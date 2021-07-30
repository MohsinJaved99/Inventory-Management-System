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
    public partial class Proccessing : UserControl
    {
        public Proccessing()
        {
            InitializeComponent();
            panel13.Location = new Point(
            this.panel12.Width / 2 - panel13.Size.Width / 2,
            this.panel12.Height / 2+10 - panel13.Size.Height / 2);
            panel13.Anchor = AnchorStyles.None;

            proccessarrival_gridview.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 191, 191);
            proccessarrival_gridview.DefaultCellStyle.SelectionForeColor = Color.Black;
            proccessarrival_gridview.DefaultCellStyle.ForeColor = Color.Black;


            //proccesslist.sele = Color.FromArgb(191, 191, 191);
            //proccesslist.DefaultCellStyle.SelectionForeColor = Color.Black;
            //proccesslist.DefaultCellStyle.ForeColor = Color.Black;

            Arrival_View();
        }

        public void Arrival_View()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select a.Arrival_ID as 'Arrival_ID',a.Arrival_Date as 'Arrival_Date',c.Customer_Name as 'Customer_Name',a.Vehicle_Number as 'Vehicle_Number',a.Gate_Pass as 'Gate_Pass',com.Commodity_Name as 'Commodity_Name',bag.Bag_Name as 'Bag_Name',a.Quantity as 'Quantity',a.Pack_Weight as 'Pack_Weight',a.Net_Weight as 'Net_Weight' from arrival a join customer c on a.Customer_ID=c.Customer_ID join commodity com on a.Commodity_ID=com.Commodity_ID join Bags bag on a.Bag_ID=bag.Bag_ID where a.Quantity>0", connection.conString);


            da.Fill(dt);

            Arrival_ID.DataPropertyName = dt.Columns["Arrival_ID"].ToString();
            Arrival_Date.DataPropertyName = dt.Columns["Arrival_Date"].ToString();
            Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
            Vehicle_Number.DataPropertyName = dt.Columns["Vehicle_Number"].ToString();
            Gate_Pass.DataPropertyName = dt.Columns["Gate_Pass"].ToString();
            Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
            Bag_Type.DataPropertyName = dt.Columns["Bag_Name"].ToString();
            Quantity1.DataPropertyName = dt.Columns["Quantity"].ToString();
            Pack_Weight.DataPropertyName = dt.Columns["Pack_Weight"].ToString();
            Net_Weight.DataPropertyName = dt.Columns["Net_Weight"].ToString();

            proccessarrival_gridview.DataSource = dt;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }
        string aid;
        string datee;
        string customername;
        string com;
        string netweight;
        string qty;
        int activatedrow;
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in proccessarrival_gridview.SelectedRows)
            {
                aid = row.Cells[0].Value.ToString();
                datee = row.Cells[1].Value.ToString();
                customername = row.Cells[2].Value.ToString();
                string vnumber = row.Cells[3].Value.ToString();
                string gp = row.Cells[4].Value.ToString();
                com = row.Cells[5].Value.ToString();
                string bagtype = row.Cells[6].Value.ToString();
                qty = row.Cells[7].Value.ToString();
                string weight = row.Cells[8].Value.ToString();
                netweight = row.Cells[9].Value.ToString();
                string slctedrow = proccessarrival_gridview.CurrentRow.Index.ToString();
                //MessageBox.Show(slctedrow);
                activatedrow = Convert.ToInt32(slctedrow);

                if (Convert.ToInt32(row.Cells[7].Value.ToString())>0 && Convert.ToInt32(row.Cells[9].Value.ToString())>0)
                {
                    proccessarrival_gridview.Rows[activatedrow].Cells[7].Value = 0;
                    proccessarrival_gridview.Rows[activatedrow].Cells[9].Value = 0;
                    idtxt.Text = aid;
                    cusnametxt.Text = customername;
                    datetxt.Text = datee;
                    vnumbertxt.Text = vnumber;
                    gptxt.Text = gp;
                    comtxt.Text = com;
                    qtytxt.Text = qty;
                    netweighttxt.Text = netweight;
                    baardanatxt.Text = "0";
                  
                }
               
                //...
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                addproccessbtn.Enabled = true;
            }
            else
            {
                addproccessbtn.Enabled = false;
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
                        proccessarrival_gridview.Rows[activatedrow].Cells[9].Value = newvalue.ToString();
                    }
                }
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
                        proccessarrival_gridview.Rows[activatedrow].Cells[7].Value = newvalue.ToString();
                    }

                }
            }

        }

        private void proccessarrival_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void proccessarrival_gridview_SelectionChanged(object sender, EventArgs e)
        {
            
        }
        int counttt = 0;
        private void addproccessbtn_Click(object sender, EventArgs e)
        {
            
            if (proccesslist.Items.Count > 0)
            {
                foreach (ListViewItem item in proccesslist.Items)
                {
                    try
                    {
                        if (item.SubItems[0].Text == idtxt.Text)
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

                    if(qtytxt.Text!="" && netweight!=null)
                    {
                        proccesslist.Items.Add(new ListViewItem(new string[] { idtxt.Text, datetxt.Text, cusnametxt.Text, comtxt.Text, qtytxt.Text, netweight.ToString(), baardanatxt.Text, netweighttxt.Text }));

                        idtxt.Text = "";
                        cusnametxt.Text = "";
                        datetxt.Text = "";
                        vnumbertxt.Text = "";
                        gptxt.Text = "";
                        comtxt.Text = "";
                        qtytxt.Text = "";
                        netweighttxt.Text = "";
                        baardanatxt.Text = "";
                        netweight = "";

                        addproccessbtn.Enabled = false;
                        checkBox1.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("Please Fill Quantity And Net Weight.");
                    }

                    
                }
            }
            else
            {
                if (qtytxt.Text != "" && netweight != null)
                {
                    proccesslist.Items.Add(new ListViewItem(new string[] { idtxt.Text, datetxt.Text, cusnametxt.Text, comtxt.Text, qtytxt.Text, netweight.ToString(), baardanatxt.Text, netweighttxt.Text }));

                idtxt.Text = "";
                cusnametxt.Text = "";
                datetxt.Text = "";
                vnumbertxt.Text = "";
                gptxt.Text = "";
                comtxt.Text = "";
                qtytxt.Text = "";
                netweighttxt.Text = "";
                baardanatxt.Text = "";
                netweight = "";

                addproccessbtn.Enabled = false;
                checkBox1.Checked = false;
                }
                else
                {
                    MessageBox.Show("Please Fill Quantity And Net Weight.");
                }
            }


        }
        ListViewItem firstSelectedItem;
        private void proccesslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void proccesslist_Click(object sender, EventArgs e)
        {
            
        }
        int realqty;
        int realweight;
        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchtxt.Enabled = true;
        }
        public void Arrival_View_Search(string searchfor, string data)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("select a.Arrival_ID as 'Arrival_ID',a.Arrival_Date as 'Arrival_Date',c.Customer_Name as 'Customer_Name',a.Vehicle_Number as 'Vehicle_Number',a.Gate_Pass as 'Gate_Pass',com.Commodity_Name as 'Commodity_Name',bag.Bag_Name as 'Bag_Name',a.Quantity as 'Quantity',a.Pack_Weight as 'Pack_Weight',a.Net_Weight as 'Net_Weight' from arrival a join customer c on a.Customer_ID=c.Customer_ID join commodity com on a.Commodity_ID=com.Commodity_ID join Bags bag on a.Bag_ID=bag.Bag_ID where " + searchfor + " like '" + data + "%' and a.Quantity>0", connection.conString);


            da.Fill(dt);

            Arrival_ID.DataPropertyName = dt.Columns["Arrival_ID"].ToString();
            Arrival_Date.DataPropertyName = dt.Columns["Arrival_Date"].ToString();
            Customer_Name.DataPropertyName = dt.Columns["Customer_Name"].ToString();
            Vehicle_Number.DataPropertyName = dt.Columns["Vehicle_Number"].ToString();
            Gate_Pass.DataPropertyName = dt.Columns["Gate_Pass"].ToString();
            Commodity.DataPropertyName = dt.Columns["Commodity_Name"].ToString();
            Bag_Type.DataPropertyName = dt.Columns["Bag_Name"].ToString();
            Quantity1.DataPropertyName = dt.Columns["Quantity"].ToString();
            Pack_Weight.DataPropertyName = dt.Columns["Pack_Weight"].ToString();
            Net_Weight.DataPropertyName = dt.Columns["Net_Weight"].ToString();

            proccessarrival_gridview.DataSource = dt;
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
        private void button3_Click(object sender, EventArgs e)
        {
            if (proccesslist.Items.Count > 0)
            {
                try
                {
                    string aid = proccesslist.SelectedItems[0].SubItems[0].Text;
                    String searchValue = aid;
                    int rowIndex = -1;
                    foreach (DataGridViewRow roww in proccessarrival_gridview.Rows)
                    {
                        if (roww.Cells[0].Value.ToString().Equals(searchValue))
                        {
                            rowIndex = roww.Index;
                            break;
                        }
                    }

                    //Obtain a reference to the newly created DataGridViewRow 
                    var row = this.proccessarrival_gridview.Rows[rowIndex];

                    //Now this won't fail since the row and columns exist 
                    //MessageBox.Show(row.Cells[7].Value.ToString());


                    row.Cells["Quantity1"].Value = (Convert.ToInt32(proccesslist.SelectedItems[0].SubItems[4].Text.ToString()) + Convert.ToInt32(row.Cells["Quantity1"].Value)).ToString();


                    row.Cells["Net_Weight"].Value = (Convert.ToInt32(proccesslist.SelectedItems[0].SubItems[7].Text.ToString()) + Convert.ToInt32(row.Cells["Net_Weight"].Value)).ToString();

                    proccesslist.SelectedItems[0].Remove();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please Select row."+ex);
                }
            }
        }

        private void proccesslist_SizeChanged(object sender, EventArgs e)
        {
            if(proccesslist.Items.Count > 0)
            {
                proceed.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }
        int c;
        private void proceed_Click(object sender, EventArgs e)
        {


            connection.conString.Close();
            connection.conString.Open();


            SqlCommand checkforactiveproccess = new SqlCommand("select count(*) as 'count' from proccess_in where Status='Active'", connection.conString);
            int count = Convert.ToInt32(checkforactiveproccess.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show("There is already proccess running.");
            }
            else
            {

                if (proccesslist.Items.Count > 0)
                {


                Random r = new Random();
                int Proccess_Number = Convert.ToInt32(r.Next(1000000000));
                foreach (ListViewItem item in proccesslist.Items)
                {

                    SqlCommand forqty = new SqlCommand("select Quantity from arrival where Arrival_ID='" + item.SubItems[0].Text.ToString() + "'", connection.conString);
                    SqlCommand forweight = new SqlCommand("select Net_Weight from arrival where Arrival_ID='" + item.SubItems[0].Text.ToString() + "'", connection.conString);


                    int oldqty = Convert.ToInt32(forqty.ExecuteScalar());
                    int newqty = Convert.ToInt32(item.SubItems[4].Text.ToString());

                    int oldweight = Convert.ToInt32(forweight.ExecuteScalar());
                    int newweight = Convert.ToInt32(item.SubItems[7].Text.ToString());


                    int updatedqty = oldqty - newqty;

                    int updatedweight = oldweight - newweight;



                    SqlCommand updateweightandqty = new SqlCommand("update arrival set Quantity='" + updatedqty.ToString() + "',Net_Weight='" + updatedweight.ToString() + "' where Arrival_ID='" + item.SubItems[0].Text + "'", connection.conString);

                    int res = updateweightandqty.ExecuteNonQuery();

                    if (res > 0)
                    {

                        SqlCommand proccessin = new SqlCommand("insert into proccess_in(Proccess_Number,Proccess_In_Date,Arrival_ID,PI_Quantity,PI_Net_Weight,Baardana,Status,Weight) values ('" + Proccess_Number.ToString() + "','" + DateTime.Now.ToString("dd-MMMM-yyyy") + "','" + item.SubItems[0].Text + "','" + newqty.ToString() + "','" + newweight.ToString() + "','" + item.SubItems[6].Text + "','Active','" + item.SubItems[5].Text.ToString() + "')", connection.conString);

                        int resin = proccessin.ExecuteNonQuery();

                        if (resin > 0)
                        {
                            c = 1;


                        }
                        else
                        {
                            c = 0;
                        }
                    }
                    else
                    {
                        SqlCommand updateweightandqty1 = new SqlCommand("update arrival set Quantity='" + oldqty.ToString() + "',Net_Weight='" + oldweight.ToString() + "' where Arrival_ID='" + item.SubItems[0].Text.ToString() + "'", connection.conString);

                        int re1s = updateweightandqty1.ExecuteNonQuery();

                        if (re1s > 0)
                        {

                            c = 3;

                        }
                        else
                        {

                            c = 0;
                        }
                    }


                }

                if (c == 1)
                {


                    idtxt.Text = "";
                    cusnametxt.Text = "";
                    datetxt.Text = "";
                    vnumbertxt.Text = "";
                    gptxt.Text = "";
                    comtxt.Text = "";
                    qtytxt.Text = "";
                    netweighttxt.Text = "";
                    baardanatxt.Text = "0";
                    searchtxt.Text = "";
                    comboBox1.SelectedIndex = -1;
                    proccesslist.Items.Clear();
                    Arrival_View();
                    MessageBox.Show("Arrival Sent To Proccessing.");

                }
                else if (c == 3)
                {
                    idtxt.Text = "";
                    cusnametxt.Text = "";
                    datetxt.Text = "";
                    vnumbertxt.Text = "";
                    gptxt.Text = "";
                    comtxt.Text = "";
                    qtytxt.Text = "";
                    baardanatxt.Text = "0";
                    netweighttxt.Text = "";
                    searchtxt.Text = "";
                    comboBox1.SelectedIndex = -1;
                    proccesslist.Items.Clear();
                    Arrival_View();
                    MessageBox.Show("Arrival Data Restored.");
                }
                else
                {
                    MessageBox.Show("Error.");
                }
                }
                else
                {
                    MessageBox.Show("Please Add Arrivals To Process List.");
                }
            }
            connection.conString.Close();
            
           
        }
        
        private void baardana_TextChanged(object sender, EventArgs e)
        {
            if (baardanatxt.Text != "" && netweighttxt.Text!="")
            {
                if (baardanatxt.Text == "0")
                {
                    netweighttxt.Text = netweight;
                }
                else
                {
                    float bd = float.Parse(baardanatxt.Text);
                    float minus = float.Parse(netweighttxt.Text) - bd;
                    int newnetweight = Convert.ToInt32(minus);
                    netweighttxt.Text = newnetweight.ToString();
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void proccessarrival_gridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
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

        private void baardana_KeyPress(object sender, KeyPressEventArgs e)
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

        private void baardana_Click(object sender, EventArgs e)
        {
            if(baardanatxt.Text=="0")
            {
                baardanatxt.Text = "";
            }
            
        }

        private void baardana_Leave(object sender, EventArgs e)
        {
            if (baardanatxt.Text == "")
            {
                baardanatxt.Text = "0";
            }
        }
    }
}
