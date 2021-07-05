using System;
using System.Diagnostics;
using System.Collections.Generic;
using ForTests.myLib;

namespace ForTests
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> myTestList = new List<double>();

            myLib.someClass mySomeData = new someClass();
            mySomeData.DTFreq.Add(1.23);

            mySomeData.AddData(3.24, 12);


            myTestList.Add(3.24);
            Debug.Print(myTestList[0].ToString());
            myTestList[0] = 5.14;
            Debug.Print(myTestList[0].ToString());
            Debug.Print(myTestList.Count.ToString());
            //mySomeData.s


            Debug.Print(mySomeData.DTFreq[0].ToString());

            Debug.Print(mySomeData.GetData(0).ToString());

            //mySomeData

            //mySomeData.addData(121, 39, 32);
            //Debug.WriteLine(mySomeData.Data);

        }


        void oldTry ()
        {
            string a = "123";
            TraceListener myListen = new ConsoleTraceListener();
            Trace.Listeners.Add(myListen);

            someClass myNewSomeClass = new someClass();
            //myNewSomeClass.someString = "123";

            Console.ReadKey();
        }
    }
}
