using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formsForTests
{
    public partial class host : Form
    {
        public string someVal
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public host()
        {
            InitializeComponent();
            label1.Text = "Какое-то значение";
            label1.Text = someVal;

        }
    }
}
