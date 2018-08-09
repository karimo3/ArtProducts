using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ArtProducts.Services;
using ArtProducts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Newtonsoft.Json;
using ArtProducts.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ArtProducts
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration config, IHostingEnvironment env)
        {
            _config = config;
            _env = env;
        }

        //public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //configuration for the Identity
            services.AddIdentity<StoreUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;

            })
              .AddEntityFrameworkStores<DutchContext>();
            
            
            //Authentication...Look at code added in AccountController.CreateToken method
            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = _config["Tokens:Issuer"],
                        ValidAudience = _config["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]))
                    };
                });

            services.AddMvc(opt =>
            {
                if (_env.IsProduction())
                {
                    opt.Filters.Add(new RequireHttpsAttribute()); //the whole site will require HTTPS only in production
                }                                                 //this is how to enable HTTPS
            })
                .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            // this is called Dependency Injection. It is neccessary for the project to run properly


            services.AddTransient<IMailService, NullMailService>();
            //Eventually will need Support for real mail service 

            services.AddTransient<DutchSeeder>(); //AddTransient are created as needed

            services.AddScoped<IDutchRepository, DutchRepository>(); //scoped bc we want the repository to be shared within one scope...interface first; add IDutchRepository as a service, and DutchRepository as the implementation

            services.AddDbContext<DutchContext>( cfg =>
                {
                    cfg.UseSqlServer(_config.GetConnectionString("DutchConnectionString")); //connection string defined in config.json
                }
            ); //database context

            services.AddAutoMapper();
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

            //app.UseSession(); //this adds session state to the application
            //app.UseDefaultFiles(); get rid of this... 
            //app.UseFileServer(); 
            app.UseStaticFiles(); //only serves files in wwwroot directory

            app.UseAuthentication(); //assumption is to use Cookie based authentication 

            app.UseMvc( routes =>
            {
                routes.MapRoute(
                  name: "Default", 
                  template: "{controller=App}/{action=Index}/{id?}"
                   // new { controller = "App", action = "Index", id = "" } //this can be used if not specified in "template"
                );
            });

            if (env.IsDevelopment())
            {
                //seed the Database
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<DutchSeeder>();
                    //seeder.Seed().Wait(); //Wait makes it Synchronous...it only happens once when the App starts up, so its okay to wait for it
                }
            }
                                  
        }
    }
}
