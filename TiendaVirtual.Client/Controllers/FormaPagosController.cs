#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaVirtual.Core.Entities;
using TiendaVirtual.Core.Interfaces;
using TiendaVirtual.Infrastruture.Data;

namespace TiendaVirtual.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaPagosController : ControllerBase
    {
        private readonly IFormasPagosUsuarioRepository _formapagousuario;

        public FormaPagosController(IFormasPagosUsuarioRepository formaPagoUsuarios)
        {
            
            _formapagousuario= formaPagoUsuarios;
        }
        // GET: api/FormaPagos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormasPagosUsuario>> ObtenerFormasPagosPorUsuarioID(int Usuarioid)
        {
            var FormaPagosReturn = new Object();
            try
            {
                FormaPagosReturn = await _formapagousuario.ObtenerFormasPagosPorUsuarioID(Usuarioid);
            }
            catch (Exception e)
            {

            }
            return Ok(FormaPagosReturn);
        }

        // PUT: api/FormaPagos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarFormaDePago(FormasPagosUsuario formaPago)
        {
            var FormaPagoActualizado = new Object();
            try
            {
                await _formapagousuario.ActualizarFormasPagosPorUsuarioID(formaPago);
            }catch(Exception e)
            {

            }
            return Ok(FormaPagoActualizado);
        }

        // POST: api/FormaPagos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AgregarFormaDePago(FormasPagosUsuario formaPago)
        {
            var FormaPagoActualizado = new Object();
            try
            {
                await _formapagousuario.AgregarFormasPagosPorUsuarioID(formaPago);
            }
            catch (Exception e)
            {

            }
            return Ok(FormaPagoActualizado);
        }

        // DELETE: api/FormaPagos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarFormaDePago(int formaPagoID)
        {
            var FormaPagoActualizado = new Object();
            try
            {
                await _formapagousuario.EliminarFormasPagosPorUsuarioID(formaPagoID);
            }
            catch (Exception e)
            {

            }
            return Ok(FormaPagoActualizado);
        }

    }
}
