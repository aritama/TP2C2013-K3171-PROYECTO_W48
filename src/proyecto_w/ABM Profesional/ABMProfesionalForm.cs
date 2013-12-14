using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;

namespace proyecto_w.ABM_Profesional
{
    public partial class frmABMProfesional : Form
    {
        private ConexionSQL conn = ConexionSQL.Instance;

        private void getProfesionalGrid()
        {
            string query = string.Format("SELECT prof_cod, prof_nombre, prof_apellido, prof_username, prof_doc_tipo, prof_doc_nro, prof_direccion, prof_telefono, prof_mail, prof_fecha_nac, prof_sexo, prof_matricula FROM PROYECTO_W.Profesional WHERE prof_estado='H'");
            this.grdConsulta.DataSource = this.conn.ejecutarQuery(query);
        }

        public frmABMProfesional()
        {
            InitializeComponent();
            this.getProfesionalGrid();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string query;
            if (this.txtFiltro.Text != "")
            {
                query = string.Format("SELECT prof_cod, prof_nombre, prof_apellido, prof_username, prof_doc_tipo, prof_doc_nro, prof_direccion, prof_telefono, prof_mail, prof_fecha_nac, prof_sexo, prof_matricula FROM PROYECTO_W.Profesional WHERE prof_estado='H' AND prof_cod = {0}", this.txtFiltro.Text);
                DataTable consulta = this.conn.ejecutarQuery(query);
                this.grdConsulta.DataSource = consulta;
                this.btnClean.Enabled = true;
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            this.Hide();
            AltaProfesionalForm altaForm = new AltaProfesionalForm();
            altaForm.ShowDialog();
            this.getProfesionalGrid();
            this.Show();
        }

        private void onlyNumbers(KeyPressEventArgs ev)
        {
            if (!Char.IsControl(ev.KeyChar) && !Char.IsNumber(ev.KeyChar))
                ev.Handled = true;
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.onlyNumbers(e);
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            this.btnClean.Enabled = false;
            this.getProfesionalGrid();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (this.grdConsulta.SelectedCells.Count == 0)
                MessageBox.Show("Debe seleccionar al menos un profesional para darlo de baja");
            else
            {
                string nombre_apellido, prof_cod;
                int selectedrowindex = this.grdConsulta.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.grdConsulta.Rows[selectedrowindex];

                nombre_apellido = Convert.ToString(selectedRow.Cells["Nombre"].Value) + " " + Convert.ToString(selectedRow.Cells["Apellido"].Value);
                prof_cod = Convert.ToString(selectedRow.Cells["Codigo"].Value);
                DialogResult dialogResult = MessageBox.Show("Esta seguro que desea dar de baja al profesional: "+nombre_apellido, "Baja profesional", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //Selecciono todos los turnos que tenia el profesional
                    string query = string.Format("SELECT turno_nro FROM PROYECTO_W.Turno WHERE turno_prof_cod={0}", prof_cod);
                    DataRowCollection turnos_nros = this.conn.ejecutarQuery(query).Rows;
                    
                    //Borro todos los turnos llegadas
                    foreach(DataRow turno_nro in turnos_nros)
                    {
                        query = string.Format("DELETE FROM PROYECTO_W.TurnoLlegada WHERE turlle_turno_nro={0}", turno_nro["turno_nro"].ToString());
                        this.conn.ejecutarQuery(query);
                    }

                    //Borro todos los turnos concretados
                    foreach (DataRow turno_nro in turnos_nros)
                    {
                        query = string.Format("DELETE FROM PROYECTO_W.TurnoConcretado WHERE turconcr_turno_nro={0}", turno_nro["turno_nro"].ToString());
                        this.conn.ejecutarQuery(query);
                    }

                    //Borro todos los turnos cancelacion
                    foreach (DataRow turno_nro in turnos_nros)
                    {
                        query = string.Format("DELETE FROM PROYECTO_W.TurnoCancelacion WHERE turcan_turno_nro={0}", turno_nro["turno_nro"].ToString());
                        this.conn.ejecutarQuery(query);
                    }

                    //Borro todos los turnos del profesional
                    query = string.Format("DELETE FROM PROYECTO_W.Turno WHERE turno_prof_cod={0}", prof_cod);
                    this.conn.ejecutarQuery(query);

                    //Doy de baja logica del profesional
                    query = string.Format("UPDATE PROYECTO_W.Profesional SET prof_estado='D' WHERE prof_cod={0}", prof_cod);
                    this.conn.ejecutarQuery(query);

                    //Actualizo la tabla
                    this.getProfesionalGrid();
                    MessageBox.Show("El profesional " + nombre_apellido + " Fue dado de baja exitosamente. Todos sus turnos se han eliminado. Por favor, avisar a los pacientes");
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int selectedrowindex = this.grdConsulta.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = this.grdConsulta.Rows[selectedrowindex];
            string prof_cod = Convert.ToString(selectedRow.Cells["Codigo"].Value);

            AltaProfesionalForm modifProf = new AltaProfesionalForm(prof_cod);
            this.Hide();
            modifProf.ShowDialog();
            this.getProfesionalGrid();
            this.Show();
        }
    }
}
