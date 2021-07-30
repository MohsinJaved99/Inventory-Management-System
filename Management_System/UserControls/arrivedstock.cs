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
    public partial class arrivedstock : UserControl
    {
        string ArrivalID;
        public arrivedstock()
        {
            InitializeComponent();
            Arrival_View();
            arrival_gridview.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 191, 191);
            arrival_gridview.DefaultCellStyle.SelectionForeColor = Color.Black;
            arrival_gridview.DefaultCellStyle.ForeColor = Color.Black;
        }


        public void Arrival_View()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select a.Arrival_Stock_ID as 'Arrival_Stock_ID',a.Arrival_Date as 'Arrival_Date',c.Customer_Name as 'Customer_Name',COALESCE(rc.Customer_Name, '-') as 'Received_From',COALESCE(a.Broker_Name, '-') as 'Broker_Name',a.Vehicle_Number as 'Vehicle_Number',a.Gate_Pass as 'Gate_Pass',com.Commodity_Name as 'Commodity_Name',COALESCE(a.Brand,'-') as 'Brand',bag.Bag_Name as 'Bag_Name',a.Quantity as 'Quantity',a.Pack_Weight as 'Pack_Weight',a.Net_Weight as 'Net_Weight',COALESCE(a.Remarks,'-') as 'Remarks' from arrival_stock a join customer c on a.Customer_ID=c.Customer_ID join commodity com on a.Commodity_ID=com.Commodity_ID join Bags bag on a.Bag_ID=bag.Bag_ID left join customer rc on rc.Customer_ID=a.Received_From order by a.Arrival_Stock_ID DESC", connection.conString);


            da.Fill(dt);

            Arrival_ID.DataPropertyName = dt.Columns["Arrival_Stock_ID"].ToString();
            Arrival_Date.DataPropertyName = dt.Columns["Arrival_Date"].ToString();
            Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
            Received_From.DataPropertyName = dt.Columns["Received_From"].ToString();
            Broker_Name.DataPropertyName = dt.Columns["Broker_Name"].ToString();
            Vehicle_Number.DataPropertyName = dt.Columns["Vehicle_Number"].ToString();
            Gate_Pass.DataPropertyName = dt.Columns["Gate_Pass"].ToString();
            Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
            Brand.DataPropertyName = dt.Columns["Brand"].ToString();
            Bag_Type.DataPropertyName = dt.Columns["Bag_Name"].ToString();
            Quantity.DataPropertyName = dt.Columns["Quantity"].ToString();
            Pack_Weight.DataPropertyName = dt.Columns["Pack_Weight"].ToString();
            Net_Weight.DataPropertyName = dt.Columns["Net_Weight"].ToString();
            Remarks.DataPropertyName = dt.Columns["Remarks"].ToString();

            arrival_gridview.DataSource = dt;

        }



        public void Arrival_View_Search(string searchfor, string data)
        {

            if (comboBox1.Text == "Arrival Date")
            {
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter("select a.Arrival_Stock_ID as 'Arrival_Stock_ID',a.Arrival_Date as 'Arrival_Date',c.Customer_Name as 'Customer_Name',COALESCE(rc.Customer_Name, '-') as 'Received_From',COALESCE(a.Broker_Name, '-') as 'Broker_Name',a.Vehicle_Number as 'Vehicle_Number',a.Gate_Pass as 'Gate_Pass',com.Commodity_Name as 'Commodity_Name',COALESCE(a.Brand,'-') as 'Brand',bag.Bag_Name as 'Bag_Name',a.Quantity as 'Quantity',a.Pack_Weight as 'Pack_Weight',a.Net_Weight as 'Net_Weight',COALESCE(a.Remarks,'-') as 'Remarks' from arrival_stock a join customer c on a.Customer_ID=c.Customer_ID join commodity com on a.Commodity_ID=com.Commodity_ID join Bags bag on a.Bag_ID=bag.Bag_ID left join customer rc on rc.Customer_ID=a.Received_From where " + searchfor + " like '%" + data + "%' order by a.Arrival_Stock_ID DESC", connection.conString);


                da.Fill(dt);

                Arrival_ID.DataPropertyName = dt.Columns["Arrival_Stock_ID"].ToString();
                Arrival_Date.DataPropertyName = dt.Columns["Arrival_Date"].ToString();
                Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
                Received_From.DataPropertyName = dt.Columns["Received_From"].ToString();
                Broker_Name.DataPropertyName = dt.Columns["Broker_Name"].ToString();
                Vehicle_Number.DataPropertyName = dt.Columns["Vehicle_Number"].ToString();
                Gate_Pass.DataPropertyName = dt.Columns["Gate_Pass"].ToString();
                Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
                Brand.DataPropertyName = dt.Columns["Brand"].ToString();
                Bag_Type.DataPropertyName = dt.Columns["Bag_Name"].ToString();
                Quantity.DataPropertyName = dt.Columns["Quantity"].ToString();
                Pack_Weight.DataPropertyName = dt.Columns["Pack_Weight"].ToString();
                Net_Weight.DataPropertyName = dt.Columns["Net_Weight"].ToString();
                Remarks.DataPropertyName = dt.Columns["Remarks"].ToString();

                arrival_gridview.DataSource = dt;
            }
            else
            {
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter("select a.Arrival_Stock_ID as 'Arrival_Stock_ID',a.Arrival_Date as 'Arrival_Date',c.Customer_Name as 'Customer_Name',COALESCE(rc.Customer_Name, '-') as 'Received_From',COALESCE(a.Broker_Name, '-') as 'Broker_Name',a.Vehicle_Number as 'Vehicle_Number',a.Gate_Pass as 'Gate_Pass',com.Commodity_Name as 'Commodity_Name',COALESCE(a.Brand,'-') as 'Brand',bag.Bag_Name as 'Bag_Name',a.Quantity as 'Quantity',a.Pack_Weight as 'Pack_Weight',a.Net_Weight as 'Net_Weight',COALESCE(a.Remarks,'-') as 'Remarks' from arrival_stock a join customer c on a.Customer_ID=c.Customer_ID join commodity com on a.Commodity_ID=com.Commodity_ID join Bags bag on a.Bag_ID=bag.Bag_ID left join customer rc on rc.Customer_ID=a.Received_From where " + searchfor + " like '" + data + "%'", connection.conString);


                da.Fill(dt);

                Arrival_ID.DataPropertyName = dt.Columns["Arrival_Stock_ID"].ToString();
                Arrival_Date.DataPropertyName = dt.Columns["Arrival_Date"].ToString();
                Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
                Received_From.DataPropertyName = dt.Columns["Received_From"].ToString();
                Broker_Name.DataPropertyName = dt.Columns["Broker_Name"].ToString();
                Vehicle_Number.DataPropertyName = dt.Columns["Vehicle_Number"].ToString();
                Gate_Pass.DataPropertyName = dt.Columns["Gate_Pass"].ToString();
                Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
                Brand.DataPropertyName = dt.Columns["Brand"].ToString();
                Bag_Type.DataPropertyName = dt.Columns["Bag_Name"].ToString();
                Quantity.DataPropertyName = dt.Columns["Quantity"].ToString();
                Pack_Weight.DataPropertyName = dt.Columns["Pack_Weight"].ToString();
                Net_Weight.DataPropertyName = dt.Columns["Net_Weight"].ToString();
                Remarks.DataPropertyName = dt.Columns["Remarks"].ToString();

                arrival_gridview.DataSource = dt;

            }



        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchtxt.Enabled = true;
        }

        private void searchtxt_TextChanged(object sender, EventArgs e)
        {
            if (searchtxt.Text == "")
            {
                Arrival_View();
            }
            else
            {
                if (comboBox1.Text == "Arrival Date")
                {
                    Arrival_View_Search("a.Arrival_Date", searchtxt.Text);
                }
                else if (comboBox1.Text == "Customer Name")
                {
                    Arrival_View_Search("c.Customer_Name", searchtxt.Text);
                }
                else if (comboBox1.Text == "Received From")
                {
                    Arrival_View_Search("rc.Customer_Name", searchtxt.Text);
                }
                else if (comboBox1.Text == "Vehicle Number")
                {
                    Arrival_View_Search("a.Vehicle_Number", searchtxt.Text);
                }
                else if (comboBox1.Text == "Gate Pass")
                {
                    Arrival_View_Search("a.Gate_Pass", searchtxt.Text);
                }
                else if (comboBox1.Text == "Commodity")
                {
                    Arrival_View_Search("com.Commodity_Name", searchtxt.Text);
                }
                else if (comboBox1.Text == "Brand")
                {
                    Arrival_View_Search("a.Brand", searchtxt.Text);
                }
                else if (comboBox1.Text == "Broker Name")
                {
                    Arrival_View_Search("a.Broker_Name", searchtxt.Text);
                }
                else if (comboBox1.Text == "Pack Weight")
                {
                    Arrival_View_Search("a.Pack_Weight", searchtxt.Text);
                }
                else if (comboBox1.Text == "Bag Type")
                {
                    Arrival_View_Search("bag.Bag_Name", searchtxt.Text);
                }
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ArrivalID != null && ArrivalID != "")
            {
                loginloading l = new loginloading();
                l.ShowDialog();
                    using (arrival_report ac = new arrival_report(ArrivalID))
                    {
                        l.Close();
                        ac.ShowDialog();
                        Arrival_View();
                        ArrivalID = "";
                    }
            }
            else
            {
                MessageBox.Show("Please Select A Row You Want To Edit");
            }
        }

        private void arrival_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in arrival_gridview.SelectedRows)
            {
                ArrivalID = row.Cells[0].Value.ToString();
            }
        }
    }
}
