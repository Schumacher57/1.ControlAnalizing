/*Рабочий пример для правой стороны*/

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

/* Вариант с пояснениями */

double tmpVal = xAxis.PixelPositionToValue(e.Location.X);
double tmpXmin = xMin + Math.Abs(xStep); // Вот тут главная засада <-------------  !!!!!!!!!!!

report.WriteLine($"{iCounter}—————————————————————————————————————————— Правая\n");
report.WriteLine("ДО Шага:");
report.WriteLine($"xMin\t{xMin}");
report.WriteLine($"SetMousePosToval({e.Location.X})\t{Math.Round(xAxis.PixelPositionToValue(e.Location.X), 2)}");
report.WriteLine($"tmpVal:\t{tmpVal}");

// Начинем какие-либо вычисления
Debug.WriteLine(percentStep);
xAxis.ScaleView.Zoom(xMin + xStep, xMax);
//xAxis.ScaleView.Zoom(xMin + 10, xMax);
//(sender as Chart).Refresh();

xMax = xAxis.ScaleView.ViewMaximum;
report.WriteLine($"\nxMin(до движения):\t{xMin}");
report.WriteLine($"tmpXmin до движения:\t{tmpXmin}");
report.WriteLine($"tmpVal до движения:\t{Math.Round(tmpVal, 2)}");

xAxis.ScaleView.Position = tmpXmin - (Math.Abs(tmpVal - xAxis.PixelPositionToValue(e.Location.X)));





report.WriteLine("\nПОСЛЕ ШАГА:");
report.WriteLine($"\nxMin(после движения):\t{xMin}");
report.WriteLine($"tmpXmin после движения:\t{tmpXmin}");
report.WriteLine($"tmpVal после движения:\t{tmpVal}");
report.WriteLine($"curVal({e.Location.X})\t{xAxis.PixelPositionToValue(e.Location.X)}");
report.WriteLine($"tmpVal-Curval:\t{tmpVal - xAxis.PixelPositionToValue(e.Location.X)}");
report.WriteLine($"xMin - (tmpVal - CurVal)\t{xMin - (Math.Abs(tmpVal - xAxis.PixelPositionToValue(e.Location.X)))}");