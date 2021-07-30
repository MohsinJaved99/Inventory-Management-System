using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_System
{
    public partial class loginloading : Form
    {
        public loginloading()
        {
            InitializeComponent();
        }
        public int a = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            a++;
            if (a == 30)
            {
                timer1.Stop();
                this.Dispose();
            }
        }

        private void loginloading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
