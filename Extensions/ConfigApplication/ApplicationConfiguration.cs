using System.Runtime.CompilerServices;

namespace Shared_Clipboard_Backend.Extensions.ConfigApplication
{
    public static class ApplicationConfiguration
    {

        public static WebApplication ConfigureApllication(this WebApplication applicaiton)
        {
            applicaiton.UseHttpsRedirection();
            applicaiton.MapControllers();

            return applicaiton;
        }
    }
}
