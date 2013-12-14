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

namespace proyecto_w.Compra_de_Bono
{
    public partial class frmCompra_de_Bono : Form
    {
        public frmCompra_de_Bono()
        {
            InitializeComponent();

            cmbCDB_Tipo.Items.Add("Farmacia");
            cmbCDB_Tipo.Items.Add("Consulta");
            if (frmLogin.user.Contains("afil"))
            {
                string query = string.Format("SELECT afil_nro FROM PROYECTO_W.Afiliado WHERE afil_username = '{0}'", frmLogin.user);
                ConexionSQL conn = new ConexionSQL();
                txtCDB_AfilNro.Text = conn.ejecutarQuery(query).Rows[0][0].ToString();
                txtCDB_AfilNro.Enabled = false;
            }
        }

        private void cmbCDB_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCDB_Status.Text = "Ingreso de datos";
        }

        private void btnCDB_RealizarCompra_Click(object sender, EventArgs e)
        {
            if (cmbCDB_Tipo.Text == "")
            {
                lblCDB_Status.Text = "Debe seleccionar el tipo de bono";
                return;
            }
            
            // CHEQUEAR AFIL_NRO, CANTIDAD > 0 , ANTES DE ENVIAR LA QUERY
            lblCDB_Status.Text = "HACIENDO";
            ConexionSQL connectionSQL = ConexionSQL.Instance;
            //uint PLAN_COD, SUMA;
                                   
            String queryCompra = string.Format("exec PROYECTO_W.SP_COMPRABONOADMIN {0},'{1}',{2}",
                txtCDB_AfilNro.Text, cmbCDB_Tipo.Text, txtCDB_Cantidad.Text);
            String queryDatos = string.Format("SELECT * FROM PROYECTO_W.F_COMPRABONO_DATOS ({0},'{1}',{2})",
                txtCDB_AfilNro.Text, cmbCDB_Tipo.Text, txtCDB_Cantidad.Text);
            // TENDRIA QUE ENVIARSE LA FECHA ACTUAL, PERO ESTAMO PROBANDO NOMA
            
            try
            {
                connectionSQL.ejecutarQuery(queryCompra);
            }
            catch (SqlException )
             {
                lblCDB_Status.Text = "Datos no validos";   
             }
            if (lblCDB_Status.Text != "Datos no validos")
            {
                DataTable datosCompra = connectionSQL.ejecutarQuery(queryDatos);
                //connectionSQL.ejecutarQuery(queryDatos);
                lblCDB_Status.Text = "Compra realizada, suma a pagar: " + datosCompra.Rows[0][0].ToString() + 
                        ". Plan: " + datosCompra.Rows[0][1].ToString();
                if (cmbCDB_Tipo.Text == "Farmacia")
                    lblCDB_Status.Text = lblCDB_Status.Text + ". \nFecha vencimiento: " + ((DateTime)(datosCompra.Rows[0][2])).AddDays(60).ToString();
                // mostrar codigo de bonos
                if (datosCompra.Rows[0][4].ToString() == "Farmacia")
                {
                    //muestro los bonos farmacia
                    String queryFarmacia =
                        string.Format("SELECT bonofarm_cod from PROYECTO_W.BonoFarmacia WHERE bonofarm_bonadq_cod = {0}", datosCompra.Rows[0][3]);
                    DataTable bonosFarmacia = connectionSQL.ejecutarQuery(queryFarmacia);
                    lblCDB_Status.Text = lblCDB_Status.Text + ". Bonos: ";
                    int cantBonos = bonosFarmacia.Rows.Count;
                    while (cantBonos > 0)
                    {
                        cantBonos = cantBonos - 1;
                        lblCDB_Status.Text = lblCDB_Status.Text + bonosFarmacia.Rows[cantBonos][0] + ", ";
                    }
                }
                else
                {
                    String queryConsulta =
                       string.Format("select bonocons_cod from PROYECTO_W.BonoConsulta WHERE bonocons_bonadq_cod = {0}", datosCompra.Rows[0][3]);
                    DataTable bonosConsulta = connectionSQL.ejecutarQuery(queryConsulta);
                    lblCDB_Status.Text = lblCDB_Status.Text + ". Bonos: ";
                    int cantBonos = bonosConsulta.Rows.Count;
                    while (cantBonos > 0)
                    {
                        cantBonos = cantBonos - 1;
                        lblCDB_Status.Text = lblCDB_Status.Text + bonosConsulta.Rows[cantBonos][0] + ", ";
                    }
                }
            }
            
        }

        private void txtCDB_AfilNro_TextChanged(object sender, EventArgs e)
        {
            lblCDB_Status.Text = "Ingreso de datos";
            if (!Regex.IsMatch(txtCDB_AfilNro.Text, @"^\d+$")) { txtCDB_AfilNro.Text = "0"; }
        }

        private void txtCDB_Cantidad_TextChanged(object sender, EventArgs e)
        {
            lblCDB_Status.Text = "Ingreso de datos";
            if (!Regex.IsMatch(txtCDB_Cantidad.Text, @"^\d+$")) { txtCDB_Cantidad.Text = "0"; }
        }

        private void frmCompra_de_Bono_Load(object sender, EventArgs e)
        {

        }

                        
    }
}
