using System;
using ForTestsConsole.TestClass2;


namespace ForTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myPrg = new Program();

            /* Тут вызывать методы для теста*/
            myPrg.testMethod3();



            // ——— /*Конец выполнения тестовых методов*/ ——— 
            Console.WriteLine("\n\n\n");
            Console.WriteLine(new string('_', 50));
            Console.WriteLine("Выполнение завершено.");
            Console.ReadKey();
        }



        // Тестовый метод. Проверяем возможность связать свойства класса
        void testMethod3()
        {
            MainClass mainTestClass = new MainClass();
            TestClassB ClassB = new TestClassB();
            ClassB.mainClassB = mainTestClass;

            Console.WriteLine($"mainTestClass.ClassA.Name: {mainTestClass.ClassA.Name}");
            mainTestClass.Name = "ReName in MainClass";
            Console.WriteLine($"mainTestClass.ClassA.Name: {mainTestClass.ClassA.Name}");
            mainTestClass.ClassA.Name = "ReName in ClassA";
            Console.WriteLine($"mainTestClass.Name: {mainTestClass.Name}\n");
            Console.WriteLine(new string('—', 50));

            ClassB.mainClassB.Name = "ReName in ClassB";
            Console.WriteLine($"mainTestClass.Name: {mainTestClass.Name}");




        }

        // Тестовый метод. Проверяем возможность связать свойства класса
        void testMethod2()
        {
            //MainClass mainClass = new MainClass();
            //TestClassA classA = new TestClassA(mainClass);


            // /* ——— Test#1 ——— */
            //mainClass.iMain = 10;
            //Console.WriteLine($"classA.i1 {classA.i1.ToString()}");
            //classA.i1 = 20;
            //Console.WriteLine($"mainClass.iMain {mainClass.iMain.ToString()}");


        }

        // Тестовый метод. Проверяем возможность связать свойства класса
        void testMethod1()
        {

            //MainClass mainClass = new MainClass();
            //var classA = new TestClassA();
            //var classB = new TestClassB();

            // /* ——— Test#1 ——— */
            //mainClass.iMain = 4;
            //classA.i1 = mainClass.iMain;
            //mainClass.iMain = 5;

            //Console.WriteLine($"classA.i1:\t{classA.i1.ToString()}");

            // /* ——— Test#2 ——— */

            //classA.i1 = 6;


            //Console.WriteLine($"classA.i1: {classA.i1.ToString()}");
            //Console.WriteLine($"classMain.iMain: {mainClass.iMain}");


        }


    }
}
