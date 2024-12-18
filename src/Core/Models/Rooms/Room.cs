using BunkerWebServer.Core.Models.Shared;

namespace BunkerWebServer.Core.Models.Rooms;

public class Room : BaseModel
{
    public int CountMembers { get; init; }
    public IEnumerable<UserInRoom> Members { get; set; } = new List<UserInRoom>();
}

public class UserInRoom : BaseModel;