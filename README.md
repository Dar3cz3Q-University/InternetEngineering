# GlovoMaslo

Glovo but only butter.

---

## Applications workflows
[![Client-App workflow status](https://github.com/KISiM-AGH/projekt-zaliczeniowy-maselniczka/actions/workflows/client-app.yml/badge.svg)](https://github.com/KISiM-AGH/projekt-zaliczeniowy-maselniczka/tree/master/src/client)

[![Core-Api workflow status](https://github.com/KISiM-AGH/projekt-zaliczeniowy-maselniczka/actions/workflows/core-api.yml/badge.svg)](https://github.com/KISiM-AGH/projekt-zaliczeniowy-maselniczka/tree/master/src/server)

---

## Setup

### Requirements
* [Docker](https://www.docker.com/)

### Local development
1. Clone the repository:
   ```shell
   git clone https://github.com/KISiM-AGH/projekt-zaliczeniowy-maselniczka.git
   cd projekt-zaliczeniowy-maselniczka
   ```
2. Setup applications:
    * [Client-App](/src/client-app)
    * [Core-Api](/src/core-api)
3. Start applications:
   ```shell
   docker compose up --watch
   ```

---

## Configuration

### Environment Variables

All default environment variables are in [.env.dist](src/.env.dist)
