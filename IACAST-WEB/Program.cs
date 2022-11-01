using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IACAST_WEB.Data;
using IACAST_WEB.Models;
using Microsoft.AspNetCore.Identity;
namespace IACAST_WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<IACAST_WEBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("IACAST_WEBContext") ?? throw new InvalidOperationException("Connection string 'IACAST_WEBContext' not found.")));

                        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<IACAST_WEBContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                SeedData.Initialize(services);
            }

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
                        app.UseAuthentication();;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();



            app.Run();
        }
    }
}