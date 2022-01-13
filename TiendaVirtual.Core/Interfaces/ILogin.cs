using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtual.Core.Entities;
using TiendaVirtual.Core.Wrappers;

namespace TiendaVirtual.Core.Interfaces
{
    public interface ILogin
    {
        Task<RepuestasServidorGenericas<Usuario>> LoginUsuario(string NombreUsuario, string Contrasena);

    }
}
