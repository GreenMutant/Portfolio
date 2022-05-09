using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace Portfolio
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddDbContext<ApplicationDbContext>(Options =>
            Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{Action=Index}/{id?}"

                    );

                endpoints.MapControllerRoute(
                   name: "fevercheck",
                   pattern: "FeverCheck",

                   defaults: new { controller = "FeverCheck", action = "GetInfo" }
                   );

                endpoints.MapControllerRoute(
                   name: "guessinggame",
                   pattern: "GuessingGame",

                   defaults: new { controller = "GuessingGame", action = "SetSession" }
                   );
                endpoints.MapControllerRoute(
                   name: "people",
                   pattern: "People",

                   defaults: new { controller = "People", action = "Index" }
                   );
                endpoints.MapControllerRoute(
                  name: "peopledb",
                  pattern: "PeopleDB",

                  defaults: new { controller = "PeopleDB", action = "Index" }
                  );
                endpoints.MapControllerRoute(
                 name: "citydb",
                 pattern: "CityDB",

                 defaults: new { controller = "CityDB", action = "Index" }
                 );
            });

            

           
        }
    }
}
