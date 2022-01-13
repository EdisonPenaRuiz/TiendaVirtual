using System;
using System.Collections.Generic;

namespace TiendaVirtual.Infrastruture.Data
{
    public partial class TiposTrasaccione
    {
        public TiposTrasaccione()
        {
            FormaPagos = new HashSet<FormaPago>();
        }

        public int TipoTransaccionId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<FormaPago> FormaPagos { get; set; }
    }
}
