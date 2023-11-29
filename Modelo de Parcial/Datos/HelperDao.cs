using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace Modelo_de_Parcial.Datos
{
    public class HelperDao
    {
        private SqlConnection conexion;

        private string cadenaCOnexion = Properties.Resources.cadenaDeConexion;

        public HelperDao()
        {
            conexion = new SqlConnection(cadenaCOnexion);
        }

        //PATRON SINGLETON
        private static HelperDao instancia;

        public static HelperDao ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new HelperDao();
            }
            return instancia;
        }

        //METODOS PROPIOS DEL HELPERDAO 
        public SqlConnection ObtenerConexion() //Es un metodo que se usa para obtener la cadena de coneccion casi como una prop
        {
            return this.conexion;
        }

        public void Conectar()
        {
            conexion.Open();
        }

        public void Desconectar()
        {
            conexion.Close();
        }

        public int ObtenerUltimaOrden(string nombreSp,string NomParametro)
        {
            int aux = 0;
            Conectar();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSp;
            SqlParameter parameter = new SqlParameter(NomParametro, SqlDbType.Int);
            parameter.Direction = ParameterDirection.Output;
            comando.Parameters.Add(parameter);
            comando.ExecuteNonQuery();
            Desconectar();
            aux = (int)parameter.Value;
            return aux; 
        }

        public DataTable Consultar(string nomSp)
        {
            Conectar();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nomSp;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            
            Desconectar();

            return tabla;
        }

        public DataTable Consultar(string nom, List<Parametro> lparametros)
        {
            Conectar();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            foreach (Parametro p in lparametros)
            {
                comando.Parameters.AddWithValue(p.Nombre, p.Valor);
            }
            comando.CommandText= nom;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            Desconectar();

            return tabla;
        }
    }
}
