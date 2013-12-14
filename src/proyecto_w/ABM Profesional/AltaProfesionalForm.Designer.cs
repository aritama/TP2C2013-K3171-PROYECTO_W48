namespace proyecto_w.ABM_Profesional
{
    partial class AltaProfesionalForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.dtmFechaNac = new System.Windows.Forms.DateTimePicker();
            this.cbxSexo = new System.Windows.Forms.ComboBox();
            this.cbxTipoDoc = new System.Windows.Forms.ComboBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblEspecialidades = new System.Windows.Forms.Label();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblNroDoc = new System.Windows.Forms.Label();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lstEspecialidades = new System.Windows.Forms.ListBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(319, 471);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 51;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(162, 471);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(127, 23);
            this.btnRegistrar.TabIndex = 50;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // dtmFechaNac
            // 
            this.dtmFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmFechaNac.Location = new System.Drawing.Point(168, 220);
            this.dtmFechaNac.MaxDate = new System.DateTime(1999, 12, 31, 0, 0, 0, 0);
            this.dtmFechaNac.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtmFechaNac.Name = "dtmFechaNac";
            this.dtmFechaNac.Size = new System.Drawing.Size(88, 20);
            this.dtmFechaNac.TabIndex = 46;
            this.dtmFechaNac.Value = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            // 
            // cbxSexo
            // 
            this.cbxSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSexo.FormattingEnabled = true;
            this.cbxSexo.Location = new System.Drawing.Point(168, 250);
            this.cbxSexo.Name = "cbxSexo";
            this.cbxSexo.Size = new System.Drawing.Size(88, 21);
            this.cbxSexo.TabIndex = 47;
            // 
            // cbxTipoDoc
            // 
            this.cbxTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoDoc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxTipoDoc.FormattingEnabled = true;
            this.cbxTipoDoc.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbxTipoDoc.Location = new System.Drawing.Point(168, 78);
            this.cbxTipoDoc.Name = "cbxTipoDoc";
            this.cbxTipoDoc.Size = new System.Drawing.Size(88, 21);
            this.cbxTipoDoc.TabIndex = 41;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(168, 194);
            this.txtMail.MaxLength = 255;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(182, 20);
            this.txtMail.TabIndex = 45;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(168, 164);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(88, 20);
            this.txtTelefono.TabIndex = 44;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(168, 136);
            this.txtDireccion.MaxLength = 255;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(182, 20);
            this.txtDireccion.TabIndex = 43;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(168, 105);
            this.txtNroDoc.MaxLength = 12;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(88, 20);
            this.txtNroDoc.TabIndex = 42;
            this.txtNroDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroDoc_KeyPress);
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(168, 53);
            this.txtApellido.MaxLength = 40;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(182, 20);
            this.txtApellido.TabIndex = 40;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(168, 22);
            this.txtNombre.MaxLength = 30;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(182, 20);
            this.txtNombre.TabIndex = 39;
            // 
            // lblEspecialidades
            // 
            this.lblEspecialidades.AutoSize = true;
            this.lblEspecialidades.Location = new System.Drawing.Point(35, 311);
            this.lblEspecialidades.Name = "lblEspecialidades";
            this.lblEspecialidades.Size = new System.Drawing.Size(78, 13);
            this.lblEspecialidades.TabIndex = 38;
            this.lblEspecialidades.Text = "Especialidades";
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Location = new System.Drawing.Point(36, 280);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(65, 13);
            this.lblMatricula.TabIndex = 36;
            this.lblMatricula.Text = "N° Matricula";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(36, 253);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(31, 13);
            this.lblSexo.TabIndex = 35;
            this.lblSexo.Text = "Sexo";
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Location = new System.Drawing.Point(36, 224);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(93, 13);
            this.lblFechaNac.TabIndex = 34;
            this.lblFechaNac.Text = "Fecha Nacimiento";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(36, 194);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(26, 13);
            this.lblMail.TabIndex = 33;
            this.lblMail.Text = "Mail";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(36, 164);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 32;
            this.lblTelefono.Text = "Teléfono";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(36, 136);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 31;
            this.lblDireccion.Text = "Dirección";
            // 
            // lblNroDoc
            // 
            this.lblNroDoc.AutoSize = true;
            this.lblNroDoc.Location = new System.Drawing.Point(36, 108);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Size = new System.Drawing.Size(82, 13);
            this.lblNroDoc.TabIndex = 30;
            this.lblNroDoc.Text = "Nro Documento";
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Location = new System.Drawing.Point(36, 79);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(86, 13);
            this.lblTipoDoc.TabIndex = 29;
            this.lblTipoDoc.Text = "Tipo Documento";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(36, 53);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 28;
            this.lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(36, 22);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 27;
            this.lblNombre.Text = "Nombre";
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(168, 277);
            this.txtMatricula.MaxLength = 15;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(88, 20);
            this.txtMatricula.TabIndex = 48;
            this.txtMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatricula_KeyPress);
            // 
            // lstEspecialidades
            // 
            this.lstEspecialidades.FormattingEnabled = true;
            this.lstEspecialidades.Location = new System.Drawing.Point(168, 311);
            this.lstEspecialidades.Name = "lstEspecialidades";
            this.lstEspecialidades.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstEspecialidades.Size = new System.Drawing.Size(182, 147);
            this.lstEspecialidades.TabIndex = 49;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(43, 471);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 52;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // AltaProfesionalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 506);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lstEspecialidades);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.dtmFechaNac);
            this.Controls.Add(this.cbxSexo);
            this.Controls.Add(this.cbxTipoDoc);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtNroDoc);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblEspecialidades);
            this.Controls.Add(this.lblMatricula);
            this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.lblFechaNac);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblNroDoc);
            this.Controls.Add(this.lblTipoDoc);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AltaProfesionalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AltaProfesionalForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DateTimePicker dtmFechaNac;
        private System.Windows.Forms.ComboBox cbxSexo;
        private System.Windows.Forms.ComboBox cbxTipoDoc;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblEspecialidades;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblNroDoc;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.ListBox lstEspecialidades;
        private System.Windows.Forms.Button btnLimpiar;
    }
}