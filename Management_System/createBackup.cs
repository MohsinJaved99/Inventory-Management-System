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
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace Management_System
{
    public partial class createBackup : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public createBackup()
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
        string sSelectedPath;
      
        private void home_Click(object sender, EventArgs e)
        {
            try
            {
            if (location.Text != "") {
                    string directory = System.IO.Directory.GetCurrentDirectory().ToString();
                    var query = String.Format(@"BACKUP DATABASE [" + directory + "\\inventorymanagement.mdf] TO DISK='" + sSelectedPath + "\\jaidiDatabaseBackup" + DateTime.Now.ToString("dd-MMMM-yyyy") + ".bak'");

            using (var command = new SqlCommand(query, connection.conString))
            {
                connection.conString.Close();
                connection.conString.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Backup Created On " + sSelectedPath, "Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.conString.Close();
            }
            }
            else
            {
                 MessageBox.Show("Please Select A Path.");
            }
            }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }


}

        private void button1_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
            folderBrowserDlg.ShowNewFolderButton = true;
            DialogResult dlgResult = folderBrowserDlg.ShowDialog();
            if (dlgResult.Equals(DialogResult.OK))
            {
                location.Text = folderBrowserDlg.SelectedPath;
                sSelectedPath = folderBrowserDlg.SelectedPath;
            }

        }

        private void createBackup_Load(object sender, EventArgs e)
        {
          
        }
    }
}
