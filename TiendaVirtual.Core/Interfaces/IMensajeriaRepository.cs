using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtual.Core.Entities;
using TiendaVirtual.Core.Wrappers;

namespace TiendaVirtual.Core.Interfaces
{
    public interface IMensajeriaRepository
    {
        public Task<RepuestasServidorGenericas<Mensaje>> ObtenerTodosLosMensajesUsuario(int usuarioID);

        public Task<RepuestasServidorGenericas<Mensaje>> ObtenerTodosLosMensajesUsuariosEpecificos(Mensaje usuariosMensajes);
    }
}
