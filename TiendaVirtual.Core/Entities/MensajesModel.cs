using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVirtual.Core.Entities
{
    public class MensajesModel
    {
        public int UsuarioIDOrigen { get; set; }

        public int UsuarioIDDestino { get; set; }

        public string Mensaje { get; set; }
    }
}
