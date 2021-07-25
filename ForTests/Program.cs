using System;
using System.Diagnostics;
using System.Data;

using ForTests.EM;
//using ForTests.myLib;
//using ForTests.mySome2;
//using ForTests.MyDataSet;


namespace ForTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myPrg = new Program();

            /* Тут вызывать методы для теста*/
            myPrg.SomeDo5();


            /*Ниже уже писать свои методы для теста*/


            Console.ReadKey();
        }

        
        void SomeDo5 ()
        {
            EMfield EMf1 = new EMfield();
            EMf1.Measure.GetMeasureFromFile(@"d:\Books\Document\Google disk\Work\Programming\C#\Текущие проекты\1. ControlAnalizing\DataResource\Measure\+ data_30-6000_El.txt");
            //EMf1.Measure.GetMeasureFromFile()

        }
        
        
        
        void SomeDo4()
        {
            /*EMfield EMf1 = new EMfield();
            Measure Mesure1 = new Measure();
            EMf1.Measure[3] = Mesure1;*/

            /*Mesure1 = EMf1.Measure.AddNew("Привет");
            EMf1.Measure[0].SomeDo();
            Mesure1.SomeDo();
            EMf1.Measure[0].someText = "Привет2";
            Console.WriteLine("После изменений:");
            EMf1.Measure[0].SomeDo();
            Mesure1.SomeDo();
            Console.WriteLine("Добавили №2");
            EMf1.Measure.AddNew();
            EMf1.Measure[1].DispSome();*/
            //EMf1.Measure = 





            /*EMf1.Measure.AddNew(Mesure1);
            EMf1.Measure.AddNew();
            EMf1.Measure[0].SomeDo();
            EMf1.Measure[1].SomeDo();*/


        }

        void SomeDo3()
        {
            /*EMFiledEx myEMf = new EMFiledEx();
            MeasureEx myMeasure = new MeasureEx("Столбец измерений");
            DataTable myMeasureSort = new DataTable();
            MeasureEx myMeasureSortEx;// = new DataTable();
            DataView mySomeSort;
            myEMf.Tables.Add(myMeasure);
            myMeasure.Rows.Add(new object[] { null, 142.14, 27.89 });
            myMeasure.Rows.Add(new object[] { null, 256.11, 27.1, 13.2 });
            myMeasure.Rows.Add(new object[] { null, 200.11, 25.1, 17.2 });
            mySomeSort = myMeasure.DefaultView;
            mySomeSort.Sort = "Частота";
            myMeasureSort = mySomeSort.ToTable();
            myMeasureSortEx = new MeasureEx(myMeasureSort);
            myMeasureSortEx.displInfo();*/


        }


        static void someDo2()
        {

            /*EMFiled myEMF = new EMFiled();*/
            //myEMF.Measures.add

            //Debug.WriteLine(myEM.Measures.Length.ToString());


        }

        // new 20.07.2021
        static void SomeDo()
        {
            /*EMField myEMF = new EMField();
            Measure myMeasur1 = new Measure();
            Measure myMeasur2 = new Measure("New name");

            myEMF.Measures.Add(myMeasur1);
            myEMF.AddMeasure(myMeasur2);


            Debug.WriteLine(myEMF.Measures[0].Name);
            Debug.WriteLine(myEMF.Measures[1].Name);*/


        }

        // 20.07.2021
        void oldTry2()
        {
            /*List<double> myTestList = new List<double>();

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

            Debug.Print(mySomeData.GetData(0).ToString());*/

            //mySomeData

            //mySomeData.addData(121, 39, 32);
            //Debug.WriteLine(mySomeData.Data);

        }

        static void oldTry()
        {
            //string a = "123";
            TraceListener myListen = new ConsoleTraceListener();
            Trace.Listeners.Add(myListen);

            //someClass myNewSomeClass = new someClass();
            //myNewSomeClass.someString = "123";

            Console.ReadKey();
        }
    }
}
