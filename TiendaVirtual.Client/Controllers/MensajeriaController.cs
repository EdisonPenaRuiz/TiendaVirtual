using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TiendaVirtual.Client.Hubs;
using TiendaVirtual.Core.Entities;

namespace TiendaVirtual.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensajeriaController : ControllerBase
    {
        private readonly IHubContext<MensajeriaTiempoReal> _hubContext;
        public MensajeriaController(IHubContext<MensajeriaTiempoReal> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public IActionResult EnviarMensaje([FromBody] MensajesModel mensajesModel) 
        {
            string mensaje = Newtonsoft.Json.JsonConvert.SerializeObject(mensajesModel);
            Console.WriteLine(mensaje);
            _hubContext.Clients.All.SendAsync("enviarmensaje", mensajesModel);

            return Ok("Operacion realizada correctamente!");
        }
    }
}
