# 测试规范（简化版）

## 测试策略

| 类型 | 工具 | 目标 |
|------|------|------|
| 单元测试 | xUnit + Moq | 测试模型序列化和工具方法 |
| 集成测试 | WebApplicationFactory | 测试 API 端点 |

---

## 单元测试

### 模型序列化测试

```csharp
public class ModelSerializationTests
{
    [Fact]
    public void OpenAIChatCompletionRequest_SerializeCorrectly()
    {
        var request = new OpenAIChatCompletionRequest
        {
            Model = "deepseek-chat",
            Messages = new List<OpenAIMessage>
            {
                new() { Role = "user", Content = "Hello" }
            },
            Stream = false
        };

        var json = JsonSerializer.Serialize(request);
        var deserialized = JsonSerializer.Deserialize<OpenAIChatCompletionRequest>(json);

        Assert.Equal("deepseek-chat", deserialized.Model);
        Assert.Single(deserialized.Messages);
        Assert.Equal("Hello", deserialized.Messages[0].Content);
    }

    [Fact]
    public void OpenAIChatCompletionResponse_SerializeCorrectly()
    {
        var response = new OpenAIChatCompletionResponse
        {
            Id = "chatcmpl-123",
            Created = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            Choices = new List<OpenAIChoice>
            {
                new()
                {
                    Index = 0,
                    Message = new OpenAIMessage { Role = "assistant", Content = "Hi" },
                    FinishReason = "stop"
                }
            },
            Usage = new OpenAIUsage
            {
                PromptTokens = 10,
                CompletionTokens = 20,
                TotalTokens = 30
            }
        };

        var json = JsonSerializer.Serialize(response);
        var deserialized = JsonSerializer.Deserialize<OpenAIChatCompletionResponse>(json);

        Assert.Equal("chat.completion", deserialized.Object);
        Assert.Single(deserialized.Choices);
        Assert.Equal(30, deserialized.Usage.TotalTokens);
    }
}
```

---

## 集成测试

### API 端点测试

```csharp
public class ApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ApiIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetModels_ReturnsModelList()
    {
        var response = await _client.GetAsync("/v1/models");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<OpenAIModelList>(content);

        Assert.NotNull(result);
        Assert.Single(result.Data);
        Assert.Equal("deepseek-chat", result.Data[0].Id);
    }

    [Fact]
    public async Task GetModel_WithValidId_ReturnsModel()
    {
        var response = await _client.GetAsync("/v1/models/deepseek-chat");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<OpenAIModelInfo>(content);

        Assert.NotNull(result);
        Assert.Equal("deepseek-chat", result.Id);
    }

    [Fact]
    public async Task GetModel_WithInvalidId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/v1/models/invalid-model");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
```

---

## 运行测试

```bash
# 运行所有测试
dotnet test

# 运行特定测试
dotnet test --filter "ModelSerializationTests"
```
