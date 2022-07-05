using System.Text.Json.Serialization;
using Api.Utils;
using Application.Customers.Commands.CreateCustomer;
using Application.Customers.Queries.GetCustomerList;
using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Queries.GetEmployeeList;
using Application.Interfaces;
using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetProductsList;
using Application.Sales.Commands.CreateSale;
using Application.Sales.Commands.CreateSale.Factory;
using Application.Sales.Queries.GetSalesDetail;
using Application.Sales.Queries.GetSalesList;
using Common.Dates;
using Infrastructure.InventoryService;
using Infrastructure.Network;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Api;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        var services = builder.Services;
        ConfigureServices(services);
        ConfigureDI(services);
        
        var app = builder.Build();
        RunMigrations(app);
        ConfigureApp(app);

        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<DatabaseService>();
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllHeaders", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }
            );
        });
        services.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    private static void ConfigureDI(IServiceCollection services)
    {
        services.AddScoped<IDatabaseService, DatabaseService>();
        services.AddScoped<IDateService, DateService>();
        services.AddScoped<ISaleFactory, SaleFactory>();
        services.AddScoped<IInventoryService, InventoryService>();
        services.AddScoped<IWebClientWrapper, WebClientWrapper>();

        services.AddScoped<IGetCustomersListQuery, GetCustomersListQuery>();
        services.AddScoped<IGetEmployeesListQuery, GetEmployeesListQuery>();
        services.AddScoped<IGetProductsListQuery, GetProductsListQuery>();
        services.AddScoped<IGetSalesListQuery, GetSalesListQuery>();
        services.AddScoped<IGetSaleDetailQuery, GetSaleDetailQuery>();
        
        services.AddScoped<ICreateSaleCommand, CreateSaleCommand>();
        services.AddScoped<ICreateCustomerCommand, CreateCustomerCommand>();
        services.AddScoped<ICreateEmployeeCommand, CreateEmployeeCommand>();
        services.AddScoped<ICreateProductCommand, CreateProductCommand>();
    }

    private static void RunMigrations(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DatabaseService>();

        context.Database.Migrate();
    }

    private static void ConfigureApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}

