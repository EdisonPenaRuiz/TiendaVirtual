using System;
using System.Collections.Generic;

namespace TiendaVirtual.Core.Entities
{
    public partial class Cuenta
    {
        public int CuentaId { get; set; }
        public decimal Monto { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; } = null!;
    }
}
