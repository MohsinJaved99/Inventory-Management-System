using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_System
{
    class Combobox
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public Combobox(string text, int value)
        {
            this.Text = text;
            this.Value = value;
        }
    }
}
