using BunkerWebServer.Infrastructure.Data.Entities.Users;
using BunkerWebServer.Infrastructure.Data.Entities.Shared;

namespace BunkerWebServer.Infrastructure.Data.Entities.Rooms
{
    public class RoomData : BaseEntity
    {
        public int CountMembers { get; init; }
        public ICollection<UserData> Users { get; init; } = new List<UserData>();
    }
}