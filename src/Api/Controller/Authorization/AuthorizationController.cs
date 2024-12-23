using BunkerWebServer.Api.Dto.Users;
using BunkerWebServer.Api.Mappers.Users;
using BunkerWebServer.Core.Services.Authorization;
using BunkerWebServer.Core.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace BunkerWebServer.Api.Controller.Authorization;


[Route("api/authorization")]
[ApiController]
public class AuthoriaztionController(IUserService userService, IAuthorizationService authorizationService) 
    : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<string?>> Login(LoginUserRequest loginUserRequest)
    {
        if (!await userService.UserIsValid(loginUserRequest.ToValidateUser()))
        {
            return Unauthorized();
        }
        
        var token = authorizationService.GenerateJwtToken(loginUserRequest.UserName);
        return Ok(new
        {
            Token = token
        });
    }
   
}