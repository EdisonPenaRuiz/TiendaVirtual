using Microsoft.AspNetCore.SignalR;
using TiendaVirtual.Core.Entities;
using TiendaVirtual.Core.Interfaces;

namespace TiendaVirtual.Client.Hubs
{
    public class MensajeriaTiempoReal:Hub
    {

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task EnviarMensaje(Mensaje mensaje)
        {
             await Clients.All.SendAsync("Mensaje",mensaje);
        }
    }
}
