using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using iaweb.Data;
using iaweb.Areas.Identity.Data;

namespace iaweb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("iawebContextConnection") ?? throw new InvalidOperationException("Connection string 'iawebContextConnection' not found.");

                                    builder.Services.AddDbContext<iawebContext>(options =>
                options.UseSqlite(connectionString));

                                                builder.Services.AddDefaultIdentity<iawebUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<iawebContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

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

            app.Run();
        }
    }
}