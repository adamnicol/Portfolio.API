using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.API.Data.Configuration;
using Portfolio.API.Services.Contracts;
using Portfolio.API.Services.Maps;

namespace Portfolio.API.Services.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceLayerConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddDataLayerConfiguration(config);
            services.AddAutoMapper(typeof(UserMap));

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
