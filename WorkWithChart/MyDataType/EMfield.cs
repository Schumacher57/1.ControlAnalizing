using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using WorkWithChart.FileOperation;
using ZedGraph;

namespace WorkWithChart.MyDataType
{
    /// <summary>
    /// Класс со всеми измерениями
    /// </summary>
    class EMfield
    {
        #region
        internal class MeasureDT // Measure Data Table
        {
            private readonly int maxColumn;
            List<Measure> Measures = new List<Measure>();

            // Добавление измерений из файла
            /// <summary>
            /// Получения данных из файла
            /// </summary>
            /// <param name="fullAddressFile">Полный путь к файлу</param>
            /// <returns>Возвращает объект Measure - полученных измерений </returns>
            public Measure GetMeasureFromFile(string fullAddressFile, string FileName = "")
            {

                FileType tmpFile = new FileType(); // Создаём переменную тиап "Файл"
                tmpFile.FullAdress = fullAddressFile; // Поулчаем адрес к файлу
                if (FileName == "")
                {
                    FileName = tmpFile.FileName;
                }
                //  Получаем временную таблицу нужного формата
                Measure tmpMeasure = new Measure(FileName);
                DataTable tmpTable = tmpMeasure.GetTable();
                object[] tmpRow = new object[] { };
                // Считываем файл построчно
                foreach (string tmpLine in tmpFile.ReadFile())
                {
                    tmpRow = getRowFromStrLine(tmpLine); // Преобразуем строку из файла в строку для записи в таблицу 
                    if (tmpRow != null) // И если есть, что записать, то заносим строку в Mesure
                    {
                        tmpTable.Rows.Add(tmpRow);
                    }
                }


                tmpMeasure.SetTable(tmpTable);
                Measures.Add(tmpMeasure);
                return tmpMeasure; // Если было что-то записано то возвращаем Mesure. Если нет то ничего не возвращаем.
            }

            // Получаем из строки тип Row для данных типа DataTable, если это возможно
            /// <summary>
            /// Получаем из строки тип Row для данных типа DataTable, если это возможно. Если нет то вернёт Null
            /// </summary>
            /// <returns>Если возможно то вренёт тип Row, если нет то вернёт тип Null. Делать проверку!</returns>
            private object[] getRowFromStrLine(string StrLine)
            {
                // Порядок такой: ID, Чатота, Сигнал, Шум, Разница, Коэффициент усиления (если есть).
                // Возможный тип разбиития либо через табуляцию, либо пробел. Остальное в игнор (->null)

                // Разбиваем строку на подстроки
                string[] tmpString = StrLine.Split(new char[] { ' ', '\t' });
                bool flagData = false; // Флаг который показывает есть ли данные в строке

                // Создаём данные для строки добавления в таблицу данных
                List<object> tmpObjRow = new List<object>();
                // Заполняем всё Null типами
                for (int i = 0; i <= maxColumn; i++) { tmpObjRow.Add(null); }
                // Смотрим, можно ли что-то добавить
                for (int i = 0; (i < tmpString.Length) && (i < maxColumn); i++)
                {
                    if (double.TryParse(tmpString[i].Replace(",", "."), System.Globalization.NumberStyles.Any, new System.Globalization.NumberFormatInfo { NumberDecimalSeparator = "." }, out double Vals))
                    {
                        flagData = true; // Если что-то получилось преобразовать в строке то будем заносить. Иначе пропустим строку.
                        tmpObjRow[i + 1] = Vals;
                    }
                }
                return flagData == true ? tmpObjRow.ToArray() : null;

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

    /// <summary>
    ///// Класс с каким-либо конкретным измерением
    /// </summary>
    public class Measure
    {
        private DataTable pMesureDT = new DataTable();
        private string pTableName;
        private string TableName { get => pTableName; set => pTableName = value; }


        // Получаем таблицу для достуапа из вне
        public DataTable GetTable() => pMesureDT;
        /// <summary>
        /// Устанавливает таблицу в 
        /// </summary>
        /// <param name="EMTale"></param>
        /// <return>Вернёт таблицу данных измерений в виде DataTable </return>
        public void SetTable(DataTable EMTale) => pMesureDT = EMTale;

        // Метод добавления только частоты
        public void AddData(double Freq)
        {
            pMesureDT.Rows.Add(new object[] { null, Freq });
            //return null;
        }

        //TODO: Метод добавления частоты и сигнала
        public void AddData(double Freq, double Sig)
        {
            pMesureDT.Rows.Add(new object[] { null, Freq, Sig });
            //return null;
        }

        public PointPairList GetLineForSig()
        {
            List<double> tmpListFreq = new List<double>();
            List<double> tmpListSig = new List<double>();
            var tmpNoise = new List<double>();
            tmpListFreq = pMesureDT.AsEnumerable().Select(x => double.Parse(x[1].ToString())).ToList();
            tmpListSig = pMesureDT.AsEnumerable().Select(x => double.Parse(x[2].ToString())).ToList();
            var tmpPointPair = new PointPairList();
            tmpPointPair.Add(tmpListFreq.ToArray(),tmpListSig.ToArray());
            return tmpPointPair;
        }


        //Метод отображения информации
        public void InfoToFile()
        {
            TextWriterTraceListener someRept = new TextWriterTraceListener(@"d:\Books\Document\Google disk\Work\Programming\C#\Текущие проекты\1. ControlAnalizing\DataResource\Measure\ReportFiles\reportDataTable.txt");
            someRept.Write("\tИд\tЧаст\tСигнал\tШум\tРазница\tСиг-Шум\tКоэфф\n");
            foreach (DataRow row in pMesureDT.Rows)
            {
                foreach (var cell in row.ItemArray)
                {
                    someRept.Write($"\t{cell}");
                }
                someRept.WriteLine("");
            }
            someRept.Flush();
        }

        // Конструктор, который создаёт столбцы по-умолчанию
        /// <summary>
        /// Конструктор принимает имя измерения
        /// </summary>
        /// <param name="TableName">Имя измерения, которое будет передано в DataTable</param>
        public Measure(string TableName)
        {
            TableName = pTableName;
            pMesureDT = getTableDefault();
        }

        // таблицы со столбцами по-умолчанию
        private DataTable getTableDefault()
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
            // Коэффициент усиления
            DataColumn gaineFreq = new DataColumn("Коэф. усл.", Type.GetType("System.Double"));
            gaineFreq.AllowDBNull = true;
            gaineFreq.DefaultValue = null;

            // Добавляем созданные столбцы
            tmpTable.Columns.Add(idColumn); // Столбец порядковый номер - ID
            tmpTable.Columns.Add(freqColumn); // Столбец Частота (не может быть Null!!!)
            tmpTable.Columns.Add(sigColumn); // Столбец Сигнал
            tmpTable.Columns.Add(noiseColumn); // Столбец Шум
            tmpTable.Columns.Add(diffColumn);   // Столбец разница сигнал - шум
            tmpTable.Columns.Add(gaineFreq);   // Коэффициент усиления

            return tmpTable;
            //this(new DataTable(thi));
            //tmpTable.DefaultView.Sort = "Частота ASC";
            //return tmpTable;
        }

    }


}
