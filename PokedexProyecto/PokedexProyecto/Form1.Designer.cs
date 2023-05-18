
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPokemons));
            this.Pokedex = new System.Windows.Forms.PictureBox();
            this.PictureBoxPokemon = new System.Windows.Forms.PictureBox();
            this.SiguientePokemon = new System.Windows.Forms.Button();
            this.AnteriorPokemon = new System.Windows.Forms.Button();
            this.alphaBlendTextBox1 = new ZBobb.AlphaBlendTextBox();
            this.Apagado = new PokedexProyecto.BotonCircular();
            ((System.ComponentModel.ISupportInitialize)(this.Pokedex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPokemon)).BeginInit();
            this.SuspendLayout();
            // 
            // Pokedex
            // 
            this.Pokedex.Image = global::PokedexProyecto.Properties.Resources.Poke;
            this.Pokedex.Location = new System.Drawing.Point(-1, 0);
            this.Pokedex.Name = "Pokedex";
            this.Pokedex.Size = new System.Drawing.Size(769, 402);
            this.Pokedex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pokedex.TabIndex = 0;
            this.Pokedex.TabStop = false;
            this.Pokedex.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmPokemons_MouseDown);
            this.Pokedex.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmPokemons_MouseMove);
            // 
            // PictureBoxPokemon
            // 
            this.PictureBoxPokemon.BackColor = System.Drawing.Color.DimGray;
            this.PictureBoxPokemon.Location = new System.Drawing.Point(124, 73);
            this.PictureBoxPokemon.Name = "PictureBoxPokemon";
            this.PictureBoxPokemon.Size = new System.Drawing.Size(119, 128);
            this.PictureBoxPokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxPokemon.TabIndex = 1;
            this.PictureBoxPokemon.TabStop = false;
            // 
            // SiguientePokemon
            // 
            this.SiguientePokemon.BackColor = System.Drawing.Color.Transparent;
            this.SiguientePokemon.FlatAppearance.BorderSize = 0;
            this.SiguientePokemon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.SiguientePokemon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SiguientePokemon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SiguientePokemon.Location = new System.Drawing.Point(318, 328);
            this.SiguientePokemon.Name = "SiguientePokemon";
            this.SiguientePokemon.Size = new System.Drawing.Size(29, 32);
            this.SiguientePokemon.TabIndex = 3;
            this.SiguientePokemon.UseVisualStyleBackColor = false;
            this.SiguientePokemon.Click += new System.EventHandler(this.SiguientePokemon_Click);
            // 
            // AnteriorPokemon
            // 
            this.AnteriorPokemon.BackColor = System.Drawing.Color.Transparent;
            this.AnteriorPokemon.FlatAppearance.BorderSize = 0;
            this.AnteriorPokemon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.AnteriorPokemon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AnteriorPokemon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnteriorPokemon.Location = new System.Drawing.Point(251, 328);
            this.AnteriorPokemon.Name = "AnteriorPokemon";
            this.AnteriorPokemon.Size = new System.Drawing.Size(29, 32);
            this.AnteriorPokemon.TabIndex = 4;
            this.AnteriorPokemon.UseVisualStyleBackColor = false;
            this.AnteriorPokemon.Click += new System.EventHandler(this.AnteriorPokemon_Click);
            // 
            // alphaBlendTextBox1
            // 
            this.alphaBlendTextBox1.BackAlpha = 10;
            this.alphaBlendTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.alphaBlendTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alphaBlendTextBox1.Font = new System.Drawing.Font("Microsoft YaHei", 9.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alphaBlendTextBox1.Location = new System.Drawing.Point(450, 49);
            this.alphaBlendTextBox1.Multiline = true;
            this.alphaBlendTextBox1.Name = "alphaBlendTextBox1";
            this.alphaBlendTextBox1.ReadOnly = true;
            this.alphaBlendTextBox1.Size = new System.Drawing.Size(281, 111);
            this.alphaBlendTextBox1.TabIndex = 5;
            // 
            // Apagado
            // 
            this.Apagado.BackColor = System.Drawing.Color.Transparent;
            this.Apagado.FlatAppearance.BorderSize = 0;
            this.Apagado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Apagado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.Apagado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Apagado.ForeColor = System.Drawing.Color.Transparent;
            this.Apagado.Location = new System.Drawing.Point(31, 291);
            this.Apagado.Name = "Apagado";
            this.Apagado.Size = new System.Drawing.Size(58, 60);
            this.Apagado.TabIndex = 2;
            this.Apagado.UseVisualStyleBackColor = false;
            this.Apagado.Click += new System.EventHandler(this.Apagado_Click);
            // 
            // frmPokemons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 398);
            this.Controls.Add(this.alphaBlendTextBox1);
            this.Controls.Add(this.AnteriorPokemon);
            this.Controls.Add(this.SiguientePokemon);
            this.Controls.Add(this.Apagado);
            this.Controls.Add(this.PictureBoxPokemon);
            this.Controls.Add(this.Pokedex);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPokemons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmPokemons_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmPokemons_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmPokemons_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.Pokedex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPokemon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Pokedex;
        private System.Windows.Forms.PictureBox PictureBoxPokemon;
        private BotonCircular Apagado;
        private System.Windows.Forms.Button SiguientePokemon;
        private System.Windows.Forms.Button AnteriorPokemon;
        private ZBobb.AlphaBlendTextBox alphaBlendTextBox1;
    }
}

