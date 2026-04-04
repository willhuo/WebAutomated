using System.Text.Json;
using DeepSeekApi.Models;
using DeepSeekApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeepSeekApi.Controllers;

[ApiController]
[Route("v1")]
public class OpenAIController : ControllerBase
{
    private readonly DeepSeekClient _client;
    private readonly ILogger<OpenAIController> _logger;

    public OpenAIController(DeepSeekClient client, ILogger<OpenAIController> logger)
    {
        _client = client;
        _logger = logger;
    }

    [HttpPost("chat/completions")]
    public async Task<IActionResult> ChatCompletions([FromBody] OpenAIChatCompletionRequest request)
    {
        try
        {
            if (request.Messages == null || request.Messages.Count == 0)
            {
                return BadRequest(CreateOpenAIError("messages array is required", "invalid_request_error"));
            }

            var userMessage = string.Join("\n", request.Messages.Where(m => m.Role != "system").Select(m => m.Content));
            var systemMessage = request.Messages.FirstOrDefault(m => m.Role == "system")?.Content;

            if (!string.IsNullOrEmpty(systemMessage))
            {
                userMessage = systemMessage + "\n" + userMessage;
            }

            if (request.Stream)
            {
                return await HandleStreamResponse(userMessage);
            }
            else
            {
                return await HandleNormalResponse(userMessage);
            }
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError(ex, "DeepSeek client error");
            return StatusCode(503, CreateOpenAIError(ex.Message, "service_unavailable"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Internal server error");
            return StatusCode(500, CreateOpenAIError("Internal server error", "api_error"));
        }
    }

    private async Task<IActionResult> HandleNormalResponse(string message)
    {
        var content = await _client.SendMessageAsync(message);

        var response = new OpenAIChatCompletionResponse
        {
            Id = $"chatcmpl-{Guid.NewGuid():N}",
            Object = "chat.completion",
            Created = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            Model = "deepseek-chat",
            Choices = new List<OpenAIChoice>
            {
                new()
                {
                    Index = 0,
                    Message = new OpenAIMessage { Role = "assistant", Content = content },
                    FinishReason = "stop"
                }
            },
            Usage = EstimateTokens(message, content)
        };

        return Ok(response);
    }

    private async Task<IActionResult> HandleStreamResponse(string message)
    {
        Response.Headers.Append("Content-Type", "text/event-stream");
        Response.Headers.Append("Cache-Control", "no-cache");
        Response.Headers.Append("Connection", "keep-alive");

        var completionId = $"chatcmpl-{Guid.NewGuid():N}";
        var created = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        var roleChunk = new OpenAIChatCompletionChunk
        {
            Id = completionId,
            Object = "chat.completion.chunk",
            Created = created,
            Model = "deepseek-chat",
            Choices = new List<OpenAIChunkChoice>
            {
                new()
                {
                    Index = 0,
                    Delta = new OpenAIDelta { Role = "assistant" },
                    FinishReason = null
                }
            }
        };
        await WriteSseChunkAsync(roleChunk);

        await foreach (var delta in _client.SendMessageStreamAsync(message))
        {
            var contentChunk = new OpenAIChatCompletionChunk
            {
                Id = completionId,
                Object = "chat.completion.chunk",
                Created = created,
                Model = "deepseek-chat",
                Choices = new List<OpenAIChunkChoice>
                {
                    new()
                    {
                        Index = 0,
                        Delta = new OpenAIDelta { Content = delta },
                        FinishReason = null
                    }
                }
            };
            await WriteSseChunkAsync(contentChunk);
        }

        var doneChunk = new OpenAIChatCompletionChunk
        {
            Id = completionId,
            Object = "chat.completion.chunk",
            Created = created,
            Model = "deepseek-chat",
            Choices = new List<OpenAIChunkChoice>
            {
                new()
                {
                    Index = 0,
                    Delta = new OpenAIDelta(),
                    FinishReason = "stop"
                }
            }
        };
        await WriteSseChunkAsync(doneChunk);

        await Response.WriteAsync("data: [DONE]\n\n");
        await Response.Body.FlushAsync();

        return new EmptyResult();
    }

    private async Task WriteSseChunkAsync(OpenAIChatCompletionChunk chunk)
    {
        var json = JsonSerializer.Serialize(chunk);
        await Response.WriteAsync($"data: {json}\n\n");
        await Response.Body.FlushAsync();
    }

    [HttpGet("models")]
    public IActionResult ListModels()
    {
        var response = new OpenAIModelList
        {
            Object = "list",
            Data = new List<OpenAIModelInfo>
            {
                new()
                {
                    Id = "deepseek-chat",
                    Object = "model",
                    Created = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                    OwnedBy = "deepseek"
                }
            }
        };

        return Ok(response);
    }

    [HttpGet("models/{modelId}")]
    public IActionResult GetModel(string modelId)
    {
        if (modelId != "deepseek-chat")
        {
            return NotFound(CreateOpenAIError($"Model '{modelId}' does not exist", "invalid_request_error", "model"));
        }

        var response = new OpenAIModelInfo
        {
            Id = "deepseek-chat",
            Object = "model",
            Created = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            OwnedBy = "deepseek"
        };

        return Ok(response);
    }

    private static object CreateOpenAIError(string message, string type, string? param = null)
    {
        return new
        {
            error = new
            {
                message,
                type,
                param,
                code = (string?)null
            }
        };
    }

    private static OpenAIUsage EstimateTokens(string prompt, string completion)
    {
        var promptTokens = (int)Math.Ceiling(prompt.Length / 2.0);
        var completionTokens = (int)Math.Ceiling(completion.Length / 2.0);

        return new OpenAIUsage
        {
            PromptTokens = promptTokens,
            CompletionTokens = completionTokens,
            TotalTokens = promptTokens + completionTokens
        };
    }
}
