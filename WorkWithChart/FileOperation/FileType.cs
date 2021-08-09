using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;



namespace WorkWithChart.FileOperation
{
    public class FileType
    {
        //  /* Приватные поля класса, для свойств класса*/
        private string pFileAddress; // Хранит адрес файла, если он установлено
        private string pFileName; // Хранит имя файла, если оно установлено
        private string pFullAddress; // Хранит полный путь к файлу если возмодно его создать (задан адрес и имя)

        // /* ———————————— Свойства класса ———————————— */
        // Получаем адрес файла
        public string FileAddress
        {
            get => pFileAddress;
            set
            {
                // Проверяем есть ли слеш в конце, для получения корректного адреса
                if (value[value.Length - 1] != '\\')
                {
                    value += "\\";
                }
                pFileAddress = value;
                crtFullAddress();
            }
        }
        // Получаем имя файла
        public string FileName
        {
            get => pFileName;
            set
            {
                pFileName = value;
                crtFullAddress();
            }
        }
        // Свойство c полным адресом
        public string FullAdress
        {
            get => pFullAddress;
            set
            {
                if (Directory.Exists(value) || File.Exists(value))
                {
                    pFullAddress = value;
                    pFileAddress = Path.GetDirectoryName(pFullAddress) + "\\";
                    FileName = Path.GetFileName(pFullAddress);
                }
            }
        }


        // /* ———————————— Методы класса ———————————— */
        // Считываем данные из файла
        public List<string> ReadFile()
        {
            if (File.Exists(pFullAddress))
            {
                List<string> tmpList = new List<string>();
                // Проубем считать данные из файла, даже если он уже открыт
                try
                {
                    // Создание процесса открытия файла, только для чтения
                    var flStrem = new FileStream(pFullAddress, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    // Читаем файл.
                    using (var myFile = new StreamReader(flStrem))
                    {
                        // Считываем данные из файла построчно
                        while (!myFile.EndOfStream)
                        {
                            tmpList.Add(myFile.ReadLine());
                        }
                    }
                }
                // 
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    err_msg($"Ошибка при чтении данных из файла: {FileName}. Возможно файл, используется в другой программе.\nСообщение ошибки: {e.Message}");
                    return null;
                }

                Debug.Print($"Кол-во строк в файле: {tmpList.Count.ToString()}");
                return tmpList; // Возвращаем считанные строки в виде List'а
            }

            err_msg($"Ошибка. Файла с именем {FileName} по адресу {FileAddress}, не существует");
            return null;
        }

        // Получаем данные из файла, если параметр был передан в конструктор.
        public List<string> ReadFile(string fullAddress)
        {
            this.pFullAddress = fullAddress;
            return ReadFile();
        }


        // Информационное сообщения об ошибке
        private void err_msg(string informMsg)
        {
            MessageBox.Show($"{informMsg}", "Произошла ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Получаем полное имя. Если адрес и имя были переданы по отдельности
        private void crtFullAddress()
        {
            if (FileAddress != null && FileName != null && FullAdress != "")
            {
                pFullAddress = FileAddress + FileName;
            }
        } // Создаём полный путь к файлу

    }
}
