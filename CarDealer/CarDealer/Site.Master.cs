using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarDealer
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"]==null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                ImagenPerfilMini.ImageUrl = (((Usuario)Session["Usuario"]).ImagenPerfil != null) ? ((Usuario)Session["Usuario"]).ImagenPerfil : "https://yt3.googleusercontent.com/wsHyzTadTE-l1LWnvPFmr_4m1B10fDmy2ri41wc3alq2cdwxPhlZ2RVbOdLPyr_RnPVLnxLC=s900-c-k-c0x00ffffff-no-rj";
            }
        }

        protected void ImagenPerfilMini_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Perfil.aspx", false);
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}