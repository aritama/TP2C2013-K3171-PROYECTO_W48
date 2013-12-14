namespace proyecto_w.Registrar_Agenda
{
    partial class frmRegistrarAgenda
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
            this.txtProfCod = new System.Windows.Forms.TextBox();
            this.checkLunes = new System.Windows.Forms.CheckBox();
            this.checkMartes = new System.Windows.Forms.CheckBox();
            this.checkMie = new System.Windows.Forms.CheckBox();
            this.checkJue = new System.Windows.Forms.CheckBox();
            this.checkVie = new System.Windows.Forms.CheckBox();
            this.checkSa = new System.Windows.Forms.CheckBox();
            this.cbxLun_ini = new System.Windows.Forms.ComboBox();
            this.cbxLun_fin = new System.Windows.Forms.ComboBox();
            this.cbxMa_ini = new System.Windows.Forms.ComboBox();
            this.cbxMa_fin = new System.Windows.Forms.ComboBox();
            this.cbxMi_ini = new System.Windows.Forms.ComboBox();
            this.cbxMi_fin = new System.Windows.Forms.ComboBox();
            this.cbxJu_ini = new System.Windows.Forms.ComboBox();
            this.cbxJu_fin = new System.Windows.Forms.ComboBox();
            this.cbxVi_ini = new System.Windows.Forms.ComboBox();
            this.cbxVi_fin = new System.Windows.Forms.ComboBox();
            this.cbxSa_ini = new System.Windows.Forms.ComboBox();
            this.cbxSa_fin = new System.Windows.Forms.ComboBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.dtp_ini = new System.Windows.Forms.DateTimePicker();
            this.dtp_fin = new System.Windows.Forms.DateTimePicker();
            this.lbl_dni = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblhorariosRA = new System.Windows.Forms.Label();
            this.dtpEx = new System.Windows.Forms.DateTimePicker();
            this.checkedListEx = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddEx = new System.Windows.Forms.Button();
            this.btnRemoveEx = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtProfCod
            // 
            this.txtProfCod.Location = new System.Drawing.Point(47, 12);
            this.txtProfCod.Name = "txtProfCod";
            this.txtProfCod.Size = new System.Drawing.Size(100, 20);
            this.txtProfCod.TabIndex = 0;
            this.txtProfCod.TextChanged += new System.EventHandler(this.txtProfCod_TextChanged);
            // 
            // checkLunes
            // 
            this.checkLunes.AutoSize = true;
            this.checkLunes.Location = new System.Drawing.Point(12, 44);
            this.checkLunes.Name = "checkLunes";
            this.checkLunes.Size = new System.Drawing.Size(55, 17);
            this.checkLunes.TabIndex = 1;
            this.checkLunes.Text = "Lunes";
            this.checkLunes.UseVisualStyleBackColor = true;
            // 
            // checkMartes
            // 
            this.checkMartes.AutoSize = true;
            this.checkMartes.Location = new System.Drawing.Point(12, 67);
            this.checkMartes.Name = "checkMartes";
            this.checkMartes.Size = new System.Drawing.Size(58, 17);
            this.checkMartes.TabIndex = 2;
            this.checkMartes.Text = "Martes";
            this.checkMartes.UseVisualStyleBackColor = true;
            // 
            // checkMie
            // 
            this.checkMie.AutoSize = true;
            this.checkMie.Location = new System.Drawing.Point(12, 92);
            this.checkMie.Name = "checkMie";
            this.checkMie.Size = new System.Drawing.Size(71, 17);
            this.checkMie.TabIndex = 3;
            this.checkMie.Text = "Miércoles";
            this.checkMie.UseVisualStyleBackColor = true;
            // 
            // checkJue
            // 
            this.checkJue.AutoSize = true;
            this.checkJue.Location = new System.Drawing.Point(12, 115);
            this.checkJue.Name = "checkJue";
            this.checkJue.Size = new System.Drawing.Size(60, 17);
            this.checkJue.TabIndex = 4;
            this.checkJue.Text = "Jueves";
            this.checkJue.UseVisualStyleBackColor = true;
            // 
            // checkVie
            // 
            this.checkVie.AutoSize = true;
            this.checkVie.Location = new System.Drawing.Point(12, 138);
            this.checkVie.Name = "checkVie";
            this.checkVie.Size = new System.Drawing.Size(61, 17);
            this.checkVie.TabIndex = 5;
            this.checkVie.Text = "Viernes";
            this.checkVie.UseVisualStyleBackColor = true;
            // 
            // checkSa
            // 
            this.checkSa.AutoSize = true;
            this.checkSa.Location = new System.Drawing.Point(12, 161);
            this.checkSa.Name = "checkSa";
            this.checkSa.Size = new System.Drawing.Size(63, 17);
            this.checkSa.TabIndex = 6;
            this.checkSa.Text = "Sábado";
            this.checkSa.UseVisualStyleBackColor = true;
            // 
            // cbxLun_ini
            // 
            this.cbxLun_ini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLun_ini.FormattingEnabled = true;
            this.cbxLun_ini.Location = new System.Drawing.Point(137, 42);
            this.cbxLun_ini.Name = "cbxLun_ini";
            this.cbxLun_ini.Size = new System.Drawing.Size(121, 21);
            this.cbxLun_ini.Sorted = true;
            this.cbxLun_ini.TabIndex = 7;
            // 
            // cbxLun_fin
            // 
            this.cbxLun_fin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLun_fin.FormattingEnabled = true;
            this.cbxLun_fin.Location = new System.Drawing.Point(300, 42);
            this.cbxLun_fin.Name = "cbxLun_fin";
            this.cbxLun_fin.Size = new System.Drawing.Size(121, 21);
            this.cbxLun_fin.Sorted = true;
            this.cbxLun_fin.TabIndex = 8;
            // 
            // cbxMa_ini
            // 
            this.cbxMa_ini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMa_ini.FormattingEnabled = true;
            this.cbxMa_ini.Location = new System.Drawing.Point(137, 65);
            this.cbxMa_ini.Name = "cbxMa_ini";
            this.cbxMa_ini.Size = new System.Drawing.Size(121, 21);
            this.cbxMa_ini.Sorted = true;
            this.cbxMa_ini.TabIndex = 9;
            // 
            // cbxMa_fin
            // 
            this.cbxMa_fin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMa_fin.FormattingEnabled = true;
            this.cbxMa_fin.Location = new System.Drawing.Point(300, 65);
            this.cbxMa_fin.Name = "cbxMa_fin";
            this.cbxMa_fin.Size = new System.Drawing.Size(121, 21);
            this.cbxMa_fin.Sorted = true;
            this.cbxMa_fin.TabIndex = 10;
            // 
            // cbxMi_ini
            // 
            this.cbxMi_ini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMi_ini.FormattingEnabled = true;
            this.cbxMi_ini.Location = new System.Drawing.Point(137, 90);
            this.cbxMi_ini.Name = "cbxMi_ini";
            this.cbxMi_ini.Size = new System.Drawing.Size(121, 21);
            this.cbxMi_ini.Sorted = true;
            this.cbxMi_ini.TabIndex = 11;
            // 
            // cbxMi_fin
            // 
            this.cbxMi_fin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMi_fin.FormattingEnabled = true;
            this.cbxMi_fin.Location = new System.Drawing.Point(300, 90);
            this.cbxMi_fin.Name = "cbxMi_fin";
            this.cbxMi_fin.Size = new System.Drawing.Size(121, 21);
            this.cbxMi_fin.Sorted = true;
            this.cbxMi_fin.TabIndex = 12;
            // 
            // cbxJu_ini
            // 
            this.cbxJu_ini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxJu_ini.FormattingEnabled = true;
            this.cbxJu_ini.Location = new System.Drawing.Point(137, 113);
            this.cbxJu_ini.Name = "cbxJu_ini";
            this.cbxJu_ini.Size = new System.Drawing.Size(121, 21);
            this.cbxJu_ini.Sorted = true;
            this.cbxJu_ini.TabIndex = 13;
            // 
            // cbxJu_fin
            // 
            this.cbxJu_fin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxJu_fin.FormattingEnabled = true;
            this.cbxJu_fin.Location = new System.Drawing.Point(300, 113);
            this.cbxJu_fin.Name = "cbxJu_fin";
            this.cbxJu_fin.Size = new System.Drawing.Size(121, 21);
            this.cbxJu_fin.Sorted = true;
            this.cbxJu_fin.TabIndex = 14;
            // 
            // cbxVi_ini
            // 
            this.cbxVi_ini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVi_ini.FormattingEnabled = true;
            this.cbxVi_ini.Location = new System.Drawing.Point(137, 136);
            this.cbxVi_ini.Name = "cbxVi_ini";
            this.cbxVi_ini.Size = new System.Drawing.Size(121, 21);
            this.cbxVi_ini.Sorted = true;
            this.cbxVi_ini.TabIndex = 15;
            // 
            // cbxVi_fin
            // 
            this.cbxVi_fin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVi_fin.FormattingEnabled = true;
            this.cbxVi_fin.Location = new System.Drawing.Point(300, 136);
            this.cbxVi_fin.Name = "cbxVi_fin";
            this.cbxVi_fin.Size = new System.Drawing.Size(121, 21);
            this.cbxVi_fin.Sorted = true;
            this.cbxVi_fin.TabIndex = 16;
            // 
            // cbxSa_ini
            // 
            this.cbxSa_ini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSa_ini.FormattingEnabled = true;
            this.cbxSa_ini.Location = new System.Drawing.Point(137, 159);
            this.cbxSa_ini.Name = "cbxSa_ini";
            this.cbxSa_ini.Size = new System.Drawing.Size(121, 21);
            this.cbxSa_ini.Sorted = true;
            this.cbxSa_ini.TabIndex = 17;
            // 
            // cbxSa_fin
            // 
            this.cbxSa_fin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSa_fin.FormattingEnabled = true;
            this.cbxSa_fin.Location = new System.Drawing.Point(300, 159);
            this.cbxSa_fin.Name = "cbxSa_fin";
            this.cbxSa_fin.Size = new System.Drawing.Size(121, 21);
            this.cbxSa_fin.Sorted = true;
            this.cbxSa_fin.TabIndex = 18;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(12, 243);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(81, 23);
            this.btnRegistrar.TabIndex = 19;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // dtp_ini
            // 
            this.dtp_ini.Location = new System.Drawing.Point(12, 196);
            this.dtp_ini.Name = "dtp_ini";
            this.dtp_ini.Size = new System.Drawing.Size(200, 20);
            this.dtp_ini.TabIndex = 20;
            this.dtp_ini.ValueChanged += new System.EventHandler(this.dtp_ini_ValueChanged);
            // 
            // dtp_fin
            // 
            this.dtp_fin.Location = new System.Drawing.Point(277, 196);
            this.dtp_fin.Name = "dtp_fin";
            this.dtp_fin.Size = new System.Drawing.Size(200, 20);
            this.dtp_fin.TabIndex = 21;
            // 
            // lbl_dni
            // 
            this.lbl_dni.AutoSize = true;
            this.lbl_dni.Location = new System.Drawing.Point(12, 15);
            this.lbl_dni.Name = "lbl_dni";
            this.lbl_dni.Size = new System.Drawing.Size(29, 13);
            this.lbl_dni.TabIndex = 22;
            this.lbl_dni.Text = "DNI:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(106, 228);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 23;
            this.lblStatus.Text = "Status";
            // 
            // lblhorariosRA
            // 
            this.lblhorariosRA.AutoSize = true;
            this.lblhorariosRA.Location = new System.Drawing.Point(257, 19);
            this.lblhorariosRA.Name = "lblhorariosRA";
            this.lblhorariosRA.Size = new System.Drawing.Size(46, 13);
            this.lblhorariosRA.TabIndex = 24;
            this.lblhorariosRA.Text = "Horarios";
            // 
            // dtpEx
            // 
            this.dtpEx.Location = new System.Drawing.Point(553, 196);
            this.dtpEx.Name = "dtpEx";
            this.dtpEx.Size = new System.Drawing.Size(200, 20);
            this.dtpEx.TabIndex = 25;
            // 
            // checkedListEx
            // 
            this.checkedListEx.FormattingEnabled = true;
            this.checkedListEx.Location = new System.Drawing.Point(553, 25);
            this.checkedListEx.Name = "checkedListEx";
            this.checkedListEx.Size = new System.Drawing.Size(200, 154);
            this.checkedListEx.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(622, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Excepciones";
            // 
            // btnAddEx
            // 
            this.btnAddEx.Location = new System.Drawing.Point(553, 228);
            this.btnAddEx.Name = "btnAddEx";
            this.btnAddEx.Size = new System.Drawing.Size(200, 23);
            this.btnAddEx.TabIndex = 28;
            this.btnAddEx.Text = "Añadir a lista";
            this.btnAddEx.UseVisualStyleBackColor = true;
            this.btnAddEx.Click += new System.EventHandler(this.btnAddEx_Click);
            // 
            // btnRemoveEx
            // 
            this.btnRemoveEx.Location = new System.Drawing.Point(553, 257);
            this.btnRemoveEx.Name = "btnRemoveEx";
            this.btnRemoveEx.Size = new System.Drawing.Size(200, 23);
            this.btnRemoveEx.TabIndex = 29;
            this.btnRemoveEx.Text = "Quitar los seleccionados de la lista";
            this.btnRemoveEx.UseVisualStyleBackColor = true;
            this.btnRemoveEx.Click += new System.EventHandler(this.btnRemoveEx_Click);
            // 
            // frmRegistrarAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 287);
            this.Controls.Add(this.btnRemoveEx);
            this.Controls.Add(this.btnAddEx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListEx);
            this.Controls.Add(this.dtpEx);
            this.Controls.Add(this.lblhorariosRA);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lbl_dni);
            this.Controls.Add(this.dtp_fin);
            this.Controls.Add(this.dtp_ini);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.cbxSa_fin);
            this.Controls.Add(this.cbxSa_ini);
            this.Controls.Add(this.cbxVi_fin);
            this.Controls.Add(this.cbxVi_ini);
            this.Controls.Add(this.cbxJu_fin);
            this.Controls.Add(this.cbxJu_ini);
            this.Controls.Add(this.cbxMi_fin);
            this.Controls.Add(this.cbxMi_ini);
            this.Controls.Add(this.cbxMa_fin);
            this.Controls.Add(this.cbxMa_ini);
            this.Controls.Add(this.cbxLun_fin);
            this.Controls.Add(this.cbxLun_ini);
            this.Controls.Add(this.checkSa);
            this.Controls.Add(this.checkVie);
            this.Controls.Add(this.checkJue);
            this.Controls.Add(this.checkMie);
            this.Controls.Add(this.checkMartes);
            this.Controls.Add(this.checkLunes);
            this.Controls.Add(this.txtProfCod);
            this.Name = "frmRegistrarAgenda";
            this.Text = "RegistrarAgenda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProfCod;
        private System.Windows.Forms.CheckBox checkLunes;
        private System.Windows.Forms.CheckBox checkMartes;
        private System.Windows.Forms.CheckBox checkMie;
        private System.Windows.Forms.CheckBox checkJue;
        private System.Windows.Forms.CheckBox checkVie;
        private System.Windows.Forms.CheckBox checkSa;
        private System.Windows.Forms.ComboBox cbxLun_ini;
        private System.Windows.Forms.ComboBox cbxLun_fin;
        private System.Windows.Forms.ComboBox cbxMa_ini;
        private System.Windows.Forms.ComboBox cbxMa_fin;
        private System.Windows.Forms.ComboBox cbxMi_ini;
        private System.Windows.Forms.ComboBox cbxMi_fin;
        private System.Windows.Forms.ComboBox cbxJu_ini;
        private System.Windows.Forms.ComboBox cbxJu_fin;
        private System.Windows.Forms.ComboBox cbxVi_ini;
        private System.Windows.Forms.ComboBox cbxVi_fin;
        private System.Windows.Forms.ComboBox cbxSa_ini;
        private System.Windows.Forms.ComboBox cbxSa_fin;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DateTimePicker dtp_ini;
        private System.Windows.Forms.DateTimePicker dtp_fin;
        private System.Windows.Forms.Label lbl_dni;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblhorariosRA;
        private System.Windows.Forms.DateTimePicker dtpEx;
        private System.Windows.Forms.CheckedListBox checkedListEx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddEx;
        private System.Windows.Forms.Button btnRemoveEx;
    }
}