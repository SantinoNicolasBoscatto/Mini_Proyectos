using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokevatos
{
    class PokemonNegocio
    {
        
        //Vamos a Hacer una funcion que lea registros de la BD
        public List<Pokemon> Listar()
        {
            List<Pokemon> listapokemon = new List<Pokemon>();
            SqlConnection conexionSql = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            try
            {
                conexionSql.ConnectionString = "server=.\\SQLEXPRESS01; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Nombre, Numero, P.Descripcion, UrlImagen, E.Descripcion, D.Descripcion  from POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.id = P.idtipo AND D.Id = P.IdDebilidad";
                comando.Connection = conexionSql;
                conexionSql.Open();
                reader =comando.ExecuteReader();

                while (reader.Read())
                {
                    Pokemon auxiliar = new Pokemon(reader.GetString(4), reader.GetString(5));
                    auxiliar.NumeroPokedex = reader.GetInt32(1);
                    auxiliar.Nombre = reader.GetString(0);
                    auxiliar.Descripcion = (string)reader["Descripcion"];
                    auxiliar.Imagen = (string)reader["UrlImagen"];
                    //auxiliar.Tipo = new Elemento();
                    //auxiliar.Tipo.Descripcion = reader.GetString(4);
                    //auxiliar.Debilidad = new Elemento();
                    //auxiliar.Debilidad.Descripcion = reader.GetString(5);
                    listapokemon.Add(auxiliar);
                }
                return listapokemon;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexionSql.Close();
            }
            
        }
    }
}
