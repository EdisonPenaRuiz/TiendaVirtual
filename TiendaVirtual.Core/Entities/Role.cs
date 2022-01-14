using System;
using System.Collections.Generic;

namespace TiendaVirtual.Core.Entities
{
    public partial class Role
    {
        public int RolId { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
