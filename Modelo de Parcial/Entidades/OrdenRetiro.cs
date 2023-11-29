using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_Parcial.Entidades
{
    public class OrdenRetiro
    {
        public int NroOrden { get; set; }
        public DateTime Fecha { get; set; }
        public string Responsable { get; set; }
        public List<DetalleDeOrden> ListaDetalles { get; set; }

        public OrdenRetiro()
        {
            NroOrden = 0;
            Fecha = DateTime.Now;
            Responsable = string.Empty;
            ListaDetalles = new List<DetalleDeOrden>();
        }

        public OrdenRetiro(int nro,DateTime fecha , string resp )
        {
            NroOrden = nro;
            Fecha = fecha;
            Responsable = resp;
            ListaDetalles = new List<DetalleDeOrden>();
        }

        public void AgregarDetalle(DetalleDeOrden detalle)
        {
            ListaDetalles.Add(detalle);
        }

        public void QuitarDetalle(int nroDetalle)
        {
            ListaDetalles.RemoveAt(nroDetalle);
        }
    }
}
