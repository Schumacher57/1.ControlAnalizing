using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;
using System.Text;

namespace ForTests.myLib
{
    internal struct DataEMF
    {
        //DAta
    }

    /*class Measure
    {
        *//*public static Measure Add()
        {
            return new Measure();
            //return new Measure[]();
        }*//*
        public static Array Add()
        {
            return null;
        }
    }


    class EMfield
    {
        public Measure[] Measures = { };

        public Measure this[int index]
        {
            get { return Measures[index]; }
            set { Measures[index] = value; }
        }
        public static Array Add(this Array myArray)
        {
            return null;
        }
    }*/






    class someClass<T> : List<T>
    {
        //private int iCount = 0;
        private List<double> pDTFreq;

        public List<double> DTFreq
        {
            get => pDTFreq;
            set { pDTFreq = value; Debug.WriteLine("Забежало"); }
        }

        public List<double> DTSig { get; set; } = new List<double>();
        public List<double> DTNoise { get; set; } = new List<double>();
        public List<List<double>> DataID { get; set; } = new List<List<double>>();


        /*public List<double> this[int index]
        {
            get => getDataByID(index);
            set
            {
                //DataID.Add(value);
                //DataID.Add(value); 
            }
        }*/




        public someClass()
        {
            //int i = 0;
            DataID.Add(new List<double>());
            List<double> someFreq = new List<double>();
            List<double> someSig = new List<double>();
            List<double> someNoise = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                someFreq.Add(i + 100);
                someSig.Add(i + 10);
                someNoise.Add(i);
            }
            DTFreq = someFreq;
            DTFreq.Add(321.1);
            DTSig = someSig;
            DTNoise = someNoise;
        }

        private List<double> getDataByID(int i)
        {
            var tmpList = new List<double>();
            tmpList.Add(DTFreq[i]);
            tmpList.Add(DTSig[i]);
            tmpList.Add(DTNoise[i]);
            return tmpList;
        }





        /*public void AddData(double freq)
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
        }*/

    }

    //Data.Add(tmpData);

}

namespace ForTests.mySome2
{


    class EMfield
    {
        #region
        internal class MesureList  // : List<MyClass2>
        {
            List<Measure> DBMeasure;

            public Measure AddNew(Measure someClass2)
            {
                return (new Measure());
            }

            public Measure AddNew()
            {
                DBMeasure.Add(new Measure());
                return DBMeasure[DBMeasure.Count - 1];
            }

            public Measure AddNew(string someText)
            {
                DBMeasure.Add(new Measure(someText));
                return DBMeasure[DBMeasure.Count - 1];
            }

            // Индексатор
            public Measure this[int index]
            {
                get => DBMeasure[index]; // Получаем элмент из списка
                set
                {
                    // Проверяем существует ли элемент
                    if (DBMeasure[index] != null)
                    {
                        DBMeasure[index] = value;
                    }
                    else
                    {
                        DBMeasure.Add(value);
                    }
                }
            }

            // Конструктор вложенного класса
            public MesureList()
            {
                // Инициализируем внутренний список с классами Measure.
                DBMeasure = new List<Measure>();
            }

        }
        #endregion


        public MesureList Measure { get; } = new();

    }



    public class Measure
    {
        public string someText { get; set; } = "nothing";

        public void DispSome()
        {
            Console.WriteLine(this.someText);
        }

        public void SomeDo()
        {

        }
        public Measure()
        {

        }

        public Measure(string someText)
        {
            this.someText = someText;
        }

    }


}
