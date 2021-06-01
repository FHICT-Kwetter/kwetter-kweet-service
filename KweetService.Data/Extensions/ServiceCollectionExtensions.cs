using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KweetService.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}