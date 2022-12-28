using UI.Sales.Services;

public static class ConfigureServices
{
    public static IServiceCollection AddUi(this IServiceCollection services)
    {
        services.AddScoped<ICreateSaleViewModelFactory, CreateSaleViewModelFactory>();
        
        return services;
    }
}