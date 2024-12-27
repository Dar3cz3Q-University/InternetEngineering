using Core.Api.Common.Errors;
using Core.Api.Common.Mapping;
using Core.Api.Config;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Core.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddSingleton<ProblemDetailsFactory, CoreProblemDetailsFactory>();

            services.AddHealthCheckWithDatabase(configuration);

            services.AddMappings();

            return services;
        }
    }
}