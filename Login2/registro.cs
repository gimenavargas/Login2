using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            txtContraseña.UseSystemPasswordChar = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            txtConfirmarContraseña.UseSystemPasswordChar = checkBox2.Checked;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void registro_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Restaurar el color de fondo predeterminado de todos los campos de texto
            txtNombre.BackColor = SystemColors.Window;
            txtCorreo.BackColor = SystemColors.Window;
            txtContraseña.BackColor = SystemColors.Window;
            txtConfirmarContraseña.BackColor = SystemColors.Window;

            // Recoger los valores ingresados en el formulario
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;
            string contraseña = txtContraseña.Text;
            string confirmarContraseña = txtConfirmarContraseña.Text;

            // Verificar si algún campo está vacío
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(contraseña) || string.IsNullOrWhiteSpace(confirmarContraseña))
            {
                MessageBox.Show("Por favor, completa todos los campos antes de registrar la información.");
                return; // Salir del método sin continuar con el proceso de guardado
            }

            // Verificar si el correo electrónico tiene el formato correcto
            string emailPattern = @"^[a-zA-Z0-9.]+@[a-zA-Z0-9.-].[a-zA-Z]{2,}";
            if (!Regex.IsMatch(correo, emailPattern))
            {
                MessageBox.Show("El correo electrónico no tiene un formato válido. Por favor, inténtalo de nuevo.");

                // Establecer el color de fondo del campo de correo electrónico en rojo
                txtCorreo.BackColor = Color.Red;
                return; // Salir del método sin continuar con el proceso de guardado
            }

            // Verificar si la longitud de la contraseña es válida (entre 8 y 12 caracteres)
            if (contraseña.Length < 6 || contraseña.Length > 10)
            {
                MessageBox.Show("La contraseña debe tener entre 6 y 10 caracteres. Por favor, inténtalo de nuevo.");

                // Establecer el color de fondo del campo de contraseña en rojo
                txtContraseña.BackColor = Color.Red;
                return; // Salir del método sin continuar con el proceso de guardado
            }

            // Verificar si las contraseñas coinciden
            if (contraseña != confirmarContraseña)
            {
                MessageBox.Show("Las contraseñas no coinciden. Por favor, inténtalo de nuevo.");

                // Establecer el color de fondo de los campos de contraseña en rojo
                txtContraseña.BackColor = Color.Red;
                txtConfirmarContraseña.BackColor = Color.Red;
                return; // Salir del método sin continuar con el proceso de guardado
            }


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

        private void button2_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario2
            Form1 Form1 = new Form1();

            // Mostrar el formulario2
            Form1.Show();

            // Cerrar el formulario1
            this.Hide();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    

