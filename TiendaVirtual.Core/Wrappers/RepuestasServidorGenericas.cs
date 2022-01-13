using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVirtual.Core.Wrappers
{
    public class RepuestasServidorGenericas<T>
    {
        public RepuestasServidorGenericas(T data, bool operacionExitosa, string errores)
        {
            OperacionExitosa = operacionExitosa;
            Data = data;
            Error = errores;
        }
        
        public bool OperacionExitosa { get; set; }
        public string Error { get; set; }
        public T Data { get; set; }
    }
}
