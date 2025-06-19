using Dominio;
using Negocio_Base_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarDealer
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Usuario"] != null)
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario aux = negocio.DevolverUsuario(((Usuario)Session["Usuario"]).Id);
                Nombre.Text = (aux.Nombre!=null)? aux.Nombre : "";
                EmailPerfil.Text = (aux.Email != null) ? aux.Email : "";
                Password.Text = (aux.Pass != null) ? aux.Pass : "";
                ImagenUrl.Text = (aux.ImagenPerfil != null) ? aux.ImagenPerfil : "";
                ImgPerfil.ImageUrl = ImagenUrl.Text;
            }
            
        }

        protected void ImagenUrl_TextChanged(object sender, EventArgs e)
        {
            ImgPerfil.ImageUrl = ImagenUrl.Text;
        }

        protected void ActualizarPerfil_Click(object sender, EventArgs e)
        {
            if (Nombre.Text!= "" && EmailPerfil.Text != "" && Password.Text != "")
            {
                Usuario usuario = new Usuario();
                usuario.Nombre = Nombre.Text;
                usuario.Email = EmailPerfil.Text;
                usuario.ImagenPerfil = ImagenUrl.Text;
                usuario.Pass = Password.Text;
                usuario.Id = ((Usuario)Session["Usuario"]).Id;
                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.UpdateUsuario(usuario);
                Session.Add("Usuario", usuario);
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }
    }
}