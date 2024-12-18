using System.ComponentModel.DataAnnotations;

namespace BunkerWebServer.Infrastructure.Data.Entities.Shared;

public class BaseEntity
{
    [Key]
    public Guid Id { get; init; }
    public required string Name { get; init; }
}