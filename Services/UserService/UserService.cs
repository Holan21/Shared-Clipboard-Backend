using Microsoft.EntityFrameworkCore;
using Shared_Clipboard_Backend.Data;
using Shared_Clipboard_Backend.Models;
using Shared_Clipboard_Backend.Services.PasswordHasher;
using System.IdentityModel.Tokens.Jwt;

namespace Shared_Clipboard_Backend.Services.UserService
{
    public class UserService(MySQLDbContext dbContext, IPasswordHasherSerivce passwordHasherSerivce) : IUserService
    {
        private readonly MySQLDbContext _dbContext = dbContext;
        private readonly IPasswordHasherSerivce _passwordHasherService;
        public async Task<string> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
