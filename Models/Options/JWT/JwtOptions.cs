namespace Shared_Clipboard_Backend.Models.Options.JWT
{
    public sealed class JwtOptions
    {
        public string SecretKey { get; set; } = string.Empty;
        public int ExpiresHours { get; set; }
        public string JwtCookiesKey { get; set; } = string.Empty;
        public TokenValidationParametersOptions TokenValidationParametersOptions { get; set; }
    }
}
