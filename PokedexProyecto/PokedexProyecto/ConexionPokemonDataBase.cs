using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PokedexProyecto
{
    class ConexionPokemonDataBase
    {
        SqlConnection conexionBD = new SqlConnection();
        SqlCommand comandoInstrucciones = new SqlCommand();
        SqlDataReader guardadorDeDatos;
        List<Pokemon> listaDePokemones = new List<Pokemon>();
        
        private List<Pokemon> Listar()
        {
            conexionBD.ConnectionString = "server=.\\SQLEXPRESS01; database=POKEDEX_DB; integrated security=true";
            comandoInstrucciones.CommandType = System.Data.CommandType.Text;
            comandoInstrucciones.CommandText = "";
            comandoInstrucciones.Connection = conexionBD;
            conexionBD.Open();
            guardadorDeDatos =  comandoInstrucciones.ExecuteReader();
            while (guardadorDeDatos.Read())
            {
                Pokemon auxiliar = new Pokemon();
            }
        }
    }
}
