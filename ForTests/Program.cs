using System;
using System.Diagnostics;
using ForTests.myLib;

namespace ForTests
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "123";
            TraceListener myListen = new ConsoleTraceListener();
            Trace.Listeners.Add(myListen);

            someClass myNewSomeClass = new someClass();
            myNewSomeClass.someString = "123";

            Console.ReadKey();
        }
    }
}
