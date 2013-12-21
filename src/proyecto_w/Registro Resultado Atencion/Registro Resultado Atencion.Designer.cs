namespace proyecto_w.Registro_Resultado_Atencion
{
    partial class Registro_Resultado_Atencion_Form
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
            this.lblTurnoNro = new System.Windows.Forms.Label();
            this.lblSintoma = new System.Windows.Forms.Label();
            this.txtSintoma = new System.Windows.Forms.TextBox();
            this.lblDiagnostico = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.btnRegistrarResultadoAtencion = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.checkConReceta = new System.Windows.Forms.CheckBox();
            this.checkConcretado = new System.Windows.Forms.CheckBox();
            this.txtTurnoNro = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTurnoNro
            // 
            this.lblTurnoNro.AutoSize = true;
            this.lblTurnoNro.Location = new System.Drawing.Point(12, 15);
            this.lblTurnoNro.Name = "lblTurnoNro";
            this.lblTurnoNro.Size = new System.Drawing.Size(61, 13);
            this.lblTurnoNro.TabIndex = 1;
            this.lblTurnoNro.Text = "Turno Nro.:";
            // 
            // lblSintoma
            // 
            this.lblSintoma.AutoSize = true;
            this.lblSintoma.Location = new System.Drawing.Point(12, 61);
            this.lblSintoma.Name = "lblSintoma";
            this.lblSintoma.Size = new System.Drawing.Size(58, 13);
            this.lblSintoma.TabIndex = 3;
            this.lblSintoma.Text = "Síntomas: ";
            // 
            // txtSintoma
            // 
            this.txtSintoma.Location = new System.Drawing.Point(79, 58);
            this.txtSintoma.Multiline = true;
            this.txtSintoma.Name = "txtSintoma";
            this.txtSintoma.Size = new System.Drawing.Size(201, 69);
            this.txtSintoma.TabIndex = 4;
            // 
            // lblDiagnostico
            // 
            this.lblDiagnostico.AutoSize = true;
            this.lblDiagnostico.Location = new System.Drawing.Point(12, 137);
            this.lblDiagnostico.Name = "lblDiagnostico";
            this.lblDiagnostico.Size = new System.Drawing.Size(69, 13);
            this.lblDiagnostico.TabIndex = 5;
            this.lblDiagnostico.Text = "Diagnóstico: ";
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Location = new System.Drawing.Point(79, 134);
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(201, 78);
            this.txtDiagnostico.TabIndex = 6;
            // 
            // btnRegistrarResultadoAtencion
            // 
            this.btnRegistrarResultadoAtencion.Location = new System.Drawing.Point(12, 253);
            this.btnRegistrarResultadoAtencion.Name = "btnRegistrarResultadoAtencion";
            this.btnRegistrarResultadoAtencion.Size = new System.Drawing.Size(59, 23);
            this.btnRegistrarResultadoAtencion.TabIndex = 7;
            this.btnRegistrarResultadoAtencion.Text = "Registrar";
            this.btnRegistrarResultadoAtencion.UseVisualStyleBackColor = true;
            this.btnRegistrarResultadoAtencion.Click += new System.EventHandler(this.btnRegistrarResultadoAtencion_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(77, 240);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status";
            this.lblStatus.Visible = false;
            // 
            // checkConReceta
            // 
            this.checkConReceta.AutoSize = true;
            this.checkConReceta.Location = new System.Drawing.Point(197, 218);
            this.checkConReceta.Name = "checkConReceta";
            this.checkConReceta.Size = new System.Drawing.Size(83, 17);
            this.checkConReceta.TabIndex = 9;
            this.checkConReceta.Text = "Con Receta";
            this.checkConReceta.UseVisualStyleBackColor = true;
            // 
            // checkConcretado
            // 
            this.checkConcretado.AutoSize = true;
            this.checkConcretado.Location = new System.Drawing.Point(200, 35);
            this.checkConcretado.Name = "checkConcretado";
            this.checkConcretado.Size = new System.Drawing.Size(81, 17);
            this.checkConcretado.TabIndex = 10;
            this.checkConcretado.Text = "Concretado";
            this.checkConcretado.UseVisualStyleBackColor = true;
            // 
            // txtTurnoNro
            // 
            this.txtTurnoNro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtTurnoNro.FormattingEnabled = true;
            this.txtTurnoNro.Location = new System.Drawing.Point(80, 6);
            this.txtTurnoNro.Name = "txtTurnoNro";
            this.txtTurnoNro.Size = new System.Drawing.Size(121, 21);
            this.txtTurnoNro.TabIndex = 11;
            this.txtTurnoNro.SelectedIndexChanged += new System.EventHandler(this.txtTurnoNro_SelectedIndexChanged);
            // 
            // Registro_Resultado_Atencion_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 287);
            this.Controls.Add(this.txtTurnoNro);
            this.Controls.Add(this.checkConcretado);
            this.Controls.Add(this.checkConReceta);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRegistrarResultadoAtencion);
            this.Controls.Add(this.txtDiagnostico);
            this.Controls.Add(this.lblDiagnostico);
            this.Controls.Add(this.txtSintoma);
            this.Controls.Add(this.lblSintoma);
            this.Controls.Add(this.lblTurnoNro);
            this.Name = "Registro_Resultado_Atencion_Form";
            this.Text = "Registro_Resultado_Atencion";
            this.Load += new System.EventHandler(this.Registro_Resultado_Atencion_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTurnoNro;
        private System.Windows.Forms.Label lblSintoma;
        private System.Windows.Forms.TextBox txtSintoma;
        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Button btnRegistrarResultadoAtencion;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox checkConReceta;
        private System.Windows.Forms.CheckBox checkConcretado;
        private System.Windows.Forms.ComboBox txtTurnoNro;
    }
}