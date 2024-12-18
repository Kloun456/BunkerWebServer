using BunkerWebServer.Api.Dto.Shared;
using Newtonsoft.Json;

namespace BunkerWebServer.Api.Dto.Rooms;

public class RoomResponse : BaseDto
{
    [JsonProperty("countMembers")]
    public int CountMembers { get; set; }
    [JsonProperty("members")]
    public IEnumerable<UserInRoomResponse> Members { get; init; } = 
        new List<UserInRoomResponse>();
}

public class UserInRoomResponse : BaseDto;