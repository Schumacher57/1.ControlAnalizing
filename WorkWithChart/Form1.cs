using System.Windows.Forms;
using System.Diagnostics;
using WorkWithChart.ChartOperation;
using WorkWithChart.MyControl;


namespace WorkWithChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

            mainChart mainChart1 = new mainChart();
            //var ChartOp = new WorkWithChart.ChartOperation.ChartControl();
            tableLayoutPanel1.Controls.Add(mainChart1, 0,1);
            ChartControl ChrtOrt = new ChartControl();

            //button1.Click += (s, a) => { Debug.WriteLine("123"); };
            button1.Click += (s, a) => { ChartControl.UpdDataFromFile(mainChart1); };




        }
    }
}
