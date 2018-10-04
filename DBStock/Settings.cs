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
    public partial class Settings : Form
    {
        string connectionString;

        public Settings(string connect)
        {
            InitializeComponent();
            connectionString = connect;
        }

        private void buttonPath_Click(object sender, EventArgs e)
        {
            if(textBoxPath.Text == "")
            {
                MessageBox.Show("Заполните поле.");
                return;
            }

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE dbo.Setting SET FilePath = @path WHERE Id = 0", connection);
                command.Parameters.AddWithValue("@path", textBoxPath.Text);
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Путь обновлен");
            textBoxPath.Text = "";

        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = (MainForm)this.Owner;
            mf.Enabled = true;
        }

        private void buttonSetCapacity_Click(object sender, EventArgs e)
        {
            if (textBoxCapacity.Text == "")
            {
                MessageBox.Show("Заполните поле.");
                return;
            }

            double capacity = 0;

            try
            {
                capacity = Convert.ToDouble(textBoxCapacity.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("Неверный формат обьема");
                textBoxCapacity.Text = "";
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE dbo.Setting SET StockCapacity = @capacity WHERE Id = 0", connection);
                command.Parameters.AddWithValue("@capacity", capacity);
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Обьем обновлен");
            textBoxPath.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pass = "";
            if(textBoxPass.Text == "")
            {
                MessageBox.Show("Заполните поле пароля");
                return;
            }
            else
            {
                pass = textBoxPass.Text;
            }

            using(SqlConnection connection  = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE dbo.Setting SET Pass = @pass WHERE Id = 0", connection);

                command.Parameters.AddWithValue("@pass", pass);
                command.ExecuteNonQuery();

            }
            MessageBox.Show("Пароль изменен");
            textBoxPass.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCapacity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
