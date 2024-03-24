using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen_2_Progra
{
    public partial class ReporteFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) //page load es la pagina en el cual el usuario podra ver los datos de la tabla del gridview
        {
            LlenarGrid();
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Formulario"].ConnectionString; //mi connection string se llama formulario sacado de mi base de datos
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Encuesta")) // cual es seleccionado de la tabla encuesta
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind(); // refrescar la tabla
                        }
                    }
                }
            }
        }

        protected void bAceptar_Click(object sender, EventArgs e) // el boton de aceptar para poder borrar algun formulario no deseado
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["Formulario"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand("DELETE Encuesta WHERE NumeroEncuesta = '" + tNumEncuesta.Text + "'", conexion); //borrar datos de la tabla encuesta en donde es seleccionado el numero de encuesta para poder borrar
            comando.ExecuteNonQuery();
            conexion.Close();
            LlenarGrid();
        }
    }
}