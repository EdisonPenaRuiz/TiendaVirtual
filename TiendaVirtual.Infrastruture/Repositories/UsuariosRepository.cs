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
    public class UsuariosRepository:IUsuariosRepository
    {
        readonly TiendaVirtualContext _context;

        public UsuariosRepository(TiendaVirtualContext context)
        {
            _context = context;
        }

        public async Task<RepuestasServidorGenericas<Usuario>> AgregarUsuario(Usuario usuarioEnviado)
        {
            var Respuesta = new RepuestasServidorGenericas<Usuario>(new Usuario() { }, new List<Usuario>() { }, true) { };
            try
            {
                //Verificamos si ya existe un usuario con las credenciales introducidas
                
                if (_context.Usuarios.Where(usuario => usuario.NombreUsuario== usuarioEnviado.NombreUsuario).Count() == 0) {
                    var NuevoUsuarioID = _context.Usuarios.Select(usuario => usuario.UsuarioId).Max() + 1;

                    //Agregando nuevo usuarioID a nuevo usuario 

                    usuarioEnviado.UsuarioId = NuevoUsuarioID;

                    _context.Usuarios.Add(usuarioEnviado);
                  await _context.SaveChangesAsync();
                    Respuesta = new RepuestasServidorGenericas<Usuario>(usuarioEnviado, new List<Usuario>() { }, true);
                
                } else if (_context.Usuarios.Where(usuario => usuario.NombreUsuario == usuarioEnviado.NombreUsuario).Count() > 0) 
                {
                    Respuesta = new RepuestasServidorGenericas<Usuario>(new Usuario() { },new List<Usuario>() { }, true, "Ya existe un usuario con el nombre de usuario introducido");
                }

            }
            catch (DbUpdateException DbE)
            {
                Respuesta = new RepuestasServidorGenericas<Usuario>(new Usuario() { }, new List<Usuario>() { }, false,DbE.Message);
            }
            return Respuesta;
         }

        

    }
}
