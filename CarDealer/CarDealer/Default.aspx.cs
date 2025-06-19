using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo_Clases;

namespace CarDealer
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Negocio_Base_Datos.NegocioBaseDatos negocio = new Negocio_Base_Datos.NegocioBaseDatos();
                Repetidor.DataSource = negocio.DevolverVentas();
                Repetidor.DataBind();
            }
        }

        protected void MasDetalles_Click(object sender, EventArgs e)
        {
            int index = ((RepeaterItem)((Button)sender).NamingContainer).ItemIndex;       
            List<Autos> Lista = new List<Autos>();
            Negocio_Base_Datos.NegocioBaseDatos negocio = new Negocio_Base_Datos.NegocioBaseDatos();
            Lista = negocio.DevolverVentas();
            int id = Lista[index].Id;
            Session.Add("AutoDetalle", Lista[index]);
            Response.Redirect("Detalle.aspx", false);
        }
    }
}