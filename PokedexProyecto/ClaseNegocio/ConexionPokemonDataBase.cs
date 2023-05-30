using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ModeloDeDominio;

namespace ClaseNegocio
{
    public class ConexionPokemonDataBase
    {
        public List<Pokemon> ListarPokemon()
        {
            ConexionDBCentralizada ConexionCentral = new ConexionDBCentralizada();
            List<Pokemon> listaDePokemones = new List<Pokemon>();
            try
            {
                ConexionCentral.SQLQuery("select Numero, Nombre, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, Ataque Ataque, Defensa,HP, AtaqueEspecial, DefensaEspecial, Velocidad, Imagen3d, EntradaPokedex, Sonidos from POKEMONS P, ELEMENTOS E, ELEMENTOS D where IdDebilidad = D.Id AND IdTipo = E.Id Order BY Numero");
                ConexionCentral.EjecutarLecturaDeTabla();               
                while (ConexionCentral.GuardadorCentralDeDatosSQLAcceso.Read())
                {
                    Pokemon auxiliar = new Pokemon();
                    auxiliar.NumeroPokedex = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Numero"];
                    auxiliar.Nombre = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Nombre"];
                    if(!(ConexionCentral.GuardadorCentralDeDatosSQLAcceso["UrlImagen"] is DBNull))
                    auxiliar.Sprite = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["UrlImagen"];
                    if (!(ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Tipo"] is DBNull))
                        auxiliar.TipoDeElemento.TipoPokemon = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Tipo"];
                    if (!(ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Debilidad"] is DBNull))
                        auxiliar.Debilidad.TipoPokemon = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Debilidad"];
                    if (!(ConexionCentral.GuardadorCentralDeDatosSQLAcceso["HP"] is DBNull))
                    {
                        auxiliar.EstadisticasBase.HP = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["HP"];
                        auxiliar.EstadisticasBase.Ataque = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Ataque"];
                        auxiliar.EstadisticasBase.Defensa = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Defensa"];
                        auxiliar.EstadisticasBase.AtaqueEspecial = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["AtaqueEspecial"];
                        auxiliar.EstadisticasBase.DefensaEspecial = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["DefensaEspecial"];
                        auxiliar.EstadisticasBase.Velocidad = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Velocidad"];
                    }
                    if (!(ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Imagen3d"] is DBNull))
                       auxiliar.Sprite3d = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Imagen3d"];
                    if (!(ConexionCentral.GuardadorCentralDeDatosSQLAcceso["EntradaPokedex"] is DBNull))
                        auxiliar.DescripcionDePokemon = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["EntradaPokedex"];
                    if (!(ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Sonidos"] is DBNull))
                        auxiliar.GritoPokemon = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Sonidos"];
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
                ConexionCentral.CerrarConexion();
            }
        }

        public void AgregarPokemon(Pokemon nuevoPokemon)
        {
            ConexionDBCentralizada ConexionBase = new ConexionDBCentralizada();
            try
            {
                ConexionBase.SQLQuery("Insert Into POKEMONS(Numero, Nombre, EntradaPokedex, Activo, IdDebilidad, IdTipo, UrlImagen, HP, Ataque, Defensa, AtaqueEspecial, DefensaEspecial, Velocidad, Imagen3d, Sonidos) values(@Numero, @Nombre, @EntradaPokedex, 1, @IdTipo, @IdDebilidad, @UrlImagen, @HP, @Ataque, @Defensa, @AtaqueEsp, @DefensaEsp, @Velocidad, @Imagen3d, @Grito)");
                ConexionBase.SetearParametrosSQL("@Numero", nuevoPokemon.NumeroPokedex);
                ConexionBase.SetearParametrosSQL("@Nombre", nuevoPokemon.Nombre);
                ConexionBase.SetearParametrosSQL("@EntradaPokedex", nuevoPokemon.DescripcionDePokemon);
                ConexionBase.SetearParametrosSQL("@IdDebilidad", nuevoPokemon.Debilidad.Id);
                ConexionBase.SetearParametrosSQL("@IdTipo", nuevoPokemon.TipoDeElemento.Id);
                ConexionBase.SetearParametrosSQL("@UrlImagen", nuevoPokemon.Sprite);
                ConexionBase.SetearParametrosSQL("@HP", nuevoPokemon.EstadisticasBase.HP);
                ConexionBase.SetearParametrosSQL("@Ataque", nuevoPokemon.EstadisticasBase.Ataque);
                ConexionBase.SetearParametrosSQL("@Defensa", nuevoPokemon.EstadisticasBase.Defensa);
                ConexionBase.SetearParametrosSQL("@AtaqueEsp", nuevoPokemon.EstadisticasBase.AtaqueEspecial);
                ConexionBase.SetearParametrosSQL("@DefensaEsp", nuevoPokemon.EstadisticasBase.DefensaEspecial);
                ConexionBase.SetearParametrosSQL("@Velocidad", nuevoPokemon.EstadisticasBase.Velocidad);
                ConexionBase.SetearParametrosSQL("@Imagen3d", nuevoPokemon.Sprite3d);
                ConexionBase.SetearParametrosSQL("@Grito", nuevoPokemon.GritoPokemon);

                ConexionBase.EjecutarInsertar();
            }
            catch (Exception ex)
            {        
                throw ex;
            }
            finally
            {
                ConexionBase.CerrarConexion();
            }
        }

        
        public List<Tipo> ListarTipo()
        {
            ConexionDBCentralizada ConexionCentral = new ConexionDBCentralizada();   
            List<Tipo> listaDeTipo = new List<Tipo>();
            try
            {    
                ConexionCentral.SQLQuery("Select Id, Descripcion from ELEMENTOS");
                ConexionCentral.EjecutarLecturaDeTabla();
                while (ConexionCentral.GuardadorCentralDeDatosSQLAcceso.Read())
                {
                    Tipo aux = new Tipo();
                    aux.Id = (int)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Id"];
                    aux.TipoPokemon = (string)ConexionCentral.GuardadorCentralDeDatosSQLAcceso["Descripcion"];
                    listaDeTipo.Add(aux);
                }
                return listaDeTipo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ConexionCentral.CerrarConexion();
            }
        }
    }
}
