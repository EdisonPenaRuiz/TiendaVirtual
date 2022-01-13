using System;
using System.Collections.Generic;

namespace TiendaVirtual.Infrastruture.Data
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

        public virtual Articulo Articulo { get; set; } = null!;
        public virtual FormaPago FormaPago { get; set; } = null!;
        public virtual Usuario Usuario { get; set; } = null!;
    }
}
