using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;
using proyecto_w.Login;
using System.Security.Cryptography;

namespace proyecto_w
{
    public partial class frmLogin : Form
    {
        private String rolSelected;
        public static string user;
        public frmLogin()
        {
            InitializeComponent();
        }

        public class Hash
        {
            public static string getHashSha256(string text)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                SHA256Managed hashstring = new SHA256Managed();
                byte[] hash = hashstring.ComputeHash(bytes);
                string hashString = string.Empty;
                foreach (byte x in hash)
                {
                    hashString += String.Format("{0:x2}", x);
                }
                return hashString;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // CARGO LA BASE CON LA FECHA
            string query_fecha = string.Format("EXEC PROYECTO_W.SP_CARGAR_FECHA @FECHA_CARG = '{0}'", Convert.ToDateTime(arch_config.Default.fecha).ToString("dd/MM/yyyy HH:mm"));
            ConexionSQL conn = new ConexionSQL();
            conn.ejecutarQuery(query_fecha);
            string queryLogin, querySQL;
            ConexionSQL connectionSQL = ConexionSQL.Instance;
            string username = txtUsername.Text;
            user = txtUsername.Text;
            string password = txtPassword.Text;
            queryLogin = string.Format("SELECT usu_password, usu_estado, usu_cant_intentos FROM PROYECTO_W.Usuario WHERE usu_username='{0}'", username);
            DataTable users = connectionSQL.ejecutarQuery(queryLogin);
            if (users.Rows.Count == 1)
            {
                if (users.Rows[0]["usu_estado"].ToString() == "D")
                {
                    MessageBox.Show("Usuario Deshabilitado. Hable con el Administrador para solucionar el problema");
                }
                else if (users.Rows[0]["usu_password"].ToString().ToUpper() != (Hash.getHashSha256(password)).ToUpper())
                {
                    queryLogin = string.Format("UPDATE PROYECTO_W.Usuario SET usu_cant_intentos=usu_cant_intentos+1 WHERE usu_username='{0}'", username);
                    connectionSQL.ejecutarQuery(queryLogin);
                    queryLogin = string.Format("SELECT usu_cant_intentos FROM PROYECTO_W.Usuario WHERE usu_username='{0}'", username);
                    int cant_intentos = Int32.Parse(connectionSQL.ejecutarQuery(queryLogin).Rows[0]["usu_cant_intentos"].ToString());
                    if (cant_intentos >= 3)
                    {
                        queryLogin = string.Format("UPDATE PROYECTO_W.Usuario SET usu_estado='D' WHERE usu_username='{0}'", username);
                        connectionSQL.ejecutarQuery(queryLogin);
                        MessageBox.Show("Usuario Deshabilitado");
                        txtUsername.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Credenciales Incorrectas. Porfavor intene nuevamente");
                        txtUsername.Text = "";
                    }
                }
                else
                {
                    queryLogin = string.Format("SELECT R.rol_cod, R.rol_nombre FROM PROYECTO_W.Rol AS R, PROYECTO_W.RolPorUsuario AS RU WHERE RU.rolxusu_username='{0}' AND RU.rolxusu_rol_cod=R.rol_cod and rol_estado = 'H'", username);
                    DataTable rols = connectionSQL.ejecutarQuery(queryLogin);
                    this.Hide();
                    if (rols.Rows.Count != 0)
                    {
                        if (rols.Rows.Count > 1)
                        {
                            List<String> rols_strings = new List<string>();

                            for (int i = 0; i < rols.Rows.Count; i++)
                            {
                                rols_strings.Add(rols.Rows[i]["rol_nombre"].ToString());
                            }
                            frmRols rolsForm = new frmRols();
                            rolsForm.setRoles(rols_strings);
                            rolsForm.ShowDialog();
                            this.rolSelected = rolsForm.rolSelected;
                        }
                        else
                        {
                            this.rolSelected = rols.Rows[0]["rol_nombre"].ToString();
                        }
                        querySQL = string.Format("SELECT F.func_nombre FROM PROYECTO_W.Funcionalidad AS F JOIN PROYECTO_W.FuncionalidadPorRol AS FR ON FR.funcxrol_func_cod=F.func_cod JOIN PROYECTO_W.Rol AS R ON R.rol_cod=fr.funcxrol_rol_cod WHERE R.rol_nombre='{0}' and funcxrol_estado = 'H'", rolSelected);
                        DataTable functions = connectionSQL.ejecutarQuery(querySQL);

                        if (functions.Rows.Count == 0)
                        {
                            MessageBox.Show("No tiene funcionalidades Habilitadas. Cerrando Programa");
                            this.Close();
                        }
                        List<String> functionsStrings = new List<string>();
                        for (int i = 0; i < functions.Rows.Count; i++)
                        {
                            functionsStrings.Add(functions.Rows[i]["func_nombre"].ToString());
                        }

                        MainWindowForm mainWindow = new MainWindowForm();
                        mainWindow.setFunctions(functionsStrings);
                        mainWindow.ShowDialog();
                    }
                        
                    
                    else
                    {
                        MessageBox.Show("No tiene ningun Rol asignado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (!this.Visible) Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Credenciales Incorrectas. Porfavor intene nuevamente");
                txtUsername.Text = "";
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled = !string.IsNullOrEmpty(txtUsername.Text) & !string.IsNullOrEmpty(txtPassword.Text);
            txtPassword.Enabled = !string.IsNullOrEmpty(txtUsername.Text);
            if (!txtPassword.Enabled) txtPassword.Text = "";
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled = !string.IsNullOrEmpty(txtPassword.Text);
        }
    }
}
