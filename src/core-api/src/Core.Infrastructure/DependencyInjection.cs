using Core.Application.Common.Interfaces.Authentication;
using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Infrastructure.Authentication.Password;
using Core.Infrastructure.Authentication.Token;
using Core.Infrastructure.Config;
using Core.Infrastructure.Persistence;
using Core.Infrastructure.Persistence.Interceptors;
using Core.Infrastructure.Persistence.Repositories;
using Core.Infrastructure.Persistence.Services;
using Core.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfigurationManager configuration)
        {
            services.AddAuth(configuration);

            services.AddPersistance(configuration);

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }

        public static IServiceCollection AddPersistance(
            this IServiceCollection services,
            IConfigurationManager configuration)
        {
            var connectionString = ConnectionStringBuilder.Build(configuration);

            services.AddDbContext<MainDbContext>(options =>
                options.UseLazyLoadingProxies().UseNpgsql(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<PublishDomainEventsInterceptor>();
            services.AddScoped<UpdateTimestampsInterceptor>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            return services;
        }

        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            IConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SECTION_NAME, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            var passwordHashingOptions = new PasswordHashingOptions();
            configuration.Bind(PasswordHashingOptions.SECTION_NAME, passwordHashingOptions);

            services.AddSingleton(Options.Create(passwordHashingOptions));
            services.AddSingleton<IPasswordHasher, Argon2PasswordHasher>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
            });

            return services;
        }
    }
}