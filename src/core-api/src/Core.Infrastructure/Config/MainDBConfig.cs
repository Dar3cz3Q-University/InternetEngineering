using Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Config
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = ConnectionStringBuilder.Build(configuration);

            services.AddDbContext<MainDBContext>(options => options.UseNpgsql(connectionString));

            return services;
        }
    }
}