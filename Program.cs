using Shared_Clipboard_Backend.Extensions.ConfigApplication;
using Shared_Clipboard_Backend.Models.Options.JWT;

namespace Shared_Clipboard_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>() 
                ?? throw new Exception("Failed to load JWT Configuration");


            builder.AddOptions();

            builder.Services
                .AddDatabase()
                .AddMappers()
                .AddRepositories()
                .AddServices()
                .AddApiVersions()
                .AddAuth(jwtOptions)
                .AddSwagger()
                .AddControllers();

            var app = builder.Build();

            if (app.Environment.IsDevelopment()) 
                app.ShowSwagger();

            app.ConfigureApllication()
                .UseAuth();

            app.Run();
        }
    }
}
