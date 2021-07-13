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
            tableLayoutPanel1.Controls.Add(mainChart1, 0, 1);
            ChartControl ChrtOrt = new ChartControl();

            //button1.Click += (s, a) => { Debug.WriteLine("123"); };
            button1.Click += (s, a) => { ChartControl.UpdDataFromFile(mainChart1); };

            button2.Click += (s, a) => { testZoomChart2(double.Parse(textBox1.Text), mainChart1); };


        }



        private void testZoomChart2(double SetPosition, System.Windows.Forms.DataVisualization.Charting.Chart someChart)
        {
            System.Windows.Forms.DataVisualization.Charting.Axis xAxis = someChart.ChartAreas[0].AxisX;
            //someChart.ChartAreas[0].AxisX.ScaleView.Zoom(20, 1000);
            someChart.ChartAreas[0].AxisX.ScaleView.Zoom(50, 300);

            someChart.ChartAreas[0].AxisX.ScaleView.Position = SetPosition;

            Debug.WriteLine($"xAxisStart: {xAxis.ScaleView.ViewMinimum}");
            Debug.WriteLine($"xAxisEnd: {xAxis.ScaleView.ViewMaximum}");

        }
        private void testZoomChart(System.Windows.Forms.DataVisualization.Charting.Chart someChart)
        {
            Debug.WriteLine($"Минимум до зума: {someChart.ChartAreas[0].AxisX.ScaleView.ViewMinimum}");
            Debug.WriteLine($"Максимум до зума: { someChart.ChartAreas[0].AxisX.ScaleView.ViewMaximum}");
            someChart.ChartAreas[0].AxisX.ScaleView.Zoom(50, 300);
            Debug.WriteLine($"Минимум после зума: {someChart.ChartAreas[0].AxisX.ScaleView.ViewMinimum}");
            Debug.WriteLine($"Максимум после зума: {someChart.ChartAreas[0].AxisX.ScaleView.ViewMaximum}");

            //someChart.ChartAreas[0].AxisY.ScaleView.Zoom(50, 300);

        }
    }
}
