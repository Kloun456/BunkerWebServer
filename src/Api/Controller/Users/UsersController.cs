﻿using BunkerWebServer.Api.Dto.Users;
using BunkerWebServer.Api.Mappers.Users;
using BunkerWebServer.Core.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace BunkerWebServer.Api.Controller.Users;

[Route("api/users")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<UserResponse>> GetUsers()
    {
        var users = await userService.GetUsers(); 
        return users.Select(user => user.ToUserResponse());
    }

    [HttpGet("{userId:guid}")]
    public async Task<UserResponse?> GetUser(Guid userId)
    {
        var user = await userService.GetUser(userId);
        return user?.ToUserResponse();
    }

    [HttpPost]
    public async Task<UserResponse> CreateUser(CreateUserRequest createUserRequest)
    {
        var user = await userService.CreateUser(createUserRequest.ToCreateUser());
        return user.ToUserResponse();
    }
}