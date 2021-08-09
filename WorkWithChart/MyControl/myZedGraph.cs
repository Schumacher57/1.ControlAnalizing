using System.Diagnostics;
using System.Windows.Forms;
using ZedGraph;
using System;


namespace WorkWithChart.MyControl
{
    class myZedGraph : ZedGraph.ZedGraphControl
    {
        TextWriterTraceListener ZdGraphReport = new TextWriterTraceListener(@"d:\Books\Document\Google disk\Work\Programming\C#\Текущие проекты\1. ControlAnalizing\DataResource\Measure\ReportFiles\zdGraphReport.txt");

        double xAxisMin = -5;
        double xAxisMax = 6100;
        double yAxisMin = 8.5f;
        double yAxisMax = 45;
        double xPos, yPos;

        int tmpCounter = 0;
        LineObj lineCross;
        public System.Windows.Forms.Label ZdLabel;



        public myZedGraph(System.Windows.Forms.Label ZdLabel)
        {
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SuspendLayout();
            this.Name = "myZedGraph";
            this.ResumeLayout(false);
            this.GraphPane.CurveList.Clear();

            this.GraphPane.XAxis.Scale.Min = 0;
            this.GraphPane.XAxis.Scale.Max = 6005;
            this.GraphPane.YAxis.Scale.Min = 0;
            this.GraphPane.YAxis.Scale.Max = 75;

            /*lastYAxisMax = this.GraphPane.YAxis.Scale.Max;
            lastYAxisMin = this.GraphPane.YAxis.Scale.Min;
            lastXAxisMax = this.GraphPane.XAxis.Scale.Max;
            lastXAxisMin = this.GraphPane.XAxis.Scale.Min;*/

            this.GraphPane.XAxis.Scale.MinAuto = false;
            this.GraphPane.XAxis.Scale.MaxAuto = false;
            this.GraphPane.YAxis.Scale.MinAuto = false;
            this.GraphPane.YAxis.Scale.MaxAuto = false;
            this.AxisChange();


            this.GraphPane.YAxis.MajorGrid.IsZeroLine = false;
            this.GraphPane.XAxis.Scale.FormatAuto = false;
            this.GraphPane.AxisChange();
            this.IsShowHScrollBar = true;
            this.IsShowVScrollBar = true;

            // Собития:
            this.ZoomEvent += MyZedGraph_ZoomEvent; ;
            this.MouseLeave += MyZedGraph_MouseLeave;
            this.MouseMoveEvent += MyZedGraph_MouseMoveEvent;
            this.VisibleChanged += MyZedGraph_VisibleChanged;

            // отключаем закоголовки
            this.GraphPane.XAxis.Title.IsVisible = false;
            this.GraphPane.YAxis.Title.IsVisible = false;
            this.GraphPane.Title.IsVisible = false;

            // Для показа данных под мышкой
            this.ZdLabel = ZdLabel;
            this.ZdLabel.Width = 77;
            this.ZdLabel.Height = 35;
            ZdLabel.Visible = false;


            // Настроиваевам стиль подписаей осей
            this.GraphPane.YAxis.Scale.FontSpec.Size = 8f;
            this.GraphPane.XAxis.Scale.FontSpec.Size = 8f;



            /*this.IsShowPointValues = true;
            this.IsShowCursorValues = true;*/


            // Отключаем включаем масштабирование
            /*this.IsEnableVZoom = false;
            this.IsEnableHZoom = false;
            this.IsEnableHPan = false;
            this.IsEnableVPan = false;*/





            //this.GraphPane.XAxis.Cross = 19.0;
            //this.GraphPane.YAxis.Cross = 0.0;

        }

        // Событие ищзменениея видимости граифка
        private void MyZedGraph_VisibleChanged(object sender, System.EventArgs e)
        {
            //setZoom();
            //throw new System.NotImplementedException();
        }

        // Событие покидания мыши области графика 
        private void MyZedGraph_MouseLeave(object sender, System.EventArgs e)
        {
            ZdLabel.Visible = false;
            ++tmpCounter;
            // setZoom();
            // throw new System.NotImplementedException();
        }

        // Событие зума
        private void MyZedGraph_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
        {
            // X
            this.GraphPane.XAxis.Scale.Min = this.GraphPane.XAxis.Scale.Min < xAxisMin ? xAxisMin : this.GraphPane.XAxis.Scale.Min;
            this.GraphPane.XAxis.Scale.Max = this.GraphPane.XAxis.Scale.Max > xAxisMax ? xAxisMax : this.GraphPane.XAxis.Scale.Max;
            // Y
            this.GraphPane.YAxis.Scale.Min = this.GraphPane.YAxis.Scale.Min < yAxisMin ? yAxisMin : this.GraphPane.YAxis.Scale.Min;
            this.GraphPane.YAxis.Scale.Max = this.GraphPane.YAxis.Scale.Max > yAxisMax ? yAxisMax : this.GraphPane.YAxis.Scale.Max;

            setZoom(100, 1);
        }

        // Событие движения мыши
        private bool MyZedGraph_MouseMoveEvent(ZedGraphControl sender, System.Windows.Forms.MouseEventArgs e)
        {


            this.GraphPane.ReverseTransform(e.Location, out xPos, out yPos);

            if (e.Button == MouseButtons.Middle || (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control))
            {
                // Ограничиваем перемещения по графику, согласно максимальным значениям на графике
                // X
                this.GraphPane.XAxis.Scale.Min = this.GraphPane.XAxis.Scale.Min < xAxisMin ? xAxisMin : this.GraphPane.XAxis.Scale.Min;
                this.GraphPane.XAxis.Scale.Max = this.GraphPane.XAxis.Scale.Max > xAxisMax ? xAxisMax : this.GraphPane.XAxis.Scale.Max;

                // Y
                this.GraphPane.YAxis.Scale.Min = this.GraphPane.YAxis.Scale.Min < yAxisMin ? yAxisMin : this.GraphPane.YAxis.Scale.Min;
                this.GraphPane.YAxis.Scale.Max = this.GraphPane.YAxis.Scale.Max > yAxisMax ? yAxisMax : this.GraphPane.YAxis.Scale.Max;
            }

            this.ZdLabel.Visible = true;
            ZdLabel.Location = new System.Drawing.Point(e.Location.X + 20, e.Location.Y - 25);
            //ZdLabel.Wra

            ZdLabel.Text = $"xPos: {Math.Round(xPos, 2)}\nyPos: {Math.Round(yPos, 2)}";
            addLineCross(yPos);
            return false;

        }

        private void addLineCross(double level)
        {
            lineCross = new LineObj(this.GraphPane.XAxis.Scale.Min, level, this.GraphPane.XAxis.Scale.Max, level);
            //lineCross.Line.Width = 2f;
            //lineCross.;
            lineCross.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            this.GraphPane.GraphObjList.Add(lineCross);
            if (this.GraphPane.GraphObjList.Count > 1)
                this.GraphPane.GraphObjList.RemoveAt(0);
            this.Invalidate();


        }
        private void setZoom(double X, double Y)
        {
            ZdGraphReport.WriteLine($"XAxis.Scale.Min:\t{this.GraphPane.XAxis.Scale.Min}");
            ZdGraphReport.WriteLine($"XAxis.Scale.Max:\t{this.GraphPane.XAxis.Scale.Max}");
            ZdGraphReport.WriteLine($"YAxis.Scale.Min:\t{this.GraphPane.YAxis.Scale.Min}");
            ZdGraphReport.WriteLine($"YAxis.Scale.Max:\t{this.GraphPane.YAxis.Scale.Max}");
            ZdGraphReport.WriteLine("———————————————————————————————————————————————————————");

            ZdGraphReport.Flush();

            /*this.GraphPane.XAxis.Scale.Min += X;
            this.GraphPane.XAxis.Scale.Max -= X;
            this.GraphPane.YAxis.Scale.Min += Y;
            this.GraphPane.YAxis.Scale.Max -= Y;*/
            this.GraphPane.AxisChange();
        }

        private void setZoom()
        {
            this.GraphPane.XAxis.Scale.Min = 0;
            this.GraphPane.XAxis.Scale.Max = 6005;
            this.GraphPane.YAxis.Scale.Min = 0;
            this.GraphPane.YAxis.Scale.Max = 75;
            this.GraphPane.AxisChange();
        }
        private void InitializeComponent()
        {

        }
    }
}
