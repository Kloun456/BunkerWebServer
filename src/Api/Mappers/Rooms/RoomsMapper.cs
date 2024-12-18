using BunkerWebServer.Api.Dto.Rooms;
using BunkerWebServer.Core.Models.Rooms;

namespace BunkerWebServer.Api.Mappers.Rooms;

public static class RoomsMapper
{
    public static CreateRoom ToCreateRoom(this CreateRoomRequest createRoomRequest)
    {
        return new CreateRoom
        {
            Name = createRoomRequest.Name
        };
    }

    public static RoomResponse ToRoomResponse(this Room room)
    {
        return new RoomResponse
        {
            Id = room.Id,
            Name = room.Name,
            CountMembers = room.CountMembers,
            Members = room.Members.Select(member => member.ToUserInRoomResponse())
        };
    }

    private static UserInRoomResponse ToUserInRoomResponse(this UserInRoom userInRoom)
    {
        return new UserInRoomResponse
        {
            Id = userInRoom.Id,
            Name = userInRoom.Name
        };
    }
}