using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtual.Core.Entities;
using TiendaVirtual.Core.Interfaces;
using TiendaVirtual.Core.Wrappers;
using TiendaVirtual.Infrastruture.Data;

namespace TiendaVirtual.Infrastruture.Repositories
{
    public class ArticulosRepository:IArticulosRepository
    {
        readonly TiendaVirtualContext _context;
        public ArticulosRepository(TiendaVirtualContext context)
        {
            _context = context;
        }
        public async Task<RepuestasServidorGenericas<Articulo>> ObtenerTodosLosArticulosDisponible()
        {
            var Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, new List<Articulo>() { }, false);
            try
            {
                var Articulos = await _context.Articulos.Where(articulo => articulo.ArticuloId==1).ToListAsync();
                Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, Articulos, true);
            }
            catch (Exception e)
            {
                Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, new List<Articulo>() { }, false, e.Message);
            }

            return Respuesta;
        }
        public async Task<RepuestasServidorGenericas<Articulo>> ObtenerArticulosPorUsuarioID(int UsuarioID)
        {
            var Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, new List<Articulo>() { }, false);
            try
            {
                var Articulos = await _context.Articulos.Where(articulo => articulo.UsuarioId==UsuarioID).ToListAsync();
                Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, Articulos, true);
            }
            catch (Exception e)
            {
                Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, new List<Articulo>() { }, false, e.Message);
            }

            return Respuesta;
        }
        public async Task<RepuestasServidorGenericas<Articulo>> ObtenerArticulosPorArticuloID(int ArticuloID)
        {
            var Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, new List<Articulo>() { }, false);
            try
            {
                var Articulo = _context.Articulos.Find(ArticuloID);
                Respuesta = new RepuestasServidorGenericas<Articulo>(Articulo, new List<Articulo>() { }, true);
            }
            catch (Exception e)
            {
                Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, new List<Articulo>() { }, false, e.Message);
            }

            return Respuesta;
        }

        public async Task<RepuestasServidorGenericas<Articulo>>AgregarArticulo(Articulo articulo)
        {
            var Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, new List<Articulo>() { }, false);
            try
            {
                var Articulos = _context.AddAsync(articulo);
                await _context.SaveChangesAsync();
                Respuesta = new RepuestasServidorGenericas<Articulo>(articulo, new List<Articulo>() { }, true);
            }
            catch (Exception e)
            {
                Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, new List<Articulo>() { }, false, e.Message);
            }

            return Respuesta;
        }

        public async Task<RepuestasServidorGenericas<Articulo>> ActualizarArticulo(Articulo articulo)
        {
            var Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, new List<Articulo>() { }, false);
            try
            {
                if (_context.Articulos.Where(articulo => articulo.ArticuloId == articulo.ArticuloId).Count() > 0)
                {
                    _context.Entry(articulo).State = EntityState.Modified;
                    var Articulos = _context.Update(articulo);
                    await _context.SaveChangesAsync();
                    Respuesta = new RepuestasServidorGenericas<Articulo>(articulo, new List<Articulo>() { }, true);

                }
                else
                {
                    Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, new List<Articulo>() { }, false, "No existe el articulo que desea actualizar");
                }

            }
            catch (Exception e)
            {
                Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, new List<Articulo>() { }, false, e.Message);
            }

            return Respuesta;
        }

        public async Task<RepuestasServidorGenericas<Articulo>> EliminarArticulo(int ArticuloID)
        {
            var Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, new List<Articulo>() { }, false);
            try
            {
                if (ArticuloID != null)
                {
                    var articulo = await _context.Articulos.FindAsync(ArticuloID);

                    if (articulo != null)
                    {
                        _context.Articulos.Remove(articulo);
                        await _context.SaveChangesAsync();
                        Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, new List<Articulo>() { }, true);

                    }
                    else
                    {
                        Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, new List<Articulo>() { }, false,"No existe el articulo que desea eliminar!");

                    }
                }
                else
                {
                    Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, new List<Articulo>() { }, false, "El articulo id que ha intentado eliminar no es valido");
                }

            }
            catch (Exception e)
            {
                Respuesta = new RepuestasServidorGenericas<Articulo>(new Articulo() { }, new List<Articulo>() { }, false, e.Message);
            }

            return Respuesta;
        }
    }
}
