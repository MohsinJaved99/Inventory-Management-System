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
    public partial class Add_Arrival : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        
        string onaccvalue;
        string onrecvalue = null;
        string sbrand = null;
        string sremarks = null;
        string sbrokername = null;

        string ArrivalID, Gatepass;
        string bagtype;
        public Add_Arrival()
        {
            InitializeComponent();
            Gatepass = "";
            ArrivalID = "";
            commodity.Items.Clear();

            string query = "select * from commodity";

            SqlDataReader sdr;
            SqlCommand cmd = new SqlCommand(query, connection.conString);

            SqlCommand cmd1 = new SqlCommand("SELECT TOP 1(Gate_Pass) as 'gp' FROM arrival ORDER BY Arrival_ID DESC", connection.conString);

            if (connection.conString.State != ConnectionState.Open)
            {
                connection.conString.Open();
            }

            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                commodity.DisplayMember = "Text";
                commodity.ValueMember = "Value";
                commodity.Items.Add(new Combobox(sdr["Commodity_Name"].ToString(), Convert.ToInt32(sdr["Commodity_ID"].ToString())));
            }

            sdr.Close();
            object result = cmd1.ExecuteScalar();
            if (result==null)
            {
                int newgp = 100;
                gate_pass.Text = newgp.ToString();
            }
            else
            {
                int lastgp = Convert.ToInt32(cmd1.ExecuteScalar().ToString());
                int newgp = lastgp + 1;
                gate_pass.Text = newgp.ToString();
            }

            if (connection.conString.State == ConnectionState.Open)
            {
                connection.conString.Close();
            }

        }

   

        public Add_Arrival(string gp,string aid)
        {
            InitializeComponent();
            heading.Text = "Edit Arrival";
            Gatepass = gp;
            ArrivalID = aid;



            commodity.Items.Clear();
            string query = "select * from commodity";
            SqlDataReader sdr;
            SqlCommand cmd = new SqlCommand(query, connection.conString);


            if (connection.conString.State != ConnectionState.Open)
            {
                connection.conString.Open();
            }
            
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                commodity.DisplayMember = "Text";
                commodity.ValueMember = "Value";
                commodity.Items.Add(new Combobox(sdr["Commodity_Name"].ToString(), Convert.ToInt32(sdr["Commodity_ID"].ToString())));
            }

            if (connection.conString.State == ConnectionState.Open)
            {
                connection.conString.Close();
            }



            SqlDataAdapter dtp3 = new SqlDataAdapter("select a.Arrival_Date as 'Arrival_Date',a.Customer_ID as 'Customer_ID',a.Received_From as 'Received_From',c.Customer_Name as 'Customer_Name',COALESCE(rc.Customer_Name, '') as 'Received_From',COALESCE(a.Broker_Name, '') as 'Broker_Name',a.Vehicle_Number as 'Vehicle_Number',a.Gate_Pass as 'Gate_Pass',com.Commodity_Name as 'Commodity_Name',COALESCE(a.Brand,'') as 'Brand',bag.Bag_Name as 'Bag_Name',a.Quantity as 'Quantity',a.Pack_Weight as 'Pack_Weight',a.Net_Weight as 'Net_Weight',COALESCE(a.Remarks,'') as 'Remarks' from arrival a join customer c on a.Customer_ID=c.Customer_ID join commodity com on a.Commodity_ID=com.Commodity_ID join Bags bag on a.Bag_ID=bag.Bag_ID left join customer rc on rc.Customer_ID=a.Received_From where a.Gate_Pass='" + Gatepass + "'", connection.conString);
       
            DataTable tp3 = new DataTable();
            dtp3.Fill(tp3);

            foreach (DataRow row1 in tp3.Rows)
            {
                arrival_date.Text = row1["Arrival_Date"].ToString();
                on_account_of.Text = row1["Customer_Name"].ToString();
                received_from.Text = row1["Received_From"].ToString();
                broker_name.Text = row1["Broker_Name"].ToString();

                vehicle_number.Text = row1["Vehicle_Number"].ToString();
                gate_pass.Text = row1["Gate_Pass"].ToString(); 
                commodity.SelectedIndex = commodity.FindString(row1["Commodity_Name"].ToString());
                brand.Text = row1["Brand"].ToString();

                quantity.Text = row1["Quantity"].ToString();
                pack_weight.Text = row1["Pack_Weight"].ToString();
                net_weight.Text = row1["Net_Weight"].ToString();
                remarks.Text = row1["Remarks"].ToString();

                if(row1["Bag_Name"].ToString()=="PP")
                {
                    PP.Checked = true;
                }
                else if(row1["Bag_Name"].ToString() == "PB")
                {
                    PB.Checked = true;
                }
                else if (row1["Bag_Name"].ToString() == "Jute Bag")
                {
                    JUTE.Checked = true;
                }

                onaccvalue= row1["Customer_ID"].ToString();
                if(row1["Customer_ID"].ToString()!="" || row1["Customer_ID"].ToString()!=null) {
                    onrecvalue = row1["Received_From"].ToString();
                }
                else
                {
                    onrecvalue = null;
                }

            }

            on_account_of_list.Visible = false;
            received_from_list.Visible = false;
        }

        private void Add_Arrival_Load(object sender, EventArgs e)
        {

           
            



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        int lastgatepass;
        string id;
        private void home_Click(object sender, EventArgs e)
        {
            if(onaccvalue!="" && vehicle_number.Text!="" && commodity.SelectedIndex!=-1 && quantity.Text!="" && pack_weight.Text!="" && net_weight.Text!="" && bagtype!="")
            {



                string getinprocess = "select count(*) as 'count' from proccess_in where Arrival_ID='" + ArrivalID + "'";
                connection.conString.Close();
                connection.conString.Open();
                SqlCommand cc = new SqlCommand(getinprocess, connection.conString);
                int count = Convert.ToInt32(cc.ExecuteScalar().ToString());
                if (count > 0)
                {
                    MessageBox.Show("You can't update this arrival, because it is in process or it maybe processed.");
                }
                else
                {

                    if (Gatepass == "")
                    {

                        var commodity_combo = commodity.SelectedItem as Combobox;
                        //MessageBox.Show(commodity_combo.Value.ToString());



                        SqlCommand cm = new SqlCommand("insert into arrival(Arrival_Date,Customer_ID,Received_From,Vehicle_Number,Gate_Pass,Commodity_ID,Brand,Broker_Name,Quantity,Pack_Weight,Bag_ID,Net_Weight,Remarks) values (@date,@custid,@rec,@vnumber,@gatepass,@commodity,@brand,@broker,@quantity,@pack,@bag,@netweight,@remarks)", connection.conString);
                        cm.Parameters.AddWithValue("@date", arrival_date.Text.ToString());
                        cm.Parameters.AddWithValue("@custid", onaccvalue);


                        if (received_from.Text == "")
                        {
                            cm.Parameters.AddWithValue("@rec", DBNull.Value);
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@rec", onrecvalue);
                        }

                        cm.Parameters.AddWithValue("@vnumber", vehicle_number.Text.ToUpper());
                        cm.Parameters.AddWithValue("@gatepass", gate_pass.Text);
                        cm.Parameters.AddWithValue("@commodity", commodity_combo.Value.ToString());

                        if (broker_name.Text == "")
                        {
                            cm.Parameters.AddWithValue("@broker", DBNull.Value);
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@broker", broker_name.Text);
                        }

                        if (brand.Text == "")
                        {
                            cm.Parameters.AddWithValue("@brand", DBNull.Value);
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@brand", brand.Text);
                        }

                        cm.Parameters.AddWithValue("@quantity", quantity.Text);
                        cm.Parameters.AddWithValue("@pack", pack_weight.Text);
                        cm.Parameters.AddWithValue("@bag", bagtype);
                        cm.Parameters.AddWithValue("@netweight", net_weight.Text);


                        if (remarks.Text == "")
                        {
                            cm.Parameters.AddWithValue("@remarks", DBNull.Value);
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@remarks", remarks.Text);
                        }

                        int res = cm.ExecuteNonQuery();

                        if (res > 0)
                        {


                            SqlCommand cm1 = new SqlCommand("insert into arrival_stock(Arrival_Date,Customer_ID,Received_From,Vehicle_Number,Gate_Pass,Commodity_ID,Brand,Broker_Name,Quantity,Pack_Weight,Bag_ID,Net_Weight,Remarks) values (@date1,@custid1,@rec1,@vnumber1,@gatepass1,@commodity1,@brand1,@broker1,@quantity1,@pack1,@bag1,@netweight1,@remarks1)", connection.conString);
                            cm1.Parameters.AddWithValue("@date1", arrival_date.Text.ToString());
                            cm1.Parameters.AddWithValue("@custid1", onaccvalue);


                            if (received_from.Text == "")
                            {
                                cm1.Parameters.AddWithValue("@rec1", DBNull.Value);
                            }
                            else
                            {
                                cm1.Parameters.AddWithValue("@rec1", onrecvalue);
                            }

                            cm1.Parameters.AddWithValue("@vnumber1", vehicle_number.Text.ToUpper());
                            cm1.Parameters.AddWithValue("@gatepass1", gate_pass.Text);
                            cm1.Parameters.AddWithValue("@commodity1", commodity_combo.Value.ToString());

                            if (broker_name.Text == "")
                            {
                                cm1.Parameters.AddWithValue("@broker1", DBNull.Value);
                            }
                            else
                            {
                                cm1.Parameters.AddWithValue("@broker1", broker_name.Text);
                            }

                            if (brand.Text == "")
                            {
                                cm1.Parameters.AddWithValue("@brand1", DBNull.Value);
                            }
                            else
                            {
                                cm1.Parameters.AddWithValue("@brand1", brand.Text);
                            }

                            cm1.Parameters.AddWithValue("@quantity1", quantity.Text);
                            cm1.Parameters.AddWithValue("@pack1", pack_weight.Text);
                            cm1.Parameters.AddWithValue("@bag1", bagtype);
                            cm1.Parameters.AddWithValue("@netweight1", net_weight.Text);


                            if (remarks.Text == "")
                            {
                                cm1.Parameters.AddWithValue("@remarks1", DBNull.Value);
                            }
                            else
                            {
                                cm1.Parameters.AddWithValue("@remarks1", remarks.Text);
                            }



                            int res1 = cm1.ExecuteNonQuery();

                            if (res1 > 0)
                            {

                                MessageBox.Show("arrival added to stock!");
                                var result = MessageBox.Show("Do you want to print arrival report?", "Report!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (result == DialogResult.Yes)
                                {
                                    SqlCommand cmm = new SqlCommand("SELECT TOP 1(Arrival_Stock_ID) as 'Arrival_ID' FROM arrival_stock ORDER BY Arrival_Stock_ID DESC", connection.conString);
                                    id = cmm.ExecuteScalar().ToString();
                                    loginloading l = new loginloading();
                                    l.ShowDialog();
                                        using (arrival_report ac = new arrival_report(id))
                                        {
                                            l.Close();
                                            ac.ShowDialog();
                                            this.Close();
                                        }
                                }
                                
                                else
                                {
                                    this.Close();
                                }


                            }
                            else
                            {
                                MessageBox.Show("error! while creating stock");
                            }

                        }
                        else
                        {
                            MessageBox.Show("error! while creating arrival");
                        }



                        connection.conString.Close();


                    }
                    else
                    {
                        var commodity_combo = commodity.SelectedItem as Combobox;
                        //MessageBox.Show(commodity_combo.Value.ToString());


                        if (connection.conString.State != ConnectionState.Open)
                        {
                            connection.conString.Open();
                        }
                        SqlCommand cm = new SqlCommand("update arrival set Arrival_Date=@date,Customer_ID=@custid,Received_From=@rec,Vehicle_Number=@vnumber,Gate_Pass=@gatepass,Commodity_ID=@commodity,Brand=@brand,Broker_Name=@broker,Quantity=@quantity,Pack_Weight=@pack,Bag_ID=@bag,Net_Weight=@netweight,Remarks=@remarks where Gate_Pass='" + Gatepass + "'", connection.conString);
                        cm.Parameters.AddWithValue("@date", arrival_date.Text.ToString());
                        cm.Parameters.AddWithValue("@custid", onaccvalue);

                        if (broker_name.Text == "")
                        {
                            cm.Parameters.AddWithValue("@broker", DBNull.Value);
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@broker", broker_name.Text);
                        }

                        if (received_from.Text == "")
                        {
                            cm.Parameters.AddWithValue("@rec", DBNull.Value);
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@rec", onrecvalue);
                        }

                        cm.Parameters.AddWithValue("@vnumber", vehicle_number.Text.ToUpper());
                        cm.Parameters.AddWithValue("@gatepass", gate_pass.Text);
                        cm.Parameters.AddWithValue("@commodity", commodity_combo.Value.ToString());

                        if (brand.Text == "")
                        {
                            cm.Parameters.AddWithValue("@brand", DBNull.Value);
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@brand", brand.Text);
                        }

                        cm.Parameters.AddWithValue("@quantity", quantity.Text);
                        cm.Parameters.AddWithValue("@pack", pack_weight.Text);
                        cm.Parameters.AddWithValue("@bag", bagtype);
                        cm.Parameters.AddWithValue("@netweight", net_weight.Text);


                        if (remarks.Text == "")
                        {
                            cm.Parameters.AddWithValue("@remarks", DBNull.Value);
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@remarks", remarks.Text);
                        }



                        //MessageBox.Show(cm.CommandText);

                        int res = cm.ExecuteNonQuery();

                        if (res > 0)
                        {

                            SqlCommand cm1 = new SqlCommand("update arrival_stock set Arrival_Date=@date,Customer_ID=@custid,Received_From=@rec,Vehicle_Number=@vnumber,Gate_Pass=@gatepass,Commodity_ID=@commodity,Brand=@brand,Broker_Name=@broker,Quantity=@quantity,Pack_Weight=@pack,Bag_ID=@bag,Net_Weight=@netweight,Remarks=@remarks where Gate_Pass='" + Gatepass + "'", connection.conString);
                            cm1.Parameters.AddWithValue("@date", arrival_date.Text.ToString());
                            cm1.Parameters.AddWithValue("@custid", onaccvalue);

                            if (broker_name.Text == "")
                            {
                                cm1.Parameters.AddWithValue("@broker", DBNull.Value);
                            }
                            else
                            {
                                cm1.Parameters.AddWithValue("@broker", broker_name.Text);
                            }

                            if (received_from.Text == "")
                            {
                                cm1.Parameters.AddWithValue("@rec", DBNull.Value);
                            }
                            else
                            {
                                cm1.Parameters.AddWithValue("@rec", onrecvalue);
                            }

                            cm1.Parameters.AddWithValue("@vnumber", vehicle_number.Text.ToUpper());
                            cm1.Parameters.AddWithValue("@gatepass", gate_pass.Text);
                            cm1.Parameters.AddWithValue("@commodity", commodity_combo.Value.ToString());

                            if (brand.Text == "")
                            {
                                cm1.Parameters.AddWithValue("@brand", DBNull.Value);
                            }
                            else
                            {
                                cm1.Parameters.AddWithValue("@brand", brand.Text);
                            }

                            cm1.Parameters.AddWithValue("@quantity", quantity.Text);
                            cm1.Parameters.AddWithValue("@pack", pack_weight.Text);
                            cm1.Parameters.AddWithValue("@bag", bagtype);
                            cm1.Parameters.AddWithValue("@netweight", net_weight.Text);


                            if (remarks.Text == "")
                            {
                                cm1.Parameters.AddWithValue("@remarks", DBNull.Value);
                            }
                            else
                            {
                                cm1.Parameters.AddWithValue("@remarks", remarks.Text);
                            }



                            //MessageBox.Show(cm.CommandText);

                            int res1 = cm1.ExecuteNonQuery();

                            if (res1 > 0)
                            {
                                MessageBox.Show("arrival updated to stock!");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("error!");
                            }




                        }
                        else
                        {
                            MessageBox.Show("error!");
                        }


                    }
                    

                    connection.conString.Close();

                }




            }
            else
            {
                MessageBox.Show("Please fill all required fields.");
            }
            
            
        }

        private void on_account_of_TextChanged(object sender, EventArgs e)
        {
            if (on_account_of.Text == "")
            {
                onaccvalue = null;
            }
            else
            {
                on_account_of_list.Items.Clear();
                string query = "select * from customer where Customer_Name like '" + on_account_of.Text + "%'";
                SqlDataReader sdr;
                SqlCommand cmd = new SqlCommand(query, connection.conString);

                if (connection.conString.State != ConnectionState.Open)
                {
                    connection.conString.Open();
                }
              
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    on_account_of_list.Enabled = true;
                    while (sdr.Read())
                    {
                        on_account_of_list.DisplayMember = "Text";
                        on_account_of_list.ValueMember = "Value";
                        on_account_of_list.Items.Add(new Combobox(sdr["Customer_Name"].ToString(), Convert.ToInt32(sdr["Customer_ID"].ToString())));
                    }
                }
                else
                {
                    on_account_of_list.Items.Add("No Customer Found.");
                    on_account_of_list.Enabled = false;
                }
               

                if (connection.conString.State == ConnectionState.Open)
                {
                    connection.conString.Close();
                }
                on_account_of_list.Visible = true;
            }
        }

        private void received_from_TextChanged(object sender, EventArgs e)
        {
            if (received_from.Text == "")
            {
                onrecvalue = null;
            }
            else
            {

                received_from_list.Items.Clear();
                string query = "select * from customer where Customer_Name like '" + received_from.Text + "%'";
                SqlDataReader sdr;
                SqlCommand cmd = new SqlCommand(query, connection.conString);

                if (connection.conString.State != ConnectionState.Open)
                {
                    connection.conString.Open();
                }

                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    received_from_list.Enabled = true;
                    while (sdr.Read())
                    {
                        received_from_list.DisplayMember = "Text";
                        received_from_list.ValueMember = "Value";
                        received_from_list.Items.Add(new Combobox(sdr["Customer_Name"].ToString(), Convert.ToInt32(sdr["Customer_ID"].ToString())));
                    }
                }
                else
                {
                    received_from_list.Items.Add("No Customer Found.");
                    received_from_list.Enabled = false;
                }

                if (connection.conString.State == ConnectionState.Open)
                {
                    connection.conString.Close();
                }
                received_from_list.Visible = true;
            }
        }

        private void on_account_of_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (on_account_of_list.SelectedIndex.ToString() == "-1")
            {
            }
            else
            {
                var selectedAcc = on_account_of_list.SelectedItem as Combobox;

                string text = selectedAcc.Text.ToString();
                onaccvalue = selectedAcc.Value.ToString();
                on_account_of.Text = text;
                on_account_of_list.Visible = false;
            }
        }

        private void Add_Arrival_Click(object sender, EventArgs e)
        {
            on_account_of_list.Visible = false;
            received_from_list.Visible = false;
        }

        private void PP_CheckedChanged(object sender, EventArgs e)
        {
            bagtype = "1";
        }

        private void PB_CheckedChanged(object sender, EventArgs e)
        {
            bagtype = "2";
        }

        private void broker_name_TextChanged(object sender, EventArgs e)
        {
            if (broker_name.Text == "")
            {
                sbrokername = null;
            }
            else
            {
                sbrokername = broker_name.Text;
            }
        }

        private void brand_TextChanged(object sender, EventArgs e)
        {
            if (brand.Text == "")
            {
                sbrand = null;
            }
            else
            {
                sbrand = brand.Text;
            }
        }

        private void remarks_TextChanged(object sender, EventArgs e)
        {
            if (remarks.Text == "")
            {
                sremarks = null;
            }
            else
            {
                sremarks = remarks.Text;
            }
        }

        private void JUTE_CheckedChanged(object sender, EventArgs e)
        {
            bagtype = "3";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void received_from_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (received_from_list.SelectedIndex.ToString() == "-1")
            {
            }
            else
            {
                var selectedAcc = received_from_list.SelectedItem as Combobox;

                string text1 = selectedAcc.Text.ToString();
                onrecvalue = selectedAcc.Value.ToString();
                received_from.Text = text1;
                received_from_list.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void net_weight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void quantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pack_weight_KeyPress(object sender, KeyPressEventArgs e)
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
