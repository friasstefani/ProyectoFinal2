using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL {
    public class Conexion { 

        public DataSet ds = new DataSet();
        public SqlDataAdapter da = new SqlDataAdapter();
        public SqlCommandBuilder cmd = new SqlCommandBuilder();

        public static SqlConnection con = new SqlConnection("Data Source=SQL5007.Smarterasp.net;Initial Catalog=DB_9CF3ED_ProdDominicanos;User Id=DB_9CF3ED_ProdDominicanos_admin;Password=ProdDominicanos123;");

        //public static SqlConnection con = new SqlConnection(@"Data Source=SERVIDOR\SQLEXPRESS;Initial Catalog=LETTUCE;Integrated Security=True");
       

        public bool EjecutarDB(string Codigo) {
            bool mensaje = false;
            SqlCommand cmd = new SqlCommand();



            try {
                con.Open(); // abrimos la conexion
                //MessageBox.Show("Conexion abierta");

                cmd.Connection = con; //asignamos la conexion
                cmd.CommandText = Codigo;     //asignamos el comando
                cmd.ExecuteNonQuery(); // ejecutamos el comando

            } catch (Exception) {
                throw;
            } finally {
                mensaje = true;
                con.Close(); //cerramos la conexion
                // MessageBox.Show("Conexion cerrada");

            }
            return mensaje;
        }
        /// <summary>
        /// para buscar datos en la base de datos
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        public DataTable BuscarDb(string comando) {
            SqlDataAdapter adp;
            DataTable dt = new DataTable();
            try {
                con.Open(); // abrimos la conexion
                adp = new SqlDataAdapter(comando, con);

                adp.Fill(dt);
            } catch (Exception) {
                con.Close();
            } finally {
                con.Close(); //cerramos la conexion

            }
            return dt;
        }

        public void Consultar(string sql, string tabla) {
            ds.Tables.Clear();
            da = new SqlDataAdapter(sql, con);
            cmd = new SqlCommandBuilder(da);
            da.Fill(ds, tabla);
        }

        public object GetDbValue(String Query) {
            try {
                con.Close();

                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                object returnValue;
                returnValue = cmd.ExecuteScalar();
                con.Close();
                return returnValue;
            } catch (SqlException ex) {
                Console.Write(ex.Message);
                return "El usuario que intenta crear ya existe";
            }
        }

    }

}

