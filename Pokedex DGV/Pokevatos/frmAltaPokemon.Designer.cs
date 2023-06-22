
namespace Pokevatos
{
    partial class frmAltaPokemon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NombreLabel = new System.Windows.Forms.Label();
            this.NumeroLabel = new System.Windows.Forms.Label();
            this.DescripcionLabel = new System.Windows.Forms.Label();
            this.NumeroBox = new System.Windows.Forms.TextBox();
            this.NombreBox = new System.Windows.Forms.TextBox();
            this.DescripcionBox = new System.Windows.Forms.TextBox();
            this.AceptarBoton = new System.Windows.Forms.Button();
            this.CancelarBoton = new System.Windows.Forms.Button();
            this.TipoCombo = new System.Windows.Forms.Label();
            this.DebilidadCombo = new System.Windows.Forms.Label();
            this.TipoCaja = new System.Windows.Forms.ComboBox();
            this.DebilidadCaja = new System.Windows.Forms.ComboBox();
            this.UrlLabel = new System.Windows.Forms.Label();
            this.UrlCaja = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ImagenBoton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // NombreLabel
            // 
            this.NombreLabel.AutoSize = true;
            this.NombreLabel.Location = new System.Drawing.Point(39, 87);
            this.NombreLabel.Name = "NombreLabel";
            this.NombreLabel.Size = new System.Drawing.Size(58, 17);
            this.NombreLabel.TabIndex = 0;
            this.NombreLabel.Text = "Nombre";
            // 
            // NumeroLabel
            // 
            this.NumeroLabel.AutoSize = true;
            this.NumeroLabel.Location = new System.Drawing.Point(40, 29);
            this.NumeroLabel.Name = "NumeroLabel";
            this.NumeroLabel.Size = new System.Drawing.Size(58, 17);
            this.NumeroLabel.TabIndex = 1;
            this.NumeroLabel.Text = "Numero";
            // 
            // DescripcionLabel
            // 
            this.DescripcionLabel.AutoSize = true;
            this.DescripcionLabel.Location = new System.Drawing.Point(31, 150);
            this.DescripcionLabel.Name = "DescripcionLabel";
            this.DescripcionLabel.Size = new System.Drawing.Size(82, 17);
            this.DescripcionLabel.TabIndex = 2;
            this.DescripcionLabel.Text = "Descripcion";
            // 
            // NumeroBox
            // 
            this.NumeroBox.Location = new System.Drawing.Point(131, 26);
            this.NumeroBox.Name = "NumeroBox";
            this.NumeroBox.Size = new System.Drawing.Size(100, 22);
            this.NumeroBox.TabIndex = 0;
            // 
            // NombreBox
            // 
            this.NombreBox.Location = new System.Drawing.Point(130, 87);
            this.NombreBox.Name = "NombreBox";
            this.NombreBox.Size = new System.Drawing.Size(100, 22);
            this.NombreBox.TabIndex = 1;
            // 
            // DescripcionBox
            // 
            this.DescripcionBox.Location = new System.Drawing.Point(131, 147);
            this.DescripcionBox.Name = "DescripcionBox";
            this.DescripcionBox.Size = new System.Drawing.Size(100, 22);
            this.DescripcionBox.TabIndex = 2;
            // 
            // AceptarBoton
            // 
            this.AceptarBoton.Location = new System.Drawing.Point(110, 359);
            this.AceptarBoton.Name = "AceptarBoton";
            this.AceptarBoton.Size = new System.Drawing.Size(75, 28);
            this.AceptarBoton.TabIndex = 6;
            this.AceptarBoton.Text = "Aceptar";
            this.AceptarBoton.UseVisualStyleBackColor = true;
            this.AceptarBoton.Click += new System.EventHandler(this.AceptarBoton_Click);
            // 
            // CancelarBoton
            // 
            this.CancelarBoton.Location = new System.Drawing.Point(220, 359);
            this.CancelarBoton.Name = "CancelarBoton";
            this.CancelarBoton.Size = new System.Drawing.Size(84, 28);
            this.CancelarBoton.TabIndex = 7;
            this.CancelarBoton.Text = "Cancelar";
            this.CancelarBoton.UseVisualStyleBackColor = true;
            this.CancelarBoton.Click += new System.EventHandler(this.CancelarBoton_Click);
            // 
            // TipoCombo
            // 
            this.TipoCombo.AutoSize = true;
            this.TipoCombo.Location = new System.Drawing.Point(76, 269);
            this.TipoCombo.Name = "TipoCombo";
            this.TipoCombo.Size = new System.Drawing.Size(36, 17);
            this.TipoCombo.TabIndex = 8;
            this.TipoCombo.Text = "Tipo";
            // 
            // DebilidadCombo
            // 
            this.DebilidadCombo.AutoSize = true;
            this.DebilidadCombo.Location = new System.Drawing.Point(46, 312);
            this.DebilidadCombo.Name = "DebilidadCombo";
            this.DebilidadCombo.Size = new System.Drawing.Size(67, 17);
            this.DebilidadCombo.TabIndex = 9;
            this.DebilidadCombo.Text = "Debilidad";
            // 
            // TipoCaja
            // 
            this.TipoCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoCaja.FormattingEnabled = true;
            this.TipoCaja.Location = new System.Drawing.Point(130, 269);
            this.TipoCaja.Name = "TipoCaja";
            this.TipoCaja.Size = new System.Drawing.Size(100, 24);
            this.TipoCaja.TabIndex = 4;
            this.TipoCaja.SelectedIndexChanged += new System.EventHandler(this.TipoCaja_SelectedIndexChanged);
            // 
            // DebilidadCaja
            // 
            this.DebilidadCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DebilidadCaja.FormattingEnabled = true;
            this.DebilidadCaja.Location = new System.Drawing.Point(131, 309);
            this.DebilidadCaja.Name = "DebilidadCaja";
            this.DebilidadCaja.Size = new System.Drawing.Size(100, 24);
            this.DebilidadCaja.TabIndex = 5;
            // 
            // UrlLabel
            // 
            this.UrlLabel.AutoSize = true;
            this.UrlLabel.Location = new System.Drawing.Point(39, 203);
            this.UrlLabel.Name = "UrlLabel";
            this.UrlLabel.Size = new System.Drawing.Size(76, 17);
            this.UrlLabel.TabIndex = 12;
            this.UrlLabel.Text = "Url Imagen";
            // 
            // UrlCaja
            // 
            this.UrlCaja.Location = new System.Drawing.Point(130, 203);
            this.UrlCaja.Name = "UrlCaja";
            this.UrlCaja.Size = new System.Drawing.Size(100, 22);
            this.UrlCaja.TabIndex = 3;
            this.UrlCaja.Leave += new System.EventHandler(this.UrlCaja_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(248, 98);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ImagenBoton
            // 
            this.ImagenBoton.Location = new System.Drawing.Point(130, 229);
            this.ImagenBoton.Name = "ImagenBoton";
            this.ImagenBoton.Size = new System.Drawing.Size(101, 34);
            this.ImagenBoton.TabIndex = 15;
            this.ImagenBoton.Text = "Imagen PC";
            this.ImagenBoton.UseVisualStyleBackColor = true;
            this.ImagenBoton.Click += new System.EventHandler(this.ImagenBoton_Click);
            // 
            // frmAltaPokemon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 396);
            this.Controls.Add(this.ImagenBoton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.UrlCaja);
            this.Controls.Add(this.UrlLabel);
            this.Controls.Add(this.DebilidadCaja);
            this.Controls.Add(this.TipoCaja);
            this.Controls.Add(this.DebilidadCombo);
            this.Controls.Add(this.TipoCombo);
            this.Controls.Add(this.CancelarBoton);
            this.Controls.Add(this.AceptarBoton);
            this.Controls.Add(this.DescripcionBox);
            this.Controls.Add(this.NombreBox);
            this.Controls.Add(this.NumeroBox);
            this.Controls.Add(this.DescripcionLabel);
            this.Controls.Add(this.NumeroLabel);
            this.Controls.Add(this.NombreLabel);
            this.Name = "frmAltaPokemon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta Pokemon";
            this.Load += new System.EventHandler(this.frmAltaPokemon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NombreLabel;
        private System.Windows.Forms.Label NumeroLabel;
        private System.Windows.Forms.Label DescripcionLabel;
        private System.Windows.Forms.TextBox NumeroBox;
        private System.Windows.Forms.TextBox NombreBox;
        private System.Windows.Forms.TextBox DescripcionBox;
        private System.Windows.Forms.Button AceptarBoton;
        private System.Windows.Forms.Button CancelarBoton;
        private System.Windows.Forms.Label TipoCombo;
        private System.Windows.Forms.Label DebilidadCombo;
        private System.Windows.Forms.ComboBox TipoCaja;
        private System.Windows.Forms.ComboBox DebilidadCaja;
        private System.Windows.Forms.Label UrlLabel;
        private System.Windows.Forms.TextBox UrlCaja;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ImagenBoton;
    }
}