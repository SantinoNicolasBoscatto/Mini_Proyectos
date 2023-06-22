using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeDominio;

namespace Negocio
{
    public class TipoNegocio
    {
        public List<Elemento> ListarElementos()
        {
            List<Elemento> listaDeElementos = new List<Elemento>();
            AccesoABaseDeDatos conexionBD = new AccesoABaseDeDatos();

            try
            {
                conexionBD.QuerySQL("select Id, Descripcion From ELEMENTOS where Active = 1");
                conexionBD.EjecutarLectura();
                while (conexionBD.GuardadorDeDatos.Read())
                {
                    Elemento auxiliar = new Elemento();
                    auxiliar.Descripcion = (string)conexionBD.GuardadorDeDatos["Descripcion"];
                    auxiliar.id = (int)conexionBD.GuardadorDeDatos["Id"];
                    listaDeElementos.Add(auxiliar);
                }
                return listaDeElementos;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }
    }
}
