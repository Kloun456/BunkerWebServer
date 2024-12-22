using System.Text;
using BunkerWebServer.Core.Models.Users;
using BunkerWebServer.Infrastructure.Contexts;
using BunkerWebServer.Infrastructure.Data.Entities.Users;
using BunkerWebServer.Infrastructure.Data.Mappers.Users;
using Microsoft.EntityFrameworkCore;

namespace BunkerWebServer.Infrastructure.Data.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User?> GetUser(string userName);
        Task<User> CreateUser(CreateUser userName);
        Task<IEnumerable<User>> GetUsers();
        Task<bool> UserExists(string userName);
        Task<bool> UserIsValid(ValidateUser validateUser);
    }

    public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
    {
        private const string ErrorNotCreateUser = "Не удалось создать пользователя";

        public async Task<User> CreateUser(CreateUser createUser)
        {
            var user = await dbContext.Users.AddAsync(new UserData
            {
                Id = Guid.NewGuid(),
                Name = createUser.UserName,
                Password = Encoding.UTF8.GetBytes(createUser.Password) 
            });
            await dbContext.SaveChangesAsync();
            
            return await GetUser(user.Entity.Name) ?? throw new NullReferenceException(ErrorNotCreateUser);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var usersData = await dbContext.Users.ToListAsync();
            return usersData.Select(userData => userData.MapToUser());
        }

        public async Task<bool> UserExists(string userName)
        {
            var userData = await (from user in dbContext.Users
                where user.Name == userName
                select user).FirstOrDefaultAsync();
            return userData != null;
        }

        public async Task<bool> UserIsValid(ValidateUser validateUser)
        {
            var userData = await (from user in dbContext.Users
                where user.Name == validateUser.UserName
                select user).FirstOrDefaultAsync();

            return userData!= null;
        }

        public async Task<User?> GetUser(string userName)
        {
            var userData = await (from user in dbContext.Users
                where user.Name == userName
                select user).FirstOrDefaultAsync();

            return userData?.MapToUser() ?? null;
        }
    }
}
