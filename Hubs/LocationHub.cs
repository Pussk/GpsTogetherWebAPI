using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;

namespace GpsTogetherWebAPI.Hubs
{
    public class LocationHub : Hub
    {
        public async Task SendLocation(int userId, double latitude, double longitude)
        {
            var timestamp = DateTime.UtcNow;

            // Envia a localização para todos os outros clientes conectados
            await Clients.Others.SendAsync("ReceiveLocation", new
            {
                userId,
                latitude,
                longitude,
                timestamp
            });
        }
    }
}
