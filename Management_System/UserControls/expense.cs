using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Management_System.UserControls
{
    public partial class expense : UserControl
    {
        string expID;
        public expense()
        {
            InitializeComponent();
            Exoense_View();

            expense_gridveiw.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 191, 191);
            expense_gridveiw.DefaultCellStyle.SelectionForeColor = Color.Black;
            expense_gridveiw.DefaultCellStyle.ForeColor = Color.Black;
        }


        public void Exoense_View()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select * from dailyexpense", connection.conString);

            da.Fill(dt);

            Expense_ID.DataPropertyName = dt.Columns["Expense_ID"].ToString();
            Expense_Date.DataPropertyName = dt.Columns["Expense_Date"].ToString();
            Expense_Head.DataPropertyName = dt.Columns["Expense_Head"].ToString();
            Expense_Mode.DataPropertyName = dt.Columns["Expense_Mode"].ToString();
            Expense_Purpose.DataPropertyName = dt.Columns["Expense_Purpose"].ToString();
            Expense_Amount.DataPropertyName = dt.Columns["Expense_Amount"].ToString();
            expense_gridveiw.DataSource = dt;
        }

        public void Exoense_View_search(string data)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select * from dailyexpense where Expense_Date like '" + data + "%' or Expense_Head like '" + data + "%' or Expense_Mode like '" + data + "%' or Expense_Purpose like '" + data + "%'", connection.conString);

            da.Fill(dt);

            Expense_ID.DataPropertyName = dt.Columns["Expense_ID"].ToString();
            Expense_Date.DataPropertyName = dt.Columns["Expense_Date"].ToString();
            Expense_Head.DataPropertyName = dt.Columns["Expense_Head"].ToString();
            Expense_Mode.DataPropertyName = dt.Columns["Expense_Mode"].ToString();
            Expense_Purpose.DataPropertyName = dt.Columns["Expense_Purpose"].ToString();
            Expense_Amount.DataPropertyName = dt.Columns["Expense_Amount"].ToString();
            expense_gridveiw.DataSource = dt;
        }

        private void home_Click(object sender, EventArgs e)
        {
            using (M_Expense ac = new M_Expense())
            {
                ac.ShowDialog();
                Exoense_View();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Exoense_View_search(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (expID != null && expID != "")
            {
                using (M_Expense ac = new M_Expense(expID))
                {
                    ac.ShowDialog();
                    Exoense_View();
                    expID = "";
                }
            }
            else
            {
                MessageBox.Show("Please Select A Row You Want To Update");
            }
        }
        private string Delete_Exp(string cid)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM dailyexpense WHERE Expense_ID = @cid", connection.conString);
            cmd.Parameters.AddWithValue("@cid", cid);

            if (connection.conString.State != ConnectionState.Open)
            {
                connection.conString.Open();
            }

            int i = cmd.ExecuteNonQuery();

            if (connection.conString.State == ConnectionState.Open)
            {
                connection.conString.Close();
            }

            if (i > 0)
            {
                return "Data Deleted From System Successfully";
            }
            else
            {
                return "Data Not Deleted From System Successfully";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Did you want to delete that expense?", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (expID != null && expID != "")
                    {
                        string msg = Delete_Exp(expID);
                        MessageBox.Show(msg);
                        Exoense_View();
                    }
                    else
                    {
                        MessageBox.Show("Please Select A Row You Want To Delete.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You Can't Delete This Record Because This Expense Exists Somewhere.");
                }
            }
        }

        private void expense_gridveiw_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in expense_gridveiw.SelectedRows)
            {
                expID = row.Cells[0].Value.ToString();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                SqlDataReader sdr;
                SqlCommand cmd = new SqlCommand("select sum(Expense_Amount) as 'sum' from dailyexpense where Expense_Date like '%" + dateTimePicker1.Text + "%'", connection.conString);
                connection.conString.Close();
                connection.conString.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        string sum = sdr["sum"].ToString();
                        totalsum.Text = sum + "Rs";
                    }
                }
                else
                {
                    totalsum.Text = "0Rs";
                }
                sdr.Close();

                connection.conString.Close();
            }
            else
            {
                SqlDataReader sdr;
                SqlCommand cmd = new SqlCommand("select sum(Expense_Amount) as 'sum' from dailyexpense where Expense_Date like '%" + textBox1.Text + "%'", connection.conString);
                connection.conString.Close();
                connection.conString.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        string sum = sdr["sum"].ToString();
                        totalsum.Text = sum + "Rs";
                    }
                }
                else
                {
                    totalsum.Text = "0Rs";
                }
                sdr.Close();

                connection.conString.Close();
            }
            

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select * from dailyexpense where Expense_Date like '%" + dateTimePicker1.Text + "%'", connection.conString);

            da.Fill(dt);

            Expense_ID.DataPropertyName = dt.Columns["Expense_ID"].ToString();
            Expense_Date.DataPropertyName = dt.Columns["Expense_Date"].ToString();
            Expense_Head.DataPropertyName = dt.Columns["Expense_Head"].ToString();
            Expense_Mode.DataPropertyName = dt.Columns["Expense_Mode"].ToString();
            Expense_Purpose.DataPropertyName = dt.Columns["Expense_Purpose"].ToString();
            Expense_Amount.DataPropertyName = dt.Columns["Expense_Amount"].ToString();
            expense_gridveiw.DataSource = dt;
        }
    }
}
