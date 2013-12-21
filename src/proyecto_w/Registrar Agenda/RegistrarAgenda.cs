using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace proyecto_w.Registrar_Agenda
{
    public partial class frmRegistrarAgenda : Form
    {
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
            if (st1 < st2)
                return true;
            else return false;
        }
        public frmRegistrarAgenda()
        {
            InitializeComponent();
            txtProfCod.Enabled = false;
            ConexionSQL conn2 = new ConexionSQL();
            string query2 = string.Format("SELECT prof_cod, prof_nombre, prof_apellido FROM PROYECTO_W.Profesional WHERE prof_estado = 'H'");
            this.grdProfesionales.DataSource = conn2.ejecutarQuery(query2);
            query2 = string.Format("SELECT esp_descripcion FROM PROYECTO_W.Especialidad");
            DataRowCollection especialidades = conn2.ejecutarQuery(query2).Rows;

            cbxEspecialidadFilter.Items.Add("Vacio");
            cbxEspecialidadFilter.SelectedIndex = 0;
            foreach (DataRow especialidad in especialidades)
            {
                cbxEspecialidadFilter.Items.Add(especialidad["esp_descripcion"].ToString());
            }

            int minutos = 00;
            
            
            TimeSpan timeAux = new TimeSpan(07, minutos, 00);
                       
            while(CompareStringAscii(timeAux.ToString(),"20:00:00"))
            {
                timeAux = new TimeSpan(07, minutos, 00);
                cbxLun_ini.Items.Add(timeAux.ToString());
                cbxLun_fin.Items.Add(timeAux.ToString());
                cbxMa_ini.Items.Add(timeAux.ToString());
                cbxMa_fin.Items.Add(timeAux.ToString());
                cbxMi_ini.Items.Add(timeAux.ToString());
                cbxMi_fin.Items.Add(timeAux.ToString());
                cbxJu_ini.Items.Add(timeAux.ToString());
                cbxJu_fin.Items.Add(timeAux.ToString());
                cbxVi_ini.Items.Add(timeAux.ToString());
                cbxVi_fin.Items.Add(timeAux.ToString());

                if ((!CompareStringAscii(timeAux.ToString(), "10:00:00")) &
                    CompareStringAscii(timeAux.ToString(), "15:00:01"))
                {
                    cbxSa_ini.Items.Add(timeAux.ToString());
                    cbxSa_fin.Items.Add(timeAux.ToString());
                }

                minutos += 30;

            }
            if(frmLogin.user.Contains("prof"))
            {
                string query = string.Format("SELECT prof_doc_nro, prof_cod FROM PROYECTO_W.Profesional WHERE prof_username = '{0}'", frmLogin.user);
                ConexionSQL conn = new ConexionSQL();
                txtProfCod.Text = conn.ejecutarQuery(query).Rows[0][0].ToString();
                string prof_cod = conn.ejecutarQuery(query).Rows[0][1].ToString();
                txtProfCod.Enabled = false;
                btnselec_profesional.Enabled = false;
                string consulta = string.Format("SELECT agen_estado FROM PROYECTO_W.AgendaProfesional WHERE agen_prof_cod = {0}", prof_cod);
                if (string.Equals(conn.ejecutarQuery(consulta).Rows[0][0].ToString(), "D"))
                {
                    this.btnRegistrar.Enabled = false;
                    lblAgendaState.Text = "Agenda Deshabilitada";
                }
                else
                {
                    this.btnRegistrar.Enabled = true;
                    lblAgendaState.Text = "Agenda habilitada";
                }
            }
        }
/* CREATE PROCEDURE PROYECTO_W.SP_REGISTRAR_AGENDA
@PROF_DNI NUMERIC(18,0), @DIA_CHECK VARCHAR(255), @DESDE DATE, @HASTA DATE,
	@HORA_INI TIME, @HORA_FIN TIME */

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // obtengo el primer dia a partir del dia actual del sistema
            // si la fecha hasta se pasa de 120 dias,, sale mensajito y no hace nada
            // 2 , si la fecha desde es antes de la actual, no hace nada

           //DateTime fechaCheck;// = (Convert.ToDateTime(dtp_ini.Text).Date + TimeSpan.Parse(cbxLun_ini.Text));
            if (((cbxLun_ini.Text == "" | cbxLun_fin.Text == "") & checkLunes.Checked)
                | ((cbxMa_ini.Text == "" | cbxMa_fin.Text == "") & checkMartes.Checked)
                | ((cbxMi_ini.Text == "" | cbxMi_fin.Text == "") & checkMie.Checked)
                | ((cbxJu_ini.Text == "" | cbxJu_fin.Text == "") & checkJue.Checked)
                | ((cbxVi_ini.Text == "" | cbxVi_fin.Text == "") & checkVie.Checked)
                | ((cbxSa_ini.Text == "" | cbxSa_fin.Text == "") & checkSa.Checked)
                )
            {
                //lblStatus.Text = "Debe seleccionar horarios para los días chequeados";
                MessageBox.Show("Debe seleccionar horarios para los días chequeados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!(checkLunes.Checked | checkMartes.Checked | checkMie.Checked | checkJue.Checked | checkVie.Checked | checkSa.Checked))
            {
                //lblStatus.Text = "No ha seleccionado ningún día";
                MessageBox.Show("No ha seleccionado ningún día", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // MARCA
            if (dtp_ini.Value.Date < Convert.ToDateTime(arch_config.Default.fecha).Date)
            {
                MessageBox.Show(String.Format("Debe elegir una fecha y hora no menor a: {0}", Convert.ToDateTime(arch_config.Default.fecha).ToString("dd/MM/yyyy HH:mm")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (dtp_ini.Value.Date == Convert.ToDateTime(arch_config.Default.fecha).Date)
                {// lunes es 1
                    ConexionSQL CONN = ConexionSQL.Instance;
                    SqlCommand COMM = new SqlCommand();
                    COMM.CommandText = "SELECT DATEPART(DW,@FECHITA)";
                    COMM.Parameters.Add("@FECHITA",SqlDbType.Date).Value = dtp_ini.Value.Date;
                    int dayweek = CONN.ejecutarEscalarInt(COMM);

                    if(checkLunes.Checked && dayweek == 1)
                    {
                        if((Convert.ToDateTime(dtp_ini.Text).Date + TimeSpan.Parse(cbxLun_ini.Text)) < Convert.ToDateTime(arch_config.Default.fecha)) 
                        {
                            MessageBox.Show(String.Format("Debe elegir una fecha y hora no menor a: {0}",
                                Convert.ToDateTime(arch_config.Default.fecha).ToString("dd/MM/yyyy HH:mm")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    if(checkMartes.Checked && dayweek == 2)
                    {
                        if((Convert.ToDateTime(dtp_ini.Text).Date + TimeSpan.Parse(cbxMa_ini.Text)) < Convert.ToDateTime(arch_config.Default.fecha)) 
                        {
                            MessageBox.Show(String.Format("Debe elegir una fecha y hora no menor a: {0}",
                                Convert.ToDateTime(arch_config.Default.fecha).ToString("dd/MM/yyyy HH:mm")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    if(checkMie.Checked && dayweek == 3)
                    {
                        if((Convert.ToDateTime(dtp_ini.Text).Date + TimeSpan.Parse(cbxMi_ini.Text)) < Convert.ToDateTime(arch_config.Default.fecha)) 
                        {
                            MessageBox.Show(String.Format("Debe elegir una fecha y hora no menor a: {0}",
                                Convert.ToDateTime(arch_config.Default.fecha).ToString("dd/MM/yyyy HH:mm")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    if(checkJue.Checked && dayweek == 4)
                    {
                        if((Convert.ToDateTime(dtp_ini.Text).Date + TimeSpan.Parse(cbxJu_ini.Text)) < Convert.ToDateTime(arch_config.Default.fecha)) 
                        {
                            MessageBox.Show(String.Format("Debe elegir una fecha y hora no menor a: {0}",
                                Convert.ToDateTime(arch_config.Default.fecha).ToString("dd/MM/yyyy HH:mm")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    if(checkVie.Checked && dayweek == 5)
                    {
                        if((Convert.ToDateTime(dtp_ini.Text).Date + TimeSpan.Parse(cbxVi_ini.Text)) < Convert.ToDateTime(arch_config.Default.fecha)) 
                        {
                            MessageBox.Show(String.Format("Debe elegir una fecha y hora no menor a: {0}",
                                Convert.ToDateTime(arch_config.Default.fecha).ToString("dd/MM/yyyy HH:mm")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    if(checkSa.Checked && dayweek == 6)
                    {
                        if((Convert.ToDateTime(dtp_ini.Text).Date + TimeSpan.Parse(cbxSa_ini.Text)) < Convert.ToDateTime(arch_config.Default.fecha)) 
                        {
                            MessageBox.Show(String.Format("Debe elegir una fecha y hora no menor a: {0}",
                                Convert.ToDateTime(arch_config.Default.fecha).ToString("dd/MM/yyyy HH:mm")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
            }

            
            Boolean noErrorFlag = true;
            if (txtProfCod.Text == "")
            {
                //lblStatus.Text = "Debe ingresar número de documento del profesional";
                MessageBox.Show("Debe ingresar número de documento del profesional", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dtp_ini.Value > dtp_fin.Value)
            {
                //lblStatus.Text = "Fecha de comienzo debe ser \n menor o igual que fecha final";
                MessageBox.Show("Fecha de comienzo debe ser \n menor o igual que fecha final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (checkLunes.Checked & !CompareStringAscii(cbxLun_ini.Text, cbxLun_fin.Text))
            {
                //lblStatus.Text = "Horario de inicio debe ser \n menor que horario final";
                MessageBox.Show("Horario de inicio debe ser \n menor que horario final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (checkMartes.Checked & !CompareStringAscii(cbxMa_ini.Text, cbxMa_fin.Text))
            {
//                lblStatus.Text = "Horario de inicio debe ser \n menor que horario final";
                MessageBox.Show("Horario de inicio debe ser \n menor que horario final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (checkMie.Checked & !CompareStringAscii(cbxMi_ini.Text, cbxMi_fin.Text))
            {
                //lblStatus.Text = "Horario de inicio debe ser \n menor que horario final";
                MessageBox.Show("Horario de inicio debe ser \n menor que horario final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (checkJue.Checked & !CompareStringAscii(cbxJu_ini.Text, cbxJu_fin.Text))
            {
               // lblStatus.Text = "Horario de inicio debe ser \n menor que horario final";
                MessageBox.Show("Horario de inicio debe ser \n menor que horario final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (checkVie.Checked & !CompareStringAscii(cbxVi_ini.Text, cbxVi_fin.Text))
            {
               // lblStatus.Text = "Horario de inicio debe ser \n menor que horario final";
                MessageBox.Show("Horario de inicio debe ser \n menor que horario final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (checkSa.Checked & !CompareStringAscii(cbxSa_ini.Text, cbxSa_fin.Text))
            {
                //lblStatus.Text = "Horario de inicio debe ser \n menor que horario final";
                MessageBox.Show("Horario de inicio debe ser \n menor que horario final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ConexionSQL sqlConexion = ConexionSQL.Instance;
            String query120 =
                string.Format("SELECT TOP 1 dateadd(day,120,fecha_fecha) FROM PROYECTO_W.Fecha JOIN PROYECTO_W.AgendaProfesional ON agen_cod = fecha_agen_cod JOIN PROYECTO_W.Profesional ON prof_cod = agen_prof_cod WHERE prof_doc_nro = {0} AND fecha_fecha >= CAST((SELECT TOP 1 * FROM PROYECTO_W.FechaConfig) AS DATE) ORDER BY fecha_fecha ASC",
                txtProfCod.Text);
            DataTable diasIni120 = sqlConexion.ejecutarQuery(query120);
            if (diasIni120.Rows.Count != 0) // es porque habia dias ahi
            {
                if (Convert.ToDateTime(dtp_fin.Text).Date > Convert.ToDateTime(diasIni120.Rows[0][0]).Date)
                {
                    //lblStatus.Text = "La fecha hasta la cual se desea programar supera el rango de 120 días";
                    MessageBox.Show("La fecha hasta la cual se desea programar supera el rango de 120 días", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            
            
            //lblStatus.Text = "EJECUTANDO";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = 
                "EXEC PROYECTO_W.SP_REGISTRAR_AGENDA @PROF_DNI,@DIA_CHECK,@DESDE,@HASTA,@HORA_INI,@HORA_FIN";
            cmd.Parameters.Add("@PROF_DNI", SqlDbType.Int).Value = txtProfCod.Text;
            cmd.Parameters.Add("@DESDE", SqlDbType.Date).Value = dtp_ini.Value;
            cmd.Parameters.Add("@HASTA", SqlDbType.Date).Value = dtp_fin.Value;

            // agrego basura
            cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxLun_ini.Text;
            cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxLun_fin.Text;
            // para poder limpiar igual en cada check

            // LUNES
            if (checkLunes.Checked)
            {
                cmd.Parameters.RemoveAt("@DIA_CHECK");
                cmd.Parameters.RemoveAt("@HORA_INI");
                cmd.Parameters.RemoveAt("@HORA_FIN");
                cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxLun_ini.Text;
                cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxLun_fin.Text;

                try
                {
                    sqlConexion.ejecutarQueryConSP(cmd);
                }
                catch (SqlException EXC)
                {
                    //lblStatus.Text = EXC.Message.ToString();
                    MessageBox.Show(EXC.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    noErrorFlag = false;
                }
            }
          

            //MARTES
            if (checkMartes.Checked)
            {
                cmd.Parameters.RemoveAt("@DIA_CHECK");
                cmd.Parameters.RemoveAt("@HORA_INI");
                cmd.Parameters.RemoveAt("@HORA_FIN");
                cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 2;
                cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxMa_ini.Text;
                cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxMa_fin.Text;

                try
                {
                    sqlConexion.ejecutarQueryConSP(cmd);
                }
                catch (SqlException EXC)
                {
                    //lblStatus.Text = EXC.Message.ToString();
                    MessageBox.Show(EXC.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    noErrorFlag = false;
                }
            }

            //MIERCOLES
            if (checkMie.Checked)
            {
                cmd.Parameters.RemoveAt("@DIA_CHECK");
                cmd.Parameters.RemoveAt("@HORA_INI");
                cmd.Parameters.RemoveAt("@HORA_FIN");
                cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxMi_ini.Text;
                cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxMi_fin.Text;

                try
                {
                    sqlConexion.ejecutarQueryConSP(cmd);
                }
                catch (SqlException EXC)
                {
                 //   lblStatus.Text = EXC.Message.ToString();
                    MessageBox.Show(EXC.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    noErrorFlag = false;
                }
            }

            //JUEVES
            if (checkJue.Checked)
            {
                cmd.Parameters.RemoveAt("@DIA_CHECK");
                cmd.Parameters.RemoveAt("@HORA_INI");
                cmd.Parameters.RemoveAt("@HORA_FIN");
                cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 4;
                cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxJu_ini.Text;
                cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxJu_fin.Text;

                try
                {
                    sqlConexion.ejecutarQueryConSP(cmd);
                }
                catch (SqlException EXC)
                {
                    //lblStatus.Text = EXC.Message.ToString();
                    MessageBox.Show(EXC.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    noErrorFlag = false;
                }
            }

            //VIERNES
            if (checkVie.Checked)
            {
                cmd.Parameters.RemoveAt("@DIA_CHECK");
                cmd.Parameters.RemoveAt("@HORA_INI");
                cmd.Parameters.RemoveAt("@HORA_FIN");
                cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 5;
                cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxVi_ini.Text;
                cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxVi_fin.Text;

                try
                {
                    sqlConexion.ejecutarQueryConSP(cmd);
                }
                catch (SqlException EXC)
                {
                    //lblStatus.Text = EXC.Message.ToString();
                    MessageBox.Show(EXC.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    noErrorFlag = false;
                }
            }

            //SABADO
            if (checkSa.Checked)
            {
                cmd.Parameters.RemoveAt("@DIA_CHECK");
                cmd.Parameters.RemoveAt("@HORA_INI");
                cmd.Parameters.RemoveAt("@HORA_FIN");
                cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 6;
                cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxSa_ini.Text;
                cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxSa_fin.Text;

                try
                {
                    sqlConexion.ejecutarQueryConSP(cmd);
                }
                catch (SqlException EXC)
                {
                    //lblStatus.Text = EXC.Message.ToString();
                    MessageBox.Show(EXC.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    noErrorFlag = false;
                }
            }

            // quitar las fechas que se encuentran en excepciones
            String queryExceps;
            try
            {
                foreach (var item in checkedListEx.Items.OfType<DateTime>().ToList())
                {
                    queryExceps =
                        string.Format("DELETE RH FROM PROYECTO_W.RangoHorario AS RH JOIN PROYECTO_W.AgendaProfesional ON agen_cod = RH.hora_agen_cod JOIN PROYECTO_W.Profesional ON prof_cod = agen_prof_cod WHERE prof_doc_nro = {0} AND RH.hora_fecha = '{1}'", txtProfCod.Text, item.Date.ToString("dd/MM/yyyy"));
                    sqlConexion.ejecutarQuery(queryExceps);
                    queryExceps =
                        string.Format("DELETE FE FROM PROYECTO_W.Fecha AS FE JOIN PROYECTO_W.AgendaProfesional ON agen_cod = FE.fecha_agen_cod JOIN PROYECTO_W.Profesional ON agen_prof_cod = prof_cod WHERE prof_doc_nro = {0} AND FE.fecha_fecha = '{1}'", txtProfCod.Text, item.Date.ToString("dd/MM/yyyy"));
                    sqlConexion.ejecutarQuery(queryExceps);
                }
            }
            catch (SqlException ex)
            {
                //lblStatus.Text = ex.Message;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            //48 HORAS CHECK
            if (noErrorFlag)
            {
                /*PROYECTO_W.F_48HORAS_CHECK
(@PROF_DNI NUMERIC(18,0), @DESDE DATE, @HASTA DATE)*/
                
               /* String query48 =
                    string.Format("SELECT * FROM PROYECTO_W.F_48HORAS_CHECK({0},'{1}','{2}')",
                    txtProfCod.Text,dtp_ini.Value.ToShortDateString(),dtp_fin.Value.ToShortDateString());*/
                SqlCommand query48 = new SqlCommand();
                query48.CommandText = 
                    "SELECT * FROM PROYECTO_W.F_48HORAS_CHECK(@PROF_DNI,CAST(@INICIO AS DATE),CAST(@FIN AS DATE))";
                query48.Parameters.Add("@PROF_DNI", SqlDbType.Int).Value = txtProfCod.Text;
                query48.Parameters.Add("@INICIO", SqlDbType.DateTime).Value = dtp_ini.Value;
                query48.Parameters.Add("@FIN", SqlDbType.DateTime).Value = dtp_fin.Value;
                DataTable tabla48 = sqlConexion.ejecutarQueryConSP(query48);
                if (tabla48.Rows.Count > 0)
                {
                    //lblStatus.Text = "Carga horaria del profesional no debe sobrepasar 48 horas semanales";
                    MessageBox.Show("Carga horaria del profesional no debe sobrepasar 48 horas semanales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    cmd = new SqlCommand();
                    cmd.CommandText =
                        "EXEC PROYECTO_W.SP_CANCELAR_AGENDA @PROF_DNI,@DIA_CHECK,@DESDE,@HASTA,@HORA_INI,@HORA_FIN";
                    cmd.Parameters.Add("@PROF_DNI", SqlDbType.Int).Value = txtProfCod.Text;
                    cmd.Parameters.Add("@DESDE", SqlDbType.Date).Value = dtp_ini.Value;
                    cmd.Parameters.Add("@HASTA", SqlDbType.Date).Value = dtp_fin.Value;

                    // agrego basura
                    cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 1;
                    cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxLun_ini.Text;
                    cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxLun_fin.Text;
                    // para poder limpiar igual en cada check
                    // LUNES
                    if (checkLunes.Checked)
                    {
                        cmd.Parameters.RemoveAt("@DIA_CHECK");
                        cmd.Parameters.RemoveAt("@HORA_INI");
                        cmd.Parameters.RemoveAt("@HORA_FIN");
                        cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxLun_ini.Text;
                        cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxLun_fin.Text;

                        try
                        {
                            sqlConexion.ejecutarQueryConSP(cmd);
                        }
                        catch (SqlException EXC)
                        {
                            //lblStatus.Text = EXC.Message.ToString();
                            MessageBox.Show(EXC.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            noErrorFlag = false;
                        }
                    }


                    //MARTES
                    if (checkMartes.Checked)
                    {
                        cmd.Parameters.RemoveAt("@DIA_CHECK");
                        cmd.Parameters.RemoveAt("@HORA_INI");
                        cmd.Parameters.RemoveAt("@HORA_FIN");
                        cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 2;
                        cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxMa_ini.Text;
                        cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxMa_fin.Text;

                        try
                        {
                            sqlConexion.ejecutarQueryConSP(cmd);
                        }
                        catch (SqlException EXC)
                        {
                            //lblStatus.Text = EXC.Message.ToString();
                            MessageBox.Show(EXC.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            noErrorFlag = false;
                        }
                    }

                    //MIERCOLES
                    if (checkMie.Checked)
                    {
                        cmd.Parameters.RemoveAt("@DIA_CHECK");
                        cmd.Parameters.RemoveAt("@HORA_INI");
                        cmd.Parameters.RemoveAt("@HORA_FIN");
                        cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxMi_ini.Text;
                        cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxMi_fin.Text;

                        try
                        {
                            sqlConexion.ejecutarQueryConSP(cmd);
                        }
                        catch (SqlException EXC)
                        {
                            //lblStatus.Text = EXC.Message.ToString();
                            MessageBox.Show(EXC.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            noErrorFlag = false;
                        }
                    }

                    //JUEVES
                    if (checkJue.Checked)
                    {
                        cmd.Parameters.RemoveAt("@DIA_CHECK");
                        cmd.Parameters.RemoveAt("@HORA_INI");
                        cmd.Parameters.RemoveAt("@HORA_FIN");
                        cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 4;
                        cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxJu_ini.Text;
                        cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxJu_fin.Text;

                        try
                        {
                            sqlConexion.ejecutarQueryConSP(cmd);
                        }
                        catch (SqlException EXC)
                        {
                         //   lblStatus.Text = EXC.Message.ToString();
                            MessageBox.Show(EXC.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            noErrorFlag = false;
                        }
                    }

                    //VIERNES
                    if (checkVie.Checked)
                    {
                        cmd.Parameters.RemoveAt("@DIA_CHECK");
                        cmd.Parameters.RemoveAt("@HORA_INI");
                        cmd.Parameters.RemoveAt("@HORA_FIN");
                        cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 5;
                        cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxVi_ini.Text;
                        cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxVi_fin.Text;

                        try
                        {
                            sqlConexion.ejecutarQueryConSP(cmd);
                        }
                        catch (SqlException EXC)
                        {
                            //lblStatus.Text = EXC.Message.ToString();
                            MessageBox.Show(EXC.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            noErrorFlag = false;
                        }
                    }

                    //SABADO
                    if (checkSa.Checked)
                    {
                        cmd.Parameters.RemoveAt("@DIA_CHECK");
                        cmd.Parameters.RemoveAt("@HORA_INI");
                        cmd.Parameters.RemoveAt("@HORA_FIN");
                        cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 6;
                        cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxSa_ini.Text;
                        cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxSa_fin.Text;

                        try
                        {
                            sqlConexion.ejecutarQueryConSP(cmd);
                        }
                        catch (SqlException EXC)
                        {
                            //lblStatus.Text = EXC.Message.ToString();
                            MessageBox.Show(EXC.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            noErrorFlag = false;
                        }
                    }
                    noErrorFlag = false;
                }
                if (noErrorFlag)
                {
                    //lblStatus.Text = "Ejecución correcta";
                    MessageBox.Show("Ejecución correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }

        }

        private void btnAddEx_Click(object sender, EventArgs e)
        {
            if(!checkedListEx.Items.Contains(dtpEx.Value.Date))
            checkedListEx.Items.Add(dtpEx.Value.Date);
        }

        private void btnRemoveEx_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListEx.CheckedItems.OfType<DateTime>().ToList())
            {
                checkedListEx.Items.Remove(item);
            }
        }

        private void txtProfCod_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtProfCod.Text, @"^\d+$")) { txtProfCod.Text = "0"; }
        }

        private void dtp_ini_ValueChanged(object sender, EventArgs e)
        {
            
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ConexionSQL connn = new ConexionSQL();
            string query = string.Format("SELECT prof_cod, prof_nombre, prof_apellido FROM PROYECTO_W.Profesional");
            this.grdProfesionales.DataSource = connn.ejecutarQuery(query);
            this.txtNameFilter.Text = "";
            this.txtLastnameFilter.Text = "";
            this.cbxEspecialidadFilter.SelectedIndex = 0;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            ConexionSQL conn3 = new ConexionSQL();
            string apellido = this.txtLastnameFilter.Text;
            string nombre = this.txtNameFilter.Text;
            string especialidad = this.cbxEspecialidadFilter.SelectedItem.ToString();

            if (apellido != "" || nombre != "" || especialidad != "Vacio")
            {
                string query3 = string.Format("SELECT prof_cod, prof_nombre, prof_apellido FROM PROYECTO_W.Profesional");

                List<String> conditions = new List<String>();

                if (apellido != "")
                    conditions.Add(string.Format("prof_apellido='{0}'", apellido));
                //conditions.Add();

                if (nombre != "")
                    conditions.Add(string.Format("prof_nombre='{0}'", nombre));
                //  conditions[conditions.Length] = string.Format("prof_nombre='{0}'", apellido);
                //conditions.Add();

                if (especialidad != "Vacio")
                    query3 = string.Format("SELECT P.prof_cod, P.prof_nombre, P.prof_apellido FROM PROYECTO_W.Profesional AS P JOIN PROYECTO_W.EspecialidadPorProfesional AS EP ON EP.espxprof_prof_cod=P.prof_cod JOIN PROYECTO_W.Especialidad AS E ON E.esp_cod=EP.espxprof_esp_cod WHERE E.esp_descripcion='{0}'", especialidad);

                if (conditions.Count > 0)
                {
                    if (query3.Contains("WHERE"))
                    {
                        query3 += string.Format(" AND {0}", string.Join(" AND ", conditions.ToArray()));
                    }
                    else
                    {
                        query3 += string.Format(" WHERE {0}", string.Join(" AND ", conditions.ToArray()));
                    }
                    query3 += string.Format(" AND prof_estado = 'H'");
                }


                this.grdProfesionales.DataSource = conn3.ejecutarQuery(query3);
            }
        }

        private void btnselec_profesional_Click(object sender, EventArgs e)
        {
            if (grdProfesionales.SelectedRows.Count == 0)
                MessageBox.Show("Debe Seleccionar un Profesional", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                ConexionSQL conn2 = new ConexionSQL();
                string prof_cod = Convert.ToString(grdProfesionales.SelectedCells[0].Value.ToString());
                string consulta = string.Format("SELECT prof_doc_nro FROM PROYECTO_W.Profesional WHERE prof_cod = {0}", prof_cod);
                txtProfCod.Text = conn2.ejecutarQuery(consulta).Rows[0][0].ToString();

                consulta = string.Format("SELECT agen_estado FROM PROYECTO_W.AgendaProfesional WHERE agen_prof_cod = {0}", prof_cod);
                if (string.Equals(conn2.ejecutarQuery(consulta).Rows[0][0].ToString(), "D"))
                {
                    this.btnRegistrar.Enabled = false;
                    lblAgendaState.Text = "Agenda Deshabilitada";
                }
                else
                {
                    this.btnRegistrar.Enabled = true;
                    lblAgendaState.Text = "Agenda habilitada";
                }
            }
        }

        private void btnAltaBaja_Click(object sender, EventArgs e)
        {
            if (grdProfesionales.SelectedRows.Count == 0)
                MessageBox.Show("Debe Seleccionar un Profesional", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                ConexionSQL conn2 = new ConexionSQL();
                string prof_cod = Convert.ToString(grdProfesionales.SelectedCells[0].Value.ToString());
                string consulta = string.Format("SELECT prof_doc_nro FROM PROYECTO_W.Profesional WHERE prof_cod = {0}", prof_cod);
                txtProfCod.Text = conn2.ejecutarQuery(consulta).Rows[0][0].ToString();

                consulta = string.Format("SELECT agen_estado FROM PROYECTO_W.AgendaProfesional WHERE agen_prof_cod = {0}", prof_cod);
                if (string.Equals(conn2.ejecutarQuery(consulta).Rows[0][0].ToString(), "D"))
                {
                    consulta = string.Format("UPDATE PROYECTO_W.AgendaProfesional SET agen_estado = 'H' WHERE agen_prof_cod = {0}", prof_cod);
                    conn2.ejecutarQuery(consulta);
                    this.btnRegistrar.Enabled = true;
                    lblAgendaState.Text = "Agenda habilitada";
                }
                else
                {
                    consulta = string.Format("UPDATE PROYECTO_W.AgendaProfesional SET agen_estado = 'D' WHERE agen_prof_cod = {0}", prof_cod);
                    conn2.ejecutarQuery(consulta);
                    this.btnRegistrar.Enabled = false;
                    lblAgendaState.Text = "Agenda Deshabilitada";

                    consulta = string.Format("SELECT agen_cod FROM PROYECTO_W.AgendaProfesional WHERE agen_prof_cod = {0}",prof_cod);
                    DataTable agenCodTable = conn2.ejecutarQuery(consulta);
                    if (agenCodTable.Rows.Count > 0)
                    {
                        uint agen_cod = Convert.ToUInt32(agenCodTable.Rows[0][0]);
                        consulta =
                            string.Format("EXEC PROYECTO_W.SP_CANCELAR_TURNOS_POR_AGENDA_DESHABILITADA {0}",
                                agen_cod);
                        conn2.ejecutarQuery(consulta);
                    }
                }
            }
        }

        private void frmRegistrarAgenda_Load(object sender, EventArgs e)
        {

        }

     
    }
}
