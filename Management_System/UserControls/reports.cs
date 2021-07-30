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
    public partial class reports : UserControl
    {
        string prnumber;
        public reports()
        {
            InitializeComponent();
            fetchinput();

            inputgrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 191, 191);
            inputgrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            inputgrid.DefaultCellStyle.ForeColor = Color.Black;


            outputgrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 191, 191);
            outputgrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            outputgrid.DefaultCellStyle.ForeColor = Color.Black;
        }
        int outsum;
        string proccesid="";
        private void reports_Load(object sender, EventArgs e)
        {
          
            //DataTable dt1 = new DataTable();
            //SqlDataAdapter da1 = new SqlDataAdapter("select o.Proccess_Out_ID,o.Proccess_Out_Date,com.Commodity_Name,o.PO_Brand,o.PO_Qunatity,o.PO_Pack_Weight,o.PO_Net_Weight,o.PO_Ratio from proccess_out o join commodity com on o.PO_Commodity=com.Commodity_ID where Proccess_Number='820225181'", connection.conString);
            //da1.Fill(dt1);

            //foreach(DataRow row in dt1.Rows)
            //{
            //    outsum += Convert.ToInt32(row["PO_Net_Weight"].ToString());
            //}

            ////Arrival_ID.DataPropertyName = dt.Columns["Arrival_ID"].ToString();
            ////Arrival_Date.DataPropertyName = dt.Columns["Arrival_Date"].ToString();
            ////Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
            ////Vehicle_Number.DataPropertyName = dt.Columns["Vehicle_Number"].ToString();
            ////Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
            ////Quantityy.DataPropertyName = dt.Columns["PI_Quantity"].ToString();
            ////Weight.DataPropertyName = dt.Columns["Weight"].ToString();
            ////Baardana.DataPropertyName = dt.Columns["Baardana"].ToString();
            ////Net_Weight.DataPropertyName = dt.Columns["PI_Net_Weight"].ToString();
            ////proccess_id.DataPropertyName = dt.Columns["Proccess_Number"].ToString();

            //dataGridView2.DataSource = dt1;


            //int shortage = insum - outsum;
            //float shortageratio = float.Parse(outsum.ToString()) / float.Parse(insum.ToString());
            //float ss = shortageratio * 100;

            //float ss1 = 100 - ss;
            //label1.Text = "Shortage : " + shortage.ToString() +"Kg";
            //label2.Text = "Shortage Ratio : " + ss1.ToString() ;
        }
        
        public void fetchinput()
        {


                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter("select p.Arrival_ID,a.Vehicle_Number,p.Proccess_Number,c.Customer_Name,com.Commodity_Name,p.Proccess_In_Date,p.PI_Quantity,p.PI_Net_Weight,p.Weight,p.Baardana from proccess_in p join arrival a on p.Arrival_ID=a.Arrival_ID join customer c on c.Customer_ID=a.Customer_ID join commodity com on a.Commodity_ID=com.Commodity_ID where p.Status='Complete' order by p.Arrival_ID desc", connection.conString);


                da.Fill(dt);

                
                Arrival_ID.DataPropertyName = dt.Columns["Arrival_ID"].ToString();
                Intput_Date.DataPropertyName = dt.Columns["Proccess_In_Date"].ToString();
                Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
                Vehicle_Number.DataPropertyName = dt.Columns["Vehicle_Number"].ToString();
                Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
                Quantityy.DataPropertyName = dt.Columns["PI_Quantity"].ToString();
                Weight.DataPropertyName = dt.Columns["Weight"].ToString();
                Baardana.DataPropertyName = dt.Columns["Baardana"].ToString();
                Net_Weight.DataPropertyName = dt.Columns["PI_Net_Weight"].ToString();
                proccess_id.DataPropertyName = dt.Columns["Proccess_Number"].ToString();
                inputgrid.DataSource = dt;
            
        }
        public void fetchinputbysearch(string searchfor, string data)
        {

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select p.Arrival_ID,a.Vehicle_Number,p.Proccess_Number,c.Customer_Name,com.Commodity_Name,p.Proccess_In_Date,p.PI_Quantity,p.PI_Net_Weight,p.Weight,p.Baardana from proccess_in p join arrival a on p.Arrival_ID=a.Arrival_ID join customer c on c.Customer_ID=a.Customer_ID join commodity com on a.Commodity_ID=com.Commodity_ID where " + searchfor + " like '" + data + "%' and p.Status='Complete' order by p.Arrival_ID desc", connection.conString);


            da.Fill(dt);


            Arrival_ID.DataPropertyName = dt.Columns["Arrival_ID"].ToString();
            Intput_Date.DataPropertyName = dt.Columns["Proccess_In_Date"].ToString();
            Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
            Vehicle_Number.DataPropertyName = dt.Columns["Vehicle_Number"].ToString();
            Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
            Quantityy.DataPropertyName = dt.Columns["PI_Quantity"].ToString();
            Weight.DataPropertyName = dt.Columns["Weight"].ToString();
            Baardana.DataPropertyName = dt.Columns["Baardana"].ToString();
            Net_Weight.DataPropertyName = dt.Columns["PI_Net_Weight"].ToString();
            proccess_id.DataPropertyName = dt.Columns["Proccess_Number"].ToString();
            inputgrid.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchtxt.Enabled = true;
        }

        private void searchtxt_TextChanged(object sender, EventArgs e)
        {
            if (searchtxt.Text == "")
            {
                fetchinput();
            }
            else
            {
                if (comboBox1.Text == "Input Date")
                {
                    fetchinputbysearch("p.Proccess_In_Date", searchtxt.Text);
                }
                else if (comboBox1.Text == "Customer Name")
                {
                    fetchinputbysearch("c.Customer_Name", searchtxt.Text);
                }
                else if (comboBox1.Text == "Vehicle Number")
                {
                    fetchinputbysearch("a.Vehicle_Number", searchtxt.Text);
                }
                else if (comboBox1.Text == "Report Number")
                {
                    fetchinputbysearch("p.Proccess_Number", searchtxt.Text);
                }
            }
        }
       
        float ratiosum;
        int count = 0;
        string insum;
        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void inputgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void inputgrid_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void inputgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in inputgrid.SelectedRows)
            {
                proccesid = row.Cells["proccess_id"].Value.ToString();
            }
            
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void home_Click(object sender, EventArgs e)
        {

            

        }

        private void home_Click_1(object sender, EventArgs e)
        {
            if (proccesid != null && proccesid != "")
            {
                int selectedrowindex = inputgrid.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = inputgrid.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["proccess_id"].Value);



                outsum = 0;
                ratiosum = 0;
                SqlDataAdapter cmdd = new SqlDataAdapter("select sum(PI_Net_Weight) as 'netweight',sum(PI_Quantity) as 'Quantity',sum(Weight) as 'weight',sum(Baardana) as 'bardana' from proccess_in where Proccess_Number='" + proccesid + "'", connection.conString);

                DataTable dtt = new DataTable();

                cmdd.Fill(dtt);

                foreach (DataRow r in dtt.Rows)
                {
                    insum = r["netweight"].ToString();


                    totalqty.Text = "QUANTITY\n" + r["Quantity"].ToString();
                    totalweightt.Text = "WEIGHT\n" + r["weight"].ToString() + " Kg";
                    if (r["bardana"].ToString() == "")
                    {
                        totalbardana.Text = "BARDANA\n" + "0 Kg";
                    }
                    else
                    {
                        totalbardana.Text = "BARDANA\n" + r["bardana"].ToString() + " Kg";
                    }
                    totalnetwieghtt.Text = "NET WIEGHT\n" + r["netweight"].ToString() + " Kg";
                }




                connection.conString.Close();








                //proccesid = row.Cells["proccess_id"].Value.ToString();

                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter("select o.Proccess_Out_Date,com.Commodity_Name,o.PO_Brand,o.PO_Qunatity,o.PO_Pack_Weight,o.PO_Net_Weight,o.PO_Ratio from out_proccess_report o join commodity com on o.PO_Commodity=com.Commodity_ID where Proccess_Number='" + proccesid + "'", connection.conString);
                da1.Fill(dt1);

                foreach (DataRow row1 in dt1.Rows)
                {
                    outsum += Convert.ToInt32(row1["PO_Net_Weight"].ToString());
                    ratiosum += float.Parse(row1["PO_Ratio"].ToString());
                }



                Output_Date.DataPropertyName = dt1.Columns["Proccess_Out_Date"].ToString();
                Product.DataPropertyName = dt1.Columns["Commodity_Name"].ToString();
                Brand.DataPropertyName = dt1.Columns["PO_Brand"].ToString();
                Qty.DataPropertyName = dt1.Columns["PO_Qunatity"].ToString();
                Pack.DataPropertyName = dt1.Columns["PO_Pack_Weight"].ToString();
                OutputWeight.DataPropertyName = dt1.Columns["PO_Net_Weight"].ToString();
                Ratio.DataPropertyName = dt1.Columns["PO_Ratio"].ToString();

                int shortage = Convert.ToInt32(insum) - outsum;
                float shortageratio = float.Parse(outsum.ToString()) / float.Parse(insum);
                float ss = shortageratio * 100;

                float ss1 = 100 - ss;

                //dt1.Rows.Add("1", "1", "OUTPUT", "1", "1", outsum.ToString(), ratiosum.ToString("0.00"));
                //dt1.Rows.Add("1", "1", "SHORTAGE", "1", "1", shortage.ToString(), ss1.ToString("0.00"));
                //dt1.Rows.Add("1", "1", "TOTAL", "1", "1", insum.ToString(), "100.00");
                outputgrid.DataSource = dt1;



                shortagetxt.Text = "SHORTAGE\n" + shortage.ToString() + "Kg (" + ss1.ToString("0.00") + "%)";
                output.Text = "OUTPUT\n" + outsum.ToString() + "Kg (" + ratiosum.ToString("0.00") + "%)";
                outputnetweight.Text = "WEIGHT\n" + insum.ToString() + "Kg (" + (ratiosum + ss1).ToString("0.00") + "%)";


            }
            else
            {
                MessageBox.Show("Please Select A Row You Want To Edit");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (proccesid != null && proccesid != "")
            {
                loginloading l = new loginloading();
                l.ShowDialog();
                    using (preports acc = new preports(proccesid))
                    {
                        l.Close();
                        acc.ShowDialog();
                        proccesid = "";
                    }
                
            }
            else
            {
                MessageBox.Show("Please Select A Row You Want To Edit");
            }
        }
    }
}
