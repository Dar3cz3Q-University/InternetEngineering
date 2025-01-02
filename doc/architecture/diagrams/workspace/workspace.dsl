workspace  {

    model {
        maselniczka = softwareSystem "Maselniczka" {
            group "Application-Network" {
                coreapi = container "Core-Api" "Main REST Api" ".Net" "Service"
                restaurantservice = container "Restaurant-Service" "Service mocking restaurant" "SpringBoot" "Service"

                rabbit = container "MQTT" "Handles messages" "rabbitmq" "Queue"
                postgre = container "PostgreSQL" "Main database" "postgres-db" "Database"
                mongo = container "MongoDB" "Database for restaurant service" "mongo-db" "Database"
            }

            group "Client-Network" {
                clientapp = container "Client-App" "Frontend application" "Next.js" "UI"
            }
        }

        clientapp -> coreapi "API Requests" "HTTP 8080"
        coreapi -> postgre "Query data" "TCP 5432"
        coreapi -> rabbit "Publish new order" "MQTT 1883"
        rabbit -> coreapi "Subscribe for order status update" "MQTT 1883"
        rabbit -> restaurantservice "Subscribe for new order" "MQTT 1883"
        restaurantservice -> rabbit "Publish order status update" "MQTT 1883"
        restaurantservice -> mongo "Query data" "TCP 27017"
    }

    views {
        systemContext maselniczka {
            include *
            autolayout lr
        }

        container maselniczka "Maselniczka" {
            include *
        }

        styles {
            element "UI" {
                shape WebBrowser
                color #ffffff
                background #0000fc
            }
            element "Queue" {
                shape Pipe
            }
            element "Service" {
                shape Box
                color #ffffff
                background #0000fc
            }
            element "Database" {
                shape cylinder
            }
        }
    }

    configuration {
        scope softwaresystem
    }
}
