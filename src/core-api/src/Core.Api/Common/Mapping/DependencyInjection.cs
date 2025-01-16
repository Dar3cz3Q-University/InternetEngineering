using Core.Application.Common.Config;
using Mapster;
using MapsterMapper;
using System.Reflection;

namespace Core.Api.Common.Mapping
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            config.ForType<IHeaderDictionary, IHeaderDictionary>()
                .MapWith(_ => null);

            config.ForType<IFormFile, IFormFile>()
                .MapWith(src => src);

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}