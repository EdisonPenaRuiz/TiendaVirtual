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
    public class FormasPagosUsuarios:IFormasPagosUsuarioRepository
    {
        public readonly TiendaVirtualContext _context;
        public FormasPagosUsuarios(TiendaVirtualContext context)
        {
            _context = context;
        }

        public async Task<RepuestasServidorGenericas<FormasPagosUsuario>> ObtenerFormasPagosPorUsuarioID(int usuarioID)
        {
            var Respuesta = new RepuestasServidorGenericas<FormasPagosUsuario>(new FormasPagosUsuario() { }, new List<FormasPagosUsuario>() { }, true, null);

            try
            {
                if (usuarioID != null) {
                var FormasPagosUsuario = await  _context.FormasPagosUsuarios.Where(formaPago => formaPago.UsuarioId == usuarioID).ToListAsync();
                    if (FormasPagosUsuario.Count() > 0)
                    {
                        Respuesta = new RepuestasServidorGenericas<FormasPagosUsuario>(new FormasPagosUsuario() { }, FormasPagosUsuario, true);
                    }
                    else
                    {
                        Respuesta = new RepuestasServidorGenericas<FormasPagosUsuario>(new FormasPagosUsuario() { }, new List<FormasPagosUsuario>() { }, true,"No existen formas de pagos para este usuario");
                    }
                }
            }catch(Exception e)
            {
                Respuesta = new RepuestasServidorGenericas<FormasPagosUsuario>(new FormasPagosUsuario() { }, new List<FormasPagosUsuario>() { }, false, e.Message);
            }
            return Respuesta;
        }
        public async Task<RepuestasServidorGenericas<FormasPagosUsuario>> ActualizarFormasPagosPorUsuarioID(FormasPagosUsuario FormaPago)
        {
            var Respuesta = new RepuestasServidorGenericas<FormasPagosUsuario>(new FormasPagosUsuario() { }, new List<FormasPagosUsuario>() { }, true, null);

            try
            {
                if (FormaPago != null)
                {
                    var FormasPagosUsuario = await _context.FormasPagosUsuarios.Where(formaPago => formaPago.FormaPagoId == FormaPago.FormaPagoId).ToListAsync();
                    if (FormasPagosUsuario.Count() > 0)
                    {
                        _context.Entry(FormaPago).State = EntityState.Modified;
                        _context.SaveChangesAsync();

                        Respuesta = new RepuestasServidorGenericas<FormasPagosUsuario>(FormaPago, new List<FormasPagosUsuario>(), true);
                    }
                    else
                    {
                        Respuesta = new RepuestasServidorGenericas<FormasPagosUsuario>(new FormasPagosUsuario() { }, new List<FormasPagosUsuario>() { }, true, "No existen formas de pagos que desea actualizar");
                    }
                }
            }
            catch (Exception e)
            {
                Respuesta = new RepuestasServidorGenericas<FormasPagosUsuario>(new FormasPagosUsuario() { }, new List<FormasPagosUsuario>() { }, false, e.Message);
            }
            return Respuesta;
        }
        public async Task<RepuestasServidorGenericas<FormasPagosUsuario>> AgregarFormasPagosPorUsuarioID(FormasPagosUsuario FormaPago)
        {
            var Respuesta = new RepuestasServidorGenericas<FormasPagosUsuario>(new FormasPagosUsuario() { }, new List<FormasPagosUsuario>() { }, true, null);

            try
            {
                if (FormaPago != null)
                {
                    var FormasPagosUsuario = await _context.FormasPagosUsuarios.Where(formaPago => formaPago.FormaPagoId == FormaPago.FormaPagoId).ToListAsync();
                    if (FormasPagosUsuario.Count() > 0)
                    {
                        _context.Add(FormaPago).State = EntityState.Modified;
                        await _context.SaveChangesAsync();

                        Respuesta = new RepuestasServidorGenericas<FormasPagosUsuario>(FormaPago, new List<FormasPagosUsuario>(), true);
                    }
                    else
                    {
                        Respuesta = new RepuestasServidorGenericas<FormasPagosUsuario>(new FormasPagosUsuario() { }, new List<FormasPagosUsuario>() { }, true, "No existen formas de pagos que desea actualizar");
                    }
                }
            }
            catch (Exception e)
            {
                Respuesta = new RepuestasServidorGenericas<FormasPagosUsuario>(new FormasPagosUsuario() { }, new List<FormasPagosUsuario>() { }, false, e.Message);
            }
            return Respuesta;
        }
        public async Task<RepuestasServidorGenericas<FormasPagosUsuario>> EliminarFormasPagosPorUsuarioID(int FormaPagoID)
        {
            var Respuesta = new RepuestasServidorGenericas<FormasPagosUsuario>(new FormasPagosUsuario() { }, new List<FormasPagosUsuario>() { }, true, null);

            try
            {
                if (FormaPagoID != null)
                {
                    if (_context.FormasPagosUsuarios.Where(formaPago => formaPago.FormaPagoId == FormaPagoID).Count() > 0)
                    {

                        var FormaPago = await _context.FormasPagosUsuarios.FindAsync(FormaPagoID);
                       

                        _context.FormasPagosUsuarios.Remove(FormaPago);
                        await _context.SaveChangesAsync();

                        Respuesta = new RepuestasServidorGenericas<FormasPagosUsuario>(FormaPago, new List<FormasPagosUsuario>(), true);
                    }
                    else
                    {
                        Respuesta = new RepuestasServidorGenericas<FormasPagosUsuario>(new FormasPagosUsuario() { }, new List<FormasPagosUsuario>() { }, true, "No existen formas de pagos que desea eliminar");
                    }
                }
            }
            catch (Exception e)
            {
                Respuesta = new RepuestasServidorGenericas<FormasPagosUsuario>(new FormasPagosUsuario() { }, new List<FormasPagosUsuario>() { }, false, e.Message);
            }
            return Respuesta;
        }

    }
}
