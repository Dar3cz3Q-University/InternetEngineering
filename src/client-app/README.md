# GlovoMaslo - Client

[![workflow status](https://github.com/KISiM-AGH/projekt-zaliczeniowy-maselniczka/actions/workflows/client.yml/badge.svg)](https://github.com/KISiM-AGH/projekt-zaliczeniowy-maselniczka/tree/master/src/client)

{description}

---

## Setup

### Requirements
* [Node](https://nodejs.org/en)

### Local development
1. Go into application directory:
   ```shell
   cd react-app
   ```
2. Create and fill environment file:
   ```shell
   cp .env.dist .env
   ```
3. Continue with [Global README.md](../../README.md)

#### If you want to run only Client app:
1. Install dependencies:
   ```shell
   npm install
   ```
2. Start application:
   ```shell
   npm run dev
   ```

---

## Configuration

### Environment Variables

All default environment variables are in [.env.dist](react-app/.env.dist)

#### Client

`VITE_APP_PORT` - port Client app starts on, default `5173`
