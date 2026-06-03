using Shared_Clipboard_Backend.Models.Contracts;

namespace Shared_Clipboard_Backend.Services.UserService
{
    public interface IUserService
    {
        public Task<string> Login(string email, string password); 
        public Task Register(UserResponse user);
    }
}
