using System.Windows.Forms;
using System.Drawing;
using System;
using ControlAnalizing.Properties;
using System.Diagnostics;
using System.Collections.Generic;

namespace ControlAnalizing.Controls.MainMenuStrip
{
    class UpMenuStrip : MenuStrip
    {

        //private deleg
        private ToolStripMenuItem upMenuStripMeasure;
        private ToolStripMenuItem[] listMeasureMenu; // Хранит "Сигнал" и "Шума" списка меню
        private ToolStripMenuItem[] listSignalMenu; // Хранит список меню в "Сигнал"
        private ToolStripMenuItem[] listNoiseMenu; // Хранит список меню в "Шум"


        /// <summary>
        /// Кнопка сохранения всех сигналов
        /// </summary>
        public event EventHandler ClickSaveMeasures;
        /// <summary>
        /// Кнопка загрузки сигналов
        /// </summary>
        public event EventHandler ClickLoadMeasures;
        /// <summary>
        /// Кнопка добаления конкретного сигнала из файла
        /// </summary>
        public event EventHandler ClickAddMeasureFromFile;

        public event EventHandler ClickSaveNoises;
        public event EventHandler ClickLoadNoises;
        public event EventHandler ClickLoadNoise;

        /// <summary>
        /// Конструктор главного меню сверху
        /// </summary>
        public UpMenuStrip()
        {

            GripStyle = ToolStripGripStyle.Hidden;
            //AutoSize = false;
            RenderMode = ToolStripRenderMode.System;
            Padding = new Padding(0);
            Margin = new Padding(0);
            Dock = DockStyle.Top;
            crtButtons();

        }


        public void crtButtons()
        {
            initialListMenuMeasure(); // Инициализируем список меню "Сигнал" и "Шум"
            initialListMenuSignal(); // Инициализируем список меню для "Сигнал"
            initialListMenuNoise(); // Инициализируем список меню для "Шум"

            upMenuStripMeasure = initialItemMenuStrip("Измерения");
            upMenuStripMeasure.DropDownItems.AddRange(listMeasureMenu);
            listMeasureMenu[0].DropDownItems.AddRange(listSignalMenu); // Добавляем список менюшек в лист сигнала
            listMeasureMenu[1].DropDownItems.AddRange(listNoiseMenu); // Добавляем список менюшек в лист шума

            Items.Add(upMenuStripMeasure);
        }


        // —————————————————— /* МЕТОДЫ */ ——————————————————


        // Инициализируем меню "Измерения"
        void initialListMenuMeasure()
        {
            List<ToolStripMenuItem> tmpListMenuMeasure = new List<ToolStripMenuItem>();
            tmpListMenuMeasure.Add(initialItemMenuStrip("Сигнал"));
            tmpListMenuMeasure.Add(initialItemMenuStrip("Шум"));
            listMeasureMenu = tmpListMenuMeasure.ToArray();
        }


        // Создание списка меню для "Сигнала"
        void initialListMenuSignal()
        {
            var tmpListMenuSignal = new List<ToolStripMenuItem>();
            tmpListMenuSignal.Add(initialItemMenuStrip("Сохранить список сигналов",Resources.SaveSignal));
            tmpListMenuSignal.Add(initialItemMenuStrip("Загрузить список сигналов",Resources.DownLoadSignal));
            tmpListMenuSignal.Add(initialItemMenuStrip("Добавить сигнал из файла"));
            tmpListMenuSignal[0].Click += (s, e) => { ClickSaveMeasures?.Invoke(s, e); };   // Событие кнопки "Сохранить список сигналов"
            tmpListMenuSignal[1].Click += (s, e) => { ClickLoadMeasures?.Invoke(s, e); };   // Событие кнопки "Загрузить список сигналов"
            tmpListMenuSignal[2].Click += (s, e) => { ClickAddMeasureFromFile?.Invoke(s, e); }; // Событие кнопки "Загрузить сигнал из файла"
            listSignalMenu = tmpListMenuSignal.ToArray();
        }

        // Создание списка меню для "Шума"
        void initialListMenuNoise()
        {
            var tmpListMenuNoise = new List<ToolStripMenuItem>();
            tmpListMenuNoise.Add(initialItemMenuStrip("Сохранить список шумов"));   // Добавляем кнопку "Сохранить список шумов" в меню "Шум"
            tmpListMenuNoise.Add(initialItemMenuStrip("Загрузить список шумов"));
            tmpListMenuNoise.Add(initialItemMenuStrip("Добавить шум из файла"));
            tmpListMenuNoise[0].Click += (s, e) => { ClickSaveNoises?.Invoke(s, e); };  // Событие кнопки "Сохранить список шумов"
            tmpListMenuNoise[1].Click += (s, e) => { ClickLoadNoises?.Invoke(s, e); };  // Событие кнопки "Загрузить список шумов"
            tmpListMenuNoise[2].Click += (s, e) => { ClickLoadNoise?.Invoke(s, e); };   // Событие кнопки "Загрузить шум из файла"
            listNoiseMenu = tmpListMenuNoise.ToArray();

        }





        // Метод инициализации конкретной строки в меню
        /// <summary>
        /// Функция создания строки в верхней меню
        /// </summary>
        /// <param name="textOnMenu">Название кнопки</param>
        /// <returns>возвращает сам элемнт ToolStripMenuItem</returns>
        ToolStripMenuItem initialItemMenuStrip(string textOnMenu)
        {
            ToolStripMenuItem tmpInitialMenu = new ToolStripMenuItem();
            tmpInitialMenu.Text = textOnMenu;
            tmpInitialMenu.Dock = DockStyle.Fill;
            tmpInitialMenu.Padding = new Padding(0);
            tmpInitialMenu.Margin = new Padding(0);
            return tmpInitialMenu;
        }

        // Метод инициализации конкретной строки в меню, с картинкой (перегрузка)
        ToolStripMenuItem initialItemMenuStrip(string textOnMenu, Image imgMenu)
        {
            ToolStripMenuItem tmpInitialMenu = initialItemMenuStrip(textOnMenu);
            tmpInitialMenu.Image = imgMenu;
            tmpInitialMenu.ImageAlign = ContentAlignment.MiddleCenter;

            return tmpInitialMenu;
        }
    }

}
