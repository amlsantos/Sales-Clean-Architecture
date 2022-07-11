using Application.Customers.Commands.CreateCustomer;
using Application.Customers.Queries.GetCustomerList;
using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Queries.GetEmployeeList;
using Application.Interfaces;
using Application.Interfaces.Infrastructure;
using Application.Interfaces.Persistence;
using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetProductsList;
using Application.Sales.Commands.CreateSale;
using Application.Sales.Commands.CreateSale.Factory;
using Application.Sales.Commands.CreateSale.Repository;
using Application.Sales.Queries.GetSalesDetail;
using Application.Sales.Queries.GetSalesList;
using Common.Dates;
using Infrastructure.InventoryService;
using Infrastructure.Network;
using Microsoft.EntityFrameworkCore;
using Persistence.Customers;
using Persistence.Database;
using Persistence.Employees;
using Persistence.Products;
using Persistence.Sales;
using UI.Sales.Services;

namespace UI;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        ConfigureServices(services);
        ConfigureDi(services);

        var app = builder.Build();
        RunMigrations(app);
        ConfigureApp(app);

        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>();
        services.AddControllersWithViews()
            .AddRazorOptions(options =>
            {
                options.ViewLocationFormats.Add("~/{1}/Views/{0}.cshtml");
                options.PageViewLocationFormats.Add("~/Shared/Views/{0}.cshtml");
            });
    }

    private static void ConfigureDi(IServiceCollection services)
    {
        services.AddSingleton<IDatabaseContext, DatabaseContext>();
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<ISaleRepositoryFacade, SaleRepositoryFacade>();
        
        services.AddScoped<IDateService, DateService>();
        services.AddScoped<ISaleFactory, SaleFactory>();
        services.AddScoped<ICreateSaleViewModelFactory, CreateSaleViewModelFactory>();
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
        var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

        context.Database.Migrate();
    }

    private static void ConfigureApp(WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    }
}