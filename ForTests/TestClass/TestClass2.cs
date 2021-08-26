using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTestsConsole.TestClass2
{

    // Главный класс
    class MainClass
    {
        private string pName;
        public string Name { get => pName; set => pName = value; }

        public TestClassA ClassA;

        public MainClass()
        {
            pName = "NameDefault";

            ClassA = new TestClassA(this);
        }

    }

    // 1 вспомогательный класс
    class TestClassA
    {
        private MainClass mainClass;
        public string Name { get => mainClass.Name; set => mainClass.Name = value; }

        public TestClassA(MainClass mainClass)
        {
            this.mainClass = mainClass;

        }


    }

    // 2 вспомогательный класс
    class TestClassB
    {
        public MainClass mainClassB;

    }


}
