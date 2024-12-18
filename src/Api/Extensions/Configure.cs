using BunkerWebServer.Core.Services.Rooms;
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
