using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication06.Conntexts;
using WebApplication06.Extensions;
using WebApplication06.Models;

namespace WebApplication06
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<Edukate01DbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("LSS01"));
            });

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = false;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz0123456789";
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 4;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<Edukate01DbContext>();

            //builder.Services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = new PathString("/Auth/Login");
            //    options.LogoutPath = new PathString("/Auth/Logout");
            //    options.AccessDeniedPath = new PathString("/Home/AccessDenied");

            //    options.Cookie = new()
            //    {
            //        Name = "IdentityCookie",
            //        HttpOnly = true,
            //        SameSite = SameSiteMode.Lax,
            //        SecurePolicy = CookieSecurePolicy.Always
            //    };
            //    options.SlidingExpiration = true;
            //    options.ExpireTimeSpan = TimeSpan.FromDays(30);
            //});

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.Cookie.Name = "YourAppCookieName";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Identity/Account/Login";
                // ReturnUrlParameter requires 
                //using Microsoft.AspNetCore.Authentication.Cookies;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });


            var app = builder.Build();
            FileExtensions.RootPath = app.Environment.WebRootPath;

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}