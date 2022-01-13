using System;
using System.Collections.Generic;

namespace TiendaVirtual.Infrastruture.Data
{
    public partial class Usuario
    {
        public Usuario()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int UsuarioId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int RolId { get; set; }
        public int CuentaId { get; set; }

        public virtual Cuenta Cuenta { get; set; } = null!;
        public virtual Role Rol { get; set; } = null!;
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
