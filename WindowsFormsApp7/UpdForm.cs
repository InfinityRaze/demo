using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp7
{
    public partial class UpdForm : Form
    {
        private const string connectionString = "Data Source = DESKTOP-RJGLL1R\\SQLEXPRESS; Initial catalog=demka; Integrated Security=true";

        public UpdForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //загрузка формы по центру экрана

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var surname = textBox1.Text;
                var firstname = textBox2.Text;
                var patronymic = textBox3.Text;                          
                var status = textBox4.Text;
                var login = textBox10.Text;
                var password = textBox9.Text;
                var role = textBox11.Text;

                string query = $"INSERT INTO Sotr(surname,firstname,patronymic,status) VALUES ('{surname}', '{firstname}', '{patronymic}', '{status}');" +
                    $"INSERT INTO Users(Username,Password,Role) VALUES ('{login}', '{password}', '{role}')";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery(); // выполнить команду на языке SQL

            }
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var surname = textBox8.Text;
                var firstname = textBox7.Text;
                var patronymic = textBox6.Text;
                var status = textBox5.Text;
                string query = $"update Sotr set status = '{status}' where surname = '{surname}'";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery(); // выполнить команду на языке SQL

            }

            this.Close();
        }
    }
}
