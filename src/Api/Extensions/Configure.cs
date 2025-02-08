using System.Text;
using BunkerWebServer.Core.Services.Authorization;
using BunkerWebServer.Core.Services.Rooms;
using BunkerWebServer.Core.Services.Users;
using BunkerWebServer.Infrastructure.Contexts;
using BunkerWebServer.Infrastructure.Data.Repositories.Rooms;
using BunkerWebServer.Infrastructure.Data.Repositories.Users;
using BunkerWebServer.Infrastructure.Managers.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
            serviceCollection.AddTransient<IAuthorizationService, AuthorizationService>();
            return serviceCollection;
        }

        public static IServiceCollection AddJwt(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = SettingsManager.JwtSetting.ValidateIssuer,
                        ValidateAudience = SettingsManager.JwtSetting.ValidateAudience,
                        ValidateLifetime = SettingsManager.JwtSetting.ValidateLifetime,
                        ValidateIssuerSigningKey = SettingsManager.JwtSetting.ValidateIssuerSigningKey,
                        ValidIssuer = SettingsManager.JwtSetting.ValidIssuer,
                        ValidAudience = SettingsManager.JwtSetting.ValidAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(SettingsManager.JwtSetting.IssuerSigningKey)),
                        
                    };
                });
            return serviceCollection;
        }

        /*public static IServiceCollection AddRedis(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = SettingsManager.RedisSetting.Connections.DefaultConnection;
                options.InstanceName = SettingsManager.RedisSetting.InstanceName;
            });

            serviceCollection.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(SettingsManager.RedisSetting.SessionSettings!.Lifetime); 
                options.Cookie.HttpOnly = SettingsManager.RedisSetting.SessionSettings!.HttpOnly; 
                options.Cookie.IsEssential = SettingsManager.RedisSetting.SessionSettings!.IsEssential; 
            });
            
            return serviceCollection;
        }*/

        public static IServiceCollection AddRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRoomRepository, RoomRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            return serviceCollection;
        }
        
        public static IServiceCollection AddContexts(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString: SettingsManager.DbSetting.Connections.DefaultConnection));
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
