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
    public partial class Form2 : Form

    {
        string connectionString = @"Data Source=(localdb)\senati;Initial Catalog=login;Integrated Security=True;";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string pregunta = "";
            string query = "SELECT pregunta_seguridad FROM registro WHERE nombre = @nombre , @correo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", textBox2);

                    try
                    {
                        connection.Open();
                        pregunta = (string)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al obtener la pregunta de seguridad: " + ex.Message);
                    }
                }
            }

            return ;
        }
    }
}
