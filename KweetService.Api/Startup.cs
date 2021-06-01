using KweetService.Api.Extensions;
using KweetService.Data.Extensions;
using KweetService.Service.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KweetService.Api
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiLayer(configuration);
            services.AddServiceLayer(configuration);
            services.AddDataLayer(configuration);
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(x => x.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());
            }
            
            app.UsePathBase(new PathString("/api/kweets"));
            app.UseHealthChecks("/api/kweets/health");
            app.UseHealthChecks("/health");
            app.UseRouting();
            app.UseCors(x => x.WithOrigins("https://kwetter.org", "https://www.kwetter.org").AllowAnyHeader().AllowAnyMethod());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}