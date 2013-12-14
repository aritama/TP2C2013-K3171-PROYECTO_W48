namespace proyecto_w.Listado_Estadistico
{
    partial class ListadoEstadisticoForm
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
            this.cbListado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSemestre = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAño = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbListado
            // 
            this.cbListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListado.FormattingEnabled = true;
            this.cbListado.Location = new System.Drawing.Point(13, 13);
            this.cbListado.Name = "cbListado";
            this.cbListado.Size = new System.Drawing.Size(263, 21);
            this.cbListado.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Listado";
            // 
            // cbSemestre
            // 
            this.cbSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSemestre.FormattingEnabled = true;
            this.cbSemestre.Location = new System.Drawing.Point(13, 41);
            this.cbSemestre.Name = "cbSemestre";
            this.cbSemestre.Size = new System.Drawing.Size(263, 21);
            this.cbSemestre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Semestre";
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(13, 69);
            this.txtAño.Name = "txtAño";
            this.txtAño.Size = new System.Drawing.Size(263, 20);
            this.txtAño.TabIndex = 4;
            this.txtAño.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAño_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Año";
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(301, 111);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 6;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click_1);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(13, 111);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // ListadoEstadisticoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 146);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAño);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbSemestre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbListado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListadoEstadisticoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListadoEstadisticoForm";
            this.Load += new System.EventHandler(this.ListadoEstadisticoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbListado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSemestre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAño;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}