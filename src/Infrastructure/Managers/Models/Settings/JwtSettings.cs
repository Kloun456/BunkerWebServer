namespace BunkerWebServer.Infrastructure.Managers.Models.Settings;

public class JwtSettings
{
    public required bool ValidateIssuer { get; init; }
    public required bool ValidateAudience { get; init; }
    public required bool ValidateLifetime { get; init; }
    public required bool ValidateIssuerSigningKey { get; init; }
    public required string ValidIssuer { get; init; }
    public required string ValidAudience { get; init; }
    public required string IssuerSigningKey { get; init; }
    public required double ExpiresMinute { get; init; }
}