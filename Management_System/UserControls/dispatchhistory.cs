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
    public partial class dispatchhistory : UserControl
    {
        public dispatchhistory()
        {
            InitializeComponent();
            Dispatch_View();

            dispatch_gridview.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 191, 191);
            dispatch_gridview.DefaultCellStyle.SelectionForeColor = Color.Black;
            dispatch_gridview.DefaultCellStyle.ForeColor = Color.Black;
        }
        string Vehiclenumber,gatepass;
        public void Dispatch_View()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select a.Dispatch_ID as 'Dispatch_ID',a.Dispatch_Date as 'Dispatch_Date',c.Customer_Name as 'Customer_Name',a.Vehicle_Number as 'Vehicle_Number',a.Gate_Pass as 'Gate_Pass',com.Commodity_Name as 'Commodity_Name',COALESCE(a.Brand,'-') as 'Brand',bag.Bag_Name as 'Bag_Name',a.Quantity as 'Quantity',a.Pack_Weight as 'Pack_Weight',a.Net_Weight as 'Net_Weight',COALESCE(a.Remarks,'-') as 'Remarks' from dispatch a join customer c on a.Customer_ID=c.Customer_ID join commodity com on a.Commodity_ID=com.Commodity_ID join Bags bag on a.Bag_ID=bag.Bag_ID order by a.Dispatch_ID DESC", connection.conString);


            da.Fill(dt);

            Dispatch_ID.DataPropertyName = dt.Columns["Dispatch_ID"].ToString();
            Dispatch_Date.DataPropertyName = dt.Columns["Dispatch_Date"].ToString();
            Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
            Vehicle_Number.DataPropertyName = dt.Columns["Vehicle_Number"].ToString();
            Gate_Pass.DataPropertyName = dt.Columns["Gate_Pass"].ToString();
            Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
            Brand.DataPropertyName = dt.Columns["Brand"].ToString();
            Bag_Type.DataPropertyName = dt.Columns["Bag_Name"].ToString();
            Quantity.DataPropertyName = dt.Columns["Quantity"].ToString();
            Pack_Weight.DataPropertyName = dt.Columns["Pack_Weight"].ToString();
            Net_Weight.DataPropertyName = dt.Columns["Net_Weight"].ToString();
            Remarks.DataPropertyName = dt.Columns["Remarks"].ToString();

            dispatch_gridview.DataSource = dt;

        }


        public void Dispatch_View_Search(string searchfor, string data)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select a.Dispatch_ID as 'Dispatch_ID',a.Dispatch_Date as 'Dispatch_Date',c.Customer_Name as 'Customer_Name',a.Vehicle_Number as 'Vehicle_Number',a.Gate_Pass as 'Gate_Pass',com.Commodity_Name as 'Commodity_Name',COALESCE(a.Brand,'-') as 'Brand',bag.Bag_Name as 'Bag_Name',a.Quantity as 'Quantity',a.Pack_Weight as 'Pack_Weight',a.Net_Weight as 'Net_Weight',COALESCE(a.Remarks,'-') as 'Remarks' from dispatch a join customer c on a.Customer_ID=c.Customer_ID join commodity com on a.Commodity_ID=com.Commodity_ID join Bags bag on a.Bag_ID=bag.Bag_ID where " + searchfor + " like '%" + data + "%' order by a.Dispatch_ID DESC", connection.conString);


            da.Fill(dt);

            Dispatch_ID.DataPropertyName = dt.Columns["Dispatch_ID"].ToString();
            Dispatch_Date.DataPropertyName = dt.Columns["Dispatch_Date"].ToString();
            Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
            Vehicle_Number.DataPropertyName = dt.Columns["Vehicle_Number"].ToString();
            Gate_Pass.DataPropertyName = dt.Columns["Gate_Pass"].ToString();
            Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
            Brand.DataPropertyName = dt.Columns["Brand"].ToString();
            Bag_Type.DataPropertyName = dt.Columns["Bag_Name"].ToString();
            Quantity.DataPropertyName = dt.Columns["Quantity"].ToString();
            Pack_Weight.DataPropertyName = dt.Columns["Pack_Weight"].ToString();
            Net_Weight.DataPropertyName = dt.Columns["Net_Weight"].ToString();
            Remarks.DataPropertyName = dt.Columns["Remarks"].ToString();

            dispatch_gridview.DataSource = dt;

        }

        private void arrival_gridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchtxt.Enabled = true;
        }

        private void searchtxt_TextChanged(object sender, EventArgs e)
        {
            if (searchtxt.Text == "")
            {
                Dispatch_View();
            }
            else
            {
                if (comboBox2.Text == "Arrival Date")
                {
                    Dispatch_View_Search("a.Arrival_Date", searchtxt.Text);
                }
                else if (comboBox2.Text == "Customer Name")
                {
                    Dispatch_View_Search("c.Customer_Name", searchtxt.Text);
                }
                else if (comboBox2.Text == "Vehicle Number")
                {
                    Dispatch_View_Search("a.Vehicle_Number", searchtxt.Text);
                }
                else if (comboBox2.Text == "Gate Pass")
                {
                    Dispatch_View_Search("a.Gate_Pass", searchtxt.Text);
                }
                else if (comboBox2.Text == "Commodity")
                {
                    Dispatch_View_Search("com.Commodity_Name", searchtxt.Text);
                }
                else if (comboBox2.Text == "Brand")
                {
                    Dispatch_View_Search("a.Brand", searchtxt.Text);
                }
                else if (comboBox2.Text == "Broker Name")
                {
                    Dispatch_View_Search("a.Broker_Name", searchtxt.Text);
                }
                else if (comboBox2.Text == "Pack Weight")
                {
                    Dispatch_View_Search("a.Pack_Weight", searchtxt.Text);
                }
                else if (comboBox2.Text == "Bag Type")
                {
                    Dispatch_View_Search("bag.Bag_Name", searchtxt.Text);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Vehiclenumber != null && Vehiclenumber != "")
            {
                loginloading l = new loginloading();
                l.ShowDialog();
                    using (dispatch_report ac = new dispatch_report(Vehiclenumber))
                    {
                    l.Close();
                    ac.ShowDialog();
                        Dispatch_View();
                        Vehiclenumber = "";
                    }
                
            }
            else
            {
                MessageBox.Show("Please Select A Row You Want To Edit");
            }
        }

        private void dispatch_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dispatch_gridview.SelectedRows)
            {
                Vehiclenumber = row.Cells["Vehicle_Number"].Value.ToString();
                gatepass = row.Cells["Gate_Pass"].Value.ToString();
            }
          
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
