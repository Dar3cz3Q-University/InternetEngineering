using Core.Application.Common.Behaviors;
using Core.Application.Common.Config;
using Core.Application.Common.Interfaces.Services;
using Core.Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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

            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IImageSaver, ImageSaver>();
            services.AddScoped<IUserContextService, UserContextService>();

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UserExistenceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RestaurantExistenceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(MenuExistenceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(OrderExistenceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AddressExistenceBehavior<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 10 * 1024 * 1024; // TODO: Move to different file
            });

            var staticFilesSettings = new StaticFilesSettings();
            configuration.Bind(StaticFilesSettings.SECTION_NAME, staticFilesSettings);

            services.AddSingleton(Options.Create(staticFilesSettings));

            return services;
        }
    }
}