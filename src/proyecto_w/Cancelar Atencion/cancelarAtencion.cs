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
using proyecto_w.Login;

namespace proyecto_w.Cancelar_Atencion
{
    public partial class frmCancelarAtencion : Form
    {
        private void recargarComboTurno(ComboBox cbX)
        {
            ConexionSQL sqlConn = ConexionSQL.Instance;
            String llena;
            if (frmLogin.user.Contains("afil"))
            {
                llena = string.Format("select turno_nro from PROYECTO_W.Turno join PROYECTO_W.Afiliado on turno_afil_nro = afil_nro where turno_estado = 'P' and turno_fecha >= (select PROYECTO_W.F_FECHA_CONFIG()) and afil_estado = 'H' and afil_username = '{0}'", frmLogin.user);
            }
            else if (frmLogin.user.Contains("prof"))
            {
                llena = string.Format("select turno_nro from PROYECTO_W.Turno join PROYECTO_W.Afiliado on turno_afil_nro = afil_nro join PROYECTO_W.Profesional on turno_prof_cod = prof_cod where turno_estado = 'P' and turno_fecha >= (select PROYECTO_W.F_FECHA_CONFIG()) and afil_estado = 'H' and prof_username = '{0}'", frmLogin.user);
            }
            else
            {
                llena = "select turno_nro from PROYECTO_W.Turno join PROYECTO_W.Afiliado on turno_afil_nro = afil_nro where turno_estado = 'P' and turno_fecha >= (select PROYECTO_W.F_FECHA_CONFIG()) and afil_estado = 'H'";
            }
            cbX.Items.Clear();
            DataTable turnos = sqlConn.ejecutarQuery(llena);
            uint i = 0;
            while (i < turnos.Rows.Count)
            {
                cbX.Items.Add(turnos.Rows[(int)i][0]);
                i++;
            }

        }
        public frmCancelarAtencion()
        {
            InitializeComponent();

            if (frmLogin.user.Contains("prof"))
            {
                cbxCancel_quien.Items.Add("Profesional");
            }
            else if (frmLogin.user.Contains("afil"))
            {
                cbxCancel_quien.Items.Add("Afiliado");
            }
            else
            {
                cbxCancel_quien.Items.Add("Profesional");
                cbxCancel_quien.Items.Add("Afiliado");
            }
            recargarComboTurno(txtCancel_turno_nro);
        }

        

        private void cbxCancel_quien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (cbxCancel_quien.Text == "")
            {
                //lblCancel_status.Text = "Debe seleccionar quién cancela";
                MessageBox.Show("Debe seleccionar quién cancela", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            ConexionSQL CONEXION = ConexionSQL.Instance;
            if (txtCancel_turno_nro.Text == "")
            {
                MessageBox.Show("No ingreso un numero de turno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            String quien = "nadie";
            if (cbxCancel_quien.Text == "Profesional")
                quien = "MEDICO";
            if (cbxCancel_quien.Text == "Afiliado")
                quien = "PACIENTE";
            if (quien != "nadie")
            {
                String QUERY = string.Format("EXEC PROYECTO_W.SP_CANCELAR {0},'{1}','{2}'", txtCancel_turno_nro.Text,
                       quien, txtCancel_motivo.Text);
                Boolean queryFail = false;
                try
                {
                    CONEXION.ejecutarQuery(QUERY);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    queryFail = true;
                }
                if (!queryFail)
                {
                    //lblCancel_status.Text = ;
                    MessageBox.Show("Atención cancelada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    recargarComboTurno(txtCancel_turno_nro);
                }
            }
            else MessageBox.Show("Datos invalidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txtnroturno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtCancel_turno_nro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtCancel_turno_nro.Text != "")
            {
                ConexionSQL sqlConn = ConexionSQL.Instance;
                String qData = "select 'Fecha: ' + CONVERT(VARCHAR, turno_fecha,120), ";
                qData += "'Afiliado: ' + afil_apellido + ', ' + afil_nombre as afil_data, ";
                qData += "'Profesional: '+prof_apellido+', '+prof_nombre as prof_data, ";
                qData += "'Especialidad: '+esp_descripcion as esp from PROYECTO_W.Turno ";
                //qData += "join PROYECTO_W.TurnoLlegada on turlle_turno_nro = turno_nro ";
                qData += "join PROYECTO_W.Afiliado on turno_afil_nro = afil_nro ";
                qData += "join PROYECTO_W.Profesional on prof_cod = turno_prof_cod ";
                qData += "join PROYECTO_W.Especialidad on turno_esp_cod = esp_cod ";
                qData += String.Format("where turno_estado = 'P' and CAST(turno_fecha AS DATETIME) >= (select PROYECTO_W.F_FECHA_CONFIG()) and afil_estado = 'H' and turno_nro = {0}", txtCancel_turno_nro.Text);
                DataTable infoTable = sqlConn.ejecutarQuery(qData);
                if (infoTable.Rows.Count != 0)
                {
                    lblTurnoInfo.Text = String.Format("{0}\n{1}\n{2}\n{3}",
                        infoTable.Rows[0][0].ToString(), infoTable.Rows[0][1].ToString(),
                        infoTable.Rows[0][2].ToString(), infoTable.Rows[0][3].ToString());
                }
            }
            else
            {
                lblTurnoInfo.Text = "";
            }

        }

        private void frmCancelarAtencion_Load(object sender, EventArgs e)
        {

        }

       
    }
}
