using BunkerWebServer.Core.Models.Users;
using BunkerWebServer.Infrastructure.Data.Repositories.Users;

namespace BunkerWebServer.Core.Services.Users
{
    public interface IUserService
    {
        Task<User> CreateUser(CreateUser createUser);
        Task<User?> GetUser(Guid userId);
        Task<IEnumerable<User>> GetUsers();
    }

    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<User> CreateUser(CreateUser createUser)
        {
            return await userRepository.CreateUser(createUser);
        }

        public async Task<User?> GetUser(Guid userId)
        {
            return await userRepository.GetUser(userId);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await userRepository.GetUsers();
        }
    }
}
