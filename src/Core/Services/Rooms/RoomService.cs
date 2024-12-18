using BunkerWebServer.Core.Models.Rooms;
using BunkerWebServer.Infrastructure.Data.Repositories.Rooms;

namespace BunkerWebServer.Core.Services.Rooms
{
    public interface IRoomService
    {
        Task<Room> CreateRoom(CreateRoom createRoom);
        Task AddMember(Guid roomId, Guid userId);
        Task<Room?> GetRoom(Guid roomId);
        Task<IEnumerable<Room>> GetRooms();
    }

    public class RoomService(IRoomRepository roomRepository) : IRoomService
    {
        public async Task AddMember(Guid roomId, Guid userId)
        {
            await roomRepository.AddMember(roomId, userId);
        }

        public async Task<Room?> GetRoom(Guid roomId)
        {
            var room = await roomRepository.GetRoom(roomId);
            if (room == null)
            {
                return room;
            }
            await roomRepository.LoadMembers(room);
            return room;
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await roomRepository.GetRooms();
        }

        public async Task<Room> CreateRoom(CreateRoom createRoom)
        {
            return await roomRepository.CreateRoom(createRoom);
        }
    }
}
