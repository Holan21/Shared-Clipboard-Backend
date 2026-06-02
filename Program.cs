using Shared_Clipboard_Backend.Extensions;

namespace Shared_Clipboard_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app =builder
                .ConfigureApiVersions()
                .AddSwagger()
                .ConfigureControllers()
                .Build();

            app.ConfigureApplication();

            app.Run();
        }

        
    }
}
