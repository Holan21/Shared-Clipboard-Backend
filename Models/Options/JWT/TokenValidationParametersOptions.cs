namespace Shared_Clipboard_Backend.Models.Options.JWT
{
    public class TokenValidationParametersOptions
    {
        public bool ValidateIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }
        public bool LogValidationExceptions { get; set; }

    }
}
