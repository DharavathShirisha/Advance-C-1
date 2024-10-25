using Microsoft.AspNetCore.Authentication.Cookies;

namespace MYmvc_Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // type of authentication is need to use is :cookie based authentication.
            //the path of the login screen.
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                c => { c.LoginPath = "/Hello/Login"; });


            var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Hello/MyPage");
            //}
           // app.UseStatusCodePagesWithRedirects("/Hello/NotFound");
          //app.UseStatusCodePagesWithReExecute("/Hello/NotFound");
            //app.UseStatusCodePages();
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
