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
    [ApiController]
    [Route("api/[controller]")]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticulosRepository _IarticulosRepository;

        public ArticulosController(IArticulosRepository IarticuloRepository)
        {
            _IarticulosRepository = IarticuloRepository;
        }

        // GET: api/Articulos
        [HttpGet]
        [Route("ObtenerTodosLosArticulos")]
        public async Task<ActionResult<IEnumerable<Articulo>>> ObtenerTodosLosArticulos()
        {
            var ArticuloRespuesta = new Object();

            try
            {
                ArticuloRespuesta = await _IarticulosRepository.ObtenerTodosLosArticulosDisponible();
            }
            catch (Exception e)
            {

            }

            return Ok(ArticuloRespuesta);
        }

        // GET: api/Articulos/5
        [HttpGet("ArticuloUsuario/{id}")]
        public async Task<ActionResult<Articulo>> GetArticuloPorUsuarioID(int id)
        {
            var ArticuloRespuesta = new Object();

            try
            {
                ArticuloRespuesta = await _IarticulosRepository.ObtenerArticulosPorUsuarioID(id);
            }
            catch (Exception e)
            {

            }

            return Ok(ArticuloRespuesta);
        }

        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articulo>> GetArticuloPorArticuloID(int id)
        {
            var ArticuloRespuesta = new Object();

            try
            {
                ArticuloRespuesta = await _IarticulosRepository.ObtenerArticulosPorArticuloID(id);
            }
            catch (Exception e)
            {

            }

            return Ok(ArticuloRespuesta);
        }

        // PUT: api/Articulos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarArticulo(Articulo articulo)
        {
            var ArticuloRespuesta = new Object();

            try
            {
                ArticuloRespuesta = await _IarticulosRepository.ActualizarArticulo(articulo);
            }
            catch (Exception e)
            {

            }

            return Ok(ArticuloRespuesta);
        }

        // POST: api/Articulos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Articulo>> AgregarArticulo(Articulo articulo)
        {
            var ArticuloRespuesta = new Object();

            try
            {
                ArticuloRespuesta = await _IarticulosRepository.AgregarArticulo(articulo);
            }
            catch (Exception e)
            {

            }

            return Ok(ArticuloRespuesta);
        }

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            var ArticuloRespuesta = new Object();

            try
            {
                ArticuloRespuesta = await _IarticulosRepository.EliminarArticulo(id);
            }
            catch (Exception e)
            {

            }

            return Ok(ArticuloRespuesta);
        }

    }
}
