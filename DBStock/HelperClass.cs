using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using System.IO;
using System.Data;
using Newtonsoft.Json;

namespace DBStock
{
    class HelperClass
    {
        public string connectionString;

        public void FixAction(bool actionType, DateTime dateTime, string changes, int totalSum, DataGridView dgv)
        {
           List<DGVClass> list = new List<DGVClass>();

           for(int i = 0; i < dgv.Rows.Count; i++)
           {
                string id = dgv.Rows[i].Cells[0].Value.ToString();
                string name = dgv.Rows[i].Cells[1].Value.ToString();
                string category = dgv.Rows[i].Cells[2].Value.ToString();
                string measuring = dgv.Rows[i].Cells[3].Value.ToString();
                string price = dgv.Rows[i].Cells[4].Value.ToString();
                string amount = dgv.Rows[i].Cells[5].Value.ToString();
                string sum = dgv.Rows[i].Cells[6].Value.ToString();

                list.Add(new DGVClass(id, name, category, measuring, price, amount, sum));
           }

            string dgvString = JsonConvert.SerializeObject(list);
           
           using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO dbo.Actions VALUES (@type, @datetime, @listChanges, @sum, @dgv)", connection);
                command.Parameters.AddWithValue("@type", actionType);
                command.Parameters.AddWithValue("@datetime", dateTime);
                command.Parameters.AddWithValue("@listChanges", changes);
                command.Parameters.AddWithValue("@sum", totalSum);
                command.Parameters.AddWithValue("@dgv", dgvString);

                command.ExecuteNonQuery();

            }

        }

        public void Print(DateTime dateTime, DataGridView dgv, bool action, int sum)
        {
            HelperClass hc = new HelperClass(connectionString);
            string path = hc.GetPath();

            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(path + "/Report.pdf", FileMode.Create));
            doc.Open();

            BaseFont bf = BaseFont.CreateFont(@"consola.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font f = new iTextSharp.text.Font(bf, 8);

            if (action)
            {
                doc.Add(new Paragraph("Накладная на добавление товара на склад ", f));
            }
            else
            {
                doc.Add(new Paragraph("Накладная на списание товара на склада ", f));
            }

            doc.Add(new Paragraph(dateTime.ToString(), f));
            doc.Add(new Paragraph(" "));

            DataTable dt = new DataTable();

            foreach(DataGridViewColumn col in dgv.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach(DataGridViewRow row in dgv.Rows)
            {
                DataRow dtr = dt.NewRow();

                foreach (DataGridViewCell cell in row.Cells)
                {
                    dtr[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dtr);
            }

            PdfPTable pdfPTable = new PdfPTable(dt.Columns.Count);

            for(int i = 0; i < dt.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = BaseColor.GRAY;
                cell.AddElement(new Chunk(dgv.Columns[i].Name, f));
                pdfPTable.AddCell(cell);
            }

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                for(int j = 0; j < dt.Columns.Count; j++)
                {
                    Phrase p = new Phrase(dt.Rows[i][j].ToString(), f);
                    pdfPTable.AddCell(p);
                }
            }
         
            doc.Add(pdfPTable);
            doc.Add(new Paragraph("Сумма изменений = " + sum.ToString(), f));
            doc.Close();

        }

        public  string GetPath()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT FilePath from dbo.Setting", connection);
                var reader = command.ExecuteReader();

                reader.Read();

                return Convert.ToString(reader.GetString(0));
            }
        }

        public List<OneProduct> GetProductList()
        {
            List<OneProduct> list = new List<OneProduct>();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.OneProduct", connection);
                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    list.Add(new OneProduct(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4)));
                }

                return list;
            }


        }

        public DataGridView DeConvertDGV(string dgvString)
        {
            List<DGVClass> list = JsonConvert.DeserializeObject<List<DGVClass>>(dgvString);
            DataGridView dataGridView2 = new DataGridView();
            dataGridView2.ColumnCount = 7;
            dataGridView2.Columns[0].Name = "Артикул";
            dataGridView2.Columns[1].Name = "Название";
            dataGridView2.Columns[2].Name = "Категория";
            dataGridView2.Columns[3].Name = "Ед. измерения";
            dataGridView2.Columns[4].Name = "Цена";
            dataGridView2.Columns[5].Name = "Количество";
            dataGridView2.Columns[6].Name = "Сумма";

            dataGridView2.Columns[0].Width = 50;
            dataGridView2.Columns[1].Width = 120;
            dataGridView2.Columns[2].Width = 120;
            dataGridView2.Columns[3].Width = 120;
            dataGridView2.Columns[4].Width = 50;
            dataGridView2.Columns[5].Width = 70;
            dataGridView2.Columns[6].Width = 50;

            foreach (var i in list)
            {
                dataGridView2.Rows.Add(i.Id, i.Name, i.Category, i.Measuring, i.Price, i.Amount, i.Sum);
            }

            return dataGridView2;


        }

        public string StockCongestion()
        {
            double totalVolume = 0;
            var capacity = 1.4;
            double result;
            List<CetegoryClass> categories = new List<CetegoryClass>();          

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Categories", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    categories.Add(new CetegoryClass(reader.GetString(0), reader.GetDouble(1)));
                }

            }

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT Category, Amount FROM dbo.Products",connection);
                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    string category = reader.GetString(0);
                    double amount = reader.GetInt32(1);

                    foreach(var i in categories)
                    {
                        if(i.Name == category)
                        {
                            totalVolume += i.Volume * amount;
                        }
                    }

                }

            }

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Setting", connection);
                var reader = command.ExecuteReader();
                reader.Read();
                capacity = reader.GetDouble(2);
            }

            result = totalVolume / capacity  *100;
            result =  Math.Round(result, 1);

            return result.ToString() + "%";

        }


        public HelperClass(string connect)
        {
            connectionString = connect;
        }

       
    }
}
