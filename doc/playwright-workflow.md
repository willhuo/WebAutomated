# Playwright 交互流程（简化版）

## 概述

使用 Playwright 与 DeepSeek 网页版交互。核心原则：**未登录时暂停等待人工登录**。

---

## 1. 浏览器初始化

```csharp
public class DeepSeekClient : IAsyncDisposable
{
    private IPlaywright? _playwright;
    private IBrowser? _browser;
    private IBrowserContext? _context;
    private IPage? _page;
    private readonly ILogger<DeepSeekClient> _logger;
    private readonly string _storageStatePath;
    
    public DeepSeekClient(ILogger<DeepSeekClient> logger, string storageStatePath)
    {
        _logger = logger;
        _storageStatePath = storageStatePath;
    }
    
    public async Task InitializeAsync()
    {
        _playwright = await Playwright.CreateAsync();
        
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false, // 必须有头模式，方便人工登录
            Args = new[] { "--no-sandbox" }
        });
        
        // 加载存储状态（如果存在）
        var contextOptions = new BrowserNewContextOptions();
        if (File.Exists(_storageStatePath))
        {
            contextOptions.StorageStatePath = _storageStatePath;
        }
        
        _context = await _browser.NewContextAsync(contextOptions);
        _page = await _context.NewPageAsync();
        _page.SetDefaultTimeout(30000);
    }
}
```

---

## 2. 登录状态检测

### 选择器

```csharp
private const string LoginIndicator = "[data-testid='chat-input'], .chat-input";
```

### 检测方法

```csharp
public async Task<bool> IsLoggedInAsync()
{
    try
    {
        await _page!.GotoAsync("https://chat.deepseek.com");
        await _page.WaitForSelectorAsync(
            LoginIndicator,
            new PageWaitForSelectorOptions { Timeout = 5000 }
        );
        return true;
    }
    catch (TimeoutException)
    {
        return false;
    }
}
```

---

## 3. 等待人工登录

**核心逻辑**：检测到未登录时，打开浏览器等待用户手动登录。

```csharp
public async Task EnsureLoggedInAsync()
{
    if (await IsLoggedInAsync())
    {
        _logger.LogInformation("DeepSeek 已登录");
        return;
    }
    
    _logger.LogWarning("DeepSeek 未登录！请在打开的浏览器中手动登录...");
    _logger.LogInformation("登录后，程序将自动继续...");
    
    // 导航到登录页面
    await _page!.GotoAsync("https://chat.deepseek.com");
    
    // 等待登录成功（轮询检测）
    while (!await IsLoggedInAsync())
    {
        await Task.Delay(1000); // 每秒检查一次
    }
    
    // 登录成功，保存状态
    await SaveStorageStateAsync();
    _logger.LogInformation("登录成功！状态已保存");
}

private async Task SaveStorageStateAsync()
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
}
```

---

## 4. 发送消息

```csharp
public async Task<string> SendMessageAsync(string message)
{
    // 确保已登录
    if (!await IsLoggedInAsync())
    {
        throw new InvalidOperationException("DeepSeek not logged in");
    }
    
    // 导航到聊天页面
    await _page!.GotoAsync("https://chat.deepseek.com");
    
    // 等待输入框
    var inputSelector = "textarea, [data-testid='chat-input'] textarea";
    await _page.WaitForSelectorAsync(inputSelector);
    
    // 输入消息
    await _page.FillAsync(inputSelector, message);
    
    // 点击发送
    var sendSelector = "button:has-text('发送'), button:has-text('Send')";
    await _page.ClickAsync(sendSelector);
    
    // 等待回复
    return await WaitForResponseAsync();
}

private async Task<string> WaitForResponseAsync()
{
    // 等待加载指示器出现
    var loadingSelector = ".loading, .typing-indicator";
    await _page!.WaitForSelectorAsync(loadingSelector, 
        new PageWaitForSelectorOptions { Timeout = 5000, State = WaitForSelectorState.Attached });
    
    // 等待加载指示器消失
    await _page.WaitForSelectorAsync(loadingSelector,
        new PageWaitForSelectorOptions { Timeout = 120000, State = WaitForSelectorState.Detached });
    
    // 获取回复内容
    var messageSelector = ".assistant-message, [data-testid='assistant-message']";
    var messages = await _page.QuerySelectorAllAsync(messageSelector);
    var lastMessage = messages.Last();
    var contentSelector = ".message-content, .prose";
    var contentElement = await lastMessage.QuerySelectorAsync(contentSelector);
    
    return (await contentElement!.InnerTextAsync()).Trim();
}
```

---

## 5. 流式响应

```csharp
public async IAsyncEnumerable<string> SendMessageStreamAsync(string message)
{
    if (!await IsLoggedInAsync())
    {
        throw new InvalidOperationException("DeepSeek not logged in");
    }
    
    await _page!.GotoAsync("https://chat.deepseek.com");
    
    var inputSelector = "textarea, [data-testid='chat-input'] textarea";
    await _page.WaitForSelectorAsync(inputSelector);
    await _page.FillAsync(inputSelector, message);
    
    var sendSelector = "button:has-text('发送'), button:has-text('Send')";
    await _page.ClickAsync(sendSelector);
    
    string lastContent = "";
    var timeout = DateTime.UtcNow.AddSeconds(120);
    
    while (DateTime.UtcNow < timeout)
    {
        var messageSelector = ".assistant-message, [data-testid='assistant-message']";
        var messages = await _page.QuerySelectorAllAsync(messageSelector);
        if (messages.Length == 0)
        {
            await Task.Delay(100);
            continue;
        }
        
        var lastMessage = messages.Last();
        var contentSelector = ".message-content, .prose";
        var contentElement = await lastMessage.QuerySelectorAsync(contentSelector);
        var currentContent = await contentElement!.InnerTextAsync();
        
        if (currentContent != lastContent)
        {
            var delta = currentContent.Substring(lastContent.Length);
            lastContent = currentContent;
            yield return delta;
        }
        
        // 检查是否完成
        var loadingSelector = ".loading, .typing-indicator";
        var loadingElement = await _page.QuerySelectorAsync(loadingSelector);
        if (loadingElement == null && lastContent.Length > 0)
        {
            break;
        }
        
        await Task.Delay(100);
    }
}
```

---

## 6. 资源释放

```csharp
public async ValueTask DisposeAsync()
{
    if (_page != null) await _page.CloseAsync();
    if (_context != null) await _context.CloseAsync();
    if (_browser != null) await _browser.CloseAsync();
    _playwright?.Dispose();
}
```
