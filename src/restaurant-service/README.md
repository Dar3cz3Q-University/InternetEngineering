# GlovoMaslo - Restaurant Service

[![workflow status](https://github.com/KISiM-AGH/projekt-zaliczeniowy-maselniczka/actions/workflows/restaurant-service.yml/badge.svg)](https://github.com/KISiM-AGH/projekt-zaliczeniowy-maselniczka/tree/master/src/restaurant-service)

{description}

---

## Setup

### Requirements
* [Java 17](https://www.oracle.com/java/technologies/javase/jdk17-archive-downloads.html)

### Local development
1. Create and fill environment file:
   ```shell
   cp .env.dist .env
   ```
2. Continue with [Global README.md](../../README.md)

#### If you want to run only Restaurant service:
1. Install dependencies:
   ```shell
   mvn dependency:go-offline -B
   ```
2. Start application:
   ```shell
   mvn spring-boot:run
   ```

---

## Configuration

### Environment Variables

All default environment variables are in [.env.dist](.env.dist)
