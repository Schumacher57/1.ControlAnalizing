using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WorkWithChart.MyControl;
using WorkWithChart.MyDataType;
using ZedGraph;

namespace WorkWithChart
{
    public partial class Form1 : Form
    {

        public GraphPane curPaint;
        TextWriterTraceListener report = new TextWriterTraceListener(System.IO.File.CreateText(@"d:\Books\Document\Google disk\Work\Programming\C#\Текущие проекты\1. ControlAnalizing\DataResource\Measure\report.txt"));


        public Form1()
        {

            InitializeComponent();
            ChartArea myCrtAr = new ChartArea();



            System.Windows.Forms.Label ZDLabel = new System.Windows.Forms.Label();
            ZDLabel.Visible = false;
            Panel MyMainPanel = new Panel();
            MyMainPanel.Dock = DockStyle.Fill;

            mainChart mainChart1 = new mainChart(); // Вариант с MS Chart
            myZedGraph mainZed = new myZedGraph(ZDLabel);  // Вариант с ZedGraph


            curPaint = mainZed.GraphPane;
            


            tableLayoutPanel1.Controls.Add(MyMainPanel, 0, 1); // Добавляем ZedGraph

            MyMainPanel.Controls.Add(mainZed);
            MyMainPanel.Controls.Add(ZDLabel);
            ZDLabel.BringToFront();
            //tableLayoutPanel1.Controls.Add(mainZed, 0, 1); // Добавляем ZedGraph

            button1.Click += (s, e) =>
            {
                EMfield EMf1 = new EMfield();
                Measure Measur1 = EMf1.Measure.GetMeasureFromFile(@"d:\Books\Document\Google disk\Work\Programming\C#\Текущие проекты\1. ControlAnalizing\DataResource\Measure\+ data_30-6000_El.txt");
                Measur1.InfoToFile();
                Measur1.GetLineForSig();
                //curPaint.CurveList.Clear();
                curPaint.AddCurve("Бла бла бла", Measur1.GetLineForSig(), System.Drawing.Color.Red, SymbolType.None);
                curPaint.YAxisList[0].MinSpace = 1.2f;
                curPaint.YAxisList[0].Scale.Min = 0;
                /*curPaint.XAxis.Scale.Min = 0;
                curPaint.XAxis.Scale.Max = 120;
                curPaint.YAxis.Scale.Min = 0;
                curPaint.YAxis.Scale.Max = 75;*/
                //curPaint.Value

                //mainZed.mouse
                curPaint.AxisChange();
                mainZed.AxisChange();
                mainZed.Invalidate();

            };

            report.Flush();

        }

    }
}
