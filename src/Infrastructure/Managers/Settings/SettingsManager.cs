using BunkerWebServer.Infrastructure.Managers.Models;

namespace BunkerWebServer.Infrastructure.Managers.Settings
{
    public class SettingsManager
    {
        private readonly IConfigurationRoot _config;
        public readonly DbSettings _dbSetting;

        private const string _NameSettingsFile = "appsettings.json";
        private const string _NameSettingsDbSection = "Db";

        public SettingsManager() 
        {
            _config = new ConfigurationBuilder()
            .AddJsonFile(_NameSettingsFile)
            .AddEnvironmentVariables()
            .Build();
            _dbSetting = _config.GetRequiredSection(_NameSettingsDbSection)
                                .Get<DbSettings>() ?? new DbSettings (){ Connections = new Connections { DefaultConnection = ""} };
        }
    }
}
