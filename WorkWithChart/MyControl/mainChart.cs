using System;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

//using 

namespace WorkWithChart.MyControl
{
    class mainChart : Chart
    {
        private long numberOfZoom = 0;
        private const float CZoomScale = 4f;
        private int FZoomLevel = 0;


        //Настройка Series
        private Series confSeries()
        {
            Series tmpSeries = new Series();

            tmpSeries.Name = "Series1";
            tmpSeries.LegendText = "Только сигнал";
            //tmpSeries.Legend.Color
            tmpSeries.IsVisibleInLegend = true;
            tmpSeries.ChartType = SeriesChartType.Line;
            tmpSeries.BorderWidth = 3;
            //tmpSeries.BorderDashStyle = ChartDashStyle.Dot;
            //tmpSeries.Color = System.Drawing.Color.FromArgb(112,255,127);

            return tmpSeries;
        }

        //Настройка ChartArea
        private ChartArea confChartArea()
        {
            ChartArea tmpChrtArea = new ChartArea();

            // Настройка расположения на графике основных данных
            tmpChrtArea.Position.Y = 1;
            tmpChrtArea.Position.Height = 99;
            tmpChrtArea.Position.X = 0;
            tmpChrtArea.Position.Width = 99.5f;

            // Настраиваем вспомогательные линии
            tmpChrtArea.AxisX.MajorGrid.Enabled = true;
            tmpChrtArea.AxisX.MinorGrid.Enabled = false;
            tmpChrtArea.AxisY.MajorGrid.Enabled = true;
            tmpChrtArea.AxisY.MinorGrid.Enabled = false;

            tmpChrtArea.AxisX.ScrollBar.BackColor = System.Drawing.Color.White;
            tmpChrtArea.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.LightGray;
            tmpChrtArea.AxisY.ScrollBar.BackColor = System.Drawing.Color.White;
            tmpChrtArea.AxisY.ScrollBar.ButtonColor = System.Drawing.Color.LightGray;

            // Настройка отрисовки основных линий
            tmpChrtArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(80, 255, 255, 255);
            tmpChrtArea.AxisX.MajorGrid.LineWidth = 2;
            //tmpChrtArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            tmpChrtArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(80, 255, 255, 255);
            tmpChrtArea.AxisY.MajorGrid.LineWidth = 2;
            //tmpChrtArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            // Настройка отрисовки вспомогательных линий
            tmpChrtArea.AxisX.MinorGrid.LineColor = System.Drawing.Color.FromArgb(37, 255, 255, 255);
            tmpChrtArea.AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
            tmpChrtArea.AxisY.MinorGrid.LineColor = System.Drawing.Color.FromArgb(37, 255, 255, 255);
            tmpChrtArea.AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;

            // Настройка шага интервала
            tmpChrtArea.AxisX.Interval = 350;
            tmpChrtArea.AxisY.Interval = 1;

            // Настройка подписей оси X
            tmpChrtArea.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont;  // Добавляем возможность уменьшения текста
            //tmpChrtArea.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep45; // Поворот подписей
            tmpChrtArea.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            tmpChrtArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold);
            tmpChrtArea.AxisX.LabelStyle.Format = "{0.000}";

            // Настройка подписей оси Y
            tmpChrtArea.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont;  // Добавляем возможность уменьшения текста
            tmpChrtArea.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DarkRed;
            tmpChrtArea.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont;
            tmpChrtArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 54f);//, System.Drawing.FontStyle.Bold);
            tmpChrtArea.AxisY.LabelStyle.Format = "{0.00 дБ}";


            //Велючаем зумирование
            tmpChrtArea.AxisX.ScaleView.Zoomable = true;
            tmpChrtArea.AxisY.ScaleView.Zoomable = true;

            return tmpChrtArea;
        }

        public mainChart()
        {
            this.Name = "mainChart";
            this.Dock = System.Windows.Forms.DockStyle.Fill;



            //Настройка Label графика (подписи графиков)
            // Настройка закловка
            this.Legends.Add(new Legend());
            this.Legends[0].Docking = Docking.Right;    // Закрепление графика
            this.Legends[0].BackColor = System.Drawing.Color.FromArgb(99, 255, 255, 255);
            this.Legends[0].Title = "Список данных: ";
            this.Legends[0].TitleForeColor = System.Drawing.Color.DarkRed;
            this.Legends[0].TitleFont = new System.Drawing.Font("Arial", 9f, (System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Bold));
            // Настройка подписей
            this.Legends[0].ForeColor = System.Drawing.Color.DarkGreen;
            this.Legends[0].Font = new System.Drawing.Font("Arial", 8f);

            // Добавление свойств для отрисовки графика
            this.ChartAreas.Add(confChartArea());   // Добавляем область графика
            this.BackColor = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            // Дополнительная настройка ChartArea
            this.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //this.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            this.MouseWheel += MainChart_MouseWheel;    // Добавляем возможность скролла графика

            this.Series.Add(confSeries());  // Добавляем данные для графиа
        }

        //Добавляем zoom
        private void MainChart_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {


            Axis xAxis = (sender as Chart).ChartAreas[0].AxisX;
            Axis yAxis = (sender as Chart).ChartAreas[0].AxisY;
            double xMin = xAxis.ScaleView.ViewMinimum;
            double xMax = xAxis.ScaleView.ViewMaximum;
            double xPixelPos = xAxis.PixelPositionToValue(e.Location.X);

            try
            {
                if (e.Delta < 0 && FZoomLevel > 0)
                {
                    // Scrolled down, meaning zoom out
                    if (--FZoomLevel <= 0)
                    {
                        FZoomLevel = 0;
                        xAxis.ScaleView.ZoomReset();
                    }
                    else
                    {
                        double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) * CZoomScale, 0);
                        double xEndPos = Math.Min(xStartPos + (xMax - xMin) * CZoomScale, xAxis.Maximum);
                        xAxis.ScaleView.Zoom(xStartPos, xEndPos);
                    }
                }
                else if (e.Delta > 0)
                {
                    // Scrolled up, meaning zoom in
                    double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) / CZoomScale, 0);
                    double xEndPos = Math.Min(xStartPos + (xMax - xMin) / CZoomScale, xAxis.Maximum);
                    xAxis.ScaleView.Zoom(xStartPos, xEndPos);
                    FZoomLevel++;
                }
            }
            catch { }

            // Настройка интервала графика
            if (e.Delta > 0)
            {
                xAxis.Interval = xAxis.Interval / 4;
                yAxis.Interval = yAxis.Interval / 1.1;
            }
            else
            {
                xAxis.Interval = xAxis.Interval * 4;
                yAxis.Interval = yAxis.Interval * 1.1;
            }
            Debug.WriteLine("Прокрутил на " + e.Delta);















            // _____________________________________________________________________
            //var chart = (Chart)sender;
            //var xAxis = chart.ChartAreas[0].AxisX;
            //var yAxis = chart.ChartAreas[0].AxisY;

            //var xMin = xAxis.ScaleView.ViewMinimum;
            //var xMax = xAxis.ScaleView.ViewMaximum;
            //var yMin = yAxis.ScaleView.ViewMinimum;
            //var yMax = yAxis.ScaleView.ViewMaximum;

            //int IntervalX = 3;
            //int IntervalY = 3;
            //try
            //{
            //    if (e.Delta < 0 && numberOfZoom > 0) // Scrolled down.
            //    {
            //        var posXStart = xAxis.PixelPositionToValue(e.Location.X) - IntervalX * 2 / Math.Pow(2, numberOfZoom);
            //        var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + IntervalX * 2 / Math.Pow(2, numberOfZoom);
            //        var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - IntervalY * 2 / Math.Pow(2, numberOfZoom);
            //        var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + IntervalY * 2 / Math.Pow(2, numberOfZoom);

            //        if (posXStart < 0) posXStart = 0;
            //        if (posYStart < 0) posYStart = 0;
            //        if (posYFinish > yAxis.Maximum) posYFinish = yAxis.Maximum;
            //        if (posXFinish > xAxis.Maximum) posYFinish = xAxis.Maximum;
            //        xAxis.ScaleView.Zoom(posXStart, posXFinish);
            //        yAxis.ScaleView.Zoom(posYStart, posYFinish);
            //        numberOfZoom--;
            //    }
            //    else if (e.Delta < 0 && numberOfZoom == 0) //Last scrolled dowm
            //    {
            //        yAxis.ScaleView.ZoomReset();
            //        xAxis.ScaleView.ZoomReset();
            //    }
            //    else if (e.Delta > 0) // Scrolled up.
            //    {

            //        var posXStart = xAxis.PixelPositionToValue(e.Location.X) - IntervalX / Math.Pow(2, numberOfZoom);
            //        var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + IntervalX / Math.Pow(2, numberOfZoom);
            //        var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - IntervalY / Math.Pow(2, numberOfZoom);
            //        var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + IntervalY / Math.Pow(2, numberOfZoom);

            //        xAxis.ScaleView.Zoom(posXStart, posXFinish);
            //        yAxis.ScaleView.Zoom(posYStart, posYFinish);
            //        numberOfZoom++;
            //    }

            //    if (numberOfZoom < 0) numberOfZoom = 0;
            //}
            //catch { }





            // _______________________


            //var chart = (Chart)sender;
            //var xAxis = chart.ChartAreas[0].AxisX;
            //var yAxis = chart.ChartAreas[0].AxisY;

            //try
            //{
            //    if (e.Delta < 0) // Scrolled down.
            //    {
            //        xAxis.ScaleView.ZoomReset();
            //        yAxis.ScaleView.ZoomReset();
            //        xAxis.Interval = 350;
            //        yAxis.Interval = 1;
            //    }
            //    else if (e.Delta > 0) // Scrolled up.
            //    {
            //        var xMin = xAxis.ScaleView.ViewMinimum;
            //        var xMax = xAxis.ScaleView.ViewMaximum;
            //        var yMin = yAxis.ScaleView.ViewMinimum;
            //        var yMax = yAxis.ScaleView.ViewMaximum;

            //        var posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
            //        var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
            //        var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
            //        var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

            //        xAxis.ScaleView.Zoom(posXStart, posXFinish);
            //        yAxis.ScaleView.Zoom(posYStart, posYFinish);
            //        xAxis.Interval = xAxis.Interval / 2;
            //        yAxis.Interval = yAxis.Interval / 2;
            //    }
            //}
            //catch { }
            // throw new System.NotImplementedException();
        }
    }
}
