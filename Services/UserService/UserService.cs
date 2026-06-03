using Microsoft.EntityFrameworkCore;
using Shared_Clipboard_Backend.Data;
using Shared_Clipboard_Backend.Models;
using Shared_Clipboard_Backend.Models.Contracts;
using Shared_Clipboard_Backend.Models.Entity;
using Shared_Clipboard_Backend.Services.PasswordHasher;
using System.IdentityModel.Tokens.Jwt;

namespace Shared_Clipboard_Backend.Services.UserService
{
    public class UserService(IUsersRepositories usersRepositories, IPasswordHasherSerivce passwordHasherSerivce) : IUserService
    {
        private readonly IUsersRepositories _usersRepositories = usersRepositories;
        private readonly IPasswordHasherSerivce _passwordHasherService = passwordHasherSerivce;
        public async Task<string> Login(string email, string password)
        {
            throw new NotImplementedException();
        }
        public async Task Register(UserResponse userReponse)
        {
            var hashed_password = _passwordHasherService.Generate(userReponse.Password);

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Password = hashed_password,
                Username = userReponse.Username,
                CreatedAt = DateTime.UtcNow,
                Email = userReponse.Email,
                Devices = new List<Device>() { 
                    new Device() 
                    { 
                        Id = Guid.NewGuid(),
                        Name = "Test",
                        OSName = "Windows"
                    }  
                },
                Clipboard = new List<ClipboardItem>()
                {
                  new ClipboardItem()
                  {
                      Id = Guid.NewGuid(),
                      Data = "testClipboard"
                  }
                }
            };
            Console.WriteLine(user);
            await _usersRepositories.AddUser(user);
            
        }
    }
}
