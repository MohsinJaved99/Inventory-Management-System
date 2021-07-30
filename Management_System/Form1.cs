using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel2.Location = new Point(
            this.ClientSize.Width / 2 - panel2.Size.Width / 2,
            this.ClientSize.Height / 2 - panel2.Size.Height / 2);
            panel2.Anchor = AnchorStyles.None;
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select count(*) as count from users where User_Name='" + username.Text + "' and User_Password='" + password.Text + "'", connection.conString);
            connection.conString.Open();
            int res = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            if (res > 0)
            {
                this.Hide();
                loginloading l = new loginloading();
                l.ShowDialog();
                if(l.a== 30)
                {
              
                        SqlCommand cmd1 = new SqlCommand("select CONCAT(First_Name,' ',Last_Name) as 'username' from users where User_Name='" + username.Text + "' and User_Password='" + password.Text + "'", connection.conString);
                        string uname = cmd1.ExecuteScalar().ToString();
                        SqlCommand cmd2 = new SqlCommand("select User_ID from users where User_Name='" + username.Text + "' and User_Password='" + password.Text + "'", connection.conString);
                        string uid = cmd2.ExecuteScalar().ToString();
                        Dashboard d = new Dashboard(uname, uid);
                        l.Hide();
                        d.Show();
               
                }
            }
            else
            {
                MessageBox.Show("Username or password do not match, Try again.");
            }
            connection.conString.Close();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
           label4.BackColor = Color.FromArgb(192, 64, 0);

        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.FromArgb(187, 66, 0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlCommand cmd = new SqlCommand("select count(*) as count from users where User_Name='" + username.Text + "' and User_Password='" + password.Text + "'", connection.conString);
                connection.conString.Open();
                int res = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                if (res > 0)
                {
                    this.Hide();
                    loginloading l = new loginloading();
                    l.ShowDialog();
                    if (l.a == 30)
                    {

                        SqlCommand cmd1 = new SqlCommand("select CONCAT(First_Name,' ',Last_Name) as 'username' from users where User_Name='" + username.Text + "' and User_Password='" + password.Text + "'", connection.conString);
                        string uname = cmd1.ExecuteScalar().ToString();
                        SqlCommand cmd2 = new SqlCommand("select User_ID from users where User_Name='" + username.Text + "' and User_Password='" + password.Text + "'", connection.conString);
                        string uid = cmd2.ExecuteScalar().ToString();
                        Dashboard d = new Dashboard(uname, uid);
                        l.Hide();
                        d.Show();

                    }
                }
                else
                {
                    MessageBox.Show("Username or password do not match, Try again.");
                }
                connection.conString.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string directory = System.IO.Directory.GetCurrentDirectory().ToString();
            //MessageBox.Show(directory + "\\Database1.mdf"); 
        }
    }
}
