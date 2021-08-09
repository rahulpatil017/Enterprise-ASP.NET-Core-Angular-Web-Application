using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using rahulpatil.Data.Models;
using rahulpatil.ViewModels.HealthCheck;

namespace rahulpatil
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddJsonOptions(options => {
                    // set this option to TRUE to indent the JSON output
                    options.JsonSerializerOptions.WriteIndented = true;
                    // set this option to NULL to use PascalCase instead of
                    // camelCase (default)
                    // options.JsonSerializerOptions.PropertyNamingPolicy =
                    // null;
                });
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "rahulpatil/dist";
            });

            // Add ApplicationDbContext and SQL Server support
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
            Configuration.GetConnectionString("DefaultConnection")
            )
            );

            services.AddHealthChecks()
                .AddCheck("ICMP_01",
                new ICMPHealthCheck("www.staysafe100.com",
                100))
                .AddCheck("ICMP_02",
                new ICMPHealthCheck("www.google.com",
                100))
                .AddCheck("ICMP_03",
                new ICMPHealthCheck("www.does-not-exist.com",
                100));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = (context) =>
                {
                    // Retrieve cache configuration from appsettings.json
                    context.Context.Response.Headers["Cache-Control"] =
                    Configuration["StaticFiles:Headers:Cache-Control"];
                }
            });

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/hc", new CustomHealthCheckOptions());
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "rahulpatil";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
