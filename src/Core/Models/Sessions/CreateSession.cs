namespace BunkerWebServer.Core.Models.Sessions;

public class CreateSession
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}