using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtual.Core.Entities;
using TiendaVirtual.Core.Wrappers;

namespace TiendaVirtual.Core.Interfaces
{
    public interface IArticulosRepository
    {
        public Task<RepuestasServidorGenericas<Articulo>> ObtenerTodosLosArticulosDisponible();
        public Task<RepuestasServidorGenericas<Articulo>> ObtenerArticulosPorUsuarioID(int UsuarioID);
        public Task<RepuestasServidorGenericas<Articulo>> ObtenerArticulosPorArticuloID(int ArticuloID);
        public Task<RepuestasServidorGenericas<Articulo>> AgregarArticulo(Articulo articulo);
        public Task<RepuestasServidorGenericas<Articulo>> ActualizarArticulo(Articulo articulo);
        public Task<RepuestasServidorGenericas<Articulo>> EliminarArticulo(int ArticuloID);

    }
}
