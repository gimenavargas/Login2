using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login2
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=(localdb)\senati;Initial Catalog=login;Integrated Security=True;";
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario2
            registro registro = new registro();

            // Mostrar el formulario2
            registro.Show();

            // Cerrar el formulario1
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtcontraseña.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string correo = txtcorreo.Text;
            string contraseña = txtcontraseña.Text;

            // Consulta SQL para verificar las credenciales del usuario
            string query = "SELECT COUNT(*) FROM registro WHERE correo = @correo AND contraseña = @contraseña";

            // Crear la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Asignar los parámetros de la consulta
                    command.Parameters.AddWithValue("@correo", correo);
                    command.Parameters.AddWithValue("@contraseña", contraseña);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();

                        // Si se encuentra una coincidencia, el usuario tiene credenciales válidas
                        if (count > 0)
                        {
                            // Permitir el acceso a la siguiente ventana o funcionalidad de la aplicación
                            MessageBox.Show("Inicio de sesión exitoso");
                            // Aquí puedes abrir la siguiente ventana o realizar cualquier otra acción necesaria
                            // Crear una instancia del formulario2
                            pagInicio pagInicio = new pagInicio();

                            // Mostrar el formulario2
                            pagInicio.Show();

                            // Cerrar el formulario1
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Credenciales incorrectas. Por favor, inténtalo de nuevo.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al iniciar sesión: " + ex.Message);
                    }
                }
            }
        }
    }
}
