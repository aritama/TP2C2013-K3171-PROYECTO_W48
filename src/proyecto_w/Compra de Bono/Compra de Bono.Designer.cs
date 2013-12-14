namespace proyecto_w.Compra_de_Bono
{
    partial class frmCompra_de_Bono
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
            this.cmbCDB_Tipo = new System.Windows.Forms.ComboBox();
            this.lblCDB_AfilNro = new System.Windows.Forms.Label();
            this.txtCDB_AfilNro = new System.Windows.Forms.TextBox();
            this.lblCDB_TipoBono = new System.Windows.Forms.Label();
            this.lblCDB_Cantidad = new System.Windows.Forms.Label();
            this.txtCDB_Cantidad = new System.Windows.Forms.TextBox();
            this.btnCDB_RealizarCompra = new System.Windows.Forms.Button();
            this.lblCDB_CantPagar = new System.Windows.Forms.Label();
            this.lblCDB_Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbCDB_Tipo
            // 
            this.cmbCDB_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCDB_Tipo.FormattingEnabled = true;
            this.cmbCDB_Tipo.Location = new System.Drawing.Point(332, 25);
            this.cmbCDB_Tipo.Name = "cmbCDB_Tipo";
            this.cmbCDB_Tipo.Size = new System.Drawing.Size(136, 21);
            this.cmbCDB_Tipo.TabIndex = 0;
            this.cmbCDB_Tipo.SelectedIndexChanged += new System.EventHandler(this.cmbCDB_Tipo_SelectedIndexChanged);
            // 
            // lblCDB_AfilNro
            // 
            this.lblCDB_AfilNro.AutoSize = true;
            this.lblCDB_AfilNro.Location = new System.Drawing.Point(12, 9);
            this.lblCDB_AfilNro.Name = "lblCDB_AfilNro";
            this.lblCDB_AfilNro.Size = new System.Drawing.Size(72, 13);
            this.lblCDB_AfilNro.TabIndex = 1;
            this.lblCDB_AfilNro.Text = "Afiiliado Nro. :";
            // 
            // txtCDB_AfilNro
            // 
            this.txtCDB_AfilNro.Location = new System.Drawing.Point(73, 25);
            this.txtCDB_AfilNro.Name = "txtCDB_AfilNro";
            this.txtCDB_AfilNro.Size = new System.Drawing.Size(136, 20);
            this.txtCDB_AfilNro.TabIndex = 2;
            this.txtCDB_AfilNro.TextChanged += new System.EventHandler(this.txtCDB_AfilNro_TextChanged);
            // 
            // lblCDB_TipoBono
            // 
            this.lblCDB_TipoBono.AutoSize = true;
            this.lblCDB_TipoBono.Location = new System.Drawing.Point(268, 9);
            this.lblCDB_TipoBono.Name = "lblCDB_TipoBono";
            this.lblCDB_TipoBono.Size = new System.Drawing.Size(76, 13);
            this.lblCDB_TipoBono.TabIndex = 3;
            this.lblCDB_TipoBono.Text = "Tipo de bono :";
            // 
            // lblCDB_Cantidad
            // 
            this.lblCDB_Cantidad.AutoSize = true;
            this.lblCDB_Cantidad.Location = new System.Drawing.Point(530, 9);
            this.lblCDB_Cantidad.Name = "lblCDB_Cantidad";
            this.lblCDB_Cantidad.Size = new System.Drawing.Size(55, 13);
            this.lblCDB_Cantidad.TabIndex = 4;
            this.lblCDB_Cantidad.Text = "Cantidad :";
            // 
            // txtCDB_Cantidad
            // 
            this.txtCDB_Cantidad.Location = new System.Drawing.Point(575, 25);
            this.txtCDB_Cantidad.Name = "txtCDB_Cantidad";
            this.txtCDB_Cantidad.Size = new System.Drawing.Size(135, 20);
            this.txtCDB_Cantidad.TabIndex = 5;
            this.txtCDB_Cantidad.TextChanged += new System.EventHandler(this.txtCDB_Cantidad_TextChanged);
            // 
            // btnCDB_RealizarCompra
            // 
            this.btnCDB_RealizarCompra.Location = new System.Drawing.Point(16, 60);
            this.btnCDB_RealizarCompra.Name = "btnCDB_RealizarCompra";
            this.btnCDB_RealizarCompra.Size = new System.Drawing.Size(101, 23);
            this.btnCDB_RealizarCompra.TabIndex = 6;
            this.btnCDB_RealizarCompra.Text = "Realizar compra";
            this.btnCDB_RealizarCompra.UseVisualStyleBackColor = true;
            this.btnCDB_RealizarCompra.Click += new System.EventHandler(this.btnCDB_RealizarCompra_Click);
            // 
            // lblCDB_CantPagar
            // 
            this.lblCDB_CantPagar.AutoSize = true;
            this.lblCDB_CantPagar.Location = new System.Drawing.Point(12, 104);
            this.lblCDB_CantPagar.Name = "lblCDB_CantPagar";
            this.lblCDB_CantPagar.Size = new System.Drawing.Size(40, 13);
            this.lblCDB_CantPagar.TabIndex = 7;
            this.lblCDB_CantPagar.Text = "Status:";
            // 
            // lblCDB_Status
            // 
            this.lblCDB_Status.AutoSize = true;
            this.lblCDB_Status.Location = new System.Drawing.Point(41, 126);
            this.lblCDB_Status.Name = "lblCDB_Status";
            this.lblCDB_Status.Size = new System.Drawing.Size(22, 13);
            this.lblCDB_Status.TabIndex = 8;
            this.lblCDB_Status.Text = "OK";
            // 
            // frmCompra_de_Bono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 172);
            this.Controls.Add(this.lblCDB_Status);
            this.Controls.Add(this.lblCDB_CantPagar);
            this.Controls.Add(this.btnCDB_RealizarCompra);
            this.Controls.Add(this.txtCDB_Cantidad);
            this.Controls.Add(this.lblCDB_Cantidad);
            this.Controls.Add(this.lblCDB_TipoBono);
            this.Controls.Add(this.txtCDB_AfilNro);
            this.Controls.Add(this.lblCDB_AfilNro);
            this.Controls.Add(this.cmbCDB_Tipo);
            this.Name = "frmCompra_de_Bono";
            this.Text = "Compra_de_Bono";
            this.Load += new System.EventHandler(this.frmCompra_de_Bono_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCDB_Tipo;
        private System.Windows.Forms.Label lblCDB_AfilNro;
        private System.Windows.Forms.TextBox txtCDB_AfilNro;
        private System.Windows.Forms.Label lblCDB_TipoBono;
        private System.Windows.Forms.Label lblCDB_Cantidad;
        private System.Windows.Forms.TextBox txtCDB_Cantidad;
        private System.Windows.Forms.Button btnCDB_RealizarCompra;
        private System.Windows.Forms.Label lblCDB_CantPagar;
        private System.Windows.Forms.Label lblCDB_Status;
    }
}