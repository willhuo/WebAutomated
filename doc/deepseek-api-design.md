# DeepSeek API 封装项目设计（简化版）

## 项目概述

将 DeepSeek 网页版封装为兼容 OpenAI API 协议的本地服务，供 AI 开发工具（如 Cursor、Windsurf 等）使用。

**核心特点**:
- 仅支持 OpenAI 兼容接口
- 无身份认证（本地工具）
- 未登录时等待人工登录
- 单一模型：deepseek-chat

---

## 技术栈

- **语言**: C# 10.0+
- **框架**: ASP.NET Core 8.0
- **浏览器自动化**: Playwright for .NET
- **日志**: Serilog
- **API 文档**: Swashbuckle (Swagger)

---

## 项目结构

```
DeepSeekApi/
├── DeepSeekApi.sln
├── src/
│   ├── DeepSeekApi/
│   │   ├── Controllers/
│   │   │   └── OpenAIController.cs      # OpenAI 兼容端点
│   │   ├── Models/
│   │   │   └── OpenAIModels.cs          # OpenAI 协议模型
│   │   ├── Services/
│   │   │   └── DeepSeekClient.cs        # Playwright 浏览器客户端
│   │   ├── AppSettings.cs               # 配置类
│   │   ├── Program.cs                   # 应用入口
│   │   ├── appsettings.json             # 配置文件
│   │   └── DeepSeekApi.csproj
│   └── DeepSeekApi.Tests/
│       ├── ModelSerializationTests.cs
│       ├── ApiIntegrationTests.cs
│       └── DeepSeekApi.Tests.csproj
├── doc/                                  # 设计文档
│   ├── deepseek-api-design.md           # 本文件
│   ├── api-specification.md             # API 接口规范
│   ├── data-models.md                   # 数据模型设计
│   ├── playwright-workflow.md           # Playwright 交互流程
│   ├── configuration-spec.md            # 配置规范
│   ├── development-tasks.md             # 开发任务清单
│   └── testing-spec.md                  # 测试规范
├── README.md
└── build.bat
```

---

## 核心模块

### 1. DeepSeekClient (Services/DeepSeekClient.cs)

**职责**: 通过 Playwright 与 DeepSeek 网页版交互

**核心方法**:
- `InitializeAsync()` - 初始化浏览器（有头模式）
- `IsLoggedInAsync()` - 检测登录状态
- `EnsureLoggedInAsync()` - 未登录时等待人工登录
- `SendMessageAsync(string)` - 发送消息并获取回复
- `SendMessageStreamAsync(string)` - 流式发送消息

**登录流程**:
1. 启动时检测登录状态
2. 未登录时打开浏览器等待用户手动登录
3. 登录成功后自动保存状态
4. 下次启动时自动恢复登录状态

---

### 2. OpenAIController (Controllers/OpenAIController.cs)

**职责**: 提供 OpenAI 兼容的 API 端点

**端点**:
- `POST /v1/chat/completions` - 聊天完成（支持流式）
- `GET /v1/models` - 列出可用模型
- `GET /v1/models/{model_id}` - 获取模型详情

---

### 3. 数据模型 (Models/OpenAIModels.cs)

**模型列表**:
- OpenAIChatCompletionRequest
- OpenAIMessage
- OpenAIChatCompletionResponse
- OpenAIChoice
- OpenAIUsage
- OpenAIChatCompletionChunk (流式)
- OpenAIModelList
- OpenAIModelInfo

---

## 配置

### appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "DeepSeekApi": {
    "Port": 5000,
    "StorageStatePath": "data/storage-state.json"
  }
}
```

### 配置项

| 配置项 | 默认值 | 说明 |
|--------|--------|------|
| Port | 5000 | API 服务端口 |
| StorageStatePath | data/storage-state.json | 登录状态文件路径 |

---

## 启动流程

```
1. 应用启动
   ↓
2. 初始化 Playwright 浏览器（有头模式）
   ↓
3. 加载登录状态（如果存在）
   ↓
4. 检测登录状态
   ├─ 已登录 → 继续启动 API 服务
   └─ 未登录 → 打开 DeepSeek 登录页面
                ↓
              等待用户手动登录
                ↓
              检测到登录成功
                ↓
              保存登录状态
                ↓
              继续启动 API 服务
   ↓
5. 启动 HTTP 服务 (http://localhost:5000)
   ↓
6. 服务就绪，等待 API 请求
```

---

## API 使用示例

### Python

```python
from openai import OpenAI

client = OpenAI(
    api_key="not-needed",
    base_url="http://localhost:5000/v1"
)

response = client.chat.completions.create(
    model="deepseek-chat",
    messages=[{"role": "user", "content": "你好"}]
)

print(response.choices[0].message.content)
```

### Node.js

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

---

## 文档索引

| 文档 | 说明 |
|------|------|
| [api-specification.md](api-specification.md) | API 接口详细规范 |
| [data-models.md](data-models.md) | 数据模型定义 |
| [playwright-workflow.md](playwright-workflow.md) | Playwright 交互流程 |
| [configuration-spec.md](configuration-spec.md) | 配置规范 |
| [development-tasks.md](development-tasks.md) | 开发任务清单 |
| [testing-spec.md](testing-spec.md) | 测试规范 |
