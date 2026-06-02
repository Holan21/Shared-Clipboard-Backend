using Asp.Versioning;
using Asp.Versioning.Conventions;

namespace Shared_Clipboard_Backend.Extensions
{
    public static class WebApplicationBuilderExtension
    {

        public static WebApplicationBuilder ConfigureApiVersions(this WebApplicationBuilder builder)
        { 
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            })
            .AddMvc(options =>
            {
                options.Conventions.Add(new VersionByNamespaceConvention());
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });

            return builder;
        }
        public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();

            return builder;
        }

        public static WebApplicationBuilder ConfigureControllers(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            return builder; 
        }
    }
}
