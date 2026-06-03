using Microsoft.EntityFrameworkCore;
using Shared_Clipboard_Backend.Data;

namespace Shared_Clipboard_Backend.Extensions.ConfigApplication
{
    public static class DatabaseConfiguration
    {
        public static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<MySQLDbContext>();
            return builder;
        }

    }
}
