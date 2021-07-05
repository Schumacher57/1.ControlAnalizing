using System.Collections.Generic;

namespace WorkWithChart.ChartOperation
{
    class MeasureData
    {
        public List<double> DTFreq = new List<double>();
        public List<double> DTSig { get; set; } = new List<double>();
        public List<double> DTNoise { get; set; } = new List<double>();



        public void AddData(double freq)    // Добавляем только частоту
        {
            DTFreq.Add(freq);
        }
        public void AddData(double freq, double sig)    // Добавляем частоту и сигнал
        {
            DTFreq.Add(freq);
            DTSig.Add(sig);
        }
        public void AddData(double freq, double sig, double noise)  // Добавляем частоту, сигнал и шум
        {
            DTFreq.Add(freq);
            DTSig.Add(sig);
            DTNoise.Add(noise);
        }

    }


}
