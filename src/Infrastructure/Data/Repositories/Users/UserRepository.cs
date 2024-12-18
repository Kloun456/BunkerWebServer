using BunkerWebServer.Core.Models.Users;
using BunkerWebServer.Infrastructure.Contexts;
using BunkerWebServer.Infrastructure.Data.Entities.Users;
using BunkerWebServer.Infrastructure.Data.Mappers.Users;
using Microsoft.EntityFrameworkCore;

namespace BunkerWebServer.Infrastructure.Data.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User?> GetUser(Guid userId);
        Task<User> CreateUser(CreateUser userName);
        Task<IEnumerable<User>> GetUsers();
    }

    public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
    {
        private const string ErrorNotCreateUser = "Не удалось создать пользователя";

        public async Task<User> CreateUser(CreateUser createUser)
        {
            var user = await dbContext.Users.AddAsync(new UserData
            {
                Id = Guid.NewGuid(),
                Name = createUser.UserName
            });
            await dbContext.SaveChangesAsync();
            
            return await GetUser(user.Entity.Id) ?? throw new NullReferenceException(ErrorNotCreateUser);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var usersData = await dbContext.Users.ToListAsync();
            return usersData.Select(userData => userData.MapToUser());
        }

        public async Task<User?> GetUser(Guid userId)
        {
            var userData = await (from user in dbContext.Users
                            where user.Id == userId
                            select user).FirstOrDefaultAsync();

            return userData?.MapToUser() ?? null;
        }
    }
}
