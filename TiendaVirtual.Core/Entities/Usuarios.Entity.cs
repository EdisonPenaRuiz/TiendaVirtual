using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVirtual.Core.Entities
{
    public class Usuarios
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int RolID { get; set; }
        public int CuentaID { get; set; }
    }
}
