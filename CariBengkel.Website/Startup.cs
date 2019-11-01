using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CariBengkel.Domain.Config;
using CariBengkel.Repository.Entity.Model;
using CariBengkel.Website.Config;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CariBengkel.Website {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.Configure<CookiePolicyOptions> (options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // db context
            services.AddDbContext<AppDbContext> (opt => opt.UseNpgsql (Configuration.GetConnectionString ("DefaultConnection")));

            // depedency injection service
            var serviceConfig = new DIConfig ();
            serviceConfig.Initialize (services);

            // depedency injection auto mapper
            services.AddAutoMapper (typeof (MapperProfile));

            services.AddMvc ()
                .AddFluentValidation (
                    config => new InitializeValidator ().Setup (config)
                )
                .SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

            // depedency injection fluent validation

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();
            app.UseStaticFiles ();
            app.UseCookiePolicy ();

            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute (
                    name: "api",
                    template: "api/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}