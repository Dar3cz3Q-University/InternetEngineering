using Core.Application.Common.Config;
using Core.Application.Common.Interfaces.Messaging;
using Core.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Core.Application.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services,
            IConfigurationManager configuration)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IImageSaver, ImageSaver>();
            services.AddScoped<IUserContextService, UserContextService>();

            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 10 * 1024 * 1024; // TODO: Move to different file
            });

            var staticFilesSettings = new StaticFilesSettings();
            configuration.Bind(StaticFilesSettings.SECTION_NAME, staticFilesSettings);

            services.AddSingleton(Options.Create(staticFilesSettings));

            services.AddScoped<IMqttMessageHandler, MqttMessageHandler>();

            return services;
        }
    }
}