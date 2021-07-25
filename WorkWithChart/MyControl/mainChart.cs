using System;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Drawing;

//using 

namespace WorkWithChart.MyControl
{
    class mainChart : Chart
    {

        TextWriterTraceListener report = new TextWriterTraceListener(System.IO.File.CreateText(@"d:\Books\Document\Google disk\Work\Programming\C#\Текущие проекты\1. ControlAnalizing\DataResource\Measure\report2.txt"));
        private int iCounter = 1;
        double percentStep = 0.4; // Значение должно быть от 0.01 до 1. Задаёт шаг скролла зума
        private bool mouseOnChart = true;   // Показывает находится ли мышь на графике или нет. (Для зума)
        private long zoomLevel = 0; // Показатель zooma. !Возможно понадобится 4 показателя.!
        
        private bool isRightButtonPressed = false;
        private Point mouseDown = Point.Empty;

        /*private long zoomLevelLeft = 0;
        private long zoomLevelRight = 0;
        private long zoomLevelTop = 0;
        private long zoomLevelBottom = 0;*/


        //Настройка Series
        private Series confSeries()
        {
            Series tmpSeries = new Series();

            tmpSeries.Name = "Series1";
            tmpSeries.LegendText = "Только сигнал";
            //tmpSeries.Legend.Color
            tmpSeries.IsVisibleInLegend = true;
            tmpSeries.ChartType = SeriesChartType.Line;
            tmpSeries.BorderWidth = 1;
            //tmpSeries.BorderDashStyle = ChartDashStyle.Dot;
            //tmpSeries.Color = System.Drawing.Color.FromArgb(112,255,127);

            return tmpSeries;
        }

        //Настройка ChartArea
        private ChartArea confChartArea()
        {
            ChartArea tmpChrtArea = new ChartArea();

            // Настройка расположения на графике основных данных

            tmpChrtArea.Position.Y = 0;
            tmpChrtArea.Position.Height = 100f;
            tmpChrtArea.Position.X = 1;
            tmpChrtArea.Position.Width = 100f;
            tmpChrtArea.InnerPlotPosition.X = 4;
            tmpChrtArea.InnerPlotPosition.Width = 96f;
            tmpChrtArea.InnerPlotPosition.Y = 0;
            tmpChrtArea.InnerPlotPosition.Height = 91.5f;


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
            /*tmpChrtArea.AxisX.Interval = 350;
            tmpChrtArea.AxisY.Interval = 1;*/

            /*tmpChrtArea.AxisX.Interval = 2;
            tmpChrtArea.AxisY.Interval = 2;*/

            /*tmpChrtArea.AxisX.Interval = 2.5;
            tmpChrtArea.AxisY.Interval = 2.5;*/


            // Настройка подписей оси X
            tmpChrtArea.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont;  // Добавляем возможность уменьшения текста
            tmpChrtArea.AxisX.IsLabelAutoFit = false;
            //tmpChrtArea.AxisY.Crossing = 17;
            //tmpChrtArea.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep45; // Поворот подписей
            tmpChrtArea.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            tmpChrtArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold);
            tmpChrtArea.AxisX.LabelStyle.Format = "{0}";

            // Настройка подписей оси Y
            tmpChrtArea.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont;  // Добавляем возможность уменьшения текста
            //tmpChrtArea.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.None;
            tmpChrtArea.AxisX.IsLabelAutoFit = false;
            tmpChrtArea.AxisX.Crossing = 8;
            tmpChrtArea.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DarkRed;
            tmpChrtArea.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont;
            tmpChrtArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold);//, System.Drawing.FontStyle.Bold);
            tmpChrtArea.AxisY.LabelStyle.Format = "{0 дБ}";


            //Велючаем зумирование
            tmpChrtArea.AxisX.ScaleView.Zoomable = true;
            tmpChrtArea.AxisY.ScaleView.Zoomable = true;
            //tmpChrtArea.CursorX.AutoScroll = true;
            //tmpChrtArea.CursorY.AutoScroll = true;
            //tmpChrtArea.CursorX.IsUserSelectionEnabled = true;
            //tmpChrtArea.CursorY.IsUserSelectionEnabled = true;
            //tmpChrtArea.CursorX.


            return tmpChrtArea;
        }

        // Настройка основного Графика
        public mainChart()
        {
            this.Name = "mainChart";
            this.Dock = System.Windows.Forms.DockStyle.Fill;

            //this.ChartAreas[0].


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
            this.MouseMove += MainChart_MouseMove;
            this.MouseUp += MainChart_MouseUp;
            this.MouseDown += MainChart_MouseDown;

            
            this.MouseEnter += (s, a) => { mouseOnChart = true; };
            this.MouseLeave += (s, a) => { mouseOnChart = false; };
            this.Series.Add(confSeries());  // Добавляем данные для графиа
        }

        private void MainChart_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                isRightButtonPressed = true;
                mouseDown = e.Location;
            }
        }

        private void MainChart_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                isRightButtonPressed = false;
                mouseDown = Point.Empty;
            }
        }

        // Отработка движения перемещения мыши по графику
        private void MainChart_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (isRightButtonPressed)
            {
                var result = (sender as Chart).HitTest(e.X, e.Y);

                if (result.ChartElementType == ChartElementType.PlottingArea)
                {
                    var oldXValue = result.ChartArea.AxisX.PixelPositionToValue(mouseDown.X);
                    var newXValue = result.ChartArea.AxisX.PixelPositionToValue(e.X);

                    var oldYValue = result.ChartArea.AxisY.PixelPositionToValue(mouseDown.Y);
                    var newYValue = result.ChartArea.AxisY.PixelPositionToValue(e.Y);

                    (sender as Chart).ChartAreas[0].AxisX.ScaleView.Position += oldXValue - newXValue;
                    (sender as Chart).ChartAreas[0].AxisY.ScaleView.Position += oldYValue - newYValue;

                    mouseDown.X = e.X;
                    mouseDown.Y = e.Y;
                }
            }
        }

        // Метод обработки события Zoom (MouseWheel)
        private void MainChart_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Получаем оси графика
            Axis xAxis = (sender as Chart).ChartAreas[0].AxisX;
            Axis yAxis = (sender as Chart).ChartAreas[0].AxisY;

            try
            {
                if (mouseOnChart == true) // Проверяем находится ли мышь на форме Chart (
                {
                    // Вводоим необходиммые начальные данные
                    // Данные для оси X
                    double xMousePos = xAxis.PixelPositionToValue(e.Location.X);
                    double xMax = xAxis.ScaleView.ViewMaximum;
                    double xMin = xAxis.ScaleView.ViewMinimum;
                    double xStep = ((xMax - xMin) * percentStep) / 2;
                    // Данные для оси Y
                    double yMousePos = yAxis.PixelPositionToValue(e.Location.Y);
                    double yMax = yAxis.ScaleView.ViewMaximum;
                    double yMin = yAxis.ScaleView.ViewMinimum;
                    double yStep = ((yMax - yMin) * percentStep) / 2;

                    ///*——————Увеличение——————*/
                    if (e.Delta > 0)
                    {
                        // Увеличение по оси X (абсцисса)

                        // Если мышь в правой половине стороны графика
                        if (xMousePos - ((xMax - xMin) / 2) > xMin)
                        {

                            double tmpVal = xAxis.PixelPositionToValue(e.Location.X);
                            double tmpXmin = xMin + Math.Abs(xStep); // Вот тут главная засада <-------------  !!!!!!!!!!!

                            xAxis.ScaleView.Zoom(xMin + xStep, xMax);
                            xMax = xAxis.ScaleView.ViewMaximum;
                            xAxis.ScaleView.Position = tmpXmin - (Math.Abs(tmpVal - xAxis.PixelPositionToValue(e.Location.X)));


                        }
                        // Если мышь в левой половине стороны графика
                        if (xMousePos + ((xMax - xMin) / 2) < xMax)
                        {
                            report.WriteLine($"{iCounter}——————————————————————————————————————————\n");
                            report.WriteLine("ДО:");
                            report.WriteLine($"{Math.Round((double)e.Location.X, 2)}px в Vals:\t{Math.Round(xAxis.PixelPositionToValue(e.Location.X), 2)}");
                            report.WriteLine($"xMin:\t{Math.Round(xMin, 2)}");

                            double tmpValFromPos = xAxis.PixelPositionToValue(e.Location.X);

                            xAxis.ScaleView.Zoom(xMin, xMax - xStep);
                            //(sender as Chart).Refresh();
                            xAxis.ScaleView.Position = xMin + Math.Abs(xAxis.PixelPositionToValue(e.Location.X) - tmpValFromPos);

                            report.WriteLine("\nПОСЛЕ:");
                            report.WriteLine($"{Math.Round((double)e.Location.X, 2)}px в Vals:\t{Math.Round(xAxis.PixelPositionToValue(e.Location.X), 2)}");
                            report.WriteLine($"xMin:\t{Math.Round(xMin, 2)}");

                        }

                        // Увеличение по оси Y (ордината)

                        // Если мышь в верхней половине графика
                        if (yMousePos - ((yMax - yMin) / 2) > yMin)
                        {
                            double tmpVal = yAxis.PixelPositionToValue(e.Location.Y);
                            double tmpYmin = yMin + Math.Abs(yStep); // Вот тут главная засада <-------------  

                            // Начинем какие-либо вычисления
                            yAxis.ScaleView.Zoom(yMin + yStep, yMax);
                            yMax = yAxis.ScaleView.ViewMaximum;
                            yAxis.ScaleView.Position = tmpYmin - (Math.Abs(tmpVal - yAxis.PixelPositionToValue(e.Location.Y)));

                        }
                        // Если мышь в нижней половине графика
                        if (yMousePos + ((yMax - yMin) / 2) < yMax)
                        {
                            double tmpValFromPos = yAxis.PixelPositionToValue(e.Location.Y);

                            yAxis.ScaleView.Zoom(yMin, yMax - yStep);
                            //(sender as Chart).Refresh();
                            yAxis.ScaleView.Position = yMin + Math.Abs(yAxis.PixelPositionToValue(e.Location.Y) - tmpValFromPos);

                        }
                        ++zoomLevel;
                    }

                    ///*——————Отдаление——————*/
                    else if ((e.Delta < 0) && (zoomLevel >= 0))
                    {

                        // Если мышь в правой половине стороны графика
                        if (xMousePos - ((xMax - xMin) / 2) > xMin)
                        {
                            double tmpVal = xAxis.PixelPositionToValue(e.Location.X);
                            double tmpXmin = xMin - Math.Abs(xStep); // Вот тут главная засада <-------------  

                            // Начинем какие-либо вычисления
                            xAxis.ScaleView.Zoom(xMin - xStep, xMax);
                            xMax = xAxis.ScaleView.ViewMaximum;
                            xAxis.ScaleView.Position = tmpXmin + (Math.Abs(tmpVal - xAxis.PixelPositionToValue(e.Location.X)));

                        }

                        // Если мышь в левой половине стороны графика !Не проверено!
                        if (xMousePos + ((xMax - xMin) / 2) < xMax)
                        {
                            double tmpValFromPos = xAxis.PixelPositionToValue(e.Location.X);

                            xAxis.ScaleView.Zoom(xMin, xMax + xStep);
                            //(sender as Chart).Refresh();
                            xAxis.ScaleView.Position = xMin - Math.Abs(xAxis.PixelPositionToValue(e.Location.X) - tmpValFromPos);
                        }

                        // Если мышь в верхней половине графика
                        if (yMousePos - ((yMax - yMin) / 2) > yMin)
                        {
                            double tmpVal = yAxis.PixelPositionToValue(e.Location.Y);
                            double tmpYmin = yMin - Math.Abs(yStep); // Вот тут главная засада <-------------  

                            // Начинем какие-либо вычисления
                            yAxis.ScaleView.Zoom(yMin - yStep, yMax);
                            yMax = yAxis.ScaleView.ViewMaximum;
                            yAxis.ScaleView.Position = tmpYmin + (Math.Abs(tmpVal - yAxis.PixelPositionToValue(e.Location.Y)));
                        }

                        // Если мышь в нижней половине графика !Не проверено!
                        if (yMousePos + ((yMax - yMin) / 2) < yMax)
                        {
                            double tmpValFromPos = yAxis.PixelPositionToValue(e.Location.Y);

                            yAxis.ScaleView.Zoom(yMin, yMax + yStep);
                            //(sender as Chart).Refresh();
                            yAxis.ScaleView.Position = yMin - Math.Abs(yAxis.PixelPositionToValue(e.Location.Y) - tmpValFromPos);

                        }

                        --zoomLevel;

                    }

                    // Сброс зума
                    if (zoomLevel < 0)
                    {
                        xAxis.ScaleView.ZoomReset();
                        yAxis.ScaleView.ZoomReset();
                        zoomLevel = -1;
                    }    // Сброс зума (по показателю вложенности зума).


                    // Данные для файла отчёта
                    report.WriteLine("");
                    ++iCounter;
                    report.Flush();

                } // Конец провери нахождения мыши на Chart
            }
            catch
            {
                xAxis.ScaleView.ZoomReset(); // Если вдург была какая либо ошибка при зуумировании, то мы сбрасываем зум
                return;
            }


        }
    }
}
