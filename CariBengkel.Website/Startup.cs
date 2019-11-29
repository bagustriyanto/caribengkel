using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CariBengkel.Domain.Config;
using CariBengkel.Repository.Entity.Custom;
using CariBengkel.Repository.Entity.Model;
using CariBengkel.Website.Config;
using CariBengkel.Website.Models;
using FluentValidation.AspNetCore;
using LocalizationCultureCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Threenine.Data.DependencyInjection;

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
            services.Configure<TokenSetting> (Configuration.GetSection ("TokenManagement"));
            var token = Configuration.GetSection ("TokenManagement").Get<TokenSetting> ();

            services.AddHttpContextAccessor ();

            // dependency injection service
            var dIConfig = new DIConfig ();
            dIConfig.Initialize (services);

            // db context
            services.AddDbContext<AppDbContext> (opt => opt.UseNpgsql (Configuration.GetConnectionString ("DefaultConnection")))
                .AddUnitOfWork<AppDbContext> ();

            // depedency injection auto mapper
            services.AddAutoMapper (typeof (MapperProfile));

            // jwt auth
            services.AddAuthentication (JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer (opt => {
                    opt.RequireHttpsMetadata = false;
                    opt.SaveToken = true;
                    opt.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey (Encoding.ASCII.GetBytes (token.Secret)),
                        ValidIssuer = token.Issuer,
                        ValidAudience = token.Audience,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddAuthentication (CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie (opt => {
                    opt.AccessDeniedPath = "/error";
                    opt.LoginPath = "/login";
                    opt.LogoutPath = "/logout";
                    opt.SlidingExpiration = false;
                    opt.ExpireTimeSpan = TimeSpan.FromMinutes (30);
                });

            // localization
            services.AddJsonLocalization (opt => opt.ResourcesPath = "Resources");
            services.AddMvc ()
                .AddJsonOptions (opt => {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver ();
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                })
                .AddFluentValidation (
                    config => new InitializeValidator ().Setup (config)
                )
                .AddViewLocalization (opt => opt.ResourcesPath = "Resources")
                .SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

            CultureInfo.CurrentCulture = new CultureInfo ("id-ID", false);
            CultureInfo.CurrentUICulture = new CultureInfo ("id-ID", false);
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

            app.UseCors (opt => opt.AllowAnyHeader ().AllowAnyMethod ().AllowAnyOrigin ());
            app.UseHttpsRedirection ();
            app.UseStaticFiles ();
            app.UseCookiePolicy ();
            app.UseAuthentication ();

            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute (
                    name: "api",
                    template: "api/{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute (
                    name: "backoffice",
                    template: "system/{controller=Backoffice}/{action=Index}/{id?}"
                );
            });
        }
    }
}