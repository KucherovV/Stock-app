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
    public partial class AddToStock : Form
    {
        List<string> commands = new List<string>();
        List<int> prohibitedIndexes = new List<int>();

        
        List<OneProduct> listObj = new List<OneProduct>();
        List<OneProduct> listToSend = new List<OneProduct>();
        string stringToSend = "Добавлено ";
        int totalSum = 0;

        string connectionString;

        public AddToStock(string connect)
        {
            InitializeComponent();

            connectionString = connect;

            dataGridViewProducts.ColumnCount = 2;
            dataGridViewProducts.Columns[0].Name = "Товар";
            dataGridViewProducts.Columns[1].Name = "Артикул";
            

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

            HelperClass hc = new HelperClass(connectionString);

            listObj = hc.GetProductList();
            FillProductNames();
            
        }

        

        public void FillProductNames()
        {
            dataGridViewProducts.Rows.Clear();
            //List<OneProduct> listObj = this.GetProducts();

            for(int i = 0; i < listObj.Count; i++)
            {                
                dataGridViewProducts.Rows.Add(listObj[i].Name, listObj[i].Id);
            }

            
        }

        private void AddToStock_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = (MainForm)this.Owner;
            mf.Enabled = true;
        }

        private void buttonAddToCheck_Click(object sender, EventArgs e)
        {
            if(maskedTextBoxAmount.Text == "")
            {
                MessageBox.Show("Введите количество товара");
                return;
            }

            if (prohibitedIndexes.Contains(dataGridViewProducts.CurrentRow.Index))
            {
                MessageBox.Show("Этот товар уже добавлен.");
                return;
            }
            else
            {
                prohibitedIndexes.Add(dataGridViewProducts.CurrentRow.Index);
            }

            CreateQuerry();
        }

        private void CreateQuerry()
        {
            HelperClass hc = new HelperClass(connectionString);

            List<OneProduct> list = hc.GetProductList();
            OneProduct product = list[dataGridViewProducts.CurrentRow.Index];

            int id = product.Id;
            bool isInDb = false;
            int amountAdd = Convert.ToInt32(maskedTextBoxAmount.Text);
            int amountInDb = 0;
            int tempId = 0 ;

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Id, Amount FROM dbo.Products", connection);
                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    tempId = reader.GetInt32(0);

                    if(tempId == id)
                    {
                        isInDb = true;
                        amountInDb = reader.GetInt32(1);
                        break;
                    }
                }

                string str;

                if (isInDb)
                {
                    int amountTotal = amountInDb + amountAdd;
                    int sum = amountTotal * product.Price;

                    str = "UPDATE dbo.Products SET Amount = " + amountTotal.ToString() + ", Sum = " + sum.ToString() + " WHERE Id = " + tempId.ToString();
                }
                else
                {
                    str = "INSERT INTO dbo.Products VALUES ('" + product.Id + "', '" + product.Name + "', '" + product.Category + "', '" + product.Measuring + "', '" + product.Price + "', '" + amountAdd + "', '" + amountAdd * product.Price + "')";
                }

                commands.Add(str);

                dataGridViewItems.Rows.Add(product.Id, product.Name, product.Category, product.Measuring, product.Price, amountAdd, Convert.ToInt32(maskedTextBoxAmount.Text)*product.Price);

                stringToSend += product.Name + "(x" + amountAdd + "), ";
                totalSum += product.Price * amountAdd;

                
            }

        }     

        private void button1_Click(object sender, EventArgs e)
        {
            if (commands.Count == 0)
                return;

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection; 

                foreach(string i in commands)
                {
                    command.CommandText = i;
                    command.ExecuteNonQuery();
                }
            }

            DateTime datetime = DateTime.Now.ToLocalTime();

            HelperClass hc = new HelperClass(connectionString);

            hc.FixAction(true, datetime, stringToSend, totalSum, dataGridViewItems);
            hc.Print(datetime, dataGridViewItems, true, totalSum);

            MessageBox.Show("Наименования добавлены");
            this.Close();

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
