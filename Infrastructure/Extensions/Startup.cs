
using Infrastructure.Context.Application;
using Infrastructure.Extensions.Cors;
using Infrastructure.Extensions.DomainService;
using Infrastructure.Extensions.HandlerService;
using Infrastructure.Extensions.OpenApi;
using Infrastructure.Extensions.Persistence;
using Infrastructure.Initialize;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class Startup
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
    {
        services    
            .AddPersistence(config)
            .AddOpenApiDocumentation(env)
            .AddCorsPolicy(config)
            .AddRepositories(config)
            .AddDomainServices()
            .AddHandlerServices();



    }
    public static void UseInfrastructure(this IApplicationBuilder builder)
    {
        builder
           
            .UseCorsPolicy();
    }

    public static async Task InitializeDatabasesAsync(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
        var contex = scope!.ServiceProvider.GetRequiredService<PersistenceContext>();
        var start = new Start(contex);
        try
        {
            await start.InitializeDatabasesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
  
}