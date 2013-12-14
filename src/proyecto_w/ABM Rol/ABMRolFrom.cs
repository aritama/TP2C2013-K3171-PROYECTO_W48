using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;
using proyecto_w.ABM_Rol;

namespace proyecto_w.ABM_Rol
{
    public partial class frmABMRol : Form
    {
        private ConexionSQL connectionSQL = ConexionSQL.Instance;
        private void reloadRoles()
        {
            string queryString = string.Format("SELECT R.rol_nombre FROM PROYECTO_W.Rol AS R");
            DataTable roles = connectionSQL.ejecutarQuery(queryString);
            this.grdRoles.DataSource = roles;
        }
        public frmABMRol()
        {
            InitializeComponent();
            this.reloadRoles();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (validar_seleccion() == true)
            {

                this.Hide();
                string rol = this.grdRoles.SelectedCells[0].Value.ToString();
                string query = string.Format("SELECT F.func_nombre FROM PROYECTO_W.Funcionalidad AS F JOIN PROYECTO_W.FuncionalidadPorRol AS FR ON FR.funcxrol_func_cod = F.func_cod JOIN PROYECTO_W.Rol AS R ON R.rol_cod = FR.funcxrol_rol_cod WHERE R.rol_nombre = '{0}' AND FR.funcxrol_estado = 'H'", rol);
                ConexionSQL connectionSQL = ConexionSQL.Instance;
                DataTable funcionalidades = connectionSQL.ejecutarQuery(query);
                List<String> funciones = new List<String>();
                for (int i = 0; i < funcionalidades.Rows.Count; i++)
                {
                    funciones.Add(funcionalidades.Rows[i]["func_nombre"].ToString());
                }

                frmModificarRol formFuncs = new frmModificarRol(funciones, rol);
                formFuncs.ShowDialog();
                this.Show();
            }
        }

        private void btnAltaRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmModificarRol formAlta = new frmModificarRol();
            formAlta.ShowDialog();
            this.reloadRoles();
            this.Show();
        }

        private bool validar_seleccion()
        {
            if (grdRoles.SelectedCells.Count == 0)
            {
                MessageBox.Show("No selecciono ningun Rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else return true;
        }

        private void Activated_Form(object sender, EventArgs e)
        {
            reloadRoles();
        }
    }
}