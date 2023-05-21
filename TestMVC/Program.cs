using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestMVC.Data;
using TestMVC.Models;

namespace TestMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<TestMVCContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("TestMVCContext") ?? throw new InvalidOperationException("Connection string 'TestMVCContext' not found.")));
             
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                SeedData.Initialize(services);
            }

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

            app.Run();
        }
    }
}