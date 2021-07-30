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
    public partial class Dashboard : Form
    {
        int PanelWidth;
        bool isCollapsed;
        public Dashboard()
        {
            InitializeComponent();
            isCollapsed = false;
            PanelWidth = panel2.Width;


            Home UH = new Home();
            AddControlsToPanel(UH);
            home.BackColor = Color.FromArgb(187, 66, 0);
            arrival.BackColor = Color.FromArgb(17, 17, 17);
            stock.BackColor = Color.FromArgb(17, 17, 17);
            stocks.BackColor = Color.FromArgb(17, 17, 17);
            proccessing.BackColor = Color.FromArgb(17, 17, 17);
            dispatch.BackColor = Color.FromArgb(17, 17, 17);
            reports.BackColor = Color.FromArgb(17, 17, 17);
            dailyexpense.BackColor = Color.FromArgb(17, 17, 17);
            button1.BackColor = Color.FromArgb(17, 17, 17);
            button2.BackColor = Color.FromArgb(17, 17, 17);
            customer.BackColor = Color.FromArgb(17, 17, 17);
            commodity.BackColor = Color.FromArgb(17, 17, 17);
        }

        string id;

        public Dashboard(string uname,string idd)
        {
            InitializeComponent();
            isCollapsed = false;
            PanelWidth = panel2.Width;
            
            userid u = new userid();
            u.setuid(idd);

            username.Text = uname;
            Home UH = new Home();
            AddControlsToPanel(UH);
            home.BackColor = Color.FromArgb(187, 66, 0);
            arrival.BackColor = Color.FromArgb(17, 17, 17);
            stock.BackColor = Color.FromArgb(17, 17, 17);
            stocks.BackColor = Color.FromArgb(17, 17, 17);
            proccessing.BackColor = Color.FromArgb(17, 17, 17);
            dispatch.BackColor = Color.FromArgb(17, 17, 17);
            reports.BackColor = Color.FromArgb(17, 17, 17);
            dailyexpense.BackColor = Color.FromArgb(17, 17, 17);
            button1.BackColor = Color.FromArgb(17, 17, 17);
            button2.BackColor = Color.FromArgb(17, 17, 17);
            customer.BackColor = Color.FromArgb(17, 17, 17);
            commodity.BackColor = Color.FromArgb(17, 17, 17);
        }
        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);
        }

        private void label14_Click(object sender, EventArgs e)
        {
            //ᐅ
        }

        private void label15_Click(object sender, EventArgs e)
        {
            timer1.Start();
           
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void home_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want exit?", "Exit!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
            }
           
        }

        private void home_MouseEnter(object sender, EventArgs e)
        {
            home.BackColor = Color.FromArgb(187, 66, 0);
        }

        private void home_MouseLeave(object sender, EventArgs e)
        {
            home.BackColor = Color.FromArgb(17, 17, 17);
        }

        private void arrival_MouseEnter(object sender, EventArgs e)
        {
            arrival.BackColor = Color.FromArgb(187, 66, 0);
        }

        private void arrival_MouseLeave(object sender, EventArgs e)
        {
            arrival.BackColor = Color.FromArgb(17, 17, 17);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (isCollapsed)
            {
                label15.Text = "ᐊ";
                home.Text = "HOME";
                arrival.Text = "ARRIVAL";
                stocks.Text = "STOCK";
                stock.Text = "ARRIVAL RECORDS";
                proccessing.Text = "IN PROCESS";
                dispatch.Text = "OUT PROCESS";
                reports.Text = "PROCESSING REPORTS";
                dailyexpense.Text = "DAILY REPORT";
                button1.Text = "DISPATCH";
                button2.Text = "DISPATCH RECORDS";
                customer.Text = "CUSTOMERS";
                commodity.Text = "COMMODITIES";

                label3.Visible = true;
                panel2.Width = panel2.Width + 200;
                if (panel2.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                label15.Text = "ᐅ";
                home.Text = "";
                arrival.Text = "";
                stock.Text = "";
                stocks.Text = "";
                proccessing.Text = "";
                dispatch.Text = "";
                reports.Text = "";
                dailyexpense.Text = "";
                button1.Text = "";
                button2.Text = "";
                customer.Text = "";
                commodity.Text = "";
                label3.Visible = false;
                panel2.Width = panel2.Width - 200;
                if (panel2.Width <= 60)
                {

                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            var info = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");
            DateTimeOffset localServerTime = DateTimeOffset.Now;
            timeee.Text = "";

            int hours = Convert.ToInt32(TimeZoneInfo.ConvertTime(localServerTime, info).ToString("hh"));
            int mins = Convert.ToInt32(TimeZoneInfo.ConvertTime(localServerTime, info).ToString("mm"));
            int sec = Convert.ToInt32(TimeZoneInfo.ConvertTime(localServerTime, info).ToString("ss"));
            if (sec > 59)
            {
                mins = mins + 1;
            }
            if (mins > 59)
            {
                hours = hours + 1;
            }
            timeee.Text = TimeZoneInfo.ConvertTime(localServerTime, info).ToString("📆 dd-MMMM-yyyy    🕐 " + hours.ToString() + ":" + mins.ToString() + ":ss tt");
            //MessageBox.Show(TimeZoneInfo.ConvertTime(localServerTime, info).ToString("📆 dd-MMMM-yyyy    🕐 " + hours.ToString() + ":0" + mins.ToString() + ":ss tt"));
            if (mins.ToString().Length == 1)
            {
                timeee.Text = TimeZoneInfo.ConvertTime(localServerTime, info).ToString("📆 dd-MMMM-yyyy    🕐 " + hours.ToString() + ":0" + mins.ToString() + ":ss tt");

            }


            if (hours.ToString().Length == 1)
            {
                timeee.Text = TimeZoneInfo.ConvertTime(localServerTime, info).ToString("📆 dd-MMMM-yyyy    🕐 0" + hours.ToString() + ":" + mins.ToString() + ":ss tt");
            }

            if (mins.ToString().Length == 1 && hours.ToString().Length == 1)
            {
                timeee.Text = TimeZoneInfo.ConvertTime(localServerTime, info).ToString("📆 dd-MMMM-yyyy    🕐 0" + hours.ToString() + ":0" + mins.ToString() + ":ss tt");
            }
        }

        private void home_Click(object sender, EventArgs e)
        {
           
        }

        private void arrival_Click(object sender, EventArgs e)
        {
            Arrival UH = new Arrival();
            AddControlsToPanel(UH);


            home.BackColor = Color.FromArgb(17, 17, 17);
            arrival.BackColor = Color.FromArgb(187, 66, 0);
            stock.BackColor = Color.FromArgb(17, 17, 17);
            stocks.BackColor = Color.FromArgb(17, 17, 17);
            proccessing.BackColor = Color.FromArgb(17, 17, 17);
            dispatch.BackColor = Color.FromArgb(17, 17, 17);
            reports.BackColor = Color.FromArgb(17, 17, 17);
            dailyexpense.BackColor = Color.FromArgb(17, 17, 17);
            button1.BackColor = Color.FromArgb(17, 17, 17);
            button2.BackColor = Color.FromArgb(17, 17, 17);
            customer.BackColor = Color.FromArgb(17, 17, 17);
            commodity.BackColor = Color.FromArgb(17, 17, 17);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void customer_Click(object sender, EventArgs e)
        {
            Customers UH = new Customers();
            AddControlsToPanel(UH);
            home.BackColor = Color.FromArgb(17, 17, 17);
            arrival.BackColor = Color.FromArgb(17, 17, 17);
            stock.BackColor = Color.FromArgb(17, 17, 17);
            stocks.BackColor = Color.FromArgb(17, 17, 17);
            proccessing.BackColor = Color.FromArgb(17, 17, 17);
            dispatch.BackColor = Color.FromArgb(17, 17, 17);
            reports.BackColor = Color.FromArgb(17, 17, 17);
            dailyexpense.BackColor = Color.FromArgb(17, 17, 17);
            button1.BackColor = Color.FromArgb(17, 17, 17);
            button2.BackColor = Color.FromArgb(17, 17, 17);
            customer.BackColor = Color.FromArgb(187, 66, 0);
            commodity.BackColor = Color.FromArgb(17, 17, 17);
        }

        private void proccessing_Click(object sender, EventArgs e)
        {
            Proccessing UH = new Proccessing();
            AddControlsToPanel(UH);
            home.BackColor = Color.FromArgb(17, 17, 17);
            arrival.BackColor = Color.FromArgb(17, 17, 17);
            stock.BackColor = Color.FromArgb(17, 17, 17);
            stocks.BackColor = Color.FromArgb(17, 17, 17);
            proccessing.BackColor = Color.FromArgb(187, 66, 0);
            dispatch.BackColor = Color.FromArgb(17, 17, 17);
            reports.BackColor = Color.FromArgb(17, 17, 17);
            dailyexpense.BackColor = Color.FromArgb(17, 17, 17);
            button1.BackColor = Color.FromArgb(17, 17, 17);
            button2.BackColor = Color.FromArgb(17, 17, 17);
            customer.BackColor = Color.FromArgb(17, 17, 17);
            commodity.BackColor = Color.FromArgb(17, 17, 17);
        }

        private void home_Click_1(object sender, EventArgs e)
        {
            Home UH = new Home();
            AddControlsToPanel(UH);
            home.BackColor = Color.FromArgb(187, 66, 0);
            arrival.BackColor = Color.FromArgb(17, 17, 17);
            stock.BackColor = Color.FromArgb(17, 17, 17);
            stocks.BackColor = Color.FromArgb(17, 17, 17);
            proccessing.BackColor = Color.FromArgb(17, 17, 17);
            dispatch.BackColor = Color.FromArgb(17, 17, 17);
            reports.BackColor = Color.FromArgb(17, 17, 17);
            dailyexpense.BackColor = Color.FromArgb(17, 17, 17);
            button1.BackColor = Color.FromArgb(17, 17, 17);
            button2.BackColor = Color.FromArgb(17, 17, 17);
            customer.BackColor = Color.FromArgb(17, 17, 17);
            commodity.BackColor = Color.FromArgb(17, 17, 17);
        }

        public void clickprocc()
        {
            proccessing.PerformClick();
        }

        private void dispatch_Click(object sender, EventArgs e)
        {

            string q = "select count(*) from proccess_in where Status='Active'";
            SqlCommand cmd = new SqlCommand(q, connection.conString);
            connection.conString.Close();
            connection.conString.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {

                Proccessing_Outputs UH = new Proccessing_Outputs();
                AddControlsToPanel(UH);
                home.BackColor = Color.FromArgb(17, 17, 17);
                arrival.BackColor = Color.FromArgb(17, 17, 17);
                stock.BackColor = Color.FromArgb(17, 17, 17);
                stocks.BackColor = Color.FromArgb(17, 17, 17);
                proccessing.BackColor = Color.FromArgb(17, 17, 17);
                dispatch.BackColor = Color.FromArgb(187, 66, 0);
                reports.BackColor = Color.FromArgb(17, 17, 17);
                dailyexpense.BackColor = Color.FromArgb(17, 17, 17);
                button1.BackColor = Color.FromArgb(17, 17, 17);
                button2.BackColor = Color.FromArgb(17, 17, 17);
                customer.BackColor = Color.FromArgb(17, 17, 17);
                commodity.BackColor = Color.FromArgb(17, 17, 17);
            }
            else
            {
                MessageBox.Show("No Procces Activated.");
            }
          
           connection.conString.Close();
           
        }

        private void reports_Click(object sender, EventArgs e)
        {
            reports UH = new reports();
            AddControlsToPanel(UH);
            home.BackColor = Color.FromArgb(17, 17, 17);
            arrival.BackColor = Color.FromArgb(17, 17, 17);
            stock.BackColor = Color.FromArgb(17, 17, 17);
            stocks.BackColor = Color.FromArgb(17, 17, 17);
            proccessing.BackColor = Color.FromArgb(17, 17, 17);
            dispatch.BackColor = Color.FromArgb(17, 17, 17);
            reports.BackColor = Color.FromArgb(187, 66, 0);
            dailyexpense.BackColor = Color.FromArgb(17, 17, 17);
            button1.BackColor = Color.FromArgb(17, 17, 17);
            button2.BackColor = Color.FromArgb(17, 17, 17);
            customer.BackColor = Color.FromArgb(17, 17, 17);
            commodity.BackColor = Color.FromArgb(17, 17, 17);
        }

        private void stock_Click(object sender, EventArgs e)
        {
            arrivedstock UH = new arrivedstock();
            AddControlsToPanel(UH);
            home.BackColor = Color.FromArgb(17, 17, 17);
            arrival.BackColor = Color.FromArgb(17, 17, 17);
            stock.BackColor = Color.FromArgb(187, 66, 0);
            stocks.BackColor = Color.FromArgb(17, 17, 17);
            proccessing.BackColor = Color.FromArgb(17, 17, 17);
            dispatch.BackColor = Color.FromArgb(17, 17, 17);
            reports.BackColor = Color.FromArgb(17, 17, 17);
            dailyexpense.BackColor = Color.FromArgb(17, 17, 17);
            button1.BackColor = Color.FromArgb(17, 17, 17);
            button2.BackColor = Color.FromArgb(17, 17, 17);
            customer.BackColor = Color.FromArgb(17, 17, 17);
            commodity.BackColor = Color.FromArgb(17, 17, 17);
        }

        private void stocks_Click(object sender, EventArgs e)
        {
            string q = "select count(*) from arrival_stock";
            SqlCommand cmd = new SqlCommand(q, connection.conString);
            connection.conString.Close();
            connection.conString.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                stocks UH = new stocks();
                AddControlsToPanel(UH);
                home.BackColor = Color.FromArgb(17, 17, 17);
                arrival.BackColor = Color.FromArgb(17, 17, 17);
                stock.BackColor = Color.FromArgb(17, 17, 17);
                stocks.BackColor = Color.FromArgb(187, 66, 0);
                proccessing.BackColor = Color.FromArgb(17, 17, 17);
                dispatch.BackColor = Color.FromArgb(17, 17, 17);
                reports.BackColor = Color.FromArgb(17, 17, 17);
                dailyexpense.BackColor = Color.FromArgb(17, 17, 17);
                button1.BackColor = Color.FromArgb(17, 17, 17);
                button2.BackColor = Color.FromArgb(17, 17, 17);
                customer.BackColor = Color.FromArgb(17, 17, 17);
                commodity.BackColor = Color.FromArgb(17, 17, 17);
            }
            else
            {
                MessageBox.Show("No Stock Available.");
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dispatch UH = new dispatch();
            AddControlsToPanel(UH);
            home.BackColor = Color.FromArgb(17, 17, 17);
            arrival.BackColor = Color.FromArgb(17, 17, 17);
            stock.BackColor = Color.FromArgb(17, 17, 17);
            stocks.BackColor = Color.FromArgb(17, 17, 17);
            proccessing.BackColor = Color.FromArgb(17, 17, 17);
            dispatch.BackColor = Color.FromArgb(17, 17, 17);
            reports.BackColor = Color.FromArgb(17, 17, 17);
            dailyexpense.BackColor = Color.FromArgb(17, 17, 17);
            button1.BackColor = Color.FromArgb(187, 66, 0);
            button2.BackColor = Color.FromArgb(17, 17, 17);
            customer.BackColor = Color.FromArgb(17, 17, 17);
            commodity.BackColor = Color.FromArgb(17, 17, 17);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dispatchhistory UH = new dispatchhistory();
            AddControlsToPanel(UH);
            home.BackColor = Color.FromArgb(17, 17, 17);
            arrival.BackColor = Color.FromArgb(17, 17, 17);
            stock.BackColor = Color.FromArgb(17, 17, 17);
            stocks.BackColor = Color.FromArgb(17, 17, 17);
            proccessing.BackColor = Color.FromArgb(17, 17, 17);
            dispatch.BackColor = Color.FromArgb(17, 17, 17);
            reports.BackColor = Color.FromArgb(17, 17, 17);
            dailyexpense.BackColor = Color.FromArgb(17, 17, 17);
            button1.BackColor = Color.FromArgb(17, 17, 17);
            button2.BackColor = Color.FromArgb(187, 66, 0);
            customer.BackColor = Color.FromArgb(17, 17, 17);
            commodity.BackColor = Color.FromArgb(17, 17, 17);
        }

        private void commodity_Click(object sender, EventArgs e)
        {
            commodities UH = new commodities();
            AddControlsToPanel(UH);
            home.BackColor = Color.FromArgb(17, 17, 17);
            arrival.BackColor = Color.FromArgb(17, 17, 17);
            stock.BackColor = Color.FromArgb(17, 17, 17);
            stocks.BackColor = Color.FromArgb(17, 17, 17);
            proccessing.BackColor = Color.FromArgb(17, 17, 17);
            dispatch.BackColor = Color.FromArgb(17, 17, 17);
            reports.BackColor = Color.FromArgb(17, 17, 17);
            dailyexpense.BackColor = Color.FromArgb(17, 17, 17);
            button1.BackColor = Color.FromArgb(17, 17, 17);
            button2.BackColor = Color.FromArgb(17, 17, 17);
            customer.BackColor = Color.FromArgb(17, 17, 17);
            commodity.BackColor = Color.FromArgb(187, 66, 0);
        }

        private void dailyexpense_Click(object sender, EventArgs e)
        {
            expense UH = new expense();
            AddControlsToPanel(UH);
            home.BackColor = Color.FromArgb(17, 17, 17);
            arrival.BackColor = Color.FromArgb(17, 17, 17);
            stock.BackColor = Color.FromArgb(17, 17, 17);
            stocks.BackColor = Color.FromArgb(17, 17, 17);
            proccessing.BackColor = Color.FromArgb(17, 17, 17);
            dispatch.BackColor = Color.FromArgb(17, 17, 17);
            reports.BackColor = Color.FromArgb(17, 17, 17);
            dailyexpense.BackColor = Color.FromArgb(187, 66, 0);
            button1.BackColor = Color.FromArgb(17, 17, 17);
            button2.BackColor = Color.FromArgb(17, 17, 17);
            customer.BackColor = Color.FromArgb(17, 17, 17);
            commodity.BackColor = Color.FromArgb(17, 17, 17);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControls_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
