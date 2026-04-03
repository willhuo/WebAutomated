# WebAutomated

DeepSeek 网页版 API 封装服务 - 将 DeepSeek 网页版封装为兼容 OpenAI API 协议的本地服务。

## 功能特点

- **OpenAI API 兼容**: 无缝对接 Cursor、Windsurf 等 AI 开发工具
- **本地运行**: 无需云端部署，直接在本地电脑运行
- **自动登录**: 首次手动登录后自动保存状态，后续自动恢复
- **流式响应**: 支持 SSE 流式输出

## 快速开始

详见 [项目设计文档](doc/deepseek-api-design.md)

## 文档

- [API 接口规范](doc/api-specification.md)
- [数据模型设计](doc/data-models.md)
- [Playwright 交互流程](doc/playwright-workflow.md)
- [配置规范](doc/configuration-spec.md)
- [开发任务清单](doc/development-tasks.md)
- [测试规范](doc/testing-spec.md)
