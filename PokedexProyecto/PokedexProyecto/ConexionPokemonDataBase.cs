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
        public List<Pokemon> Listar()
        {
            SqlConnection conexionBD = new SqlConnection();
            SqlCommand comandoInstrucciones = new SqlCommand();
            SqlDataReader guardadorDeDatos;
            List<Pokemon> listaDePokemones = new List<Pokemon>();
            try
            {
                conexionBD.ConnectionString = "server=.\\SQLEXPRESS01; database=POKEDEX_DB; integrated security=true";
                comandoInstrucciones.CommandType = System.Data.CommandType.Text;
                comandoInstrucciones.CommandText = "select Numero, Nombre, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, Ataque Ataque, Defensa,HP, AtaqueEspecial, DefensaEspecial, Velocidad, Imagen3d, EntradaPokedex from POKEMONS P, ELEMENTOS E, ELEMENTOS D where IdDebilidad = D.Id AND IdTipo = E.Id Order BY Numero";
                comandoInstrucciones.Connection = conexionBD;
                conexionBD.Open();
                guardadorDeDatos = comandoInstrucciones.ExecuteReader();
                while (guardadorDeDatos.Read())
                {

                    Pokemon auxiliar = new Pokemon();
                    auxiliar.NumeroPokedex = (int)guardadorDeDatos["Numero"];
                    auxiliar.Nombre = (string)guardadorDeDatos["Nombre"];
                    auxiliar.Sprite = (string)guardadorDeDatos["UrlImagen"];
                    auxiliar.TipoDeElemento.TipoPokemon = (string)guardadorDeDatos["Tipo"];
                    auxiliar.Debilidad.TipoPokemon = (string)guardadorDeDatos["Debilidad"];
                    auxiliar.EstadisticasBase.HP = (int)guardadorDeDatos["HP"];
                    auxiliar.EstadisticasBase.Ataque = (int)guardadorDeDatos["Ataque"];
                    auxiliar.EstadisticasBase.Defensa = (int)guardadorDeDatos["Defensa"];
                    auxiliar.EstadisticasBase.AtaqueEspecial = (int)guardadorDeDatos["AtaqueEspecial"];
                    auxiliar.EstadisticasBase.DefensaEspecial = (int)guardadorDeDatos["DefensaEspecial"];
                    auxiliar.EstadisticasBase.Velocidad = (int)guardadorDeDatos["Velocidad"];
                    auxiliar.Sprite3d = (string)guardadorDeDatos["Imagen3d"];
                    auxiliar.DescripcionDePokemon = (string)guardadorDeDatos["EntradaPokedex"];
                    listaDePokemones.Add(auxiliar);
                    
                }
                return listaDePokemones;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexionBD.Close();
            }
        }
    }
}
