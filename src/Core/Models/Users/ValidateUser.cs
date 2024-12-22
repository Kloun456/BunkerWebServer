namespace BunkerWebServer.Core.Models.Users;

public class ValidateUser
{
    public required string UserName { get; init; }
    public required string Password { get; set; }
}