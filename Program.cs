using Microsoft.Extensions.Options;
using Shared_Clipboard_Backend.Extensions.ConfigApplication;
using Shared_Clipboard_Backend.Models.Options;

namespace Shared_Clipboard_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddApiVersions()
                .AddDatabase()
                .AddSwagger()
                .AddServices()
                .AddRepositories()
                .AddOptions()
                .AddMappers()
                .AddControllers();

            using (var sp = builder.Services.BuildServiceProvider())
            {
                var jwtOptions = sp.GetRequiredService<IOptions<JwtOptions>>();
                builder.AddApiAuthentication(jwtOptions);
            }
            var app = builder.Build();

            if (app.Environment.IsDevelopment()) 
                app.ShowSwagger();

            app.UseHttpsRedirection()
               .UseAuthentication()
               .UseAuthorization();

            app.MapControllers();
            app.Run();

        }
    }
}
