using System.IdentityModel.Tokens.Jwt;

namespace Shared_Clipboard_Backend.Services.JwtProvider
{
    public class JwtProvider
    {
        public async Task<string> Generate()
        {
            JwtSecurityToken jwt = new JwtSecurityToken() {  };

            return string.Empty;
        }
    }
}
