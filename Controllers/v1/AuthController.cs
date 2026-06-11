using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shared_Clipboard_Backend.Models.Contracts;
using Shared_Clipboard_Backend.Models.Options.JWT;
using Shared_Clipboard_Backend.Services.UserService;

namespace Shared_Clipboard_Backend.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AuthController(
        IUserService userService, 
        IOptions<JwtOptions> config
        ) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly JwtOptions _config = config.Value;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginResponse login)
        {
            var token = await _userService.Login(login.email, login.password);

            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterResponse user)
        {

            await _userService.Register(user);

            return Ok();
        }
    }
}
