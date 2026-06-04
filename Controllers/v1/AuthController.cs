using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared_Clipboard_Backend.Models.Contracts;
using Shared_Clipboard_Backend.Services.Parsers;
using Shared_Clipboard_Backend.Services.UserService;

namespace Shared_Clipboard_Backend.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AuthController(
        IUserService userService, 
        IUserAgentParser parser
        ) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IUserAgentParser _parser = parser;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginResponse login)
        {
            var token = await _userService.Login(login.email, login.password);

            Response.Cookies.Append("jwtkey", token);
            
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterResponse user)
        {
            var device = await _parser.ParseAsync(Request.Headers["User-Agent"]);

            await _userService.Register(user,device);

            return Ok();
        }

        [HttpGet("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }
    }
}
