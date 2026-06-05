using Shared_Clipboard_Backend.Models;
using Shared_Clipboard_Backend.Models.Contracts;
using Shared_Clipboard_Backend.Models.Entity;

namespace Shared_Clipboard_Backend.Services
{
    public interface IUsersRepositories
    {
        public Task AddUser(User user);
        public Task<User> GetByEmailAsync(string email);
    }
}
