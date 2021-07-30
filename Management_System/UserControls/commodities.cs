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
    public partial class commodities : UserControl
    {
        string ComID;
        public commodities()
        {
            InitializeComponent();
            Cim_View();

            com_gridveiw.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 191, 191);
            com_gridveiw.DefaultCellStyle.SelectionForeColor = Color.Black;
            com_gridveiw.DefaultCellStyle.ForeColor = Color.Black;
        }

        public void Cim_View()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select Commodity_ID as 'Commodity_ID',Commodity_Name as 'Commodity_Name',COALESCE(Commodity_Discription, '-') as 'Commodity_Discription',Entry_Date as 'Entry_Date' from commodity", connection.conString);

            da.Fill(dt);

            Commodity_ID.DataPropertyName = dt.Columns["Commodity_ID"].ToString();
            Commodity_Name.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
            Commodity_Date.DataPropertyName = dt.Columns["Entry_Date"].ToString();
            Discription.DataPropertyName = dt.Columns["Commodity_Discription"].ToString();

            com_gridveiw.DataSource = dt;
        }

        public void Cim_View_search(string data)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select Commodity_ID as 'Commodity_ID',Commodity_Name as 'Commodity_Name',COALESCE(Commodity_Discription, '-') as 'Commodity_Discription',Entry_Date as 'Entry_Date' from commodity where Commodity_Name like '%" + data+"%'", connection.conString);

            da.Fill(dt);

            Commodity_ID.DataPropertyName = dt.Columns["Commodity_ID"].ToString();
            Commodity_Name.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
            Commodity_Date.DataPropertyName = dt.Columns["Entry_Date"].ToString();
            Discription.DataPropertyName = dt.Columns["Commodity_Discription"].ToString();

            com_gridveiw.DataSource = dt;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void com_gridveiw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ComID != null && ComID != "")
            {
                using (M_Commodity ac = new M_Commodity(ComID))
                {
                    ac.ShowDialog();
                    Cim_View();
                    ComID = "";
                }
            }
            else
            {
                MessageBox.Show("Please Select A Row You Want To Update");
            }
        }

        private void com_gridveiw_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in com_gridveiw.SelectedRows)
            {
                ComID = row.Cells[0].Value.ToString();
            }
        }
        private string Delete_Com(string cid)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM commodity WHERE Commodity_ID = @cid", connection.conString);
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
            var result = MessageBox.Show("Did you want to delete that commodity?", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (ComID != null && ComID != "")
                    {
                        string msg = Delete_Com(ComID);
                        MessageBox.Show(msg);
                        Cim_View();
                    }
                    else
                    {
                        MessageBox.Show("Please Select A Row You Want To Delete.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You Can't Delete This Record Because This Commodity Exists Somewhere.");
                }
            }
        }

        private void home_Click(object sender, EventArgs e)
        {
            using (M_Commodity ac = new M_Commodity())
            {
                ac.ShowDialog();
                Cim_View();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Cim_View_search(textBox1.Text);
        }
    }
}
