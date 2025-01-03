using Core.Application.Common.Behaviors;
using Core.Application.Common.Interfaces.Services;
using Core.Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddScoped<IAddressService, AddressService>();

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateUserExistenceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateRestaurantExistenceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateMenuExistenceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateOrderExistenceBehavior<,>));
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateAddressExistenceBehavior<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}