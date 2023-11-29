using Modelo_de_Parcial.Datos;
using Modelo_de_Parcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_Parcial.Servicios.Interfaz
{
    public interface IServicio
    {
        int ObtenerNroProxCarga();
        List<Material> TraerMateriales();
        OrdenRetiro TraerOrden(int nroOrden);
        List<OrdenRetiro> TraerOrdenes(List<Parametro> lParams, string comandoSP);
        bool ConfirmarOrden(OrdenRetiro ordenRetiro);
        bool ActualizarOrden(OrdenRetiro ordenRetiro);
        bool BorrarOrden(int nroOrden);
    }
}
