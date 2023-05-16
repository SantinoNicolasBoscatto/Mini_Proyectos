using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokevatos
{
    public partial class frmPokemons : Form
    {
        //private int x = 0;
        private List<Pokemon> lista;
        public frmPokemons()
        {
            InitializeComponent();
            
        }

        private void frmPokemons_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            lista = negocio.Listar();
            dgvPokemon.DataSource = lista;
            dgvPokemon.Columns["Imagen"].Visible = false;
            CargarImagen(lista[0].Imagen);
            //this.DescripcionPDEX.Text = lista[0].Descripcion;
        }
        
        private void dgvPokemon_SelectionChanged(object sender, EventArgs e)
        {
               Pokemon select = (Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
                CargarImagen(select.Imagen);         
            
        }      
        Point mouseLoc;
        private void frmPokemons_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLoc = e.Location;
        }

        private void Off_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    private void CargarImagen(string url)
        {
            try
            {
                pbPokemon.Load(url);
            }
            catch (Exception)
            {
                pbPokemon.Load("https://static.wikia.nocookie.net/bec6f033-936d-48c5-9c1e-7fb7207e28af/scale-to-width/755");
            }
        }
        //private void CargarDescripcion(string descripcion)
        //{
        // try
        //{
        // DescripcionPDEX.Text = descripcion;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //x++;
                //CargarImagen(lista[x].Imagen);
                //CargarDescripcion(lista[x].Descripcion);
            }
            catch (Exception)
            {
                //x--;
            }

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
    }
    //catch (Exception)
    //{
    // DescripcionPDEX.Text = "???";
}
// }
//}
//private void button1_Click(object sender, EventArgs e)
//{
// try
//{
// x--;
// CargarImagen(lista[x].Imagen);
// CargarDescripcion(lista[x].Descripcion);
//}
//catch (Exception)
//{
//x++;
// }


//}

