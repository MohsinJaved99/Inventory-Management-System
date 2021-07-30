using Management_System.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_System
{
    public partial class Add_Customer : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        string Customer_IDD;
        public Add_Customer()
        {
            InitializeComponent();
            heading.Text = "Add Customer";
            Customer_IDD = "";
        }
        
        public Add_Customer(string customerid)
        {
            InitializeComponent();
            heading.Text = "Edit Customer";
            Customer_IDD = customerid;
            
            SqlDataAdapter dtp3 = new SqlDataAdapter("select * from customer where Customer_ID= @Customer_ID", connection.conString);
            dtp3.SelectCommand.Parameters.AddWithValue("@Customer_ID", Customer_IDD);
            DataTable tp3 = new DataTable();
            dtp3.Fill(tp3);

            foreach (DataRow row1 in tp3.Rows)
            {
                customer_name.Text = row1["Customer_Name"].ToString();
                customer_contact.Text = row1["Customer_Contact"].ToString();
                customer_cnic.Text = row1["Customer_CNIC"].ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void heading_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void home_Click(object sender, EventArgs e)
        {
            if (customer_name.Text == "" || customer_contact.Text == "" || customer_cnic.Text == "")
            {
                MessageBox.Show("Please Fill All Fields.");
            }
            else
            {

                if(Customer_IDD=="")
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("insert into customer(Customer_Name,Customer_Contact,Customer_CNIC,Entry_Date) values('" + customer_name.Text + "','" + customer_contact.Text + "','" + customer_cnic.Text + "','" + DateTime.Now.ToString("dd-MMMM-yyyy") + "')", connection.conString);
                        if (connection.conString.State.Equals(ConnectionState.Closed))
                        {
                            connection.conString.Open();
                        }

                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            MessageBox.Show("Customer Added Successfully!");
                            Customers c = new Customers();
                            c.Customer_View();
                            this.Close();
                        }

                        if (connection.conString.State.Equals(ConnectionState.Open))
                        {
                            connection.conString.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Customer CNIC or Contact Already Exist.");
                    }
                }
                else
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("update customer set Customer_Name='" + customer_name.Text + "',Customer_Contact='" + customer_contact.Text + "',Customer_CNIC='" + customer_cnic.Text + "' where Customer_ID='" + Customer_IDD + "'", connection.conString);
                        if (connection.conString.State.Equals(ConnectionState.Closed))
                        {
                            connection.conString.Open();
                        }

                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            MessageBox.Show("Customer Updated Successfully!");
                            Customers c = new Customers();
                            c.Customer_View();
                            this.Close();
                        }

                        if (connection.conString.State.Equals(ConnectionState.Open))
                        {
                            connection.conString.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Customer CNIC or Contact Already Exist.");
                    }
                }
              
            }
        }

        private void Add_Customer_Load(object sender, EventArgs e)
        {

        }

        private void customer_contact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void customer_cnic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
