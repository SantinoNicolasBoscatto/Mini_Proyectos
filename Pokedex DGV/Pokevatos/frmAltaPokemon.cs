using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModeloDeDominio;
using Negocio;
using System.Configuration;

namespace Pokevatos
{   
    public partial class frmAltaPokemon : Form
    {
        private Pokemon pokemon = null;
        bool bd = true;
        OpenFileDialog cargarImagen = null;
        public frmAltaPokemon()
        {
            InitializeComponent();
        }
        public frmAltaPokemon(Pokemon modificacion, bool bandera)
        {
            InitializeComponent();
            pokemon =modificacion;
            bd = bandera;
            this.Text = "Modificacion";
        }
        private void CancelarBoton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void AceptarBoton_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            PokemonNegocio negocio = new PokemonNegocio();
            try
                {
                    
                if (bd)
                {
                    pokemon = new Pokemon();
                    pokemon.Nombre = NombreBox.Text;
                    pokemon.Descripcion = DescripcionBox.Text;
                    pokemon.NumeroPokedex = int.Parse(NumeroBox.Text);
                    pokemon.Debilidad = (Elemento)DebilidadCaja.SelectedItem;
                    pokemon.Tipo = (Elemento)TipoCaja.SelectedItem;
                    if (cargarImagen != null && !(UrlCaja.Text.ToLower().Contains("http")))
                    {
                        //bool verificadorDeCopia = File.Exists(ConfigurationManager.AppSettings["Imagenes"]+cargarImagen.FileName);
                        string ruta = cargarImagen.FileName;
                        string nombreArchivo = Path.GetFileName(ruta);
                        if (!(File.Exists(Path.Combine(ConfigurationManager.AppSettings["Imagenes"], nombreArchivo))))
                        {
                            File.Copy(cargarImagen.FileName, ConfigurationManager.AppSettings["Imagenes"] + cargarImagen.SafeFileName);
                            pokemon.Imagen = Path.Combine(ConfigurationManager.AppSettings["Imagenes"], nombreArchivo);
                        }
                    }
                    else
                    {
                        pokemon.Imagen = UrlCaja.Text;
                    }
                    negocio.Agregar(pokemon);
                    MessageBox.Show("Agregado Con exito");
                    
                        
                }
                else
                {
                    pokemon.Nombre = NombreBox.Text;
                    pokemon.Descripcion = DescripcionBox.Text;
                    pokemon.NumeroPokedex = int.Parse(NumeroBox.Text);
                    pokemon.Debilidad = (Elemento)DebilidadCaja.SelectedItem;
                    pokemon.Tipo = (Elemento)TipoCaja.SelectedItem;
                    if (cargarImagen != null && !(UrlCaja.Text.ToLower().Contains("http")))
                    {
                        //bool verificadorDeCopia = File.Exists(ConfigurationManager.AppSettings["Imagenes"]+cargarImagen.FileName);
                        string ruta = cargarImagen.FileName;
                        string nombreArchivo = Path.GetFileName(ruta);
                        if (!(File.Exists(Path.Combine(ConfigurationManager.AppSettings["Imagenes"], nombreArchivo))))
                        {
                            File.Copy(cargarImagen.FileName, ConfigurationManager.AppSettings["Imagenes"] + cargarImagen.SafeFileName);
                            pokemon.Imagen = Path.Combine(ConfigurationManager.AppSettings["Imagenes"], nombreArchivo);
                        }
                    }
                    else
                    {
                        pokemon.Imagen = UrlCaja.Text;
                    }
                    negocio.Modificar(pokemon);
                    MessageBox.Show("Modificado Con exito");                   
                }
                this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Datos Mal Cargados" + ex.ToString());
                }    
            
        }

        private void frmAltaPokemon_Load(object sender, EventArgs e)
        {
            TipoNegocio negocioElemento = new TipoNegocio();
            try
            {
                TipoCaja.DataSource = negocioElemento.ListarElementos();
                TipoCaja.ValueMember = "Descripcion";
                TipoCaja.DisplayMember = "Descripcion";
                DebilidadCaja.DataSource = negocioElemento.ListarElementos();
                DebilidadCaja.ValueMember = "Descripcion";
                DebilidadCaja.DisplayMember = "Descripcion";
                if (pokemon!= null)
                {
                    NumeroBox.Text = pokemon.NumeroPokedex.ToString();
                    NombreBox.Text = pokemon.Nombre;
                    DescripcionBox.Text = pokemon.Descripcion;
                    UrlCaja.Text = pokemon.Imagen;
                    TipoCaja.SelectedValue = pokemon.Tipo.Descripcion;
                    DebilidadCaja.SelectedValue = pokemon.Debilidad.Descripcion;

                    try
                    {
                        pictureBox1.Load(UrlCaja.Text);
                    }
                    catch (Exception)
                    {
                    }     
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UrlCaja_Leave(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Load(UrlCaja.Text);
            }
            catch (Exception)
            {
                pictureBox1.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/No_image_available.svg/1024px-No_image_available.svg.png");
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ImagenBoton_Click(object sender, EventArgs e)
        {
            cargarImagen = new OpenFileDialog();
            cargarImagen.Filter = "jpg|*.jpg| png|*.png| gif|*.gif";
            if (cargarImagen.ShowDialog() == DialogResult.OK)
            { 
                UrlCaja.Text = cargarImagen.FileName;
                try
                {
                    pictureBox1.Load(UrlCaja.Text);
                }
                catch (Exception)
                {
                    pictureBox1.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/No_image_available.svg/1024px-No_image_available.svg.png");
                }
            }

        }

        private void TipoCaja_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
