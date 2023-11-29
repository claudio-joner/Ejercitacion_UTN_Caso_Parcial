using Modelo_de_Parcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_Parcial.Datos.Interfaz
{
    internal interface IOrdenesDao
    {
        int ObterneProximaOrden();
        bool ConfirmarOrden(OrdenRetiro orden);

        OrdenRetiro TraerOrdenNumero(int numero);
        bool ActualizarOrden(OrdenRetiro orden);

        bool BorrarOrden(int nroOrden);
        List<OrdenRetiro> TraerOrdenes(List<Parametro> lParams, string nombreSP);
        List<Material> TraerMateriales();
    }
}
