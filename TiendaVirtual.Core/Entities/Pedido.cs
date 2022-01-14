using System;
using System.Collections.Generic;

namespace TiendaVirtual.Core.Entities
{
    public partial class Pedido
    {
        public int PedidoId { get; set; }
        public string PaisDestino { get; set; } = null!;
        public string ProvinciaDestino { get; set; } = null!;
        public string SectorDestino { get; set; } = null!;
        public int ArticuloId { get; set; }
        public int FormaPagoId { get; set; }
        public int UsuarioId { get; set; }

    }
    public partial class ListadoPedido
    {
        public int PedidoID { get; set; }
        public string Nombre { get; set; } = null!;
        public string PaisDestino { get; set; } = null!;
        public string ProvinciaDestino { get; set; } = null!;
        public string SectorDestino { get; set; } = null!;
        public decimal Precio { get; set; }
        public string FormaDePago { get; set; }

    }
}
