﻿using fileOP = WorkWithChart.FileOperation;
using System.Linq;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace WorkWithChart.ChartOperation
{
    class ChartControl
    {
        public static void UpdDataFromFile(Chart mainChart)
        {
            MeasureData measure1 = new MeasureData();
            fileOP.FileType myFile = new fileOP.FileType();
            mainChart.Series[0].Points.Clear();
            myFile.FileAddress = @"d:\Books\Document\Google disk\Work\Programming\C#\Текущие проекты\1. ControlAnalizing\DataResource\Measure\";
            myFile.FileName = "+ data_30-6000_El_!SMA!.txt";
            ////myFile.FileName = "+ data_30-6000_El.txt";
            //myFile.FileName = "TestData.txt";

            //measure1 = myFile.ReadFile();
            mainChart.Series[0].Points.DataBindXY(measure1.DTFreq.ToArray(), measure1.DTSig.ToArray());
            //mainChart.Series[0].BorderWidth = 1;
            //mainChart.ChartAreas[0].AxisX.Minimum = measure1.DTFreq[0];




            /*mainChart.ChartAreas[0].AxisX.Minimum = measure1.DTFreq[0] - 2;
            mainChart.ChartAreas[0].AxisX.Maximum = measure1.DTFreq.Max() + 2;
            mainChart.ChartAreas[0].AxisY.Minimum = measure1.DTSig.Min() - 2;*/

            /*mainChart.ChartAreas[0].AxisX.Minimum = measure1.DTFreq[0] - 60;
            mainChart.ChartAreas[0].AxisX.Maximum = measure1.DTFreq.Max() + 60;
            mainChart.ChartAreas[0].AxisY.Minimum = measure1.DTSig.Min() - 5;*/

            // Debug.WriteLine(measure1.DTSig.Min().ToString());

            //mainChart.Series[0].Points.AddXY(measure1.DTFreq.ToArray(),measure1.DTSig.ToArray());

        }
    }
}
