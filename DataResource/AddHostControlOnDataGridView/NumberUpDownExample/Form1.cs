using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberUpDownExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Rows.Add("0");
            }
            this.dataGridView1.Columns[0].Width = 150;
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.BeginEdit(true);
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.BeginEdit(true);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
