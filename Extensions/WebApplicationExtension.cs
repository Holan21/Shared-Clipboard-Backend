namespace Shared_Clipboard_Backend.Extensions
{
    public static class WebApplicationExtension
    {
        public static WebApplication ConfigureApplication(this WebApplication app)
        {
            app.UseHttpsRedirection()
                .UseAuthorization()
                .UseSwagger()
                .UseSwaggerUI();

            app.MapControllers();
            return app;
        }
    }
}
