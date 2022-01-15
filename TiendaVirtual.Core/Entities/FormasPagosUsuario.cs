using System;
using System.Collections.Generic;

namespace TiendaVirtual.Core.Entities
{
    public partial class FormasPagosUsuario
    {
        public int FormaPagoId { get; set; }
        public string Nombre { get; set; } = null!;
        public int UsuarioId { get; set; }
    }
}
