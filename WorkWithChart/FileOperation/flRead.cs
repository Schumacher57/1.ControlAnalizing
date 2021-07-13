using System;
using WorkWithChart.ChartOperation;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;


namespace WorkWithChart.FileOperation
{
    class someFile
    {

        private string pAddrFile;
        private string pFileName;
        public string AddrFile 
        {
            get 
            {
                return pAddrFile; 
            }
            set
            {
                pAddrFile = value;
                crtFullAddress();
            }
        }
        public string FileName
        {
            get
            {
                return pFileName;
            }
            set
            {
                pFileName = value;
                crtFullAddress();
            }
        }   //
        private string fullAddress;




        public MeasureData ReadFile()
        {
            if (File.Exists(fullAddress))
            {
                MeasureData tmpMeasure = new MeasureData();
                try
                {
                    using (StreamReader myFile = new StreamReader(fullAddress))
                    {
                        string[] tmpStr;
                        while (!myFile.EndOfStream)
                        {
                            tmpStr = myFile.ReadLine().Replace(".", ",").Split('\t');
                            tmpMeasure.AddData(double.Parse(tmpStr[0]), double.Parse(tmpStr[1]));
                        }
                    }
                }
                catch (Exception e) 
                {
                    Debug.WriteLine(e.Message);
                }
                return tmpMeasure;
            }
            return null;
        }

        public MeasureData ReadFile (string fullAddress)
        {
            return null;
        }

        private void crtFullAddress()
        {
            if (AddrFile != null && FileName != null)
            {
                fullAddress = AddrFile + FileName;
            }
        } // Создаём полный путь к файлу

    }
}
