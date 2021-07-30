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
    public partial class Arrival : UserControl
    {
        public Arrival()
        {
            InitializeComponent();
            Arrival_View();
            arrival_gridview.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 191, 191);
            arrival_gridview.DefaultCellStyle.SelectionForeColor = Color.Black;
            arrival_gridview.DefaultCellStyle.ForeColor = Color.Black;

        }

        string Gatepass,ArrivalID;
        public void Arrival_View()
        {
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter("select a.Arrival_ID as 'Arrival_ID',a.Arrival_Date as 'Arrival_Date',c.Customer_Name as 'Customer_Name',COALESCE(rc.Customer_Name, '-') as 'Received_From',COALESCE(a.Broker_Name, '-') as 'Broker_Name',a.Vehicle_Number as 'Vehicle_Number',a.Gate_Pass as 'Gate_Pass',com.Commodity_Name as 'Commodity_Name',COALESCE(a.Brand,'-') as 'Brand',bag.Bag_Name as 'Bag_Name',a.Quantity as 'Quantity',a.Pack_Weight as 'Pack_Weight',a.Net_Weight as 'Net_Weight',COALESCE(a.Remarks,'-') as 'Remarks' from arrival a join customer c on a.Customer_ID=c.Customer_ID join commodity com on a.Commodity_ID=com.Commodity_ID join Bags bag on a.Bag_ID=bag.Bag_ID left join customer rc on rc.Customer_ID=a.Received_From where Quantity>0", connection.conString);


                da.Fill(dt);

                Arrival_ID.DataPropertyName = dt.Columns["Arrival_ID"].ToString();
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



        public void Arrival_View_Search(string searchfor,string data)
        {

            if(comboBox1.Text=="Arrival Date")
            {
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter("select a.Arrival_ID as 'Arrival_ID',a.Arrival_Date as 'Arrival_Date',c.Customer_Name as 'Customer_Name',COALESCE(rc.Customer_Name, '-') as 'Received_From',COALESCE(a.Broker_Name, '-') as 'Broker_Name',a.Vehicle_Number as 'Vehicle_Number',a.Gate_Pass as 'Gate_Pass',com.Commodity_Name as 'Commodity_Name',COALESCE(a.Brand,'-') as 'Brand',bag.Bag_Name as 'Bag_Name',a.Quantity as 'Quantity',a.Pack_Weight as 'Pack_Weight',a.Net_Weight as 'Net_Weight',COALESCE(a.Remarks,'-') as 'Remarks' from arrival a join customer c on a.Customer_ID=c.Customer_ID join commodity com on a.Commodity_ID=com.Commodity_ID join Bags bag on a.Bag_ID=bag.Bag_ID left join customer rc on rc.Customer_ID=a.Received_From where " + searchfor + " like '%" + data + "%' and Quantity>0 order by a.Arrival_ID DESC", connection.conString);


                da.Fill(dt);

                Arrival_ID.DataPropertyName = dt.Columns["Arrival_ID"].ToString();
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

                SqlDataAdapter da = new SqlDataAdapter("select a.Arrival_ID as 'Arrival_ID',a.Arrival_Date as 'Arrival_Date',c.Customer_Name as 'Customer_Name',COALESCE(rc.Customer_Name, '-') as 'Received_From',COALESCE(a.Broker_Name, '-') as 'Broker_Name',a.Vehicle_Number as 'Vehicle_Number',a.Gate_Pass as 'Gate_Pass',com.Commodity_Name as 'Commodity_Name',COALESCE(a.Brand,'-') as 'Brand',bag.Bag_Name as 'Bag_Name',a.Quantity as 'Quantity',a.Pack_Weight as 'Pack_Weight',a.Net_Weight as 'Net_Weight',COALESCE(a.Remarks,'-') as 'Remarks' from arrival a join customer c on a.Customer_ID=c.Customer_ID join commodity com on a.Commodity_ID=com.Commodity_ID join Bags bag on a.Bag_ID=bag.Bag_ID left join customer rc on rc.Customer_ID=a.Received_From where " + searchfor + " like '" + data + "%' and Quantity>0 order by a.Arrival_ID DESC", connection.conString);


                da.Fill(dt);

                Arrival_ID.DataPropertyName = dt.Columns["Arrival_ID"].ToString();
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



        private void home_Click(object sender, EventArgs e)
        {
            using (Add_Arrival ad = new Add_Arrival())
            {
                ad.ShowDialog();
                Arrival_View();
            }
           
        }





        private void product_brand_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        private string Delete_Arrival(string gp)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM arrival WHERE Gate_Pass = @gp", connection.conString);
            cmd.Parameters.AddWithValue("@gp", gp);

            SqlCommand cmd1 = new SqlCommand("DELETE FROM arrival_stock WHERE Gate_Pass = @gp", connection.conString);
            cmd1.Parameters.AddWithValue("@gp", gp);

            if (connection.conString.State != ConnectionState.Open)
            {
                connection.conString.Open();
            }

            int i = cmd.ExecuteNonQuery();
            int i1 = cmd1.ExecuteNonQuery();

            if (connection.conString.State == ConnectionState.Open)
            {
                connection.conString.Close();
            }

            if (i > 0 && i1>0)
            {
                return "Data Deleted From System Successfully";
            }
            else
            {
                return "Data Not Deleted From System Successfully";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Did you want to delete that arrival?", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (Gatepass != null && Gatepass != "")
                    {
                        string msg = Delete_Arrival(Gatepass);
                        MessageBox.Show(msg);
                        Arrival_View();
                    }
                    else
                    {
                        MessageBox.Show("Please Select A Row You Want To Delete.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You Can't Delete This Record Because This Arrival Exists Somewhere.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Gatepass != null && Gatepass != "" && ArrivalID != null && ArrivalID != "")
            {
                using (Add_Arrival ac = new Add_Arrival(Gatepass, ArrivalID))
                {
                    ac.ShowDialog();
                    Arrival_View();
                    Gatepass = "";
                }
            }
            else
            {
                MessageBox.Show("Please Select A Row You Want To Edit");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchtxt.Enabled = true;
        }

        private void arrival_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in arrival_gridview.SelectedRows)
            {
                ArrivalID = row.Cells["Arrival_ID"].Value.ToString();
                Gatepass = row.Cells["Gate_Pass"].Value.ToString();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //filtertxt.Enabled = true;
            //if(comboBox2.Text=="All")
            //{
            //    if (searchtxt.Text == "")
            //    {
            //        filtertxt.CustomFormat = "-";
            //        filtertxt.Enabled = false;
            //        Arrival_View();
            //    }
            //    else
            //    {
            //        filtertxt.CustomFormat = "-";
            //        filtertxt.Enabled = false;
            //        if (comboBox1.Text == "Arrival Date")
            //        {
            //            Arrival_View_Search("a.Arrival_Date", searchtxt.Text);
            //        }
            //        else if (comboBox1.Text == "Customer Name")
            //        {
            //            Arrival_View_Search("c.Customer_Name", searchtxt.Text);
            //        }
            //        else if (comboBox1.Text == "Received From")
            //        {
            //            Arrival_View_Search("rc.Customer_Name", searchtxt.Text);
            //        }
            //        else if (comboBox1.Text == "Vehicle Number")
            //        {
            //            Arrival_View_Search("a.Vehicle_Number", searchtxt.Text);
            //        }
            //        else if (comboBox1.Text == "Gate Pass")
            //        {
            //            Arrival_View_Search("a.Gate_Pass", searchtxt.Text);
            //        }
            //        else if (comboBox1.Text == "Commodity")
            //        {
            //            Arrival_View_Search("com.Commodity_Name", searchtxt.Text);
            //        }
            //        else if (comboBox1.Text == "Brand")
            //        {
            //            Arrival_View_Search("a.Brand", searchtxt.Text);
            //        }
            //        else if (comboBox1.Text == "Broker Name")
            //        {
            //            Arrival_View_Search("a.Broker_Name", searchtxt.Text);
            //        }
            //        else if (comboBox1.Text == "Pack Weight")
            //        {
            //            Arrival_View_Search("a.Pack_Weight", searchtxt.Text);
            //        }
            //        else if (comboBox1.Text == "Bag Type")
            //        {
            //            Arrival_View_Search("bag.Bag_Name", searchtxt.Text);
            //        }
            //    }
            //}
            //else if(comboBox2.Text == "Month")
            //{
            //    filtertxt.CustomFormat = "MMMM";
            //}
            //else if (comboBox2.Text == "Year")
            //{
            //    filtertxt.CustomFormat = "yyyy";
            //}
        }

        private void filtertxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void filtertxt_ValueChanged(object sender, EventArgs e)
        {
            //if (searchtxt.Text == "")
            //{
            //    Arrival_View();
            //}
            //else
            //{
            //    if (comboBox1.Text == "Arrival Date")
            //    {
            //        Arrival_View_Search("a.Arrival_Date", searchtxt.Text);
            //    }
            //    else if (comboBox1.Text == "Customer Name")
            //    {
            //        Arrival_View_Search("c.Customer_Name", searchtxt.Text);
            //    }
            //    else if (comboBox1.Text == "Received From")
            //    {
            //        Arrival_View_Search("rc.Customer_Name", searchtxt.Text);
            //    }
            //    else if (comboBox1.Text == "Vehicle Number")
            //    {
            //        Arrival_View_Search("a.Vehicle_Number", searchtxt.Text);
            //    }
            //    else if (comboBox1.Text == "Gate Pass")
            //    {
            //        Arrival_View_Search("a.Gate_Pass", searchtxt.Text);
            //    }
            //    else if (comboBox1.Text == "Commodity")
            //    {
            //        Arrival_View_Search("com.Commodity_Name", searchtxt.Text);
            //    }
            //    else if (comboBox1.Text == "Brand")
            //    {
            //        Arrival_View_Search("a.Brand", searchtxt.Text);
            //    }
            //    else if (comboBox1.Text == "Broker Name")
            //    {
            //        Arrival_View_Search("a.Broker_Name", searchtxt.Text);
            //    }
            //    else if (comboBox1.Text == "Pack Weight")
            //    {
            //        Arrival_View_Search("a.Pack_Weight", searchtxt.Text);
            //    }
            //    else if (comboBox1.Text == "Bag Type")
            //    {
            //        Arrival_View_Search("bag.Bag_Name", searchtxt.Text);
            //    }
            //}
        }

        private void searchtxt_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
