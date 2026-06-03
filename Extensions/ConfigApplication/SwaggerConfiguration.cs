namespace Shared_Clipboard_Backend.Extensions.ConfigApplication
{
    public static class SwaggerConfiguration
    {
        public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();

            return builder;
        }

        public static WebApplication ShowSwagger(this WebApplication app)
        {
            app.UseSwagger()
               .UseSwaggerUI();

            return app;
        }
    }
}
