using Application.Configuration;
using Common.Configuration;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;
using Persistence.Database;

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
        services.AddPersistence();
        services.AddApplication();
        services.AddInfrastructure();
        services.AddCommon();
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