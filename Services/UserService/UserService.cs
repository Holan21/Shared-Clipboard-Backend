
using Shared_Clipboard_Backend.Mapper;
using Shared_Clipboard_Backend.Models.Contracts;
using Shared_Clipboard_Backend.Models.Entity;
using Shared_Clipboard_Backend.Services.JwtProvider;
using Shared_Clipboard_Backend.Services.PasswordHasher;

namespace Shared_Clipboard_Backend.Services.UserService
{
    public class UserService(
        IUsersRepositories usersRepositories, 
        IPasswordHasherSerivce passwordHasherSerivce,
        IJwtProvider jwtProvider
        ) : IUserService
    {
        private readonly IUsersRepositories _usersRepositories = usersRepositories;
        private readonly IPasswordHasherSerivce _passwordHasherService = passwordHasherSerivce;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<string> Login(string email, string password)
        {
            var user = await _usersRepositories.GetByEmailAsync(email);

            var result = _passwordHasherService.Verify(password, user.Password);

            if (result== false)
            {
                throw new Exception();
            }

            var token = await _jwtProvider.Generate(user);
            return token;
        }
        public async Task Register(RegisterResponse userReponse, Device device)
        {
            var hashed_password = _passwordHasherService.Generate(userReponse.Password);

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Password = hashed_password,
                Username = userReponse.Username,
                CreatedAt = DateTime.UtcNow,
                Email = userReponse.Email,
            };

            user.Devices.Add(device);

            await _usersRepositories.AddUser(user);
            
        }
    }
}
