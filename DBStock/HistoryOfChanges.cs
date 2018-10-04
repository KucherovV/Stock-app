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
using Newtonsoft.Json;

namespace DBStock
{
    public partial class HistoryOfChanges : Form
    {
        string connectionString;
        public HistoryOfChanges(string connect)
        {
            connectionString = connect;

            InitializeComponent();
            dataGridViewRecipies.ColumnCount = 4;
            dataGridViewRecipies.Columns[0].Name = "Действие";
            dataGridViewRecipies.Columns[1].Name = "Время";
            dataGridViewRecipies.Columns[2].Name = "Список изменений";
            dataGridViewRecipies.Columns[3].Name = "Сумма изменений";
            dataGridViewRecipies.Columns[2].Width = 500;
            dataGridViewRecipies.Columns[1].Width = 110;

            UpdateChanges();

            dataGridViewRecipies.Sort(dataGridViewRecipies.Columns[1], ListSortDirection.Ascending);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void UpdateChanges()
        {
            string actionStr = "";
            int i = 0;
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Actions", connection);
                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    bool action = reader.GetBoolean(0);
                    if (action)
                        actionStr = "Добавление";
                    else
                        actionStr = "Списание";

                    DateTime dtTemp = reader.GetDateTime(1);
                    DateTime dt = new DateTime();
                    dt.AddYears(dtTemp.Year);
                    dt.AddMonths(dtTemp.Month);
                    dt.AddDays(dtTemp.Day);
                    dt.AddHours(dtTemp.Hour);
                    dt.AddMinutes(dtTemp.Minute);


                    dataGridViewRecipies.Rows.Add(actionStr, reader.GetDateTime(1), reader.GetString(2), reader.GetInt32(3));
                    
                    if(action)
                    {
                        dataGridViewRecipies.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen ;
                    }
                    else
                    {
                        dataGridViewRecipies.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                    }
                    i++;
                }

            }
        }

        private void HistoryOfChanges_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = (MainForm)this.Owner;
            mf.Enabled = true;
        }     

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridViewRecipies.CurrentRow.Index;

            DateTime dt = Convert.ToDateTime(dataGridViewRecipies.CurrentRow.Cells[1].Value);
            bool action = false;
            if (dataGridViewRecipies.Rows[index].Cells[0].Value.ToString() == "Добавление")
                action = true;

            int sum = Convert.ToInt32(dataGridViewRecipies.Rows[index].Cells[3].Value);

            DataGridView DGV;
            string dgvString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DGV FROM dbo.Actions WHERE DateTime = @dt", connection);
                command.Parameters.AddWithValue("@dt", dt);
                var reader = command.ExecuteReader();
                reader.Read();

                dgvString = reader.GetString(0);
            }

            HelperClass hc = new HelperClass(connectionString);
            DGV = hc.DeConvertDGV(dgvString);

            hc.Print(dt, DGV, action, sum);

            MessageBox.Show("Отчет восстановлен");

        }
    }
}
