﻿namespace Management_System.UserControls
{
    partial class arrivedstock
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.arrival_gridview = new System.Windows.Forms.DataGridView();
            this.Arrival_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arrival_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Received_From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Broker_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vehicle_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gate_Pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Commodity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bag_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pack_Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Net_Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchtxt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.arrival_gridview)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // arrival_gridview
            // 
            this.arrival_gridview.AllowUserToAddRows = false;
            this.arrival_gridview.AllowUserToDeleteRows = false;
            this.arrival_gridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.arrival_gridview.BackgroundColor = System.Drawing.Color.White;
            this.arrival_gridview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.arrival_gridview.ColumnHeadersHeight = 38;
            this.arrival_gridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Arrival_ID,
            this.Arrival_Date,
            this.Customer_Name,
            this.Received_From,
            this.Broker_Name,
            this.Vehicle_Number,
            this.Gate_Pass,
            this.Commodity,
            this.Brand,
            this.Bag_Type,
            this.Quantity,
            this.Pack_Weight,
            this.Net_Weight,
            this.Remarks});
            this.arrival_gridview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.arrival_gridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arrival_gridview.GridColor = System.Drawing.Color.Black;
            this.arrival_gridview.Location = new System.Drawing.Point(5, 123);
            this.arrival_gridview.Margin = new System.Windows.Forms.Padding(2);
            this.arrival_gridview.Name = "arrival_gridview";
            this.arrival_gridview.ReadOnly = true;
            this.arrival_gridview.RowHeadersVisible = false;
            this.arrival_gridview.RowTemplate.Height = 30;
            this.arrival_gridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.arrival_gridview.Size = new System.Drawing.Size(1312, 564);
            this.arrival_gridview.TabIndex = 48;
            this.arrival_gridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.arrival_gridview_CellClick);
            // 
            // Arrival_ID
            // 
            this.Arrival_ID.HeaderText = "Arrival ID";
            this.Arrival_ID.Name = "Arrival_ID";
            this.Arrival_ID.ReadOnly = true;
            this.Arrival_ID.Visible = false;
            // 
            // Arrival_Date
            // 
            this.Arrival_Date.FillWeight = 122.0297F;
            this.Arrival_Date.HeaderText = "Arrival Date";
            this.Arrival_Date.Name = "Arrival_Date";
            this.Arrival_Date.ReadOnly = true;
            // 
            // Customer_Name
            // 
            this.Customer_Name.FillWeight = 122.0297F;
            this.Customer_Name.HeaderText = "Customer Name";
            this.Customer_Name.Name = "Customer_Name";
            this.Customer_Name.ReadOnly = true;
            // 
            // Received_From
            // 
            this.Received_From.FillWeight = 122.0297F;
            this.Received_From.HeaderText = "Received From";
            this.Received_From.Name = "Received_From";
            this.Received_From.ReadOnly = true;
            // 
            // Broker_Name
            // 
            this.Broker_Name.FillWeight = 122.0297F;
            this.Broker_Name.HeaderText = "Broker Name";
            this.Broker_Name.Name = "Broker_Name";
            this.Broker_Name.ReadOnly = true;
            // 
            // Vehicle_Number
            // 
            this.Vehicle_Number.FillWeight = 88.04605F;
            this.Vehicle_Number.HeaderText = "Vehicle Number";
            this.Vehicle_Number.Name = "Vehicle_Number";
            this.Vehicle_Number.ReadOnly = true;
            // 
            // Gate_Pass
            // 
            this.Gate_Pass.FillWeight = 75.09678F;
            this.Gate_Pass.HeaderText = "Gate Pass";
            this.Gate_Pass.Name = "Gate_Pass";
            this.Gate_Pass.ReadOnly = true;
            // 
            // Commodity
            // 
            this.Commodity.FillWeight = 122.0297F;
            this.Commodity.HeaderText = "Commodity";
            this.Commodity.Name = "Commodity";
            this.Commodity.ReadOnly = true;
            // 
            // Brand
            // 
            this.Brand.FillWeight = 65.98985F;
            this.Brand.HeaderText = "Brand";
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            // 
            // Bag_Type
            // 
            this.Bag_Type.FillWeight = 61.98333F;
            this.Bag_Type.HeaderText = "Bag";
            this.Bag_Type.Name = "Bag_Type";
            this.Bag_Type.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.FillWeight = 85.84173F;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Pack_Weight
            // 
            this.Pack_Weight.FillWeight = 68.8345F;
            this.Pack_Weight.HeaderText = "Pack";
            this.Pack_Weight.Name = "Pack_Weight";
            this.Pack_Weight.ReadOnly = true;
            // 
            // Net_Weight
            // 
            this.Net_Weight.FillWeight = 122.0297F;
            this.Net_Weight.HeaderText = "Net Weight";
            this.Net_Weight.Name = "Net_Weight";
            this.Net_Weight.ReadOnly = true;
            // 
            // Remarks
            // 
            this.Remarks.FillWeight = 122.0297F;
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1312, 65);
            this.panel1.TabIndex = 47;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(66)))), ((int)(((byte)(0)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::Management_System.Properties.Resources.icons8_print_24;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(135, 65);
            this.button3.TabIndex = 40;
            this.button3.Text = "Print";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.searchtxt);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(885, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 5, 5, 2);
            this.panel2.Size = new System.Drawing.Size(427, 65);
            this.panel2.TabIndex = 38;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Arrival Date",
            "Customer Name",
            "Received From",
            "Vehicle Number",
            "Gate Pass",
            "Commodity",
            "Brand",
            "Broker Name",
            "Pack Weight",
            "Bag Type"});
            this.comboBox1.Location = new System.Drawing.Point(8, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(155, 31);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.label1.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Search Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // searchtxt
            // 
            this.searchtxt.Enabled = false;
            this.searchtxt.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtxt.Location = new System.Drawing.Point(169, 28);
            this.searchtxt.Name = "searchtxt";
            this.searchtxt.Size = new System.Drawing.Size(250, 31);
            this.searchtxt.TabIndex = 6;
            this.searchtxt.TextChanged += new System.EventHandler(this.searchtxt_TextChanged);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.label13.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(169, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(250, 19);
            this.label13.TabIndex = 5;
            this.label13.Text = "Search";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(5, 682);
            this.panel7.TabIndex = 46;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1317, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(5, 682);
            this.panel6.TabIndex = 45;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 687);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1322, 5);
            this.panel5.TabIndex = 44;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1322, 5);
            this.panel4.TabIndex = 43;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel3.Controls.Add(this.label15);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1312, 53);
            this.panel3.TabIndex = 49;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(1312, 53);
            this.label15.TabIndex = 93;
            this.label15.Text = "A R R I V A L S   R E C O R D S";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // arrivedstock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.arrival_gridview);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Name = "arrivedstock";
            this.Size = new System.Drawing.Size(1322, 692);
            ((System.ComponentModel.ISupportInitialize)(this.arrival_gridview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView arrival_gridview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchtxt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arrival_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arrival_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Received_From;
        private System.Windows.Forms.DataGridViewTextBoxColumn Broker_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vehicle_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gate_Pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Commodity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bag_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pack_Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Net_Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.Button button3;
    }
}
