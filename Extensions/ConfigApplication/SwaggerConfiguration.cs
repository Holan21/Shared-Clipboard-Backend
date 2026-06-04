namespace Shared_Clipboard_Backend.Extensions.ConfigApplication
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwagger(this IServiceCollection service)
        {
            service.AddSwaggerGen();

            return service;
        }

        public static WebApplication ShowSwagger(this WebApplication app)
        {
            app.UseSwagger()
               .UseSwaggerUI();

            return app;
        }
    }
}
