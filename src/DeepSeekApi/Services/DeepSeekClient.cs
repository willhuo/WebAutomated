using Microsoft.Extensions.Logging;
using Microsoft.Playwright;

namespace DeepSeekApi.Services;

public class DeepSeekClient : IAsyncDisposable
{
    private IPlaywright? _playwright;
    private IBrowser? _browser;
    private IBrowserContext? _context;
    private IPage? _page;
    private readonly ILogger<DeepSeekClient> _logger;
    private readonly string _storageStatePath;
    private readonly object _lock = new();
    private bool _isInitialized;

    private const string LoginIndicator = "[data-testid='chat-input'], .chat-input, textarea";
    private const string MessageInputSelector = "textarea, [data-testid='chat-input'] textarea";
    private const string SendButtonSelector = "button:has-text('发送'), button:has-text('Send')";
    private const string AssistantMessageSelector = ".assistant-message, [data-testid='assistant-message'], .message.assistant";
    private const string MessageContentSelector = ".message-content, .prose, [data-testid='message-content']";
    private const string LoadingSelector = ".loading, .typing-indicator, [data-testid='loading']";

    public DeepSeekClient(ILogger<DeepSeekClient> logger, string storageStatePath)
    {
        _logger = logger;
        _storageStatePath = storageStatePath;
    }

    public async Task InitializeAsync()
    {
        if (_isInitialized) return;

        _logger.LogInformation("Initializing Playwright browser...");
        _playwright = await Playwright.CreateAsync();

        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            Args = new[] { "--no-sandbox", "--disable-web-security" }
        });

        var contextOptions = new BrowserNewContextOptions
        {
            IgnoreHTTPSErrors = true,
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36"
        };

        if (File.Exists(_storageStatePath))
        {
            _logger.LogInformation("Loading storage state from {Path}", _storageStatePath);
            contextOptions.StorageStatePath = _storageStatePath;
        }

        _context = await _browser.NewContextAsync(contextOptions);
        _page = await _context.NewPageAsync();
        _page.SetDefaultTimeout(30000);
        _isInitialized = true;

        _logger.LogInformation("Browser initialized successfully");
    }

    public async Task<bool> IsLoggedInAsync()
    {
        try
        {
            await _page!.GotoAsync("https://chat.deepseek.com", new PageGotoOptions { Timeout = 15000 });
            await _page.WaitForSelectorAsync(
                LoginIndicator,
                new PageWaitForSelectorOptions { Timeout = 5000 }
            );
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task EnsureLoggedInAsync()
    {
        if (await IsLoggedInAsync())
        {
            _logger.LogInformation("DeepSeek is already logged in");
            return;
        }

        _logger.LogWarning("DeepSeek not logged in! Please login manually in the browser...");
        _logger.LogInformation("Waiting for login... Program will continue automatically after successful login.");

        await _page!.GotoAsync("https://chat.deepseek.com");

        var checkCount = 0;
        while (!await IsLoggedInAsync())
        {
            await Task.Delay(2000);
            checkCount++;
            if (checkCount % 30 == 0)
            {
                _logger.LogInformation("Still waiting for login... ({0} seconds)", checkCount * 2);
            }
        }

        await SaveStorageStateAsync();
        _logger.LogInformation("Login successful! Storage state saved.");
    }

    public async Task<string> SendMessageAsync(string message)
    {
        if (!await IsLoggedInAsync())
        {
            throw new InvalidOperationException("DeepSeek not logged in. Please login first.");
        }

        _logger.LogInformation("Sending message: {Message}", message.Substring(0, Math.Min(50, message.Length)));

        await _page!.GotoAsync("https://chat.deepseek.com");
        await _page.WaitForSelectorAsync(MessageInputSelector);

        await _page.FillAsync(MessageInputSelector, message);
        await _page.WaitForSelectorAsync(SendButtonSelector);
        await _page.ClickAsync(SendButtonSelector);

        return await WaitForResponseAsync();
    }

    public async IAsyncEnumerable<string> SendMessageStreamAsync(string message)
    {
        if (!await IsLoggedInAsync())
        {
            throw new InvalidOperationException("DeepSeek not logged in. Please login first.");
        }

        _logger.LogInformation("Sending stream message: {Message}", message.Substring(0, Math.Min(50, message.Length)));

        await _page!.GotoAsync("https://chat.deepseek.com");
        await _page.WaitForSelectorAsync(MessageInputSelector);

        await _page.FillAsync(MessageInputSelector, message);
        await _page.WaitForSelectorAsync(SendButtonSelector);
        await _page.ClickAsync(SendButtonSelector);

        string lastContent = "";
        var timeout = DateTime.UtcNow.AddSeconds(120);
        var hasStarted = false;

        while (DateTime.UtcNow < timeout)
        {
            var messages = await _page.QuerySelectorAllAsync(AssistantMessageSelector);
            if (messages.Count == 0)
            {
                await Task.Delay(100);
                continue;
            }

            var lastMessage = messages.Last();
            var contentElement = await lastMessage.QuerySelectorAsync(MessageContentSelector);
            if (contentElement == null)
            {
                await Task.Delay(100);
                continue;
            }

            var currentContent = await contentElement.InnerTextAsync();

            if (currentContent != lastContent)
            {
                hasStarted = true;
                var delta = currentContent.Substring(lastContent.Length);
                lastContent = currentContent;
                yield return delta;
            }

            var loadingElement = await _page.QuerySelectorAsync(LoadingSelector);
            if (loadingElement == null && hasStarted && lastContent.Length > 0)
            {
                await Task.Delay(500);
                break;
            }

            await Task.Delay(100);
        }
    }

    private async Task<string> WaitForResponseAsync()
    {
        try
        {
            await _page!.WaitForSelectorAsync(LoadingSelector,
                new PageWaitForSelectorOptions { Timeout = 10000, State = WaitForSelectorState.Attached });
        }
        catch (TimeoutException)
        {
            _logger.LogWarning("Loading indicator not found, message may have been sent");
        }

        try
        {
            await _page.WaitForSelectorAsync(LoadingSelector,
                new PageWaitForSelectorOptions { Timeout = 120000, State = WaitForSelectorState.Detached });
        }
        catch (TimeoutException)
        {
            _logger.LogWarning("Response timeout, returning current content");
        }

        var messages = await _page.QuerySelectorAllAsync(AssistantMessageSelector);
        if (messages.Count == 0)
        {
            throw new InvalidOperationException("No assistant message found");
        }

        var lastMessage = messages.Last();
        var contentElement = await lastMessage.QuerySelectorAsync(MessageContentSelector);
        var content = await contentElement!.InnerTextAsync();

        return content.Trim();
    }

    private async Task SaveStorageStateAsync()
    {
        try
        {
            var directory = Path.GetDirectoryName(_storageStatePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            await _context!.StorageStateAsync(new BrowserContextStorageStateOptions
            {
                Path = _storageStatePath
            });

            _logger.LogInformation("Storage state saved to {Path}", _storageStatePath);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to save storage state");
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_page != null) await _page.CloseAsync();
        if (_context != null) await _context.CloseAsync();
        if (_browser != null) await _browser.CloseAsync();
        _playwright?.Dispose();
    }
}
