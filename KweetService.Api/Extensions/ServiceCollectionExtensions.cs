using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace KweetService.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApiLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            
            services.AddControllers();
            services.AddHealthChecks();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = env == "Production" ? "https://www.kwetter.org/api/auth" : "http://localhost:5000/api/auth";
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = true,
                    };
                    options.MapInboundClaims = false;
                });
            services.AddAuthorization();
        }
    }
}