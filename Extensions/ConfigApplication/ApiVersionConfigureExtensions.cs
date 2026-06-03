using Asp.Versioning;

namespace Shared_Clipboard_Backend.Extensions.ConfigApplication
{
    public static class ApiVersionConfigureExtensions
    {
        public static WebApplicationBuilder AddApiVersions(this WebApplicationBuilder builder)
        {
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });

            return builder;
        }

    }
}
