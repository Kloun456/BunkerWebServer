using BunkerWebServer.Core.Models.Sessions;
using BunkerWebServer.Infrastructure.Managers.Settings;
using Microsoft.Extensions.Caching.Distributed;

namespace BunkerWebServer.Core.Services.Sessions;

public interface ISessionService
{
    Task<string?> CreateSession(CreateSession createSession);
    Task<string?> GetSession(string idSession);
}

public class SessionService(IDistributedCache cache) : ISessionService
{
    private readonly SettingsManager _settingsManager = new();
    
    public async Task<string?> CreateSession(CreateSession createSession)
    {
        var idSession = string.Concat(createSession.UserName, ":", Guid.NewGuid().ToString());
        await cache.SetStringAsync(idSession, createSession.UserName, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(
                _settingsManager._redisSetting.SessionSettings!.Lifetime)
        });
        
        return idSession;
    }

    public async Task<string?> GetSession(string idSession)
    {
        return await cache.GetStringAsync(idSession);
    }
}