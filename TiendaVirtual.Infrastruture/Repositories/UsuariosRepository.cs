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

        public async Task<RepuestasServidorGenericas<Usuario>> AgregarUsuario(Usuario usuario)
        {
            var Respuesta = new RepuestasServidorGenericas<Usuario>(new Usuario() { }, new List<Usuario>() { }, true) { };
            try
            {
                //Verificamos si ya existe un usuario con las credenciales introducidas
                
                if (_context.Usuarios.Where(usuario => usuario.NombreUsuario==usuario.NombreUsuario).Count() == 0) {
                  _context.Usuarios.Add(usuario);
                  await _context.SaveChangesAsync();
                    Respuesta = new RepuestasServidorGenericas<Usuario>(usuario, new List<Usuario>() { }, true);
                
                } else if (_context.Usuarios.Where(usuario => usuario.NombreUsuario == usuario.NombreUsuario).Count() > 0) 
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
