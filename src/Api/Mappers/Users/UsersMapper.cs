using BunkerWebServer.Api.Dto.Users;
using BunkerWebServer.Core.Models.Users;

namespace BunkerWebServer.Api.Mappers.Users;

public static class UsersMapper
{
    public static CreateUser ToCreateUser(this CreateUserRequest createUserRequest)
    {
        return new CreateUser
        {
            UserName = createUserRequest.Name
        };
    }

    public static UserResponse ToUserResponse(this User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            Name = user.Name
        };
    }
    
}