namespace proyecto_w.Login
{
    partial class frmRols
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
            this.lstRol = new System.Windows.Forms.ListBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstRol
            // 
            this.lstRol.FormattingEnabled = true;
            this.lstRol.Location = new System.Drawing.Point(12, 12);
            this.lstRol.Name = "lstRol";
            this.lstRol.Size = new System.Drawing.Size(120, 95);
            this.lstRol.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(12, 118);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(120, 23);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Seleccionar";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // frmRols
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(146, 153);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lstRol);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRols";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Rol";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstRol;
        private System.Windows.Forms.Button btnSubmit;
    }
}