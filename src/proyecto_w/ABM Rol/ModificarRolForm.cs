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

namespace proyecto_w.ABM_Rol
{
    public partial class frmModificarRol : Form
    {
        private string rol;
        ConexionSQL connectionSQL = ConexionSQL.Instance;
        private DataTable funcionalidades;
        private bool status;
        private string action;
        public frmModificarRol()
        {
            InitializeComponent();
            this.action = "ALTA";
            string query = string.Format("SELECT func_nombre FROM PROYECTO_W.Funcionalidad");
            List<String> arrayString = new List<string>();
            DataTable funcs = this.connectionSQL.ejecutarQuery(query);
            for (int i = 0; i < funcs.Rows.Count; i++)
                arrayString.Add(funcs.Rows[i]["func_nombre"].ToString());

            this.lstFuncionalidad.DataSource = arrayString;
        }
        public frmModificarRol(List<String> funciones, string rol) 
        {
            InitializeComponent();
            this.action = "MOD";
            this.txtNombreRol.Text = rol;
            this.rol = rol;
            string query = string.Format("SELECT func_nombre FROM PROYECTO_W.Funcionalidad");
            this.funcionalidades = this.connectionSQL.ejecutarQuery(query);
            List<String> funcionalidadesString = new List<string>();
            for (int i = 0; i < this.funcionalidades.Rows.Count; i++) 
            {
                funcionalidadesString.Add(this.funcionalidades.Rows[i][0].ToString());
            }
            this.lstFuncionalidad.DataSource = funcionalidadesString;
            for(int i=0;i<this.funcionalidades.Rows.Count;i++)
            {
                if (funciones.IndexOf(this.funcionalidades.Rows[i]["func_nombre"].ToString()) != -1)
                    this.lstFuncionalidad.SetSelected(i, true);
                else
                    this.lstFuncionalidad.SetSelected(i, false);
            }
            query = string.Format("SELECT R.rol_estado FROM PROYECTO_W.Rol AS R WHERE R.rol_nombre = '{0}'", this.rol);
            DataTable results = this.connectionSQL.ejecutarQuery(query);
            this.status = (results.Rows[0]["rol_estado"].ToString() == "H");
            this.chkEnable.Checked = this.status;
 
        }

        private bool validar_campo()
        {
            if (txtNombreRol.Text == "")
            {
                MessageBox.Show("Debe Ingresar un nombre de rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //if (this.action == "ALTA")
            //{
            //    if (lstFuncionalidad.SelectedItem)
            //}
            else return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validar_campo() == true)
            {

                if (this.action == "MOD")
                {
                    string checkEnable, status, queryString;

                    if (this.chkEnable.Checked) checkEnable = "H";
                    else
                    {
                        checkEnable = "D";
                        if (this.status)
                        {
                            queryString = string.Format("SELECT rol_cod FROM PROYECTO_W.Rol WHERE rol_nombre = '{0}'", this.rol);
                            DataTable queryRolCode = this.connectionSQL.ejecutarQuery(queryString);
                            string rolCode = queryRolCode.Rows[0]["rol_cod"].ToString();
                            queryString = string.Format("DELETE FROM PROYECTO_W.RolPorUsuario WHERE rolxusu_rol_cod = {0}", rolCode);
                            this.connectionSQL.ejecutarQuery(queryString);
                        }
                    }

                    string queryEnable = string.Format("UPDATE R SET rol_estado='{0}'  FROM PROYECTO_W.Rol AS R WHERE rol_nombre = '{1}'", checkEnable, this.rol);

                                       
                    this.connectionSQL.ejecutarQuery(queryEnable);
                                    

                    string queryName = string.Format("UPDATE R SET rol_nombre = '{0}' FROM PROYECTO_W.Rol AS R WHERE R.rol_nombre = '{1}'", this.txtNombreRol.Text, this.rol);
                    try
                    {
                        connectionSQL.ejecutarQuery(queryName);
                    }
                    catch (SqlException err)
                    {
                        MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    foreach (string element in this.lstFuncionalidad.Items)
                    {
                        if (this.lstFuncionalidad.SelectedItems.Contains(element))
                            status = "H";
                        else
                            status = "D";
                        queryString = string.Format("UPDATE FR SET FR.funcxrol_estado='{0}' FROM PROYECTO_W.FuncionalidadPorRol AS FR JOIN PROYECTO_W.Rol AS R ON R.rol_cod = FR.funcxrol_rol_cod JOIN PROYECTO_W.Funcionalidad AS F ON F.func_cod = FR.funcxrol_func_cod WHERE F.func_nombre = '{1}' AND R.rol_nombre='{2}'", status, element, this.rol);
                        this.connectionSQL.ejecutarQuery(queryString);
                    }
                }
                else if (this.action == "ALTA")
                {
                    string queryString, rolStatus, status;
                    string rolName = this.txtNombreRol.Text;
                    if (this.chkEnable.Checked) rolStatus = "H";
                    else rolStatus = "D";
                    queryString = string.Format("INSERT INTO PROYECTO_W.Rol(rol_nombre, rol_estado) VALUES ('{0}','{1}')", rolName, rolStatus);
                    this.connectionSQL.ejecutarQuery(queryString);
                    queryString = string.Format("SELECT rol_cod FROM PROYECTO_W.Rol WHERE rol_nombre='{0}'", rolName);
                    string rolCode = this.connectionSQL.ejecutarQuery(queryString).Rows[0]["rol_cod"].ToString();
                    int iterator = 1;
                    foreach (string element in this.lstFuncionalidad.Items)
                    {
                        if (this.lstFuncionalidad.SelectedItems.Contains(element))
                            status = "H";
                        else
                            status = "D";
                        queryString = string.Format("INSERT INTO PROYECTO_W.FuncionalidadPorRol VALUES ({0},{1},'{2}')", rolCode, iterator.ToString(), status);
                        this.connectionSQL.ejecutarQuery(queryString);
                        iterator = iterator + 1;
                    }
                }
                this.Hide();
            }
        }
    }
}
