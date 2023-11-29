using Modelo_de_Parcial.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_Parcial.Servicios
{
    internal class FactoryServicioImp : FactoryServicio
    {
        public override IServicio CrearSerivicio()
        {
            return new Servicios.Implementacion.Servicio();
        }
    }
}
