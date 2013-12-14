namespace proyecto_w.ABM_Rol
{
    partial class frmABMRol
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
            this.btnAltaRol = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.grdRoles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAltaRol
            // 
            this.btnAltaRol.Location = new System.Drawing.Point(170, 12);
            this.btnAltaRol.Name = "btnAltaRol";
            this.btnAltaRol.Size = new System.Drawing.Size(75, 23);
            this.btnAltaRol.TabIndex = 1;
            this.btnAltaRol.Text = "Alta";
            this.btnAltaRol.UseVisualStyleBackColor = true;
            this.btnAltaRol.Click += new System.EventHandler(this.btnAltaRol_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(170, 41);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(110, 23);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar/Baja";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // grdRoles
            // 
            this.grdRoles.AllowUserToAddRows = false;
            this.grdRoles.AllowUserToDeleteRows = false;
            this.grdRoles.AllowUserToResizeColumns = false;
            this.grdRoles.AllowUserToResizeRows = false;
            this.grdRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdRoles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRoles.ColumnHeadersVisible = false;
            this.grdRoles.Location = new System.Drawing.Point(12, 12);
            this.grdRoles.MultiSelect = false;
            this.grdRoles.Name = "grdRoles";
            this.grdRoles.ReadOnly = true;
            this.grdRoles.RowHeadersVisible = false;
            this.grdRoles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdRoles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdRoles.Size = new System.Drawing.Size(152, 229);
            this.grdRoles.TabIndex = 4;
            // 
            // frmABMRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.grdRoles);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAltaRol);
            this.Name = "frmABMRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Rol";
            this.Activated += new System.EventHandler(this.Activated_Form);
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAltaRol;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridView grdRoles;
    }
}