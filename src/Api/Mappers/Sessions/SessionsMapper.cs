using BunkerWebServer.Api.Dto.Sessions;
using BunkerWebServer.Core.Models.Sessions;

namespace BunkerWebServer.Api.Mappers.Sessions;

public static class SessionsMapper
{
    public static CreateSession ToCreateSession(this CreateSessionRequest createSessionRequest)
    {
        return new CreateSession
        {
            UserName = createSessionRequest.UserName,
            Password = createSessionRequest.Password
        };
    }
}