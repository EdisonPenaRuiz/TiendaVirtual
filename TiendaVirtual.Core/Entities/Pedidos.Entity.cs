using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVirtual.Core.Entities
{
    internal class Pedidos
    {
        int PedidoID { get; set; }
        string PaisDestino { get; set; }
        string ProvinciaDestino { get; set;}
        string SectorDestino { get; set; }
        string Articulo { get; set; }
        string FormaPago { get; set; }
        int UsuarioID { get; set; }
    }
}
