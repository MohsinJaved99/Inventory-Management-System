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
    public partial class RestoreBackup : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public RestoreBackup()
        {
            InitializeComponent();
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
        string sFileName;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Database Restore|*.bak";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                sFileName = choofdlog.FileName;
                location.Text = choofdlog.FileName;
            }
        }

        private void home_Click(object sender, EventArgs e)
        {
            if (location.Text != "")
            {
                this.Cursor = Cursors.WaitCursor;

                connection.conString.Close();
                connection.conString.Open();
                string directory = System.IO.Directory.GetCurrentDirectory().ToString();
                MessageBox.Show("Restoring Database,Please Wait", "Restoring", MessageBoxButtons.OK,MessageBoxIcon.Information);

                string sqlStmt2 = string.Format("ALTER DATABASE [" + directory + "\\inventorymanagement.mdf] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;");
                SqlCommand bu2 = new SqlCommand(sqlStmt2, connection.conString);
                int r=bu2.ExecuteNonQuery();
                if (r > 0)
                {
                string sqlStmt3 = "USE MASTER RESTORE DATABASE [" + directory + "\\inventorymanagement.mdf] FROM DISK='" + sFileName + "' WITH REPLACE;";
                SqlCommand bu3 = new SqlCommand(sqlStmt3, connection.conString);
                int re=bu3.ExecuteNonQuery();
                if(re>0)
                {
                    string sqlStmt4 = string.Format("ALTER DATABASE [" + directory + "\\inventorymanagement.mdf] SET MULTI_USER;");
                    SqlCommand bu4 = new SqlCommand(sqlStmt4, connection.conString);
                    bu4.ExecuteNonQuery();
                }
                }
                



                MessageBox.Show("Backup Restored", "Restored", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.conString.Close();
                this.Dispose();
                this.Cursor = Cursors.Arrow;
            }
            else
            {
                MessageBox.Show("Please Select Backup File.");
                connection.conString.Close();
            }
        }
    }
}
