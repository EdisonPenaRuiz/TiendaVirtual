using System;
using System.Collections.Generic;

namespace TiendaVirtual.Infrastruture.Data
{
    public partial class Articulo
    {
        public Articulo()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int ArticuloId { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
