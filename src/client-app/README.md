# GlovoMaslo - Client

[![workflow status](https://github.com/KISiM-AGH/projekt-zaliczeniowy-maselniczka/actions/workflows/client-app.yml/badge.svg)](https://github.com/KISiM-AGH/projekt-zaliczeniowy-maselniczka/tree/master/src/client-app)

{description}

---

## Setup

### Requirements
* [Node](https://nodejs.org/en)

### Local development
1. Go into application directory:
   ```shell
   cd src
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

All default environment variables are in [.env.dist](src/.env.dist)

#### Client

`CLIENT_APP_PORT` - port Client-App starts on, default `3000`
`CLIENT_NODE_ENV` - environment Client-App starts on, default `development`
