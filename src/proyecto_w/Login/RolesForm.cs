using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;

namespace proyecto_w.Login
{
    public partial class frmRols : Form
    {
        public List<string> roles { get; set; }
        public String rolSelected;
        public frmRols()
        {
            InitializeComponent();
        }

        public void setRoles(List<String> roles)
        {
            this.lstRol.DataSource = roles;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.rolSelected = lstRol.Text.ToString();
            this.Hide();
        }
    }
}
