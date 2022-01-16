using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TiendaVirtual.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {

        [HttpGet("{id}")]
        public ActionResult ObtenerPermisos(int rolId)
        {
            if (rolId==1) { 
             string[] PermisoComprador = { "Pedidos-Comprador", "FormasPagos-Comprador", "Cuentas-Comprador", "Mensajes-Comprador" };
                return Ok(PermisoComprador);
            }
            else
            {
                string[] PermisoVendedor = { "Permisos-Vendedor", "Mensajes-Vendedor" };
                return Ok(PermisoVendedor);
            }
            
        }
    }
}
