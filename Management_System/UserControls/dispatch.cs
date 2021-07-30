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

namespace Management_System
{
    public partial class dispatch : UserControl
    {
        public dispatch()
        {
            InitializeComponent();
            Stock();
            panel13.Location = new Point(
            this.panel12.Width / 2 - panel13.Size.Width / 2,
            this.panel12.Height / 2+10 - panel13.Size.Height / 2);
            panel13.Anchor = AnchorStyles.None;

            stock_gridview.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 191, 191);
            stock_gridview.DefaultCellStyle.SelectionForeColor = Color.Black;
            stock_gridview.DefaultCellStyle.ForeColor = Color.Black;
        }

        public void Stock()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select o.Proccess_Out_ID,o.Customer_ID,c.Customer_Name,o.Proccess_Out_Date,o.PO_Commodity,com.Commodity_Name,o.PO_Brand,o.PO_Qunatity,o.PO_Pack_Weight,o.PO_Net_Weight from proccess_out o join customer c on c.Customer_ID=o.Customer_ID join commodity com on o.PO_Commodity=com.Commodity_ID where o.PO_Qunatity>0", connection.conString);


            da.Fill(dt);
            Stock_ID.DataPropertyName = dt.Columns["Proccess_Out_ID"].ToString();
            Stock_Date.DataPropertyName = dt.Columns["Proccess_Out_Date"].ToString();
            Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
            Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
            Brandd.DataPropertyName = dt.Columns["PO_Brand"].ToString();
            Quantity1.DataPropertyName = dt.Columns["PO_Qunatity"].ToString();
            Pack_Weight.DataPropertyName = dt.Columns["PO_Pack_Weight"].ToString();
            Net_Weight.DataPropertyName = dt.Columns["PO_Net_Weight"].ToString(); 
            Customer_ID.DataPropertyName = dt.Columns["Customer_ID"].ToString();
            Commodity_ID.DataPropertyName = dt.Columns["PO_Commodity"].ToString();
            stock_gridview.DataSource = dt;
        }

        public void Stock_withsearch(string search, string sreachdata)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select o.Proccess_Out_ID,o.Customer_ID,c.Customer_Name,o.Proccess_Out_Date,o.PO_Commodity,com.Commodity_Name,o.PO_Brand,o.PO_Qunatity,o.PO_Pack_Weight,o.PO_Net_Weight from proccess_out o join customer c on c.Customer_ID=o.Customer_ID join commodity com on o.PO_Commodity=com.Commodity_ID where " + search + " like '%" + sreachdata + "%' and o.PO_Qunatity>0", connection.conString);


            da.Fill(dt);
            Stock_ID.DataPropertyName = dt.Columns["Proccess_Out_ID"].ToString();
            Stock_Date.DataPropertyName = dt.Columns["Proccess_Out_Date"].ToString();
            Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
            Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
            Brandd.DataPropertyName = dt.Columns["PO_Brand"].ToString();
            Quantity1.DataPropertyName = dt.Columns["PO_Qunatity"].ToString();
            Pack_Weight.DataPropertyName = dt.Columns["PO_Pack_Weight"].ToString();
            Net_Weight.DataPropertyName = dt.Columns["PO_Net_Weight"].ToString();
            Customer_ID.DataPropertyName = dt.Columns["Customer_ID"].ToString();
            Commodity_ID.DataPropertyName = dt.Columns["PO_Commodity"].ToString();
            stock_gridview.DataSource = dt;
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
            searchtxt.Enabled = true;
        }
        string datee;
        string customername;
        string com;
        string brand;
        string packweight;
        string netweight;
        string qty;
        int activatedrow;

        string custid;
        string outputid;
        string commoid;
        int i;
        string vnum;
        private void button1_Click(object sender, EventArgs e)
        {
           
            foreach (DataGridViewRow row in stock_gridview.SelectedRows)
            {
                datee = row.Cells["Stock_Date"].Value.ToString();
                customername = row.Cells["Customer_Name"].Value.ToString();
                com = row.Cells["Commodity"].Value.ToString();
                brand = row.Cells["Brandd"].Value.ToString();
                qty = row.Cells["Quantity1"].Value.ToString();
                packweight = row.Cells["Pack_Weight"].Value.ToString();
                netweight = row.Cells["Net_Weight"].Value.ToString();
                custid = row.Cells["Customer_ID"].Value.ToString();
                outputid = row.Cells["Stock_ID"].Value.ToString();
                commoid = row.Cells["Commodity_ID"].Value.ToString();
                string slctedrow = stock_gridview.CurrentRow.Index.ToString();
                //MessageBox.Show(slctedrow);
                activatedrow = Convert.ToInt32(slctedrow);
                

                if (Convert.ToInt32(row.Cells["Quantity1"].Value.ToString()) > 0 && Convert.ToInt32(row.Cells["Net_Weight"].Value.ToString()) > 0)
                {
                    row.Cells["Quantity1"].Value = 0;
                    row.Cells["Net_Weight"].Value = 0;
                    cusnametxt.Text = customername;
                    datetxt.Text = datee;
                    comtxt.Text = com;
                    brandtxt.Text = brand;
                    qtytxt.Text = qty;
                    packtxt.Text = packweight;
                    netweighttxt.Text = netweight;
                    comid.Text = commoid;


                }

                //...
            }


        }

        private void qtytxt_TextChanged(object sender, EventArgs e)
        {
            if (qtytxt.Text != "")
            {
                if (Convert.ToInt32(qtytxt.Text) > Convert.ToInt32(qty))
                {
                    MessageBox.Show("Quantity value exceed arrival quantity value.");
                    qtytxt.Text = qty;
                }
                else
                {
                    if (Convert.ToInt32(qtytxt.Text) == Convert.ToInt32(qty))
                    {

                    }
                    else
                    {
                        int newvalue = Convert.ToInt32(qty) - Convert.ToInt32(qtytxt.Text);
                        stock_gridview.Rows[activatedrow].Cells["Quantity1"].Value = newvalue.ToString();
                    }

                }
            }
        }

        private void netweighttxt_TextChanged(object sender, EventArgs e)
        {
            if (netweighttxt.Text != "")
            {
                if (Convert.ToInt32(netweighttxt.Text) > Convert.ToInt32(netweight))
                {
                    MessageBox.Show("Net weight value exceed arrival net weight value.");
                    netweighttxt.Text = netweight;
                }
                else
                {
                    if (Convert.ToInt32(netweighttxt.Text) == Convert.ToInt32(netweight)) { }
                    else
                    {
                        int newvalue = Convert.ToInt32(netweight) - Convert.ToInt32(netweighttxt.Text);
                        stock_gridview.Rows[activatedrow].Cells["Net_Weight"].Value = newvalue.ToString();
                    }
                }
            }
        }

        private void dispatch_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand("SELECT TOP 1(Gate_Pass) FROM dispatch ORDER BY Dispatch_ID DESC", connection.conString);

                connection.conString.Close();
                connection.conString.Open();

          
                if (cmd1.ExecuteScalar().ToString() == null)
                {
                    int newgp = 100;
                    gptxt.Text = newgp.ToString();
                }
                else
                {
                    int lastgp = Convert.ToInt32(cmd1.ExecuteScalar().ToString());
                    int newgp = lastgp + 1;
                    gptxt.Text = newgp.ToString();
                }

                connection.conString.Close();
            }
            catch(Exception ex)
            {
                int newgp = 100;
                gptxt.Text = newgp.ToString();
            }
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(outputid);
        }

        string selectedbagtypeid;
        string selectedbagtypetext;

        int counttt = 0;
        private void addproccessbtn_Click(object sender, EventArgs e)
        {
            
            if (proccesslist.Items.Count > 0)
            {
                foreach (ListViewItem item in proccesslist.Items)
                {
                    try
                    {
                        if (item.SubItems[0].Text == outputid)
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

                    if(qtytxt.Text=="" || netweighttxt.Text=="" || packtxt.Text=="" || selectedbagtypeid==null || selectedbagtypeid=="")
                    {
                        MessageBox.Show("Please fill all required fields.");
                    }
                    else
                    {
                        proccesslist.Items.Add(new ListViewItem(new string[] { outputid, datetxt.Text, cusnametxt.Text, comtxt.Text, brandtxt.Text, qtytxt.Text, packtxt.Text, selectedbagtypetext, netweighttxt.Text, remarktxt.Text, custid, selectedbagtypeid, comid.Text }));

                        idtxt.Text = "";
                        cusnametxt.Text = "";
                        datetxt.Text = "";
                        comtxt.Text = "";
                        qtytxt.Text = "";
                        netweighttxt.Text = "";
                        netweight = "";
                        PP.Checked = false;
                        PB.Checked = false;
                        JUTE.Checked = false;

                        addproccessbtn.Enabled = false;
                        checkBox1.Checked = false;
                    }
                 
                }
            }
            else
            {
                if (qtytxt.Text == "" || netweighttxt.Text == "" || packtxt.Text == "" || selectedbagtypeid == null || selectedbagtypeid == "")
                {
                    MessageBox.Show("Please fill all required fields.");
                }
                else
                {
                    proccesslist.Items.Add(new ListViewItem(new string[] { outputid, datetxt.Text, cusnametxt.Text, comtxt.Text, brandtxt.Text, qtytxt.Text, packtxt.Text, selectedbagtypetext, netweighttxt.Text, remarktxt.Text, custid, selectedbagtypeid, comid.Text }));

                    idtxt.Text = "";
                    cusnametxt.Text = "";
                    datetxt.Text = "";
                    comtxt.Text = "";
                    qtytxt.Text = "";
                    netweighttxt.Text = "";
                    packtxt.Text = "";
                    netweight = "";
                    PP.Checked = false;
                    PB.Checked = false;
                    JUTE.Checked = false;

                    addproccessbtn.Enabled = false;
                    checkBox1.Checked = false;
                }
            }
        }
    

        private void PP_CheckedChanged(object sender, EventArgs e)
        {
            selectedbagtypeid = "1";
            selectedbagtypetext = "PP";
        }

        private void PB_CheckedChanged(object sender, EventArgs e)
        {
            selectedbagtypeid = "2";
            selectedbagtypetext = "PB";
        }

        private void JUTE_CheckedChanged(object sender, EventArgs e)
        {
            selectedbagtypeid = "3";
            selectedbagtypetext = "JUTE";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                addproccessbtn.Enabled = true;
            }
            else
            {
                addproccessbtn.Enabled = false;
            }
        }
        int realqty;
        int realweight;
        private void button3_Click(object sender, EventArgs e)
        {
            if (proccesslist.Items.Count > 0)
            {
                try
                {
                    string aid = proccesslist.SelectedItems[0].SubItems[0].Text;
                    String searchValue = aid;
                    int rowIndex = -1;
                    foreach (DataGridViewRow roww in stock_gridview.Rows)
                    {
                        if (roww.Cells["Stock_ID"].Value.ToString().Equals(searchValue))
                        {
                            rowIndex = roww.Index;
                            break;
                        }
                    }

                    //Obtain a reference to the newly created DataGridViewRow 
                    var row = this.stock_gridview.Rows[rowIndex];

                    //Now this won't fail since the row and columns exist 
                    //MessageBox.Show(row.Cells[7].Value.ToString());
                    

                    //MessageBox.Show("Grid Quantity=" + row.Cells["Quantity1"].Value + " List Quantity=" + proccesslist.SelectedItems[0].SubItems[5].Text.ToString());

                    //MessageBox.Show("Grid Weight=" + row.Cells["Net_Weight"].Value + " List Quantity=" + proccesslist.SelectedItems[0].SubItems[8].Text.ToString());

                    row.Cells["Quantity1"].Value = (Convert.ToInt32(proccesslist.SelectedItems[0].SubItems[5].Text.ToString()) + Convert.ToInt32(row.Cells["Quantity1"].Value)).ToString();
               

                    row.Cells["Net_Weight"].Value = (Convert.ToInt32(proccesslist.SelectedItems[0].SubItems[8].Text.ToString()) + Convert.ToInt32(row.Cells["Net_Weight"].Value)).ToString();
                   


                    //if (realqty > Convert.ToInt32(proccesslist.SelectedItems[0].SubItems[5].Text.ToString()))
                    //{
                    //    row.Cells["Quantity1"].Value = realqty.ToString();
                    //}
                    //else
                    //{

                    //}

                    //if (realweight > Convert.ToInt32(proccesslist.SelectedItems[0].SubItems[8].Text.ToString()))
                    //{
                    //    row.Cells["Net_Weight"].Value = realweight.ToString();
                    //}
                    //else
                    //{

                    //}

                    proccesslist.SelectedItems[0].Remove();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please Select row." + ex);
                }
            }
        }
        int c;
        private void proceed_Click(object sender, EventArgs e)
        {
            connection.conString.Close();
            connection.conString.Open();
            if (vnumbertxt.Text!="" && gptxt.Text!="")
            {

                foreach (ListViewItem item in proccesslist.Items)
                {

                    SqlCommand forqty = new SqlCommand("select PO_Qunatity from proccess_out where Proccess_Out_ID='" + item.SubItems[0].Text.ToString() + "'", connection.conString);
                    SqlCommand forweight = new SqlCommand("select PO_Net_Weight from proccess_out where Proccess_Out_ID='" + item.SubItems[0].Text.ToString() + "'", connection.conString);


                    int oldqty = Convert.ToInt32(forqty.ExecuteScalar());
                    int newqty = Convert.ToInt32(item.SubItems[5].Text.ToString());

                    int oldweight = Convert.ToInt32(forweight.ExecuteScalar());
                    int newweight = Convert.ToInt32(item.SubItems[8].Text.ToString());


                    int updatedqty = oldqty - newqty;

                    int updatedweight = oldweight - newweight;


                    SqlCommand updateweightandqty = new SqlCommand("update proccess_out set PO_Qunatity='" + updatedqty.ToString() + "',PO_Net_Weight='" + updatedweight.ToString() + "' where Proccess_Out_ID='" + item.SubItems[0].Text.ToString() + "'", connection.conString);

                    int res = updateweightandqty.ExecuteNonQuery();

                    if (res > 0)
                    {




                        SqlCommand cm = new SqlCommand("insert into dispatch(Dispatch_Date,Customer_ID,Vehicle_Number,Gate_Pass,Commodity_ID,Brand,Quantity,Pack_Weight,Bag_ID,Net_Weight,Remarks) values (@date,@custid,@vnumber,@gatepass,@commodity,@brand,@quantity,@pack,@bag,@netweight,@remarks)", connection.conString);
                        cm.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd-MMMM-yyyy"));
                        cm.Parameters.AddWithValue("@custid", item.SubItems[10].Text.ToString());
                        cm.Parameters.AddWithValue("@vnumber", vnumbertxt.Text.ToUpper());
                        cm.Parameters.AddWithValue("@gatepass", gptxt.Text);
                        cm.Parameters.AddWithValue("@commodity", item.SubItems[12].Text.ToString());
                        if (item.SubItems[4].Text.ToString() == "")
                        {
                            cm.Parameters.AddWithValue("@brand", DBNull.Value);
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@brand", item.SubItems[4].Text.ToString());
                        }
                        cm.Parameters.AddWithValue("@quantity", item.SubItems[5].Text.ToString());
                        cm.Parameters.AddWithValue("@pack", item.SubItems[6].Text.ToString());
                        cm.Parameters.AddWithValue("@bag", item.SubItems[11].Text.ToString());
                        cm.Parameters.AddWithValue("@netweight", item.SubItems[8].Text.ToString());


                        if (remarks.Text == "")
                        {
                            cm.Parameters.AddWithValue("@remarks", DBNull.Value);
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@remarks", item.SubItems[9].Text.ToString());
                        }

                        int res1 = cm.ExecuteNonQuery();

                        if (res1 > 0)
                        {


                            c = 1;

                        }
                        else
                        {
                            c= 0;
                        }


                    }

                    //MessageBox.Show("OLD QUANTITY : " + oldqty.ToString() + "NEW QTY : " + newqty.ToString() + " Updated : " + updatedqty.ToString());
                    //MessageBox.Show("OLD w8 : " + oldweight.ToString() + "NEW w8 : " + newweight.ToString() + " Updated : " + updatedweight.ToString());

                }

                if(c==1)
                {

                    MessageBox.Show("Stock dispatched on vehicle number (" + vnumbertxt.Text + ")");
                    var result = MessageBox.Show("Do you want to print dispatch report?", "Report!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        SqlCommand cmm = new SqlCommand("SELECT TOP 1(Vehicle_Number) as 'vnumber' FROM dispatch ORDER BY Dispatch_ID DESC", connection.conString);
                        vnum = cmm.ExecuteScalar().ToString();
                        loginloading l = new loginloading();
                        l.ShowDialog();
                            using (dispatch_report ac = new dispatch_report(vnum))
                            {
                                l.Close();
                                ac.ShowDialog();

                                idtxt.Text = "";
                                cusnametxt.Text = "";
                                datetxt.Text = "";
                                comtxt.Text = "";
                                qtytxt.Text = "";
                                netweighttxt.Text = "";
                                packtxt.Text = "";
                                netweight = "";
                                PP.Checked = false;
                                PB.Checked = false;
                                JUTE.Checked = false;

                                addproccessbtn.Enabled = false;
                                checkBox1.Checked = false;
                                proccesslist.Items.Clear();
                                vnumbertxt.Text = "";
                            }
                        
                    }
                    else
                    {

                        idtxt.Text = "";
                        cusnametxt.Text = "";
                        datetxt.Text = "";
                        comtxt.Text = "";
                        qtytxt.Text = "";
                        netweighttxt.Text = "";
                        packtxt.Text = "";
                        netweight = "";
                        PP.Checked = false;
                        PB.Checked = false;
                        JUTE.Checked = false;

                        addproccessbtn.Enabled = false;
                        checkBox1.Checked = false;
                        proccesslist.Items.Clear();
                        vnumbertxt.Text = "";
                    }


                 
                }
                else
                {
                    MessageBox.Show("Error occurs while dispatching.");
                }

                connection.conString.Close();
            }
            else
            {

                connection.conString.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            stock_gridview.SelectedRows[0].Cells["Quantity1"].Value = (Convert.ToInt32(qtytxt.Text) + Convert.ToInt32(stock_gridview.SelectedRows[0].Cells["Quantity1"].Value)).ToString();


            stock_gridview.SelectedRows[0].Cells["Net_Weight"].Value = (Convert.ToInt32(netweighttxt.Text) + Convert.ToInt32(stock_gridview.SelectedRows[0].Cells["Net_Weight"].Value)).ToString();
            idtxt.Text = "";
            cusnametxt.Text = "";
            datetxt.Text = "";
            comtxt.Text = "";
            qtytxt.Text = "";
            netweighttxt.Text = "";
            packtxt.Text = "";
            netweight = "";
            PP.Checked = false;
            PB.Checked = false;
            JUTE.Checked = false;

            addproccessbtn.Enabled = false;
            checkBox1.Checked = false;

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void proccesslist_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
