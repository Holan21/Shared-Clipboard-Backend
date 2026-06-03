using Shared_Clipboard_Backend.Services.PasswordHasher;
namespace Shared_Clipboard_Backend.Extensions.ConfigApplication
{
    public static class ServiceConfigureExtensions
    {

        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IPasswordHasherSerivce, PasswordHasherService>();

            return builder;
        }
    }
}
