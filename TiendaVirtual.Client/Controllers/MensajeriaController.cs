using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TiendaVirtual.Client.Hubs;
using TiendaVirtual.Core.Entities;
using TiendaVirtual.Core.Interfaces;

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
        public string ObtenerMensaje(string mensajes) 
        {
            string repuesta = string.Empty;
            
            _hubContext.Clients.All.SendAsync("mensajes",mensajes);

            return repuesta;
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerMensajesConTodosLosUsuariosDestino(int usuarioOrigenId)
        {
            //string mensaje = Newtonsoft.Json.JsonConvert.SerializeObject(mensajesModel);

            //_hubContext.Clients.Client(mensajesModel.UsuarioIddestino.ToString()).SendAsync("enviarmensaje", mensajesModel.Mensaje1);

            return Ok("Operacion realizada correctamente!");
        }

        [HttpGet]
        public IActionResult ObtenerMensajesConUsuarioEspecifico(Mensaje mensajes)
        {
            //string mensaje = Newtonsoft.Json.JsonConvert.SerializeObject(mensajesModel);

            //_hubContext.Clients.Client(mensajesModel.UsuarioIddestino.ToString()).SendAsync("enviarmensaje", mensajesModel.Mensaje1);

            return Ok("Operacion realizada correctamente!");
        }
    }
}
