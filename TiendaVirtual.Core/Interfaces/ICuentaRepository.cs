using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtual.Core.Entities;
using TiendaVirtual.Core.Wrappers;

namespace TiendaVirtual.Core.Interfaces
{
    public interface ICuentaRepository
    {
        public Task<RepuestasServidorGenericas<Cuenta>> ObtenerCuentaPorUsuarioID(int UsuarioID);

        public Task<RepuestasServidorGenericas<Cuenta>> AgregarCuenta(Cuenta cuenta);

        public Task<RepuestasServidorGenericas<Cuenta>> ActualizarCuenta(Cuenta cuenta);

        public Task<RepuestasServidorGenericas<Cuenta>> EliminarCuenta(int CuentaID);
    }
}
