using System.Windows.Forms;
using System;
//using OxyPlot;
//using OxyPlot.Series;
using System.Diagnostics;
using WorkWithChart.ChartOperation;
using WorkWithChart.MyControl;
using System.Windows.Forms.DataVisualization.Charting;


namespace WorkWithChart
{
    public partial class Form1 : Form
    {
        private long iCounter = 1;
        private float percentStep = 0.4f;
        TextWriterTraceListener report = new TextWriterTraceListener(System.IO.File.CreateText(@"d:\Books\Document\Google disk\Work\Programming\C#\Текущие проекты\1. ControlAnalizing\DataResource\Measure\report.txt"));


        public Form1()
        {

            InitializeComponent();


            mainChart mainChart1 = new mainChart();
            //var mainChart2 = new PlotModel();

            tableLayoutPanel1.Controls.Add(mainChart1, 0, 1);
            //ChartControl ChrtOrt = new ChartControl();


            button1.Click += (s, a) => { ChartControl.UpdDataFromFile(mainChart1); };
            textBox1.Text = "837,57";
            textBox1.KeyDown += (s, a) => { if (a.KeyCode == Keys.Enter) testZoomChart3(double.Parse(textBox1.Text), mainChart1); };
            button2.Click += (s, a) => { testZoomChart3(double.Parse(textBox1.Text), mainChart1); };


        }

        private void testZoomChart3(double SetMousePosition, Chart someChart)
        {
            Axis xAxis = someChart.ChartAreas[0].AxisX;

            try
            {




                double xMin = xAxis.ScaleView.ViewMinimum;
                double xMax = xAxis.ScaleView.ViewMaximum;
                double xMosePos = SetMousePosition;
                double xStep = ((xMax - xMin) * percentStep) / 2;

                /*xAxis.ScaleView.Zoom(8+10, xMax);
                report.WriteLine($"xMin:\t{xMin}");
                report.WriteLine($"xMax:\t{xMax}");*/
                //xAxis.ScaleView.;


                // Условие для правой части графика
                if (xMosePos - ((xMax - xMin) / 2) > xMin)
                {
                    double tmpVal = xAxis.PixelPositionToValue(SetMousePosition);
                    double tmpXmin = xMin+10; // Вот тут главная засада <-------------  !!!!!!!!!!!
                    
                    report.WriteLine($"{iCounter}—————————————————————————————————————————— Правая\n");
                    report.WriteLine("ДО Шага:");
                    report.WriteLine($"xMax\t{xMax}");
                    report.WriteLine($"SetMousePosToval({SetMousePosition})\t{xAxis.PixelPositionToValue(SetMousePosition)}");
                    report.WriteLine($"tmpVal:\t{tmpVal}");

                    // Начинем какие-либо вычисления
                    xAxis.ScaleView.Zoom(xMin + 10, xMax);
                    someChart.Refresh();
                    xMax = xAxis.ScaleView.ViewMaximum;
                    //xAxis.ScaleView.Position = tmpXmin - (Math.Abs(tmpVal - xAxis.PixelPositionToValue(SetMousePosition)));
                    
                    report.WriteLine($"\nxMin:\t{xMin}");
                    report.WriteLine($"xMin - (tmpVal - CurVal)\t{xMin-(Math.Abs(tmpVal- xAxis.PixelPositionToValue(SetMousePosition)))}");

                    //xAxis.ScaleView.Position = xMin + Math.Abs(xAxis.PixelPositionToValue(SetMousePosition) - tmpVal);


                    report.WriteLine("\nПОСЛЕ ШАГА:");
                    report.WriteLine($"xMax:\t{xMax}");
                    report.WriteLine($"SetMousePosToval({SetMousePosition})\t{xAxis.PixelPositionToValue(SetMousePosition)}");
                    report.WriteLine($"tmpVal:\t{tmpVal}");

                    report.WriteLine($"Разница tmpVal - CurVal:\t{tmpVal - xAxis.PixelPositionToValue(SetMousePosition)}");
                }

                // Условие для левой части графика
                if (xMosePos + ((xMax - xMin) / 2) < xMax)
                {

                    float tmpVal = (float)xAxis.PixelPositionToValue(SetMousePosition);
                    //= Math.Round(xAxis.ValueToPixelPosition(25), 2);

                    report.WriteLine($"{iCounter}——————————————————————————————————————————\n");
                    report.WriteLine("ДО:");
                    //report.WriteLine($"25 в пикселах:\t{Math.Round(xAxis.ValueToPixelPosition(25), 2)}");
                    report.WriteLine($"{SetMousePosition}px в Vals:\t{Math.Round(xAxis.PixelPositionToValue(SetMousePosition), 2)}");
                    report.WriteLine($"xMin:\t{Math.Round(xMin, 2)}");
                    //report.WriteLine($"curVal в пикселах:\t{Math.Round(xAxis.ValueToPixelPosition(tmpVal), 2)}");


                    // Начинем какие-либо вычисления
                    xAxis.ScaleView.Zoom(xMin, xMax - xStep);
                    someChart.Refresh();
                    xMax = xAxis.ScaleView.ViewMaximum;

                    xAxis.ScaleView.Position = xMin + Math.Abs(xAxis.PixelPositionToValue(SetMousePosition) - tmpVal);
                    //xAxis.ScaleView.Position = xMin + Math.Abs(mousePos2 - mousePos1);




                    // После вычисдения
                    report.WriteLine("\nПОСЛЕ:");
                    //report.WriteLine($"25 в пикселах\t{Math.Round(xAxis.ValueToPixelPosition(25), 2)}");
                    report.WriteLine($"{SetMousePosition}px в Vals:\t{Math.Round(xAxis.PixelPositionToValue(SetMousePosition), 2)}");
                    report.WriteLine($"xMin:\t{Math.Round(xMin, 2)}");

                    report.WriteLine($"px25AftherOnVals:\t{Math.Round(xAxis.PixelPositionToValue(tmpVal), 2)}");
                    report.WriteLine($"diffVals:\t{Math.Round(xAxis.PixelPositionToValue(tmpVal) - 25, 2)}");

                }
            }

            catch { xAxis.ScaleView.ZoomReset(); Debug.Write("Сброс \n"); }




            // Производим запись в отчёт
            report.WriteLine("");
            ++iCounter;
            report.Flush();


        }


        private void funcUpdZooom(Axis slAxis, double xStart, double xStop)
        {
            slAxis.ScaleView.Zoom(xStart, xStop);
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
