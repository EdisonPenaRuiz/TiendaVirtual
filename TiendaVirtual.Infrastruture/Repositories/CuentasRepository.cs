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
    public class CuentasRepository : ICuentaRepository
    {
        readonly TiendaVirtualContext _context;
        public CuentasRepository(TiendaVirtualContext context)
        {
            _context = context;
        }

        public async Task<RepuestasServidorGenericas<Cuenta>> ObtenerCuentaPorUsuarioID(int UsuarioID)
        {
            var Respuesta = new RepuestasServidorGenericas<Cuenta>(new Cuenta() { }, new List<Cuenta>() { }, false);
            try
            {
                var Cuenta = await _context.Cuentas.Where(cuenta => cuenta.UsuarioId == UsuarioID).ToListAsync();
                Respuesta = new RepuestasServidorGenericas<Cuenta>(new Cuenta() { }, Cuenta, true);
            }
            catch (Exception e)
            {
                Respuesta = new RepuestasServidorGenericas<Cuenta>(new Cuenta() { }, new List<Cuenta>() { }, false, e.Message);
            }

            return Respuesta;
        }
       
        public async Task<RepuestasServidorGenericas<Cuenta>> AgregarCuenta(Cuenta cuenta)
        {
            var Respuesta = new RepuestasServidorGenericas<Cuenta>(new Cuenta() { }, new List<Cuenta>() { }, false);
            try
            {
                _context.AddAsync(cuenta);
                await _context.SaveChangesAsync();
                Respuesta = new RepuestasServidorGenericas<Cuenta>(cuenta, new List<Cuenta>() { }, true);
            }
            catch (Exception e)
            {
                Respuesta = new RepuestasServidorGenericas<Cuenta>(new Cuenta() { }, new List<Cuenta>() { }, false, e.Message);
            }

            return Respuesta;
        }

        public async Task<RepuestasServidorGenericas<Cuenta>> ActualizarCuenta(Cuenta cuenta)
        {
            var Respuesta = new RepuestasServidorGenericas<Cuenta>(new Cuenta() { }, new List<Cuenta>() { }, false);
            try
            {
                if (_context.Cuentas.Where(cuenta => cuenta.CuentaId == cuenta.CuentaId).Count() > 0)
                {
                    _context.Entry(cuenta).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    Respuesta = new RepuestasServidorGenericas<Cuenta>(cuenta, new List<Cuenta>() { }, true);

                }
                else
                {
                    Respuesta = new RepuestasServidorGenericas<Cuenta>(new Cuenta() { }, new List<Cuenta>() { }, false, "No existe la cuenta que desea actualizar");
                }

            }
            catch (Exception e)
            {
                Respuesta = new RepuestasServidorGenericas<Cuenta>(new Cuenta() { }, new List<Cuenta>() { }, false, e.Message);
            }

            return Respuesta;
        }

        public async Task<RepuestasServidorGenericas<Cuenta>> EliminarCuenta(int CuentaID)
        {
            var Respuesta = new RepuestasServidorGenericas<Cuenta>(new Cuenta() { }, new List<Cuenta>() { }, false);
            try
            {
                if (CuentaID != null)
                {
                    var cuenta = await _context.Cuentas.FindAsync(CuentaID);

                    if (cuenta != null)
                    {
                        _context.Cuentas.Remove(cuenta);
                        await _context.SaveChangesAsync();
                        Respuesta = new RepuestasServidorGenericas<Cuenta>(new Cuenta() { }, new List<Cuenta>() { }, true);

                    }
                    else
                    {
                        Respuesta = new RepuestasServidorGenericas<Cuenta>(new Cuenta() { }, new List<Cuenta>() { }, false, "No existe la cuenta que desea eliminar!");

                    }
                }
                else
                {
                    Respuesta = new RepuestasServidorGenericas<Cuenta>(new Cuenta() { }, new List<Cuenta>() { }, false, "La cuenta que ha intentado eliminar no es valido");
                }

            }
            catch (Exception e)
            {
                Respuesta = new RepuestasServidorGenericas<Cuenta>(new Cuenta() { }, new List<Cuenta>() { }, false, e.Message);
            }

            return Respuesta;
        }


    }
}
