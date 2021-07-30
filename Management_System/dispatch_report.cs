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
    public partial class dispatch_report : Form
    {
        public dispatch_report()
        {
            InitializeComponent();
        }



        public dispatch_report(string vnumber)
        {
            InitializeComponent();

            string Query1 = "dispatchReport";
            SqlCommand MyCommand21 = new SqlCommand(Query1, connection.conString);
            MyCommand21.CommandType = CommandType.StoredProcedure;
            MyCommand21.Parameters.AddWithValue("@vnumber", vnumber);

            connection.conString.Close();
            connection.conString.Open();


            SqlDataAdapter MyAdapter1 = new SqlDataAdapter();
            MyAdapter1.SelectCommand = MyCommand21;
            DataSet ds1 = new DataSet();
            MyAdapter1.Fill(ds1, "dispatchReport");
            dispatchr cr = new dispatchr();
            cr.Database.Tables[0].SetDataSource(ds1);




            string Query2 = "sumofqtyweight";
            SqlCommand MyCommand2 = new SqlCommand(Query2, connection.conString);
            MyCommand2.CommandType = CommandType.StoredProcedure;
            MyCommand2.Parameters.AddWithValue("@vnumber", vnumber);

            connection.conString.Close();
            connection.conString.Open();


            SqlDataAdapter MyAdapter12 = new SqlDataAdapter();
            MyAdapter12.SelectCommand = MyCommand2;
            DataSet ds12 = new DataSet();
            MyAdapter12.Fill(ds12, "sumofqtyweight");
            
            cr.Database.Tables[1].SetDataSource(ds12);


            crystalReportViewer1.ReportSource = cr;

             
        }


        private void dispatch_report_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
