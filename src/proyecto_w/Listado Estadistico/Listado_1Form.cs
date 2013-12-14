using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;

namespace proyecto_w.Listado_Estadistico
{
    public partial class ListadoForm : Form
    {
        public ListadoForm(string semestre, string año, int listado)
        {
            InitializeComponent();
            ConexionSQL conn = new ConexionSQL();
            string query;
            switch (listado)
            {
                case 1:
                    if (semestre == "1")
                    {
                        query = string.Format("SELECT TOP 5 ESP.esp_descripcion as Especialidad, ESP.esp_cod as Cod_Especialidad, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 1 THEN 1 ELSE 0 END) AS Cant_Enero, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 2 THEN 1 ELSE 0 END) AS Cant_Febrero, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 3 THEN 1 ELSE 0 END) AS Cant_Marzo, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 4 THEN 1 ELSE 0 END) AS Cant_Abril, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 5 THEN 1 ELSE 0 END) AS Cant_Mayo, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 6 THEN 1 ELSE 0 END) AS Cant_Junio");
                        query += string.Format(" FROM PROYECTO_W.TurnoCancelacion AS TURNCAN JOIN PROYECTO_W.Turno AS TURN ON TURNCAN.turcan_turno_nro = TURN.turno_nro JOIN PROYECTO_W.Especialidad AS ESP ON ESP.esp_cod = TURN.turno_esp_cod");
                        query += string.Format(" WHERE YEAR(TURN.turno_fecha) = {0} AND MONTH(TURN.turno_fecha) >= 1 AND MONTH(TURN.turno_fecha) <= 6", año);
                        query += string.Format(" GROUP BY ESP.esp_cod, ESP.esp_descripcion");
                        query += string.Format(" ORDER BY COUNT(*) DESC");
                    }
                    else
                    {
                        query = string.Format("SELECT TOP 5 ESP.esp_descripcion as Especialidad, ESP.esp_cod as Cod_Especialidad, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 7 THEN 1 ELSE 0 END) AS Cant_Julio, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 8 THEN 1 ELSE 0 END) AS Cant_Agosto, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 9 THEN 1 ELSE 0 END) AS Cant_Septiembre, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 10 THEN 1 ELSE 0 END) AS Cant_Octubre, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 11 THEN 1 ELSE 0 END) AS Cant_Noviembre, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 12 THEN 1 ELSE 0 END) AS Cant_Diciembre");
                        query += string.Format(" FROM PROYECTO_W.TurnoCancelacion AS TURNCAN JOIN PROYECTO_W.Turno AS TURN ON TURNCAN.turcan_turno_nro = TURN.turno_nro JOIN PROYECTO_W.Especialidad AS ESP ON ESP.esp_cod = TURN.turno_esp_cod");
                        query += string.Format(" WHERE YEAR(TURN.turno_fecha) = {0} AND MONTH(TURN.turno_fecha) >= 7 AND MONTH(TURN.turno_fecha) <= 12", año);
                        query += string.Format(" GROUP BY ESP.esp_cod, ESP.esp_descripcion");
                        query += string.Format(" ORDER BY COUNT(*) DESC");

                    }
                    grdListado1.DataSource = conn.ejecutarQuery(query);
                    break;
                case 2:
                    if (semestre == "1")
                    {
                        query = string.Format("DECLARE @FECHA DATETIME");
                        query += string.Format(" SET @FECHA = PROYECTO_W.F_FECHA_CONFIG()");
                        query += string.Format(" SELECT TOP 5 AFIL.afil_nro AS Nro_Afil, afil_apellido + ', ' + afil_nombre AS Nom_Y_Apell, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 1 THEN 1 ELSE 0 END) AS Cant_Enero, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 2 THEN 1 ELSE 0 END) AS Cant_Febrero, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 3 THEN 1 ELSE 0 END) AS Cant_Marzo, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 4 THEN 1 ELSE 0 END) AS Cant_Abril, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 5 THEN 1 ELSE 0 END) AS Cant_Mayo, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 6 THEN 1 ELSE 0 END) AS Cant_Junio");
                        query += string.Format(" FROM PROYECTO_W.BonoFarmacia AS BONOFARM JOIN PROYECTO_W.BonoAdquirido AS BONOADQ ON BONOFARM.bonofarm_bonadq_cod = BONOADQ.bonadq_cod JOIN PROYECTO_W.Afiliado AS AFIL ON AFIL.afil_nro = BONOADQ.bonadq_afil_nro");
                        query += string.Format(" WHERE BONOFARM.bonofarm_cod NOT IN (SELECT bonoxreceta_bonofarm_cod FROM PROYECTO_W.BonoPorReceta) AND BONOFARM.bonofarm_fecha_venc < @FECHA AND MONTH(BONOFARM.bonofarm_fecha_venc) >= 1 AND MONTH(BONOFARM.bonofarm_fecha_venc) <= 6 AND YEAR(BONOFARM.bonofarm_fecha_venc) = {0}", año);
                        query += string.Format(" GROUP BY AFIL.afil_nro, AFIL.afil_nombre, AFIL.afil_apellido");
                        query += string.Format(" ORDER BY COUNT(*) DESC");
                    }
                    else
                    {
                        query = string.Format("DECLARE @FECHA DATETIME");
                        query += string.Format(" SET @FECHA = PROYECTO_W.F_FECHA_CONFIG()");
                        query += string.Format(" SELECT TOP 5 AFIL.afil_nro AS Nro_Afil, afil_apellido + ', ' + afil_nombre AS Nom_Y_Apell, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 7 THEN 1 ELSE 0 END) AS Cant_Julio, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 8 THEN 1 ELSE 0 END) AS Cant_Agosto, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 9 THEN 1 ELSE 0 END) AS Cant_Septiembre, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 10 THEN 1 ELSE 0 END) AS Cant_Octubre, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 11 THEN 1 ELSE 0 END) AS Cant_Noviembre, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 12 THEN 1 ELSE 0 END) AS Cant_Diciembre");
                        query += string.Format(" FROM PROYECTO_W.BonoFarmacia AS BONOFARM JOIN PROYECTO_W.BonoAdquirido AS BONOADQ ON BONOFARM.bonofarm_bonadq_cod = BONOADQ.bonadq_cod JOIN PROYECTO_W.Afiliado AS AFIL ON AFIL.afil_nro = BONOADQ.bonadq_afil_nro");
                        query += string.Format(" WHERE BONOFARM.bonofarm_cod NOT IN (SELECT bonoxreceta_bonofarm_cod FROM PROYECTO_W.BonoPorReceta) AND BONOFARM.bonofarm_fecha_venc < @FECHA AND MONTH(BONOFARM.bonofarm_fecha_venc) >= 7 AND MONTH(BONOFARM.bonofarm_fecha_venc) <= 12 AND YEAR(BONOFARM.bonofarm_fecha_venc) = {0}", año);
                        query += string.Format(" GROUP BY AFIL.afil_nro, AFIL.afil_nombre, AFIL.afil_apellido");
                        query += string.Format(" ORDER BY COUNT(*) DESC");
                    }
                grdListado1.DataSource = conn.ejecutarQuery(query);
                break;
                case 3:
                if (semestre == "1")
                {
                    query = string.Format("SELECT TOP 5 ESP.esp_descripcion AS Especialidad, ESP.esp_cod AS Cod_Especialidad, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 1 THEN 1 ELSE 0 END) AS Cant_Enero, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 2 THEN 1 ELSE 0 END) AS Cant_Febrero, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 3 THEN 1 ELSE 0 END) AS Cant_Marzo, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 4 THEN 1 ELSE 0 END) AS Cant_Abril, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 5 THEN 1 ELSE 0 END) AS Cant_Mayo, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 6 THEN 1 ELSE 0 END) AS Cant_Junio");
                    query += string.Format(" FROM PROYECTO_W.TurnoConcretado AS TURNCON JOIN PROYECTO_W.Turno AS TURN ON TURNCON.turconcr_turno_nro = TURN.turno_nro JOIN PROYECTO_W.Especialidad AS ESP ON TURN.turno_esp_cod = ESP.esp_cod JOIN PROYECTO_W.BonoPorReceta ON TURNCON.turconcr_receta_cod = bonoxreceta_receta_cod");
                    query += string.Format(" WHERE TURNCON.turconcr_receta_cod IS NOT NULL AND MONTH(TURN.turno_fecha) >= 1 AND MONTH(TURN.turno_fecha) <= 6 AND YEAR(TURN.turno_fecha) = {0}", año);
                    query += string.Format(" GROUP BY ESP.esp_cod, ESP.esp_descripcion");
                    query += string.Format(" ORDER BY COUNT(*) DESC");
                }
                else
                {
                    query = string.Format("SELECT TOP 5 ESP.esp_descripcion as Especialidad, ESP.esp_cod as Cod_Especialidad, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 7 THEN 1 ELSE 0 END) AS Cant_Julio, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 8 THEN 1 ELSE 0 END) AS Cant_Agosto, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 9 THEN 1 ELSE 0 END) AS Cant_Septiembre, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 10 THEN 1 ELSE 0 END) AS Cant_Octubre, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 11 THEN 1 ELSE 0 END) AS Cant_Noviembre, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 12 THEN 1 ELSE 0 END) AS Cant_Diciembre");
                    query += string.Format(" FROM PROYECTO_W.TurnoConcretado AS TURNCON JOIN PROYECTO_W.Turno AS TURN ON TURNCON.turconcr_turno_nro = TURN.turno_nro JOIN PROYECTO_W.Especialidad AS ESP ON TURN.turno_esp_cod = ESP.esp_cod JOIN PROYECTO_W.BonoPorReceta ON TURNCON.turconcr_receta_cod = bonoxreceta_receta_cod");
                    query += string.Format(" WHERE TURNCON.turconcr_receta_cod IS NOT NULL AND MONTH(TURN.turno_fecha) >= 7 AND MONTH(TURN.turno_fecha) <= 12 AND YEAR(TURN.turno_fecha) = {0}", año);
                    query += string.Format(" GROUP BY ESP.esp_cod, ESP.esp_descripcion");
                    query += string.Format(" ORDER BY COUNT(*) DESC");
                }
                grdListado1.DataSource = conn.ejecutarQuery(query);
                break;
                case 4:
                if (semestre == "1")
                {
                    query = string.Format("SELECT afil_nro AS Afil_Cod, afil_apellido + ', ' + afil_apellido AS Nom_Apell_Afil, SUM(CASE WHEN MONTH(turno_fecha) = 1 THEN 1 ELSE 0 END) AS Cant_Enero, SUM(CASE WHEN MONTH(turno_fecha) = 2 THEN 1 ELSE 0 END) AS Cant_Febrero, SUM(CASE WHEN MONTH(turno_fecha) = 3 THEN 1 ELSE 0 END) AS Cant_Marzo, SUM(CASE WHEN MONTH(turno_fecha) = 4 THEN 1 ELSE 0 END) AS Cant_Abril, SUM(CASE WHEN MONTH(turno_fecha) = 5 THEN 1 ELSE 0 END) AS Cant_Mayo, SUM(CASE WHEN MONTH(turno_fecha) = 6 THEN 1 ELSE 0 END) AS Cant_Junio");
                    query += string.Format(" FROM PROYECTO_W.V_LISTADO_4");
                    query += string.Format(" WHERE YEAR(turno_fecha) = {0} AND MONTH(turno_fecha) >= 1 AND MONTH(turno_fecha) <= 6", año);
                    query += string.Format(" GROUP BY afil_nro, afil_nombre, afil_apellido");
                    query += string.Format(" ORDER BY COUNT(*) DESC");
                }
                else
                {
                    query = string.Format("SELECT afil_nro AS Afil_Cod, afil_apellido + ', ' + afil_apellido AS Nom_Apell_Afil, SUM(CASE WHEN MONTH(turno_fecha) = 7 THEN 1 ELSE 0 END) AS Cant_Julio, SUM(CASE WHEN MONTH(turno_fecha) = 8 THEN 1 ELSE 0 END) AS Cant_Agosto, SUM(CASE WHEN MONTH(turno_fecha) = 9 THEN 1 ELSE 0 END) AS Cant_Septiembre, SUM(CASE WHEN MONTH(turno_fecha) = 10 THEN 1 ELSE 0 END) AS Cant_Octubre, SUM(CASE WHEN MONTH(turno_fecha) = 11 THEN 1 ELSE 0 END) AS Cant_Noviembre, SUM(CASE WHEN MONTH(turno_fecha) = 12 THEN 1 ELSE 0 END) AS Cant_Diciembre");
                    query += string.Format(" FROM PROYECTO_W.V_LISTADO_4");
                    query += string.Format(" WHERE YEAR(turno_fecha) = {0} AND MONTH(turno_fecha) >= 7 AND MONTH(turno_fecha) <= 12", año);
                    query += string.Format(" GROUP BY afil_nro, afil_nombre, afil_apellido");
                    query += string.Format(" ORDER BY COUNT(*) DESC");
                }
                grdListado1.DataSource = conn.ejecutarQuery(query);
                break;
            }
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
