﻿using System.Diagnostics;
using System.Windows.Forms;

namespace ToggleButtonExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.Controls.Add(new ToggleSwitch());
            button1.Click += (s, a) => { updateTableLayout(); };

        }

        public void updateTableLayout()
        {
            var myTbl = tableLayoutPanel2;
            for (int i = 0; i < myTbl.RowCount - 1; i++)
            {
                myTbl.Controls.Add(new ToggleSwitch(), 0, i);
            }

            Debug.WriteLine(myTbl.RowStyles[1].Height);
            myTbl.RowStyles[0].Height = 30;
        }

    }
}
