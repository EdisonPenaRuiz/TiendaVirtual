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
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosRepository _IpedidosRepository;

        public PedidosController(IPedidosRepository IpedidoRepository)
        {
            _IpedidosRepository = IpedidoRepository;
        }

       
        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> ObtenerPedidosPorUsuario(int id)
        {
            var PedidosReturn = new Object();
            try
            {
                PedidosReturn = await _IpedidosRepository.ObtenerPedidosPorUsuarioID(id);
            }
            catch (Exception e)
            {

            }
            return Ok(PedidosReturn);
        }

        // POST: api/Pedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pedido>> AgregarPedido(Pedido pedidos)
        {
            var PedidosReturn = new Object();
            try
            {
                PedidosReturn = await _IpedidosRepository.AgregarPedido(pedidos);

            }
            catch (Exception e)
            {
                PedidosReturn = e;
            }
            return Ok(PedidosReturn);
        }

        // PUT: api/Pedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPedidos(int id,Pedido Pedido)
        {
            var PedidosReturn = new Object();
            try
            {
                PedidosReturn = await _IpedidosRepository.ActualizarPedido(Pedido,id);

            }
            catch (Exception e)
            {
                PedidosReturn = e;
            }
            return Ok(PedidosReturn);
        }

       

        // DELETE: api/Pedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPedidos(int id)
        {
            var PedidosReturn = new Object();
            try
            {
                PedidosReturn = await _IpedidosRepository.EliminarPedido(id);

            }
            catch (Exception e)
            {
                PedidosReturn = e;
            }
            return Ok(PedidosReturn);
        }

    }
}
