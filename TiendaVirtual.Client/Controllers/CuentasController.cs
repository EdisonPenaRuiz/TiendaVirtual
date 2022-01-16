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
    public class CuentasController : ControllerBase
    {
        private readonly ICuentaRepository _IcuentaRepository;

        public CuentasController(ICuentaRepository ICuentaRepository)
        {
            _IcuentaRepository = ICuentaRepository;
        }


        // GET: api/Cuentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuenta>> ObtenerCuentaPorUsuario(int id)
        {
            var CuentaReturn = new Object();
            try
            {
                CuentaReturn = await _IcuentaRepository.ObtenerCuentaPorUsuarioID(id);
            }
            catch (Exception e)
            {

            }
            return Ok(CuentaReturn);
        }

        // POST: api/Cuentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cuenta>> AgregarCuenta(Cuenta Cuenta)
        {
            var CuentaReturn = new Object();
            try
            {
                CuentaReturn = await _IcuentaRepository.AgregarCuenta(Cuenta);

            }
            catch (Exception e)
            {
                CuentaReturn = e;
            }
            return Ok(CuentaReturn);
        }

        // PUT: api/Cuentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCuenta(Cuenta Cuenta)
        {
            var CuentasReturn = new Object();
            try
            {
                CuentasReturn = await _IcuentaRepository.ActualizarCuenta(Cuenta);

            }
            catch (Exception e)
            {
                CuentasReturn = e;
            }
            return Ok(CuentasReturn);
        }



        // DELETE: api/Cuentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCuenta(int id)
        {
            var CuentaReturn = new Object();
            try
            {
                CuentaReturn = await _IcuentaRepository.EliminarCuenta(id);

            }
            catch (Exception e)
            {
                CuentaReturn = e;
            }
            return Ok(CuentaReturn);
        }

    }
}
