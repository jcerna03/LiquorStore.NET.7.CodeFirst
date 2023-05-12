using LiquorStore.NET._7.MVC.Data;
using Microsoft.EntityFrameworkCore;

namespace LiquorStore.NET._7.MVC;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        //Add EF service
        builder.Services.AddDbContext<LiquorStoreContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(LiquorStoreContext))));

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        WebApplication app = builder.Build();


        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}