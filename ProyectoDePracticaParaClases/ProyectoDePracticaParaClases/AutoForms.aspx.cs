using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModeloDeDominio;

namespace ProyectoDePracticaParaClases
{
    public partial class AutoForms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListaCarga.Items.Add("Rojo");
                ListaCarga.Items.Add("Azul");
                ListaCarga.Items.Add("Amarillo");
                ListaCarga.Items.Add("Negro");
                ListaCarga.Items.Add("Blanco");
                ListaCarga.Items.Add("Chatarresco");
                if (Request.QueryString["id"] != null)
                {
                    AgregarBoton.Visible = false;
                    ModificarBoton.Visible = true;
                    EliminarBoton.Visible = true;
                    int idAutoSelect = int.Parse(Request.QueryString["id"]);                  
                    Auto seleccionado =  ((List<Auto>)Session["Lista"]).Find(aux => aux.Id == idAutoSelect);
                    IDCarTextBox.Text = idAutoSelect.ToString();
                    DescripcionTextbox.Text = seleccionado.Descripcion;
                    ModeloBox.Text = seleccionado.Modelo;
                    FechaBox.Text = seleccionado.Fecha.ToString("yyyy-MM-dd");
                    CheckBox1.Checked = seleccionado.Usado;
                    int index = -1;
                    if (seleccionado.Importado == true)
                    {
                        Importado.Checked = true;
                        Nacional.Checked = false;
                    }
                    foreach (var item in ListaCarga.Items)
                    {
                        index++;
                        if (item.ToString() == seleccionado.Color)
                        {
                             ListaCarga.SelectedIndex = index;
                        }
                    }
                }
            } 

        }

        protected void AgregarBoton_Click(object sender, EventArgs e)
        {
            Auto ejemplo = new Auto();
            ejemplo.Id = int.Parse(IDCarTextBox.Text);
            ejemplo.Descripcion = DescripcionTextbox.Text;
            ejemplo.Modelo = ModeloBox.Text;
            ejemplo.Color = ListaCarga.SelectedItem.Text;
            ejemplo.Fecha = DateTime.Parse(FechaBox.Text);
            ejemplo.Usado = CheckBox1.Checked;
            ejemplo.Importado = Importado.Checked;
            if (Request.QueryString["id"] == null)
            {
                ((List<Auto>)Session["Lista"]).Add(ejemplo);
                Response.Redirect("Default.aspx", false);
                //List<Auto> aux = new List<Auto>();
                //aux = (List<Auto>)Session["Lista"] != null ? (List<Auto>)Session["Lista"] : (List<Auto>)new List<Auto>();
                //aux.Add(ejemplo);
                //Response.Redirect("Default.aspx?bool="+ true, false);
            }
            else
            {
               Auto dummy = ((List<Auto>)Session["Lista"]).FirstOrDefault(aux => aux.Id == ejemplo.Id);
                if (dummy != null)
                {
                    dummy.Descripcion = ejemplo.Descripcion;
                    dummy.Modelo = ejemplo.Modelo;
                    dummy.Color = ejemplo.Color;
                    dummy.Fecha = ejemplo.Fecha;
                    dummy.Usado = ejemplo.Usado;
                    dummy.Importado = ejemplo.Importado;
                    Response.Redirect("Default.aspx", false);
                }
            }

        }

        protected void EliminarBoton_Click(object sender, EventArgs e)
        {
            int eliminarAuto = int.Parse(Request.QueryString["id"]);
            ((List<Auto>)Session["Lista"]).Remove(((List<Auto>)Session["Lista"]).Find(aux => aux.Id == eliminarAuto));
            Response.Redirect("Default.aspx", false);
        }
    }
}