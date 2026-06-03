using Shared_Clipboard_Backend.Extensions.ConfigApplication;

namespace Shared_Clipboard_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.AddApiVersions()
                .AddDatabase()
                .AddSwagger()
                .AddServices()
                .AddRepositories()
                .AddMappers()
                .AddControllers()
                .Build();

            if (app.Environment.IsDevelopment()) 
                app.ShowSwagger();

            app.UseHttpsRedirection()
               .UseAuthorization()
               .UseAuthentication();

            app.MapControllers();
            app.Run();

        }
    }
}
