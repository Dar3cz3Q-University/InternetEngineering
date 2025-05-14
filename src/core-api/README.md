# GlovoMaslo - CoreAPI

[![workflow status](https://github.com/Dar3cz3Q-University/InternetEngineering/actions/workflows/core-api.yml/badge.svg)](https://github.com/Dar3cz3Q-University/InternetEngineering/tree/master/src/core-api)

{description}

---

## Setup

### Requirements
* [.NET 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

### Local development
1. Create and fill environment file:
   ```shell
   cp .env.dist .env
   ```
2. Continue with [Global README.md](../../README.md)

#### If you want to run only Core api:
1. Install dependencies:
   ```shell
   dotnet restore "./Core.Api/Core.Api.csproj"
   ```
2. Start application:
   ```shell
   dotnet watch run --project "./Core.Api/Core.Api.csproj"
   ```

---

## Configuration

### Environment Variables

All default environment variables are in [.env.dist](.env.dist)
