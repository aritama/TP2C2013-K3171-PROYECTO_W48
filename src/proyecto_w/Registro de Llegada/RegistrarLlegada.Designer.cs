namespace proyecto_w.Registro_de_Llegada
{
    partial class frmRegistrarLlegada
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
            this.txtFiltroAfiliado = new System.Windows.Forms.Label();
            this.lblFiltroNombre = new System.Windows.Forms.Label();
            this.lblFiltroApellido = new System.Windows.Forms.Label();
            this.lblFiltroEspecialidad = new System.Windows.Forms.Label();
            this.txtLastnameFilter = new System.Windows.Forms.TextBox();
            this.txtAfilNro = new System.Windows.Forms.TextBox();
            this.txtNameFilter = new System.Windows.Forms.TextBox();
            this.cbxEspecialidadFilter = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.grdProfesionales = new System.Windows.Forms.DataGridView();
            this.NroProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.lblTurnos = new System.Windows.Forms.Label();
            this.grdTurnos = new System.Windows.Forms.DataGridView();
            this.lblBono = new System.Windows.Forms.Label();
            this.txtBono = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnValidar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdProfesionales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFiltroAfiliado
            // 
            this.txtFiltroAfiliado.AutoSize = true;
            this.txtFiltroAfiliado.Location = new System.Drawing.Point(43, 210);
            this.txtFiltroAfiliado.Name = "txtFiltroAfiliado";
            this.txtFiltroAfiliado.Size = new System.Drawing.Size(56, 13);
            this.txtFiltroAfiliado.TabIndex = 0;
            this.txtFiltroAfiliado.Text = "N° Afiliado";
            // 
            // lblFiltroNombre
            // 
            this.lblFiltroNombre.AutoSize = true;
            this.lblFiltroNombre.Location = new System.Drawing.Point(19, 29);
            this.lblFiltroNombre.Name = "lblFiltroNombre";
            this.lblFiltroNombre.Size = new System.Drawing.Size(99, 13);
            this.lblFiltroNombre.TabIndex = 1;
            this.lblFiltroNombre.Text = "Nombre Profesional";
            // 
            // lblFiltroApellido
            // 
            this.lblFiltroApellido.AutoSize = true;
            this.lblFiltroApellido.Location = new System.Drawing.Point(19, 57);
            this.lblFiltroApellido.Name = "lblFiltroApellido";
            this.lblFiltroApellido.Size = new System.Drawing.Size(99, 13);
            this.lblFiltroApellido.TabIndex = 2;
            this.lblFiltroApellido.Text = "Apellido Profesional";
            // 
            // lblFiltroEspecialidad
            // 
            this.lblFiltroEspecialidad.AutoSize = true;
            this.lblFiltroEspecialidad.Location = new System.Drawing.Point(19, 85);
            this.lblFiltroEspecialidad.Name = "lblFiltroEspecialidad";
            this.lblFiltroEspecialidad.Size = new System.Drawing.Size(67, 13);
            this.lblFiltroEspecialidad.TabIndex = 3;
            this.lblFiltroEspecialidad.Text = "Especialidad";
            // 
            // txtLastnameFilter
            // 
            this.txtLastnameFilter.Location = new System.Drawing.Point(124, 54);
            this.txtLastnameFilter.MaxLength = 15;
            this.txtLastnameFilter.Name = "txtLastnameFilter";
            this.txtLastnameFilter.Size = new System.Drawing.Size(159, 20);
            this.txtLastnameFilter.TabIndex = 7;
            // 
            // txtAfilNro
            // 
            this.txtAfilNro.Location = new System.Drawing.Point(22, 226);
            this.txtAfilNro.MaxLength = 10;
            this.txtAfilNro.Name = "txtAfilNro";
            this.txtAfilNro.Size = new System.Drawing.Size(100, 20);
            this.txtAfilNro.TabIndex = 5;
            this.txtAfilNro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAfilNro_KeyPress);
            // 
            // txtNameFilter
            // 
            this.txtNameFilter.Location = new System.Drawing.Point(124, 26);
            this.txtNameFilter.MaxLength = 15;
            this.txtNameFilter.Name = "txtNameFilter";
            this.txtNameFilter.Size = new System.Drawing.Size(159, 20);
            this.txtNameFilter.TabIndex = 6;
            // 
            // cbxEspecialidadFilter
            // 
            this.cbxEspecialidadFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEspecialidadFilter.FormattingEnabled = true;
            this.cbxEspecialidadFilter.Location = new System.Drawing.Point(124, 82);
            this.cbxEspecialidadFilter.Name = "cbxEspecialidadFilter";
            this.cbxEspecialidadFilter.Size = new System.Drawing.Size(159, 21);
            this.cbxEspecialidadFilter.TabIndex = 8;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(168, 109);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // grdProfesionales
            // 
            this.grdProfesionales.AllowUserToAddRows = false;
            this.grdProfesionales.AllowUserToDeleteRows = false;
            this.grdProfesionales.AllowUserToResizeColumns = false;
            this.grdProfesionales.AllowUserToResizeRows = false;
            this.grdProfesionales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProfesionales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroProfesional,
            this.NombreProfesional,
            this.ApellidoProfesional});
            this.grdProfesionales.Location = new System.Drawing.Point(289, 21);
            this.grdProfesionales.MultiSelect = false;
            this.grdProfesionales.Name = "grdProfesionales";
            this.grdProfesionales.ReadOnly = true;
            this.grdProfesionales.RowHeadersVisible = false;
            this.grdProfesionales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdProfesionales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdProfesionales.Size = new System.Drawing.Size(302, 105);
            this.grdProfesionales.TabIndex = 0;
            // 
            // NroProfesional
            // 
            this.NroProfesional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NroProfesional.DataPropertyName = "prof_cod";
            this.NroProfesional.Frozen = true;
            this.NroProfesional.HeaderText = "N° Profesional";
            this.NroProfesional.Name = "NroProfesional";
            this.NroProfesional.ReadOnly = true;
            // 
            // NombreProfesional
            // 
            this.NombreProfesional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NombreProfesional.DataPropertyName = "prof_nombre";
            this.NombreProfesional.Frozen = true;
            this.NombreProfesional.HeaderText = "Nombre";
            this.NombreProfesional.Name = "NombreProfesional";
            this.NombreProfesional.ReadOnly = true;
            // 
            // ApellidoProfesional
            // 
            this.ApellidoProfesional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ApellidoProfesional.DataPropertyName = "prof_apellido";
            this.ApellidoProfesional.Frozen = true;
            this.ApellidoProfesional.HeaderText = "Apellido";
            this.ApellidoProfesional.Name = "ApellidoProfesional";
            this.ApellidoProfesional.ReadOnly = true;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(399, 142);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionar.TabIndex = 10;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // lblTurnos
            // 
            this.lblTurnos.AutoSize = true;
            this.lblTurnos.Location = new System.Drawing.Point(286, 174);
            this.lblTurnos.Name = "lblTurnos";
            this.lblTurnos.Size = new System.Drawing.Size(97, 13);
            this.lblTurnos.TabIndex = 11;
            this.lblTurnos.Text = "Turnos Disponibles";
            // 
            // grdTurnos
            // 
            this.grdTurnos.AllowUserToAddRows = false;
            this.grdTurnos.AllowUserToDeleteRows = false;
            this.grdTurnos.AllowUserToResizeColumns = false;
            this.grdTurnos.AllowUserToResizeRows = false;
            this.grdTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdTurnos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdTurnos.ColumnHeadersHeight = 21;
            this.grdTurnos.Location = new System.Drawing.Point(143, 199);
            this.grdTurnos.MultiSelect = false;
            this.grdTurnos.Name = "grdTurnos";
            this.grdTurnos.ReadOnly = true;
            this.grdTurnos.RowHeadersVisible = false;
            this.grdTurnos.RowHeadersWidth = 50;
            this.grdTurnos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTurnos.Size = new System.Drawing.Size(448, 83);
            this.grdTurnos.TabIndex = 1;
            this.grdTurnos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.click_fila);
            this.grdTurnos.SelectionChanged += new System.EventHandler(this.seleccion_fila);
            // 
            // lblBono
            // 
            this.lblBono.AutoSize = true;
            this.lblBono.Location = new System.Drawing.Point(183, 304);
            this.lblBono.Name = "lblBono";
            this.lblBono.Size = new System.Drawing.Size(91, 13);
            this.lblBono.TabIndex = 13;
            this.lblBono.Text = "N° Bono Consulta";
            // 
            // txtBono
            // 
            this.txtBono.Enabled = false;
            this.txtBono.Location = new System.Drawing.Point(289, 301);
            this.txtBono.MaxLength = 8;
            this.txtBono.Name = "txtBono";
            this.txtBono.Size = new System.Drawing.Size(100, 20);
            this.txtBono.TabIndex = 11;
            this.txtBono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBono_KeyPress);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(235, 343);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(128, 23);
            this.btnRegistrar.TabIndex = 12;
            this.btnRegistrar.Text = "Registrar Llegada";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(22, 109);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 14;
            this.btnFilter.Text = "Filtrar";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.Location = new System.Drawing.Point(22, 252);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(100, 23);
            this.btnValidar.TabIndex = 15;
            this.btnValidar.Text = "Validar";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // frmRegistrarLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 385);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtBono);
            this.Controls.Add(this.lblBono);
            this.Controls.Add(this.grdTurnos);
            this.Controls.Add(this.lblTurnos);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.grdProfesionales);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.cbxEspecialidadFilter);
            this.Controls.Add(this.txtNameFilter);
            this.Controls.Add(this.txtAfilNro);
            this.Controls.Add(this.txtLastnameFilter);
            this.Controls.Add(this.lblFiltroEspecialidad);
            this.Controls.Add(this.lblFiltroApellido);
            this.Controls.Add(this.lblFiltroNombre);
            this.Controls.Add(this.txtFiltroAfiliado);
            this.Name = "frmRegistrarLlegada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Llegada";
            ((System.ComponentModel.ISupportInitialize)(this.grdProfesionales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtFiltroAfiliado;
        private System.Windows.Forms.Label lblFiltroNombre;
        private System.Windows.Forms.Label lblFiltroApellido;
        private System.Windows.Forms.Label lblFiltroEspecialidad;
        private System.Windows.Forms.TextBox txtLastnameFilter;
        private System.Windows.Forms.TextBox txtAfilNro;
        private System.Windows.Forms.TextBox txtNameFilter;
        private System.Windows.Forms.ComboBox cbxEspecialidadFilter;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView grdProfesionales;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoProfesional;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Label lblTurnos;
        private System.Windows.Forms.DataGridView grdTurnos;
        private System.Windows.Forms.Label lblBono;
        private System.Windows.Forms.TextBox txtBono;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnValidar;
    }
}