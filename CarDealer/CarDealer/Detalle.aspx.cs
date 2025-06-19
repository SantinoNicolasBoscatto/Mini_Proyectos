using Modelo_Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio_Base_Datos;

namespace CarDealer
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["AutoDetalle"] != null)
            {
                Autos aux = (Autos)Session["AutoDetalle"];
                MarcaImagen.ImageUrl = aux.MarcaAuto.ImagenMarca != null ? aux.MarcaAuto.ImagenMarca : "https://cdn4.vectorstock.com/i/1000x1000/48/83/no-car-sign-vector-13874883.jpg";
                ModeloLabel.Text = aux.NombreModelo;
                PotenciaLabel.Text = aux.HP.ToString() + " Hp";
                PesoLabel.Text = string.Format("{0:n0}", aux.Peso) + " Kg";
                PPLabel.Text = aux.RelacionPesoPotencia.ToString("0.00") + " Kg/Hp";
                TraccionLabel.Text = aux.Traccion;
                ASPLabel.Text = aux.Aspiracion;
                KMLabel.Text = string.Format("{0:n0}", aux.Kilometraje);
                TorqueLabel.Text = aux.Torque.ToString()+" Nm";
                YearLabel.Text = aux.Anio.ToString();
                CompraLabel.Text = "$ "+string.Format("{0:n0}", aux.Precio);
                ImagenProducto.ImageUrl = aux.ImagenVenta != null ? aux.ImagenVenta : "https://cdn4.vectorstock.com/i/1000x1000/48/83/no-car-sign-vector-13874883.jpg";
            
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void VolverBoton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void Comprar_Click(object sender, EventArgs e)
        {
            FuncionesNegocio func = new FuncionesNegocio();
            NegocioPagina negocio = new NegocioPagina(func);
            if(negocio.ComprarAuto(((Autos)Session["AutoDetalle"]).Id))
            {
                Response.Redirect("Exito.aspx", false);
            }
            else
            {
                ErrorCompra.Visible = true;
            }
        }
    }
}