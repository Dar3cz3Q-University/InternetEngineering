using Microsoft.Extensions.Configuration;

namespace Core.Infrastructure.Config
{
    public static class ConnectionStringBuilder
    {
        public static string Build(IConfiguration configuration)
        {
            var connectionStringTemplate = configuration.GetConnectionString("MainConnection");

            return connectionStringTemplate
                .Replace("{POSTGRES_DB_HOST}", Environment.GetEnvironmentVariable("POSTGRES_DB_HOST") ?? "localhost")
                .Replace("{POSTGRES_DB_PORT}", Environment.GetEnvironmentVariable("POSTGRES_DB_PORT") ?? "5432")
                .Replace("{POSTGRES_DB_NAME}", Environment.GetEnvironmentVariable("POSTGRES_DB_NAME") ?? "db")
                .Replace("{POSTGRES_DB_USER}", Environment.GetEnvironmentVariable("POSTGRES_DB_USER") ?? "user")
                .Replace("{POSTGRES_DB_PASSWORD}", Environment.GetEnvironmentVariable("POSTGRES_DB_PASSWORD") ?? "password");
        }
    }
}