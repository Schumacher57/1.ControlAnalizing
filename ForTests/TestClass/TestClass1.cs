using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTestsConsole.TestClass1
{

    class MainClass
    {
        public delegate void changeiMain(int iMain);
        static public event changeiMain ChangeiMain;


        private int piMain;
        public int iMain
        {
            get => piMain;

            set
            {
                piMain = value;
                ChangeiMain(value);
            }
        }

        public MainClass()
        {
            TestClassA.Changei += (i) => { piMain = i; };
        }

    }
    class TestClassA
    {

        public delegate void changei(int iMain);
        static public event changei Changei;

        private int pi1;
        public int i1
        {
            get => pi1;
            set 
            {
                pi1 = value;
                Changei(value);
            }
        }

        public TestClassA()
        {
            MainClass.ChangeiMain += (i) => { pi1 = i; };
        }

    }

    class TestClassB
    {
        public int i2 { get; set; }
    }


}
