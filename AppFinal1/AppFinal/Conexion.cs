using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;



namespace AppFinal1
{
    class Conexion
    {
        SqlConnection cn = new SqlConnection("Data Source=RECEPCION-PC;Initial Catalog=Prueba;Integrated Security=True");
        private SqlCommand cmd;
        private SqlCommandBuilder cmb;
        private DataSet ds;
        private SqlDataAdapter da;
        private DataTable dt;
        private UniqueConstraint uc;

         public int login (string usuario, string pass)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("spLogin", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("pass", pass);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return dr.GetInt32(0);
                }



            }
            
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                cn.Close();
            }

            return -1;

        }

        public bool conectar()
        {
            bool conectado = false;

            try
            {
                cn.Open();
                conectado = true;
                MessageBox.Show("Conectado");

            }
            catch (SqlException ex)
            {
                conectado = false;
                MessageBox.Show("No se conecto con la base de datos: " + ex.ToString());
            }
            finally
            {
                cn.Close();
            }
            return conectado;
        }

        public bool  agregar(string consulta)
        {

            bool guardado = false;
            int rows = 0;

            cn.Open();
            cmd = new SqlCommand(consulta, cn);
            rows = cmd.ExecuteNonQuery();

            if (rows > 0)
            {
                guardado = true;
            }

            cn.Close();
            return guardado;
        }

        public bool insertar(string consulta)
        {    //al querer colocar una letra me lanza error
            bool agregar = false;
            int rows = 0;

            cn.Open();
            cmd = new SqlCommand(consulta, cn);
            rows = cmd.ExecuteNonQuery();

            if (rows > 0)
            {
                agregar = true;
            }

            cn.Close();
            return agregar;

        }

        public bool eliminar(string consulta)
        {
            bool eliminado = false;
            int rows = 0;

            cn.Open();
            cmd = new SqlCommand(consulta, cn);
            rows = cmd.ExecuteNonQuery();

            if (rows > 0)
            {
                eliminado = true;
            }

            cn.Close();
            return eliminado;
        }

        public bool actualizar(string consulta)
        {
            bool actualizar = false;
            int rows = 0;

            cn.Open();
            cmd = new SqlCommand(consulta, cn);
            rows = cmd.ExecuteNonQuery();

            if (rows > 0)
            {
                actualizar = true;
            }

            cn.Close();
            return actualizar;
        }

        public DataTable mostrar(string consulta)
        {
            cn.Open();
            cmd = new SqlCommand(consulta, cn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();

            da.Fill(dt);

            cn.Close();

            return dt;
        }

        public DataTable mostrarCódigo(string consulta)
        {
            cn.Open();
            cmd = new SqlCommand(consulta, cn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();

            da.Fill(dt);

            cn.Close();

            return dt;
        }




    }
    
}
