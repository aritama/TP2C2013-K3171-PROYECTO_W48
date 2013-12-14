using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace proyecto_w.Listado_Estadistico
{
    public partial class ListadoEstadisticoForm : Form
    {
        public ListadoEstadisticoForm()
        {
            InitializeComponent();
            this.cbListado.Items.Add("1.Especialidades que mas registraron cancelaciones");
            this.cbListado.Items.Add("2.Bonos farmacia vencidos por afiliado");
            this.cbListado.Items.Add("3.Especialidades con bonos farmacia recetados");
            this.cbListado.Items.Add("4.Afiliados que usaron bonos que no compraron");
            this.cbSemestre.Items.Add("1");
            this.cbSemestre.Items.Add("2");
        }

        private void btAceptar_Click_1(object sender, EventArgs e)
        {
            if (validar_campo() == true)
            {
                               
                int indexlistado;
                switch (cbListado.SelectedIndex)
                {
                    case 0:
                        indexlistado = 1;
                        break;
                    case 1:
                        indexlistado = 2;
                        break;
                    case 2:
                        indexlistado = 3;
                        break;
                    case 3:
                        indexlistado = 4;
                        break;
                    default:
                        indexlistado = 1;
                        break;
                }
                ListadoForm listado_1Ventana = new ListadoForm(cbSemestre.Text, txtAño.Text, indexlistado);
                this.Hide();
                listado_1Ventana.ShowDialog();
                this.Show();
                
            }
        }

        private bool validar_campo()
        {
            if (cbListado.Text == "")
            {
                MessageBox.Show("Debe elejir un listado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cbSemestre.Text == "")
            {
                MessageBox.Show("Debe elejir un semestre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtAño.Text == "" || txtAño.Text.Length != 4)
            {
                MessageBox.Show("El campo año esta vacio o ingreso mal el año", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else return true;
        }

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {

                e.Handled = true;

            }
        }

        private void ListadoEstadisticoForm_Load(object sender, EventArgs e)
        {
            cbListado.Text = "";
            cbSemestre.Text = "";
            txtAño.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cbSemestre.SelectedIndex = -1;
            cbListado.SelectedIndex = -1;
            txtAño.Text = "";
        }

    }
}
