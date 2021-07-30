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
    public partial class Home : UserControl
    {
        userid u = new userid();
        public Home()
        {
            InitializeComponent();
            panel3.Location = new Point(
this.panel2.Width / 2 - panel3.Size.Width / 2,
this.panel2.Height / 2+40 - panel3.Size.Height / 2);
            panel3.Anchor = AnchorStyles.None;



            SqlDataReader sdr;
            SqlCommand cmd = new SqlCommand("select Note_Text as 'text' from stickynote where User_ID='" + u.getuid() + "'", connection.conString);
            connection.conString.Close();
            connection.conString.Open();
            sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    text.Text = sdr["text"].ToString();
                }
            }
            else
            {
                text.Text = "Type Here...";
            }
            sdr.Close();

            connection.conString.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
          

            SqlCommand cmd = new SqlCommand("select count(*) as count from stickynote where User_ID='" + u.getuid() + "'", connection.conString);
            connection.conString.Close();
            connection.conString.Open();
            int res = Convert.ToInt32(cmd.ExecuteScalar().ToString());
         
            if (res > 0)
            {
                SqlCommand updte = new SqlCommand("update stickynote set Note_Text='" + text.Text + "' where User_ID='" + u.getuid() + "'", connection.conString);
                int res2 = updte.ExecuteNonQuery();
                if (res2 > 0)
                {

                }
                else
                {
                    MessageBox.Show("Error occurs while creating sticky note");
                }
            }
            else
            {
                SqlCommand create = new SqlCommand("insert into stickynote(User_ID,Note_Text) values ('" + u.getuid() + "','"+text.Text+"')", connection.conString);
                int res1 = create.ExecuteNonQuery();
                if(res1>0)
                {

                }
                else
                {
                    MessageBox.Show("Error occurs while creating sticky note");
                }
            }
            connection.conString.Close();

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void addcombo_Click(object sender, EventArgs e)
        {

        }

        private void addcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            backupcombo.SelectedIndex = -1;
            if(addcombo.SelectedIndex==0)
            {
                using (Add_Customer ad = new Add_Customer())
                {
                    ad.ShowDialog();
                    addcombo.SelectedIndex = -1;
                    loaddata();
                }
            }
            else if(addcombo.SelectedIndex == 1)
            {
                using (M_Commodity ad = new M_Commodity())
                {
                    ad.ShowDialog();
                    addcombo.SelectedIndex = -1;
                    loaddata();
                }
            }
            else if (addcombo.SelectedIndex == 2)
            {
                using (Add_Arrival ad = new Add_Arrival())
                {
                    ad.ShowDialog();
                    addcombo.SelectedIndex = -1;
                }
            }
            else if (addcombo.SelectedIndex == 3)
            {
                using (M_Expense ad = new M_Expense())
                {
                    ad.ShowDialog();
                    addcombo.SelectedIndex = -1;
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void loaddata()
        {
            SqlCommand totalcusquery = new SqlCommand("select count(*) as count from customer", connection.conString);

            SqlCommand totalcomquery = new SqlCommand("select count(*) as count from commodity", connection.conString);

            SqlCommand totalinproccessqury = new SqlCommand("select count(*) as count from proccess_in where Status='Active'", connection.conString);
            connection.conString.Close();
            connection.conString.Open();
            totalcus.Text = totalcusquery.ExecuteScalar().ToString();
            totalcom.Text = totalcomquery.ExecuteScalar().ToString();
            inprocessarrival.Text = totalinproccessqury.ExecuteScalar().ToString();
            connection.conString.Close();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void backupcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            addcombo.SelectedIndex = -1;
            if (backupcombo.SelectedIndex == 0)
            {
                using (createBackup ad = new createBackup())
                {
                    ad.ShowDialog();
                    backupcombo.SelectedIndex = -1;
                }
            }
            else if (backupcombo.SelectedIndex == 1)
            {
                using (RestoreBackup ad = new RestoreBackup())
                {
                    ad.ShowDialog();
                    backupcombo.SelectedIndex = -1;
                }
            }
        }
    }
}
