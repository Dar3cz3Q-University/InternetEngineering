using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Common.Behaviors
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBehavoiurs(
            this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UserExistenceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RestaurantExistenceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(MenuExistenceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(OrderExistenceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AddressExistenceBehavior<,>));

            return services;
        }
    }
}