using BunkerWebServer.Api.Dto.Users;
using BunkerWebServer.Core.Models.Users;

namespace BunkerWebServer.Api.Mappers.Users;

public static class UsersMapper
{
    public static CreateUser ToCreateUser(this CreateUserRequest createUserRequest)
    {
        return new CreateUser
        {
            UserName = createUserRequest.Name,
            Password = createUserRequest.Password
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

    public static ValidateUser ToValidateUser(this LoginUserRequest loginUserRequest)
    {
        return new ValidateUser
        {
            Password = loginUserRequest.Password,
            UserName = loginUserRequest.UserName
        };
    }
}