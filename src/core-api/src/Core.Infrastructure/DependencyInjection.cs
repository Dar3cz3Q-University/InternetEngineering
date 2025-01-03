﻿using Core.Application.Common.Interfaces.Authentication;
using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Infrastructure.Authentication;
using Core.Infrastructure.Config;
using Core.Infrastructure.Persistence;
using Core.Infrastructure.Persistence.Interceptors;
using Core.Infrastructure.Persistence.Repositories.InMemory;
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

            services.AddDbContext<MainDbContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<PublishDomainEventsInterceptor>();
            services.AddScoped<UpdateTimestampsInterceptor>();

            services.AddScoped<IUserRepository, InMemoryUserRepository>();
            services.AddScoped<IRestaurantRepository, InMemoryRestaurantRepository>();
            services.AddScoped<IMenuRepository, InMemoryMenuRepository>();
            services.AddScoped<IOrderRepository, InMemoryOrderRepository>();

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

            return services;
        }
    }
}