using System.Runtime.CompilerServices;

namespace Shared_Clipboard_Backend.Extensions.ConfigApplication
{
    public static class ApplicationConfiguration
    {
        public static IConfiguration AddConfiguration(this WebApplicationBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            builder.Configuration.AddConfiguration(configuration);
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            return configuration;
        }

        public static WebApplication ConfigureApllication(this WebApplication applicaiton)
        {
            applicaiton.UseHttpsRedirection();
            applicaiton.MapControllers();

            return applicaiton;
        }
    }
}
