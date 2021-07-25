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
        private string pAddressFile; // Хранит адрес файла, если он установлено
        private string pFileName; // Хранит имя файла, если оно установлено
        private string fullAddress; // Хранит полный путь к файлу если возмодно его создать (задан адрес и имя)

        //  /* Свойства класса*/
        // Получаем адрес файла
        public string FileAddress
        {
            get => pAddressFile;
            set
            {
                // Проверяем есть ли слеш в конце, для получения корректного адреса
                if (value[value.Length - 1] != '\\')
                {
                    value += "\\";
                }
                pAddressFile = value;
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
        public string FullAdress { get => fullAddress; set => fullAddress = value; }


        // /* ———————————— Методы класса ———————————— */
        // Считываем данные из файла
        public List<string> ReadFile()
        {
            if (File.Exists(fullAddress))
            {
                List<string> tmpList = new List<string>();
                // Проубем считать данные из файла, даже если он уже открыт
                try
                {
                    // Создание процесса открытия файла, только для чтения
                    var flStrem = new FileStream(fullAddress, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

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
            this.fullAddress = fullAddress;
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
            if (FileAddress != null && FileName != null)
            {
                fullAddress = FileAddress + FileName;
            }
        } // Создаём полный путь к файлу

    }
}
