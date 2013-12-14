namespace proyecto_w.ABM_Profesional
{
    partial class frmABMProfesional
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
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.lblNro = new System.Windows.Forms.Label();
            this.grdConsulta = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nro_dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_nac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClean = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(221, 13);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 13;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(115, 15);
            this.txtFiltro.MaxLength = 8;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(100, 20);
            this.txtFiltro.TabIndex = 12;
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltro_KeyPress);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(-83, 38);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(59, 13);
            this.lblFiltro.TabIndex = 11;
            this.lblFiltro.Text = "N° Afiliado:";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(607, 13);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(688, 13);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(75, 23);
            this.btnBaja.TabIndex = 8;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(526, 13);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(75, 23);
            this.btnAlta.TabIndex = 7;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // lblNro
            // 
            this.lblNro.AutoSize = true;
            this.lblNro.Location = new System.Drawing.Point(21, 18);
            this.lblNro.Name = "lblNro";
            this.lblNro.Size = new System.Drawing.Size(74, 13);
            this.lblNro.TabIndex = 14;
            this.lblNro.Text = "N° Profesional";
            // 
            // grdConsulta
            // 
            this.grdConsulta.AllowUserToAddRows = false;
            this.grdConsulta.AllowUserToDeleteRows = false;
            this.grdConsulta.AllowUserToResizeColumns = false;
            this.grdConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdConsulta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nombre,
            this.Apellido,
            this.Username,
            this.tipo_dni,
            this.nro_dni,
            this.mail,
            this.Direccion,
            this.Telefono,
            this.fecha_nac,
            this.sexo,
            this.matricula});
            this.grdConsulta.Location = new System.Drawing.Point(12, 53);
            this.grdConsulta.MultiSelect = false;
            this.grdConsulta.Name = "grdConsulta";
            this.grdConsulta.RowHeadersVisible = false;
            this.grdConsulta.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdConsulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdConsulta.ShowCellErrors = false;
            this.grdConsulta.ShowEditingIcon = false;
            this.grdConsulta.ShowRowErrors = false;
            this.grdConsulta.Size = new System.Drawing.Size(751, 383);
            this.grdConsulta.TabIndex = 15;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "prof_cod";
            this.Codigo.Frozen = true;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 50;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "prof_nombre";
            this.Nombre.Frozen = true;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 60;
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "prof_apellido";
            this.Apellido.Frozen = true;
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            this.Apellido.Width = 60;
            // 
            // Username
            // 
            this.Username.DataPropertyName = "prof_username";
            this.Username.Frozen = true;
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            this.Username.Width = 60;
            // 
            // tipo_dni
            // 
            this.tipo_dni.DataPropertyName = "prof_doc_tipo";
            this.tipo_dni.Frozen = true;
            this.tipo_dni.HeaderText = "Tipo Documento";
            this.tipo_dni.Name = "tipo_dni";
            this.tipo_dni.ReadOnly = true;
            this.tipo_dni.Width = 65;
            // 
            // nro_dni
            // 
            this.nro_dni.DataPropertyName = "prof_doc_nro";
            this.nro_dni.Frozen = true;
            this.nro_dni.HeaderText = "Numero de Documento";
            this.nro_dni.Name = "nro_dni";
            this.nro_dni.ReadOnly = true;
            this.nro_dni.Width = 70;
            // 
            // mail
            // 
            this.mail.DataPropertyName = "prof_mail";
            this.mail.Frozen = true;
            this.mail.HeaderText = "E-Mail";
            this.mail.Name = "mail";
            this.mail.ReadOnly = true;
            this.mail.Width = 60;
            // 
            // Direccion
            // 
            this.Direccion.DataPropertyName = "prof_direccion";
            this.Direccion.Frozen = true;
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 60;
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "prof_telefono";
            this.Telefono.Frozen = true;
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Width = 70;
            // 
            // fecha_nac
            // 
            this.fecha_nac.DataPropertyName = "prof_fecha_nac";
            this.fecha_nac.Frozen = true;
            this.fecha_nac.HeaderText = "Fecha de Nacimiento";
            this.fecha_nac.Name = "fecha_nac";
            this.fecha_nac.ReadOnly = true;
            this.fecha_nac.Width = 75;
            // 
            // sexo
            // 
            this.sexo.DataPropertyName = "prof_sexo";
            this.sexo.Frozen = true;
            this.sexo.HeaderText = "Sexo";
            this.sexo.Name = "sexo";
            this.sexo.ReadOnly = true;
            this.sexo.Width = 50;
            // 
            // matricula
            // 
            this.matricula.DataPropertyName = "prof_matricula";
            this.matricula.Frozen = true;
            this.matricula.HeaderText = "Matricula";
            this.matricula.Name = "matricula";
            this.matricula.ReadOnly = true;
            this.matricula.Width = 60;
            // 
            // btnClean
            // 
            this.btnClean.Enabled = false;
            this.btnClean.Location = new System.Drawing.Point(302, 13);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(49, 23);
            this.btnClean.TabIndex = 16;
            this.btnClean.Text = "Limpiar";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // frmABMProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 448);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.grdConsulta);
            this.Controls.Add(this.lblNro);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnAlta);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmABMProfesional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABMProfesionalForm";
            ((System.ComponentModel.ISupportInitialize)(this.grdConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Label lblNro;
        private System.Windows.Forms.DataGridView grdConsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn nro_dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_nac;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn matricula;
        private System.Windows.Forms.Button btnClean;

    }
}