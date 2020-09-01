using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookWatch
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
           // services.AddControllersWithViews();
            services.AddControllersWithViews();
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
                //Show Error Page
                app.UseExceptionHandler("/error");
            }
            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseNodeModules();
            
            app.UseRouting();
            app.UseEndpoints(cfg=> 
            {
                cfg.MapControllerRoute("Default",
              "{controller}/{action}/{id?}",
              new { controller = "App", Action = "Index" });
            });

            //What was in the video
            //app.UseMvc(cfg =>
            //{
            //    cfg.MapRoute("Default",
            //  "{controller}/{action}/{id?}",
            //  new { controller = "App", Action = "Index" });
            //});
        }
    }
}
