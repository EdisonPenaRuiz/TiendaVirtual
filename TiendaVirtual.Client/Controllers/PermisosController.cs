using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TiendaVirtual.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {

        [HttpGet("{rolId}")]
        public ActionResult ObtenerPermisos(int rolId)
        {
            if (rolId==1) { 
             string[] PermisoComprador = { "Comprador" };
                return Ok(PermisoComprador);
            }
            else if (rolId == 2)
            {
                string[] PermisoVendedor = { "Vendedor" };
                return Ok(PermisoVendedor);
            }
            return Ok();
        }
    }
}
