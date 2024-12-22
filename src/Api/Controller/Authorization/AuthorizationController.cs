using BunkerWebServer.Api.Dto.Users;
using BunkerWebServer.Api.Mappers.Users;
using BunkerWebServer.Core.Models.Sessions;
using BunkerWebServer.Core.Services.Sessions;
using BunkerWebServer.Core.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace BunkerWebServer.Api.Controller.Authorization;


[Route("api/authorization")]
[ApiController]
public class AuthoriaztionController(IUserService userService, ISessionService sessionService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<string?> Login(LoginUserRequest loginUserRequest)
    {
        if (!await userService.UserIsValid(loginUserRequest.ToValidateUser()))
        {
            throw new Exception("Invalid username or password");
        }

        return await sessionService.CreateSession(new CreateSession
        {
            UserName = loginUserRequest.UserName,
            Password = loginUserRequest.Password
        });
    }
}