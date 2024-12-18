using BunkerWebServer.Core.Models.Rooms;
using BunkerWebServer.Infrastructure.Data.Entities.Rooms;
using BunkerWebServer.Infrastructure.Data.Entities.Users;

namespace BunkerWebServer.Infrastructure.Data.Mappers.Rooms;

public static class RoomMapper
{
    public static Room ToRoom(this RoomData roomData)
    {
        return new Room
        {
            Id = roomData.Id,
            CountMembers = roomData.CountMembers,
            Name = roomData.Name
        };
    }

    public static RoomData ToRoomData(this Room room)
    {
        return new RoomData
        {
            Id = room.Id,
            Name = room.Name,
            CountMembers = room.CountMembers
        };
    }

    public static UserInRoom ToUserInRoom(this UserData userData)
    {
        return new UserInRoom
        {
            Id = userData.Id,
            Name = userData.Name
        };
    }
}