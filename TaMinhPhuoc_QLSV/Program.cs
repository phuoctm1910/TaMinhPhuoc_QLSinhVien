using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TaMinhPhuoc_QLSV.Data;

namespace TaMinhPhuoc_QLSV
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<QuanlysinhvienContext>(options =>
             options.UseMySql(builder.Configuration.GetConnectionString("strConn"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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