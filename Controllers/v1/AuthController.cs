using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Shared_Clipboard_Backend.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }
    }
}
