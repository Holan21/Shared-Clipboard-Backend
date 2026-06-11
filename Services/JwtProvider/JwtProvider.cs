using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared_Clipboard_Backend.Models.Entity;
using Shared_Clipboard_Backend.Models.Options.JWT;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shared_Clipboard_Backend.Services.JwtProvider
{
    public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
    {
        private readonly JwtOptions _options = options.Value;

        public async Task<string> Generate(User user)
        {
            Claim[] claims = [
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new("userName", user.Username),
                new("email", user.Email),
                new("createdAt",user.CreatedAt.ToString())
                ];

            var signingCreadentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials:signingCreadentials,
                expires: DateTime.UtcNow.AddHours(_options.ExpiresHours)
                );

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}
