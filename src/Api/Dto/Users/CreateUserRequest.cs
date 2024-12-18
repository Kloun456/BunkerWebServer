
using Newtonsoft.Json;

namespace BunkerWebServer.Api.Dto.Users;

public class CreateUserRequest
{
    [JsonProperty("name")]
    public required string Name { get; set; }
}