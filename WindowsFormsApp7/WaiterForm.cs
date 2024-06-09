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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp7
{
    public partial class WaiterForm : Form
    {
        private const string connectionString = "Data Source = DESKTOP-RJGLL1R\\SQLEXPRESS; Initial catalog=demka; Integrated Security=true";
        int selectedRow;

        public WaiterForm()
        {
            InitializeComponent();
        }

        private void WaiterForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demkaDataSet.Zakaz". При необходимости она может быть перемещена или удалена.
            this.zakazTableAdapter.Fill(this.demkaDataSet.Zakaz);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var id = textBox1.Text;
                var position = textBox2.Text;
                var status = textBox3.Text;
                string query = $"INSERT INTO Zakaz(position,status) VALUES ('{position}', '{status}')";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery(); // выполнить команду на языке SQL
                this.zakazTableAdapter.Fill(this.demkaDataSet.Zakaz);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var id = textBox1.Text;
                var position = textBox2.Text;
                var status = textBox3.Text;
                string query = $"update Zakaz set position = '{position}', status = '{status}' where id_zakaz = '{id}'";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery(); // выполнить команду на языке SQL
                this.zakazTableAdapter.Fill(this.demkaDataSet.Zakaz);

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();

            }
        }
    }
}
