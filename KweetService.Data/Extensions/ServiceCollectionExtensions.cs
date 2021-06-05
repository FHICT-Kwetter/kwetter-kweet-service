using System;
using KweetService.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KweetService.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("GOOGLE_CLOUD_SQL");
            
            services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IDataContext, DataContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}