using Modelo_de_Parcial.Datos;
using Modelo_de_Parcial.Datos.Implementacion;
using Modelo_de_Parcial.Datos.Interfaz;
using Modelo_de_Parcial.Entidades;
using Modelo_de_Parcial.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_Parcial.Servicios.Implementacion
{
    internal class Servicio : IServicio
    {
        IOrdenesDao ordenesDao;

        public Servicio()
        {
            ordenesDao = new OrdenesDao();
        }
        public bool ActualizarOrden(OrdenRetiro ordenRetiro)
        {
            throw new NotImplementedException();
        }

        public bool BorrarOrden(int nroOrden)
        {
            throw new NotImplementedException();
        }

        public bool ConfirmarOrden(OrdenRetiro ordenRetiro)
        {
            throw new NotImplementedException();
        }

        public int ObtenerNroProxCarga()
        {
            throw new NotImplementedException();
        }

        public List<Material> TraerMateriales()
        {
            return ordenesDao.TraerMateriales();
        }

        public OrdenRetiro TraerOrden(int nroOrden)
        {
            throw new NotImplementedException();
        }

        public List<OrdenRetiro> TraerOrdenes(List<Parametro> lParams, string comandoSP)
        {
            throw new NotImplementedException();
        }
    }
}
