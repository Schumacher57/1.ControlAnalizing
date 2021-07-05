using fileOP = WorkWithChart.FileOperation;
using System.Linq;

using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace WorkWithChart.ChartOperation
{
    class ChartControl
    {
        public static void UpdDataFromFile(Chart mainChart)
        {
            MeasureData measure1 = new MeasureData();
            fileOP.someFile myFile = new fileOP.someFile();

            myFile.AddrFile = @"d:\Books\Document\Google disk\Work\Programming\C#\Текущие проекты\1. ControlAnalizing\DataResource\Measure\";
            myFile.FileName = "+ data_30-6000_El.txt";
            measure1 = myFile.ReadFile();
            mainChart.Series[0].Points.DataBindXY(measure1.DTFreq.ToArray(), measure1.DTSig.ToArray());

            //mainChart.Series[0].Points.AddXY(measure1.DTFreq.ToArray(),measure1.DTSig.ToArray());

        }
    }
}
