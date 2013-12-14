namespace proyecto_w.ABM_Rol
{
    partial class frmModificarRol
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
            this.lstFuncionalidad = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lstFuncionalidad
            // 
            this.lstFuncionalidad.FormattingEnabled = true;
            this.lstFuncionalidad.Location = new System.Drawing.Point(12, 60);
            this.lstFuncionalidad.Name = "lstFuncionalidad";
            this.lstFuncionalidad.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFuncionalidad.Size = new System.Drawing.Size(173, 147);
            this.lstFuncionalidad.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(38, 240);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Guardar Cambios";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNombreRol
            // 
            this.txtNombreRol.Location = new System.Drawing.Point(65, 26);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(100, 20);
            this.txtNombreRol.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre:";
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(12, 217);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(83, 17);
            this.chkEnable.TabIndex = 4;
            this.chkEnable.Tag = "";
            this.chkEnable.Text = "Habilitar Rol";
            this.chkEnable.UseVisualStyleBackColor = true;
            // 
            // frmModificarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 275);
            this.Controls.Add(this.chkEnable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombreRol);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstFuncionalidad);
            this.MaximizeBox = false;
            this.Name = "frmModificarRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modicacion/Baja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFuncionalidad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEnable;
    }
}