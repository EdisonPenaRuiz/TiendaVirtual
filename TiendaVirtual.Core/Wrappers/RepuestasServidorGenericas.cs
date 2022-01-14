using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVirtual.Core.Wrappers
{
    public class RepuestasServidorGenericas<T>
    {
        public RepuestasServidorGenericas(T resultado,List<T> listadoResultado, bool operacionExitosa, string errores=null)
        {
            OperacionExitosa = operacionExitosa;
            ResultadoEspecifico = resultado;
            ListadoResultados = listadoResultado;
            Error = errores;
        }
        
        public bool OperacionExitosa { get; set; }
        public string Error { get; set; }
        public List<T> ListadoResultados { get; set; }
        public T ResultadoEspecifico { get; set; }
    }
}
