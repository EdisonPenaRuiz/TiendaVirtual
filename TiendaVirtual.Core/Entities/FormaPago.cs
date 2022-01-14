using System;
using System.Collections.Generic;

namespace TiendaVirtual.Core.Entities
{
    public partial class FormaPago
    {
        public FormaPago()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int FormaPagoId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
