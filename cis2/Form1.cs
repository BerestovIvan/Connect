using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace cis2
{
    public partial class Form1 : Form
    {
       
        string connectionString = "server=localhost;username=root;database=q;password=berest2008";
        string request = "select * from w";
        DataSet ds;
        MySqlDataAdapter adapter;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                adapter = new MySqlDataAdapter(request, connection);
                // Создаем объект Dataset
                ds = new DataSet();
                // Заполняем Dataset
                adapter.Fill(ds);
                // Отображаем данные
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter);
            adapter.Update(ds);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {            
            DataRow row = ds.Tables[0].NewRow(); // добавляем новую строку в DataTable
            ds.Tables[0].Rows.Add(row);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }
    }
}
