using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Shared_Clipboard_Backend.Models.Options;
using System.Text;

namespace Shared_Clipboard_Backend.Extensions.ConfigApplication
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddApiVersions(this IServiceCollection services, JwtOptions config)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services, JwtOptions config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
               {
                   options.TokenValidationParameters = new()
                   {
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.SecretKey)),
                   };

                   options.Events = new JwtBearerEvents()
                   {
                       OnMessageReceived = context =>
                       {
                           context.Token = context.Request.Cookies["jwtkey"];

                           return Task.CompletedTask;
                       }
                   };
               });

            return services;

        }

        public static WebApplication UseAuth(this WebApplication application)
        {
            application.UseAuthentication()
                .UseAuthorization();

            return application;
        }
    }
}
