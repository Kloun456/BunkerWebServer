
using Newtonsoft.Json;

namespace BunkerWebServer.Api.Dto.Users;

public class CreateUserRequest
{
    [JsonProperty("name")]
    public required string Name { get; set; }
    [JsonProperty("password")]
    public required string Password { get; set; }
}