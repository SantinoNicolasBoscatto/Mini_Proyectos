using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClaseNegocio;
using ModeloDeDominio;

namespace PokedexProyecto
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            ConexionPokemonDataBase conexionAgregar = new ConexionPokemonDataBase();
            Pokemon nuevoPoke = new Pokemon();
            try
            {
                nuevoPoke.NumeroPokedex = (int)NumeroBox.Value;   
                nuevoPoke.DescripcionDePokemon = DescripcionBox.Text;
                nuevoPoke.Sprite = ImagenBox.Text;
                nuevoPoke.Sprite3d = Imagen3dBox.Text;
                nuevoPoke.EstadisticasBase.HP = (int)HpBox.Value;
                nuevoPoke.EstadisticasBase.Ataque = (int)AtaqueBox.Value;
                nuevoPoke.EstadisticasBase.Defensa = (int)DefensaBox.Value;
                nuevoPoke.EstadisticasBase.AtaqueEspecial = (int)AtaqueEspBox.Value;
                nuevoPoke.EstadisticasBase.DefensaEspecial = (int)DefEspBox.Value;
                nuevoPoke.EstadisticasBase.Velocidad = (int)VelocidadBox.Value;
                nuevoPoke.GritoPokemon = GritoBox.Text;
                nuevoPoke.TipoDeElemento = (Tipo)TipoComboBox.SelectedItem;
                nuevoPoke.Debilidad = (Tipo)DebilidadComboBox.SelectedItem;
                nuevoPoke.Nombre = NombreBox.Text;
                conexionAgregar.AgregarPokemon(nuevoPoke);

                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
                //MessageBox.Show("Datos Mal Cargados, Revise los datos");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ConexionPokemonDataBase CargarTipos = new ConexionPokemonDataBase();
            TipoComboBox.DataSource = CargarTipos.ListarTipo();
            DebilidadComboBox.DataSource = CargarTipos.ListarTipo();
        }

        private void ImagenBox_Leave(object sender, EventArgs e)
        {
            try
            {
                CargarSprite(ImagenBox.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void CargarSprite(string Sprite2d)
        {
            try
            {
                pictureBox1.Load(Sprite2d);
            }
            catch (Exception)
            {
                pictureBox1.Load("https://static.wikia.nocookie.net/bec6f033-936d-48c5-9c1e-7fb7207e28af/scale-to-width/755");
            }
        }
        private void CargarSprite3d(string Sprite3d)
        {
            try
            {
                pictureBox2.Load(Sprite3d);
            }
            catch (Exception)
            {
                pictureBox2.Load("https://static.wikia.nocookie.net/bec6f033-936d-48c5-9c1e-7fb7207e28af/scale-to-width/755");
            }
        }

        private void Imagen3dBox_Leave(object sender, EventArgs e)
        {
            try
            {
                CargarSprite3d(Imagen3dBox.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
