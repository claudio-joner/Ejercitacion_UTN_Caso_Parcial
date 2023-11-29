using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_Parcial.Entidades
{
    public class Material
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public int Stock { get; set; }

        public Material()
        {
            Codigo = 0;
            Nombre = string.Empty;
            Stock = 0;
        }

        public Material(int cod, string nom, int stock)
        {
            Codigo = cod;
            Nombre = nom;
            Stock = stock;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
