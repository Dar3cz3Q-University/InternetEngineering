# GlovoMaslo - Client

[![workflow status](https://github.com/KISiM-AGH/projekt-zaliczeniowy-maselniczka/actions/workflows/client.yml/badge.svg)](https://github.com/KISiM-AGH/projekt-zaliczeniowy-maselniczka/tree/master/src/client)

{description}

---

## Setup

### Requirements
* [Node](https://nodejs.org/en)

### Local development
1. Create and fill environment file:
   ```shell
   cp .env.dist react-app/.env
   ```
2. Go into application directory:
   ```shell
   cd react-app
   ```
3. Install dependencies:
   ```shell
   npm install
   ```

* If you want to run only Client app:
  ```shell
  npm run dev
  ```

---

## Configuration

### Environment Variables

All default environment variables are in [.env.dist](.env.dist)

#### Client

`VITE_APP_PORT` - port app starts on, default `5173`
