using Modelo_de_Parcial.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_Parcial.Servicios
{
    public abstract class FactoryServicio
    {
        public abstract IServicio CrearSerivicio();
    }
}
