using System.Data;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace ForTests.MyDataSet
{
    class EMFiledEx : DataSet
    {
        private List<DataTable> pSMATables = new List<DataTable>();

        public List<DataTable> SMATables
        {
            get => pSMATables;
            set => value = pSMATables;
        }

        public DataTable LoadDataFromFile()
        {
            return null;
        }


        //DataSet bookStore = new DataSet("BookStore");


    }
    class MeasureEx : DataTable
    {
        //private DataView mySortByFreq;

        public void displInfo()
        {
            Console.Write("\tИд \tЧас\tСигнал \tШум \tРазница Сиг-Шум\n");
            foreach (DataRow row in this.Rows)
            {
                foreach (var cell in row.ItemArray)
                {
                    Console.Write($"\t{cell}");
                }
                Console.WriteLine("");
            }
        }

        /*public void displInfoSort()
        {
            Console.Write("\tИд \tСигнал \tШум \tРазница Сиг-Шум\n");

            foreach (DataRow row in this.Rows)
            {
                foreach (var cell in row.ItemArray)
                {
                    Console.Write($"\t{cell}");
                }
                Console.WriteLine("");
            }
        }*/

        /*public GetSortedTable()
        {
           
        }*/

        public MeasureEx(DataTable someTbl)
        {
            
        }

        public MeasureEx()
        {

        }
        // Переопределяем конструктор
        public MeasureEx(string name):base()
        {
            // Имя таблицы
            this.TableName = name;
            
            // Создаём столбцы таблицы
            // Столбец ID
            DataColumn idColumn = new DataColumn("ID", Type.GetType("System.Int64"));
            idColumn.Unique = true; // Только уникальные значнеия
            idColumn.AllowDBNull = false; // Не могут быть Null объектами
            idColumn.AutoIncrement = true; // Будет автоинкрементироваться
            idColumn.AutoIncrementSeed = 1; // Начало с 1
            idColumn.AutoIncrementStep = 1; // Шаг автоинкремента - 1
            // Столбец Частота 
            DataColumn freqColumn = new DataColumn("Частота", Type.GetType("System.Double"));
            freqColumn.DefaultValue = 0;
            freqColumn.AllowDBNull = false;
            
            // Столбец Сигнал
            DataColumn sigColumn = new DataColumn("Сигнал", Type.GetType("System.Double"));
            sigColumn.AllowDBNull = true;
            sigColumn.DefaultValue = null;
            // Столбец Шум
            DataColumn noiseColumn = new DataColumn("Шум", Type.GetType("System.Double"));
            noiseColumn.AllowDBNull = true;
            noiseColumn.DefaultValue = null;
            // Уровень сигнала
            DataColumn diffColumn = new DataColumn("Разница сиг-шум", Type.GetType("System.Double"));
            diffColumn.AllowDBNull = true;
            diffColumn.DefaultValue = null;
            diffColumn.Expression = "CONVERT((Сигнал - Шум) * 100, System.Int64) / 100";

            // Добавляем созданные столбцы
            this.Columns.Add(idColumn); // Столбец порядковый номер - ID
            this.Columns.Add(freqColumn); // Столбец Частота (не может быть Null!!!)
            
            this.Columns.Add(sigColumn); // Столбец Сигнал
            this.Columns.Add(noiseColumn); // Столбец Шум
            this.Columns.Add(diffColumn);   // Столбец разница сигнал - шум

            //this(new DataTable(thi));
            this.DefaultView.Sort = "Частота ASC";

           
            //DataTable someTabl = new DataTable();
            //this = mySortByFreq.ToTable();

        }



        // Применение функции SMA для данных в таблице
        public DataTable ExucuteSMA()
        {
            return null;
        }
    }

}


