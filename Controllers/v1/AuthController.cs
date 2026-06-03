using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared_Clipboard_Backend.Models.Contracts;
using Shared_Clipboard_Backend.Services.Parsers;
using Shared_Clipboard_Backend.Services.UserService;

namespace Shared_Clipboard_Backend.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AuthController(IUserService userService, IUserAgentParser parser) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IUserAgentParser _parser = parser;

        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserResponse user)
        {
            var device =await parser.ParseAsync(HttpContext.Request.Headers["User-Agent"]);

            await _userService.Register(user,device);

            return Ok();
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }
    }
}
