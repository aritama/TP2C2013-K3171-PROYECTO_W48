using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;
using proyecto_w.Login;
using proyecto_w.ABM_Afiliado;
using System.Text.RegularExpressions;
using System.Globalization;

namespace proyecto_w.ABM_Afiliado
{
    public partial class AltaAfiliadoForm : Form
    {
        private ConexionSQL connectionSQL = ConexionSQL.Instance;
        private Dictionary<string, string> estadoCivilMap = new Dictionary<string, string>();
        private Random rnd = new Random();
        private string afiliadoNumber;
        private StringBuilder strBuilder = new StringBuilder();
        private bool onlyUse = false;
        private bool modifyAfil = false;

        private bool isEmail(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
                return false;

            Regex EmailAddress = new Regex(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");

            return EmailAddress.IsMatch(emailAddress);
        }

        public AltaAfiliadoForm(string afiliadoRelacionado, int sonNumber)
        {
            InitializeComponent();
            this.afiliadoNumber = afiliadoRelacionado.Remove(afiliadoRelacionado.Length - 2, 2);
            this.afiliadoNumber += "03";
            this.afiliadoNumber = (Int32.Parse(this.afiliadoNumber) + sonNumber).ToString();
            this.initializeComboboxs();
            this.onlyUse = true;
        }

        public AltaAfiliadoForm(DataRow afiliado)
        {
            InitializeComponent();
            initializeComboboxs();
            this.afiliadoNumber = afiliado["afil_nro"].ToString();
            this.dtmFechaNac.Value = DateTime.Parse(afiliado["afil_fecha_nac"].ToString());
            this.txtNombre.Enabled = false;
            this.txtApellido.Enabled = false;
            this.cbxTipoDoc.Visible = false;
            this.txtNroDoc.Enabled = false;
            this.dtmFechaNac.Enabled = false;

            this.txtNombre.Text = afiliado["afil_nombre"].ToString();
            this.txtApellido.Text = afiliado["afil_apellido"].ToString();
            this.txtNroDoc.Text = afiliado["afil_doc_nro"].ToString();
        
            this.txtDireccion.Text = afiliado["afil_direccion"].ToString();
            this.txtMail.Text = afiliado["afil_mail"].ToString();
            this.txtTelefono.Text = afiliado["afil_telefono"].ToString();
            this.txtCantFamiliares.Text = afiliado["afil_cant_pers_a_cargo"].ToString();

            if (afiliado["afil_sexo"].ToString() == "NULL")
                this.cbxSexo.SelectedItem = "No Determinado";
            else if(afiliado["afil_sexo"].ToString() == "M")
                this.cbxSexo.SelectedItem = "Masculino";
            else if (afiliado["afil_sexo"].ToString() == "F")
                this.cbxSexo.SelectedItem = "Femenino";

            if (afiliado["afil_estado_civil"].ToString() == "NULL")
                this.cbxEstadoCivil.SelectedItem = "No Determinado";
            else if (afiliado["afil_estado_civil"].ToString() == "S")
                this.cbxEstadoCivil.SelectedItem = "Soltero";
            else if (afiliado["afil_estado_civil"].ToString() == "Ca")
                this.cbxEstadoCivil.SelectedItem = "Casado";
            else if (afiliado["afil_estado_civil"].ToString() == "Co")
                this.cbxEstadoCivil.SelectedItem = "Concubinato";
            else if (afiliado["afil_estado_civil"].ToString() == "V")
                this.cbxEstadoCivil.SelectedItem = "Viudo";
            else if (afiliado["afil_estado_civil"].ToString() == "D")
                this.cbxEstadoCivil.SelectedItem = "Divorsiado";

            this.cbxPlanMedico.SelectedItem = afiliado["plan_descripcion"].ToString();

            this.btnCancel.Visible = true;
            this.modifyAfil = true;
            this.btnRegistrar.Text = "Modificar Afiliado";
            this.btnLimpiar.Visible = false;
        }

        public AltaAfiliadoForm(string afiliadoRelacionado)
        {
            InitializeComponent();
            this.afiliadoNumber = afiliadoRelacionado.Remove(afiliadoRelacionado.Length - 2, 2);
            this.afiliadoNumber += "02";
            this.initializeComboboxs();
            this.onlyUse = true;
        }

        private void initializeComboboxs()
        {
            // cargarComboBox("Proyecto_W.Afiliado", "afil_doc_tipo", cbxTipoDoc);
            // cargarComboBox("Proyecto_W.Afiliado", "afil_sexo", cbxSexo);
            cbxTipoDoc.Items.Add("DNI");
            cbxTipoDoc.SelectedIndex = 0;

            cbxSexo.Items.Add("No determinado"); //Null
            cbxSexo.Items.Add("Femenino"); //F
            cbxSexo.Items.Add("Masculino"); //M
            cbxSexo.SelectedIndex = 0;
//            cargarComboBox("Proyecto_W.Afiliado", "afil_estado_civil", cbxEstadoCivil);

            this.estadoCivilMap["Soltero"] = "S";
            this.estadoCivilMap["Casado"] = "Ca";
            this.estadoCivilMap["Viudo"] = "V";
            this.estadoCivilMap["Concubinato"] = "Co";
            this.estadoCivilMap["Divorsiado"] = "D";

            cbxEstadoCivil.Items.Add("No determinado");
            cbxEstadoCivil.Items.Add("Soltero"); //S
            cbxEstadoCivil.Items.Add("Casado"); //Ca
            cbxEstadoCivil.Items.Add("Viudo"); //V
            cbxEstadoCivil.Items.Add("Concubinato"); //Co
            cbxEstadoCivil.Items.Add("Divorsiado"); //D
            cbxEstadoCivil.SelectedIndex = 0;

            string query = string.Format("SELECT plan_descripcion FROM [GD2C2013].[PROYECTO_W].[Plan]");
            DataRowCollection planes = this.connectionSQL.ejecutarQuery(query).Rows;

            foreach (DataRow row in planes) 
                cbxPlanMedico.Items.Add(row["plan_descripcion"]);

            cbxPlanMedico.SelectedIndex = 0;
            this.btnCancel.Visible = false;
        }

        public AltaAfiliadoForm()
        {
            InitializeComponent();
            this.afiliadoNumber = null;
            this.initializeComboboxs();

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.modifyAfil)
            {
                if (!validarCamposModificacion())
                {
                    string query = string.Format("UPDATE PROYECTO_W.Afiliado SET afil_direccion='{0}', afil_telefono={1}, afil_mail='{2}', afil_cant_pers_a_cargo={3}, ", this.txtDireccion.Text, this.txtTelefono.Text, this.txtMail.Text, this.txtCantFamiliares.Text);

                    if (this.cbxSexo.SelectedItem.ToString() == "No determinado")
                        query += "afil_sexo=NULL, ";
                    else
                        query += string.Format("afil_sexo='{0}', ", this.cbxSexo.SelectedItem.ToString()[0]);

                    if (this.cbxEstadoCivil.SelectedItem.ToString() == "No determinado")
                        query += "afil_estado_civil=NULL, ";
                    else
                        query += string.Format("afil_estado_civil='{0}', ", this.estadoCivilMap[this.cbxEstadoCivil.SelectedItem.ToString()]);

                    string planInteger = this.connectionSQL.ejecutarQuery(string.Format("SELECT plan_cod FROM [GD2C2013].[PROYECTO_W].[Plan] WHERE plan_descripcion='{0}'", this.cbxPlanMedico.SelectedItem.ToString())).Rows[0][0].ToString();

                    query += string.Format("afil_plan_cod={0} ", planInteger);

                    query += string.Format("WHERE afil_nro={0}", this.afiliadoNumber);
                    this.connectionSQL.ejecutarQuery(query);
                    this.modifyAfil = false;
                    MessageBox.Show("Afiliado Modificado Correctamente");
                    this.Close();
                }
            }
            else
            {
                string queryAlta = "SET DATEFORMAT mdy INSERT INTO PROYECTO_W.Afiliado (afil_nombre, afil_apellido, afil_doc_tipo, afil_doc_nro, afil_direccion, afil_telefono, afil_mail, afil_fecha_nac, afil_plan_cod, afil_cant_pers_a_cargo, afil_nro, afil_sexo, afil_estado_civil) VALUES(";
                /* Begin - Declaracion de variables para cada campo en el form Alta */
                string afil_nro = string.Format("10{0}01", this.rnd.Next(8000, 9999).ToString());

                if (this.afiliadoNumber == null)
                {
                    string query = string.Format("SELECT afil_nro FROM PROYECTO_W.Afiliado WHERE afil_nro='{0}'", afil_nro);
                    DataTable results = this.connectionSQL.ejecutarQuery(query);
                    while (results.Rows.Count != 0)
                    {
                        afil_nro = string.Format("10{0}01", this.rnd.Next(8000, 9999).ToString());
                        query = string.Format("SELECT afil_nro FROM PROYECTO_W.Afiliado WHERE afil_nro='{0}'", afil_nro);
                        results = this.connectionSQL.ejecutarQuery(query);
                    }
                    this.afiliadoNumber = afil_nro;
                }

                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string tipodoc = cbxTipoDoc.Text;
                string nrodoc = txtNroDoc.Text;
                string direccion = txtDireccion.Text;
                string telefono = txtTelefono.Text;
                string mail = txtMail.Text;
                string fechanac = dtmFechaNac.Text;
                string sexo = cbxSexo.Text;
                string estadocivil = cbxEstadoCivil.Text; ;

                string cantfamiliares = txtCantFamiliares.Text;
                string queryPlan = string.Format("SELECT plan_cod FROM [GD2C2013].[PROYECTO_W].[Plan] WHERE plan_descripcion = '{0}'", cbxPlanMedico.Text);
                string planmed = this.connectionSQL.ejecutarQuery(queryPlan).Rows[0]["plan_cod"].ToString();
                /* End - Declaracion de variables para cada campo en el form Alta */

                if (!validarCamposVacios())
                {
                    queryAlta += string.Format("'{0}','{1}','{2}',{3},'{4}',{5},'{6}','{7}',{8},{9},{10},", nombre, apellido, tipodoc, nrodoc, direccion, telefono, mail, fechanac, planmed, cantfamiliares, this.afiliadoNumber);
                    if (sexo == "No determinado") queryAlta += "NULL,";
                    else queryAlta += string.Format("'{0}',", sexo[0]);

                    if (estadocivil == "No determinado") queryAlta += "NULL)";
                    else queryAlta += string.Format("'{0}')", estadoCivilMap[estadocivil]);

                    connectionSQL.ejecutarQuery(queryAlta);
                    MessageBox.Show("Afiliado dado de alta");

                    //verificacion por conyuge
                    if (onlyUse)
                    {
                        this.Close();
                    }
                    else
                    {
                        if (estadocivil.Equals("Casado") || estadocivil.Equals("Concubinato"))
                        {
                            var win_conyugue = MessageBox.Show("¿Desea afiliar a su conyugue?", "Atención", MessageBoxButtons.YesNo);
                            if (win_conyugue == DialogResult.No)
                                this.Close();
                            else
                            {
                                this.Hide();
                                AltaAfiliadoForm frm = new AltaAfiliadoForm(this.afiliadoNumber);
                                frm.ShowDialog();
                                this.Show();
                                this.Close();
                            }

                        }
                        //verificacion por conyuge

                        //verificacion por hijo o familiares a cargo
                        for (int i = 0; i < Convert.ToInt16(txtCantFamiliares.Text); i++)
                        {
                            var win_familiar = MessageBox.Show("¿Desea afiliar a otro familiar?", "Atención", MessageBoxButtons.YesNo);
                            if (win_familiar == DialogResult.No)
                                this.Close();
                            else
                            {
                                this.Hide();
                                AltaAfiliadoForm frm = new AltaAfiliadoForm(this.afiliadoNumber, i);
                                frm.ShowDialog();
                                this.Show();
                                this.Close();
                            }
                        }
                        //verificacion por hijo o familiares a cargo
                    }
                    this.Close();
                }

                //if (validarCamposTipos()) return;

                //Hacer el insert del afiliado - HECHO
                //Si el afiliado tiene como estado civil 'casado' o 'en concubinato' mostrar una pantalla
                //de alta. Se deberá crear otro form tanto para conyugues como hijos que sea COPIA EXACTA del form
                // Alta Afiliado pero sin preguntar por conyugue o hijo.
                //Una vez registrado el conyugue, hacer un for por la cantidad de hijos y preguntar
                //por cada uno si lo quiere afiliar, y abrir una pantalla de alta.

                //            queryAlta = string.Format("INSERT INTO PROYECTO_W.Afiliado (afil_nombre, afil_apellido, afil_doc_tipo, afil_doc_nro, afil_direccion, afil_telefono, afil_sexo, afil_plan_cod, afil_cant_pers_a_cargo, afil_estado_civil, afil_mail, afil_fecha_nac) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')", nombre, apellido, tipodoc, nrodoc, direccion, telefono, sexo, planmed, cantfamiliares, estadocivil, mail, fechanac);
            }
            
        }

        private bool validarCamposVacios()
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar nombre.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Focus();
                return true;
            }
            if (txtApellido.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar apellido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtApellido.Focus();
                return true;
            }
            if (cbxTipoDoc.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar tipo de documento.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxTipoDoc.Focus();
                return true;
            }
            if (txtNroDoc.Text == "")
            {
                MessageBox.Show("Ingresar DNI.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroDoc.Focus();
                return true;
            }
            if (txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar dirección.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDireccion.Focus();
                return true;
            }
            if (txtTelefono.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar telefono.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTelefono.Focus();
                return true;
            }

            if (txtMail.Text.Trim() == "" || !this.isEmail(txtMail.Text))
            {
                MessageBox.Show("Ingresar mail.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMail.Focus();
                return true;
            }
            if (cbxSexo.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar sexo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxSexo.Focus();
                return true;
            }
            if (cbxEstadoCivil.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar estado civil.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxEstadoCivil.Focus();
                return true;
            }
            if (txtCantFamiliares.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar cantidad de hijos o familiares a cargo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCantFamiliares.Focus();
                return true;
            }
            if (cbxPlanMedico.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar plan medico.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxPlanMedico.Focus();
                return true;
            }

            return false;
        }

        public void cargarComboBox(string tabla, string campo, ComboBox comboBox)
        {
            string query = string.Format("SELECT DISTINCT {0} FROM {1}", campo, tabla);
            DataTable items = this.connectionSQL.ejecutarQuery(query);
            comboBox.Items.Clear();
            foreach (DataRow fila in items.Rows)
            {
                comboBox.Items.Add(fila[0]);
            }


        }


        private void onlyNumbers(KeyPressEventArgs ev)
        {
            if (!Char.IsControl(ev.KeyChar) && !Char.IsNumber(ev.KeyChar))
                ev.Handled = true;
        }

        private void txtCantFamiliares_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.onlyNumbers(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.onlyNumbers(e);
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
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
            txtCantFamiliares.Text = "";
            txtDireccion.Text = "";
            txtNombre.Text = "";
            txtNroDoc.Text = "";
            txtTelefono.Text = "";
            txtMail.Text = "";
            cbxTipoDoc.SelectedIndex = 0;
            cbxSexo.SelectedIndex = 0;
            cbxEstadoCivil.SelectedIndex = 0;
            cbxPlanMedico.SelectedIndex = 0;
        }

        private bool validarCamposModificacion()
        {
            if (txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar dirección.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDireccion.Focus();
                return true;
            }
            if (txtTelefono.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar telefono.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTelefono.Focus();
                return true;
            }

            if (txtMail.Text.Trim() == "" || !this.isEmail(txtMail.Text))
            {
                MessageBox.Show("Ingresar mail.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMail.Focus();
                return true;
            }
            if (txtCantFamiliares.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar cantidad de hijos o familiares a cargo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCantFamiliares.Focus();
                return true;
            }
            else
            {
                return false;
            }
        }

        //private bool validarCamposTipos()
        //{
        //    if txtNombre.GetType()
        //}

    }
}
