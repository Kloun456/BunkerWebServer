using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BunkerWebServer.Infrastructure.Managers.Settings;
using Microsoft.IdentityModel.Tokens;

namespace BunkerWebServer.Core.Services.Authorization;

public interface IAuthorizationService
{
    string GenerateJwtToken(string userName);
}

public class AuthorizationService : IAuthorizationService
{
    private readonly SettingsManager _settingsManager= new ();
    
    public string GenerateJwtToken(string userName)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settingsManager.JwtSetting.IssuerSigningKey));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _settingsManager.JwtSetting.ValidIssuer,
            audience: _settingsManager.JwtSetting.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_settingsManager.JwtSetting.ExpiresMinute),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}