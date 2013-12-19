using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;

namespace proyecto_w.ABM_Afiliado
{
    public partial class frmABMAfiliado : Form
    {
        private ConexionSQL connectSQL = ConexionSQL.Instance;
        public frmABMAfiliado()
        {
            InitializeComponent();
            string query = string.Format("SELECT afil_nro, afil_nombre, afil_apellido, afil_doc_tipo, afil_doc_nro, afil_direccion, afil_telefono, afil_mail,afil_fecha_nac, afil_sexo, afil_estado_civil, Pl.plan_descripcion FROM PROYECTO_W.Afiliado AS A JOIN [GD2C2013].[PROYECTO_W].[Plan] AS Pl ON pl.plan_cod = A.afil_plan_cod WHERE afil_estado='H'");
            DataTable resultAfil = this.connectSQL.ejecutarQuery(query);
            this.grdConsulta.DataSource = resultAfil;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            AltaAfiliadoForm frm = new AltaAfiliadoForm();
            frm.ShowDialog();
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (this.txtFiltro.Text.Length == 8)
            {
                string query = string.Format("SELECT * FROM PROYECTO_W.Afiliado WHERE afil_nro={0} AND afil_estado='H'", this.txtFiltro.Text);
                this.grdConsulta.DataSource = this.connectSQL.ejecutarQuery(query);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (this.grdConsulta.SelectedCells.Count == 0)
                MessageBox.Show("Debe seleccionar un afiliado en la tabla para poder darlo de baja");
            else
            {
                int rowIndex = this.grdConsulta.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = grdConsulta.Rows[rowIndex];
                string id_selected = Convert.ToString(selectedRow.Cells["afil_nro"].Value);
                //DateTime date = DateTime.Now;
                string query = string.Format("UPDATE PROYECTO_W.Afiliado SET afil_estado='D', afil_fecha_baja='{0}' WHERE afil_nro={1}", Convert.ToDateTime(arch_config.Default.fecha).ToString("dd/MM/yyyy HH:mm"), id_selected);
                this.connectSQL.ejecutarQuery(query);
                MessageBox.Show("Usuario dado de Baja correctamente");
                query = string.Format("SELECT afil_nro, afil_nombre, afil_apellido, afil_doc_tipo, afil_doc_nro, afil_direccion, afil_telefono, afil_mail,afil_fecha_nac, afil_sexo, afil_estado_civil, Pl.plan_descripcion FROM PROYECTO_W.Afiliado AS A JOIN [GD2C2013].[PROYECTO_W].[Plan] AS Pl ON pl.plan_cod = A.afil_plan_cod WHERE afil_estado='H'");
                this.grdConsulta.DataSource = this.connectSQL.ejecutarQuery(query);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int rowIndex = this.grdConsulta.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = grdConsulta.Rows[rowIndex];
            string id_selected = Convert.ToString(selectedRow.Cells["afil_nro"].Value);
            string query = string.Format("SELECT afil_nombre, afil_apellido, afil_doc_tipo, afil_doc_nro, afil_direccion, afil_telefono, afil_mail, afil_fecha_nac, afil_plan_cod, afil_cant_pers_a_cargo, afil_nro, afil_sexo, afil_estado_civil, plan_descripcion FROM PROYECTO_W.Afiliado AS A JOIN [GD2C2013].[PROYECTO_W].[Plan] AS Pl ON pl.plan_cod = A.afil_plan_cod WHERE afil_nro={0}", id_selected);
            DataRow afil = this.connectSQL.ejecutarQuery(query).Rows[0];
            AltaAfiliadoForm modificarForm = new AltaAfiliadoForm(afil);
            this.Hide();
            modificarForm.ShowDialog();
            query = string.Format("SELECT afil_nro, afil_nombre, afil_apellido, afil_doc_tipo, afil_doc_nro, afil_direccion, afil_telefono, afil_mail,afil_fecha_nac, afil_sexo, afil_estado_civil, Pl.plan_descripcion FROM PROYECTO_W.Afiliado AS A JOIN [GD2C2013].[PROYECTO_W].[Plan] AS Pl ON pl.plan_cod = A.afil_plan_cod WHERE afil_estado='H'");
            this.grdConsulta.DataSource = this.connectSQL.ejecutarQuery(query);
            this.Show();
            
        }

        private void frmABMAfiliado_Load(object sender, EventArgs e)
        {

        }

        private void active_from(object sender, EventArgs e)
        {
            string query = string.Format("SELECT afil_nro, afil_nombre, afil_apellido, afil_doc_tipo, afil_doc_nro, afil_direccion, afil_telefono, afil_mail,afil_fecha_nac, afil_sexo, afil_estado_civil, Pl.plan_descripcion FROM PROYECTO_W.Afiliado AS A JOIN [GD2C2013].[PROYECTO_W].[Plan] AS Pl ON pl.plan_cod = A.afil_plan_cod WHERE afil_estado='H'");
            DataTable resultAfil = this.connectSQL.ejecutarQuery(query);
            this.grdConsulta.DataSource = resultAfil;
        }
    }
}