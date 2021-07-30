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
    public partial class stocks : UserControl
    {
        public stocks()
        {
            InitializeComponent();

            stock_gridview.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 191, 191);
            stock_gridview.DefaultCellStyle.SelectionForeColor = Color.Black;
            stock_gridview.DefaultCellStyle.ForeColor = Color.Black;
            Stock();

            string query = "select * from commodity";

            SqlDataReader sdr;
            SqlCommand cmd = new SqlCommand(query, connection.conString);
            connection.conString.Close();
            connection.conString.Open();


            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                commodities.DisplayMember = "Text";
                commodities.ValueMember = "Value";
                commodities.Items.Add(new Combobox(sdr["Commodity_Name"].ToString(), Convert.ToInt32(sdr["Commodity_ID"].ToString())));
            }

            sdr.Close();
            connection.conString.Close();
        }

        public void Stock()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select c.Customer_Name,o.Proccess_Out_Date,com.Commodity_Name,o.PO_Brand,o.PO_Qunatity,o.PO_Pack_Weight,o.PO_Net_Weight from proccess_out o join customer c on c.Customer_ID=o.Customer_ID join commodity com on o.PO_Commodity=com.Commodity_ID where o.PO_Qunatity>0", connection.conString);


            da.Fill(dt);

            Stock_Date.DataPropertyName = dt.Columns["Proccess_Out_Date"].ToString();
            Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
            Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
            Brand.DataPropertyName = dt.Columns["PO_Brand"].ToString();
            Quantity.DataPropertyName = dt.Columns["PO_Qunatity"].ToString();
            Pack_Weight.DataPropertyName = dt.Columns["PO_Pack_Weight"].ToString();
            Net_Weight.DataPropertyName = dt.Columns["PO_Net_Weight"].ToString();

            stock_gridview.DataSource = dt;
        }

        public void Stock_CommodityFilter(string data)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select c.Customer_Name,o.Proccess_Out_Date,com.Commodity_Name,o.PO_Brand,o.PO_Qunatity,o.PO_Pack_Weight,o.PO_Net_Weight from proccess_out o join customer c on c.Customer_ID=o.Customer_ID join commodity com on o.PO_Commodity=com.Commodity_ID where com.Commodity_Name='" + data+ "' and o.PO_Qunatity>0", connection.conString);


            da.Fill(dt);

            Stock_Date.DataPropertyName = dt.Columns["Proccess_Out_Date"].ToString();
            Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
            Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
            Brand.DataPropertyName = dt.Columns["PO_Brand"].ToString();
            Quantity.DataPropertyName = dt.Columns["PO_Qunatity"].ToString();
            Pack_Weight.DataPropertyName = dt.Columns["PO_Pack_Weight"].ToString();
            Net_Weight.DataPropertyName = dt.Columns["PO_Net_Weight"].ToString();

            stock_gridview.DataSource = dt;
        }


        public void Stock_withsearch(string search, string sreachdata)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select c.Customer_Name,o.Proccess_Out_Date,com.Commodity_Name,o.PO_Brand,o.PO_Qunatity,o.PO_Pack_Weight,o.PO_Net_Weight from proccess_out o join customer c on c.Customer_ID=o.Customer_ID join commodity com on o.PO_Commodity=com.Commodity_ID where " + search + " like '%" + sreachdata + "%' and o.PO_Qunatity>0", connection.conString);


            da.Fill(dt);

            Stock_Date.DataPropertyName = dt.Columns["Proccess_Out_Date"].ToString();
            Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
            Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
            Brand.DataPropertyName = dt.Columns["PO_Brand"].ToString();
            Quantity.DataPropertyName = dt.Columns["PO_Qunatity"].ToString();
            Pack_Weight.DataPropertyName = dt.Columns["PO_Pack_Weight"].ToString();
            Net_Weight.DataPropertyName = dt.Columns["PO_Net_Weight"].ToString();

            stock_gridview.DataSource = dt;
        }


        public void Stock_CommodityFilterwithsearch(string search,string sreachdata,string data)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select c.Customer_Name,o.Proccess_Out_Date,com.Commodity_Name,o.PO_Brand,o.PO_Qunatity,o.PO_Pack_Weight,o.PO_Net_Weight from proccess_out o join customer c on c.Customer_ID=o.Customer_ID join commodity com on o.PO_Commodity=com.Commodity_ID where com.Commodity_Name='" + data + "' and  " + search + " like '%" + sreachdata + "%' and o.PO_Qunatity>0", connection.conString);


            da.Fill(dt);

            Stock_Date.DataPropertyName = dt.Columns["Proccess_Out_Date"].ToString();
            Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
            Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
            Brand.DataPropertyName = dt.Columns["PO_Brand"].ToString();
            Quantity.DataPropertyName = dt.Columns["PO_Qunatity"].ToString();
            Pack_Weight.DataPropertyName = dt.Columns["PO_Pack_Weight"].ToString();
            Net_Weight.DataPropertyName = dt.Columns["PO_Net_Weight"].ToString();

            stock_gridview.DataSource = dt;
        }

        private void arrival_gridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int sumquantity;
        int sumnetwight;
        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void commodities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (commodities.SelectedIndex != -1) {
                if (comboBox1.SelectedIndex == -1 || searchtxt.Text == "")
                {
                    Stock_CommodityFilter(commodities.Text);
                }
                else
                {
                    if (comboBox1.Text == "Stock Date")
                    {
                        Stock_CommodityFilterwithsearch("o.Proccess_Out_Date", searchtxt.Text, commodities.Text);
                    }
                    else if (comboBox1.Text == "Customer Name")
                    {
                        Stock_CommodityFilterwithsearch("c.Customer_Name", searchtxt.Text, commodities.Text);
                    }
                    else if (comboBox1.Text == "Brand")
                    {
                        Stock_CommodityFilterwithsearch("o.PO_Brand", searchtxt.Text, commodities.Text);
                    }
                    else if (comboBox1.Text == "Pack Weight")
                    {
                        Stock_CommodityFilterwithsearch("o.PO_Pack_Weight", searchtxt.Text, commodities.Text);
                    }
                }
            }
            else
            {
                Stock();
            }
        }

        private void searchtxt_TextChanged(object sender, EventArgs e)
        {
            if (searchtxt.Text == "")
            {
                Stock();
            }
            else
            {
                if (comboBox1.Text == "Stock Date")
                {
                    Stock_withsearch("o.Proccess_Out_Date", searchtxt.Text);
                }
                else if (comboBox1.Text == "Customer Name")
                {
                    Stock_withsearch("c.Customer_Name", searchtxt.Text);
                }
                else if (comboBox1.Text == "Brand")
                {
                    Stock_withsearch("o.PO_Brand", searchtxt.Text);
                }
                else if (comboBox1.Text == "Pack Weight")
                {
                    Stock_withsearch("o.PO_Pack_Weight", searchtxt.Text);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            searchtxt.Enabled = true;
        }

        private void home_Click(object sender, EventArgs e)
        {
            sumquantity = 0;
            sumnetwight = 0;
            foreach (DataGridViewRow row in stock_gridview.Rows)
            {
                sumquantity += Convert.ToInt32(row.Cells["Quantity"].Value.ToString());
                sumnetwight += Convert.ToInt32(row.Cells["Net_Weight"].Value.ToString());
            }

            totalquantity.Text = "QUANTITY\n" + sumquantity;
            totalnetweight.Text = "NET WEIGHT\n" + sumnetwight + "Kg";
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
