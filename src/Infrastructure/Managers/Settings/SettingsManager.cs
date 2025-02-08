using BunkerWebServer.Infrastructure.Managers.Models.Settings;
using BunkerWebServer.Infrastructure.Managers.Models.Settings.Shared;

namespace BunkerWebServer.Infrastructure.Managers.Settings
{
    public class SettingsManager
    {
        public readonly DbSettings DbSetting;
        //public readonly RedisSettings RedisSetting;
        public readonly JwtSettings JwtSetting;
        
        private const string NameSettingsFile = "appsettings.json";
        private const string NameSettingsDbSection = "Db";
        //private const string NameSettingsRedisSection = "Redis";
        private const string NameSettingsJwtSetting = "Jwt";
        
        public SettingsManager() 
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(NameSettingsFile)
                .AddEnvironmentVariables()
                .Build();
            DbSetting = config.GetRequiredSection(NameSettingsDbSection)
                                .Get<DbSettings>() ?? 
                         new DbSettings { 
                             Connections = new Connections 
                             { 
                                 DefaultConnection = "" 
                             } 
                         };
            /*RedisSetting = config.GetRequiredSection(NameSettingsRedisSection)
                               .Get<RedisSettings>() ?? 
                           new RedisSettings 
                           { 
                               Connections = new Connections
                               { 
                                   DefaultConnection = ""
                               },
                               InstanceName = ""
                           };*/
            JwtSetting = config.GetRequiredSection(NameSettingsJwtSetting)
                             .Get<JwtSettings>() ?? 
                         new JwtSettings 
                         { 
                             ValidateIssuer = true,
                             ValidateAudience = true,
                             ValidateLifetime = true,
                             ValidateIssuerSigningKey = true,
                             IssuerSigningKey = "",
                             ValidAudience = "",
                             ValidIssuer = "",
                             ExpiresMinute = 2
                         };
        }
    }
}
