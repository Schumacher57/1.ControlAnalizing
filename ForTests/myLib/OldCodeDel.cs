using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTestsConsole.TestClass
{
    class OldCodeDel
    {


        // Проверяем возвращение значения из события
        void someDo9()
        {




        }

        void Display(string someMessage)
        {
            Console.WriteLine(someMessage);
        }

        void someDo8()
        {
            int y = 1;
            testClassDel myClas1 = new testClassDel();

            Console.WriteLine($"y До: {y}");
            unsafe
            {
                myClas1.x = &y;
            }
            myClas1.someDo1_1();

            Console.WriteLine($"y После: {y}");

        }

        void someDo7()
        {
            testClassDel myClas1 = new testClassDel();
            myClas1.Display("Первый вывод");
            testClassDel myClas2 = myClas1;
            myClas2.someDo6();

            myClas1.Display("Воторй вывод");

        }



        void SomeDo6()
        {
            int? x = 5;
            int? y = null;
            ref int? refX = ref y;

            Console.WriteLine(x);
        }

        void SomeDo5()
        {
            //EM.EMfield EMf1 = new EM.EMfield();
            //EMf1.Measure.LayOutTable;
            //EMf1.Measure.GetMeasureFromFile(@"d:\Books\Document\Google disk\Work\Programming\C#\Текущие проекты\1. ControlAnalizing\DataResource\Measure\TestData2.txt");
            //EMf1.Measure[0].InfoToConsole();

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
            //TraceListener myListen = new ConsoleTraceListener();
            //Trace.Listeners.Add(myListen);

            //someClass myNewSomeClass = new someClass();
            //myNewSomeClass.someString = "123";

            Console.ReadKey();
        }
    }

    class testEven1
    {
        public delegate void dlgtDo1(string someString);
        public event dlgtDo1 rtnString;


        public void someDoStr(string getSomeStr)
        {
            if (rtnString != null)
            {
                rtnString(getSomeStr);
            }
        }
    }




    internal class testClassDel
    {

        public string xVals = "4";
        unsafe public int* x;
        public int x1;

        public testClassDel()
        {

        }
        public testClassDel(int y)
        {
            unsafe
            {
                x = &y;
            }

        }
        public void Display2(string someText)
        {
            unsafe
            {
                Console.WriteLine($"{someText}: {*x}");
            }

        }

        public void someDo1_1()
        {
            unsafe
            {
                *x = 20;
            }
            unsafe
            {
                Console.WriteLine($"Адерсс y: {(uint)x}");

            }
        }
        public void Display(string someTxt)
        {

            Console.WriteLine($"{someTxt}: {xVals}");
        }

        public void someDo6()
        {
            xVals = "6";
        }
    }
}

