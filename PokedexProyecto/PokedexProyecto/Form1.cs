using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            alphaBlendTextBox1.Parent = Pokedex;
            alphaBlendTextBox1.Visible = true;
        }


        private void frmPokemons_Load(object sender, EventArgs e)
        {
            ConexionPokemonDataBase PokemonNegocio = new ConexionPokemonDataBase();
            listaDePokemones = PokemonNegocio.Listar();
            CargarSprite(listaDePokemones[x].Sprite);
            CargarEntradaPokedex(listaDePokemones[0].DescripcionDePokemon);

            
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
            {
                x++;
                CargarSprite(listaDePokemones[x].Sprite);
                CargarEntradaPokedex(listaDePokemones[x].DescripcionDePokemon);
            }
            catch (Exception)
            {
                x--;
            } 
            
        }

        private void AnteriorPokemon_Click(object sender, EventArgs e)
        {
            try
            {
                x--;
                CargarSprite(listaDePokemones[x].Sprite);
                CargarEntradaPokedex(listaDePokemones[x].DescripcionDePokemon);
            }
            catch (Exception)
            {
                x++;
            }
        }
    }
}
