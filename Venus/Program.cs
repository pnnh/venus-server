


using System.Net; 
using Venus.Models;
using Microsoft.EntityFrameworkCore;
using Venus.Services; 

namespace Venus
{
    public class Venus
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders().AddSimpleConsole(options =>
            {
                options.SingleLine = true;
                options.IncludeScopes = true;
                options.UseUtcTimestamp = true;
            });

            builder.Services.AddControllersWithViews();

            var config = AwsConfig.GetConfig();

            builder.Services.AddDbContext<VenusDatabaseContext>(options =>
            {
                options.UseNpgsql(config.PgDsn);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
 
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

    }
}
