using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.API.Data.Contracts;
using Portfolio.API.Data.Repositories;

namespace Portfolio.API.Data.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataLayerConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
