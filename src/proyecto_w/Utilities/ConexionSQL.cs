using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace proyecto_w.Utilities.Conexion
{
    public class ConexionSQL
    {
        static ConexionSQL instance = null;

        private SqlConnection conn;

        private SqlConnection Conn
        {
            get { return this.conn; }
            set { this.conn = value; }
        }

        private string error;
        public string Error
        {
            get { return this.error; }
            set { this.error = value; }
        }

        public ConexionSQL()
        {
            //string strConn = "user id=gd;" +
            //                    "password=gd2013;" +
            //                    "server=.\\SQLSERVER2008;" +
            //                    "Trusted_Connection=yes;" +
            //                    "database=GD2C2013;";

            this.Conn = new SqlConnection(arch_config.Default.strConn);
            this.Conn.Open();
        }

        public static ConexionSQL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConexionSQL();
                }
                return instance;
            }
        }

        public bool ejecutarEscalar(SqlCommand cmd)
        {
            cmd.Connection = this.Conn;
            if (cmd.ExecuteScalar() != null)
                return true;
            else
                return false;

        }

        public DataTable ejecutarQuery(string query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 800;

            cmd.Connection = this.Conn;
            cmd.CommandText = query;

            // Usaremos un DataAdapter para leer los datos
            SqlDataAdapter da = new SqlDataAdapter(query, this.Conn);
            // El resultado lo guardaremos en una tabla
            DataTable tabla = new DataTable();
            tabla.Locale = System.Globalization.CultureInfo.InvariantCulture;
            // Llenamos la tabla con los datos leídos
            da.Fill(tabla);

            return tabla;
        }

        public DataTable ejecutarQueryConSP(SqlCommand cmd)
        {
            cmd.Connection = this.Conn;

            // El resultado lo guardaremos en una tabla
            DataTable tabla = new DataTable();
            // Usaremos un DataAdapter para leer los datos
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // Llenamos la tabla con los datos leídos
            da.Fill(tabla);

            cmd.Dispose();
            cmd = null;

            return tabla;
        }

        public void ejecutarSP(SqlCommand cmd)
        {
            cmd.Connection = this.Conn;

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            cmd = null;
        }

        public string ejecutarEscalarString(SqlCommand cmd)
        {

            cmd.Connection = this.Conn;


            return cmd.ExecuteScalar().ToString();
        }

        public int ejecutarEscalarInt(SqlCommand cmd)
        {

            cmd.Connection = this.Conn;


            return Convert.ToInt32( cmd.ExecuteScalar() );
        }


    }
}
