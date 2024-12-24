# GlovoMaslo

Glovo but only butter.

---

## Applications workflows
[![Client workflow status](https://github.com/KISiM-AGH/projekt-zaliczeniowy-maselniczka/actions/workflows/client.yml/badge.svg)](https://github.com/KISiM-AGH/projekt-zaliczeniowy-maselniczka/tree/master/src/client)

[![CoreAPI workflow status](https://github.com/KISiM-AGH/projekt-zaliczeniowy-maselniczka/actions/workflows/core-api.yml/badge.svg)](https://github.com/KISiM-AGH/projekt-zaliczeniowy-maselniczka/tree/master/src/server)

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
    * [Client](/src/client)
    * [CoreAPI](/src/server)
3. Start applications:
   ```shell
   docker compose up
   ```

---

## Configuration

### Environment Variables

All default environment variables are in [.env.dist](src/.env.dist)

#### Client

`VITE_APP_PORT` - port Client app starts on, default `5173`

#### CoreAPI

#### MSSQL
`MSSQL_SA_PASSWORD` - database sa password, default `zaq1@WSX` \
`MSSQL_PORT` - database port, default `1433`

#### Redis
`REDIS_DB` - database number for read and write operations, between `0` and `15`, default `0` \
`REDIS_HOST` - hostname of the Redis reader endpoint that connects the Redis instance as a caching layer, default `redis` \
`REDIS_PORT` - caching layer port, default `6379` \
`REDIS_PASSWORD` - instance password, default `zaq1@WSX` \
`REDIS_TLS` - whether to use TLS for the Redis connection, default `false`

#### RabbitMQ
`RABBITMQ_DEFAULT_USER` - default username, default `guest` \
`RABBITMQ_DEFAULT_PASS` - default password, default `zaq1@WSX` \
`RABBITMQ_MANAGEMENT_PORT` - management page port, default `15672` \
`RABBITMQ_AMQP_PORT` - AMQP port, default `5672` \
`RABBITMQ_MQTT_PORT` - MQTT port, default `1883`
