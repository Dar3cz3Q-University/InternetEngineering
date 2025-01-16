
using Core.Api;
using Core.Application;
using Core.Infrastructure;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
{
    // TODO: Add HTTPS port
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(5042);
    });

    builder.Configuration
        .AddJsonFile("appsettings.json")
        .AddJsonFile("appsettings.Development.json")
        .AddEnvironmentVariables();

    builder.Services
        .AddPresentation(builder.Configuration)
        .AddApplication(builder.Configuration)
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UsePathBase("/api/v1");

    app.MapHealthChecks("/_health", new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

    app.UseExceptionHandler("/error");

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.UseStaticFiles();

    app.Run();
}