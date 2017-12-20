using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Services;
using MyProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyProject
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); // this is called Dependency Injection. It is neccessary for the project to run properly


            services.AddTransient<IMailService, NullMailService>();
            //Eventually will need Support for real mail service 

            services.AddTransient<DutchSeeder>(); //AddTransient are created as needed

            services.AddScoped<IDutchRepository, DutchRepository>(); //scoped bc we want the repository to be shared within one scope...interface first; add IDutchRepository as a service, and DutchRepository as the implementation

            services.AddDbContext<DutchContext>( cfg =>
                {
                    cfg.UseSqlServer(_config.GetConnectionString("DutchConnectionString")); //connection string defined in config.json
                }
            ); //database context


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) //there is IsDevelopment, IsStaging, IsProduction
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            //app.UseDefaultFiles(); get rid of this
            app.UseStaticFiles(); //only serves files in wwwroot directory
            app.UseMvc( routes =>
            {
                routes.MapRoute(
                   "Default", 
                    "{controller}/{action}/{id}",
                    new { controller = "App", action = "Index", id = "" }
                );
            });

            if (env.IsDevelopment())
            {
                //seed the Database
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<DutchSeeder>();
                    seeder.Seed();
                }
            }
                                  
        }
    }
}
