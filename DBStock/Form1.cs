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
    public partial class MainForm : Form
    {
        string connectionString;

        public MainForm(string connect)
        {

            InitializeComponent();
            connectionString = connect;

            dataGridViewProducts.ColumnCount = 7;
            dataGridViewProducts.Columns[0].Name = "Артикул";
            dataGridViewProducts.Columns[1].Name = "Наименование";
            dataGridViewProducts.Columns[2].Name = "Категория";
            dataGridViewProducts.Columns[3].Name = "Ед. измерения";
            dataGridViewProducts.Columns[4].Name = "Цена";
            dataGridViewProducts.Columns[5].Name = "Количество";
            dataGridViewProducts.Columns[6].Name = "Общая стоимость";                    

            if (!IfProductsEmpty())
            {
                trackBar1.Minimum = 0;
                trackBar1.Maximum = this.GetMaxprice();

                trackBar2.Maximum = 0;
                trackBar2.Maximum = this.GetMaxAmount();

                
            }
            else
            {
                trackBar1.Maximum = 0;
                trackBar2.Maximum = 0;
            }
            GetCategories();
            
            comboBoxCategory.SelectedIndex = 0;
            UpdateProducts();
            HelperClass hc = new HelperClass(connectionString);
            label4.Text = hc.StockCongestion();

            
        }

        private void категориюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkingWithCategories wc = new WorkingWithCategories(connectionString);
            wc.Owner = this;
            this.Enabled = false;
            wc.Show();
        }

        private void товарToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.CheckIfCategoriesEmpty())
            {
                WorkingWithProducts wp = new WorkingWithProducts(connectionString);
                wp.Owner = this;
                this.Enabled = false;
                wp.Show();
            }
            else
            {
                MessageBox.Show("Нет категорий. Создайте категорию и повторите попытку.");
            }
        }
        private void UpdateProducts()
        {
            dataGridViewProducts.Rows.Clear();

            string selectedItem = comboBoxCategory.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Products", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string category = reader.GetString(2);
                    int price = reader.GetInt32(4);
                    int amount = reader.GetInt32(5);
                    string name = reader.GetString(1).ToLower();

                    if (selectedItem == category || selectedItem == comboBoxCategory.Items[0].ToString())
                    {
                        if (price >= trackBar1.Value)
                        {
                            if (amount >= trackBar2.Value)
                            {
                                if(name.Contains(textBoxSearch.Text.ToLower()))
                                    dataGridViewProducts.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), price, amount, reader.GetInt32(6));
                            }
                        }
                    }
                }
                
            }

        }

        private void MainForm_EnabledChanged(object sender, EventArgs e)
        {
            trackBar1.Minimum = 0;
            trackBar1.Maximum = this.GetMaxprice();

            trackBar2.Maximum = 0;
            trackBar2.Maximum = this.GetMaxAmount();

            UpdateProducts();

            HelperClass hc = new HelperClass(connectionString);

            label4.Text = hc.StockCongestion();
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddToStock ads = new AddToStock(connectionString);
            ads.Owner = this;
            this.Enabled = false;
            ads.Show();
        }

        private void списатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteFromStock dfs = new DeleteFromStock(connectionString);
            dfs.Owner = this;
            this.Enabled = false;
            dfs.Show();
        }

        private void историяИзмененийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryOfChanges hc = new HistoryOfChanges(connectionString);
            hc.Owner = this;
            this.Enabled = false;
            hc.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GetCategories()
        {

            comboBoxCategory.Items.Add("Все категории");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Categories", connection);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        comboBoxCategory.Items.Add(Convert.ToString(reader.GetString(0)));
                    }
                }
                else
                {
                    MessageBox.Show("Нет категорий. Создайте категорию и повторите попытку.");                 
                    //this.Close();

                    //WorkingWithCategories wc = new WorkingWithCategories();
                    //wc.Show();

                }


            }
        }

        private bool CheckIfCategoriesEmpty()
        {

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Categories", connection);
                var reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }

        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            label1.Text = "Товары, дороже 0 грн.";
            trackBar1.Minimum = 0;
            if (!this.IfProductsEmpty())
            {
                trackBar1.Maximum = this.GetMaxprice();
            }
            else
                trackBar1.Maximum = 0;

            trackBar2.Value = 0;
            label2.Text = "Товары, которых больше чем 0 штук";
            trackBar2.Maximum = 0;
            if (!this.IfProductsEmpty())
            {
                trackBar2.Maximum = this.GetMaxAmount();
            }
            else
                trackBar2.Maximum = 0;
            UpdateProducts();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            

            UpdateProducts();
            label1.Text = "Товары, дороже " + trackBar1.Value + " грн.";
        }

        private int GetMaxprice()
        {
            if (!this.IfProductsEmpty())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT MAX(Price) FROM dbo.Products", connection);
                    return Convert.ToInt32(command.ExecuteScalar());

                }
            }
            else return 0;
        }

        private int GetMaxAmount()
        {
            if (!this.IfProductsEmpty())
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT MAX(Amount) FROM dbo.Products", connection);
                    return Convert.ToInt32(command.ExecuteScalar());

                }
            }
            else return 0;
        }

        private bool IfProductsEmpty()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Products", connection);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                    return false;
                else
                    return true;

            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            UpdateProducts();
            label2.Text = "Товары, которых больше чем " + trackBar2.Value + " штук";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            UpdateProducts();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings st = new Settings(connectionString);
            st.Owner = this;
            this.Enabled = false;
            st.Show();
        }
    }


}
