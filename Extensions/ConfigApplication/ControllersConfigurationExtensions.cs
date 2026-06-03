namespace Shared_Clipboard_Backend.Extensions.ConfigApplication
{
    public static class ControllersConfigurationExtensions
    {
        public static WebApplicationBuilder AddControllers(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            return builder;
        }
    }
}
