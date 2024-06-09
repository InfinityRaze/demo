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

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        private const string connectionString = "Data Source = DESKTOP-RJGLL1R\\SQLEXPRESS; Initial catalog=demka; Integrated Security=true";
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //загрузка формы по центру экрана

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (AuthenticateUser(username, password))
            {
                string role = GetRoleFromDatabase(username);
                OpenFormBasedOnRole(role);
            }
            else
            {
                MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Warning);  //вывод сообщения о том что такого пользователя не существует
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private string GetRoleFromDatabase(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Role FROM Users WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                return (string)command.ExecuteScalar();
            }
        }

        private void OpenFormBasedOnRole(string role)
        {
            if (role.ToLower() == "admin")
            {
                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);  //выовд сообщения на экран о выполнении
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
                this.Hide();
            }
            else if (role.ToLower() == "cook")
            {
                CookForm cookForm = new CookForm();
                cookForm.Show();
                this.Hide();
            }
            else if (role.ToLower() == "waiter")
            {
                WaiterForm waiterForm = new WaiterForm();
                waiterForm.Show();
                this.Hide();
            }
        }
    }
}
