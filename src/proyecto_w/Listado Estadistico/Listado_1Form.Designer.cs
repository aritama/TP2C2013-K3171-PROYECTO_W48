namespace proyecto_w.Listado_Estadistico
{
    partial class ListadoForm
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
            this.grdListado1 = new System.Windows.Forms.DataGridView();
            this.btSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdListado1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdListado1
            // 
            this.grdListado1.AllowUserToAddRows = false;
            this.grdListado1.AllowUserToDeleteRows = false;
            this.grdListado1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdListado1.Location = new System.Drawing.Point(13, 13);
            this.grdListado1.Name = "grdListado1";
            this.grdListado1.ReadOnly = true;
            this.grdListado1.RowHeadersVisible = false;
            this.grdListado1.Size = new System.Drawing.Size(804, 307);
            this.grdListado1.TabIndex = 0;
            // 
            // btSalir
            // 
            this.btSalir.Location = new System.Drawing.Point(726, 329);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(75, 23);
            this.btSalir.TabIndex = 1;
            this.btSalir.Text = "Salir";
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // ListadoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 364);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.grdListado1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListadoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado";
            ((System.ComponentModel.ISupportInitialize)(this.grdListado1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdListado1;
        private System.Windows.Forms.Button btSalir;
    }
}