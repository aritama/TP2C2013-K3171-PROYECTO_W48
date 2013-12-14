using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;

namespace proyecto_w.Registro_de_Llegada
{
    public partial class frmRegistrarLlegada : Form
    {
        private ConexionSQL conn = ConexionSQL.Instance;

        private void onlyNumbers(KeyPressEventArgs ev)
        {
            if (!Char.IsControl(ev.KeyChar) && !Char.IsNumber(ev.KeyChar))
                ev.Handled = true;
        }

        public frmRegistrarLlegada()
        {
            InitializeComponent();
            string query = string.Format("SELECT prof_cod, prof_nombre, prof_apellido FROM PROYECTO_W.Profesional WHERE prof_estado = 'H'");
            this.grdProfesionales.DataSource = this.conn.ejecutarQuery(query);
            query = string.Format("SELECT esp_descripcion FROM PROYECTO_W.Especialidad");
            DataRowCollection especialidades = this.conn.ejecutarQuery(query).Rows;

            cbxEspecialidadFilter.Items.Add("Vacio");
            cbxEspecialidadFilter.SelectedIndex = 0;
            foreach (DataRow especialidad in especialidades)
            {
                cbxEspecialidadFilter.Items.Add(especialidad["esp_descripcion"].ToString());
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string apellido = this.txtLastnameFilter.Text;
            string nombre = this.txtNameFilter.Text;
            string especialidad = this.cbxEspecialidadFilter.SelectedItem.ToString();

            if (apellido != "" || nombre != "" || especialidad != "Vacio")
            {
                string query = string.Format("SELECT prof_cod, prof_nombre, prof_apellido FROM PROYECTO_W.Profesional");

                List<String> conditions = new List<String>();

                if (apellido != "")
                    conditions.Add(string.Format("prof_apellido='{0}'", apellido));
                //conditions.Add();

                if (nombre != "")
                    conditions.Add(string.Format("prof_nombre='{0}'", nombre));
                //  conditions[conditions.Length] = string.Format("prof_nombre='{0}'", apellido);
                //conditions.Add();

                if (especialidad != "Vacio")
                    query = string.Format("SELECT P.prof_cod, P.prof_nombre, P.prof_apellido FROM PROYECTO_W.Profesional AS P JOIN PROYECTO_W.EspecialidadPorProfesional AS EP ON EP.espxprof_prof_cod=P.prof_cod JOIN PROYECTO_W.Especialidad AS E ON E.esp_cod=EP.espxprof_esp_cod WHERE E.esp_descripcion='{0}'", especialidad);

                if(conditions.Count > 0)
                {
                    if (query.Contains("WHERE"))
                    {
                        query += string.Format(" AND {0}", string.Join(" AND ", conditions.ToArray()));
                    }
                    else
                    {
                        query += string.Format(" WHERE {0}", string.Join(" AND ", conditions.ToArray()));
                    }
                    query += string.Format(" AND prof_estado = 'H'");
                }
                

                this.grdProfesionales.DataSource = this.conn.ejecutarQuery(query);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            string query = string.Format("SELECT prof_cod, prof_nombre, prof_apellido FROM PROYECTO_W.Profesional");
            this.grdProfesionales.DataSource = this.conn.ejecutarQuery(query);
            this.txtNameFilter.Text = "";
            this.txtLastnameFilter.Text = "";
            this.cbxEspecialidadFilter.SelectedIndex = 0;
            this.txtBono.Enabled = false;
            this.txtAfilNro.Text = "";
            this.grdTurnos.DataSource = null;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (grdProfesionales.SelectedRows.Count == 0)
                MessageBox.Show("Debe Seleccionar un Profesional", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                int selectedrowindex = grdProfesionales.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = grdProfesionales.Rows[selectedrowindex];  
                string prof_cod = Convert.ToString(selectedRow.Cells["NroProfesional"].Value);           

                //string date = string.Format("{0:yyyy-M-d HH:mm:ss}", DateTime.Now);
                string query = string.Format("DECLARE @FECHA DATETIME");
                query += string.Format(" SET @FECHA = PROYECTO_W.F_FECHA_CONFIG()");
                query += string.Format(" SELECT T.turno_nro AS Turno, T.turno_afil_nro AS Nro_Afil, A.afil_nombre AS Nom_Afil, A.afil_apellido AS Apell_Afil, T.turno_fecha");
                query += string.Format(" FROM PROYECTO_W.Turno AS T JOIN PROYECTO_W.Afiliado AS A ON A.afil_nro=T.turno_afil_nro");
                query += string.Format(" WHERE CAST(T.turno_fecha AS DATE) = CAST(@FECHA AS DATE) AND T.turno_estado = 'P' AND T.turno_prof_cod={0}",  prof_cod);
                DataTable results = this.conn.ejecutarQuery(query);
                int amount_results = results.Rows.Count;
                this.grdTurnos.DataSource = results;

                if(amount_results > 0)
                    this.txtBono.Enabled = true;
                else
                    this.txtBono.Enabled = false;
            }
        }

        private void txtAfilNro_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.onlyNumbers(e);
        }

        private void txtBono_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.onlyNumbers(e);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if ((validar_campos() == true) && (validar_nro_afil() == true))
            {
                string query = string.Format("SELECT bonocons_estado");
                query += string.Format(" FROM PROYECTO_W.BonoConsulta JOIN PROYECTO_W.BonoAdquirido ON BonoConsulta.bonocons_bonadq_cod = BonoAdquirido.bonadq_cod");
                query += string.Format(" WHERE SUBSTRING( (CAST(bonadq_afil_nro AS VARCHAR)), 1, 6) = {0} AND bonocons_cod={1}", txtAfilNro.Text.Substring(0,6), this.txtBono.Text);
                DataTable results = this.conn.ejecutarQuery(query);
                if (results.Rows.Count != 0)
                {
                    if (results.Rows[0][0].ToString() == "S")
                    {
                        query = string.Format("UPDATE PROYECTO_W.BonoConsulta SET bonocons_estado='U' WHERE bonocons_cod={0}", this.txtBono.Text);
                        this.conn.ejecutarQuery(query);

                        int selectedrowindex = grdProfesionales.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = grdProfesionales.Rows[selectedrowindex];
                        //string prof_cod = Convert.ToString(selectedRow.Cells["NroProfesional"].Value);
                        //string date = string.Format("{0:yyyy-M-d HH:mm:ss}", DateTime.Now);
                        //query = string.Format("SELECT T.turno_nro FROM PROYECTO_W.Turno AS T JOIN PROYECTO_W.Afiliado AS A ON A.afil_nro=T.turno_afil_nro WHERE T.turno_fecha<CONVERT(DATETIME, '{0}', 120) AND A.afil_nro={1} AND T.turno_estado = 'P' AND T.turno_prof_cod={2}", date, this.txtAfilNro.Text, prof_cod);

                        /*int selectedrowindex = grdProfesionales.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = grdProfesionales.Rows[selectedrowindex];
                        string turnoNro = Convert.ToString(selectedRow.Cells["NumeroTurno"].Value);
                        */
                        //string turnoNro = this.conn.ejecutarQuery(query).Rows[0][0].ToString();
                        string turnoNro = Convert.ToString(grdTurnos.SelectedCells[0].Value);

                        //query = string.Format("UPDATE PROYECTO_W.Turno SET turno_estado='A' WHERE turno_nro={0}", turnoNro);
                        //this.conn.ejecutarQuery(query);

                        query = string.Format("SELECT afil_nro_consultas FROM PROYECTO_W.Afiliado WHERE afil_nro={0}", this.txtAfilNro.Text);
                        int nroConsultas = int.Parse(this.conn.ejecutarQuery(query).Rows[0][0].ToString());

                        query = string.Format("DECLARE @FECHA DATETIME SET @FECHA = PROYECTO_W.F_FECHA_CONFIG() INSERT INTO PROYECTO_W.TurnoLlegada VALUES ({0}, {1}, {2}, @FECHA)", turnoNro, nroConsultas + 1, this.txtBono.Text);
                        this.conn.ejecutarQuery(query);

                        query = string.Format("UPDATE PROYECTO_W.Afiliado SET afil_nro_consultas={0} WHERE afil_nro={1}", nroConsultas + 1, this.txtAfilNro.Text);
                        this.conn.ejecutarQuery(query);

                        MessageBox.Show("Consulta Registrada");
                        this.txtBono.Enabled = false;
                        this.txtAfilNro.Text = "";
                        this.grdTurnos.DataSource = null;
                    }
                    else
                        MessageBox.Show("El Bono Consulta ya fue utilizado");
                }
                else
                    MessageBox.Show("Ocurrio un problema, pudo haber sido:\n-No se encontro el Bono Consulta\n-No se encontro el numero de afiliado\n-El bono no pertenece al afiliado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            validar_nro_afil();
        }
        private bool validar_campos()
        {
            if (txtBono.Text == "")
            {
                MessageBox.Show("Ingrese el numero de bono consulta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else return true;
        }
        private bool validar_nro_afil()
        {
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            ConexionSQL conn = new ConexionSQL();
            string query = string.Format("SELECT * FROM PROYECTO_W.Afiliado WHERE afil_nro={0} AND afil_estado = 'H'", txtAfilNro.Text);
            if (txtAfilNro.Text == "")
            {
                MessageBox.Show("Ingrese Numero de Afiliado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag2 = true;
            }

            if (conn.ejecutarQuery(query).Rows.Count == 0)
            {
                MessageBox.Show("El usuario esta deshabilitado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag3 = true;
            }
            foreach (DataGridViewRow fila in grdTurnos.Rows)
            {
                if (Convert.ToString(fila.Cells[1].Value) == txtAfilNro.Text)
                {
                    MessageBox.Show("El afiliado posee un turno con el profesional el dia de hoy", "Validado", MessageBoxButtons.OK);
                    flag = true;
                    break;
                }
            }
            if (!flag2 && !flag && !flag3)
            {
                MessageBox.Show("El afiliado no posee ningun turno el dia de hoy con el profesional", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return flag;
        }

        private void seleccion_fila(object sender, EventArgs e)
        {
        }

        private void click_fila(object sender, MouseEventArgs e)
        {
            if (grdTurnos.Rows.Count > 0)
            {
                txtAfilNro.Text = Convert.ToString(grdTurnos.SelectedCells[1].Value);
            }
        }
    }
}
