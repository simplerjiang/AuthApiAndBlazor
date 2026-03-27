# AuthApiAndBlazor

一个基于 **Blazor + ASP.NET Core Web API + JWT + Identity** 的全栈认证示例项目。

这个仓库主要演示的是：

- 前端如何完成注册、登录、退出
- 后端如何结合 ASP.NET Core Identity 与 JWT 签发认证令牌
- 前后端如何共享认证相关的数据模型
- Blazor 客户端如何在本地保存 token 并维护认证状态

English summary: a full-stack authentication sample using Blazor, ASP.NET Core Web API, JWT, Identity, and shared contracts.

## 项目结构

```text
client/    Blazor 客户端，包含登录、注册、认证状态管理
server/    ASP.NET Core 3.1 API，负责 Identity、JWT、认证接口
server2.2/ ASP.NET Core 2.2 版本的后端实现
shared/    前后端共享的数据模型与返回结果类型
```

## 技术栈

### Client

- Blazor（早期 WebAssembly 方案）
- Blazored.LocalStorage
- AuthenticationStateProvider

### Server

- ASP.NET Core 3.1 Web API
- ASP.NET Core Identity
- JWT Bearer Authentication
- Entity Framework Core
- Pomelo.EntityFrameworkCore.MySql

### Shared

- .NET Standard 2.0 共享模型
- 登录 / 注册 DTO
- 认证结果返回对象

## 当前实现的主要功能

根据当前源码，这个项目已经包含以下典型认证流程：

- **注册接口**：创建 `IdentityUser`
- **登录接口**：校验用户名密码并签发 JWT
- **客户端认证服务**：调用登录与注册 API
- **本地 token 保存**：使用 LocalStorage 保存认证令牌
- **认证状态同步**：登录后更新 Blazor 的 AuthenticationState
- **共享模型**：客户端与服务端共用 `LoginModel`、`RegisterModel`、结果对象等类型

## 关键代码位置

### 后端认证相关

- `server/Controllers/LoginController.cs`
- `server/Controllers/RegisterController.cs`
- `server/Startup.cs`
- `server/Data/ApplicationDbContext.cs`

### 客户端认证相关

- `client/Services/AuthService.cs`
- `client/Providers/ApiAuthenticationStateProvider.cs`
- `client/Pages/Login.razor`
- `client/Pages/Register.razor`

### 共享模型

- `shared/LoginModel.cs`
- `shared/RegisterModel.cs`
- `shared/LoginResult.cs`
- `shared/RegisterResult.cs`

## 认证流程概览

1. 用户在 Blazor 客户端提交注册或登录表单
2. 客户端调用后端 API
3. 后端通过 ASP.NET Core Identity 完成用户校验或创建
4. 登录成功后，后端签发 JWT
5. 客户端将 token 存入 LocalStorage
6. 客户端更新认证状态，并在后续请求中携带 Bearer Token

## 运行说明

这个仓库是一个示例性质的认证项目，适合学习或继续扩展。启动前建议先确认：

- 数据库连接字符串
- JWT 相关配置（Issuer / Audience / SecurityKey / Expiry）
- MySQL 环境是否可用

后端配置入口主要在：

- `server/appsettings.json`
- `server/appsettings.Development.json`

## 适合什么场景

这个项目适合当作以下方向的参考起点：

- Blazor 登录注册系统
- ASP.NET Core Identity + JWT 的基础整合
- 前后端共享 DTO 的全栈项目结构
- 认证状态在前端的保存与恢复

## 说明

仓库中同时保留了 `server`（3.1）和 `server2.2` 两套后端实现，反映了项目从较早版本向更新框架迁移和实验的过程。

如果你正在整理自己的认证 Demo，或者想快速理解一个早期 Blazor 全栈认证样例，这个仓库会很直观。