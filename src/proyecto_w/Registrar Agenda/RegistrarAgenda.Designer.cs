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
            this.grdProfesionales = new System.Windows.Forms.DataGridView();
            this.NroProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.lblFiltroNombre = new System.Windows.Forms.Label();
            this.btnselec_profesional = new System.Windows.Forms.Button();
            this.lblFiltroEspecialidad = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFiltroApellido = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtLastnameFilter = new System.Windows.Forms.TextBox();
            this.cbxEspecialidadFilter = new System.Windows.Forms.ComboBox();
            this.txtNameFilter = new System.Windows.Forms.TextBox();
            this.btnAltaBaja = new System.Windows.Forms.Button();
            this.lblAgendaState = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdProfesionales)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtProfCod
            // 
            this.txtProfCod.Location = new System.Drawing.Point(56, 240);
            this.txtProfCod.Name = "txtProfCod";
            this.txtProfCod.Size = new System.Drawing.Size(100, 20);
            this.txtProfCod.TabIndex = 0;
            this.txtProfCod.TextChanged += new System.EventHandler(this.txtProfCod_TextChanged);
            // 
            // checkLunes
            // 
            this.checkLunes.AutoSize = true;
            this.checkLunes.Location = new System.Drawing.Point(21, 272);
            this.checkLunes.Name = "checkLunes";
            this.checkLunes.Size = new System.Drawing.Size(55, 17);
            this.checkLunes.TabIndex = 1;
            this.checkLunes.Text = "Lunes";
            this.checkLunes.UseVisualStyleBackColor = true;
            // 
            // checkMartes
            // 
            this.checkMartes.AutoSize = true;
            this.checkMartes.Location = new System.Drawing.Point(21, 295);
            this.checkMartes.Name = "checkMartes";
            this.checkMartes.Size = new System.Drawing.Size(58, 17);
            this.checkMartes.TabIndex = 2;
            this.checkMartes.Text = "Martes";
            this.checkMartes.UseVisualStyleBackColor = true;
            // 
            // checkMie
            // 
            this.checkMie.AutoSize = true;
            this.checkMie.Location = new System.Drawing.Point(21, 320);
            this.checkMie.Name = "checkMie";
            this.checkMie.Size = new System.Drawing.Size(71, 17);
            this.checkMie.TabIndex = 3;
            this.checkMie.Text = "Miércoles";
            this.checkMie.UseVisualStyleBackColor = true;
            // 
            // checkJue
            // 
            this.checkJue.AutoSize = true;
            this.checkJue.Location = new System.Drawing.Point(21, 343);
            this.checkJue.Name = "checkJue";
            this.checkJue.Size = new System.Drawing.Size(60, 17);
            this.checkJue.TabIndex = 4;
            this.checkJue.Text = "Jueves";
            this.checkJue.UseVisualStyleBackColor = true;
            // 
            // checkVie
            // 
            this.checkVie.AutoSize = true;
            this.checkVie.Location = new System.Drawing.Point(21, 366);
            this.checkVie.Name = "checkVie";
            this.checkVie.Size = new System.Drawing.Size(61, 17);
            this.checkVie.TabIndex = 5;
            this.checkVie.Text = "Viernes";
            this.checkVie.UseVisualStyleBackColor = true;
            // 
            // checkSa
            // 
            this.checkSa.AutoSize = true;
            this.checkSa.Location = new System.Drawing.Point(21, 389);
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
            this.cbxLun_ini.Location = new System.Drawing.Point(146, 270);
            this.cbxLun_ini.Name = "cbxLun_ini";
            this.cbxLun_ini.Size = new System.Drawing.Size(121, 21);
            this.cbxLun_ini.Sorted = true;
            this.cbxLun_ini.TabIndex = 7;
            // 
            // cbxLun_fin
            // 
            this.cbxLun_fin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLun_fin.FormattingEnabled = true;
            this.cbxLun_fin.Location = new System.Drawing.Point(309, 270);
            this.cbxLun_fin.Name = "cbxLun_fin";
            this.cbxLun_fin.Size = new System.Drawing.Size(121, 21);
            this.cbxLun_fin.Sorted = true;
            this.cbxLun_fin.TabIndex = 8;
            // 
            // cbxMa_ini
            // 
            this.cbxMa_ini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMa_ini.FormattingEnabled = true;
            this.cbxMa_ini.Location = new System.Drawing.Point(146, 293);
            this.cbxMa_ini.Name = "cbxMa_ini";
            this.cbxMa_ini.Size = new System.Drawing.Size(121, 21);
            this.cbxMa_ini.Sorted = true;
            this.cbxMa_ini.TabIndex = 9;
            // 
            // cbxMa_fin
            // 
            this.cbxMa_fin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMa_fin.FormattingEnabled = true;
            this.cbxMa_fin.Location = new System.Drawing.Point(309, 293);
            this.cbxMa_fin.Name = "cbxMa_fin";
            this.cbxMa_fin.Size = new System.Drawing.Size(121, 21);
            this.cbxMa_fin.Sorted = true;
            this.cbxMa_fin.TabIndex = 10;
            // 
            // cbxMi_ini
            // 
            this.cbxMi_ini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMi_ini.FormattingEnabled = true;
            this.cbxMi_ini.Location = new System.Drawing.Point(146, 318);
            this.cbxMi_ini.Name = "cbxMi_ini";
            this.cbxMi_ini.Size = new System.Drawing.Size(121, 21);
            this.cbxMi_ini.Sorted = true;
            this.cbxMi_ini.TabIndex = 11;
            // 
            // cbxMi_fin
            // 
            this.cbxMi_fin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMi_fin.FormattingEnabled = true;
            this.cbxMi_fin.Location = new System.Drawing.Point(309, 318);
            this.cbxMi_fin.Name = "cbxMi_fin";
            this.cbxMi_fin.Size = new System.Drawing.Size(121, 21);
            this.cbxMi_fin.Sorted = true;
            this.cbxMi_fin.TabIndex = 12;
            // 
            // cbxJu_ini
            // 
            this.cbxJu_ini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxJu_ini.FormattingEnabled = true;
            this.cbxJu_ini.Location = new System.Drawing.Point(146, 341);
            this.cbxJu_ini.Name = "cbxJu_ini";
            this.cbxJu_ini.Size = new System.Drawing.Size(121, 21);
            this.cbxJu_ini.Sorted = true;
            this.cbxJu_ini.TabIndex = 13;
            // 
            // cbxJu_fin
            // 
            this.cbxJu_fin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxJu_fin.FormattingEnabled = true;
            this.cbxJu_fin.Location = new System.Drawing.Point(309, 341);
            this.cbxJu_fin.Name = "cbxJu_fin";
            this.cbxJu_fin.Size = new System.Drawing.Size(121, 21);
            this.cbxJu_fin.Sorted = true;
            this.cbxJu_fin.TabIndex = 14;
            // 
            // cbxVi_ini
            // 
            this.cbxVi_ini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVi_ini.FormattingEnabled = true;
            this.cbxVi_ini.Location = new System.Drawing.Point(146, 364);
            this.cbxVi_ini.Name = "cbxVi_ini";
            this.cbxVi_ini.Size = new System.Drawing.Size(121, 21);
            this.cbxVi_ini.Sorted = true;
            this.cbxVi_ini.TabIndex = 15;
            // 
            // cbxVi_fin
            // 
            this.cbxVi_fin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVi_fin.FormattingEnabled = true;
            this.cbxVi_fin.Location = new System.Drawing.Point(309, 364);
            this.cbxVi_fin.Name = "cbxVi_fin";
            this.cbxVi_fin.Size = new System.Drawing.Size(121, 21);
            this.cbxVi_fin.Sorted = true;
            this.cbxVi_fin.TabIndex = 16;
            // 
            // cbxSa_ini
            // 
            this.cbxSa_ini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSa_ini.FormattingEnabled = true;
            this.cbxSa_ini.Location = new System.Drawing.Point(146, 387);
            this.cbxSa_ini.Name = "cbxSa_ini";
            this.cbxSa_ini.Size = new System.Drawing.Size(121, 21);
            this.cbxSa_ini.Sorted = true;
            this.cbxSa_ini.TabIndex = 17;
            // 
            // cbxSa_fin
            // 
            this.cbxSa_fin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSa_fin.FormattingEnabled = true;
            this.cbxSa_fin.Location = new System.Drawing.Point(309, 387);
            this.cbxSa_fin.Name = "cbxSa_fin";
            this.cbxSa_fin.Size = new System.Drawing.Size(121, 21);
            this.cbxSa_fin.Sorted = true;
            this.cbxSa_fin.TabIndex = 18;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(21, 471);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(81, 23);
            this.btnRegistrar.TabIndex = 19;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // dtp_ini
            // 
            this.dtp_ini.Location = new System.Drawing.Point(21, 424);
            this.dtp_ini.Name = "dtp_ini";
            this.dtp_ini.Size = new System.Drawing.Size(200, 20);
            this.dtp_ini.TabIndex = 20;
            this.dtp_ini.ValueChanged += new System.EventHandler(this.dtp_ini_ValueChanged);
            // 
            // dtp_fin
            // 
            this.dtp_fin.Location = new System.Drawing.Point(286, 424);
            this.dtp_fin.Name = "dtp_fin";
            this.dtp_fin.Size = new System.Drawing.Size(200, 20);
            this.dtp_fin.TabIndex = 21;
            // 
            // lbl_dni
            // 
            this.lbl_dni.AutoSize = true;
            this.lbl_dni.Location = new System.Drawing.Point(21, 243);
            this.lbl_dni.Name = "lbl_dni";
            this.lbl_dni.Size = new System.Drawing.Size(29, 13);
            this.lbl_dni.TabIndex = 22;
            this.lbl_dni.Text = "DNI:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(115, 456);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 23;
            this.lblStatus.Text = "Status";
            // 
            // lblhorariosRA
            // 
            this.lblhorariosRA.AutoSize = true;
            this.lblhorariosRA.Location = new System.Drawing.Point(266, 247);
            this.lblhorariosRA.Name = "lblhorariosRA";
            this.lblhorariosRA.Size = new System.Drawing.Size(46, 13);
            this.lblhorariosRA.TabIndex = 24;
            this.lblhorariosRA.Text = "Horarios";
            // 
            // dtpEx
            // 
            this.dtpEx.Location = new System.Drawing.Point(562, 424);
            this.dtpEx.Name = "dtpEx";
            this.dtpEx.Size = new System.Drawing.Size(200, 20);
            this.dtpEx.TabIndex = 25;
            // 
            // checkedListEx
            // 
            this.checkedListEx.FormattingEnabled = true;
            this.checkedListEx.Location = new System.Drawing.Point(562, 253);
            this.checkedListEx.Name = "checkedListEx";
            this.checkedListEx.Size = new System.Drawing.Size(200, 154);
            this.checkedListEx.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(631, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Excepciones";
            // 
            // btnAddEx
            // 
            this.btnAddEx.Location = new System.Drawing.Point(562, 456);
            this.btnAddEx.Name = "btnAddEx";
            this.btnAddEx.Size = new System.Drawing.Size(200, 23);
            this.btnAddEx.TabIndex = 28;
            this.btnAddEx.Text = "Añadir a lista";
            this.btnAddEx.UseVisualStyleBackColor = true;
            this.btnAddEx.Click += new System.EventHandler(this.btnAddEx_Click);
            // 
            // btnRemoveEx
            // 
            this.btnRemoveEx.Location = new System.Drawing.Point(562, 485);
            this.btnRemoveEx.Name = "btnRemoveEx";
            this.btnRemoveEx.Size = new System.Drawing.Size(200, 23);
            this.btnRemoveEx.TabIndex = 29;
            this.btnRemoveEx.Text = "Quitar los seleccionados de la lista";
            this.btnRemoveEx.UseVisualStyleBackColor = true;
            this.btnRemoveEx.Click += new System.EventHandler(this.btnRemoveEx_Click);
            // 
            // grdProfesionales
            // 
            this.grdProfesionales.AllowUserToAddRows = false;
            this.grdProfesionales.AllowUserToDeleteRows = false;
            this.grdProfesionales.AllowUserToResizeColumns = false;
            this.grdProfesionales.AllowUserToResizeRows = false;
            this.grdProfesionales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProfesionales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroProfesional,
            this.NombreProfesional,
            this.ApellidoProfesional});
            this.grdProfesionales.Location = new System.Drawing.Point(285, 35);
            this.grdProfesionales.MultiSelect = false;
            this.grdProfesionales.Name = "grdProfesionales";
            this.grdProfesionales.ReadOnly = true;
            this.grdProfesionales.RowHeadersVisible = false;
            this.grdProfesionales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdProfesionales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdProfesionales.Size = new System.Drawing.Size(302, 105);
            this.grdProfesionales.TabIndex = 15;
            // 
            // NroProfesional
            // 
            this.NroProfesional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NroProfesional.DataPropertyName = "prof_cod";
            this.NroProfesional.Frozen = true;
            this.NroProfesional.HeaderText = "N° Profesional";
            this.NroProfesional.Name = "NroProfesional";
            this.NroProfesional.ReadOnly = true;
            // 
            // NombreProfesional
            // 
            this.NombreProfesional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NombreProfesional.DataPropertyName = "prof_nombre";
            this.NombreProfesional.Frozen = true;
            this.NombreProfesional.HeaderText = "Nombre";
            this.NombreProfesional.Name = "NombreProfesional";
            this.NombreProfesional.ReadOnly = true;
            // 
            // ApellidoProfesional
            // 
            this.ApellidoProfesional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ApellidoProfesional.DataPropertyName = "prof_apellido";
            this.ApellidoProfesional.Frozen = true;
            this.ApellidoProfesional.HeaderText = "Apellido";
            this.ApellidoProfesional.Name = "ApellidoProfesional";
            this.ApellidoProfesional.ReadOnly = true;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(18, 156);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(96, 23);
            this.btnFiltrar.TabIndex = 24;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // lblFiltroNombre
            // 
            this.lblFiltroNombre.AutoSize = true;
            this.lblFiltroNombre.Location = new System.Drawing.Point(15, 43);
            this.lblFiltroNombre.Name = "lblFiltroNombre";
            this.lblFiltroNombre.Size = new System.Drawing.Size(99, 13);
            this.lblFiltroNombre.TabIndex = 16;
            this.lblFiltroNombre.Text = "Nombre Profesional";
            // 
            // btnselec_profesional
            // 
            this.btnselec_profesional.Location = new System.Drawing.Point(285, 156);
            this.btnselec_profesional.Name = "btnselec_profesional";
            this.btnselec_profesional.Size = new System.Drawing.Size(302, 23);
            this.btnselec_profesional.TabIndex = 23;
            this.btnselec_profesional.Text = "Seleccionar";
            this.btnselec_profesional.UseVisualStyleBackColor = true;
            this.btnselec_profesional.Click += new System.EventHandler(this.btnselec_profesional_Click);
            // 
            // lblFiltroEspecialidad
            // 
            this.lblFiltroEspecialidad.AutoSize = true;
            this.lblFiltroEspecialidad.Location = new System.Drawing.Point(15, 99);
            this.lblFiltroEspecialidad.Name = "lblFiltroEspecialidad";
            this.lblFiltroEspecialidad.Size = new System.Drawing.Size(67, 13);
            this.lblFiltroEspecialidad.TabIndex = 18;
            this.lblFiltroEspecialidad.Text = "Especialidad";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdProfesionales);
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Controls.Add(this.lblFiltroNombre);
            this.groupBox1.Controls.Add(this.btnselec_profesional);
            this.groupBox1.Controls.Add(this.lblFiltroApellido);
            this.groupBox1.Controls.Add(this.lblFiltroEspecialidad);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.txtLastnameFilter);
            this.groupBox1.Controls.Add(this.cbxEspecialidadFilter);
            this.groupBox1.Controls.Add(this.txtNameFilter);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 192);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profesional";
            // 
            // lblFiltroApellido
            // 
            this.lblFiltroApellido.AutoSize = true;
            this.lblFiltroApellido.Location = new System.Drawing.Point(15, 71);
            this.lblFiltroApellido.Name = "lblFiltroApellido";
            this.lblFiltroApellido.Size = new System.Drawing.Size(99, 13);
            this.lblFiltroApellido.TabIndex = 17;
            this.lblFiltroApellido.Text = "Apellido Profesional";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(154, 156);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(101, 23);
            this.btnLimpiar.TabIndex = 22;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtLastnameFilter
            // 
            this.txtLastnameFilter.Location = new System.Drawing.Point(120, 68);
            this.txtLastnameFilter.MaxLength = 15;
            this.txtLastnameFilter.Name = "txtLastnameFilter";
            this.txtLastnameFilter.Size = new System.Drawing.Size(159, 20);
            this.txtLastnameFilter.TabIndex = 20;
            // 
            // cbxEspecialidadFilter
            // 
            this.cbxEspecialidadFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEspecialidadFilter.FormattingEnabled = true;
            this.cbxEspecialidadFilter.Location = new System.Drawing.Point(120, 96);
            this.cbxEspecialidadFilter.Name = "cbxEspecialidadFilter";
            this.cbxEspecialidadFilter.Size = new System.Drawing.Size(159, 21);
            this.cbxEspecialidadFilter.TabIndex = 21;
            // 
            // txtNameFilter
            // 
            this.txtNameFilter.Location = new System.Drawing.Point(120, 40);
            this.txtNameFilter.MaxLength = 15;
            this.txtNameFilter.Name = "txtNameFilter";
            this.txtNameFilter.Size = new System.Drawing.Size(159, 20);
            this.txtNameFilter.TabIndex = 19;
            // 
            // btnAltaBaja
            // 
            this.btnAltaBaja.Location = new System.Drawing.Point(658, 181);
            this.btnAltaBaja.Name = "btnAltaBaja";
            this.btnAltaBaja.Size = new System.Drawing.Size(104, 23);
            this.btnAltaBaja.TabIndex = 25;
            this.btnAltaBaja.Text = "Alta/Baja agenda";
            this.btnAltaBaja.UseVisualStyleBackColor = true;
            this.btnAltaBaja.Click += new System.EventHandler(this.btnAltaBaja_Click);
            // 
            // lblAgendaState
            // 
            this.lblAgendaState.AutoSize = true;
            this.lblAgendaState.Location = new System.Drawing.Point(655, 83);
            this.lblAgendaState.Name = "lblAgendaState";
            this.lblAgendaState.Size = new System.Drawing.Size(105, 13);
            this.lblAgendaState.TabIndex = 31;
            this.lblAgendaState.Text = "Estado de la agenda";
            // 
            // frmRegistrarAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 521);
            this.Controls.Add(this.lblAgendaState);
            this.Controls.Add(this.btnAltaBaja);
            this.Controls.Add(this.groupBox1);
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
            this.Load += new System.EventHandler(this.frmRegistrarAgenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdProfesionales)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.DataGridView grdProfesionales;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoProfesional;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label lblFiltroNombre;
        private System.Windows.Forms.Button btnselec_profesional;
        private System.Windows.Forms.Label lblFiltroEspecialidad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFiltroApellido;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtLastnameFilter;
        private System.Windows.Forms.ComboBox cbxEspecialidadFilter;
        private System.Windows.Forms.TextBox txtNameFilter;
        private System.Windows.Forms.Button btnAltaBaja;
        private System.Windows.Forms.Label lblAgendaState;
    }
}