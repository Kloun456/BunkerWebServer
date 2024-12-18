﻿using BunkerWebServer.Infrastructure.Data.Entities.Rooms;
using BunkerWebServer.Infrastructure.Data.Entities.Shared;

namespace BunkerWebServer.Infrastructure.Data.Entities.Users
{
    public class UserData : BaseEntity
    {
        public ICollection<RoomData> Rooms { get; init; } = new List<RoomData>();
    }
}