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
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UserExistenceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RestaurantExistenceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(MenuExistenceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(OrderExistenceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AddressExistenceBehavior<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}