using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBStock
{
    public partial class SetUp : Form
    {
        string connectionString;

        public SetUp(string connect)
        {
            InitializeComponent();
            connectionString = connect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxPass.Text != "" && textBoxPath.Text != "" && textBoxVolume.Text != "")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO dbo.Setting (Pass, FilePath, StockCapacity) VALUES (@pass, @path, @cap)", connection);
                    command.Parameters.AddWithValue("@pass", textBoxPass.Text);
                    command.Parameters.AddWithValue("@path", textBoxPath.Text);
                    command.Parameters.AddWithValue("@cap", textBoxVolume.Text);
                    command.ExecuteNonQuery();
                    
                }
                MessageBox.Show("Данные занесены");
                Application.Exit();

            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }

        }
    }
}
