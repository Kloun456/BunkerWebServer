using System.Net.WebSockets;

namespace BunkerWebServer.Api.Extensions;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:5173")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            })
            .AddRepository()
            .AddServices()
            .AddContexts()
            .AddSwagger()
            .AddRedis()
            .AddControllers();
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        
        app.UseRouting();
        app.UseCors("AllowSpecificOrigin");
        app.UseSwagger();
        app.UseSession();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = string.Empty; // Доступ к Swagger UI по корневому URL
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    
}

public static class ConfigureEndpoints
{
    public static void Configure(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/ws", async context =>
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                await HandleWebSocketAsync(webSocket);
            }
            else
            {
                context.Response.StatusCode = 500;
            }
        });
    }

    private static async Task HandleWebSocketAsync(WebSocket webSocket)
    {
        var buffer = new byte[1024 * 4];

        while (webSocket.State == WebSocketState.Open)
        {
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), 
                CancellationToken.None);

            if (result.MessageType == WebSocketMessageType.Close)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", 
                    CancellationToken.None);
            }
            else
            {
                var message = System.Text.Encoding.UTF8.GetString(buffer, 0, result.Count);
                var responseMessage = $"Echo: {message}";
                var responseBuffer = System.Text.Encoding.UTF8.GetBytes(responseMessage);
                await webSocket.SendAsync(new ArraySegment<byte>(responseBuffer), 
                    WebSocketMessageType.Text, true, CancellationToken.None);
                await Task.Delay(2000);
                responseMessage += "END";
                responseBuffer = System.Text.Encoding.UTF8.GetBytes(responseMessage);
                await webSocket.SendAsync(new ArraySegment<byte>(responseBuffer), 
                    WebSocketMessageType.Text, true, CancellationToken.None);
                

            }
        }
    }
}