using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_Parcial.Entidades
{
    public class DetalleDeOrden
    {
        public int idDetalle { get; set; }
        public Material Material { get; set; }
        public int Cantidad { get; set; }

        public DetalleDeOrden()
        {
            idDetalle = 0;
            Material = new Material();
            Cantidad = 0;
        }

        public DetalleDeOrden(int id,Material mat, int cant)
        {
            idDetalle = id;
            Material = mat;
            Cantidad = cant;
        }

        public override string ToString()
        {
            return idDetalle + "-" + Material.Nombre;
        }
    }
}
