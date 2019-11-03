using CariBengkel.Domain.Cores;
using CariBengkel.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CariBengkel.Domain.Config {
    public class DIConfig {
        public void Initialize (IServiceCollection services) {
            services.AddScoped<IAuthServices, AuthServices> ();
        }
    }
}