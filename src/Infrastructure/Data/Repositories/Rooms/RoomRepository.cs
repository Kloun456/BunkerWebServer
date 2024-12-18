using BunkerWebServer.Core.Models.Rooms;
using BunkerWebServer.Infrastructure.Contexts;
using BunkerWebServer.Infrastructure.Data.Entities.Rooms;
using BunkerWebServer.Infrastructure.Data.Mappers.Rooms;
using Microsoft.EntityFrameworkCore;

namespace BunkerWebServer.Infrastructure.Data.Repositories.Rooms
{
    public interface IRoomRepository
    {
        Task<Room> CreateRoom(CreateRoom room);
        Task<Room?> GetRoom(Guid roomId);
        Task LoadMembers(Room room);
        Task AddMember(Guid roomId, Guid userId);
        Task<IEnumerable<Room>> GetRooms();
    }

    public class RoomRepository(ApplicationDbContext dbContext) : IRoomRepository
    {
        private const string ErrorNotCreateUser = "Not created user";
        
        public async Task<Room> CreateRoom(CreateRoom room)
        {
            var roomData = await dbContext.Rooms.AddAsync(
                new RoomData 
                { 
                    Id = Guid.NewGuid(), 
                    CountMembers = 0, 
                    Name = room.Name
                }    
            );

            await dbContext.SaveChangesAsync();

            return await GetRoom(roomData.Entity.Id) ?? throw new NullReferenceException(ErrorNotCreateUser);
        }

        public async Task LoadMembers(Room room)
        {
            var roomData = room.ToRoomData();
            
            await dbContext.Entry(roomData).Collection(r => r.Users).LoadAsync();

            room.Members = roomData.Users.Select(roomUser => roomUser.ToUserInRoom());
            
        }

        public async Task AddMember(Guid roomId, Guid userId)
        {
            var room = await dbContext.Rooms.FirstOrDefaultAsync( room => room.Id == roomId )
                ?? throw new Exception($"Нет команты с Id - {roomId}");

            var user = await dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId)
                ?? throw new Exception($"Нет пользователя с Id - {userId}");

            user.Rooms.Add(room);
            room.Users.Add(user);

            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            var roomsData = await dbContext.Rooms.ToListAsync();
            return roomsData.Select(roomData => roomData.ToRoom());
        }

        public async Task<Room?> GetRoom(Guid roomId)
        {
            var roomData = await(from room in dbContext.Rooms
                                 where room.Id == roomId
                                 select room).FirstOrDefaultAsync();

            return roomData?.ToRoom() ?? null;
        }
    }
}
