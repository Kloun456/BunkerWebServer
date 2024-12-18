using BunkerWebServer.Api.Dto.Rooms;
using BunkerWebServer.Api.Mappers.Rooms;
using BunkerWebServer.Core.Models.Users;
using BunkerWebServer.Core.Services.Rooms;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BunkerWebServer.Api.Controller.Rooms;

[Route("api/rooms")]
[ApiController]
public class RoomsController(IRoomService roomService) : ControllerBase
{
    [HttpPost]
    public async Task<RoomResponse> CreateRoom([FromBody] CreateRoomRequest createRoomRequest)
    {
        var room = await roomService.CreateRoom(createRoomRequest.ToCreateRoom());
        return room.ToRoomResponse();
    }

    [HttpPatch("{roomId:guid}/members/{userId:guid}")]
    public async Task UpdateMember(Guid roomId, Guid userId, [FromBody]JsonPatchDocument<User> patchDoc)
    {
        await roomService.AddMember(roomId, userId);
    }

    [HttpGet]
    public async Task<IEnumerable<RoomResponse>> GetRooms()
    {
        var rooms = await roomService.GetRooms();
        return rooms.Select(room => room.ToRoomResponse());
    }

    [HttpGet("{roomId:guid}")]
    public async Task<RoomResponse?> GetRoom(Guid roomId)
    {
        var room = await roomService.GetRoom(roomId);
        return room?.ToRoomResponse();
    }
}
