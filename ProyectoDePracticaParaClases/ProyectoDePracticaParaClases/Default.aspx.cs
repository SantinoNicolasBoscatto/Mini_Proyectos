using ModeloDeDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoDePracticaParaClases
{
    public partial class Default : System.Web.UI.Page
    {
        //bool bandera;
        protected void Page_Load(object sender, EventArgs e)
        {
            //bandera = Request.QueryString["bool"] != null ? true : false;
            if (!IsPostBack)
            {
                if (Session["Lista"] == null)
                {
                    Negocio aux = new Negocio();
                    Session.Add("Lista", aux.listar());
                }
                dgvAutos.DataSource = Session["Lista"];
                dgvAutos.DataBind();
            }

        }

        protected void BotonAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AutoForms.aspx", false);
        }

        protected void dgvAutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var myId = dgvAutos.SelectedDataKey.Value.ToString();
            Response.Redirect("AutoForms.aspx?id="+ myId,false);
        }
    }
}