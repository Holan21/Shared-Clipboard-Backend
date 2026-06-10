using Microsoft.Extensions.Options;
using Shared_Clipboard_Backend.Models.Options.JWT;
using Shared_Clipboard_Backend.Repositories;
using Shared_Clipboard_Backend.Services;
using Shared_Clipboard_Backend.Services.JwtProvider;
using Shared_Clipboard_Backend.Services.PasswordHasher;
using Shared_Clipboard_Backend.Services.UserService;

namespace Shared_Clipboard_Backend.Extensions.ConfigApplication
{
    public static class ContextConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepositories, UsersRepositories>();
            
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasherSerivce, PasswordHasherService>();
            services.AddScoped<IJwtProvider, JwtProvider>();

            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {

            return services;
        }

        public static WebApplicationBuilder AddOptions(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;

            builder.Services.Configure<JwtOptions>(configuration.GetSection(
                nameof(JwtOptions)));

            return builder;
        }
    }
}
