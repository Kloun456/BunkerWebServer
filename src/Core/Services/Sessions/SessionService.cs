using BunkerWebServer.Infrastructure.Managers.Settings;
using Microsoft.Extensions.Caching.Distributed;

namespace BunkerWebServer.Core.Services.Sessions;

public interface ISessionService
{
    Task<string?> CreateSession(string username);
    Task<string?> GetSession(string idSession);
}

public class SessionService(IDistributedCache cache) : ISessionService
{
    private readonly SettingsManager _settingsManager = new();
    
    public async Task<string?> CreateSession(string username)
    {
        var idSession = string.Concat(username, ":", Guid.NewGuid().ToString());
        await cache.SetStringAsync(idSession, username, new DistributedCacheEntryOptions
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