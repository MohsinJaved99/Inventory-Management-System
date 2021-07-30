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
    public partial class M_Commodity : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        string Com_IDD;
        public M_Commodity()
        {
            InitializeComponent();
            heading.Text = "Add Commodity";
            Com_IDD = "";
        }

        public M_Commodity(string comrid)
        {
            InitializeComponent();
            heading.Text = "Edit Commodity";
            Com_IDD = comrid;

            SqlDataAdapter dtp3 = new SqlDataAdapter("select * from commodity where Commodity_ID=@Com_ID", connection.conString);
            dtp3.SelectCommand.Parameters.AddWithValue("@Com_ID", comrid);
            DataTable tp3 = new DataTable();
            dtp3.Fill(tp3);

            foreach (DataRow row1 in tp3.Rows)
            {
              
                name.Text = row1["Commodity_Name"].ToString();
                dis.Text = row1["Commodity_Discription"].ToString();
            }
        }

        private void customer_name_TextChanged(object sender, EventArgs e)
        {

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
            if (name.Text == "")
            {
                MessageBox.Show("Please Enter Commodity Name.");
            }
            else
            {

                if (Com_IDD == "")
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("insert into commodity(Commodity_Name,Commodity_Discription,Entry_Date) values('" + name.Text + "','" + dis.Text + "','" + DateTime.Now.ToString("dd-MMMM-yyyy") + "')", connection.conString);
                        if (connection.conString.State.Equals(ConnectionState.Closed))
                        {
                            connection.conString.Open();
                        }

                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            MessageBox.Show("Commodity Added Successfully!");
                            this.Close();
                        }

                        if (connection.conString.State.Equals(ConnectionState.Open))
                        {
                            connection.conString.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Commodity Name Already Exist.");
                    }
                }
                else
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("update commodity set Commodity_Name='" + name.Text + "',Commodity_Discription='" + dis.Text + "' where Commodity_ID='" + Com_IDD + "'", connection.conString);
                        if (connection.conString.State.Equals(ConnectionState.Closed))
                        {
                            connection.conString.Open();
                        }

                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            MessageBox.Show("Commodity Updated Successfully!");
                            this.Close();
                        }

                        if (connection.conString.State.Equals(ConnectionState.Open))
                        {
                            connection.conString.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Commodity Name Already Exist.");
                    }
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void M_Commodity_Load(object sender, EventArgs e)
        {

        }
    }
}
