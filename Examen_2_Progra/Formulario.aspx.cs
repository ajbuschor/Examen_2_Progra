using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace Examen_2_Progra
{
    public partial class Formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Generar y mostrar el número de encuesta solo si es la primera vez que se carga la página
                int numeroEncuesta = ObtenerProximoNumeroEncuesta();
                lblNumeroEncuesta.Text = numeroEncuesta.ToString();
            }
        }
        protected int ObtenerProximoNumeroEncuesta()
        {
           
            string connectionString = ConfigurationManager.ConnectionStrings["Formulario"].ConnectionString;

            // Consulta SQL para obtener el proximo numero de encuesta
            string query = "SELECT ISNULL(MAX(NumeroEncuesta), 0) + 1 FROM Encuesta";

   
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    // Si hay un resultado, devolver el proximo numero de siguiente encuesta
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }

            // Si no se puede obtener el proximo numero de encuesta, devolver 1
            return 1;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Verificar que todos los campos estén completos
            if (string.IsNullOrEmpty(tNombre.Text) || string.IsNullOrEmpty(tApellido.Text) || string.IsNullOrEmpty(tFechaNac.Text) || string.IsNullOrEmpty(tEdad.Text) || string.IsNullOrEmpty(tCorreo.Text))
            {
                MostrarAlerta("Por favor complete todos los campos.");
                return;
            }

            // Verificar que la edad esté dentro del rango permitido
            int edad;
            if (!int.TryParse(tEdad.Text, out edad) || edad < 18 || edad > 50)
            {
                MostrarAlerta("La edad debe estar entre 18 y 50 años sino, no se guardara el formulario.");
                return;
            }

            // Convertir el valor del DropDownList para que coincida con el tipo de datos en la base de datos
            string carroPropio = dCarro.SelectedValue;
            if (carroPropio == "Si")
            {
                carroPropio = "Sí";
            }
            else if (carroPropio == "No")
            {
                carroPropio = "No";
            }

            // Realizar la inserción en la base de datos
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Formulario"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Encuesta VALUES('" + tNombre.Text + "', '" + tApellido.Text + "', '" + tFechaNac.Text + "','" + tEdad.Text + "', '" + tCorreo.Text + "','" + carroPropio + "')";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }

            // Llenar el GridView con los datos recién insertados
            LlenarGrid();

            MostrarAlerta("Encuesta guardada exitosamente!!!");
        }
        private void MostrarAlerta(string mensaje) //muestra una alerta si algo fue ingresado incorrectamente
        {
            string script = $"alert('{mensaje}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "alertScript", script, true);
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Formulario"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Encuesta")) //llena los datos del formulario en la tabla de la base de datos "Encuesta"
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable()) ;
        
                    }
                }
            }
        }


    }
}
