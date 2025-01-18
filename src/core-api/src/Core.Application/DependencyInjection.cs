using Core.Application.Common.Behaviors;
using Core.Application.Common.Mapping;
using Core.Application.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services,
            IConfigurationManager configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddHttpContextAccessor();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMappings();

            services.AddBehavoiurs();

            services.AddServices(configuration);

            return services;
        }
    }
}