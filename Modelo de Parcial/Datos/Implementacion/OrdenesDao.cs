using Modelo_de_Parcial.Datos.Interfaz;
using Modelo_de_Parcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_Parcial.Datos.Implementacion
{
    internal class OrdenesDao : IOrdenesDao
    {
        public bool ActualizarOrden(OrdenRetiro orden)
        {
            throw new NotImplementedException();
        }

        public bool BorrarOrden(int nroOrden)
        {
            throw new NotImplementedException();
        }

        public bool ConfirmarOrden(OrdenRetiro orden)
        {
            bool aux = true;
            SqlTransaction transaction = null;
            SqlConnection conexion = HelperDao.ObtenerInstancia().ObtenerConexion();
            try
            {
                conexion.Open();
                transaction = conexion.BeginTransaction();
                SqlCommand comando = new SqlCommand("SP_INSERTAR_ORDEN",conexion,transaction);
                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter parametro = new SqlParameter("@prox_orden",SqlDbType.Int);
                parametro.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametro);
                comando.Parameters.AddWithValue("@fecha_orden", orden.Fecha);
                comando.Parameters.AddWithValue("@responsable", orden.Responsable);
                comando.ExecuteNonQuery();

                int nroOrden = (int)parametro.Value;
                int i = 1;

                foreach (DetalleDeOrden d in orden.ListaDetalles)
                {
                    SqlCommand comandoOrden = new SqlCommand("SP_INSERTAR_DETALLE",conexion,transaction);
                    comandoOrden.CommandType = CommandType.StoredProcedure;
                    comandoOrden.Parameters.AddWithValue("@id_detalle", i);
                    comandoOrden.Parameters.AddWithValue("@id_orden", nroOrden);
                    comandoOrden.Parameters.AddWithValue("@material", d.Material.Codigo);
                    comandoOrden.Parameters.AddWithValue("@cantidad", d.Cantidad);
                    comandoOrden.ExecuteNonQuery();

                    i++;
                }

                transaction.Commit();

            }
            catch
            {
                if (transaction != null) 
                {
                    transaction.Rollback();
                    aux = false; 
                } 
            }
            finally
            {
                if(conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return aux;
        }

        public int ObterneProximaOrden()
        {
            throw new NotImplementedException();
        }

        public List<Material> TraerMateriales()
        {
            List<Material> lMateriales = new List<Material>();
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_MATERIALES");
            foreach (DataRow r in tabla.Rows)
            {
                int id = int.Parse(r["id_material"].ToString());
                string nom = r["nom_material"].ToString();
                int stock = int.Parse(r["stock_material"].ToString());
                Material m = new Material(id, nom, stock);
                lMateriales.Add(m);
            }
            return lMateriales;
        }

        public List<OrdenRetiro> TraerOrdenes(List<Parametro> lParams, string nombreSP)
        {
            throw new NotImplementedException();
        }

        public OrdenRetiro TraerOrdenNumero(int numero)
        {
            throw new NotImplementedException();
        }
    }
}
