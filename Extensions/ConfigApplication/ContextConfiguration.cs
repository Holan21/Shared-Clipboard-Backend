using Shared_Clipboard_Backend.Mapper;
using Shared_Clipboard_Backend.Repositories;
using Shared_Clipboard_Backend.Services;
using Shared_Clipboard_Backend.Services.JwtProvider;
using Shared_Clipboard_Backend.Services.Parsers;
using Shared_Clipboard_Backend.Services.PasswordHasher;
using Shared_Clipboard_Backend.Services.UserAgen;
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
            services.AddSingleton<IPasswordHasherSerivce, PasswordHasherService>();
            services.AddSingleton<IJwtProvider, JwtProvider>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserAgentParser, UserAgentParser>();

            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddScoped<IDeviceMapper, DeviceMapper>();

            return services;
        }
    }
}
