using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //загрузка формы по центру экрана

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demkaDataSet.Zakaz". При необходимости она может быть перемещена или удалена.
            this.zakazTableAdapter.Fill(this.demkaDataSet.Zakaz);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demkaDataSet.Sotr". При необходимости она может быть перемещена или удалена.
            this.sotrTableAdapter.Fill(this.demkaDataSet.Sotr);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.zakazTableAdapter.Fill(this.demkaDataSet.Zakaz);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demkaDataSet.Sotr". При необходимости она может быть перемещена или удалена.
            this.sotrTableAdapter.Fill(this.demkaDataSet.Sotr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdForm updForm = new UpdForm();
            updForm.Show();

        }
    }
}
