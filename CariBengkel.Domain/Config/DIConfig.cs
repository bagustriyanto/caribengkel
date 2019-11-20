using CariBengkel.Domain.Cores;
using CariBengkel.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CariBengkel.Domain.Config {
    public class DIConfig {
        public void Initialize (IServiceCollection services) {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor> ();
            services.AddScoped<IAuthServices, AuthServices> ();
            services.AddScoped<IUserServices, UserServices> ();
            services.AddScoped<IRoleServices, RoleServices> ();
            services.AddScoped<IMenuServices, MenuServices> ();
        }
    }
}