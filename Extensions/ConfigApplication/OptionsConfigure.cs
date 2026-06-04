using Shared_Clipboard_Backend.Models.Options;

namespace Shared_Clipboard_Backend.Extensions.ConfigApplication
{
    public static class OptionsConfigure
    {
        public static WebApplicationBuilder AddOptions(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

            return builder;
        }
    }
}
