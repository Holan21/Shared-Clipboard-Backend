namespace Shared_Clipboard_Backend.Services.PasswordHasher
{
    public interface IPasswordHasherSerivce
    {
        string Generate(string password);
        bool Verify(string password,string hashedPassword);
    }
}
