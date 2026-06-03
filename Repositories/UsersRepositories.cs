using Microsoft.EntityFrameworkCore;
using Shared_Clipboard_Backend.Data;
using Shared_Clipboard_Backend.Mappers.UserMapper;
using Shared_Clipboard_Backend.Models;
using Shared_Clipboard_Backend.Services;

namespace Shared_Clipboard_Backend.Repositories
{
    public class UsersRepositories
        (MySQLDbContext dbContext, IUserMapper userMapper) 
        : IUsersRepositories
    {
        private readonly IUserMapper _userMapper = userMapper;
        private readonly MySQLDbContext _dbContext = dbContext;

        public async Task<User> GetByEmail(string email)
        {
            var result = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Email == email) ?? throw new Exception();

            return 
                await _userMapper.ToDtoAsync(result);
        }

    }
}
