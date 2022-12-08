using Application.Interfaces.Infrastructure;
using Infrastructure.Network;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IInventoryService, InventoryService.InventoryService>();
        services.AddScoped<IWebClientWrapper, WebClientWrapper>();

        return services;
    }
}