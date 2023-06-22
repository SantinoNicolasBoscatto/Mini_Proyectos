using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModeloDeDominio;
using Negocio;

namespace Pokevatos
{
    public partial class frmPokemons : Form
    {
        private List<Pokemon> lista;
        private List<Elemento> listaElem;
        public frmPokemons()
        {
            InitializeComponent();
            
        }

        private void frmPokemons_Load(object sender, EventArgs e)
        {
            CampoComboBox.Items.Add("Numero");
            CampoComboBox.Items.Add("Nombre");
            CampoComboBox.Items.Add("Descripcion");
            ActualizarGrilla();
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

        private void AgregarBoton_Click(object sender, EventArgs e)
        {
            frmAltaPokemon alta = new frmAltaPokemon();
            alta.ShowDialog();
            ActualizarGrilla();
        }
        private void ActualizarGrilla()
        {
            PokemonNegocio negocio = new PokemonNegocio();
            TipoNegocio negocioElem = new TipoNegocio();
            try
            {
                lista = negocio.Listar();
                listaElem = negocioElem.ListarElementos();
                dgvPokemon.DataSource = lista;
                dgvPokemon.Columns["Imagen"].Visible = false;
                dgvPokemon.Columns["Id"].Visible = false;
                dgvPokemon.Columns["Activo"].Visible = false;
                CargarImagen(lista[0].Imagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ModificarBoton_Click(object sender, EventArgs e)
        {
            // Pasaje de parametros mediante el constructor
            Pokemon seleccionadoParaModificar = (Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
            bool bd = false;
            frmAltaPokemon modificar = new frmAltaPokemon(seleccionadoParaModificar, bd);
            modificar.ShowDialog();
            ActualizarGrilla();
        }

        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            DialogResult validacion= MessageBox.Show("Quiere Eliminar?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if(validacion==DialogResult.OK)
            {
                PokemonNegocio negocio = new PokemonNegocio();
                Pokemon poke = (Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
                //negocio.Eliminar(poke);
                negocio.EliminarLogica(poke);
                ActualizarGrilla();
                MessageBox.Show("Eliminado");
            }
            
        }

        private void FiltroBoton_Click(object sender, EventArgs e)
        {

        }


        private void FiltroBox_KeyUp(object sender, KeyEventArgs e)
        {
            List<Pokemon> listaFiltrada;
            listaFiltrada = lista.FindAll(Index => Index.Nombre.ToUpper().Contains(FiltroBox.Text.ToUpper()) || Index.NumeroPokedex.ToString().Contains(FiltroBox.Text) || Index.Tipo.Descripcion.ToUpper().Contains(FiltroBox.Text.ToUpper()));
            if (FiltroBox.Text.Length >= 2)
                dgvPokemon.DataSource = listaFiltrada;
            else
                dgvPokemon.DataSource = lista;
        }

        private void CampoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CampoComboBox.Text == "Numero")
            {
                CriterioComboBox.Items.Clear();
                CriterioComboBox.Items.Add("Es Mayor a");
                CriterioComboBox.Items.Add("Es Menor a");
                CriterioComboBox.Items.Add("Es Igual a");
            }
            else
            {
                CriterioComboBox.Items.Clear();
                CriterioComboBox.Items.Add("Empieza Por");
                CriterioComboBox.Items.Add("Termina Por");
                CriterioComboBox.Items.Add("Contiene");
            }
        }

        private bool ValidarFiltro()
        {
            if(CampoComboBox.SelectedIndex<0)
            {
                MessageBox.Show("Campo Mal Cargado, Porfavor seleccione un Campo");
                return true;
            }
                
            if (CriterioComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Criterio Mal Cargado, Porfavor seleccione un Criterio");
                return true;
            }

            if (FiltroAvanzadoBox.Text=="")
            {
                MessageBox.Show("El Filtro no puede estar vacio, vuelva a cargar el filtro");
                return true;
            }
            if (CampoComboBox.Text =="Numero")
            {
                if (SoloNumeros(FiltroAvanzadoBox.Text))
                {
                    MessageBox.Show("Ingreso Letras Con el fitro numerico, por favor corrija este error");
                    return SoloNumeros(FiltroAvanzadoBox.Text);
                }
            }
            return false;
        }

        private bool SoloNumeros(string validar)
        {
            foreach (char caracter in validar)
            {
                if (!(char.IsNumber(caracter)))
                    return true;
            }
            return false;
        }
        private void FiltroAvanzadoBoton_Click(object sender, EventArgs e)
        {
            try
            {
                string campo = CampoComboBox.Text;
                string criterio = CriterioComboBox.Text;
                string texto = FiltroAvanzadoBox.Text;
                if(!(ValidarFiltro()))
                {
                    PokemonNegocio negocioAvanzado = new PokemonNegocio();
                    dgvPokemon.DataSource = negocioAvanzado.FiltroAvanzado(campo, criterio, texto);
                }               
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void dgvPokemon_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("SEXOOOOOOOOOOOOOO");
        }

        private void FiltroBoton_Click_1(object sender, EventArgs e)
        {

        }
    }
    //catch (Exception)
    //{
    // DescripcionPDEX.Text = "???";
}


