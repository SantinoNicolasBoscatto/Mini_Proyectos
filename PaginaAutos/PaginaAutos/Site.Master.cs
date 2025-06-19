using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using ModeloDeDominio;
using System.IO;
using System.Web.Services;

namespace PaginaAutos
{
    public partial class SiteMaster : MasterPage
    {
        
        private SqlDataReader GuardadorDatos;
        public SqlDataReader Guardador { get { return GuardadorDatos; } }
        readonly List<int> bolsaDeEnterosAutos = new List<int>();
        DateTime fechaPagina;
        DateTime fechaManager;
        List<int> AutosID = new List<int>();
        List<int> auxiliarLista = new List<int>();
        List<int> recargaDeLista = new List<int>();
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection conexionBD = new SqlConnection(ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString))
                {
                    string consultaFechas = "select FechaManager , FechaPagina from Fecha";
                    using (SqlCommand ComandoDeBaseDatos = new SqlCommand())
                    {
                        ComandoDeBaseDatos.CommandType = System.Data.CommandType.Text;
                        ComandoDeBaseDatos.CommandText = consultaFechas;
                        ComandoDeBaseDatos.Connection = conexionBD;
                        if (conexionBD.State == System.Data.ConnectionState.Closed)
                        {
                            conexionBD.Open();
                        }
                        GuardadorDatos = ComandoDeBaseDatos.ExecuteReader();
                        while (Guardador.Read())
                        {
                            fechaPagina = (DateTime)Guardador["FechaPagina"];
                            fechaManager = (DateTime)Guardador["FechaManager"];
                        }
                        GuardadorDatos.Close();
                    }
                }
                if (fechaPagina.Month != fechaManager.Month || true)
                {
                    using (SqlConnection conexionBD = new SqlConnection(ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString))
                    {
                        using (SqlCommand ComandoDeBaseDatos = new SqlCommand())
                        {

                            string inyeccion = "select AutoID, Nombre, Anio, Traccion, HP, Torque, Peso, PesoPotencia, TopSpeed, Pais2, PaisFabricacion, Aspiracion, Price, ImagenVentas from Autos, Marca where Marca = ID and  Dueno = 0";
                            ComandoDeBaseDatos.CommandType = System.Data.CommandType.Text;
                            ComandoDeBaseDatos.CommandText = inyeccion;
                            ComandoDeBaseDatos.Connection = conexionBD; //REVISAR
                            if (conexionBD.State == System.Data.ConnectionState.Closed)
                            {
                                conexionBD.Open();
                            }
                            int auxiliar = 0;
                            ComandoDeBaseDatos.Connection = conexionBD;
                            GuardadorDatos = ComandoDeBaseDatos.ExecuteReader();
                            List<Auto> listaDeAutos = new List<Auto>();
                            while (Guardador.Read())
                            {
                                auxiliar++;
                                bolsaDeEnterosAutos.Add(auxiliar);
                            }
                            GuardadorDatos.Close();
                            inyeccion = "select AutoID from Autos where dueno = 1";
                            ComandoDeBaseDatos.CommandText = inyeccion;
                            GuardadorDatos = ComandoDeBaseDatos.ExecuteReader();
                            int numeroDueno = -255;
                            if (Guardador.Read())
                            {
                                numeroDueno = (int)Guardador["AutoID"];
                            }
                            GuardadorDatos.Close();
                            AutosID = PoolObjetos(bolsaDeEnterosAutos.Count, bolsaDeEnterosAutos, numeroDueno);
                            HttpContext.Current.Cache["MyList"] = AutosID;
                            if (AutosID.Count >= 30)
                            {
                                SetearParametros("@Uno", AutosID[0], ComandoDeBaseDatos);
                                SetearParametros("@Dos", AutosID[1], ComandoDeBaseDatos);
                                SetearParametros("@Tres", AutosID[2], ComandoDeBaseDatos);
                                SetearParametros("@Cuatro", AutosID[3], ComandoDeBaseDatos);
                                SetearParametros("@Cinco", AutosID[4], ComandoDeBaseDatos);
                                SetearParametros("@6", AutosID[5], ComandoDeBaseDatos);
                                SetearParametros("@7", AutosID[6], ComandoDeBaseDatos);
                                SetearParametros("@8", AutosID[7], ComandoDeBaseDatos);
                                SetearParametros("@9", AutosID[8], ComandoDeBaseDatos);
                                SetearParametros("@10", AutosID[9], ComandoDeBaseDatos);
                                SetearParametros("@11", AutosID[10], ComandoDeBaseDatos);
                                SetearParametros("@12", AutosID[11], ComandoDeBaseDatos);
                                SetearParametros("@13", AutosID[12], ComandoDeBaseDatos);
                                SetearParametros("@14", AutosID[13], ComandoDeBaseDatos);
                                SetearParametros("@15", AutosID[14], ComandoDeBaseDatos);
                                SetearParametros("@16", AutosID[15], ComandoDeBaseDatos);
                                SetearParametros("@17", AutosID[16], ComandoDeBaseDatos);
                                SetearParametros("@18", AutosID[17], ComandoDeBaseDatos);
                                SetearParametros("@19", AutosID[18], ComandoDeBaseDatos);
                                SetearParametros("@20", AutosID[19], ComandoDeBaseDatos);
                                SetearParametros("@21", AutosID[20], ComandoDeBaseDatos);
                                SetearParametros("@22", AutosID[21], ComandoDeBaseDatos);
                                SetearParametros("@23", AutosID[22], ComandoDeBaseDatos);
                                SetearParametros("@24", AutosID[23], ComandoDeBaseDatos);
                                SetearParametros("@25", AutosID[24], ComandoDeBaseDatos);
                                SetearParametros("@26", AutosID[25], ComandoDeBaseDatos);
                                SetearParametros("@27", AutosID[26], ComandoDeBaseDatos);
                                SetearParametros("@28", AutosID[27], ComandoDeBaseDatos);
                                SetearParametros("@29", AutosID[28], ComandoDeBaseDatos);
                                SetearParametros("@30", AutosID[29], ComandoDeBaseDatos);
                                inyeccion = "select AutoID, Nombre, Anio, Traccion, HP, Torque, Peso, PesoPotencia, TopSpeed, Pais2, PaisFabricacion, Aspiracion, Price, ImagenVentas from Autos, Marca where Marca = ID and  AutoID IN (@Uno, @Dos, @Tres, @Cuatro, @Cinco, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, @19, @20, @21, @22, @23, @24, @25, @26, @27, @28, @29, @30)";
                                ComandoDeBaseDatos.CommandType = System.Data.CommandType.Text;
                                ComandoDeBaseDatos.CommandText = inyeccion;
                                ComandoDeBaseDatos.Connection = conexionBD;
                                GuardadorDatos = ComandoDeBaseDatos.ExecuteReader();
                                while (Guardador.Read())
                                {
                                    Auto aux = new Auto();
                                    aux.HP = (int)GuardadorDatos["HP"];
                                    aux.id = (int)GuardadorDatos["AutoID"];
                                    aux.Nombre = (string)GuardadorDatos["Nombre"];
                                    aux.Anio = (int)GuardadorDatos["Anio"];
                                    aux.Traccion = (string)GuardadorDatos["Traccion"];
                                    aux.Torque = (int)GuardadorDatos["Torque"];
                                    aux.Peso = (int)GuardadorDatos["Peso"];
                                    aux.PesoPotencia = (double)GuardadorDatos["PesoPotencia"];
                                    aux.TopSpeed = (double)GuardadorDatos["TopSpeed"];
                                    aux.ImagenMarca = (string)GuardadorDatos["Pais2"];
                                    aux.Aspiracion = (string)GuardadorDatos["Aspiracion"];
                                    aux.Imagen = (string)GuardadorDatos["ImagenVentas"];
                                    aux.Precio = (int)GuardadorDatos["Price"];
                                    listaDeAutos.Add(aux);
                                }
                            }
                            string plataFormato;
                            Dictionary<string, string> tagValues = new Dictionary<string, string>
                            {
                           { "HorsePower", listaDeAutos[0].HP.ToString()+" Hp" },
                           { "Precio", plataFormato = string.Format("$ {0:N0}", listaDeAutos[0].Precio)},
                           { "Boton", listaDeAutos[0].Precio.ToString()},
                           { "Peso", listaDeAutos[0].Peso.ToString()+" Kg" },
                           { "Nombre", listaDeAutos[0].Nombre},
                           { "ImagenVenta", listaDeAutos[0].Imagen},
                           { "PesoPotencia", listaDeAutos[0].PesoPotencia.ToString()},
                           { "Traccion", listaDeAutos[0].Traccion},
                           { "Torque", listaDeAutos[0].Torque.ToString()+" Nm"},
                           { "Aspiracion", listaDeAutos[0].Aspiracion},
                           { "TopSpeed", listaDeAutos[0].TopSpeed.ToString()},
                           { "Marca", listaDeAutos[0].ImagenMarca.ToString()},

                        { "HorsePower1", listaDeAutos[1].HP.ToString()+" Hp" },
                           { "Precio1", plataFormato = string.Format("$ {0:N0}", listaDeAutos[1].Precio)},
                           { "Peso1", listaDeAutos[1].Peso.ToString()+" Kg" },
                           { "Nombre1", listaDeAutos[1].Nombre},
                           { "ImagenVenta1", listaDeAutos[1].Imagen},
                           { "PesoPotencia1", listaDeAutos[1].PesoPotencia.ToString()},
                           { "Traccion1", listaDeAutos[1].Traccion},
                           { "Torque1", listaDeAutos[1].Torque.ToString()+" Nm"},
                           { "Aspiracion1", listaDeAutos[1].Aspiracion},
                           { "TopSpeed1", listaDeAutos[1].TopSpeed.ToString()},
                           { "Marca1", listaDeAutos[1].ImagenMarca.ToString()},

                           { "HorsePower2", listaDeAutos[2].HP.ToString()+" Hp" },
                           { "Precio2", plataFormato = string.Format("$ {0:N0}", listaDeAutos[2].Precio)},
                           { "Peso2", listaDeAutos[2].Peso.ToString()+" Kg" },
                           { "Nombre2", listaDeAutos[2].Nombre},
                           { "ImagenVenta2", listaDeAutos[2].Imagen},
                           { "PesoPotencia2", listaDeAutos[2].PesoPotencia.ToString()},
                           { "Traccion2", listaDeAutos[2].Traccion},
                           { "Torque2", listaDeAutos[2].Torque.ToString()+" Nm"},
                           { "Aspiracion2", listaDeAutos[2].Aspiracion},
                           { "TopSpeed2", listaDeAutos[2].TopSpeed.ToString()},
                           { "Marca2", listaDeAutos[2].ImagenMarca.ToString()},

                           { "HorsePower3", listaDeAutos[3].HP.ToString()+" Hp" },
                           { "Precio3", plataFormato = string.Format("$ {0:N0}", listaDeAutos[3].Precio)},
                           { "Peso3", listaDeAutos[3].Peso.ToString()+" Kg" },
                           { "Nombre3", listaDeAutos[3].Nombre},
                           { "ImagenVenta3", listaDeAutos[3].Imagen},
                           { "PesoPotencia3", listaDeAutos[3].PesoPotencia.ToString()},
                           { "Traccion3", listaDeAutos[3].Traccion},
                           { "Torque3", listaDeAutos[3].Torque.ToString()+" Nm"},
                           { "Aspiracion3", listaDeAutos[3].Aspiracion},
                           { "TopSpeed3", listaDeAutos[3].TopSpeed.ToString()},
                           { "Marca3", listaDeAutos[3].ImagenMarca.ToString()},

                           { "HorsePower4", listaDeAutos[4].HP.ToString()+" Hp" },
                           { "Precio4", plataFormato = string.Format("$ {0:N0}", listaDeAutos[4].Precio)},
                           { "Peso4", listaDeAutos[4].Peso.ToString()+" Kg" },
                           { "Nombre4", listaDeAutos[4].Nombre},
                           { "ImagenVenta4", listaDeAutos[4].Imagen},
                           { "PesoPotencia4", listaDeAutos[4].PesoPotencia.ToString()},
                           { "Traccion4", listaDeAutos[4].Traccion},
                           { "Torque4", listaDeAutos[4].Torque.ToString()+" Nm"},
                           { "Aspiracion4", listaDeAutos[4].Aspiracion},
                           { "TopSpeed4", listaDeAutos[4].TopSpeed.ToString()},
                           { "Marca4", listaDeAutos[4].ImagenMarca.ToString()},

                           { "HorsePower5", listaDeAutos[5].HP.ToString()+" Hp" },
                           { "Precio5", plataFormato = string.Format("$ {0:N0}", listaDeAutos[5].Precio)},
                           { "Peso5", listaDeAutos[5].Peso.ToString()+" Kg" },
                           { "Nombre5", listaDeAutos[5].Nombre},
                           { "ImagenVenta5", listaDeAutos[5].Imagen},
                           { "PesoPotencia5", listaDeAutos[5].PesoPotencia.ToString()},
                           { "Traccion5", listaDeAutos[5].Traccion},
                           { "Torque5", listaDeAutos[5].Torque.ToString()+" Nm"},
                           { "Aspiracion5", listaDeAutos[5].Aspiracion},
                           { "TopSpeed5", listaDeAutos[5].TopSpeed.ToString()},
                           { "Marca5", listaDeAutos[5].ImagenMarca.ToString()},

                           { "HorsePower6", listaDeAutos[6].HP.ToString()+" Hp" },
                           { "Precio6", plataFormato = string.Format("$ {0:N0}", listaDeAutos[6].Precio)},
                           { "Peso6", listaDeAutos[6].Peso.ToString()+" Kg" },
                           { "Nombre6", listaDeAutos[6].Nombre},
                           { "ImagenVenta6", listaDeAutos[6].Imagen},
                           { "PesoPotencia6", listaDeAutos[6].PesoPotencia.ToString()},
                           { "Traccion6", listaDeAutos[6].Traccion},
                           { "Torque6", listaDeAutos[6].Torque.ToString()+" Nm"},
                           { "Aspiracion6", listaDeAutos[6].Aspiracion},
                           { "TopSpeed6", listaDeAutos[6].TopSpeed.ToString()},
                           { "Marca6", listaDeAutos[6].ImagenMarca.ToString()},

                           { "HorsePower7", listaDeAutos[7].HP.ToString()+" Hp" },
                           { "Precio7", plataFormato = string.Format("$ {0:N0}", listaDeAutos[7].Precio)},
                           { "Peso7", listaDeAutos[7].Peso.ToString()+" Kg" },
                           { "Nombre7", listaDeAutos[7].Nombre},
                           { "ImagenVenta7", listaDeAutos[7].Imagen},
                           { "PesoPotencia7", listaDeAutos[7].PesoPotencia.ToString()},
                           { "Traccion7", listaDeAutos[7].Traccion},
                           { "Torque7", listaDeAutos[7].Torque.ToString()+" Nm"},
                           { "Aspiracion7", listaDeAutos[7].Aspiracion},
                           { "TopSpeed7", listaDeAutos[7].TopSpeed.ToString()},
                           { "Marca7", listaDeAutos[7].ImagenMarca.ToString()},

                           { "HorsePower8", listaDeAutos[8].HP.ToString()+" Hp" },
                           { "Precio8", plataFormato = string.Format("$ {0:N0}", listaDeAutos[8].Precio)},
                           { "Peso8", listaDeAutos[8].Peso.ToString()+" Kg" },
                           { "Nombre8", listaDeAutos[8].Nombre},
                           { "ImagenVenta8", listaDeAutos[8].Imagen},
                           { "PesoPotencia8", listaDeAutos[8].PesoPotencia.ToString()},
                           { "Traccion8", listaDeAutos[8].Traccion},
                           { "Torque8", listaDeAutos[8].Torque.ToString()+" Nm"},
                           { "Aspiracion8", listaDeAutos[8].Aspiracion},
                           { "TopSpeed8", listaDeAutos[8].TopSpeed.ToString()},
                           { "Marca8", listaDeAutos[8].ImagenMarca.ToString()},

                           { "HorsePower9", listaDeAutos[9].HP.ToString()+" Hp" },
                           { "Precio9", plataFormato = string.Format("$ {0:N0}", listaDeAutos[9].Precio)},
                           { "Peso9", listaDeAutos[9].Peso.ToString()+" Kg" },
                           { "Nombre9", listaDeAutos[9].Nombre},
                           { "ImagenVenta9", listaDeAutos[9].Imagen},
                           { "PesoPotencia9", listaDeAutos[9].PesoPotencia.ToString()},
                           { "Traccion9", listaDeAutos[9].Traccion},
                           { "Torque9", listaDeAutos[9].Torque.ToString()+" Nm"},
                           { "Aspiracion9", listaDeAutos[9].Aspiracion},
                           { "TopSpeed9", listaDeAutos[9].TopSpeed.ToString()},
                           { "Marca9", listaDeAutos[9].ImagenMarca.ToString()},

                           { "HorsePower10", listaDeAutos[10].HP.ToString()+" Hp" },
                           { "Precio10", plataFormato = string.Format("$ {0:N0}", listaDeAutos[10].Precio)},
                           { "Peso10", listaDeAutos[10].Peso.ToString()+" Kg" },
                           { "Nombre10", listaDeAutos[10].Nombre},
                           { "ImagenVenta10", listaDeAutos[10].Imagen},
                           { "PesoPotencia10", listaDeAutos[10].PesoPotencia.ToString()},
                           { "Traccion10", listaDeAutos[10].Traccion},
                           { "Torque10", listaDeAutos[10].Torque.ToString()+" Nm"},
                           { "Aspiracion10", listaDeAutos[10].Aspiracion},
                           { "TopSpeed10", listaDeAutos[10].TopSpeed.ToString()},
                           { "Marca10", listaDeAutos[10].ImagenMarca.ToString()},

                           { "HorsePower11", listaDeAutos[11].HP.ToString()+" Hp" },
                           { "Precio11", plataFormato = string.Format("$ {0:N0}", listaDeAutos[11].Precio)},
                           { "Peso11", listaDeAutos[11].Peso.ToString()+" Kg" },
                           { "Nombre11", listaDeAutos[11].Nombre},
                           { "ImagenVenta11", listaDeAutos[11].Imagen},
                           { "PesoPotencia11", listaDeAutos[11].PesoPotencia.ToString()},
                           { "Traccion11", listaDeAutos[11].Traccion},
                           { "Torque11", listaDeAutos[11].Torque.ToString()+" Nm"},
                           { "Aspiracion11", listaDeAutos[11].Aspiracion},
                           { "TopSpeed11", listaDeAutos[11].TopSpeed.ToString()},
                           { "Marca11", listaDeAutos[11].ImagenMarca.ToString()},

                           { "HorsePower12", listaDeAutos[12].HP.ToString()+" Hp" },
                           { "Precio12", plataFormato = string.Format("$ {0:N0}", listaDeAutos[12].Precio)},
                           { "Peso12", listaDeAutos[12].Peso.ToString()+" Kg" },
                           { "Nombre12", listaDeAutos[12].Nombre},
                           { "ImagenVenta12", listaDeAutos[12].Imagen},
                           { "PesoPotencia12", listaDeAutos[12].PesoPotencia.ToString()},
                           { "Traccion12", listaDeAutos[12].Traccion},
                           { "Torque12", listaDeAutos[12].Torque.ToString()+" Nm"},
                           { "Aspiracion12", listaDeAutos[12].Aspiracion},
                           { "TopSpeed12", listaDeAutos[12].TopSpeed.ToString()},
                           { "Marca12", listaDeAutos[12].ImagenMarca.ToString()},

                           { "HorsePower13", listaDeAutos[13].HP.ToString()+" Hp" },
                           { "Precio13", plataFormato = string.Format("$ {0:N0}", listaDeAutos[13].Precio)},
                           { "Peso13", listaDeAutos[13].Peso.ToString()+" Kg" },
                           { "Nombre13", listaDeAutos[13].Nombre},
                           { "ImagenVenta13", listaDeAutos[13].Imagen},
                           { "PesoPotencia13", listaDeAutos[13].PesoPotencia.ToString()},
                           { "Traccion13", listaDeAutos[13].Traccion},
                           { "Torque13", listaDeAutos[13].Torque.ToString()+" Nm"},
                           { "Aspiracion13", listaDeAutos[13].Aspiracion},
                           { "TopSpeed13", listaDeAutos[13].TopSpeed.ToString()},
                           { "Marca13", listaDeAutos[13].ImagenMarca.ToString()},

                           { "HorsePower14", listaDeAutos[14].HP.ToString()+" Hp" },
                           { "Precio14", plataFormato = string.Format("$ {0:N0}", listaDeAutos[14].Precio)},
                           { "Peso14", listaDeAutos[14].Peso.ToString()+" Kg" },
                           { "Nombre14", listaDeAutos[14].Nombre},
                           { "ImagenVenta14", listaDeAutos[14].Imagen},
                           { "PesoPotencia14", listaDeAutos[14].PesoPotencia.ToString()},
                           { "Traccion14", listaDeAutos[14].Traccion},
                           { "Torque14", listaDeAutos[14].Torque.ToString()+" Nm"},
                           { "Aspiracion14", listaDeAutos[14].Aspiracion},
                           { "TopSpeed14", listaDeAutos[14].TopSpeed.ToString()},
                           { "Marca14", listaDeAutos[14].ImagenMarca.ToString()},

                           { "HorsePower15", listaDeAutos[15].HP.ToString()+" Hp" },
                           { "Precio15", plataFormato = string.Format("$ {0:N0}", listaDeAutos[15].Precio)},
                           { "Peso15", listaDeAutos[15].Peso.ToString()+" Kg" },
                           { "Nombre15", listaDeAutos[15].Nombre},
                           { "ImagenVenta15", listaDeAutos[15].Imagen},
                           { "PesoPotencia15", listaDeAutos[15].PesoPotencia.ToString()},
                           { "Traccion15", listaDeAutos[15].Traccion},
                           { "Torque15", listaDeAutos[15].Torque.ToString()+" Nm"},
                           { "Aspiracion15", listaDeAutos[15].Aspiracion},
                           { "TopSpeed15", listaDeAutos[15].TopSpeed.ToString()},
                           { "Marca15", listaDeAutos[15].ImagenMarca.ToString()},

                           { "HorsePower16", listaDeAutos[16].HP.ToString()+" Hp" },
                           { "Precio16", plataFormato = string.Format("$ {0:N0}", listaDeAutos[16].Precio)},
                           { "Peso16", listaDeAutos[16].Peso.ToString()+" Kg" },
                           { "Nombre16", listaDeAutos[16].Nombre},
                           { "ImagenVenta16", listaDeAutos[16].Imagen},
                           { "PesoPotencia16", listaDeAutos[16].PesoPotencia.ToString()},
                           { "Traccion16", listaDeAutos[16].Traccion},
                           { "Torque16", listaDeAutos[16].Torque.ToString()+" Nm"},
                           { "Aspiracion16", listaDeAutos[16].Aspiracion},
                           { "TopSpeed16", listaDeAutos[16].TopSpeed.ToString()},
                           { "Marca16", listaDeAutos[16].ImagenMarca.ToString()},

                           { "HorsePower17", listaDeAutos[17].HP.ToString()+" Hp" },
                           { "Precio17", plataFormato = string.Format("$ {0:N0}", listaDeAutos[17].Precio)},
                           { "Peso17", listaDeAutos[17].Peso.ToString()+" Kg" },
                           { "Nombre17", listaDeAutos[17].Nombre},
                           { "ImagenVenta17", listaDeAutos[17].Imagen},
                           { "PesoPotencia17", listaDeAutos[17].PesoPotencia.ToString()},
                           { "Traccion17", listaDeAutos[17].Traccion},
                           { "Torque17", listaDeAutos[17].Torque.ToString()+" Nm"},
                           { "Aspiracion17", listaDeAutos[17].Aspiracion},
                           { "TopSpeed17", listaDeAutos[17].TopSpeed.ToString()},
                           { "Marca17", listaDeAutos[17].ImagenMarca.ToString()},

                           { "HorsePower18", listaDeAutos[18].HP.ToString()+" Hp" },
                           { "Precio18", plataFormato = string.Format("$ {0:N0}", listaDeAutos[18].Precio)},
                           { "Peso18", listaDeAutos[18].Peso.ToString()+" Kg" },
                           { "Nombre18", listaDeAutos[18].Nombre},
                           { "ImagenVenta18", listaDeAutos[18].Imagen},
                           { "PesoPotencia18", listaDeAutos[18].PesoPotencia.ToString()},
                           { "Traccion18", listaDeAutos[18].Traccion},
                           { "Torque18", listaDeAutos[18].Torque.ToString()+" Nm"},
                           { "Aspiracion18", listaDeAutos[18].Aspiracion},
                           { "TopSpeed18", listaDeAutos[18].TopSpeed.ToString()},
                           { "Marca18", listaDeAutos[18].ImagenMarca.ToString()},

                           { "HorsePower19", listaDeAutos[19].HP.ToString()+" Hp" },
                           { "Precio19", plataFormato = string.Format("$ {0:N0}", listaDeAutos[19].Precio)},
                           { "Peso19", listaDeAutos[19].Peso.ToString()+" Kg" },
                           { "Nombre19", listaDeAutos[19].Nombre},
                           { "ImagenVenta19", listaDeAutos[19].Imagen},
                           { "PesoPotencia19", listaDeAutos[19].PesoPotencia.ToString()},
                           { "Traccion19", listaDeAutos[19].Traccion},
                           { "Torque19", listaDeAutos[19].Torque.ToString()+" Nm"},
                           { "Aspiracion19", listaDeAutos[19].Aspiracion},
                           { "TopSpeed19", listaDeAutos[19].TopSpeed.ToString()},
                           { "Marca19", listaDeAutos[19].ImagenMarca.ToString()},

                           { "HorsePower20", listaDeAutos[20].HP.ToString()+" Hp" },
                           { "Precio20", plataFormato = string.Format("$ {0:N0}", listaDeAutos[20].Precio)},
                           { "Peso20", listaDeAutos[20].Peso.ToString()+" Kg" },
                           { "Nombre20", listaDeAutos[20].Nombre},
                           { "ImagenVenta20", listaDeAutos[20].Imagen},
                           { "PesoPotencia20", listaDeAutos[20].PesoPotencia.ToString()},
                           { "Traccion20", listaDeAutos[20].Traccion},
                           { "Torque20", listaDeAutos[20].Torque.ToString()+" Nm"},
                           { "Aspiracion20", listaDeAutos[20].Aspiracion},
                           { "TopSpeed20", listaDeAutos[20].TopSpeed.ToString()},
                           { "Marca20", listaDeAutos[20].ImagenMarca.ToString()},

                           { "HorsePower21", listaDeAutos[21].HP.ToString()+" Hp" },
                           { "Precio21", plataFormato = string.Format("$ {0:N0}", listaDeAutos[21].Precio)},
                           { "Peso21", listaDeAutos[21].Peso.ToString()+" Kg" },
                           { "Nombre21", listaDeAutos[21].Nombre},
                           { "ImagenVenta21", listaDeAutos[21].Imagen},
                           { "PesoPotencia21", listaDeAutos[21].PesoPotencia.ToString()},
                           { "Traccion21", listaDeAutos[21].Traccion},
                           { "Torque21", listaDeAutos[21].Torque.ToString()+" Nm"},
                           { "Aspiracion21", listaDeAutos[21].Aspiracion},
                           { "TopSpeed21", listaDeAutos[21].TopSpeed.ToString()},
                           { "Marca21", listaDeAutos[21].ImagenMarca.ToString()},

                           { "HorsePower22", listaDeAutos[22].HP.ToString()+" Hp" },
                           { "Precio22", plataFormato = string.Format("$ {0:N0}", listaDeAutos[22].Precio)},
                           { "Peso22", listaDeAutos[22].Peso.ToString()+" Kg" },
                           { "Nombre22", listaDeAutos[22].Nombre},
                           { "ImagenVenta22", listaDeAutos[22].Imagen},
                           { "PesoPotencia22", listaDeAutos[22].PesoPotencia.ToString()},
                           { "Traccion22", listaDeAutos[22].Traccion},
                           { "Torque22", listaDeAutos[22].Torque.ToString()+" Nm"},
                           { "Aspiracion22", listaDeAutos[22].Aspiracion},
                           { "TopSpeed22", listaDeAutos[22].TopSpeed.ToString()},
                           { "Marca22", listaDeAutos[22].ImagenMarca.ToString()},

                           { "HorsePower23", listaDeAutos[23].HP.ToString()+" Hp" },
                           { "Precio23", plataFormato = string.Format("$ {0:N0}", listaDeAutos[23].Precio)},
                           { "Peso23", listaDeAutos[23].Peso.ToString()+" Kg" },
                           { "Nombre23", listaDeAutos[23].Nombre},
                           { "ImagenVenta23", listaDeAutos[23].Imagen},
                           { "PesoPotencia23", listaDeAutos[23].PesoPotencia.ToString()},
                           { "Traccion23", listaDeAutos[23].Traccion},
                           { "Torque23", listaDeAutos[23].Torque.ToString()+" Nm"},
                           { "Aspiracion23", listaDeAutos[23].Aspiracion},
                           { "TopSpeed23", listaDeAutos[23].TopSpeed.ToString()},
                           { "Marca23", listaDeAutos[23].ImagenMarca.ToString()},

                           { "HorsePower24", listaDeAutos[24].HP.ToString()+" Hp" },
                           { "Precio24", plataFormato = string.Format("$ {0:N0}", listaDeAutos[24].Precio)},
                           { "Peso24", listaDeAutos[24].Peso.ToString()+" Kg" },
                           { "Nombre24", listaDeAutos[24].Nombre},
                           { "ImagenVenta24", listaDeAutos[24].Imagen},
                           { "PesoPotencia24", listaDeAutos[24].PesoPotencia.ToString()},
                           { "Traccion24", listaDeAutos[24].Traccion},
                           { "Torque24", listaDeAutos[24].Torque.ToString()+" Nm"},
                           { "Aspiracion24", listaDeAutos[24].Aspiracion},
                           { "TopSpeed24", listaDeAutos[24].TopSpeed.ToString()},
                           { "Marca24", listaDeAutos[24].ImagenMarca.ToString()},

                           { "HorsePower25", listaDeAutos[25].HP.ToString()+" Hp" },
                           { "Precio25", plataFormato = string.Format("$ {0:N0}", listaDeAutos[25].Precio)},
                           { "Peso25", listaDeAutos[25].Peso.ToString()+" Kg" },
                           { "Nombre25", listaDeAutos[25].Nombre},
                           { "ImagenVenta25", listaDeAutos[25].Imagen},
                           { "PesoPotencia25", listaDeAutos[25].PesoPotencia.ToString()},
                           { "Traccion25", listaDeAutos[25].Traccion},
                           { "Torque25", listaDeAutos[25].Torque.ToString()+" Nm"},
                           { "Aspiracion25", listaDeAutos[25].Aspiracion},
                           { "TopSpeed25", listaDeAutos[25].TopSpeed.ToString()},
                           { "Marca25", listaDeAutos[25].ImagenMarca.ToString()},

                           { "HorsePower26", listaDeAutos[26].HP.ToString()+" Hp" },
                           { "Precio26", plataFormato = string.Format("$ {0:N0}", listaDeAutos[26].Precio)},
                           { "Peso26", listaDeAutos[26].Peso.ToString()+" Kg" },
                           { "Nombre26", listaDeAutos[26].Nombre},
                           { "ImagenVenta26", listaDeAutos[26].Imagen},
                           { "PesoPotencia26", listaDeAutos[26].PesoPotencia.ToString("0.00")},
                           { "Traccion26", listaDeAutos[26].Traccion},
                           { "Torque26", listaDeAutos[26].Torque.ToString()+" Nm"},
                           { "Aspiracion26", listaDeAutos[26].Aspiracion},
                           { "TopSpeed26", listaDeAutos[26].TopSpeed.ToString()},
                           { "Marca26", listaDeAutos[26].ImagenMarca.ToString()},

                           { "HorsePower27", listaDeAutos[27].HP.ToString()+" Hp" },
                           { "Precio27", plataFormato = string.Format("$ {0:N0}", listaDeAutos[27].Precio)},
                           { "Peso27", listaDeAutos[27].Peso.ToString()+" Kg" },
                           { "Nombre27", listaDeAutos[27].Nombre},
                           { "ImagenVenta27", listaDeAutos[27].Imagen},
                           { "PesoPotencia27", listaDeAutos[27].PesoPotencia.ToString()},
                           { "Traccion27", listaDeAutos[27].Traccion},
                           { "Torque27", listaDeAutos[27].Torque.ToString()+" Nm"},
                           { "Aspiracion27", listaDeAutos[27].Aspiracion},
                           { "TopSpeed27", listaDeAutos[0].TopSpeed.ToString()},
                           { "Marca27", listaDeAutos[27].ImagenMarca.ToString()},

                           { "HorsePower28", listaDeAutos[28].HP.ToString()+" Hp" },
                           { "Precio28", plataFormato = string.Format("$ {0:N0}", listaDeAutos[28].Precio)},
                           { "Peso28", listaDeAutos[28].Peso.ToString()+" Kg" },
                           { "Nombre28", listaDeAutos[28].Nombre},
                           { "ImagenVenta28", listaDeAutos[28].Imagen},
                           { "PesoPotencia28", listaDeAutos[28].PesoPotencia.ToString()},
                           { "Traccion28", listaDeAutos[28].Traccion},
                           { "Torque28", listaDeAutos[28].Torque.ToString()+" Nm"},
                           { "Aspiracion28", listaDeAutos[28].Aspiracion},
                           { "TopSpeed28", listaDeAutos[28].TopSpeed.ToString()},
                           { "Marca28", listaDeAutos[28].ImagenMarca.ToString()},

                           { "HorsePower29", listaDeAutos[29].HP.ToString()+" Hp" },
                           { "Precio29", plataFormato = string.Format("$ {0:N0}", listaDeAutos[29].Precio)},
                           { "Peso29", listaDeAutos[29].Peso.ToString()+" Kg" },
                           { "Nombre29", listaDeAutos[29].Nombre},
                           { "ImagenVenta29", listaDeAutos[29].Imagen},
                           { "PesoPotencia29", listaDeAutos[29].PesoPotencia.ToString()},
                           { "Traccion29", listaDeAutos[29].Traccion},
                           { "Torque29", listaDeAutos[29].Torque.ToString()+" Nm"},
                           { "Aspiracion29", listaDeAutos[29].Aspiracion},
                           { "TopSpeed29", listaDeAutos[29].TopSpeed.ToString()},
                           { "Marca29", listaDeAutos[29].ImagenMarca.ToString()},
                    };
                            foreach (var kvp in tagValues)
                            {
                                // Encuentra el elemento por su ID
                                Control control = FindControl(kvp.Key);

                                // Verifica si se encontró el elemento
                                if (control != null)
                                {
                                    if (control is HtmlImage imageTag)
                                    {
                                        // Si es una etiqueta <img>, establece el atributo src
                                        imageTag.Src = kvp.Value;
                                    }
                                    else if (control is HtmlGenericControl genericTag)
                                    {
                                        // Si es una etiqueta <p> u otro elemento de texto, establece el nuevo valor
                                        genericTag.InnerText = kvp.Value;
                                    }
                                }
                            }
                            CargaLista(AutosID);
                        }

                    }
                    using (SqlConnection conexionBase = new SqlConnection(ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString))
                    {
                        using (SqlCommand comandoActualizar = new SqlCommand())
                        {
                            comandoActualizar.CommandType = System.Data.CommandType.Text;
                            comandoActualizar.CommandText = "Update Fecha Set FechaPagina = FechaManager";
                            comandoActualizar.Connection = conexionBase;
                            if (conexionBase.State == System.Data.ConnectionState.Closed)
                            {
                                conexionBase.Open();
                            }
                            comandoActualizar.ExecuteNonQuery();
                        }
                    }
                }

                else
                {
                    recargaDeLista = (List<int>)HttpContext.Current.Cache["MyList"];
                    AutosID = (List<int>)HttpContext.Current.Cache["MyList"];
                    string inyeccion = "";
                    List<Auto> listaDeAutos = new List<Auto>();
                    using (SqlConnection conexionBD = new SqlConnection(ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString))
                    {
                        using (SqlCommand ComandoDeBaseDatos = new SqlCommand())
                        {
                            if (recargaDeLista.Count >= 30)
                            {
                                SetearParametros("@Uno", recargaDeLista[0], ComandoDeBaseDatos);
                                SetearParametros("@Dos", recargaDeLista[1], ComandoDeBaseDatos);
                                SetearParametros("@Tres", recargaDeLista[2], ComandoDeBaseDatos);
                                SetearParametros("@Cuatro", recargaDeLista[3], ComandoDeBaseDatos);
                                SetearParametros("@Cinco", recargaDeLista[4], ComandoDeBaseDatos);
                                SetearParametros("@6", recargaDeLista[5], ComandoDeBaseDatos);
                                SetearParametros("@7", recargaDeLista[6], ComandoDeBaseDatos);
                                SetearParametros("@8", recargaDeLista[7], ComandoDeBaseDatos);
                                SetearParametros("@9", recargaDeLista[8], ComandoDeBaseDatos);
                                SetearParametros("@10", recargaDeLista[9], ComandoDeBaseDatos);
                                SetearParametros("@11", recargaDeLista[10], ComandoDeBaseDatos);
                                SetearParametros("@12", recargaDeLista[11], ComandoDeBaseDatos);
                                SetearParametros("@13", recargaDeLista[12], ComandoDeBaseDatos);
                                SetearParametros("@14", recargaDeLista[13], ComandoDeBaseDatos);
                                SetearParametros("@15", recargaDeLista[14], ComandoDeBaseDatos);
                                SetearParametros("@16", recargaDeLista[15], ComandoDeBaseDatos);
                                SetearParametros("@17", recargaDeLista[16], ComandoDeBaseDatos);
                                SetearParametros("@18", recargaDeLista[17], ComandoDeBaseDatos);
                                SetearParametros("@19", recargaDeLista[18], ComandoDeBaseDatos);
                                SetearParametros("@20", recargaDeLista[19], ComandoDeBaseDatos);
                                SetearParametros("@21", recargaDeLista[20], ComandoDeBaseDatos);
                                SetearParametros("@22", recargaDeLista[21], ComandoDeBaseDatos);
                                SetearParametros("@23", recargaDeLista[22], ComandoDeBaseDatos);
                                SetearParametros("@24", recargaDeLista[23], ComandoDeBaseDatos);
                                SetearParametros("@25", recargaDeLista[24], ComandoDeBaseDatos);
                                SetearParametros("@26", recargaDeLista[25], ComandoDeBaseDatos);
                                SetearParametros("@27", recargaDeLista[26], ComandoDeBaseDatos);
                                SetearParametros("@28", recargaDeLista[27], ComandoDeBaseDatos);
                                SetearParametros("@29", recargaDeLista[28], ComandoDeBaseDatos);
                                SetearParametros("@30", recargaDeLista[29], ComandoDeBaseDatos);
                                inyeccion = "select AutoID, Nombre, Anio, Traccion, HP, Torque, Peso, PesoPotencia, TopSpeed, Pais2, PaisFabricacion, Aspiracion, Price, ImagenVentas from Autos, Marca where Marca = ID and  AutoID IN (@Uno, @Dos, @Tres, @Cuatro, @Cinco, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, @19, @20, @21, @22, @23, @24, @25, @26, @27, @28, @29, @30)";
                                ComandoDeBaseDatos.CommandType = System.Data.CommandType.Text;
                                ComandoDeBaseDatos.CommandText = inyeccion;
                                ComandoDeBaseDatos.Connection = conexionBD;
                                if (conexionBD.State == System.Data.ConnectionState.Closed)
                                {
                                    conexionBD.Open();
                                }
                                GuardadorDatos = ComandoDeBaseDatos.ExecuteReader();
                                while (Guardador.Read())
                                {
                                    Auto aux = new Auto();
                                    aux.HP = (int)GuardadorDatos["HP"];
                                    aux.id = (int)GuardadorDatos["AutoID"];
                                    aux.Nombre = (string)GuardadorDatos["Nombre"];
                                    aux.Anio = (int)GuardadorDatos["Anio"];
                                    aux.Traccion = (string)GuardadorDatos["Traccion"];
                                    aux.Torque = (int)GuardadorDatos["Torque"];
                                    aux.Peso = (int)GuardadorDatos["Peso"];
                                    aux.PesoPotencia = (double)GuardadorDatos["PesoPotencia"];
                                    aux.TopSpeed = (double)GuardadorDatos["TopSpeed"];
                                    aux.ImagenMarca = (string)GuardadorDatos["Pais2"];
                                    aux.Aspiracion = (string)GuardadorDatos["Aspiracion"];
                                    aux.Imagen = (string)GuardadorDatos["ImagenVentas"];
                                    aux.Precio = (int)GuardadorDatos["Price"];
                                    listaDeAutos.Add(aux);
                                }
                            }
                            string plataFormato;
                            Dictionary<string, string> tagValues = new Dictionary<string, string>
                        {
                           { "HorsePower", listaDeAutos[0].HP.ToString()+" Hp" },
                           { "Precio", plataFormato = string.Format("$ {0:N0}", listaDeAutos[0].Precio)},
                           { "Peso", listaDeAutos[0].Peso.ToString()+" Kg" },
                           { "Nombre", listaDeAutos[0].Nombre},
                           { "ImagenVenta", listaDeAutos[0].Imagen},
                           { "PesoPotencia", listaDeAutos[0].PesoPotencia.ToString()},
                           { "Traccion", listaDeAutos[0].Traccion},
                           { "Torque", listaDeAutos[0].Torque.ToString()+" Nm"},
                           { "Aspiracion", listaDeAutos[0].Aspiracion},
                           { "TopSpeed", listaDeAutos[0].TopSpeed.ToString()},
                           { "Marca", listaDeAutos[0].ImagenMarca.ToString()},

                        { "HorsePower1", listaDeAutos[1].HP.ToString()+" Hp" },
                           { "Precio1", plataFormato = string.Format("$ {0:N0}", listaDeAutos[0].Precio)},
                           { "Peso1", listaDeAutos[1].Peso.ToString()+" Kg" },
                           { "Nombre1", listaDeAutos[1].Nombre},
                           { "ImagenVenta1", listaDeAutos[1].Imagen},
                           { "PesoPotencia1", listaDeAutos[1].PesoPotencia.ToString()},
                           { "Traccion1", listaDeAutos[1].Traccion},
                           { "Torque1", listaDeAutos[1].Torque.ToString()+" Nm"},
                           { "Aspiracion1", listaDeAutos[1].Aspiracion},
                           { "TopSpeed1", listaDeAutos[1].TopSpeed.ToString()},
                           { "Marca1", listaDeAutos[1].ImagenMarca.ToString()},

                           { "HorsePower2", listaDeAutos[2].HP.ToString()+" Hp" },
                           { "Precio2", plataFormato = string.Format("$ {0:N0}", listaDeAutos[2].Precio)},
                           { "Peso2", listaDeAutos[2].Peso.ToString()+" Kg" },
                           { "Nombre2", listaDeAutos[2].Nombre},
                           { "ImagenVenta2", listaDeAutos[2].Imagen},
                           { "PesoPotencia2", listaDeAutos[2].PesoPotencia.ToString()},
                           { "Traccion2", listaDeAutos[2].Traccion},
                           { "Torque2", listaDeAutos[2].Torque.ToString()+" Nm"},
                           { "Aspiracion2", listaDeAutos[2].Aspiracion},
                           { "TopSpeed2", listaDeAutos[2].TopSpeed.ToString()},
                           { "Marca2", listaDeAutos[2].ImagenMarca.ToString()},

                           { "HorsePower3", listaDeAutos[3].HP.ToString()+" Hp" },
                           { "Precio3", plataFormato = string.Format("$ {0:N0}", listaDeAutos[3].Precio)},
                           { "Peso3", listaDeAutos[3].Peso.ToString()+" Kg" },
                           { "Nombre3", listaDeAutos[3].Nombre},
                           { "ImagenVenta3", listaDeAutos[3].Imagen},
                           { "PesoPotencia3", listaDeAutos[3].PesoPotencia.ToString()},
                           { "Traccion3", listaDeAutos[3].Traccion},
                           { "Torque3", listaDeAutos[3].Torque.ToString()+" Nm"},
                           { "Aspiracion3", listaDeAutos[3].Aspiracion},
                           { "TopSpeed3", listaDeAutos[3].TopSpeed.ToString()},
                           { "Marca3", listaDeAutos[3].ImagenMarca.ToString()},

                           { "HorsePower4", listaDeAutos[4].HP.ToString()+" Hp" },
                           { "Precio4", plataFormato = string.Format("$ {0:N0}", listaDeAutos[4].Precio)},
                           { "Peso4", listaDeAutos[4].Peso.ToString()+" Kg" },
                           { "Nombre4", listaDeAutos[4].Nombre},
                           { "ImagenVenta4", listaDeAutos[4].Imagen},
                           { "PesoPotencia4", listaDeAutos[4].PesoPotencia.ToString()},
                           { "Traccion4", listaDeAutos[4].Traccion},
                           { "Torque4", listaDeAutos[4].Torque.ToString()+" Nm"},
                           { "Aspiracion4", listaDeAutos[4].Aspiracion},
                           { "TopSpeed4", listaDeAutos[4].TopSpeed.ToString()},
                           { "Marca4", listaDeAutos[4].ImagenMarca.ToString()},

                           { "HorsePower5", listaDeAutos[5].HP.ToString()+" Hp" },
                           { "Precio5", plataFormato = string.Format("$ {0:N0}", listaDeAutos[5].Precio)},
                           { "Peso5", listaDeAutos[5].Peso.ToString()+" Kg" },
                           { "Nombre5", listaDeAutos[5].Nombre},
                           { "ImagenVenta5", listaDeAutos[5].Imagen},
                           { "PesoPotencia5", listaDeAutos[5].PesoPotencia.ToString()},
                           { "Traccion5", listaDeAutos[5].Traccion},
                           { "Torque5", listaDeAutos[5].Torque.ToString()+" Nm"},
                           { "Aspiracion5", listaDeAutos[5].Aspiracion},
                           { "TopSpeed5", listaDeAutos[5].TopSpeed.ToString()},
                           { "Marca5", listaDeAutos[5].ImagenMarca.ToString()},

                           { "HorsePower6", listaDeAutos[6].HP.ToString()+" Hp" },
                           { "Precio6", plataFormato = string.Format("$ {0:N0}", listaDeAutos[6].Precio)},
                           { "Peso6", listaDeAutos[6].Peso.ToString()+" Kg" },
                           { "Nombre6", listaDeAutos[6].Nombre},
                           { "ImagenVenta6", listaDeAutos[6].Imagen},
                           { "PesoPotencia6", listaDeAutos[6].PesoPotencia.ToString()},
                           { "Traccion6", listaDeAutos[6].Traccion},
                           { "Torque6", listaDeAutos[6].Torque.ToString()+" Nm"},
                           { "Aspiracion6", listaDeAutos[6].Aspiracion},
                           { "TopSpeed6", listaDeAutos[6].TopSpeed.ToString()},
                           { "Marca6", listaDeAutos[6].ImagenMarca.ToString()},

                           { "HorsePower7", listaDeAutos[7].HP.ToString()+" Hp" },
                           { "Precio7", plataFormato = string.Format("$ {0:N0}", listaDeAutos[7].Precio)},
                           { "Peso7", listaDeAutos[7].Peso.ToString()+" Kg" },
                           { "Nombre7", listaDeAutos[7].Nombre},
                           { "ImagenVenta7", listaDeAutos[7].Imagen},
                           { "PesoPotencia7", listaDeAutos[7].PesoPotencia.ToString()},
                           { "Traccion7", listaDeAutos[7].Traccion},
                           { "Torque7", listaDeAutos[7].Torque.ToString()+" Nm"},
                           { "Aspiracion7", listaDeAutos[7].Aspiracion},
                           { "TopSpeed7", listaDeAutos[7].TopSpeed.ToString()},
                           { "Marca7", listaDeAutos[7].ImagenMarca.ToString()},

                           { "HorsePower8", listaDeAutos[8].HP.ToString()+" Hp" },
                           { "Precio8", plataFormato = string.Format("$ {0:N0}", listaDeAutos[8].Precio)},
                           { "Peso8", listaDeAutos[8].Peso.ToString()+" Kg" },
                           { "Nombre8", listaDeAutos[8].Nombre},
                           { "ImagenVenta8", listaDeAutos[8].Imagen},
                           { "PesoPotencia8", listaDeAutos[8].PesoPotencia.ToString()},
                           { "Traccion8", listaDeAutos[8].Traccion},
                           { "Torque8", listaDeAutos[8].Torque.ToString()+" Nm"},
                           { "Aspiracion8", listaDeAutos[8].Aspiracion},
                           { "TopSpeed8", listaDeAutos[8].TopSpeed.ToString()},
                           { "Marca8", listaDeAutos[8].ImagenMarca.ToString()},

                           { "HorsePower9", listaDeAutos[9].HP.ToString()+" Hp" },
                           { "Precio9", plataFormato = string.Format("$ {0:N0}", listaDeAutos[9].Precio)},
                           { "Peso9", listaDeAutos[9].Peso.ToString()+" Kg" },
                           { "Nombre9", listaDeAutos[9].Nombre},
                           { "ImagenVenta9", listaDeAutos[9].Imagen},
                           { "PesoPotencia9", listaDeAutos[9].PesoPotencia.ToString()},
                           { "Traccion9", listaDeAutos[9].Traccion},
                           { "Torque9", listaDeAutos[9].Torque.ToString()+" Nm"},
                           { "Aspiracion9", listaDeAutos[9].Aspiracion},
                           { "TopSpeed9", listaDeAutos[9].TopSpeed.ToString()},
                           { "Marca9", listaDeAutos[9].ImagenMarca.ToString()},

                           { "HorsePower10", listaDeAutos[10].HP.ToString()+" Hp" },
                           { "Precio10", plataFormato = string.Format("$ {0:N0}", listaDeAutos[10].Precio)},
                           { "Peso10", listaDeAutos[10].Peso.ToString()+" Kg" },
                           { "Nombre10", listaDeAutos[10].Nombre},
                           { "ImagenVenta10", listaDeAutos[10].Imagen},
                           { "PesoPotencia10", listaDeAutos[10].PesoPotencia.ToString()},
                           { "Traccion10", listaDeAutos[10].Traccion},
                           { "Torque10", listaDeAutos[10].Torque.ToString()+" Nm"},
                           { "Aspiracion10", listaDeAutos[10].Aspiracion},
                           { "TopSpeed10", listaDeAutos[10].TopSpeed.ToString()},
                           { "Marca10", listaDeAutos[10].ImagenMarca.ToString()},

                           { "HorsePower11", listaDeAutos[11].HP.ToString()+" Hp" },
                           { "Precio11", plataFormato = string.Format("$ {0:N0}", listaDeAutos[11].Precio)},
                           { "Peso11", listaDeAutos[11].Peso.ToString()+" Kg" },
                           { "Nombre11", listaDeAutos[11].Nombre},
                           { "ImagenVenta11", listaDeAutos[11].Imagen},
                           { "PesoPotencia11", listaDeAutos[11].PesoPotencia.ToString()},
                           { "Traccion11", listaDeAutos[11].Traccion},
                           { "Torque11", listaDeAutos[11].Torque.ToString()+" Nm"},
                           { "Aspiracion11", listaDeAutos[11].Aspiracion},
                           { "TopSpeed11", listaDeAutos[11].TopSpeed.ToString()},
                           { "Marca11", listaDeAutos[11].ImagenMarca.ToString()},

                           { "HorsePower12", listaDeAutos[12].HP.ToString()+" Hp" },
                           { "Precio12", plataFormato = string.Format("$ {0:N0}", listaDeAutos[12].Precio)},
                           { "Peso12", listaDeAutos[12].Peso.ToString()+" Kg" },
                           { "Nombre12", listaDeAutos[12].Nombre},
                           { "ImagenVenta12", listaDeAutos[12].Imagen},
                           { "PesoPotencia12", listaDeAutos[12].PesoPotencia.ToString()},
                           { "Traccion12", listaDeAutos[12].Traccion},
                           { "Torque12", listaDeAutos[12].Torque.ToString()+" Nm"},
                           { "Aspiracion12", listaDeAutos[12].Aspiracion},
                           { "TopSpeed12", listaDeAutos[12].TopSpeed.ToString()},
                           { "Marca12", listaDeAutos[12].ImagenMarca.ToString()},

                           { "HorsePower13", listaDeAutos[13].HP.ToString()+" Hp" },
                           { "Precio13", plataFormato = string.Format("$ {0:N0}", listaDeAutos[13].Precio)},
                           { "Peso13", listaDeAutos[13].Peso.ToString()+" Kg" },
                           { "Nombre13", listaDeAutos[13].Nombre},
                           { "ImagenVenta13", listaDeAutos[13].Imagen},
                           { "PesoPotencia13", listaDeAutos[13].PesoPotencia.ToString()},
                           { "Traccion13", listaDeAutos[13].Traccion},
                           { "Torque13", listaDeAutos[13].Torque.ToString()+" Nm"},
                           { "Aspiracion13", listaDeAutos[13].Aspiracion},
                           { "TopSpeed13", listaDeAutos[13].TopSpeed.ToString()},
                           { "Marca13", listaDeAutos[13].ImagenMarca.ToString()},

                           { "HorsePower14", listaDeAutos[14].HP.ToString()+" Hp" },
                           { "Precio14", plataFormato = string.Format("$ {0:N0}", listaDeAutos[14].Precio)},
                           { "Peso14", listaDeAutos[14].Peso.ToString()+" Kg" },
                           { "Nombre14", listaDeAutos[14].Nombre},
                           { "ImagenVenta14", listaDeAutos[14].Imagen},
                           { "PesoPotencia14", listaDeAutos[14].PesoPotencia.ToString()},
                           { "Traccion14", listaDeAutos[14].Traccion},
                           { "Torque14", listaDeAutos[14].Torque.ToString()+" Nm"},
                           { "Aspiracion14", listaDeAutos[14].Aspiracion},
                           { "TopSpeed14", listaDeAutos[14].TopSpeed.ToString()},
                           { "Marca14", listaDeAutos[14].ImagenMarca.ToString()},

                           { "HorsePower15", listaDeAutos[15].HP.ToString()+" Hp" },
                           { "Precio15", plataFormato = string.Format("$ {0:N0}", listaDeAutos[15].Precio)},
                           { "Peso15", listaDeAutos[15].Peso.ToString()+" Kg" },
                           { "Nombre15", listaDeAutos[15].Nombre},
                           { "ImagenVenta15", listaDeAutos[15].Imagen},
                           { "PesoPotencia15", listaDeAutos[15].PesoPotencia.ToString()},
                           { "Traccion15", listaDeAutos[15].Traccion},
                           { "Torque15", listaDeAutos[15].Torque.ToString()+" Nm"},
                           { "Aspiracion15", listaDeAutos[15].Aspiracion},
                           { "TopSpeed15", listaDeAutos[15].TopSpeed.ToString()},
                           { "Marca15", listaDeAutos[15].ImagenMarca.ToString()},

                           { "HorsePower16", listaDeAutos[16].HP.ToString()+" Hp" },
                           { "Precio16", plataFormato = string.Format("$ {0:N0}", listaDeAutos[16].Precio)},
                           { "Peso16", listaDeAutos[16].Peso.ToString()+" Kg" },
                           { "Nombre16", listaDeAutos[16].Nombre},
                           { "ImagenVenta16", listaDeAutos[16].Imagen},
                           { "PesoPotencia16", listaDeAutos[16].PesoPotencia.ToString()},
                           { "Traccion16", listaDeAutos[16].Traccion},
                           { "Torque16", listaDeAutos[16].Torque.ToString()+" Nm"},
                           { "Aspiracion16", listaDeAutos[16].Aspiracion},
                           { "TopSpeed16", listaDeAutos[16].TopSpeed.ToString()},
                           { "Marca16", listaDeAutos[16].ImagenMarca.ToString()},

                           { "HorsePower17", listaDeAutos[17].HP.ToString()+" Hp" },
                           { "Precio17", plataFormato = string.Format("$ {0:N0}", listaDeAutos[17].Precio)},
                           { "Peso17", listaDeAutos[17].Peso.ToString()+" Kg" },
                           { "Nombre17", listaDeAutos[17].Nombre},
                           { "ImagenVenta17", listaDeAutos[17].Imagen},
                           { "PesoPotencia17", listaDeAutos[17].PesoPotencia.ToString()},
                           { "Traccion17", listaDeAutos[17].Traccion},
                           { "Torque17", listaDeAutos[17].Torque.ToString()+" Nm"},
                           { "Aspiracion17", listaDeAutos[17].Aspiracion},
                           { "TopSpeed17", listaDeAutos[17].TopSpeed.ToString()},
                           { "Marca17", listaDeAutos[17].ImagenMarca.ToString()},

                           { "HorsePower18", listaDeAutos[18].HP.ToString()+" Hp" },
                           { "Precio18", plataFormato = string.Format("$ {0:N0}", listaDeAutos[18].Precio)},
                           { "Peso18", listaDeAutos[18].Peso.ToString()+" Kg" },
                           { "Nombre18", listaDeAutos[18].Nombre},
                           { "ImagenVenta18", listaDeAutos[18].Imagen},
                           { "PesoPotencia18", listaDeAutos[18].PesoPotencia.ToString()},
                           { "Traccion18", listaDeAutos[18].Traccion},
                           { "Torque18", listaDeAutos[18].Torque.ToString()+" Nm"},
                           { "Aspiracion18", listaDeAutos[18].Aspiracion},
                           { "TopSpeed18", listaDeAutos[18].TopSpeed.ToString()},
                           { "Marca18", listaDeAutos[18].ImagenMarca.ToString()},

                           { "HorsePower19", listaDeAutos[19].HP.ToString()+" Hp" },
                           { "Precio19", plataFormato = string.Format("$ {0:N0}", listaDeAutos[19].Precio)},
                           { "Peso19", listaDeAutos[19].Peso.ToString()+" Kg" },
                           { "Nombre19", listaDeAutos[19].Nombre},
                           { "ImagenVenta19", listaDeAutos[19].Imagen},
                           { "PesoPotencia19", listaDeAutos[19].PesoPotencia.ToString()},
                           { "Traccion19", listaDeAutos[19].Traccion},
                           { "Torque19", listaDeAutos[19].Torque.ToString()+" Nm"},
                           { "Aspiracion19", listaDeAutos[19].Aspiracion},
                           { "TopSpeed19", listaDeAutos[19].TopSpeed.ToString()},
                           { "Marca19", listaDeAutos[19].ImagenMarca.ToString()},

                           { "HorsePower20", listaDeAutos[20].HP.ToString()+" Hp" },
                           { "Precio20", plataFormato = string.Format("$ {0:N0}", listaDeAutos[20].Precio)},
                           { "Peso20", listaDeAutos[20].Peso.ToString()+" Kg" },
                           { "Nombre20", listaDeAutos[20].Nombre},
                           { "ImagenVenta20", listaDeAutos[20].Imagen},
                           { "PesoPotencia20", listaDeAutos[20].PesoPotencia.ToString()},
                           { "Traccion20", listaDeAutos[20].Traccion},
                           { "Torque20", listaDeAutos[20].Torque.ToString()+" Nm"},
                           { "Aspiracion20", listaDeAutos[20].Aspiracion},
                           { "TopSpeed20", listaDeAutos[20].TopSpeed.ToString()},
                           { "Marca20", listaDeAutos[20].ImagenMarca.ToString()},

                           { "HorsePower21", listaDeAutos[21].HP.ToString()+" Hp" },
                           { "Precio21", plataFormato = string.Format("$ {0:N0}", listaDeAutos[21].Precio)},
                           { "Peso21", listaDeAutos[21].Peso.ToString()+" Kg" },
                           { "Nombre21", listaDeAutos[21].Nombre},
                           { "ImagenVenta21", listaDeAutos[21].Imagen},
                           { "PesoPotencia21", listaDeAutos[21].PesoPotencia.ToString()},
                           { "Traccion21", listaDeAutos[21].Traccion},
                           { "Torque21", listaDeAutos[21].Torque.ToString()+" Nm"},
                           { "Aspiracion21", listaDeAutos[21].Aspiracion},
                           { "TopSpeed21", listaDeAutos[21].TopSpeed.ToString()},
                           { "Marca21", listaDeAutos[21].ImagenMarca.ToString()},

                           { "HorsePower22", listaDeAutos[22].HP.ToString()+" Hp" },
                           { "Precio22", plataFormato = string.Format("$ {0:N0}", listaDeAutos[22].Precio)},
                           { "Peso22", listaDeAutos[22].Peso.ToString()+" Kg" },
                           { "Nombre22", listaDeAutos[22].Nombre},
                           { "ImagenVenta22", listaDeAutos[22].Imagen},
                           { "PesoPotencia22", listaDeAutos[22].PesoPotencia.ToString()},
                           { "Traccion22", listaDeAutos[22].Traccion},
                           { "Torque22", listaDeAutos[22].Torque.ToString()+" Nm"},
                           { "Aspiracion22", listaDeAutos[22].Aspiracion},
                           { "TopSpeed22", listaDeAutos[22].TopSpeed.ToString()},
                           { "Marca22", listaDeAutos[22].ImagenMarca.ToString()},

                           { "HorsePower23", listaDeAutos[23].HP.ToString()+" Hp" },
                           { "Precio23", plataFormato = string.Format("$ {0:N0}", listaDeAutos[23].Precio)},
                           { "Peso23", listaDeAutos[23].Peso.ToString()+" Kg" },
                           { "Nombre23", listaDeAutos[23].Nombre},
                           { "ImagenVenta23", listaDeAutos[23].Imagen},
                           { "PesoPotencia23", listaDeAutos[23].PesoPotencia.ToString()},
                           { "Traccion23", listaDeAutos[23].Traccion},
                           { "Torque23", listaDeAutos[23].Torque.ToString()+" Nm"},
                           { "Aspiracion23", listaDeAutos[23].Aspiracion},
                           { "TopSpeed23", listaDeAutos[23].TopSpeed.ToString()},
                           { "Marca23", listaDeAutos[23].ImagenMarca.ToString()},

                           { "HorsePower24", listaDeAutos[24].HP.ToString()+" Hp" },
                           { "Precio24", plataFormato = string.Format("$ {0:N0}", listaDeAutos[24].Precio)},
                           { "Peso24", listaDeAutos[24].Peso.ToString()+" Kg" },
                           { "Nombre24", listaDeAutos[24].Nombre},
                           { "ImagenVenta24", listaDeAutos[24].Imagen},
                           { "PesoPotencia24", listaDeAutos[24].PesoPotencia.ToString()},
                           { "Traccion24", listaDeAutos[24].Traccion},
                           { "Torque24", listaDeAutos[24].Torque.ToString()+" Nm"},
                           { "Aspiracion24", listaDeAutos[24].Aspiracion},
                           { "TopSpeed24", listaDeAutos[24].TopSpeed.ToString()},
                           { "Marca24", listaDeAutos[24].ImagenMarca.ToString()},

                           { "HorsePower25", listaDeAutos[25].HP.ToString()+" Hp" },
                           { "Precio25", plataFormato = string.Format("$ {0:N0}", listaDeAutos[25].Precio)},
                           { "Peso25", listaDeAutos[25].Peso.ToString()+" Kg" },
                           { "Nombre25", listaDeAutos[25].Nombre},
                           { "ImagenVenta25", listaDeAutos[25].Imagen},
                           { "PesoPotencia25", listaDeAutos[25].PesoPotencia.ToString()},
                           { "Traccion25", listaDeAutos[25].Traccion},
                           { "Torque25", listaDeAutos[25].Torque.ToString()+" Nm"},
                           { "Aspiracion25", listaDeAutos[25].Aspiracion},
                           { "TopSpeed25", listaDeAutos[25].TopSpeed.ToString()},
                           { "Marca25", listaDeAutos[25].ImagenMarca.ToString()},

                           { "HorsePower26", listaDeAutos[26].HP.ToString()+" Hp" },
                           { "Precio26", plataFormato = string.Format("$ {0:N0}", listaDeAutos[26].Precio)},
                           { "Peso26", listaDeAutos[26].Peso.ToString()+" Kg" },
                           { "Nombre26", listaDeAutos[26].Nombre},
                           { "ImagenVenta26", listaDeAutos[26].Imagen},
                           { "PesoPotencia26", listaDeAutos[26].PesoPotencia.ToString("0.00")},
                           { "Traccion26", listaDeAutos[26].Traccion},
                           { "Torque26", listaDeAutos[26].Torque.ToString()+" Nm"},
                           { "Aspiracion26", listaDeAutos[26].Aspiracion},
                           { "TopSpeed26", listaDeAutos[26].TopSpeed.ToString()},
                           { "Marca26", listaDeAutos[26].ImagenMarca.ToString()},

                           { "HorsePower27", listaDeAutos[27].HP.ToString()+" Hp" },
                           { "Precio27", plataFormato = string.Format("$ {0:N0}", listaDeAutos[27].Precio)},
                           { "Peso27", listaDeAutos[27].Peso.ToString()+" Kg" },
                           { "Nombre27", listaDeAutos[27].Nombre},
                           { "ImagenVenta27", listaDeAutos[27].Imagen},
                           { "PesoPotencia27", listaDeAutos[27].PesoPotencia.ToString()},
                           { "Traccion27", listaDeAutos[27].Traccion},
                           { "Torque27", listaDeAutos[27].Torque.ToString()+" Nm"},
                           { "Aspiracion27", listaDeAutos[27].Aspiracion},
                           { "TopSpeed27", listaDeAutos[0].TopSpeed.ToString()},
                           { "Marca27", listaDeAutos[27].ImagenMarca.ToString()},

                           { "HorsePower28", listaDeAutos[28].HP.ToString()+" Hp" },
                           { "Precio28", plataFormato = string.Format("$ {0:N0}", listaDeAutos[28].Precio)},
                           { "Peso28", listaDeAutos[28].Peso.ToString()+" Kg" },
                           { "Nombre28", listaDeAutos[28].Nombre},
                           { "ImagenVenta28", listaDeAutos[28].Imagen},
                           { "PesoPotencia28", listaDeAutos[28].PesoPotencia.ToString()},
                           { "Traccion28", listaDeAutos[28].Traccion},
                           { "Torque28", listaDeAutos[28].Torque.ToString()+" Nm"},
                           { "Aspiracion28", listaDeAutos[28].Aspiracion},
                           { "TopSpeed28", listaDeAutos[28].TopSpeed.ToString()},
                           { "Marca28", listaDeAutos[28].ImagenMarca.ToString()},
                    };
                            foreach (var kvp in tagValues)
                            {
                                // Encuentra el elemento por su ID
                                Control control = FindControl(kvp.Key);

                                // Verifica si se encontró el elemento
                                if (control != null)
                                {
                                    if (control is HtmlImage imageTag)
                                    {
                                        // Si es una etiqueta <img>, establece el atributo src
                                        imageTag.Src = kvp.Value;
                                    }
                                    else if (control is HtmlGenericControl genericTag)
                                    {
                                        // Si es una etiqueta <p> u otro elemento de texto, establece el nuevo valor
                                        genericTag.InnerText = kvp.Value;
                                    }
                                }
                            }
                            CargaLista(recargaDeLista);
                        }
                    }
                }
            }
        }

        public void CargaLista(List<int> carga)
        {
            auxiliarLista = carga;
        }

        public List<int> PoolObjetos(int tamanioBolsa, List<int> bolsaObjetos, int excluir)
        {
            List<int> listaNumeros = new List<int>();
            Random numerosRandom = new Random();
            int x = 0;
            int y;
            while (x != 30 && tamanioBolsa > 0)
            {
                y = (int)numerosRandom.Next(0, tamanioBolsa);
                if (bolsaObjetos[y]!= excluir)
                {
                    listaNumeros.Add(bolsaObjetos[y]);
                    bolsaObjetos.Remove(bolsaObjetos[y]);
                    tamanioBolsa = bolsaObjetos.Count;
                    x++;
                }
                
            }
            return listaNumeros;
        }

        public void SetearParametros(string Nombre, object valor, SqlCommand ComandoDeBaseDatos)
        {
            ComandoDeBaseDatos.Parameters.AddWithValue(Nombre, valor);
        }

        public void ActualizarBaseDeDatos(string ID)
        {
            using (SqlConnection conexionBD = new SqlConnection(ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString))
            {
                string inyectar = "Select Price From Autos Where AutoID = @ID";
                
                using (SqlCommand ComandoDeBaseDatos = new SqlCommand())
                {
                    int auxID = int.Parse(ID);
                    int precio;           
                    SetearParametros("@ID", auxiliarLista[auxID-1] , ComandoDeBaseDatos);
                    ComandoDeBaseDatos.CommandType = System.Data.CommandType.Text;
                    ComandoDeBaseDatos.CommandText = inyectar;
                    ComandoDeBaseDatos.Connection = conexionBD;
                    if (conexionBD.State == System.Data.ConnectionState.Closed)
                    {
                        conexionBD.Open();
                    }
                    GuardadorDatos = ComandoDeBaseDatos.ExecuteReader();
                    if (Guardador.Read())
                    {
                        precio = (int)Guardador["Price"];
                    }
                }

                inyectar = "Update Economia Set Dinero = Dinero - @BotonPrecio";
                using (SqlCommand ComandoDeBaseDatos = new SqlCommand())
                {
                    SetearParametros("@BotonPrecio", "Boton",ComandoDeBaseDatos);
                    ComandoDeBaseDatos.CommandType = System.Data.CommandType.Text;
                    ComandoDeBaseDatos.CommandText = inyectar;
                    ComandoDeBaseDatos.Connection = conexionBD;
                    if (conexionBD.State == System.Data.ConnectionState.Closed)
                    {
                        conexionBD.Open();
                    }
                    ComandoDeBaseDatos.ExecuteNonQuery();
                }
            }
        }

        protected void Boton1_Click(object sender, EventArgs e)
        {
            //ActualizarBaseDeDatos(Boton1.CommandName);
        }
    }
}

