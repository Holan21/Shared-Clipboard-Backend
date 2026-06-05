using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shared_Clipboard_Backend.Models.Contracts;
using Shared_Clipboard_Backend.Models.Options.JWT;
using Shared_Clipboard_Backend.Services.Parsers;
using Shared_Clipboard_Backend.Services.UserService;

namespace Shared_Clipboard_Backend.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AuthController(
        IUserService userService, 
        IUserAgentParser parser,
        IOptions<JwtOptions> config
        ) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IUserAgentParser _parser = parser;
        private readonly JwtOptions _config = config.Value;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginResponse login)
        {
            var token = await _userService.Login(login.email, login.password);

            Response.Cookies.Append(_config.JwtCookiesKey, token);
            
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterResponse user)
        {
            var userAgent = Request.Headers["User-Agent"].ToString();

            var device = await _parser.ParseAsync(userAgent);

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
