using CrystalDecisions.CrystalReports.Engine;
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
    public partial class arrival_report : Form
    {
        
        ReportDocument crys = new ReportDocument();
        public arrival_report()
        {
            InitializeComponent();
        }

        public arrival_report(string aid)
        {
            InitializeComponent();

            string Query1 = "SelectAllCustomers";
            SqlCommand MyCommand21 = new SqlCommand(Query1, connection.conString);
            MyCommand21.CommandType = CommandType.StoredProcedure;
            MyCommand21.Parameters.AddWithValue("@id", aid);

            connection.conString.Close();
            connection.conString.Open();
          

            SqlDataAdapter MyAdapter1 = new SqlDataAdapter();
            MyAdapter1.SelectCommand = MyCommand21;
            DataSet ds1 = new DataSet();
            MyAdapter1.Fill(ds1, "SelectAllCustomers");

            arrivalreport cr = new arrivalreport();
            cr.SetDataSource(ds1);

            crystalReportViewer1.ReportSource = cr;
        }


        private void arrival_report_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
