using System;
using System.Collections.Generic;

namespace TiendaVirtual.Core.Entities
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
        public int UsuarioId { get; set; }
        public bool Disponible { get; set; }

        public virtual Usuario Usuario { get; set; } = null!;
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
