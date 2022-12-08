using Common.Dates;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Configuration;

public static class ConfigureServices
{
    public static IServiceCollection AddCommon(this IServiceCollection services)
    {
        services.AddScoped<IDateService, DateService>();
        
        return services;
    }
}