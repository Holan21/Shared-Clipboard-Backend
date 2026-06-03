using Shared_Clipboard_Backend.Models;
using Shared_Clipboard_Backend.Models.Dto;

namespace Shared_Clipboard_Backend.Mappers.UserMapper
{
    public interface IUserMapper
    {
        public Task<User> ToDtoAsync(UserEntity user);
    }
}
