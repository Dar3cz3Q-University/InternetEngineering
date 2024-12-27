using Core.Infrastructure.Config;

namespace Core.Api.Config
{
    public static class HealthCheckConfig
    {
        public static IServiceCollection AddHealthCheckWithDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = ConnectionStringBuilder.Build(configuration);

            services.AddHealthChecks().AddNpgSql(
                connectionString,
                name: "PostgreSQL",
                timeout: TimeSpan.FromSeconds(5),
                tags: ["db", "critical"]
            );

            return services;
        }
    }
}