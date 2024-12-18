using Newtonsoft.Json;

namespace BunkerWebServer.Api.Dto.Shared;

public class BaseDto
{
    [JsonProperty("id")]
    public required Guid Id { get; set; }
    [JsonProperty("name")]
    public required string Name { get; set; }
}