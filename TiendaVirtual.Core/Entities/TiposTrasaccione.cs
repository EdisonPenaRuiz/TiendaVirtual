using System;
using System.Collections.Generic;

namespace TiendaVirtual.Core.Entities
{
    public partial class TiposTrasaccione
    {
        public TiposTrasaccione()
        {
            
        }

        public int TipoTransaccionId { get; set; }
        public string Nombre { get; set; } = null!;

    }
}
