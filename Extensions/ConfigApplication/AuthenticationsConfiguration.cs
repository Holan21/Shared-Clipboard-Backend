using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared_Clipboard_Backend.Models.Options;
using System.Text;

namespace Shared_Clipboard_Backend.Extensions.ConfigApplication
{
    public static class AuthenticationsConfiguration
    {
        public static WebApplicationBuilder AddApiAuthentication(this WebApplicationBuilder builder, IOptions<JwtOptions> config)
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Value.SecretKey)),
                         
                        
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


            builder.Services.AddAuthorization();
            return builder;
        }

    }
}
