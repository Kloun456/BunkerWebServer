using System.Text;
using BunkerWebServer.Core.Models.Users;
using BunkerWebServer.Infrastructure.Data.Entities.Users;

namespace BunkerWebServer.Infrastructure.Data.Mappers.Users
{
    public static class UserMapper
    {
        public static User MapToUser(this UserData userData)
        {
            return new User
            { 
                Id = userData.Id, 
                Name = userData.Name,
                HashPassword = Encoding.UTF8.GetString(userData.Password)
            };
        }
    }
}
