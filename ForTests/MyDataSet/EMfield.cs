using System.Data;
using System;
using System.Collections.Generic;
using WorkWithChart.FileOperation;

namespace ForTests.EM
{
    class EMfield
    {
        #region
        internal class MeasureDT // Measure Data Table
        {
            private readonly int maxColumn;
            List<Measure> Measures;

            //Допилить метод очистки всех таблиц 
            public void CleaAllDataInTables()
            {
                foreach (Measure tmpMeasure in Measures)
                {
                    DataTable tmpTbl;
                    tmpTbl = tmpMeasure.GetTable();
                }
            }

            // Добавление измерений из файла
            /// <summary>
            /// Получения данных из файла
            /// </summary>
            /// <param name="fullAddressFile">Полный путь к файлу</param>
            /// <returns>Возвращает объект Measure - полученных измерений </returns>
            public Measure GetMeasureFromFile(string fullAddressFile, string FileName = "")
            {
                DataTable tmpTable = new Measure("tmpTable").GetTable();
                FileType tmpFile = new FileType(); // Создаём переменную тиап "Файл"
                tmpFile.FullAdress = fullAddressFile; // Поулчаем адрес к файлу
                if (FileName == "")
                {
                    FileName = tmpFile.FileName;
                }

                // Считываем файл построчно
                foreach (string tmpLine in tmpFile.ReadFile())
                {
                    if (getRowFromStrLine(tmpLine) != null)
                    {
                        tmpTable.Rows.Add(getRowFromStrLine(tmpLine));
                    }
                }
                EM.Measure tmpMeasure = new EM.Measure(FileName);
                tmpMeasure.SetTable(tmpTable);
                return tmpMeasure;
            }


            // TODO: Получаем из строки тип Row для данных типа DataTable, если это возможно
            /// <summary>
            /// Получаем из строки тип Row для данных типа DataTable, если это возможно. Если нет то вернёт Null
            /// </summary>
            /// <returns>Если возможно то вренёт тип Row, если нет то вернёт тип Null. Делать проверку!</returns>
            private object[] getRowFromStrLine(string StrLine)
            {
                // Порядок такой: Чатота, Сигнал, Шум, разница.
                // Возможный тип разбиития либо через табуляцию, либо пробел. Остальное в игнор (->null)
                // DataRow tmpRow = new DataRow();
                string[] tmpString = StrLine.Split(new char[] { ' ', '\t' });
                if ((tmpString.Length <= 0) || (tmpString.Length > maxColumn))
                { return null; }
                List<object> tmpObjRow = new List<object>();
                tmpObjRow.Add(null);
                for (int i = 0; i < maxColumn; i++)
                {
                    if (tmpString.Length < i)
                    {
                        try
                        {
                            tmpObjRow.Add(double.Parse(tmpString[0].Replace(",", ".")));
                        }
                        catch
                        {
                            
                        }
                    }
                    tmpObjRow.Add(null);
                }
                return tmpObjRow.ToArray();
                /*try
                {
                    switch (tmpString.Length)
                    {
                        case 1:
                            return new object[] { null, double.Parse(tmpString[0].Replace(",", ".")) };
                        case 2:
                            return new object[] { null, double.Parse(tmpString[0].Replace(".", ",")), double.Parse(tmpString[1].Replace(".", ",")) };
                        case 3:
                            return new object[] { null, double.Parse(tmpString[0].Replace(",", ".")), double.Parse(tmpString[1].Replace(",", ".")), double.Parse(tmpString[2].Replace(",", ".")) };
                        case 4:
                            return new object[] { null, double.Parse(tmpString[0].Replace(",", ".")), double.Parse(tmpString[1].Replace(",", ".")), double.Parse(tmpString[2].Replace(",", ".")), double.Parse(tmpString[3].Replace(",", ".")) };
                        case 5:
                            return new object[] { null, double.Parse(tmpString[0].Replace(",", ".")),
                                double.Parse(tmpString[1].Replace(",", ".")), double.Parse(tmpString[2].Replace(",", ".")), double.Parse(tmpString[3].Replace(",", ".")), double.Parse(tmpString[4].Replace(",", ".")) };
                        default:
                            return null;
                    }
                }
                catch
                {
                    return null;
                }*/

            }

            // Добавление типа Measure в список
            /// <summary>
            /// Добавлние измерения (Measure) в список
            /// </summary>
            /// <param name="TableName">Имя измерений</param>
            /// <returns>Возвращает измерения типа Measure</returns>
            public Measure Add(string TableName)
            {
                Measures.Add(new Measure(TableName));
                return Measures[Measures.Count - 1];
            }

            // Индексатор таблиц
            public Measure this[int index]
            {
                get => Measures[index]; // Получаем элмент из списка
                set
                {
                    // Проверяем существует ли элемент
                    if (Measures[index] != null)
                    {
                        Measures[index] = value;
                    }
                    else
                    {
                        Measures.Add(value);
                    }
                }
            }

            // Конструтор таблицы с данными по измерениям
            public MeasureDT()
            {
                maxColumn = 4;
                //Measures.Tables.Add();
            }
        }
        #endregion
        public MeasureDT Measure { get; } = new MeasureDT();



    }

    public class Measure
    {
        private DataTable pmeasureDataTable;
        private DataTable mesureDT { get => pmeasureDataTable; set => pmeasureDataTable = value; }
        private string pTableName;
        private string TableName { get => pTableName; set => pTableName = value; }


        // Получаем таблицу для достуапа из вне
        public DataTable GetTable() => mesureDT;
        public void SetTable(DataTable EMTale) => mesureDT = EMTale;

        // Метод добавления только частоты
        public void AddData(double Freq)
        {
            mesureDT.Rows.Add(new object[] { null, Freq });
            //return null;
        }

        // Метод добавления частоты и сигнала
        public void AddData(double Freq, double Sig)
        {
            mesureDT.Rows.Add(new object[] { null, Freq, Sig });
            //return null;
        }


        // Конструктор, который создаёт столбцы по-умолчанию
        public Measure(string TableName)
        {
            TableName = pTableName;
            pmeasureDataTable = new DataTable();
            getTableDefault();
        }

        // таблицы со столбцами по-умолчанию
        private void getTableDefault()
        {
            // Имя таблицы
            DataTable tmpTable = new DataTable();
            tmpTable.TableName = this.TableName; ;    // Имя таблицы. Не забыть!

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
            tmpTable.Columns.Add(idColumn); // Столбец порядковый номер - ID
            tmpTable.Columns.Add(freqColumn); // Столбец Частота (не может быть Null!!!)
            tmpTable.Columns.Add(sigColumn); // Столбец Сигнал
            tmpTable.Columns.Add(noiseColumn); // Столбец Шум
            tmpTable.Columns.Add(diffColumn);   // Столбец разница сигнал - шум

            //this(new DataTable(thi));
            tmpTable.DefaultView.Sort = "Частота ASC";
            //return tmpTable;
        }

    }


}
