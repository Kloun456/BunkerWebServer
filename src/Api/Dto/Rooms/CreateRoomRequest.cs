
using Newtonsoft.Json;

namespace BunkerWebServer.Api.Dto.Rooms;

public class CreateRoomRequest
{
    [JsonProperty("name")]
    public required string Name { get; set; }
}