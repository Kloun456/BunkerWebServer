﻿namespace BunkerWebServer.Core.Models.Users;

public class CreateUser
{
    public required string UserName { get; init; }
    public required string Password { get; set; }
}