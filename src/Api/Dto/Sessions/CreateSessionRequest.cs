namespace BunkerWebServer.Api.Dto.Sessions;

public class CreateSessionRequest
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}