using Shared_Clipboard_Backend.Models.Entity;

namespace Shared_Clipboard_Backend.Services.JwtProvider
{
    public interface IJwtProvider
    {
        public Task<string> Generate(User user);
    }
}
