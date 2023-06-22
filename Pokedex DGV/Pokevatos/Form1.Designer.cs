
namespace Pokevatos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPokemons));
            this.pbPokemon = new System.Windows.Forms.PictureBox();
            this.dgvPokemon = new System.Windows.Forms.DataGridView();
            this.Off = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.AgregarBoton = new System.Windows.Forms.Button();
            this.ModificarBoton = new System.Windows.Forms.Button();
            this.BotonEliminar = new System.Windows.Forms.Button();
            this.FiltroBoton = new System.Windows.Forms.Button();
            this.FiltroBox = new System.Windows.Forms.TextBox();
            this.FiltroAvanzadoBoton = new System.Windows.Forms.Button();
            this.CampoComboBox = new System.Windows.Forms.ComboBox();
            this.CriterioComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FiltroAvanzadoBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPokemon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPokemon)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPokemon
            // 
            this.pbPokemon.BackColor = System.Drawing.Color.Transparent;
            this.pbPokemon.Location = new System.Drawing.Point(252, 3);
            this.pbPokemon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbPokemon.Name = "pbPokemon";
            this.pbPokemon.Size = new System.Drawing.Size(195, 171);
            this.pbPokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPokemon.TabIndex = 4;
            this.pbPokemon.TabStop = false;
            // 
            // dgvPokemon
            // 
            this.dgvPokemon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPokemon.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPokemon.Location = new System.Drawing.Point(12, 198);
            this.dgvPokemon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPokemon.MultiSelect = false;
            this.dgvPokemon.Name = "dgvPokemon";
            this.dgvPokemon.RowHeadersWidth = 51;
            this.dgvPokemon.RowTemplate.Height = 24;
            this.dgvPokemon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPokemon.Size = new System.Drawing.Size(781, 279);
            this.dgvPokemon.TabIndex = 3;
            this.dgvPokemon.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPokemon_DataError);
            this.dgvPokemon.SelectionChanged += new System.EventHandler(this.dgvPokemon_SelectionChanged);
            // 
            // Off
            // 
            this.Off.BackColor = System.Drawing.Color.Transparent;
            this.Off.FlatAppearance.BorderSize = 0;
            this.Off.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Off.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Off.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Off.Location = new System.Drawing.Point(12, 129);
            this.Off.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Off.Name = "Off";
            this.Off.Size = new System.Drawing.Size(61, 55);
            this.Off.TabIndex = 5;
            this.Off.UseVisualStyleBackColor = false;
            this.Off.Click += new System.EventHandler(this.Off_Click);
            // 
            // AgregarBoton
            // 
            this.AgregarBoton.Location = new System.Drawing.Point(12, 10);
            this.AgregarBoton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AgregarBoton.Name = "AgregarBoton";
            this.AgregarBoton.Size = new System.Drawing.Size(83, 48);
            this.AgregarBoton.TabIndex = 10;
            this.AgregarBoton.Text = "Agregar";
            this.AgregarBoton.UseVisualStyleBackColor = true;
            this.AgregarBoton.Click += new System.EventHandler(this.AgregarBoton_Click);
            // 
            // ModificarBoton
            // 
            this.ModificarBoton.Location = new System.Drawing.Point(120, 11);
            this.ModificarBoton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ModificarBoton.Name = "ModificarBoton";
            this.ModificarBoton.Size = new System.Drawing.Size(87, 48);
            this.ModificarBoton.TabIndex = 11;
            this.ModificarBoton.Text = "Modificar";
            this.ModificarBoton.UseVisualStyleBackColor = true;
            this.ModificarBoton.Click += new System.EventHandler(this.ModificarBoton_Click);
            // 
            // BotonEliminar
            // 
            this.BotonEliminar.Location = new System.Drawing.Point(12, 76);
            this.BotonEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.BotonEliminar.Name = "BotonEliminar";
            this.BotonEliminar.Size = new System.Drawing.Size(83, 47);
            this.BotonEliminar.TabIndex = 12;
            this.BotonEliminar.Text = "Eliminar";
            this.BotonEliminar.UseVisualStyleBackColor = true;
            this.BotonEliminar.Click += new System.EventHandler(this.BotonEliminar_Click);
            // 
            // FiltroBoton
            // 
            this.FiltroBoton.Location = new System.Drawing.Point(111, 113);
            this.FiltroBoton.Name = "FiltroBoton";
            this.FiltroBoton.Size = new System.Drawing.Size(108, 49);
            this.FiltroBoton.TabIndex = 13;
            this.FiltroBoton.Text = "Filtro";
            this.FiltroBoton.UseVisualStyleBackColor = true;
            this.FiltroBoton.Click += new System.EventHandler(this.FiltroBoton_Click_1);
            // 
            // FiltroBox
            // 
            this.FiltroBox.Location = new System.Drawing.Point(111, 76);
            this.FiltroBox.Name = "FiltroBox";
            this.FiltroBox.Size = new System.Drawing.Size(108, 22);
            this.FiltroBox.TabIndex = 14;
            this.FiltroBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FiltroBox_KeyUp);
            // 
            // FiltroAvanzadoBoton
            // 
            this.FiltroAvanzadoBoton.Location = new System.Drawing.Point(568, 115);
            this.FiltroAvanzadoBoton.Name = "FiltroAvanzadoBoton";
            this.FiltroAvanzadoBoton.Size = new System.Drawing.Size(108, 44);
            this.FiltroAvanzadoBoton.TabIndex = 15;
            this.FiltroAvanzadoBoton.Text = "Avanzado";
            this.FiltroAvanzadoBoton.UseVisualStyleBackColor = true;
            this.FiltroAvanzadoBoton.Click += new System.EventHandler(this.FiltroAvanzadoBoton_Click);
            // 
            // CampoComboBox
            // 
            this.CampoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CampoComboBox.FormattingEnabled = true;
            this.CampoComboBox.Location = new System.Drawing.Point(453, 44);
            this.CampoComboBox.Name = "CampoComboBox";
            this.CampoComboBox.Size = new System.Drawing.Size(109, 24);
            this.CampoComboBox.TabIndex = 16;
            this.CampoComboBox.SelectedIndexChanged += new System.EventHandler(this.CampoComboBox_SelectedIndexChanged);
            // 
            // CriterioComboBox
            // 
            this.CriterioComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CriterioComboBox.FormattingEnabled = true;
            this.CriterioComboBox.Location = new System.Drawing.Point(568, 44);
            this.CriterioComboBox.Name = "CriterioComboBox";
            this.CriterioComboBox.Size = new System.Drawing.Size(113, 24);
            this.CriterioComboBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(486, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Campo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(597, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Criterio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(720, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Filtro";
            // 
            // FiltroAvanzadoBox
            // 
            this.FiltroAvanzadoBox.Location = new System.Drawing.Point(687, 44);
            this.FiltroAvanzadoBox.Name = "FiltroAvanzadoBox";
            this.FiltroAvanzadoBox.Size = new System.Drawing.Size(108, 22);
            this.FiltroAvanzadoBox.TabIndex = 22;
            // 
            // frmPokemons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 489);
            this.Controls.Add(this.FiltroAvanzadoBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CriterioComboBox);
            this.Controls.Add(this.CampoComboBox);
            this.Controls.Add(this.FiltroAvanzadoBoton);
            this.Controls.Add(this.FiltroBox);
            this.Controls.Add(this.FiltroBoton);
            this.Controls.Add(this.BotonEliminar);
            this.Controls.Add(this.ModificarBoton);
            this.Controls.Add(this.AgregarBoton);
            this.Controls.Add(this.Off);
            this.Controls.Add(this.pbPokemon);
            this.Controls.Add(this.dgvPokemon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPokemons";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pokedex";
            this.Load += new System.EventHandler(this.frmPokemons_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmPokemons_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmPokemons_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pbPokemon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPokemon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbPokemon;
        private System.Windows.Forms.DataGridView dgvPokemon;
        private System.Windows.Forms.Button Off;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button AgregarBoton;
        private System.Windows.Forms.Button ModificarBoton;
        private System.Windows.Forms.Button BotonEliminar;
        private System.Windows.Forms.Button FiltroBoton;
        private System.Windows.Forms.TextBox FiltroBox;
        private System.Windows.Forms.Button FiltroAvanzadoBoton;
        private System.Windows.Forms.ComboBox CampoComboBox;
        private System.Windows.Forms.ComboBox CriterioComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FiltroAvanzadoBox;
    }
}

