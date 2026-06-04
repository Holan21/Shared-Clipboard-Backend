using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared_Clipboard_Backend.Models.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Shared_Clipboard_Backend.Services.JwtProvider
{
    public class JwtProvider
    {
        private readonly JwtOptions _options;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }
        public async Task<string> Generate()
        {
            var signingCreadentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                signingCredentials:signingCreadentials,
                expires: DateTime.UtcNow.AddHours(_options.ExpiresHours)
                );

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}
