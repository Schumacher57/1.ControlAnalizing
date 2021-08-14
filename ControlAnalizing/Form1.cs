using System;
using System.Windows.Forms;
using System.Diagnostics;
using ControlAnalizing.Controls.MainMenuStrip;

namespace ControlAnalizing
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            // Добавляем контролы на форму
            UpMenuStrip UpMainMenuStrip = new UpMenuStrip();
            Controls.Add(UpMainMenuStrip);


        }





    }
}
