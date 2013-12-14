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
                string query = string.Format("SELECT prof_doc_nro FROM PROYECTO_W.Profesional WHERE prof_username = '{0}'", frmLogin.user);
                ConexionSQL conn = new ConexionSQL();
                txtProfCod.Text = conn.ejecutarQuery(query).Rows[0][0].ToString();
                txtProfCod.Enabled = false;
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
                lblStatus.Text = "Debe seleccionar horarios para los días chequeados";
                return;
            }
            if (!(checkLunes.Checked | checkMartes.Checked | checkMie.Checked | checkJue.Checked | checkVie.Checked | checkSa.Checked))
            {
                lblStatus.Text = "No ha seleccionado ningún día";
                return;
            }

            if (checkLunes.Checked)
            {
                if((Convert.ToDateTime(dtp_ini.Text).Date + TimeSpan.Parse(cbxLun_ini.Text)) < Convert.ToDateTime(arch_config.Default.fecha)) 
                {
                    lblStatus.Text =
                    String.Format("Debe elegir una fecha y hora no menor a: {0}", arch_config.Default.fecha);
                    return;
                }

            }
            if (checkMartes.Checked)
            {
                if ((Convert.ToDateTime(dtp_ini.Text).Date + TimeSpan.Parse(cbxMa_ini.Text)) < Convert.ToDateTime(arch_config.Default.fecha))
                {
                    lblStatus.Text =
                    String.Format("Debe elegir una fecha y hora no menor a: {0}", arch_config.Default.fecha);
                    return;
                }
            }
            if (checkMie.Checked)
            {
                if ((Convert.ToDateTime(dtp_ini.Text).Date + TimeSpan.Parse(cbxMi_ini.Text)) < Convert.ToDateTime(arch_config.Default.fecha))
                {
                    lblStatus.Text =
                    String.Format("Debe elegir una fecha y hora no menor a: {0}", arch_config.Default.fecha);
                    return;
                }
            }
            if (checkJue.Checked)
            {
                if ((Convert.ToDateTime(dtp_ini.Text).Date + TimeSpan.Parse(cbxJu_ini.Text)) < Convert.ToDateTime(arch_config.Default.fecha))
                {
                    lblStatus.Text =
                    String.Format("Debe elegir una fecha y hora no menor a: {0}", arch_config.Default.fecha);
                    return;
                }
            }

            if (checkVie.Checked)
            {
                if ((Convert.ToDateTime(dtp_ini.Text).Date + TimeSpan.Parse(cbxVi_ini.Text)) < Convert.ToDateTime(arch_config.Default.fecha))
                {
                    lblStatus.Text =
                    String.Format("Debe elegir una fecha y hora no menor a: {0}", arch_config.Default.fecha);
                    return;
                }
            }
            if (checkSa.Checked)
            {
                if ((Convert.ToDateTime(dtp_ini.Text).Date + TimeSpan.Parse(cbxSa_ini.Text)) < Convert.ToDateTime(arch_config.Default.fecha))
                {
                    lblStatus.Text =
                    String.Format("Debe elegir una fecha y hora no menor a: {0}", arch_config.Default.fecha);
                    return;
                }
            }

               

            
            Boolean noErrorFlag = true;
            if (txtProfCod.Text == "")
            {
                lblStatus.Text = "Debe ingresar número de documento del profesional";
                return;
            }
            if (dtp_ini.Value > dtp_fin.Value)
            {
                lblStatus.Text = "Fecha de comienzo debe ser \n menor o igual que fecha final";
                return;
            }

            if (checkLunes.Checked & !CompareStringAscii(cbxLun_ini.Text, cbxLun_fin.Text))
            {
                lblStatus.Text = "Horario de inicio debe ser \n menor que horario final";
                return;
            }
            if (checkMartes.Checked & !CompareStringAscii(cbxMa_ini.Text, cbxMa_fin.Text))
            {
                lblStatus.Text = "Horario de inicio debe ser \n menor que horario final";
                return;
            }
            if (checkMie.Checked & !CompareStringAscii(cbxMi_ini.Text, cbxMi_fin.Text))
            {
                lblStatus.Text = "Horario de inicio debe ser \n menor que horario final";
                return;
            }
            if (checkJue.Checked & !CompareStringAscii(cbxJu_ini.Text, cbxJu_fin.Text))
            {
                lblStatus.Text = "Horario de inicio debe ser \n menor que horario final";
                return;
            }
            if (checkVie.Checked & !CompareStringAscii(cbxVi_ini.Text, cbxVi_fin.Text))
            {
                lblStatus.Text = "Horario de inicio debe ser \n menor que horario final";
                return;
            }
            if (checkSa.Checked & !CompareStringAscii(cbxSa_ini.Text, cbxSa_fin.Text))
            {
                lblStatus.Text = "Horario de inicio debe ser \n menor que horario final";
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
                    lblStatus.Text = "La fecha hasta la cual se desea programar supera el rango de 120 días";
                    return;
                }
            }
            
            
            lblStatus.Text = "EJECUTANDO";
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
                    lblStatus.Text = EXC.Message.ToString();
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
                    lblStatus.Text = EXC.Message.ToString();
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
                    lblStatus.Text = EXC.Message.ToString();
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
                    lblStatus.Text = EXC.Message.ToString();
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
                    lblStatus.Text = EXC.Message.ToString();
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
                    lblStatus.Text = EXC.Message.ToString();
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
                        string.Format("DELETE RH FROM PROYECTO_W.RangoHorario AS RH JOIN PROYECTO_W.AgendaProfesional ON agen_cod = RH.hora_agen_cod JOIN PROYECTO_W.Profesional ON prof_cod = agen_prof_cod WHERE prof_doc_nro = {0} AND RH.hora_fecha = '{1}'", txtProfCod.Text, item.Date.ToString());
                    sqlConexion.ejecutarQuery(queryExceps);
                    queryExceps =
                        string.Format("DELETE FE FROM PROYECTO_W.Fecha AS FE JOIN PROYECTO_W.AgendaProfesional ON agen_cod = FE.fecha_agen_cod JOIN PROYECTO_W.Profesional ON agen_prof_cod = prof_cod WHERE prof_doc_nro = {0} AND FE.fecha_fecha = '{1}'", txtProfCod.Text, item.Date.ToString());
                    sqlConexion.ejecutarQuery(queryExceps);
                }
            }
            catch (SqlException ex)
            {
                lblStatus.Text = ex.Message;
            }



            if (noErrorFlag)
                lblStatus.Text = "Ejecución Correcta";

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
   
    }
}
