namespace BunkerWebServer.Core.Models.Shared;

public class BaseModel
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}