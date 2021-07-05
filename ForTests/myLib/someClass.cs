using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;
using System.Text;

namespace ForTests.myLib
{
    class someClass
    {
        public List<double> DTFreq = new List<double>();
        public List<double> DTSig { get; set; } = new List<double>();
        public List<double> DTNoise { get; set; } = new List<double>();



        public void AddData(double freq)
        {
            DTFreq.Add(freq);
        }
        public void AddData(double freq, double sig)
        {
            DTFreq.Add(freq);
            DTSig.Add(sig);
        }
        public void AddData(double freq, double sig, double noise)
        {
            DTFreq.Add(freq);
            DTSig.Add(sig);
            DTSig.Add(noise);
        }

        public double[,] GetData(int index)
        {
            double[] tmpArray = new double[1];
            double[,] tmpArray1 = new double[DTFreq.Count,3];



            if (index < DTFreq.Count)
            {
                Debug.WriteLine(DTFreq[index].ToString());
                tmpArray[0] = DTFreq[index];
                return tmpArray1;
            }
            return null;
        }

    }

    //Data.Add(tmpData);

}

