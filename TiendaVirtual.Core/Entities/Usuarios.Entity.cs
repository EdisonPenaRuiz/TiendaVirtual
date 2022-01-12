using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVirtual.Core.Entities
{
    public class Usuarios
    {
        int UsuarioID { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        int RolID { get; set; }
        int CuentaID { get; set; }
    }
}
