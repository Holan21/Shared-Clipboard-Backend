using Shared_Clipboard_Backend.Data;

namespace Shared_Clipboard_Backend.Extensions.ConfigApplication
{
    public static class DatabaseConfigurationExtensions
    {
        public static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<SharedClipboardMySQLDbContex>();
            return builder;
        }

    }
}
