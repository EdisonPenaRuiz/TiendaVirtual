using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVirtual.Core.Entities
{
    internal class Pedidos
    {
        public int PedidoID { get; set; }
        public string PaisDestino { get; set; }
        public string ProvinciaDestino { get; set;}
        public string SectorDestino { get; set; }
        public string Articulo { get; set; }
        public string FormaPago { get; set; }
        public int UsuarioID { get; set; }
    }
}
