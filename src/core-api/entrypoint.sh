#!/bin/bash
set -e

cd app

echo "Applying database migrations..."
dotnet ef database update --project ./Core.Infrastructure/Core.Infrastructure.csproj --startup-project ./Core.Api/Core.Api.csproj --msbuildprojectextensionspath ./Core.Api/obj/container || {
    echo "Migration failed, continuing to start the application..."
}

echo "Starting application in watch mode..."
exec dotnet watch run --project ./Core.Api/Core.Api.csproj
