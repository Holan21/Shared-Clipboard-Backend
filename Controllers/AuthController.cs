using Microsoft.AspNetCore.Mvc;

namespace Shared_Clipboard_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Login()
        {
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Register()
        {
            return null;
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            return null;
        }
    }
}
