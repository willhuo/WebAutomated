# DeepSeek API 接口规范（简化版）

## 基础信息

- **Base URL**: `http://localhost:{port}`
- **认证方式**: 无（本地工具）
- **响应格式**: JSON
- **字符编码**: UTF-8

---

## 支持的 API 端点

### 1. 聊天完成 (Chat Completions)

**端点**: `POST /v1/chat/completions`

**请求体**:
```json
{
  "model": "deepseek-chat",
  "messages": [
    {"role": "system", "content": "你是一个有用的助手"},
    {"role": "user", "content": "你好"}
  ],
  "stream": false
}
```

**请求参数**:
| 参数 | 类型 | 必填 | 说明 |
|------|------|------|------|
| model | string | 是 | 固定为 "deepseek-chat" |
| messages | array | 是 | 消息数组 |
| messages[].role | string | 是 | system/user/assistant |
| messages[].content | string | 是 | 消息内容 |
| stream | bool | 否 | 是否流式输出，默认 false |

**响应示例** (非流式):
```json
{
  "id": "chatcmpl-12345",
  "object": "chat.completion",
  "created": 1704067200,
  "model": "deepseek-chat",
  "choices": [
    {
      "index": 0,
      "message": {
        "role": "assistant",
        "content": "你好！有什么可以帮助你的吗？"
      },
      "finish_reason": "stop"
    }
  ],
  "usage": {
    "prompt_tokens": 20,
    "completion_tokens": 100,
    "total_tokens": 120
  }
}
```

**流式响应** (SSE):
```
data: {"id":"chatcmpl-12345","object":"chat.completion.chunk","created":1704067200,"model":"deepseek-chat","choices":[{"index":0,"delta":{"role":"assistant","content":"你"},"finish_reason":null}]}

data: {"id":"chatcmpl-12345","object":"chat.completion.chunk","created":1704067200,"model":"deepseek-chat","choices":[{"index":0,"delta":{"role":"assistant","content":"好"},"finish_reason":null}]}

data: {"id":"chatcmpl-12345","object":"chat.completion.chunk","created":1704067200,"model":"deepseek-chat","choices":[{"index":0,"delta":{},"finish_reason":"stop"}]}

data: [DONE]
```

---

### 2. 列出模型

**端点**: `GET /v1/models`

**响应**:
```json
{
  "object": "list",
  "data": [
    {
      "id": "deepseek-chat",
      "object": "model",
      "created": 1704067200,
      "owned_by": "deepseek"
    }
  ]
}
```

---

### 3. 检索模型

**端点**: `GET /v1/models/{model_id}`

**响应**:
```json
{
  "id": "deepseek-chat",
  "object": "model",
  "created": 1704067200,
  "owned_by": "deepseek"
}
```

---

## 错误响应

```json
{
  "error": {
    "message": "错误描述",
    "type": "错误类型",
    "param": null,
    "code": null
  }
}
```

**常见错误**:
| 场景 | HTTP 状态码 | message |
|------|------------|---------|
| 未登录 DeepSeek | 503 | DeepSeek not logged in. Please login first. |
| 模型不存在 | 404 | Model 'xxx' does not exist |
| 服务器错误 | 500 | Internal server error |

---

## 客户端集成示例

### Python SDK

```python
from openai import OpenAI

client = OpenAI(
    api_key="not-needed",  # 不需要，但必须提供
    base_url="http://localhost:5000/v1"
)

response = client.chat.completions.create(
    model="deepseek-chat",
    messages=[{"role": "user", "content": "你好"}]
)

print(response.choices[0].message.content)
```

### Node.js SDK

```javascript
import OpenAI from "openai";

const openai = new OpenAI({
  apiKey: "not-needed",
  baseURL: "http://localhost:5000/v1",
});

const response = await openai.chat.completions.create({
  model: "deepseek-chat",
  messages: [{ role: "user", content: "你好" }],
});

console.log(response.choices[0].message.content);
```
