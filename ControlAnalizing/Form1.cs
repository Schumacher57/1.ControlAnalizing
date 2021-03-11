using System.Diagnostics;
using System.IO;
using System;
using System.Windows.Forms;

namespace ControlAnalizing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText("log.txt"))); // Имя файл при отладке (логирование)
            Trace.AutoFlush = true; // Добавляем "слушателей" для отладки



        }
    }
}
