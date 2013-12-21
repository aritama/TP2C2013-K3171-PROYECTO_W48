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
using proyecto_w.Generar_Receta;
using System.Text.RegularExpressions;

namespace proyecto_w.Registro_Resultado_Atencion
{
    public partial class Registro_Resultado_Atencion_Form : Form
    {
        public Registro_Resultado_Atencion_Form()
        {
            InitializeComponent();
            string llena;
            ConexionSQL conn = new ConexionSQL();
            if (frmLogin.user.Contains("prof"))
            {
                llena = string.Format("select turno_nro from PROYECTO_W.Turno join PROYECTO_W.TurnoLlegada on turlle_turno_nro = turno_nro join PROYECTO_W.Afiliado on turno_afil_nro = afil_nro join PROYECTO_W.Profesional on turno_prof_cod = prof_cod where turno_estado = 'P' and turno_fecha >= (select PROYECTO_W.F_FECHA_CONFIG()) and afil_estado = 'H' and prof_username = '{0}'", frmLogin.user);
            }
            else
            {
                llena = "select turno_nro from PROYECTO_W.Turno join PROYECTO_W.Afiliado on turno_afil_nro = afil_nro JOIN PROYECTO_W.TURNOLLEGADA ON TURLLE_TURNO_NRO = TURNO_NRO where turno_estado = 'P' and turno_fecha >= (select PROYECTO_W.F_FECHA_CONFIG()) and afil_estado = 'H'";
            }
            DataTable turnos = conn.ejecutarQuery(llena);
            uint i = 0;
            while (i < turnos.Rows.Count)
            {
                txtTurnoNro.Items.Add(turnos.Rows[(int)i][0]);
                i++;
            }
        }

        private void btnRegistrarResultadoAtencion_Click(object sender, EventArgs e)
        {
            ConexionSQL sqlConexion = ConexionSQL.Instance;
            bool noError = true;
            int Concretado = 0;
            if (checkConcretado.Checked)
            {
                if (txtDiagnostico.Text == "")
                {
                    //lblStatus.Text = "Debe ingresar algún diagnóstico";
                    MessageBox.Show("Debe ingresar algún diagnóstico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                
                Concretado = 1;
            }
            String queryConcretado =
                string.Format("EXEC PROYECTO_W.SP_TURNO_CONCRETADO {0},'{1}','{2}',{3}",
                    txtTurnoNro.Text, txtSintoma.Text, txtDiagnostico.Text, Concretado);
//@TURNO_NRO NUMERIC(18,0), @SINTOMAS VARCHAR(255), @DIAGNOSTICO VARCHAR(255), @CONCRETADO TINYINT)
            try
            {
                sqlConexion.ejecutarQuery(queryConcretado);
            }
            catch (SqlException ex)
            {
               // lblStatus.Text = ex.Message;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                noError = false;
            }

            if (noError & checkConReceta.Checked)
            {
                //verificar primero que no haya receta ya hecha 
                queryConcretado =
                    string.Format("SELECT * FROM PROYECTO_W.TurnoConcretado WHERE turconcr_turno_nro = {0} AND turconcr_receta_cod != NULL", txtTurnoNro.Text);
                DataTable checkTab = sqlConexion.ejecutarQuery(queryConcretado);
                if (checkTab.Rows.Count > 0)
                {
                    //lblStatus.Text= "Este turno ya posee \n receta asociada";
                    MessageBox.Show("Este turno ya posee \n receta asociada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Generar_Receta_Form genReceta = new Generar_Receta_Form(System.UInt32.Parse(txtTurnoNro.Text));
                this.Hide();
                genReceta.ShowDialog();
                this.Show();
            }

            if (noError)
                //lblStatus.Text = "Registrado correctamente";
                MessageBox.Show("Registrado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txtTurnoNro_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "Ingresando Datos";
            if (!Regex.IsMatch(txtTurnoNro.Text, @"^\d+$")) { txtTurnoNro.Text = "0"; }
        }

        private void Registro_Resultado_Atencion_Form_Load(object sender, EventArgs e)
        {

        }

        private void txtTurnoNro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
