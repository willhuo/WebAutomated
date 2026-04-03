# 开发任务清单（简化版）

## 执行顺序

严格按照 Phase 1 → Phase 2 → Phase 3 → Phase 4 的顺序执行。

---

## Phase 1: 项目初始化

### Task 1.1: 创建项目结构

**执行步骤**:

```bash
# 创建目录
mkdir -p DeepSeekApi/src/DeepSeekApi
mkdir -p DeepSeekApi/src/DeepSeekApi.Tests
cd DeepSeekApi

# 创建解决方案
dotnet new sln -n DeepSeekApi

# 创建主项目
cd src/DeepSeekApi
dotnet new webapi -n DeepSeekApi --no-https
cd ../..

# 创建测试项目
cd src/DeepSeekApi.Tests
dotnet new xunit -n DeepSeekApi.Tests
cd ../..

# 添加项目引用
dotnet sln add src/DeepSeekApi/DeepSeekApi.csproj
dotnet sln add src/DeepSeekApi.Tests/DeepSeekApi.Tests.csproj
dotnet add src/DeepSeekApi.Tests/DeepSeekApi.Tests.csproj reference src/DeepSeekApi/DeepSeekApi.csproj
```

**验收**: `dotnet build` 成功

---

### Task 1.2: 安装 NuGet 包

```bash
cd src/DeepSeekApi
dotnet add package Microsoft.Playwright --version 1.40.0
dotnet add package Serilog.AspNetCore --version 8.0.0
dotnet add package Swashbuckle.AspNetCore --version 6.5.0
```

**验收**: 包安装成功

---

### Task 1.3: 创建目录结构

```
src/DeepSeekApi/
├── Controllers/
├── Models/
├── Services/
└── Program.cs
```

---

## Phase 2: 核心服务

### Task 2.1: 实现配置和模型

**参考文档**: `configuration-spec.md`, `data-models.md`

**文件**:
- `Models/OpenAIModels.cs` - 所有 OpenAI 兼容模型
- `AppSettings.cs` - 配置类

**验收**: 编译通过

---

### Task 2.2: 实现 DeepSeekClient

**参考文档**: `playwright-workflow.md`

**文件**: `Services/DeepSeekClient.cs`

**实现方法**:
- `InitializeAsync()` - 初始化浏览器
- `IsLoggedInAsync()` - 检测登录状态
- `EnsureLoggedInAsync()` - 等待人工登录
- `SendMessageAsync(string message)` - 发送消息
- `SendMessageStreamAsync(string message)` - 流式发送
- `DisposeAsync()` - 释放资源

**验收**: 浏览器可以启动，登录检测正常

---

## Phase 3: API 控制器

### Task 3.1: 实现 OpenAI 兼容控制器

**参考文档**: `api-specification.md`

**文件**: `Controllers/OpenAIController.cs`

**端点**:
- `POST /v1/chat/completions` - 聊天完成
- `GET /v1/models` - 列出模型
- `GET /v1/models/{model_id}` - 检索模型

**验收**: 端点可以正常响应

---

### Task 3.2: 实现 Program.cs

**文件**: `Program.cs`

**关键代码**:
```csharp
var builder = WebApplication.CreateBuilder(args);

// 配置
builder.Services.Configure<AppSettings>(
    builder.Configuration.GetSection("DeepSeekApi"));

// 注册服务
builder.Services.AddSingleton<DeepSeekClient>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 中间件
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

// 初始化并检查登录
var client = app.Services.GetRequiredService<DeepSeekClient>();
await client.InitializeAsync();
await client.EnsureLoggedInAsync();

app.Run($"http://localhost:{app.Configuration["DeepSeekApi:Port"] ?? "5000"}");
```

**验收**: 应用启动成功，浏览器打开等待登录

---

## Phase 4: 配置文件

### Task 4.1: 创建 appsettings.json

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

---

### Task 4.2: 创建项目文件

**文件**: `src/DeepSeekApi/DeepSeekApi.csproj`

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.Playwright" Version="1.40.0" />
    <PackageReference Include="Serilog.AspNetCore" Version="8.0.0" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
  </ItemGroup>
</Project>
```

---

## 执行总结

```
Phase 1: 项目初始化
  ├─ Task 1.1: 创建项目结构
  ├─ Task 1.2: 安装 NuGet 包
  └─ Task 1.3: 创建目录

Phase 2: 核心服务
  ├─ Task 2.1: 配置和模型
  └─ Task 2.2: DeepSeekClient

Phase 3: API 控制器
  ├─ Task 3.1: OpenAI 控制器
  └─ Task 3.2: Program.cs

Phase 4: 配置文件
  ├─ Task 4.1: appsettings.json
  └─ Task 4.2: 项目文件
```
