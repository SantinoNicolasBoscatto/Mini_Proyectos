using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoABaseDeDatos
    {
        public AccesoABaseDeDatos()
        {
            this.conexionBaseDatos = new SqlConnection("server=.\\SQLEXPRESS01; database=POKEDEX_DB; integrated security=true");
            this.comandoDeSQL = new SqlCommand();
        }
        private SqlConnection conexionBaseDatos;
        private SqlCommand comandoDeSQL;
        private SqlDataReader guardadorDeDatos;
        //Con esta Propiedad tengo la posibilidad de leer los datos que tenga
        // el guardador de datos (lo que encuentre en mi SQLDatbase).
        public SqlDataReader GuardadorDeDatos
        {
            get { return guardadorDeDatos; }
        }

        public void QuerySQL(string query)
        {
            comandoDeSQL.CommandType = System.Data.CommandType.Text;
            comandoDeSQL.CommandText = query;
        }

        public void EjecutarLectura()
        {
            try
            {
                comandoDeSQL.Connection = conexionBaseDatos;
                conexionBaseDatos.Open();
               guardadorDeDatos = comandoDeSQL.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public void EjecutarAccion()
        {
            try
            {
                comandoDeSQL.Connection = conexionBaseDatos;
                conexionBaseDatos.Open();
                comandoDeSQL.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            comandoDeSQL.Parameters.AddWithValue(nombre, valor);
        }

        public void CerrarConexion()
        {
            if (guardadorDeDatos!=null )
            {
                guardadorDeDatos.Close();
                conexionBaseDatos.Close();
            }
        }
    }
}
