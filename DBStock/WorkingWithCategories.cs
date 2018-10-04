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
    public partial class WorkingWithCategories : Form
    {
        string connectionString;

        public WorkingWithCategories(string connect)
        {
            InitializeComponent();
            connectionString = connect;
            dataGridViewCategories.ColumnCount = 2;
            dataGridViewCategories.Columns[0].Name = "Категория";
            dataGridViewCategories.Columns[1].Name = "Обьем, занимаемый категорией";

            UpdateCategories();
            
        }



        public void UpdateCategories()
        {
            dataGridViewCategories.Rows.Clear();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Categories", connection);
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    dataGridViewCategories.Rows.Add(reader.GetString(0), reader.GetDouble(1));
                }

            }

        }

        private void WorkingWithCategories_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = (MainForm)this.Owner;
            mf.Enabled = true;
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            string category = textBoxCategory.Text;
            double volume = 4;
            try
            {
                volume = Convert.ToDouble(textBoxV.Text);
            }
            catch(FormatException)
            {
                MessageBox.Show("Неверный формат обьема.");
                textBoxV.Text = "";
                return;
            }


            if(String.IsNullOrWhiteSpace(category) || category.Length > 15)
            {
                MessageBox.Show("Некоректное значение.");
                textBoxCategory.Text = "";
                return;
            }

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO dbo.Categories VALUES (@category, @volume)", connection);

                command.Parameters.AddWithValue("@category", category);
                command.Parameters.AddWithValue("@volume", volume);
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Категория добавлена");
            textBoxCategory.Text = "";
            UpdateCategories();
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(dataGridViewCategories.Rows.Count > 0)
            {
                string str = dataGridViewCategories.CurrentCell.Value.ToString();


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("DELETE FROM dbo.Categories WHERE CategoryName LIKE @str", connection);
                    command.Parameters.AddWithValue("@str", str);
                    command.ExecuteNonQuery();
                    
                }
                MessageBox.Show("Категория " + str + " удалена");

                UpdateCategories();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
