using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;

namespace proyecto_w.Pedido_Turno
{
    public partial class PedidoTurnoForm : Form
    {
        private string prof_cod = "";
        private string fecha = "";
        private System.Collections.Generic.List<string> col_horarios_turnos = new System.Collections.Generic.List<string>();
        public PedidoTurnoForm()
        {
            InitializeComponent();

            ConexionSQL conn = new ConexionSQL();
            string query = string.Format("SELECT prof_cod, prof_nombre, prof_apellido FROM PROYECTO_W.Profesional WHERE prof_estado = 'H'");
            grdProfesionales.DataSource = conn.ejecutarQuery(query);
            query = string.Format("SELECT esp_descripcion FROM PROYECTO_W.Especialidad");
            DataRowCollection especialidades = conn.ejecutarQuery(query).Rows;

            cbxEspecialidadFilter.Items.Add("Vacio");
            cbxEspecialidadFilter.SelectedIndex = 0;
            foreach (DataRow especialidad in especialidades)
            {
                cbxEspecialidadFilter.Items.Add(especialidad["esp_descripcion"].ToString());
            }
            cbTurnos.Items.Add("Hora del Turno a Registrar");
            cbTurnos.SelectedIndex = 0;
            cbxEspecialidad.Items.Add("Especialidad del Profesional");
            cbxEspecialidad.SelectedIndex = 0;
            if (frmLogin.user.Contains("afil"))
            {
                string query2 = string.Format("SELECT afil_nro FROM PROYECTO_W.Afiliado WHERE afil_username = '{0}'", frmLogin.user);
                ConexionSQL conn2 = new ConexionSQL();
                txtNro_Afil.Text = conn2.ejecutarQuery(query2).Rows[0][0].ToString();
                txtNro_Afil.Enabled = false;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            ConexionSQL conn = new ConexionSQL();
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
                    query = string.Format("SELECT P.prof_cod, P.prof_nombre, P.prof_apellido FROM PROYECTO_W.Profesional AS P JOIN PROYECTO_W.EspecialidadPorProfesional AS EP ON EP.espxprof_prof_cod=P.prof_cod JOIN PROYECTO_W.Especialidad AS E ON E.esp_cod=EP.espxprof_esp_cod WHERE E.esp_descripcion='{0}' AND prof_estado = 'H'", especialidad);

                if (conditions.Count > 0)
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


                this.grdProfesionales.DataSource = conn.ejecutarQuery(query);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ConexionSQL conn = new ConexionSQL();
            string query = string.Format("SELECT prof_cod, prof_nombre, prof_apellido FROM PROYECTO_W.Profesional");
            this.grdProfesionales.DataSource = conn.ejecutarQuery(query);
            this.txtNameFilter.Text = "";
            this.txtLastnameFilter.Text = "";
            this.cbxEspecialidadFilter.SelectedIndex = 0;
            this.grdDias.DataSource = null;
            this.grdTurnos.DataSource = null;
            this.cbTurnos.Items.Clear();
            this.cbTurnos.Items.Add("Hora del Turno a Registrar");
            this.cbTurnos.SelectedIndex = 0;
            this.cbxEspecialidad.Items.Clear();
            this.cbxEspecialidad.Items.Add("Especialidad del Profesional");
            this.cbxEspecialidad.SelectedIndex = 0;
            this.txtNro_Afil.Text = "";
        }

        private void btnselec_profesional_Click(object sender, EventArgs e)
        {
            if (validar_seleccion() == true)
            {
                cbxEspecialidad.Items.Clear();
                cbxEspecialidad.Items.Add("Especialidad del Profesional");
                cbxEspecialidad.SelectedIndex = 0;
                ConexionSQL conn = new ConexionSQL();
                prof_cod = grdProfesionales.SelectedCells[0].Value.ToString();
                string query;
                query = string.Format("DECLARE @FECHA DATETIME SET @FECHA = PROYECTO_W.F_FECHA_CONFIG()");
                query += string.Format(" SELECT fecha_fecha AS Fecha, (CASE DATEPART(DW, fecha_fecha) WHEN 1 THEN 'Lunes' WHEN 2 THEN 'Martes' WHEN 3 THEN 'Miercoles' WHEN 4 THEN 'Jueves' WHEN 5 THEN 'Viernes' WHEN 6 THEN 'Sabado' WHEN 7 THEN 'Domingo' END) AS Dia");
                query += string.Format(" FROM PROYECTO_W.Profesional JOIN PROYECTO_W.AgendaProfesional ON prof_cod = agen_prof_cod JOIN PROYECTO_W.Fecha ON agen_cod = fecha_agen_cod");
                query += string.Format(" WHERE prof_cod = {0} AND fecha_fecha >= CAST(@FECHA AS DATE)", prof_cod);
                query += string.Format(" ORDER BY fecha_fecha");
                grdDias.DataSource = conn.ejecutarQuery(query);
                query = string.Format("SELECT esp_descripcion, esp_cod");
                query += string.Format(" FROM PROYECTO_W.Profesional JOIN PROYECTO_W.EspecialidadPorProfesional ON prof_cod = espxprof_prof_cod JOIN PROYECTO_W.Especialidad ON espxprof_esp_cod = esp_cod");
                query += string.Format(" WHERE prof_cod = {0}", prof_cod);
                DataRowCollection filas_esp_espcod = conn.ejecutarQuery(query).Rows;
                foreach (DataRow fila in filas_esp_espcod)
                {
                    cbxEspecialidad.Items.Add(fila[0].ToString());
                }
            }
        }

        private bool validar_seleccion()
        {
            if (grdProfesionales.SelectedCells.Count == 0)
            {
                MessageBox.Show("No selecciono ningun profesional", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                ConexionSQL conn = new ConexionSQL();
                string prof_cod_seleccionado = grdProfesionales.SelectedCells[0].Value.ToString();
                string query = string.Format("SELECT agen_estado FROM PROYECTO_W.Profesional JOIN PROYECTO_W.AgendaProfesional");
                query += string.Format(" ON prof_cod = agen_prof_cod WHERE prof_cod = {0}", prof_cod_seleccionado);
                if ( conn.ejecutarQuery(query).Rows[0][0].ToString()[0] == 'D')
                {
                    MessageBox.Show("El profesional seleccionado cancelo su agenda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                } else return true;
            }
        }

        private void btnselec_dia_Click(object sender, EventArgs e)
        {
            if (validar_seleccion_dia() == true)
            {
                col_horarios_turnos.Clear();
                cbTurnos.Items.Clear();
                cbTurnos.Items.Add("Hora del Turno a Registrar");
                this.cbTurnos.SelectedIndex = 0;
                ConexionSQL conn = new ConexionSQL();
                string query;
                //Value.ToString("dd/MM/yyyy HH:mm")
                //fecha = grdDias.SelectedCells[0].Value.ToString().Substring(0,10);
                fecha = Convert.ToDateTime(grdDias.SelectedCells[0].Value.ToString().Substring(0, 10)).ToString("dd/MM/yyyy HH:mm");
                query = string.Format("SELECT turno_nro as Turno, CAST(turno_fecha AS TIME(0)) AS Hora, turno_afil_nro as Afiliado");
                query += string.Format(" FROM PROYECTO_W.Turno");
                query += string.Format(" WHERE CAST(turno_fecha AS DATE) = '{0}' AND turno_prof_cod = {1} AND turno_estado = 'P'", fecha, prof_cod);
                query += string.Format(" ORDER BY turno_fecha");
                DataTable tabla_turnos = conn.ejecutarQuery(query);
                DataRowCollection filas = tabla_turnos.Rows;
                grdTurnos.DataSource = tabla_turnos;
                // Carga la coleccion horarios_turnos para luego comparar y cargar el combobox.
                foreach(DataRow fila in filas)
                {
                    col_horarios_turnos.Add(fila[1].ToString());
                }

                cargar_combobox_horarios();
            }
        }

        private bool validar_seleccion_dia()
        {
            if (grdDias.SelectedCells.Count == 0)
            {
                MessageBox.Show("No selecciono ningun dia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else return true;
        }

        private void cargar_combobox_horarios()
        {
            ConexionSQL conn = new ConexionSQL();
            string query = string.Format("SELECT CAST(hora_inicio AS TIME(0)), CAST(hora_fin AS TIME(0))");
            query += string.Format(" FROM PROYECTO_W.RangoHorario JOIN PROYECTO_W.AgendaProfesional ON hora_agen_cod = agen_cod");
            query += string.Format(" WHERE CAST(hora_fecha AS DATE) = '{0}' AND agen_prof_cod = {1}", fecha, prof_cod);
            query += string.Format(" ORDER BY hora_inicio");
            DataRowCollection filas_rango_horario = conn.ejecutarQuery(query).Rows;            
            foreach (DataRow fila in filas_rango_horario)
            {
                string time_ini = fila[0].ToString();
                string time_fin = fila[1].ToString();
                string min_ini_string = Convert.ToString(time_ini[3]);
                min_ini_string += Convert.ToString(time_ini[4]);
                int minutos = Convert.ToInt32(min_ini_string);
                string hora_ini_string = Convert.ToString(time_ini[0]);
                hora_ini_string += Convert.ToString(time_ini[1]);
                int hora = Convert.ToInt32(hora_ini_string);
                
                TimeSpan count_time = new TimeSpan(hora, minutos, 00);
                while(CompareStringAscii(count_time.ToString(), time_fin))
                {
                    if (!col_horarios_turnos.Contains(count_time.ToString()))
                    {
                        cbTurnos.Items.Add(count_time.ToString());
                    }
                    minutos += 30;
                    count_time = new TimeSpan(hora, minutos, 00);
                }
            }
        }

        private bool CompareStringAscii(String str1, String str2)
        {
            byte[] a1 = Encoding.ASCII.GetBytes(str1);
            byte[] a2 = Encoding.ASCII.GetBytes(str2);
            uint st1 = 0, st2 = 0;
            uint uni = (uint) str1.Length;
            uni = (uint)Math.Pow((double)10, (double)uni);
            foreach (byte b in a1)
            {
                st1 += b * uni;
                uni = uni / 10;
            }
            uni = (uint)str2.Length;
            uni = (uint)Math.Pow((double)10, (double)uni);
            foreach (byte b in a2)
            {
                st2 += b * uni;
                uni = uni / 10;
            }
            if (st2 > st1)
                return true;
            else return false;
        }

        private void txtNro_Afil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {

                e.Handled = true;

            }
        }

        private void btnregis_turno_Click(object sender, EventArgs e)
        {
            if (validar_registrar() == true)
            {
                ConexionSQL conn = new ConexionSQL();
                string query = string.Format("SELECT esp_cod FROM PROYECTO_W.Especialidad WHERE esp_descripcion = '{0}'", cbxEspecialidad.SelectedItem.ToString());
                string esp_cod = conn.ejecutarQuery(query).Rows[0][0].ToString();
                query = string.Format("SELECT agen_cod FROM PROYECTO_W.AgendaProfesional WHERE agen_prof_cod = {0}", prof_cod);
                string agen_cod = conn.ejecutarQuery(query).Rows[0][0].ToString(); 
                query = string.Format("INSERT INTO PROYECTO_W.Turno");
                query += string.Format(" VALUES ({0},", txtNro_Afil.Text);
                query += string.Format(" 'P',");
                query += string.Format(" '{0}", fecha.Substring(0, 10)); 
                query += string.Format(" {0}", cbTurnos.SelectedItem.ToString());
                query += string.Format(".000',");
                query += string.Format(" {0}, {1}, {2})", prof_cod, esp_cod, agen_cod);
                conn.ejecutarQuery(query);
                MessageBox.Show("Se reservo exitosamente el turno", "Turno Registado", MessageBoxButtons.OK);
                btnLimpiar.PerformClick();
            }
        }

        private bool validar_registrar()
        {
            if (cbTurnos.SelectedIndex == 0 || cbTurnos.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un horario para el turno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtNro_Afil.Text == "")
            {
                MessageBox.Show("Debe ingresar el Nro de Afiliado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cbxEspecialidad.SelectedIndex == 0 || cbxEspecialidad.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar la especialidad del Profesional", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            string query = string.Format("SELECT afil_nro FROM PROYECTO_W.Afiliado WHERE afil_nro = {0} AND afil_estado = 'H'", txtNro_Afil.Text);
            ConexionSQL conn = new ConexionSQL();
            DataRowCollection filas = conn.ejecutarQuery(query).Rows;
            if (filas.Count == 0)
            {
                MessageBox.Show("No se encontro el Nro de Afiliado o el usuario esta Deshabilitado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else return true;
        }
    }
}