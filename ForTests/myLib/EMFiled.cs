using System;
using System.Collections.Generic;
using System.Text;

namespace ForTests.myLib
{
    class EMFiled
    {
        public IList<Measures> Measures { get; set; }

        public void EMField()
        {
            Measures = new List<Measures>();
        }


    }

    public class Measures
    {
        public void SomeDO()
        {

        }
        public static void add()
        {

        }
    }
}
