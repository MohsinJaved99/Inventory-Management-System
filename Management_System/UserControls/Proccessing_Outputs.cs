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
using Management_System.UserControls;

namespace Management_System
{
    public partial class Proccessing_Outputs : UserControl
    {
        string pid, cusid;
        public Proccessing_Outputs()
        {
            InitializeComponent();
            Active_View();



            commodities.Items.Clear();

            string query = "select * from commodity";

            string q = "select Proccess_Number from proccess_in where Status='Active'";

            SqlDataReader sdr;
            SqlCommand cmd = new SqlCommand(query, connection.conString);
            SqlCommand cmd1 = new SqlCommand(q, connection.conString);
            connection.conString.Close();
            connection.conString.Open();
           
            pid=cmd1.ExecuteScalar().ToString();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                commodities.DisplayMember = "Text";
                commodities.ValueMember = "Value";
                commodities.Items.Add(new Combobox(sdr["Commodity_Name"].ToString(), Convert.ToInt32(sdr["Commodity_ID"].ToString())));
            }

            sdr.Close();

                connection.conString.Close();
           
            panel13.Location = new Point(
           this.panel12.Width / 2 - panel13.Size.Width / 2,
           this.panel12.Height / 2+10 - panel13.Size.Height / 2);
            panel13.Anchor = AnchorStyles.None;

            proccessout_gridview.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 191, 191);
            proccessout_gridview.DefaultCellStyle.SelectionForeColor = Color.Black;
            proccessout_gridview.DefaultCellStyle.ForeColor = Color.Black;
            //proccessout_gridview[3, proccessout_gridview.Rows.Count - 1].Value = "Total";


            //proccessout_gridview.Rows[proccessout_gridview.Rows.Count - 1].Cells[5].Value = qtyy.ToString();

            //proccessout_gridview.Rows[proccessout_gridview.Rows.Count - 1].Cells[6].Value = weightt.ToString();

            //proccessout_gridview.Rows[proccessout_gridview.Rows.Count - 1].Cells[7].Value = bardana.ToString();

            //proccessout_gridview.Rows[proccessout_gridview.Rows.Count - 1].Cells[8].Value = netweightt.ToString();
        }

        public void Active_View()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select p.Arrival_ID,a.Vehicle_Number,p.Proccess_Number,c.Customer_ID,c.Customer_Name,com.Commodity_Name,a.Arrival_Date,p.PI_Quantity,p.PI_Net_Weight,p.Weight,p.Baardana from proccess_in p join arrival a on p.Arrival_ID=a.Arrival_ID join customer c on c.Customer_ID=a.Customer_ID join commodity com on a.Commodity_ID=com.Commodity_ID where p.Status='Active'", connection.conString);


            da.Fill(dt);

            Arrival_ID.DataPropertyName = dt.Columns["Arrival_ID"].ToString();
            Arrival_Date.DataPropertyName = dt.Columns["Arrival_Date"].ToString();
            Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
            Vehicle_Number.DataPropertyName = dt.Columns["Vehicle_Number"].ToString();
            Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
            Quantityy.DataPropertyName = dt.Columns["PI_Quantity"].ToString();
            Weight.DataPropertyName = dt.Columns["Weight"].ToString();
            Baardana.DataPropertyName = dt.Columns["Baardana"].ToString();
            Net_Weight.DataPropertyName = dt.Columns["PI_Net_Weight"].ToString();
            proccess_id.DataPropertyName = dt.Columns["Proccess_Number"].ToString();

            foreach(DataRow row in dt.Rows)
            {
                cusid = row["Customer_ID"].ToString();
            }
            proccessout_gridview.DataSource = dt;

           
        }


        public void Active_View_Search(string searchfor, string data)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select p.Arrival_ID,a.Vehicle_Number,p.Proccess_Number,c.Customer_Name,com.Commodity_Name,a.Arrival_Date,p.PI_Quantity,p.PI_Net_Weight,p.Weight,p.Baardana from proccess_in p join arrival a on p.Arrival_ID=a.Arrival_ID join customer c on c.Customer_ID=a.Customer_ID join commodity com on a.Commodity_ID=com.Commodity_ID where  p.Status='Active' and " + searchfor + " like '" + data + "%'", connection.conString);


            da.Fill(dt);

            Arrival_ID.DataPropertyName = dt.Columns["Arrival_ID"].ToString();
            Arrival_Date.DataPropertyName = dt.Columns["Arrival_Date"].ToString();
            Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
            Vehicle_Number.DataPropertyName = dt.Columns["Vehicle_Number"].ToString();
            Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
            Quantityy.DataPropertyName = dt.Columns["PI_Quantity"].ToString();
            Weight.DataPropertyName = dt.Columns["Weight"].ToString();
            Baardana.DataPropertyName = dt.Columns["Baardana"].ToString();
            Net_Weight.DataPropertyName = dt.Columns["PI_Net_Weight"].ToString();
            proccess_id.DataPropertyName = dt.Columns["Proccess_Number"].ToString();

            proccessout_gridview.DataSource = dt;


        }

        private void label12_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(cusid);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
             
        }

        private void proccesslist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void proccessout_gridview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //int i = 1;

            //foreach(DataGridViewRow row in proccessout_gridview.Rows)
            //{
            //    row.Cells[0].Value = i;
            //    i++;
            //}
        }
        decimal qtyy = 0;
        decimal weightt = 0;
        decimal netweightt = 0;
        int minus;
        decimal bardana = 0;
        private void Proccessing_Outputs_Load(object sender, EventArgs e)
        {
        

            foreach(DataGridViewRow row in proccessout_gridview.Rows)
            {
                var singleqty = row.Cells["Quantityy"].Value;

                var singlewight = row.Cells["Weight"].Value;

                var singlebardana = row.Cells["Baardana"].Value;

                var singlenetweight = row.Cells["Net_Weight"].Value;

                var singleproccessnumber = row.Cells["proccess_id"].Value;


                if (singleqty != DBNull.Value)
                {
                    qtyy += Convert.ToDecimal(singleqty);
                }

                if (singlewight != DBNull.Value)
                {
                    weightt += Convert.ToDecimal(singlewight);
                }

                if (singlebardana != DBNull.Value)
                {
                    bardana += Convert.ToDecimal(singlebardana);
                }

                if (singlenetweight != DBNull.Value)
                {
                    netweightt += Convert.ToDecimal(singlenetweight);
                }
            }

            totalqty.Text = "QTY\n" + qtyy.ToString();

            totalweightt.Text = "WEIGHT\n" + weightt.ToString() + " Kg";
            if(bardana.ToString()=="")
            {
                totalbardana.Text = "BARDANA\n" + "0 Kg";
            }
            else
            {
                totalbardana.Text = "BARDANA\n" + bardana.ToString() + " Kg";
            }

            minus = Convert.ToInt32(netweightt.ToString());
            totalnetwieghtt.Text = "NET WIEGHT\n" + netweightt.ToString() + " Kg";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                addoutputbtn.Enabled = true;
            }
            else
            {
                addoutputbtn.Enabled = false;
            }
        }
        int counttt = 0;
        int sum;
        
        private void addoutputbtn_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            proceed.Enabled = true;
            if (outputlist.Items.Count > 0)
            {
             
                foreach (ListViewItem item in outputlist.Items)
                {
                    try
                    {
                        if (item.SubItems[1].Text == commodities.Text)
                        {
                            counttt = 1;
                        }
                        else
                        {
                            counttt = 0;

                        }
                    }
                    catch (Exception ex)
                    {
                        counttt = 0;
                        MessageBox.Show("Something worng. " + ex);
                    }
                }
                if (counttt == 1)
                {
                    MessageBox.Show("You already add that arrival.");
                }
                else
                {
                    
                    if(qtytxt.Text!="" && netweighttxt.Text != "" && ratiotxt.Text!="" && commodities.SelectedIndex!=-1)
                    {

                        var commodity_combo = commodities.SelectedItem as Combobox;
                        outputlist.Items.Add(new ListViewItem(new string[] { pid, commodity_combo.Text, brandtxt.Text, qtytxt.Text, packtxt.Text, netweighttxt.Text, ratiotxt.Text, commodity_combo.Value.ToString() }));


                        commodities.SelectedIndex = -1;
                        brandtxt.Text = "";
                        qtytxt.Text = "";
                        packtxt.Text = "";
                        netweighttxt.Text = "";
                        ratiotxt.Text = "";
                        checkBox1.Checked = false;
                        addoutputbtn.Enabled = false;

                        sum = 0;
                        foreach (ListViewItem item in outputlist.Items)
                        {
                            sum += int.Parse(item.SubItems[5].Text);
                        }

                        minus = Convert.ToInt32(netweightt.ToString()) - sum;
                        totalnetwieghtt.Text = "NET WIEGHT\n" + minus.ToString() + " Kg";
                    }
                    else
                    {
                        MessageBox.Show("Please Fill Quantity And Net Weight.");
                    }



                }
            }
            else
            {
                if (qtytxt.Text != "" && netweighttxt.Text != "" && ratiotxt.Text != "")
                {
                    var commodity_combo = commodities.SelectedItem as Combobox;
                outputlist.Items.Add(new ListViewItem(new string[] { pid, commodity_combo.Text, brandtxt.Text, qtytxt.Text, packtxt.Text, netweighttxt.Text, ratiotxt.Text, commodity_combo.Value.ToString() }));

                commodities.SelectedIndex = -1;
                brandtxt.Text = "";
                qtytxt.Text = "";
                packtxt.Text = "";
                netweighttxt.Text = "";
                ratiotxt.Text = "";
                checkBox1.Checked = false;
                addoutputbtn.Enabled = false;

                foreach (ListViewItem item in outputlist.Items)
                {
                    sum += int.Parse(item.SubItems[5].Text);
                }


                minus = Convert.ToInt32(netweightt.ToString()) - sum;
                totalnetwieghtt.Text = "NET WIEGHT\n" + minus.ToString() + " Kg";
                }
                else
                {
                    MessageBox.Show("Please Fill Quantity And Net Weight.");
                }

            }
        }
        private void netweighttxt_TextChanged(object sender, EventArgs e)
        {
            if (netweighttxt.Text != "")
            {
                if (Convert.ToInt32(netweighttxt.Text) > minus)
                {
                    MessageBox.Show("Given Weight Exceed Net Weight.");
                    netweighttxt.Text = minus.ToString();
                }
                float givennetweight = float.Parse(netweighttxt.Text);
                float totalnetweight = float.Parse(netweightt.ToString());
                

                float ratio = givennetweight / totalnetweight;
                float ratio2 = ratio * 100;

                //MessageBox.Show(ratio2.ToString());
                ratiotxt.Text = ratio2.ToString("0.00");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
      
        private void outputlist_SizeChanged(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {

            outputlist.SelectedItems[0].Remove();


            sum = 0;
            foreach (ListViewItem item in outputlist.Items)
            {
                sum += int.Parse(item.SubItems[5].Text);
            }

            minus = Convert.ToInt32(netweightt.ToString()) - sum;
            totalnetwieghtt.Text = "NET WIEGHT\n" + minus.ToString() + " Kg";
            
           
        }

        private void searchtxt_TextChanged(object sender, EventArgs e)
        {
            if (searchtxt.Text == "")
            {
                Active_View();
            }
            else
            {
                if (comboBox1.Text == "Arrival Date")
                {
                    Active_View_Search("a.Arrival_Date", searchtxt.Text);
                }
                else if (comboBox1.Text == "Customer Name")
                {
                    Active_View_Search("c.Customer_Name", searchtxt.Text);
                }
                else if (comboBox1.Text == "Vehicle Number")
                {
                    Active_View_Search("a.Vehicle_Number", searchtxt.Text);
                }
                else if (comboBox1.Text == "Commodity")
                {
                    Active_View_Search("com.Commodity_Name", searchtxt.Text);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchtxt.Enabled = true;
        }
        int c;
        private void proceed_Click(object sender, EventArgs e)
        {
            try
            {
                if (outputlist.Items.Count > 0)
                {
                    connection.conString.Close();
                    connection.conString.Open();
                    foreach (ListViewItem item in outputlist.Items)
                    {

                        string brand = item.SubItems[2].Text.ToString();
                        string quantity = item.SubItems[3].Text.ToString();
                        string pack = item.SubItems[4].Text.ToString();
                        string weight = item.SubItems[5].Text.ToString();
                        string ratio = item.SubItems[6].Text.ToString();
                        string commodityid = item.SubItems[7].Text.ToString();

                        


                        string insertoutput = "insert into proccess_out(Proccess_Number,Proccess_Out_Date,PO_Commodity,PO_Brand,PO_Qunatity,PO_Pack_Weight,PO_Net_Weight,PO_Ratio,Customer_ID) values ('" + pid + "','" + DateTime.Now.ToString("dd-MMMM-yyyy") + "','" + commodityid + "','" + brand + "','" + quantity + "','" + pack + "','" + weight + "','" + ratio + "','"+cusid+"')";
                        SqlCommand io = new SqlCommand(insertoutput, connection.conString);
                        int res = io.ExecuteNonQuery();


                        string insertoutputreport = "insert into out_proccess_report(Proccess_Number,Proccess_Out_Date,PO_Commodity,PO_Brand,PO_Qunatity,PO_Pack_Weight,PO_Net_Weight,PO_Ratio,Customer_ID) values ('" + pid + "','" + DateTime.Now.ToString("dd-MMMM-yyyy") + "','" + commodityid + "','" + brand + "','" + quantity + "','" + pack + "','" + weight + "','" + ratio + "','" + cusid + "')";
                        SqlCommand ior = new SqlCommand(insertoutputreport, connection.conString);
                        int res2 = ior.ExecuteNonQuery();

                        if (res > 0 && res2>0)
                        {
                            string updateinput = "update proccess_in set Status='Complete' where Proccess_Number='" + pid + "'";
                            SqlCommand up = new SqlCommand(updateinput, connection.conString);
                            int res1 = up.ExecuteNonQuery();
                            if (res1 > 0)
                            {
                                c = 1;
                            }
                            else
                            {
                                c = 0;
                            }
                        }

                        //StringBuilder sr = new StringBuilder();
                        //sr.Append("Commodity : " + commodityid + "\nBrand : " + brand + "\nQuantity : " + quantity + "\nPack : " + pack + "\nWeight : " + weight + "\nRatio : " + ratio);


                        //MessageBox.Show(sr.ToString());

                    }
                    if (c == 1)
                    {


                        commodities.SelectedIndex = -1;
                        qtytxt.Text = "";
                        packtxt.Text = "";
                        netweighttxt.Text = "";
                        ratiotxt.Text = "";
                        brandtxt.Text = "";
                        qtytxt.Text = "";
                        netweighttxt.Text = "";
                        searchtxt.Text = "";
                        comboBox1.SelectedIndex = -1;
                        outputlist.Items.Clear();
                        cusid = "";
                        MessageBox.Show("Proccessing Completed.");
                        panel14.Visible = true;
                        connection.conString.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error.");
                        connection.conString.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void qtytxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void packtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void netweighttxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
