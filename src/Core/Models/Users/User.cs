using BunkerWebServer.Core.Models.Shared;

namespace BunkerWebServer.Core.Models.Users;

public class User : BaseModel
{
    public required string HashPassword { get; set; } 
}