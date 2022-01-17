using System;
using System.Collections.Generic;

namespace TiendaVirtual.Core.Entities
{
    public partial class Mensaje
    {
        public int MensajeId { get; set; }
        public string Mensaje1 { get; set; } = null!;
        public int UsuarioIdorigen { get; set; }
        public int UsuarioIddestino { get; set; }
        public int PedidoId { get; set; }
        public bool EstadoMensaje { get; set; }

        public virtual Pedido MensajeNavigation { get; set; } = null!;
    }
}
