using System.Windows.Forms;
using formsForTests.TestClass;
namespace formsForTests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            formUpd.myLayoutPanel = tableLayoutPanel1;

            formUpd.myLayoutUpd();
            TestDataWithTableLayOut someData1 = new TestDataWithTableLayOut();
            SomeClassWithControls someControls = new SomeClassWithControls();
            someControls.TestLayOutPanel = someData1.MainLayOutPanel;

            this.Controls.Add(someData1.MainLayOutPanel);



            button1.Click += (s, a) =>
            {
                someControls.isVisible = someControls.isVisible ? false : true;


                //var myNewWwtich = new ToggleSwitch.();
                //tableLayoutPanel1.Controls.Add(myNewWwtich, 0, 0);
                /*host myTwoForm = new host();
                myTwoForm.someVal = "Передаю значение!";
                myTwoForm.ShowDialog();*/
            };


        }
    }


}
