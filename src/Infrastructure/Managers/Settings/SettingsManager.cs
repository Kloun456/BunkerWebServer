using BunkerWebServer.Infrastructure.Managers.Models.Settings;
using BunkerWebServer.Infrastructure.Managers.Models.Settings.Shared;

namespace BunkerWebServer.Infrastructure.Managers.Settings
{
    public class SettingsManager
    {
        private readonly IConfigurationRoot _config;
        public readonly DbSettings _dbSetting;
        public readonly RedisSettings _redisSetting;

        private const string _NameSettingsFile = "appsettings.json";
        private const string _NameSettingsDbSection = "Db";
        private const string _NameSettingsRedisSection = "Redis";
        

        public SettingsManager() 
        {
            _config = new ConfigurationBuilder()
            .AddJsonFile(_NameSettingsFile)
            .AddEnvironmentVariables()
            .Build();
            _dbSetting = _config.GetRequiredSection(_NameSettingsDbSection)
                                .Get<DbSettings>() ?? 
                         new DbSettings { 
                             Connections = new Connections 
                             { 
                                 DefaultConnection = "" 
                             } 
                         };
            _redisSetting = _config.GetRequiredSection(_NameSettingsRedisSection)
                                .Get<RedisSettings>() ??
                            new RedisSettings
                            {
                                Connections = new Connections
                                {
                                    DefaultConnection = ""
                                },
                                InstanceName = ""
                            };
        }
    }
}
