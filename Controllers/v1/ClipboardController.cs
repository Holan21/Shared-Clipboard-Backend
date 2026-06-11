using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared_Clipboard_Backend.Models.Contracts;
using Shared_Clipboard_Backend.Repositories;
using Shared_Clipboard_Backend.Services;
using System.Security.Claims;

namespace Shared_Clipboard_Backend.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class ClipboardController(ICLipboardRepositories cLipboardRepositories) : ControllerBase
    {
        [HttpGet("clipboardAll")]
        public async Task<IActionResult> ClipboardAll()
        {
            bool v = Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId);
            if (!v) throw new Exception();

            var result = await cLipboardRepositories.GetByIdAsync(userId);

            return Ok(result);
        }
    }
}
