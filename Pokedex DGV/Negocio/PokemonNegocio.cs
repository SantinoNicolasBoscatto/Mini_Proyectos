using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDominio;

namespace Negocio
{
    public class PokemonNegocio
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
                conexionSql.ConnectionString = "Data Source=192.168.0.5\\SQLEXPRESS01;Initial Catalog=POKEDEX_DB; integrated security= true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Nombre, Numero, EntradaPokedex, UrlImagen, E.Descripcion, D.Descripcion, P.IdDebilidad IdDeb, P.Id, Activo  from POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.id = P.idtipo AND D.Id = P.IdDebilidad AND Activo = 1 Order By Numero";
                comando.Connection = conexionSql;
                conexionSql.Open();
                reader =comando.ExecuteReader();

                while (reader.Read())
                {
                    Pokemon auxiliar = new Pokemon(reader.GetString(4), reader.GetString(5));
                    auxiliar.NumeroPokedex = reader.GetInt32(1);
                    auxiliar.Nombre = reader.GetString(0);
                    auxiliar.Descripcion = (string)reader["EntradaPokedex"];
                    auxiliar.Tipo.id = (int)reader["Id"];
                    auxiliar.Debilidad.id = (int)reader["IdDeb"];
                    auxiliar.Id = (int)reader["Id"];
                    //if (!(reader.IsDBNull(reader.GetOrdinal("UrlImagen"))))
                    //auxiliar.Imagen = (string)reader["UrlImagen"];
                    if (!(reader["UrlImagen"] is DBNull))
                    {
                        auxiliar.Imagen = (string)reader["UrlImagen"];
                    }
                    //if ((bool)reader["Activo"])
                     //auxiliar.Activo = (bool)reader["Activo"];
                      
                    
                    listapokemon.Add(auxiliar);
                    //auxiliar.Tipo = new Elemento();
                    //auxiliar.Tipo.Descripcion = reader.GetString(4);
                    //auxiliar.Debilidad = new Elemento();
                    //auxiliar.Debilidad.Descripcion = reader.GetString(5);
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

        public List<Pokemon> ListarInactivos()
        {
            List<Pokemon> listapokemon = new List<Pokemon>();
            SqlConnection conexionSql = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            try
            {
                conexionSql.ConnectionString = "server=.\\SQLEXPRESS01; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Nombre, Numero, EntradaPokedex, UrlImagen, E.Descripcion, D.Descripcion, P.Id Id, P.IdDebilidad IdDeb, P.Id, Activo  from POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.id = P.idtipo AND D.Id = P.IdDebilidad AND Activo = 0 Order By Numero";
                comando.Connection = conexionSql;
                conexionSql.Open();
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Pokemon auxiliar = new Pokemon(reader.GetString(4), reader.GetString(5));
                    auxiliar.NumeroPokedex = reader.GetInt32(1);
                    auxiliar.Nombre = reader.GetString(0);
                    auxiliar.Descripcion = (string)reader["EntradaPokedex"];
                    auxiliar.Tipo.id = (int)reader["Id"];
                    auxiliar.Debilidad.id = (int)reader["IdDeb"];
                    auxiliar.Id = (int)reader["Id"];
                    //if (!(reader.IsDBNull(reader.GetOrdinal("UrlImagen"))))
                    //auxiliar.Imagen = (string)reader["UrlImagen"];
                    if (!(reader["UrlImagen"] is DBNull))
                    {
                        auxiliar.Imagen = (string)reader["UrlImagen"];
                    }
                    //if ((bool)reader["Activo"])
                    //auxiliar.Activo = (bool)reader["Activo"];


                    listapokemon.Add(auxiliar);
                    //auxiliar.Tipo = new Elemento();
                    //auxiliar.Tipo.Descripcion = reader.GetString(4);
                    //auxiliar.Debilidad = new Elemento();
                    //auxiliar.Debilidad.Descripcion = reader.GetString(5);
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


        public void Agregar(Pokemon nuevo)
        {
            AccesoABaseDeDatos negocioInsertar = new AccesoABaseDeDatos();
            try
            {
                negocioInsertar.QuerySQL("Insert Into POKEMONS (Numero, Nombre, EntradaPokedex, Activo, IdDebilidad, IdTipo, UrlImagen ) values ("+ nuevo.NumeroPokedex + ",'"+ nuevo.Nombre+"','"+ nuevo.Descripcion+"',1, @IdTipo, @IdDebilidad, @UrlImagen)");
                negocioInsertar.setearParametro("@IdTipo", nuevo.Tipo.id);
                negocioInsertar.setearParametro("@IdDebilidad", nuevo.Debilidad.id);
                negocioInsertar.setearParametro("@UrlImagen", nuevo.Imagen);
                negocioInsertar.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                negocioInsertar.CerrarConexion();
            }
        }

        public void Modificar(Pokemon mod)
        {
            AccesoABaseDeDatos negocioInsertar = new AccesoABaseDeDatos();
            try
            {
                negocioInsertar.QuerySQL("Update POKEMONS set Numero = @Numero, Nombre =@Nombre, EntradaPokedex = @Descripcion, UrlImagen=@UrlImagen, IdTipo=@IdTipo, IdDebilidad =@IdDebilidad Where Id = @id");
                negocioInsertar.setearParametro("@Numero", mod.NumeroPokedex);
                negocioInsertar.setearParametro("@Nombre", mod.Nombre);
                negocioInsertar.setearParametro("@Descripcion", mod.Descripcion);
                negocioInsertar.setearParametro("@IdTipo", mod.Tipo.id);
                negocioInsertar.setearParametro("@IdDebilidad", mod.Debilidad.id);
                negocioInsertar.setearParametro("@UrlImagen", mod.Imagen);
                negocioInsertar.setearParametro("@id", mod.Id);
                negocioInsertar.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                negocioInsertar.CerrarConexion();
            }
        }


        public void Eliminar (Pokemon eliminar)
        {
            AccesoABaseDeDatos eliminarBase = new AccesoABaseDeDatos();
            try
            {
                eliminarBase.QuerySQL("Delete from POKEMONS where Id = @Id");
                eliminarBase.setearParametro("@Id", eliminar.Id);
                eliminarBase.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                eliminarBase.CerrarConexion();
            }
            
        }

        public void EliminarLogica(Pokemon eliminar)
        {
            AccesoABaseDeDatos eliminarBase = new AccesoABaseDeDatos();
            try
            {
                eliminarBase.QuerySQL("UPDATE POKEMONS SET Activo = 0 where Id = @Id");
                eliminarBase.setearParametro("@Id", eliminar.Id);
                eliminarBase.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                eliminarBase.CerrarConexion();
            }

        }

        public List<Pokemon> FiltroAvanzado(string campo, string criterio, string texto)
        {
            List<Pokemon> PokemonFiltrado = new List<Pokemon>();
            AccesoABaseDeDatos BaseAcceso = new AccesoABaseDeDatos();
            string inyeccion = "select Nombre, Numero, EntradaPokedex, UrlImagen, E.Descripcion, D.Descripcion, P.IdDebilidad Deb, P.Id, Activo  from POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.id = P.idtipo AND D.Id = P.IdDebilidad AND Activo = 1 AND ";

            try
            { 
                switch (campo)
                {
                    case "Numero":
                        switch (criterio)
                        {
                            case "Es Mayor a":
                                inyeccion += "Numero > " + texto;
                                break;
                            case "Es Menor a":
                                inyeccion += "Numero < " + texto;
                                break;
                            case "Es Igual a":
                                inyeccion += "Numero = " + texto;
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Empieza Por":
                                inyeccion += "Nombre Like '" + texto + "%'";
                                break;
                            case "Termina Por":
                                inyeccion += "Nombre Like '" + "%"+ texto +"'";
                                break;
                            case "Contiene":
                                inyeccion += "Nombre Like '" + "%" + texto + "%'";
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        switch (criterio)
                        {
                            case "Empieza Por":
                                inyeccion += "EntradaPokedex Like '" + texto + "%'";
                                break;
                            case "Termina Por":
                                inyeccion += "EntradaPokedex Like '" + "%" + texto + "'";
                                break;
                            case "Contiene":
                                inyeccion += "EntradaPokedex Like '" + "%" + texto + "%'";
                                break;
                            default:
                                break;
                        }
                        break;
                }

                BaseAcceso.QuerySQL(inyeccion+=" Order By Numero");
                BaseAcceso.EjecutarLectura();
                while(BaseAcceso.GuardadorDeDatos.Read())
                {
                    Pokemon auxilio = new Pokemon(BaseAcceso.GuardadorDeDatos.GetString(4), BaseAcceso.GuardadorDeDatos.GetString(5));
                    auxilio.Nombre = (string)BaseAcceso.GuardadorDeDatos["Nombre"];
                    auxilio.NumeroPokedex = (int)BaseAcceso.GuardadorDeDatos["Numero"];
                    auxilio.Descripcion = (string)BaseAcceso.GuardadorDeDatos["EntradaPokedex"];
                    auxilio.Tipo.id = (int)BaseAcceso.GuardadorDeDatos["Id"];
                    auxilio.Debilidad.id = (int)BaseAcceso.GuardadorDeDatos["Deb"];
                    auxilio.Id = (int)BaseAcceso.GuardadorDeDatos["Id"];
                    if (!(BaseAcceso.GuardadorDeDatos["UrlImagen"] is DBNull))
                    {
                        auxilio.Imagen = (string)BaseAcceso.GuardadorDeDatos["UrlImagen"];
                    }
                    PokemonFiltrado.Add(auxilio);
                }
            return PokemonFiltrado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseAcceso.CerrarConexion();
            }

        }
    }
}
