using Application.Customers.Commands.CreateCustomer;
using Application.Customers.Queries.GetCustomerList;
using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Queries.GetEmployeeList;
using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetProductsList;
using Application.Sales.Commands.CreateSale;
using Application.Sales.Commands.CreateSale.Factory;
using Application.Sales.Commands.CreateSale.Repository;
using Application.Sales.Queries.GetSalesDetail;
using Application.Sales.Queries.GetSalesList;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration;

public static class ConfigureServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IGetCustomersListQuery, GetCustomersListQuery>();
        services.AddScoped<IGetEmployeesListQuery, GetEmployeesListQuery>();
        services.AddScoped<IGetProductsListQuery, GetProductsListQuery>();
        services.AddScoped<IGetSalesListQuery, GetSalesListQuery>();
        services.AddScoped<IGetSaleDetailQuery, GetSaleDetailQuery>();
        
        services.AddScoped<ICreateSaleCommand, CreateSaleCommand>();
        services.AddScoped<ICreateCustomerCommand, CreateCustomerCommand>();
        services.AddScoped<ICreateEmployeeCommand, CreateEmployeeCommand>();
        services.AddScoped<ICreateProductCommand, CreateProductCommand>();

        services.AddScoped<ISaleFactory, SaleFactory>();
        services.AddScoped<ISaleRepositoryFacade, SaleRepositoryFacade>();
        
        return services;
    }
}