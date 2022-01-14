using System;
using System.Collections.Generic;
using System.Linq;

using TiendaVirtual.Core.Entities;
using TiendaVirtual.Core.Interfaces;
using TiendaVirtual.Infrastruture.Data;
using Microsoft.EntityFrameworkCore;
using TiendaVirtual.Core.Wrappers;

namespace TiendaVirtual.Infrastruture.Repositories
{
    public class LoginRepository:ILoginRepository
    {
        readonly TiendaVirtualContext _context;

        public LoginRepository(TiendaVirtualContext context)
        {
            _context = context;
        }

       public async Task<RepuestasServidorGenericas<Usuario>> LoginUsuario(string NombreUsuario, string Contrasena)
       {
            var Repuesta = new RepuestasServidorGenericas<Usuario>(new Usuario() { },true,null) { };
            try
            {
                var usuarioLoguin = await _context.Usuarios.Where(x => x.NombreUsuario == NombreUsuario && x.Contrasena == Contrasena).ToListAsync();
            
                if (usuarioLoguin.Count() > 1)
                {
                    Repuesta = new RepuestasServidorGenericas<Usuario>(new Usuario() { },true, "Existe mas de un usuario con las credenciales introducidas");

                }else if(usuarioLoguin.Count() == 1) {
                    Repuesta = new RepuestasServidorGenericas<Usuario>(usuarioLoguin[0], true, null);
                }else if (usuarioLoguin.Count()==0)
                {
                    Repuesta = new RepuestasServidorGenericas<Usuario>(new Usuario() { }, true, "No existen usuarios con las credenciales introducidas"); ;
                }
            }
            catch (Exception e)
            {
                return new RepuestasServidorGenericas<Usuario>(new Usuario() { }, false, e.Message);
            }

            return Repuesta;
       }
       
    }

   
}
