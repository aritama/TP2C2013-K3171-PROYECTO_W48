using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;
using System.Text.RegularExpressions;


namespace proyecto_w.ABM_Profesional
{
    public partial class AltaProfesionalForm : Form
    {
        private string profCod;
        private void onlyNumbers(KeyPressEventArgs ev)
        {
            if (!Char.IsControl(ev.KeyChar) && !Char.IsNumber(ev.KeyChar))
                ev.Handled = true;
        }

        private bool isEmail(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
                return false;

            Regex EmailAddress = new Regex(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");

            return EmailAddress.IsMatch(emailAddress);
        }

        private bool validarCampos()
        {
            //TODO: Poner los mensajes en todos los campos. @FacuE porfavor hacelo xD
            if (this.txtNombre.Text == "" || this.txtNombre.Text.Length < 3)
            {
                MessageBox.Show("El campo Nombre esta Vacio o no es valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (this.txtApellido.Text == "" || this.txtApellido.Text.Length < 3)
            {
                MessageBox.Show("El campo Apellido esta Vacio o no es valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (this.txtNroDoc.Text == "" || this.txtNroDoc.Text.Length < 5)
            {
                MessageBox.Show("El campo Numero de Documento esta Vacio o no es valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (this.txtDireccion.Text == "" || this.txtDireccion.Text.Length < 4)
            {
                MessageBox.Show("El campo Direccion esta Vacio o no es valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (this.txtTelefono.Text == "" || this.txtTelefono.Text.Length < 5)
            {
                MessageBox.Show("El campo Telefono esta Vacio o no es valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (this.txtMail.Text == "" || this.txtMail.Text.Length < 6)
            {
                MessageBox.Show("El campo Email esta Vacio o no es valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!this.isEmail(this.txtMail.Text))
            {
                MessageBox.Show("Debe poner un email valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (this.txtMatricula.Text == "" || this.txtMatricula.Text.Length < 3)
            {
                MessageBox.Show("El campo Matricula esta Vacio o no es valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (this.lstEspecialidades.SelectedItems.Count == 0)
            {
                MessageBox.Show("No selecciono ninguna especialidad, debe seleccional al menos una", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private ConexionSQL conn = ConexionSQL.Instance;

        private void makeOnlyModifiedForm()
        {
            this.txtNombre.Enabled = false;
            this.txtApellido.Enabled = false;
            this.cbxTipoDoc.Enabled = false;
            this.txtNroDoc.Enabled = false;
            this.dtmFechaNac.Enabled = false;
        }

        public AltaProfesionalForm(string prof_cod)
        {
            this.profCod = prof_cod;
            InitializeComponent();
            this.btnRegistrar.Text = "Modificar";
            this.makeOnlyModifiedForm();
            this.cbxTipoDoc.Items.Add("DNI");
            this.cbxTipoDoc.SelectedIndex = 0;
            this.cbxSexo.Items.Add("No determinado");
            this.cbxSexo.Items.Add("Masculino");
            this.cbxSexo.Items.Add("Femenino");

            string queryEspecialidades = string.Format("SELECT esp_descripcion FROM PROYECTO_W.Especialidad");
            DataRowCollection especialidades = this.conn.ejecutarQuery(queryEspecialidades).Rows;
            foreach (DataRow row in especialidades)
                this.lstEspecialidades.Items.Add(row["esp_descripcion"]);

            //Especialidades del profesional
            string queryProfesional = string.Format("SELECT esp_descripcion FROM PROYECTO_W.Especialidad AS E JOIN PROYECTO_W.EspecialidadPorProfesional AS EP ON E.esp_cod=EP.espxprof_esp_cod WHERE espxprof_prof_cod={0}", prof_cod);
            DataRowCollection especialidadesProfesional = this.conn.ejecutarQuery(queryProfesional).Rows;
            foreach (DataRow row in especialidadesProfesional)
                lstEspecialidades.SelectedItem = row["esp_descripcion"].ToString();

            string query = string.Format("SELECT prof_cod, prof_nombre, prof_apellido, prof_username, prof_doc_tipo, prof_doc_nro, prof_direccion, prof_telefono, prof_mail, prof_fecha_nac, prof_sexo, prof_matricula FROM PROYECTO_W.Profesional WHERE prof_estado='H' AND prof_cod={0}", prof_cod);
            DataRow profesional = this.conn.ejecutarQuery(query).Rows[0];
            this.txtApellido.Text = profesional["prof_apellido"].ToString();
            this.txtNombre.Text = profesional["prof_nombre"].ToString();
            this.txtDireccion.Text = profesional["prof_direccion"].ToString();

            if (profesional["prof_sexo"].ToString() == "NULL")
                this.cbxSexo.SelectedIndex = 0;
            else if (profesional["prof_sexo"].ToString() == "M")
                this.cbxSexo.SelectedIndex = 1;
            else
                this.cbxSexo.SelectedIndex = 2;
            
            this.txtMail.Text = profesional["prof_mail"].ToString();
            this.txtMatricula.Text = profesional["prof_matricula"].ToString();
            this.txtNroDoc.Text = profesional["prof_doc_nro"].ToString();
            this.dtmFechaNac.Text = profesional["prof_fecha_nac"].ToString();
            this.txtTelefono.Text = profesional["prof_telefono"].ToString();
            this.btnLimpiar.Visible = false;
        }

        public AltaProfesionalForm()
        {
            InitializeComponent();
            string query = string.Format("SELECT esp_descripcion FROM PROYECTO_W.Especialidad");
            DataRowCollection queryExecuted = this.conn.ejecutarQuery(query).Rows;
            foreach (DataRow row in queryExecuted)
                this.lstEspecialidades.Items.Add(row["esp_descripcion"]);
            this.cbxTipoDoc.Items.Add("DNI");
            this.cbxTipoDoc.SelectedIndex = 0;
            this.cbxSexo.Items.Add("No determinado");
            this.cbxSexo.Items.Add("Masculino");
            this.cbxSexo.Items.Add("Femenino");
            this.cbxSexo.SelectedIndex = 0;
        }

        private string darAltaProf(string nombre, string apellido, string tipo_doc, string nro_doc,string direccion, string telefono, string mail, string fecha_nac, string sexo, string matricula)
        {
            //Da de alta un profesional y devuelve el codProf del mismo
            string query = string.Format("INSERT INTO PROYECTO_W.Profesional(prof_nombre, prof_apellido, prof_doc_tipo, prof_doc_nro, prof_direccion, prof_telefono, prof_mail, prof_fecha_nac, prof_sexo, prof_matricula) VALUES('{0}','{1}','{2}',{3},'{4}',{5},'{6}','{7}',{8},'{9}');", nombre, apellido, tipo_doc, nro_doc, direccion, telefono, mail, fecha_nac, sexo, matricula);
            this.conn.ejecutarQuery(query);
            query = string.Format("SELECT prof_cod FROM PROYECTO_W.Profesional WHERE prof_nombre='{0}' AND prof_apellido='{1}' AND prof_mail='{2}' AND prof_matricula='{3}'", nombre, apellido, mail, matricula);
            return this.conn.ejecutarQuery(query).Rows[0]["prof_cod"].ToString();
        }

        private void darAltaEspecialidadAProfesional(string prof_cod, ListBox.SelectedObjectCollection Especialidades)
        {
            string espCodQuery, espCod, insertQuery;

            foreach (string especialidad in Especialidades)
            {
                espCodQuery = string.Format("SELECT esp_cod FROM PROYECTO_W.Especialidad WHERE esp_descripcion='{0}'", especialidad);
                espCod = this.conn.ejecutarQuery(espCodQuery).Rows[0]["esp_cod"].ToString();
                insertQuery = string.Format("INSERT INTO PROYECTO_W.EspecialidadPorProfesional VALUES ({0}, {1})", prof_cod, espCod);
                this.conn.ejecutarQuery(insertQuery);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string sexo = "NULL";
            switch (this.cbxSexo.SelectedIndex)
            {
                case 1:
                    sexo = "'M'";
                    break;
                case 2:
                    sexo = "'F'";
                    break;

            }
            if (this.validarCampos())
               // MessageBox.Show("Algunos campos estan incorrectos. Verifique eso y vuelva a intentarlo");
            //else
            {
                if (this.btnRegistrar.Text == "Registrar")
                {
                    string nombre, apellido, telefono, nro_doc, fecha_nac, tipo_doc, direccion, mail, matricula;
                    nombre = this.txtNombre.Text;
                    apellido = this.txtApellido.Text;
                    telefono = this.txtTelefono.Text;
                    nro_doc = this.txtNroDoc.Text;
                    tipo_doc = this.cbxTipoDoc.SelectedItem.ToString();
                    direccion = this.txtDireccion.Text;
                    mail = this.txtMail.Text;
                    matricula = this.txtMatricula.Text;
                    fecha_nac = this.dtmFechaNac.Value.ToString("dd/MM/yyyy HH:mm"); 
                    string prof_cod = this.darAltaProf(nombre, apellido, tipo_doc, nro_doc, direccion, telefono, mail, fecha_nac, sexo, matricula);
                    this.darAltaEspecialidadAProfesional(prof_cod, this.lstEspecialidades.SelectedItems);
                    MessageBox.Show("Profesional dado de Alta Correctamente");
                    this.Close();
                }
                else if (this.btnRegistrar.Text == "Modificar")
                {
                    if (this.lstEspecialidades.SelectedItems.Count == 0)
                        MessageBox.Show("Debe seleccionar almenos una especialidad");
                    else if (this.txtMatricula.Text.Length <= 3)
                        MessageBox.Show("El campo Matricula debe tener almenos 4 numeros. No puede estar Vacio");
                    else
                    {
                        //Modifico los datos personales
                        string query = string.Format("UPDATE PROYECTO_W.Profesional SET prof_direccion='{0}', prof_mail='{1}', prof_sexo={2}, prof_matricula='{3}', prof_telefono={4} WHERE prof_cod={5}", this.txtDireccion.Text, this.txtMail.Text, sexo, this.txtMatricula.Text, this.txtTelefono.Text, this.profCod);
                        this.conn.ejecutarQuery(query);

                        //Borro todas las especialidades que habian registradas para este profesional y Seteo estas nuevas
                        query = string.Format("DELETE FROM PROYECTO_W.EspecialidadPorProfesional WHERE espxprof_prof_cod={0}", this.profCod);
                        this.conn.ejecutarQuery(query);

                        //AGrego las nuevas especialidades
                        string espCodQuery, espCod, insertQuery;
                        foreach (string especialidad in this.lstEspecialidades.SelectedItems)
                        {
                            espCodQuery = string.Format("SELECT esp_cod FROM PROYECTO_W.Especialidad WHERE esp_descripcion='{0}'", especialidad);
                            espCod = this.conn.ejecutarQuery(espCodQuery).Rows[0]["esp_cod"].ToString();
                            insertQuery = string.Format("INSERT INTO PROYECTO_W.EspecialidadPorProfesional VALUES ({0}, {1})", this.profCod, espCod);
                            this.conn.ejecutarQuery(insertQuery);
                        }
                        MessageBox.Show("Profesional modificado exitosamente");
                        this.Close();
                    }
                }
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.onlyNumbers(e);
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.onlyNumbers(e);
        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.onlyNumbers(e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtMail.Text = "";
            txtMatricula.Text = "";
            txtNombre.Text = "";
            txtNroDoc.Text = "";
            txtTelefono.Text = "";
            cbxSexo.SelectedIndex = 0;
            cbxTipoDoc.SelectedIndex = 0;
        }
    }
}
