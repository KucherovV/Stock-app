using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace DBStock
{
    public partial class Login : Form
    {
        string connectionString;

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxServerName.Text != "")
            {
                try
                {
                    connectionString = @"Data Source = " + textBoxServerName.Text +";Initial Catalog = DBStock; Integrated Security=True";            
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("UPDATE dbo.Setting SET ServerName  = @name", connection);
                        command.Parameters.AddWithValue("@name", textBoxServerName.Text);
                        command.ExecuteNonQuery();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка");
                    return;
                }
            }
            else
                return;


            try
            {
                string pass = "";
             
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT Pass FROM dbo.Setting", connection);
                    var reader = command.ExecuteReader();
                    reader.Read();

                    pass = reader.GetString(0);
                }

                if (textBoxPass.Text == pass)
                {
                    MainForm mf = new MainForm(connectionString);
                    this.Visible = false;
                    mf.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Неправильный пароль!");
                    textBoxPass.Text = "";
                }
            }
            catch(Exception)
            {
               MessageBox.Show("Приложение не установлено. Заполните основные данные.");
                SetUp su = new SetUp(connectionString);
                su.ShowDialog();
                this.Close();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
