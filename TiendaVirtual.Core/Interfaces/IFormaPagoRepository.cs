using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtual.Core.Entities;
using TiendaVirtual.Core.Wrappers;

namespace TiendaVirtual.Core.Interfaces
{
    public interface IFormasPagosUsuarioRepository
    {
        public Task<RepuestasServidorGenericas<FormasPagosUsuario>> ObtenerFormasPagosPorUsuarioID(int usuarioID);

        public Task<RepuestasServidorGenericas<FormasPagosUsuario>> ActualizarFormasPagosPorUsuarioID(FormasPagosUsuario FormaPago);

        public Task<RepuestasServidorGenericas<FormasPagosUsuario>> AgregarFormasPagosPorUsuarioID(FormasPagosUsuario FormaPago);

        public Task<RepuestasServidorGenericas<FormasPagosUsuario>> EliminarFormasPagosPorUsuarioID(int FormaPagoID);

    }
}
