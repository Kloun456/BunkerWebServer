using BunkerWebServer.Core.Models.Users;
using BunkerWebServer.Infrastructure.Data.Repositories.Users;
using Microsoft.AspNetCore.Identity;

namespace BunkerWebServer.Core.Services.Users
{
    public interface IUserService
    {
        Task<User> CreateUser(CreateUser createUser);
        Task<User?> GetUser(string userName);
        Task<IEnumerable<User>> GetUsers();
        Task<bool> UserExists(string userName);
        Task<bool> UserIsValid(ValidateUser validateUser);
    }

    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly PasswordHasher<object> _passwordHasher = new(); 
        
        public async Task<User> CreateUser(CreateUser createUser)
        {
            if (await UserExists(createUser.UserName))
            {
                throw new Exception("User already exists");
            }
            createUser.Password = _passwordHasher.HashPassword(createUser.UserName, createUser.Password);
            return await userRepository.CreateUser(createUser);
        }

        public async Task<User?> GetUser(string userName)
        {
            return await userRepository.GetUser(userName);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await userRepository.GetUsers();
        }

        public async Task<bool> UserExists(string userName)
        {
            return await userRepository.UserExists(userName);
        }

        public async Task<bool> UserIsValid(ValidateUser validateUser)
        {
            var user = await userRepository.GetUser(validateUser.UserName);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var result = _passwordHasher.VerifyHashedPassword(user.Name, user.HashPassword, validateUser.Password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
