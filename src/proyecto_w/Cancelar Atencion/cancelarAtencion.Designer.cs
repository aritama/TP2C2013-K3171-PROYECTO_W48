namespace proyecto_w.Cancelar_Atencion
{
    partial class frmCancelarAtencion
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
            this.txtCancel_turno_nro = new System.Windows.Forms.ComboBox();
            this.txtCancel_motivo = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbxCancel_quien = new System.Windows.Forms.ComboBox();
            this.lbl_turno_nro = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCancel_status = new System.Windows.Forms.Label();
            this.lblTurnoInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCancel_turno_nro
            // 
            this.txtCancel_turno_nro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCancel_turno_nro.Location = new System.Drawing.Point(101, 6);
            this.txtCancel_turno_nro.Name = "txtCancel_turno_nro";
            this.txtCancel_turno_nro.Size = new System.Drawing.Size(121, 21);
            this.txtCancel_turno_nro.TabIndex = 0;
            this.txtCancel_turno_nro.SelectedIndexChanged += new System.EventHandler(this.txtCancel_turno_nro_SelectedIndexChanged);
            this.txtCancel_turno_nro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnroturno_KeyPress);
            // 
            // txtCancel_motivo
            // 
            this.txtCancel_motivo.Location = new System.Drawing.Point(101, 103);
            this.txtCancel_motivo.Multiline = true;
            this.txtCancel_motivo.Name = "txtCancel_motivo";
            this.txtCancel_motivo.Size = new System.Drawing.Size(392, 63);
            this.txtCancel_motivo.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(365, 183);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancelar atención";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbxCancel_quien
            // 
            this.cbxCancel_quien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCancel_quien.FormattingEnabled = true;
            this.cbxCancel_quien.Location = new System.Drawing.Point(101, 42);
            this.cbxCancel_quien.Name = "cbxCancel_quien";
            this.cbxCancel_quien.Size = new System.Drawing.Size(121, 21);
            this.cbxCancel_quien.Sorted = true;
            this.cbxCancel_quien.TabIndex = 5;
            this.cbxCancel_quien.SelectedIndexChanged += new System.EventHandler(this.cbxCancel_quien_SelectedIndexChanged);
            // 
            // lbl_turno_nro
            // 
            this.lbl_turno_nro.AutoSize = true;
            this.lbl_turno_nro.Location = new System.Drawing.Point(12, 9);
            this.lbl_turno_nro.Name = "lbl_turno_nro";
            this.lbl_turno_nro.Size = new System.Drawing.Size(64, 13);
            this.lbl_turno_nro.TabIndex = 6;
            this.lbl_turno_nro.Text = "Turno Nro. :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Quién cancela: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Motivo (opcional) :";
            // 
            // lblCancel_status
            // 
            this.lblCancel_status.AutoSize = true;
            this.lblCancel_status.Location = new System.Drawing.Point(12, 170);
            this.lblCancel_status.Name = "lblCancel_status";
            this.lblCancel_status.Size = new System.Drawing.Size(13, 13);
            this.lblCancel_status.TabIndex = 9;
            this.lblCancel_status.Text = "_";
            this.lblCancel_status.Visible = false;
            // 
            // lblTurnoInfo
            // 
            this.lblTurnoInfo.AutoSize = true;
            this.lblTurnoInfo.Location = new System.Drawing.Point(262, 14);
            this.lblTurnoInfo.Name = "lblTurnoInfo";
            this.lblTurnoInfo.Size = new System.Drawing.Size(53, 13);
            this.lblTurnoInfo.TabIndex = 10;
            this.lblTurnoInfo.Text = "TurnoInfo";
            // 
            // frmCancelarAtencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 218);
            this.Controls.Add(this.lblTurnoInfo);
            this.Controls.Add(this.lblCancel_status);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_turno_nro);
            this.Controls.Add(this.cbxCancel_quien);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtCancel_motivo);
            this.Controls.Add(this.txtCancel_turno_nro);
            this.Name = "frmCancelarAtencion";
            this.Text = "cancelarAtencion";
            this.Load += new System.EventHandler(this.frmCancelarAtencion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox txtCancel_turno_nro;
        private System.Windows.Forms.TextBox txtCancel_motivo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbxCancel_quien;
        private System.Windows.Forms.Label lbl_turno_nro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCancel_status;
        private System.Windows.Forms.Label lblTurnoInfo;
    }
}