using Application.Interfaces.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Customers;
using Persistence.Database;
using Persistence.Employees;
using Persistence.Products;
using Persistence.Sales;

namespace Persistence.Configuration;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddSingleton<IDatabaseContext, DatabaseContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        
        return services;
    }
}