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
    public partial class WorkingWithProducts : Form
    {
        string connectionString;

        public WorkingWithProducts(string connect)
        {
            InitializeComponent();

            connectionString = connect;

            dataGridViewProducts.ColumnCount = 5;
            dataGridViewProducts.Columns[0].Name = "Артикул";
            dataGridViewProducts.Columns[1].Name = "Название";
            dataGridViewProducts.Columns[2].Name = "Категория";
            dataGridViewProducts.Columns[3].Name = "Ед. измерения";
            dataGridViewProducts.Columns[4].Name = "Цена";

            dataGridViewProducts.Columns[0].Width = 100;
            dataGridViewProducts.Columns[1].Width = 100;
            dataGridViewProducts.Columns[2].Width = 100;
            dataGridViewProducts.Columns[3].Width = 100;
            dataGridViewProducts.Columns[4].Width = 100;

            GetCategories();
            UpdateProducts();
            
        }



        public void UpdateProducts()
        {
            dataGridViewProducts.Rows.Clear();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.OneProduct", connection);
                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    dataGridViewProducts.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                }
                
            }

        }

        private void GetCategories()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Categories", connection);
                var reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        comboBoxCategory.Items.Add(Convert.ToString(reader.GetString(0)));
                    }

                }
                else
                {
                    MessageBox.Show("Нет категорий. Создайте категорию и повторите попытку.");
                    MainForm mf = (MainForm)this.Owner;
                    mf.Enabled = true;
                    this.Close();
                }


            }
        }

        private void WorkingWithProducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = (MainForm)this.Owner;
            mf.Enabled = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int id = 0;
            string name;
            string category;
            string measuring;
            int price = 0;

            bool success = int.TryParse(textBoxId.Text, out int result);
            if (success && result.ToString().Length <= 10)
            {
                id = result;
            }
            else
            {
                MessageBox.Show("Введите коректное значение артикула");
                textBoxId.Text = "";
                return;
            }

            if(string.IsNullOrEmpty(textBoxName.Text) || textBoxName.Text.Length > 20)
            {
                MessageBox.Show("Введите корректное значение имени");
                textBoxName.Text = "";
                return;
            }
            else
            {
                name = textBoxName.Text;
            }

            if(comboBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите категорию");
                return;
            }
            else
            {
                category = comboBoxCategory.SelectedItem.ToString();
            }

            if (string.IsNullOrEmpty(textBoxMeasuring.Text) || textBoxMeasuring.Text.Length > 20)
            {
                MessageBox.Show("Введите корректное значение еденицы измерения");
                textBoxMeasuring.Text = "";
                return;
            }
            else
            {
                measuring = textBoxMeasuring.Text;
            }

            success = int.TryParse(textBoxPrice.Text, out int result1);
            if (success)
            {
                price = result1;
            }
            else
            {
                MessageBox.Show("Введите коректное значение цены");
                textBoxPrice.Text = "";
                return;
            }

            int temp;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT Id FROM dbo.OneProduct", connection);
                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    temp = Convert.ToInt32(reader.GetInt32(0));
                    if(temp == id)
                    {
                        MessageBox.Show("Товар с таким артикулом уже сужествует");
                        textBoxId.Text = "";
                        return;
                    }
                }
                reader.Close();

                command.CommandText = "INSERT INTO dbo.OneProduct VALUES (@id, @name, @category, @measuring, @price)";
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@category", category);
                command.Parameters.AddWithValue("@measuring", measuring);
                command.Parameters.AddWithValue("@price", price);

                command.ExecuteNonQuery();
            }
            MessageBox.Show("Товар добавлен");

            textBoxName.Text = "";
            textBoxId.Text = "";
            textBoxMeasuring.Text = "";
            textBoxPrice.Text = "";
            comboBoxCategory.SelectedIndex = -1;

            UpdateProducts();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.Rows.Count != 0)
            {
                string id = dataGridViewProducts.CurrentRow.Cells[0].Value.ToString();

                string sqlCommand = "DELETE FROM dbo.OneProduct WHERE Id = " + id;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlCommand, connection);
                    command.ExecuteNonQuery();

                }
                UpdateProducts();
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
