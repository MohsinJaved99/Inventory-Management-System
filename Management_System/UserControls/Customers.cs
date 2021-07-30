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
    public partial class Customers : UserControl
    {

        string CustomerID;
        public Customers()
        {
            InitializeComponent();
            Customer_View();
            customer_gridveiw.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 191, 191);
            customer_gridveiw.DefaultCellStyle.SelectionForeColor = Color.Black;
            customer_gridveiw.DefaultCellStyle.ForeColor = Color.Black;
        }

        public void Customer_View()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select * from customer", connection.conString);

            da.Fill(dt);

            Customer_ID.DataPropertyName = dt.Columns["Customer_ID"].ToString();
            Customer_Namee.DataPropertyName = dt.Columns["Customer_Name"].ToString();
            Customer_Contact.DataPropertyName = dt.Columns["Customer_Contact"].ToString();
            Customer_CNIC.DataPropertyName = dt.Columns["Customer_CNIC"].ToString();
            Entry_Date.DataPropertyName = dt.Columns["Entry_Date"].ToString();

            customer_gridveiw.DataSource = dt;
        }


        public void Customer_View_Search(String data)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select * from customer where Customer_Name like '"+data+ "%' or Customer_Contact like '" + data + "%' or Customer_CNIC like '" + data + "%' or Entry_Date like '" + data + "%'", connection.conString);

            da.Fill(dt);

            Customer_ID.DataPropertyName = dt.Columns["Customer_ID"].ToString();
            Customer_Namee.DataPropertyName = dt.Columns["Customer_Name"].ToString();
            Customer_Contact.DataPropertyName = dt.Columns["Customer_Contact"].ToString();
            Customer_CNIC.DataPropertyName = dt.Columns["Customer_CNIC"].ToString();
            Entry_Date.DataPropertyName = dt.Columns["Entry_Date"].ToString();

            customer_gridveiw.DataSource = dt;
        }

        private void home_Click(object sender, EventArgs e)
        {
            using (Add_Customer ac = new Add_Customer())
            {
                ac.ShowDialog();
                Customer_View();
            }
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Customer_View_Search(textBox1.Text.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CustomerID != null && CustomerID != "")
            {
                using (Add_Customer ac = new Add_Customer(CustomerID))
                {
                    ac.ShowDialog();
                    Customer_View();
                    CustomerID = "";
                }
            }
            else
            {
                MessageBox.Show("Please Select A Row You Want To Update");
            }
        }

        private void customer_gridveiw_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in customer_gridveiw.SelectedRows)
            {
                CustomerID = row.Cells[0].Value.ToString();
            }
        }



        private string Delete_Customer(string cid)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM customer WHERE Customer_ID = @cid", connection.conString);
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
            var result = MessageBox.Show("Did you want to delete that customer?","Alert!", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (CustomerID != null && CustomerID != "")
                    {
                        string msg = Delete_Customer(CustomerID);
                        MessageBox.Show(msg);
                        Customer_View();
                    }
                    else
                    {
                        MessageBox.Show("Please Select A Row You Want To Delete.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You Can't Delete This Record Because This Customer Exists Somewhere.");
                }
            }
        }

        private void customer_gridveiw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
