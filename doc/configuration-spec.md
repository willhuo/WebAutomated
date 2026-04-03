# 配置规范（简化版）

## 配置文件

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

## 配置项说明

| 配置项 | 类型 | 默认值 | 说明 |
|--------|------|--------|------|
| Port | int | 5000 | API 服务端口 |
| StorageStatePath | string | data/storage-state.json | 登录状态文件路径 |

## 配置类

```csharp
public class AppSettings
{
    public int Port { get; set; } = 5000;
    public string StorageStatePath { get; set; } = "data/storage-state.json";
}
```

## 环境变量覆盖

- `DEEPSEEK_API_PORT` - 覆盖端口
- `DEEPSEEK_STORAGE_PATH` - 覆盖状态文件路径
