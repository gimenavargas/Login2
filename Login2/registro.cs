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
    public partial class registro : Form
    {
        string connectionString = @"Data Source=(localdb)\senati;Initial Catalog=login;Integrated Security=True;";


        public registro()
        {
            InitializeComponent();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            txtConfirmarContraseña.UseSystemPasswordChar = !checkBox2.Checked;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void registro_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Recoger los valores ingresados en el formulario
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;
            string contraseña = txtContraseña.Text;
            string confirmarContraseña = txtConfirmarContraseña.Text;

            // Crear la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear la consulta SQL para insertar los datos en la tabla
                    string query = "INSERT INTO registro (nombre, correo, contraseña, confirmar_contraseña) VALUES (@nombre, @correo, @contraseña, @confirmarContraseña)";

                    // Crear el comando SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Asignar los parámetros de la consulta
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@correo", correo);
                        command.Parameters.AddWithValue("@contraseña", contraseña);
                        command.Parameters.AddWithValue("@confirmarContraseña", confirmarContraseña);

                        // Ejecutar la consulta
                        command.ExecuteNonQuery();

                        // Mostrar un mensaje de éxito
                        MessageBox.Show("Datos guardados correctamente");
                    }
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje de error si ocurre una excepción
                    MessageBox.Show("Error al guardar los datos: " + ex.Message);
                }
            }
        }
    }
}
    

