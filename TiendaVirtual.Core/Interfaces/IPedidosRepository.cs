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

        public Task<RepuestasServidorGenericas<ListadoPedido>> ObtenerPedidosPorUsuarioID(int UsuarioID);

        public Task<RepuestasServidorGenericas<Pedido>> AgregarPedidos(List<Pedido> Pedidos);

    }
}
