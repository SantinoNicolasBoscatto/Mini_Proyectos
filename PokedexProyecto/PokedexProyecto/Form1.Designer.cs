
namespace PokedexProyecto
{
    partial class frmPokemons
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Pokedex = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Pokedex)).BeginInit();
            this.SuspendLayout();
            // 
            // Pokedex
            // 
            this.Pokedex.Image = global::PokedexProyecto.Properties.Resources.Poke;
            this.Pokedex.Location = new System.Drawing.Point(-1, -2);
            this.Pokedex.Name = "Pokedex";
            this.Pokedex.Size = new System.Drawing.Size(775, 410);
            this.Pokedex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pokedex.TabIndex = 0;
            this.Pokedex.TabStop = false;
            this.Pokedex.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmPokemons_MouseDown);
            this.Pokedex.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmPokemons_MouseMove);
            // 
            // frmPokemons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 407);
            this.Controls.Add(this.Pokedex);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPokemons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmPokemons_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmPokemons_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.Pokedex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Pokedex;
    }
}

