namespace BunkerWebServer.Infrastructure.Managers.Models;

public class DbSettings
{
    public required Connections Connections { get; set; }
}

public class Connections
{
    public required string DefaultConnection { get; set; }
}
