using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using NAudio.Wave;
using ModeloDeDominio;
using ClaseNegocio;

namespace PokedexProyecto
{
    public partial class frmPokemons : Form
    {
        int x = 0;
        List<Pokemon> listaDePokemones = new List<Pokemon>();
        public frmPokemons()
        {
            InitializeComponent();
            PictureBoxPokemon.BackColor = Color.Transparent;
            PictureBoxPokemon.Parent = Pokedex;
            PictureBoxPokemon.Visible = true;
            Apagado.BackColor = Color.Transparent;
            Apagado.Parent = Pokedex;
            Apagado.Visible = true;
            SiguientePokemon.BackColor = Color.Transparent;
            SiguientePokemon.Parent = Pokedex;
            SiguientePokemon.Visible = true;
            AnteriorPokemon.BackColor = Color.Transparent;
            AnteriorPokemon.Parent = Pokedex;
            AnteriorPokemon.Visible = true;
            Buscar.BackColor = Color.Transparent;
            Buscar.Parent = Pokedex;
            Buscar.Visible = true;
            Sprite3d.BackColor = Color.Transparent;
            Sprite3d.Parent = Pokedex;
            Sprite3d.Visible = true;
            GritoBoton.BackColor = Color.Transparent;
            GritoBoton.Parent = Pokedex;
            GritoBoton.Visible = true;
            NumeroBox.Parent = Pokedex;
            NumeroBox.Visible = true;
            alphaBlendTextBox1.Parent = Pokedex;
            alphaBlendTextBox1.Visible = true;
            Agregar.Parent = Pokedex;
            Agregar.Visible = true;
        }
        bool bdSprite = true; 
        public void CargarTabla ()
        {
            ConexionPokemonDataBase PokemonNegocio = new ConexionPokemonDataBase();
            listaDePokemones = PokemonNegocio.ListarPokemon();
            CargarSprite(listaDePokemones[x].Sprite);
            CargarEntradaPokedex(listaDePokemones[x].DescripcionDePokemon);
            CargarNumeroPokedex(listaDePokemones[x].NumeroPokedex);
            using (AudioFileReader audioFileReader = new AudioFileReader(listaDePokemones[x].GritoPokemon))
            {
                using (WaveOutEvent waveOutEvent = new WaveOutEvent())
                {
                    // Bajar el volumen a la mitad (0.5)
                    waveOutEvent.Volume = 0.05f;

                    // Conectar el AudioFileReader al WaveOutEvent
                    waveOutEvent.Init(audioFileReader);

                    // Reproducir el sonido con el volumen ajustado
                    waveOutEvent.Play();
                }

            }
            using (SoundPlayer Cry = new SoundPlayer(listaDePokemones[x].GritoPokemon))
            {
                Cry.Play();
            }
        }
        private void frmPokemons_Load(object sender, EventArgs e)
        {
            CargarTabla();
            
        }

        private void CargarSprite(string Sprite2d)
        {
            try
            {
                PictureBoxPokemon.Load(Sprite2d);
            }
            catch (Exception)
            {
                PictureBoxPokemon.Load("https://static.wikia.nocookie.net/bec6f033-936d-48c5-9c1e-7fb7207e28af/scale-to-width/755");
            }
        }
        private void CargarEntradaPokedex(string descripcion)
        {
            try
            {
                alphaBlendTextBox1.Text = descripcion;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void CargarNumeroPokedex(int num)
        {
            try
            {
                NumeroBox.Text = num.ToString();
            }
            catch (Exception)
            {
                NumeroBox.Text = "Error";
            }
            
        }
        private void CargarGrito()
        {
            try
            {
                using (SoundPlayer Cry = new SoundPlayer(listaDePokemones[x].GritoPokemon))
                { Cry.Play(); }
            }
            catch (Exception)
            {
                throw;
            }

        }
        private void Apagado_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Point mouseLoc;
        private void frmPokemons_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLoc = e.Location;
        }
        private void frmPokemons_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.Location.X - mouseLoc.X;
                int dy = e.Location.Y - mouseLoc.Y;
                dx += this.Location.X;
                dy += this.Location.Y;
                this.Location = new Point(dx, dy);
            }
        }
        private void SiguientePokemon_Click(object sender, EventArgs e)
        {
            try
            {x++; 
             CargarTabla();
             Sprite3d.Text = "3D";
                if (!bdSprite)
                {
                    bdSprite = true;
                }
            }
            catch (Exception)
            {x--;}     
        }
        private void AnteriorPokemon_Click(object sender, EventArgs e)
        {
            try
            {x--;
             CargarTabla();
             Sprite3d.Text = "3D";
                if (!bdSprite)
                {
                    bdSprite = true;
                }
            }
            catch (Exception)
            {x++;}
        }
        private void GritoBoton_Click(object sender, EventArgs e)
        {
            CargarGrito();
        }
        private void Agregar_Click(object sender, EventArgs e)
        {   
            Form2 segundaVentana = new Form2();
            segundaVentana.ShowDialog();
            CargarTabla();
        }
        private void Sprite3d_Click(object sender, EventArgs e)
        {
            try
            {
                if (bdSprite)
                {
                    CargarSprite(listaDePokemones[x].Sprite3d);
                    CargarGrito();
                    bdSprite = false;
                    Sprite3d.Text = "2D";
                }
                else
                {
                    CargarSprite(listaDePokemones[x].Sprite);
                    CargarGrito();
                    bdSprite = true;
                    Sprite3d.Text = "3D";
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        int y;
        private void Buscar_Click(object sender, EventArgs e)
        {
            y = x;
            x = int.Parse(NumeroBox.Text);
            try
            {
                if (x == listaDePokemones[x - 1].NumeroPokedex)
                {
                    x = x - 1;
                    CargarTabla();
                }
                else
                {
                    x = y;
                    y = y + 1;
                    NumeroBox.Text = y.ToString("0");
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("El Pokemon no existe");
                x = y;
                y = y + 1;
                NumeroBox.Text = y.ToString("0");
            }
        }
    }
}
