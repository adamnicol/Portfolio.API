using FluentValidation;
using System.Reflection;

namespace Portfolio.API.Services.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddServiceLayerConfiguration(config);

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
