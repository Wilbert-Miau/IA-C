<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Web_MVC_IA_CAST.Data;
using Web_MVC_IA_CAST.Models;
=======
>>>>>>> f9c72cac54baba9455812492975daf89d92c5309
namespace Web_MVC_IA_CAST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
<<<<<<< HEAD
            builder.Services.AddDbContext<Web_MVC_IA_CASTContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Web_MVC_IA_CASTContext") ?? throw new InvalidOperationException("Connection string 'Web_MVC_IA_CASTContext' not found.")));
=======
>>>>>>> f9c72cac54baba9455812492975daf89d92c5309

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

<<<<<<< HEAD

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                SeedData.Initialize(services);
            }









=======
>>>>>>> f9c72cac54baba9455812492975daf89d92c5309
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
}