
using Microsoft.EntityFrameworkCore;
using PlantCareMini.Data;
using PlantCareMini.Data.Data;

namespace PlantCareMini.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Database connection
            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(
                    @"Server=localhost,1433;Database=PlantCareMiniDb;User Id=sa;Password=144g144gG@;TrustServerCertificate=True;"));

            //Add-Migration init -Project PlantCareMini.Data -StartupProject PlantCareMini.Web
            //Update-Database -Project PlantCareMini.Data -StartupProject PlantCareMini.Web



            var app = builder.Build();



          
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
