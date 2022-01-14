#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaVirtual.Core.Entities;
using TiendaVirtual.Infrastruture.Data;

namespace TiendaVirtual.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaPagosController : ControllerBase
    {
        private readonly TiendaVirtualContext _context;

        public FormaPagosController(TiendaVirtualContext context)
        {
            _context = context;
        }

        // GET: api/FormaPagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormaPago>>> GetFormaPagos()
        {
            return await _context.FormaPagos.ToListAsync();
        }

        // GET: api/FormaPagos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormaPago>> GetFormaPago(int id)
        {
            var formaPago = await _context.FormaPagos.FindAsync(id);

            if (formaPago == null)
            {
                return NotFound();
            }

            return formaPago;
        }

        // PUT: api/FormaPagos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormaPago(int id, FormaPago formaPago)
        {
            if (id != formaPago.FormaPagoId)
            {
                return BadRequest();
            }

            _context.Entry(formaPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormaPagoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FormaPagos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FormaPago>> PostFormaPago(FormaPago formaPago)
        {
            _context.FormaPagos.Add(formaPago);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FormaPagoExists(formaPago.FormaPagoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFormaPago", new { id = formaPago.FormaPagoId }, formaPago);
        }

        // DELETE: api/FormaPagos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormaPago(int id)
        {
            var formaPago = await _context.FormaPagos.FindAsync(id);
            if (formaPago == null)
            {
                return NotFound();
            }

            _context.FormaPagos.Remove(formaPago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormaPagoExists(int id)
        {
            return _context.FormaPagos.Any(e => e.FormaPagoId == id);
        }
    }
}
