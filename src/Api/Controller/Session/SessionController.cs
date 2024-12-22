using BunkerWebServer.Core.Services.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace BunkerWebServer.Api.Controller.Session;

[Route("api/sessions")]
[ApiController]
public class SessionsController(ISessionService sessionService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateSession([FromBody] string userName)
    {
        return Ok(await sessionService.CreateSession(userName));
    }
    
    [HttpGet("{idSession}")]
    public async Task<ActionResult> GetSession([FromRoute] string idSession)
    {
        return Ok(await sessionService.GetSession(idSession));
    }
}
