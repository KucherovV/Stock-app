
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
    public partial class DeleteFromStock : Form
    {
        List<int> prohibitedIndexes = new List<int>();
        List<string> commands = new List<string>();
        List<string> changes = new List<string>();
        List<OneProduct> listObj;
        string stringToSend = "Списано ";
        int totalSum = 0;

        string connectionString;

        public DeleteFromStock(string connect)
        {
            connectionString = connect;
            InitializeComponent();
            dataGridViewProducts.ColumnCount = 4;
            dataGridViewProducts.Columns[0].Name = "Название";
            dataGridViewProducts.Columns[1].Name = "Артикул";
            dataGridViewProducts.Columns[2].Name = "Цена";
            dataGridViewProducts.Columns[3].Name = "Остаток на складе";

            dataGridViewItems.ColumnCount = 7;
            dataGridViewItems.Columns[0].Name = "Артикул";
            dataGridViewItems.Columns[1].Name = "Название";
            dataGridViewItems.Columns[2].Name = "Категория";
            dataGridViewItems.Columns[3].Name = "Ед. измерения";
            dataGridViewItems.Columns[4].Name = "Цена";
            dataGridViewItems.Columns[5].Name = "Количество";
            dataGridViewItems.Columns[6].Name = "Сумма";

            dataGridViewItems.Columns[0].Width = 50;
            dataGridViewItems.Columns[1].Width = 120;
            dataGridViewItems.Columns[2].Width = 120;
            dataGridViewItems.Columns[3].Width = 120;
            dataGridViewItems.Columns[4].Width = 50;
            dataGridViewItems.Columns[5].Width = 70;
            dataGridViewItems.Columns[6].Width = 50;

            UpdateProducts();

            HelperClass hx = new HelperClass(connectionString);
            listObj = hx.GetProductList();

           
        }

        private void UpdateProducts()
        {
                     
            dataGridViewProducts.Rows.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Products", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridViewProducts.Rows.Add(reader.GetString(1), reader.GetInt32(0), reader.GetInt32(4), reader.GetInt32(5));
                }

            }
            
        }

        private void DeleteFromStock_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = (MainForm)this.Owner;
            mf.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxAmount.Text == "")
            {
                MessageBox.Show("Введите количество товара");
                return;
            }

            if (prohibitedIndexes.Contains(dataGridViewProducts.CurrentRow.Index))
            {
                MessageBox.Show("Этот товар уже добавлен.");
                return;
            }          

            if(Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[3].Value) < Convert.ToInt32(maskedTextBoxAmount.Text))
            {
                MessageBox.Show("На складе нет столько товара");
                return;
            }

            prohibitedIndexes.Add(dataGridViewProducts.CurrentRow.Index);

            CreateQuerry();
        }

        private void CreateQuerry()
        {
            HelperClass hc = new HelperClass(connectionString);

            List<OneProduct> list = hc.GetProductList();
            OneProduct product = new OneProduct();
            int currId = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[1].Value);

            foreach(var i in list)
            {
                if (i.Id == currId)
                    product = i;                  
            }

            int newAmount = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[3].Value) - Convert.ToInt32(maskedTextBoxAmount.Text);
            int sum = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[2].Value) * newAmount;
            string str = "";
            int amountAdd = Convert.ToInt32(maskedTextBoxAmount.Text);


            if (newAmount == 0)
            {
                str = "DELETE FROM dbo.Products WHERE Id = " + currId.ToString();
            }
            else
            {
                str = "UPDATE dbo.Products SET Amount = " + newAmount + ", Sum = " + sum + "WHERE Id = " + currId.ToString();
            }
            commands.Add(str);

            dataGridViewItems.Rows.Add(product.Id, product.Name, product.Category, product.Measuring, product.Price, amountAdd, Convert.ToInt32(maskedTextBoxAmount.Text) * product.Price);


            str = maskedTextBoxAmount.Text.Trim(' ');

            stringToSend += Convert.ToString(dataGridViewProducts.CurrentRow.Cells[0].Value) + "(x" + str + "), ";
            totalSum += Convert.ToInt32(maskedTextBoxAmount.Text) * Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[2].Value);

        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            if (commands.Count == 0)
                return;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                foreach (string i in commands)
                {
                    command.CommandText = i;
                    command.ExecuteNonQuery();
                }
            }

            DateTime datetime = DateTime.Now.ToLocalTime();
            HelperClass hc = new HelperClass(connectionString);

            hc.FixAction(false, datetime, stringToSend, totalSum, dataGridViewItems);
            hc.Print(datetime, dataGridViewItems, false, totalSum);

            MessageBox.Show("Наименования списаны");
            this.Close();

        }

        
    }
}
