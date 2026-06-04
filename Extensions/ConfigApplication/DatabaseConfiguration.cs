using Shared_Clipboard_Backend.Data;

namespace Shared_Clipboard_Backend.Extensions.ConfigApplication
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<MySQLDbContext>();

            return services;
        }

    }
}
