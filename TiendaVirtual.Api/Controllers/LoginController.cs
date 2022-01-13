using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaVirtual.Core.Entities;
using TiendaVirtual.Core.Interfaces;

namespace TiendaVirtual.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly ILogin _Ilogin;

        public LoginController(ILogin Ilogin)
        {
            _Ilogin = Ilogin;
        }

        [HttpGet]
        public async Task<IActionResult> LoginUsuario(UsuarioLoguearse usuario)
        {
            var UsuarioRetrun=new Object();
            try
            {
               UsuarioRetrun =  await _Ilogin.LoginUsuario(usuario.NombreUsuario, usuario.Contrasena);
              
            }
            catch (Exception e)
            {

            }
           return Ok(UsuarioRetrun);
        }        


    }

  
}
