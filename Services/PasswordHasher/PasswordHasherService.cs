using System.Security.Cryptography;

namespace Shared_Clipboard_Backend.Services.PasswordHasher
{
    public class PasswordHasherService : IPasswordHasherSerivce
    {
        public string Generate(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    }
}
