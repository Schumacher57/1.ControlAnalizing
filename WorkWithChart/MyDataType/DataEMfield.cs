using System.Collections.Generic;
using fileOP = WorkWithChart.FileOperation;

namespace WorkWithChart.MyDataType
{
    class DataEMfield 
    {
        
        public List<double> DTFreq { get; set; } = new List<double>();
        public List<double> DTSig { get; set; } = new List<double>();
        public List<double> DTNoise { get; set; } = new List<double>();

        // Получаем данные из файла по полному пути.
        public DataEMfield[] GetDataFromFile(string fullAddress)
        {


            return null;
        }

        // Получаем данные из файла по составному пути
        public DataEMfield[] GetDataFromFile(string addressFile, string fileName)
        {


            return null;
        }
        static public void Add()
        {
            

        }
    }
}
