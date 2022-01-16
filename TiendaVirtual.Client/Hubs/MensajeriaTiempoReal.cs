using Microsoft.AspNetCore.SignalR;

namespace TiendaVirtual.Client.Hubs
{
    public class MensajeriaTiempoReal:Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public Task MensajeGenerar(string mensaje)
        {
            return Clients.Client("").SendAsync("MensajeriaGeneral", mensaje);
        }
    }
}
