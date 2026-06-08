using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared_Clipboard_Backend.Models.Options.JWT;
using System.Text;

namespace Shared_Clipboard_Backend.Extensions.ConfigApplication
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddApiVersions(this IServiceCollection services)
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

        public static IServiceCollection AddAuthFromHeader(this IServiceCollection services,JwtOptions config)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
               {
                   options.TokenValidationParameters = new()
                   {
                       ValidateIssuer = config.TokenValidationParametersOptions.ValidateIssuer,
                       ValidateAudience = config.TokenValidationParametersOptions.ValidateAudience,
                       ValidateLifetime = config.TokenValidationParametersOptions.ValidateLifetime,
                       ValidateIssuerSigningKey = config.TokenValidationParametersOptions.ValidateIssuerSigningKey,
                       LogValidationExceptions = config.TokenValidationParametersOptions.LogValidationExceptions,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.SecretKey)),
                   };
               });

            return services;

        }

        public static IServiceCollection AddAuthFromCookies(this IServiceCollection services, JwtOptions config)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
               {
                   options.TokenValidationParameters = new()
                   {
                       ValidateIssuer = config.TokenValidationParametersOptions.ValidateIssuer,
                       ValidateAudience = config.TokenValidationParametersOptions.ValidateAudience,
                       ValidateLifetime = config.TokenValidationParametersOptions.ValidateLifetime,
                       ValidateIssuerSigningKey = config.TokenValidationParametersOptions.ValidateIssuerSigningKey,
                       LogValidationExceptions = config.TokenValidationParametersOptions.LogValidationExceptions,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.SecretKey)),
                   };

                   options.Events = new JwtBearerEvents()
                   {
                       OnMessageReceived = context =>
                       {
                           context.Token = context.Request.Cookies[config.JwtCookiesKey];

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
