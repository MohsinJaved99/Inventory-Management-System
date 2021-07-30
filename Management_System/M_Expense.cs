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
    public partial class M_Expense : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        string Exp_IDD;
        public M_Expense()
        {
            InitializeComponent();
            heading.Text = "Add Expense";
            Exp_IDD = "";
        }

        public M_Expense(string expid)
        {
            InitializeComponent();
            heading.Text = "Edit Expense";
            Exp_IDD = expid;

            SqlDataAdapter dtp3 = new SqlDataAdapter("select * from dailyexpense where Expense_ID=@Com_ID", connection.conString);
            dtp3.SelectCommand.Parameters.AddWithValue("@Com_ID", expid);
            DataTable tp3 = new DataTable();
            dtp3.Fill(tp3);

            foreach (DataRow row1 in tp3.Rows)
            {
                date.Text = row1["Expense_Date"].ToString();
                head.SelectedIndex = head.FindString(row1["Expense_Head"].ToString());
                mode.SelectedIndex = mode.FindString(row1["Expense_Mode"].ToString());
                purpose.Text = row1["Expense_Purpose"].ToString();
                amount.Text = row1["Expense_Amount"].ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void home_Click(object sender, EventArgs e)
        {
            if (purpose.Text == "" || purpose.Text == "" || head.SelectedIndex==-1 || mode.SelectedIndex==-1)
            {
                MessageBox.Show("Please Fill All Fields.");
            }
            else
            {

                if (Exp_IDD == "")
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("insert into dailyexpense(Expense_Date,Expense_Head,Expense_Mode,Expense_Purpose,Expense_Amount) values('" + date.Text + "','" + head.Text + "','" + mode.Text +"','" + purpose.Text + "','" + amount.Text +"')", connection.conString);
                        if (connection.conString.State.Equals(ConnectionState.Closed))
                        {
                            connection.conString.Open();
                        }

                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            MessageBox.Show("Expense Added Successfully!");
                            this.Close();
                        }

                        if (connection.conString.State.Equals(ConnectionState.Open))
                        {
                            connection.conString.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error.");
                    }
                }
                else
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("update dailyexpense set Expense_Date='" + date.Text + "',Expense_Head='" + head.Text + "',Expense_Mode='" + mode.Text + "',Expense_Purpose='" + purpose.Text + "',Expense_Amount='" + amount.Text + "' where Expense_ID='" + Exp_IDD + "'", connection.conString);
                        if (connection.conString.State.Equals(ConnectionState.Closed))
                        {
                            connection.conString.Open();
                        }

                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            MessageBox.Show("Expense Updated Successfully!");
                            this.Close();
                        }

                        if (connection.conString.State.Equals(ConnectionState.Open))
                        {
                            connection.conString.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error.");
                    }
                }

            }
        }

        private void M_Expense_Load(object sender, EventArgs e)
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

        private void amount_KeyPress(object sender, KeyPressEventArgs e)
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
