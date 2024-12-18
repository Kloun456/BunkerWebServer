using BunkerWebServer.Infrastructure.Data.Entities.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BunkerWebServer.Infrastructure.Data.Entities.Rooms;

public class RoomMember
{
    [Key]
    public required Guid Id { get; init; }
    [ForeignKey(nameof(RoomId))]
    public required Guid RoomId { get; init; }
    [ForeignKey(nameof(UserId))]
    public required Guid UserId { get; init; }
            
    public required RoomData Room { get; init; }
    public required UserData User { get; init; }
}