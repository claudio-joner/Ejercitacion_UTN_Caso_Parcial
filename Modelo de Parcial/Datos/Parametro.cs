using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_Parcial.Datos
{
    public class Parametro
    {
        public string Nombre { get; set; }
        public object Valor { get; set; }

        public Parametro()
        {
            Nombre = string.Empty;
            Valor = null;
        }

        public Parametro(string nom, object val)
        {
            Nombre = nom;
            Valor = val;
        }
    }
}
