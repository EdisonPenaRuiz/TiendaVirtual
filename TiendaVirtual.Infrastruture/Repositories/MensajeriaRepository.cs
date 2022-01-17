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
    public class MensajeriaRepository : IMensajeriaRepository
    {
        readonly TiendaVirtualContext _context;
        public MensajeriaRepository(TiendaVirtualContext context)
        {
            _context = context;
        }

        public async Task<RepuestasServidorGenericas<Mensaje>> ObtenerTodosLosMensajesUsuario(int usuarioID)
        {
            var Respuesta = new RepuestasServidorGenericas<Mensaje>(new Mensaje() { },new List<Mensaje>() { },false);
            try
            {
              List<Mensaje> listadoMensaje =  await _context.Mensajes.Where(mensaje => mensaje.UsuarioIddestino == usuarioID || mensaje.UsuarioIdorigen == usuarioID).ToListAsync();
                Respuesta = new RepuestasServidorGenericas<Mensaje>(new Mensaje() { }, listadoMensaje, true);
            }
            catch (Exception e)
            {
                Respuesta = new RepuestasServidorGenericas<Mensaje>(new Mensaje() { }, new List<Mensaje>() { }, false, e.Message.ToString());
            }
            return Respuesta;
        }

        public async Task<RepuestasServidorGenericas<Mensaje>> ObtenerTodosLosMensajesUsuariosEpecificos(Mensaje usuariosMensajes)
        {
            var Respuesta = new RepuestasServidorGenericas<Mensaje>(new Mensaje() { }, new List<Mensaje>() { }, false);
            try
            {
                List<Mensaje> listadoMensaje = await _context.Mensajes.Where(mensaje => mensaje.UsuarioIddestino == usuariosMensajes.UsuarioIddestino || mensaje.UsuarioIdorigen == mensaje.UsuarioIddestino || mensaje.UsuarioIdorigen == usuariosMensajes.UsuarioIdorigen || mensaje.UsuarioIddestino == mensaje.UsuarioIddestino).ToListAsync();
                Respuesta = new RepuestasServidorGenericas<Mensaje>(new Mensaje() { }, listadoMensaje, true);
            }
            catch (Exception e)
            {
                Respuesta = new RepuestasServidorGenericas<Mensaje>(new Mensaje() { }, new List<Mensaje>() { }, false, e.Message.ToString());
            }
            return Respuesta;
        }
    }
}
