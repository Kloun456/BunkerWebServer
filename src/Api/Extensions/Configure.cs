using BunkerWebServer.Core.Services.Rooms;
using BunkerWebServer.Core.Services.Sessions;
using BunkerWebServer.Core.Services.Users;
using BunkerWebServer.Infrastructure.Contexts;
using BunkerWebServer.Infrastructure.Data.Repositories.Rooms;
using BunkerWebServer.Infrastructure.Data.Repositories.Users;
using BunkerWebServer.Infrastructure.Managers.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BunkerWebServer.Api.Extensions
{
    public static class Configure
    {
        private static readonly SettingsManager SettingsManager = new();

        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRoomService, RoomService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ISessionService, SessionService>();
            return serviceCollection;
        }

        public static IServiceCollection AddRedis(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = SettingsManager._redisSetting.Connections.DefaultConnection;
                options.InstanceName = SettingsManager._redisSetting.InstanceName;
            });

            serviceCollection.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(SettingsManager._redisSetting.SessionSettings!.Lifetime); 
                options.Cookie.HttpOnly = SettingsManager._redisSetting.SessionSettings!.HttpOnly; 
                options.Cookie.IsEssential = SettingsManager._redisSetting.SessionSettings!.IsEssential; 
            });
            
            return serviceCollection;
        }

        public static IServiceCollection AddRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRoomRepository, RoomRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            return serviceCollection;
        }
        
        public static IServiceCollection AddContexts(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString: SettingsManager._dbSetting.Connections.DefaultConnection));
            return serviceCollection;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            return serviceCollection;
        }
    }
}
