using System.Windows.Forms;

namespace formsForTests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            formUpd.myLayoutPanel = tableLayoutPanel1;

            formUpd.myLayoutUpd();

            button1.Click += (s, a) =>
            {
                //var myNewWwtich = new ToggleSwitch.();

                //tableLayoutPanel1.Controls.Add(myNewWwtich, 0, 0);
                host myTwoForm = new host();
                myTwoForm.someVal = "Передаю значение!";
                myTwoForm.Show();
            };


        }
    }


}
