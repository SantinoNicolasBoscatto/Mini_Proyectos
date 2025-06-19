using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio_Base_Datos;

namespace CarDealer
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.Registrarse.UniqueID;
        }

        protected void Registrarse_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            Negocio_Base_Datos.UsuarioNegocio negocio = new Negocio_Base_Datos.UsuarioNegocio();
            try
            {
                Unico.Visible = false;
                Page.Validate();
                if (!Page.IsValid)
                    return;
                user.Email = EmailBox.Text;
                user.Pass = PassBox.Text;
                user.Id = negocio.RegistroUsuario(user);
                if (user.Id != 0)
                {
                    Session.Add("Usuario", user);
                    Response.Redirect("Default.aspx", false);
                }
                else
                    Unico.Visible = true;
                
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

    }
}
