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
    public partial class preports : Form
    {
        public preports()
        {
            InitializeComponent();
        }

        public preports(string prnumber)
        {
            InitializeComponent();


            string Query10 = "reportinput";
            SqlCommand MyCommand210 = new SqlCommand(Query10, connection.conString);
            MyCommand210.CommandType = CommandType.StoredProcedure;
            MyCommand210.Parameters.AddWithValue("@process_number", Convert.ToInt32(prnumber));

            connection.conString.Close();
            connection.conString.Open();


            SqlDataAdapter MyAdapter10 = new SqlDataAdapter();
            MyAdapter10.SelectCommand = MyCommand210;
            DataSet ds10 = new DataSet();
            MyAdapter10.Fill(ds10, "reportinput");

            processreport cr = new processreport();

            cr.Database.Tables[0].SetDataSource(ds10);


            string Query1 = "reportinput";
            SqlCommand MyCommand21 = new SqlCommand(Query1, connection.conString);
            MyCommand21.CommandType = CommandType.StoredProcedure;
            MyCommand21.Parameters.AddWithValue("@process_number", Convert.ToInt32(prnumber));
            


            SqlDataAdapter MyAdapter1 = new SqlDataAdapter();
            MyAdapter1.SelectCommand = MyCommand21;
            DataSet ds1 = new DataSet();
            MyAdapter1.Fill(ds1, "reportinput");
            

            cr.Subreports[0].Database.Tables[0].SetDataSource(ds1);




            string Query2 = "sumofprocessinput";
            SqlCommand MyCommand2 = new SqlCommand(Query2, connection.conString);
            MyCommand2.CommandType = CommandType.StoredProcedure;
            MyCommand2.Parameters.AddWithValue("@process_number", Convert.ToInt32(prnumber));



            SqlDataAdapter MyAdapter12 = new SqlDataAdapter();
            MyAdapter12.SelectCommand = MyCommand2;
            DataSet ds12 = new DataSet();
            MyAdapter12.Fill(ds12, "sumofprocessinput");

            cr.Subreports[0].Database.Tables[1].SetDataSource(ds12);







            string Query12 = "reportoutput";
            SqlCommand MyCommand211 = new SqlCommand(Query12, connection.conString);
            MyCommand211.CommandType = CommandType.StoredProcedure;
            MyCommand211.Parameters.AddWithValue("@process_number", Convert.ToInt32(prnumber));



            SqlDataAdapter MyAdapter11 = new SqlDataAdapter();
            MyAdapter11.SelectCommand = MyCommand211;
            DataSet ds11 = new DataSet();
            MyAdapter11.Fill(ds11, "reportoutput");
            

            cr.Subreports[1].Database.Tables[0].SetDataSource(ds11);




            string Query29 = "sumofprocessoutput";
            SqlCommand MyCommand29 = new SqlCommand(Query29, connection.conString);
            MyCommand29.CommandType = CommandType.StoredProcedure;
            MyCommand29.Parameters.AddWithValue("@process_number", Convert.ToInt32(prnumber));

    


            SqlDataAdapter MyAdapter129 = new SqlDataAdapter();
            MyAdapter129.SelectCommand = MyCommand29;
            DataSet ds129 = new DataSet();
            MyAdapter129.Fill(ds129, "sumofprocessoutput");

            cr.Subreports[1].Database.Tables[1].SetDataSource(ds129);








            crystalReportViewer1.ReportSource = cr;
            connection.conString.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
