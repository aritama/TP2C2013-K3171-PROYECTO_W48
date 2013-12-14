namespace proyecto_w.Pedido_Turno
{
    partial class PedidoTurnoForm
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
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnselec_profesional = new System.Windows.Forms.Button();
            this.grdProfesionales = new System.Windows.Forms.DataGridView();
            this.NroProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cbxEspecialidadFilter = new System.Windows.Forms.ComboBox();
            this.txtNameFilter = new System.Windows.Forms.TextBox();
            this.txtLastnameFilter = new System.Windows.Forms.TextBox();
            this.lblFiltroEspecialidad = new System.Windows.Forms.Label();
            this.lblFiltroApellido = new System.Windows.Forms.Label();
            this.lblFiltroNombre = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdDias = new System.Windows.Forms.DataGridView();
            this.btnselec_dia = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdTurnos = new System.Windows.Forms.DataGridView();
            this.btnregis_turno = new System.Windows.Forms.Button();
            this.cbTurnos = new System.Windows.Forms.ComboBox();
            this.txtNro_Afil = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxEspecialidad = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdProfesionales)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDias)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(18, 156);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(96, 23);
            this.btnFiltrar.TabIndex = 24;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnselec_profesional
            // 
            this.btnselec_profesional.Location = new System.Drawing.Point(285, 156);
            this.btnselec_profesional.Name = "btnselec_profesional";
            this.btnselec_profesional.Size = new System.Drawing.Size(302, 23);
            this.btnselec_profesional.TabIndex = 23;
            this.btnselec_profesional.Text = "Seleccionar";
            this.btnselec_profesional.UseVisualStyleBackColor = true;
            this.btnselec_profesional.Click += new System.EventHandler(this.btnselec_profesional_Click);
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
            this.grdProfesionales.Location = new System.Drawing.Point(285, 35);
            this.grdProfesionales.MultiSelect = false;
            this.grdProfesionales.Name = "grdProfesionales";
            this.grdProfesionales.ReadOnly = true;
            this.grdProfesionales.RowHeadersVisible = false;
            this.grdProfesionales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdProfesionales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdProfesionales.Size = new System.Drawing.Size(302, 105);
            this.grdProfesionales.TabIndex = 15;
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
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(154, 156);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(101, 23);
            this.btnLimpiar.TabIndex = 22;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cbxEspecialidadFilter
            // 
            this.cbxEspecialidadFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEspecialidadFilter.FormattingEnabled = true;
            this.cbxEspecialidadFilter.Location = new System.Drawing.Point(120, 96);
            this.cbxEspecialidadFilter.Name = "cbxEspecialidadFilter";
            this.cbxEspecialidadFilter.Size = new System.Drawing.Size(159, 21);
            this.cbxEspecialidadFilter.TabIndex = 21;
            // 
            // txtNameFilter
            // 
            this.txtNameFilter.Location = new System.Drawing.Point(120, 40);
            this.txtNameFilter.MaxLength = 15;
            this.txtNameFilter.Name = "txtNameFilter";
            this.txtNameFilter.Size = new System.Drawing.Size(159, 20);
            this.txtNameFilter.TabIndex = 19;
            // 
            // txtLastnameFilter
            // 
            this.txtLastnameFilter.Location = new System.Drawing.Point(120, 68);
            this.txtLastnameFilter.MaxLength = 15;
            this.txtLastnameFilter.Name = "txtLastnameFilter";
            this.txtLastnameFilter.Size = new System.Drawing.Size(159, 20);
            this.txtLastnameFilter.TabIndex = 20;
            // 
            // lblFiltroEspecialidad
            // 
            this.lblFiltroEspecialidad.AutoSize = true;
            this.lblFiltroEspecialidad.Location = new System.Drawing.Point(15, 99);
            this.lblFiltroEspecialidad.Name = "lblFiltroEspecialidad";
            this.lblFiltroEspecialidad.Size = new System.Drawing.Size(67, 13);
            this.lblFiltroEspecialidad.TabIndex = 18;
            this.lblFiltroEspecialidad.Text = "Especialidad";
            // 
            // lblFiltroApellido
            // 
            this.lblFiltroApellido.AutoSize = true;
            this.lblFiltroApellido.Location = new System.Drawing.Point(15, 71);
            this.lblFiltroApellido.Name = "lblFiltroApellido";
            this.lblFiltroApellido.Size = new System.Drawing.Size(99, 13);
            this.lblFiltroApellido.TabIndex = 17;
            this.lblFiltroApellido.Text = "Apellido Profesional";
            // 
            // lblFiltroNombre
            // 
            this.lblFiltroNombre.AutoSize = true;
            this.lblFiltroNombre.Location = new System.Drawing.Point(15, 43);
            this.lblFiltroNombre.Name = "lblFiltroNombre";
            this.lblFiltroNombre.Size = new System.Drawing.Size(99, 13);
            this.lblFiltroNombre.TabIndex = 16;
            this.lblFiltroNombre.Text = "Nombre Profesional";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdProfesionales);
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Controls.Add(this.lblFiltroNombre);
            this.groupBox1.Controls.Add(this.btnselec_profesional);
            this.groupBox1.Controls.Add(this.lblFiltroApellido);
            this.groupBox1.Controls.Add(this.lblFiltroEspecialidad);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.txtLastnameFilter);
            this.groupBox1.Controls.Add(this.cbxEspecialidadFilter);
            this.groupBox1.Controls.Add(this.txtNameFilter);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 192);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profesional";
            // 
            // grdDias
            // 
            this.grdDias.AllowUserToAddRows = false;
            this.grdDias.AllowUserToDeleteRows = false;
            this.grdDias.AllowUserToResizeColumns = false;
            this.grdDias.AllowUserToResizeRows = false;
            this.grdDias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdDias.Location = new System.Drawing.Point(16, 31);
            this.grdDias.MultiSelect = false;
            this.grdDias.Name = "grdDias";
            this.grdDias.ReadOnly = true;
            this.grdDias.RowHeadersVisible = false;
            this.grdDias.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdDias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDias.Size = new System.Drawing.Size(239, 197);
            this.grdDias.TabIndex = 26;
            // 
            // btnselec_dia
            // 
            this.btnselec_dia.Location = new System.Drawing.Point(16, 234);
            this.btnselec_dia.Name = "btnselec_dia";
            this.btnselec_dia.Size = new System.Drawing.Size(239, 23);
            this.btnselec_dia.TabIndex = 28;
            this.btnselec_dia.Text = "Seleccionar";
            this.btnselec_dia.UseVisualStyleBackColor = true;
            this.btnselec_dia.Click += new System.EventHandler(this.btnselec_dia_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtNro_Afil);
            this.groupBox2.Controls.Add(this.grdDias);
            this.groupBox2.Controls.Add(this.btnselec_dia);
            this.groupBox2.Location = new System.Drawing.Point(12, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 304);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dias Agenda Profesional";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxEspecialidad);
            this.groupBox3.Controls.Add(this.cbTurnos);
            this.groupBox3.Controls.Add(this.grdTurnos);
            this.groupBox3.Controls.Add(this.btnregis_turno);
            this.groupBox3.Location = new System.Drawing.Point(321, 210);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(296, 304);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Turnos ya asignados";
            // 
            // grdTurnos
            // 
            this.grdTurnos.AllowUserToAddRows = false;
            this.grdTurnos.AllowUserToDeleteRows = false;
            this.grdTurnos.AllowUserToResizeColumns = false;
            this.grdTurnos.AllowUserToResizeRows = false;
            this.grdTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTurnos.Location = new System.Drawing.Point(25, 31);
            this.grdTurnos.MultiSelect = false;
            this.grdTurnos.Name = "grdTurnos";
            this.grdTurnos.ReadOnly = true;
            this.grdTurnos.RowHeadersVisible = false;
            this.grdTurnos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTurnos.Size = new System.Drawing.Size(239, 169);
            this.grdTurnos.TabIndex = 26;
            // 
            // btnregis_turno
            // 
            this.btnregis_turno.Location = new System.Drawing.Point(25, 260);
            this.btnregis_turno.Name = "btnregis_turno";
            this.btnregis_turno.Size = new System.Drawing.Size(239, 23);
            this.btnregis_turno.TabIndex = 28;
            this.btnregis_turno.Text = "Registrar";
            this.btnregis_turno.UseVisualStyleBackColor = true;
            this.btnregis_turno.Click += new System.EventHandler(this.btnregis_turno_Click);
            // 
            // cbTurnos
            // 
            this.cbTurnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTurnos.FormattingEnabled = true;
            this.cbTurnos.Location = new System.Drawing.Point(25, 206);
            this.cbTurnos.Name = "cbTurnos";
            this.cbTurnos.Size = new System.Drawing.Size(239, 21);
            this.cbTurnos.TabIndex = 29;
            // 
            // txtNro_Afil
            // 
            this.txtNro_Afil.Location = new System.Drawing.Point(111, 264);
            this.txtNro_Afil.Name = "txtNro_Afil";
            this.txtNro_Afil.Size = new System.Drawing.Size(144, 20);
            this.txtNro_Afil.TabIndex = 29;
            this.txtNro_Afil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNro_Afil_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nro Afiliado";
            // 
            // cbxEspecialidad
            // 
            this.cbxEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEspecialidad.FormattingEnabled = true;
            this.cbxEspecialidad.Location = new System.Drawing.Point(25, 233);
            this.cbxEspecialidad.Name = "cbxEspecialidad";
            this.cbxEspecialidad.Size = new System.Drawing.Size(239, 21);
            this.cbxEspecialidad.TabIndex = 30;
            // 
            // PedidoTurnoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 524);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PedidoTurnoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pedido Turno";
            ((System.ComponentModel.ISupportInitialize)(this.grdProfesionales)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDias)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTurnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnselec_profesional;
        private System.Windows.Forms.DataGridView grdProfesionales;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoProfesional;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ComboBox cbxEspecialidadFilter;
        private System.Windows.Forms.TextBox txtNameFilter;
        private System.Windows.Forms.TextBox txtLastnameFilter;
        private System.Windows.Forms.Label lblFiltroEspecialidad;
        private System.Windows.Forms.Label lblFiltroApellido;
        private System.Windows.Forms.Label lblFiltroNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdDias;
        private System.Windows.Forms.Button btnselec_dia;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView grdTurnos;
        private System.Windows.Forms.Button btnregis_turno;
        private System.Windows.Forms.ComboBox cbTurnos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNro_Afil;
        private System.Windows.Forms.ComboBox cbxEspecialidad;
    }
}