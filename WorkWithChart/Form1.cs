using System.Windows.Forms;
using System.Diagnostics;
using WorkWithChart.ChartOperation;


namespace WorkWithChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

            //var ChartOp = new WorkWithChart.ChartOperation.ChartControl();

            ChartControl ChrtOrt = new ChartControl();

            //button1.Click += (s, a) => { Debug.WriteLine("123"); };
            button1.Click += (s, a) => { ChartControl.UpdDataFromFile (chart1); };




        }
    }
}
