using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtual.Core.Entities;
using TiendaVirtual.Core.Wrappers;

namespace TiendaVirtual.Core.Interfaces
{
    public interface IPedidosRepository
    {

        public Task<RepuestasServidorGenericas<ListadoPedido>> ObtenerPedidosPorUsuarioID(Usuario Usuario);

        public Task<RepuestasServidorGenericas<Pedido>> AgregarPedido(Pedido Pedido);

        public Task<RepuestasServidorGenericas<Pedido>> ActualizarPedido(Pedido Pedido, int PedidoID);
        
        public Task<RepuestasServidorGenericas<Pedido>> EliminarPedido(int PedidoID);
    }
}
