using Shared_Clipboard_Backend.Mapper;
using Shared_Clipboard_Backend.Repositories;
using Shared_Clipboard_Backend.Services;
using Shared_Clipboard_Backend.Services.Parsers;
using Shared_Clipboard_Backend.Services.PasswordHasher;
using Shared_Clipboard_Backend.Services.UserAgen;
using Shared_Clipboard_Backend.Services.UserService;

namespace Shared_Clipboard_Backend.Extensions.ConfigApplication
{
    public static class ContextConfiguration
    {
        public static WebApplicationBuilder AddControllers(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            return builder;
        }

        public static WebApplicationBuilder AddRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUsersRepositories, UsersRepositories>();
            
            return builder;
        }

        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IPasswordHasherSerivce, PasswordHasherService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserAgentParser, UserAgentParser>();

            return builder;
        }

        public static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IDeviceMapper, DeviceMapper>();

            return builder;
        }
    }
}
