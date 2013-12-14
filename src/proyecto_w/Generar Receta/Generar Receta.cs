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

namespace proyecto_w.Generar_Receta
{
    public partial class Generar_Receta_Form : Form
    {
        public uint turno_nro;
        public uint receta_cod;
        DataTable bonosFarmDisp;
        public Generar_Receta_Form(uint nro_turno)
        {
            InitializeComponent();
            turno_nro = nro_turno;
            receta_cod = 0;
        }

        private void recargarListaBonos(ComboBox cbxBonos)
        {
            ConexionSQL sqlConn = ConexionSQL.Instance;
            String queryBonFarm =
                string.Format("SELECT * FROM PROYECTO_W.F_BONOS_FARMACIA_DISPONIBLES({0})", turno_nro);
            // bonofarm_cod, bonadq_afil_nro, bonofarm_fecha_venc
            //bonosFarmDisp.Clear();
            bonosFarmDisp = sqlConn.ejecutarQuery(queryBonFarm);
            cbxBonos.Items.Clear();
            uint cantidad = (uint)bonosFarmDisp.Rows.Count;
            while (cantidad > 0)
            {
                cbxBonos.Items.Add(bonosFarmDisp.Rows[(int)cantidad - 1][0]);
                cantidad--;
            }
        }

        private void Generar_Receta_Load(object sender, EventArgs e)
        {
            ConexionSQL sqlConn = ConexionSQL.Instance;
            String queryMedicamentosCBX =
                string.Format("SELECT DISTINCT medicamento_nombre FROM PROYECTO_W.Medicamento");
            DataTable Meds = sqlConn.ejecutarQuery(queryMedicamentosCBX);
            uint medCount = 0;
            while (medCount < Meds.Rows.Count)
            {
                cbxMed1.Items.Add(Meds.Rows[(int)medCount][0].ToString());
                cbxMed2.Items.Add(Meds.Rows[(int)medCount][0].ToString());
                cbxMed3.Items.Add(Meds.Rows[(int)medCount][0].ToString());
                cbxMed4.Items.Add(Meds.Rows[(int)medCount][0].ToString());
                cbxMed5.Items.Add(Meds.Rows[(int)medCount][0].ToString());
                medCount = medCount + 1;
            }

            recargarListaBonos(cbxBonosFarmacia);


        }

        private void txtCant1_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtCant1.Text, @"^\d+$")) { txtCant1.Text = "0"; }
        }

        private void txtCant2_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtCant2.Text, @"^\d+$")) { txtCant2.Text = "0"; }
        }

        private void txtCant3_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtCant3.Text, @"^\d+$")) { txtCant3.Text = "0"; }
        }

        private void txtCant4_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtCant4.Text, @"^\d+$")) { txtCant4.Text = "0"; }
        }

        private void txtCant5_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtCant5.Text, @"^\d+$")) { txtCant5.Text = "0"; }
        }

        private void cbxBonosFarmacia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxBonosFarmacia.Text != "")
            {
                uint indice = 0;
                uint tope = (uint)bonosFarmDisp.Rows.Count;
                while (cbxBonosFarmacia.Text != bonosFarmDisp.Rows[(int)indice][0].ToString() & indice != tope - 1)
                {
                    indice++;
                }
                lblInfoBono.Text =
                    string.Format("{0}\n{1}", bonosFarmDisp.Rows[(int)indice][1], bonosFarmDisp.Rows[(int)indice][2]);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (cbxMed1.Text == "" & cbxMed2.Text == "" & cbxMed3.Text == "" &
                    cbxMed4.Text == "" & cbxMed5.Text == "")
            {
                lblStatus.Text = "No ha seleccionado \n medicamento alguno";
                return;
            }

            if (cbxBonosFarmacia.Text != "")
            {
                ConexionSQL sqlConn = ConexionSQL.Instance;
                String recetaQuery =
                    string.Format("SELECT * FROM PROYECTO_W.BonoFarmacia WHERE bonofarm_estado = 'S' AND bonofarm_cod = {0}", cbxBonosFarmacia.Text);
                // si variable receta_cod == 0, hay que asignar una receta a esto
                // EXISTE EL BONO ELEGIDO TODAVIA
                DataTable hayBono = sqlConn.ejecutarQuery(recetaQuery);

                if (hayBono.Rows.Count == 1)
                {
                    if ((cbxMed1.Text != "" & !(Convert.ToInt32(txtCant1.Text) <= 3 & Convert.ToInt32(txtCant1.Text) >= 1))
                        | (cbxMed2.Text != "" & !(Convert.ToInt32(txtCant2.Text) <= 3 & Convert.ToInt32(txtCant2.Text) >= 1))
                        | (cbxMed3.Text != "" & !(Convert.ToInt32(txtCant3.Text) <= 3 & Convert.ToInt32(txtCant3.Text) >= 1))
                        | (cbxMed4.Text != "" & !(Convert.ToInt32(txtCant4.Text) <= 3 & Convert.ToInt32(txtCant4.Text) >= 1))
                        | (cbxMed5.Text != "" & !(Convert.ToInt32(txtCant5.Text) <= 3 & Convert.ToInt32(txtCant5.Text) >= 1))
                        )
                    {
                        lblStatus.Text = "La cantidad de medicamentos debe ser entre 1 y 3";
                        return;
                    }

                    if (cbxMed1.Text != "")
                    {
                        recetaQuery =
                            string.Format("INSERT INTO PROYECTO_W.MedicamentoPorBonoFarmacia (medxbonofar_bonofarm_cod,medxbonofar_medicamento_cantidad,medxbonofar_medicamento_nombre_cod) VALUES ({0},{1},(SELECT TOP 1 medicamento_nombre_cod FROM PROYECTO_W.Medicamento WHERE medicamento_nombre = '{2}'))",
                            cbxBonosFarmacia.Text, txtCant1.Text, cbxMed1.Text);
                        try
                        {
                            sqlConn.ejecutarQuery(recetaQuery);
                        }
                        catch (SqlException)
                        {
                            lblStatus.Text = "Medicamento Duplicado";
                            recetaQuery =
                                string.Format("DELETE PROYECTO_W.MedicamentoPorBonoFarmacia WHERE medxbonofar_bonofarm_cod = {0}",
                                cbxBonosFarmacia.Text);
                            sqlConn.ejecutarQuery(recetaQuery);
                            return;
                        }
                    }


                    if (cbxMed2.Text != "")
                    {
                        recetaQuery =
                            string.Format("INSERT INTO PROYECTO_W.MedicamentoPorBonoFarmacia (medxbonofar_bonofarm_cod,medxbonofar_medicamento_cantidad,medxbonofar_medicamento_nombre_cod) VALUES ({0},{1},(SELECT TOP 1 medicamento_nombre_cod FROM PROYECTO_W.Medicamento WHERE medicamento_nombre = '{2}'))",
                            cbxBonosFarmacia.Text, txtCant2.Text, cbxMed2.Text);
                        try
                        {
                            sqlConn.ejecutarQuery(recetaQuery);
                        }
                        catch (SqlException)
                        {
                            lblStatus.Text = "Medicamento Duplicado";
                            recetaQuery =
                                string.Format("DELETE PROYECTO_W.MedicamentoPorBonoFarmacia WHERE medxbonofar_bonofarm_cod = {0}",
                                cbxBonosFarmacia.Text);
                            sqlConn.ejecutarQuery(recetaQuery);
                            return;
                        }
                    }


                    if (cbxMed3.Text != "")
                    {
                        recetaQuery =
                            string.Format("INSERT INTO PROYECTO_W.MedicamentoPorBonoFarmacia (medxbonofar_bonofarm_cod,medxbonofar_medicamento_cantidad,medxbonofar_medicamento_nombre_cod) VALUES ({0},{1},(SELECT TOP 1 medicamento_nombre_cod FROM PROYECTO_W.Medicamento WHERE medicamento_nombre = '{2}'))",
                            cbxBonosFarmacia.Text, txtCant3.Text, cbxMed3.Text);
                        try
                        {
                            sqlConn.ejecutarQuery(recetaQuery);
                        }
                        catch (SqlException)
                        {
                            lblStatus.Text = "Medicamento Duplicado";
                            recetaQuery =
                                string.Format("DELETE PROYECTO_W.MedicamentoPorBonoFarmacia WHERE medxbonofar_bonofarm_cod = {0}",
                                cbxBonosFarmacia.Text);
                            sqlConn.ejecutarQuery(recetaQuery);
                            return;
                        }
                    }


                    if (cbxMed4.Text != "")
                    {
                        recetaQuery =
                            string.Format("INSERT INTO PROYECTO_W.MedicamentoPorBonoFarmacia (medxbonofar_bonofarm_cod,medxbonofar_medicamento_cantidad,medxbonofar_medicamento_nombre_cod) VALUES ({0},{1},(SELECT TOP 1 medicamento_nombre_cod FROM PROYECTO_W.Medicamento WHERE medicamento_nombre = '{2}'))",
                            cbxBonosFarmacia.Text, txtCant4.Text, cbxMed4.Text);
                        try
                        {
                            sqlConn.ejecutarQuery(recetaQuery);
                        }
                        catch (SqlException)
                        {
                            lblStatus.Text = "Medicamento Duplicado";
                            recetaQuery =
                                string.Format("DELETE PROYECTO_W.MedicamentoPorBonoFarmacia WHERE medxbonofar_bonofarm_cod = {0}",
                                cbxBonosFarmacia.Text);
                            sqlConn.ejecutarQuery(recetaQuery);
                            return;
                        }
                    }


                    if (cbxMed5.Text != "")
                    {
                        recetaQuery =
                            string.Format("INSERT INTO PROYECTO_W.MedicamentoPorBonoFarmacia (medxbonofar_bonofarm_cod,medxbonofar_medicamento_cantidad,medxbonofar_medicamento_nombre_cod) VALUES ({0},{1},(SELECT TOP 1 medicamento_nombre_cod FROM PROYECTO_W.Medicamento WHERE medicamento_nombre = '{2}'))",
                            cbxBonosFarmacia.Text, txtCant5.Text, cbxMed5.Text);
                        try
                        {
                            sqlConn.ejecutarQuery(recetaQuery);
                        }
                        catch (SqlException)
                        {
                            lblStatus.Text = "Medicamento Duplicado";
                            recetaQuery =
                                string.Format("DELETE PROYECTO_W.MedicamentoPorBonoFarmacia WHERE medxbonofar_bonofarm_cod = {0}",
                                cbxBonosFarmacia.Text);
                            sqlConn.ejecutarQuery(recetaQuery);
                            return;
                        }
                    }


                    recetaQuery =
                        string.Format("UPDATE PROYECTO_W.BonoFarmacia SET bonofarm_estado = 'U' WHERE bonofarm_cod = {0}",
                        cbxBonosFarmacia.Text);
                    sqlConn.ejecutarQuery(recetaQuery);
                    // SI TODO LO DE ANTES SALIO BIEN, llega hasta aca
                    //  ES MOMENTO DE ASOCIARLO A UNA RECETA
                    //      SI RECETA ES CERO, HAY QUE INSERTAR UNA RECETA Y ASOCIARLA A UN TURNO
                    if (receta_cod == 0)
                    {
                        recetaQuery =
                            string.Format("INSERT INTO PROYECTO_W.Receta (receta_fecha_prescripcion) VALUES ((SELECT PROYECTO_W.F_FECHA_CONFIG()))");
                        sqlConn.ejecutarQuery(recetaQuery);
                        recetaQuery =
                            string.Format("SELECT TOP 1 receta_cod FROM PROYECTO_W.Receta ORDER BY receta_cod DESC");
                        DataTable dataReceta = sqlConn.ejecutarQuery(recetaQuery);
                        receta_cod = Convert.ToUInt32(dataReceta.Rows[0][0].ToString());
                        /*
                         * hay que meter receta al turno}
                         * hay que poner en el coso de registro resultado, que si ya existe y todo, no hace nada
                         * */
                        recetaQuery =
                            string.Format("UPDATE PROYECTO_W.TurnoConcretado SET turconcr_receta_cod = {0} WHERE turconcr_turno_nro = {1}",
                            receta_cod, turno_nro);
                        sqlConn.ejecutarQuery(recetaQuery);
                    }
                    //ahora ponermos en bono por receta
                    recetaQuery =
                        string.Format("INSERT INTO PROYECTO_W.BonoPorReceta(bonoxreceta_receta_cod,bonoxreceta_bonofarm_cod) VALUES ({0},{1})",
                        receta_cod, cbxBonosFarmacia.Text);
                    sqlConn.ejecutarQuery(recetaQuery);

                    // FINALIZA OK TODO
                    lblStatus.Text = "INGRESO CORRECTO";
                    recargarListaBonos(cbxBonosFarmacia);
                }
                else
                {// NO EXISTE MAS EL BONO ESE,, QUE VUELVA A CARGAR
                    lblStatus.Text = "VUELVA A ELEGIR BONO";
                    recargarListaBonos(cbxBonosFarmacia);
                }
            }
            else
            {
                lblStatus.Text = "Debe elegir Bono";
            }
        }

        private void gridX_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




    }
}
