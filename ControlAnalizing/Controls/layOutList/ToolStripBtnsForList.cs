using System.Drawing;
using System.Windows.Forms;
using ControlAnalizing.Properties;
using ControlAnalizing.DataEMF;
using System;

namespace ControlAnalizing.Controls.layOutList
{
    class ToolStripBtnsForList : ToolStrip
    {

        // TODO: Подумать над прототипом делегата, событий кнопок ("Добавить", "Удалить", "Выбрать", "Фильтр" и т.д.)

        // /*Кнопки которые будут на панели по управлению полученными даными ("Сигнал", "Шум")
        private ToolStripButton btnSelect;
        private ToolStripButton btnAdd;
        private ToolStripButton btnDel;
        private ToolStripButton btnFiltr;
        private ToolStripButton btnLook;
        private ToolStripComboBox cmbSigNoise;

        // Поле которое хранит текущий выбор "Сигнал" или "Шум"
        private ActiveSelect activeSelect;
        private int activeIndex;

        private int heightButtons = 19; // Высота всех кнопок
        private int widthButtons = 19;  // Ширина всех кнопок

        /// <summary>
        /// Делегат который вернёт тип Enum, где возможно два значения: либо "Sginal", либо "Noise"
        /// </summary>
        /// <param name="activeSelect">Два значения либо "Sginal", либо "Noise"</param>
        public delegate void currentChoose(ActiveSelect activeSelect);
        
        
        public delegate void addClick(ActiveSelect activeSelect);



        /// <summary>
        /// Событие которое сработает, если пользователь изменит поле cmbSigNoise и вернёт текущий выбор "Сигнал" или "Шум"
        /// </summary>
        public event currentChoose SigNoise;    // Событие показывающее, что на данный момент выбрано
        /// <summary>
        /// Событие добавления измерения в список
        /// </summary>
        public event addClick AddClick;

        /// <summary>
        /// Конструктор класса, который инициализирует все данные, при вызове
        /// </summary>
        public ToolStripBtnsForList()
        {
            // /* Настраиваем свойства листа кнопок по управлению списком сигналов, по-умолчанию */
            Dock = DockStyle.Top;   // Закрепляем панель сверху
            GripStyle = ToolStripGripStyle.Hidden;  // Скрываем точки слева (ненужный шлак на форме)
            RenderMode = ToolStripRenderMode.System;    // Выбираем тип внешнего вида
            Padding = new Padding(0);   // Отключаем отступы от других элементов
            Margin = new Padding(0);    // Отключаем отступы от других элементов
            AutoSize = false;   // Включаем ручной размер
            Height = 19;    // Выставляем нужный нам размер
            initializationButtons();
            initializCmbSigNoise();

            // /* ———— Добавление созданных кнопок, в меню ToolStrip ———— */
            Items.Add(btnSelect);
            Items.Add(new ToolStripSeparator());
            Items.Add(btnAdd);
            Items.Add(new ToolStripSeparator());
            Items.Add(btnDel);
            Items.Add(new ToolStripSeparator());
            Items.Add(cmbSigNoise);
            Items.Add(new ToolStripSeparator());
            Items.Add(btnFiltr);
            Items.Add(new ToolStripSeparator());
            Items.Add(btnLook);

        }



        /// <summary>
        /// Метод инициализации кнопока, на панели ToolStripMenu, по управлению списокои измерений "Сигнал" или "Шум" 
        /// </summary>
        private void initializationButtons()
        {
            btnSelect = creatingButton(Resources.SelectMeasure);    // Инициализируем кнопку выбора
            btnAdd = creatingButton(Resources.AddMeasure);  // Иинициализируем кнопку добавления в список "Сигнала" или "Шума"
            btnDel = creatingButton(Resources.DelMeasure);  // Инициализируем кнопку удаления из списка "Сигнала" или "Шума"
            btnFiltr = creatingButton(Resources.ChartFilter4);  // Ииициализируем кнопку фильтра (SMA) для сигнала или шума
            btnLook = creatingButton(Resources.LookData2);  // Инициализируем кнопку просмотра данных "Сигнала" или "Шума"

            // /* ——— Инициализируем события кнопок на ToolStrip панели ——— */
            btnAdd.Click += (s, e) => { AddClick(this.activeSelect); }; // При нажатии на кнопку Добавления измерения вернётся текущий выбор "Сигнала" или "Шума"
        
        }


        /// <summary>
        /// Метод создания ToolStrip кнопки для управления списком измерений
        /// </summary>
        /// <param name="imageOnButton">Картинка для кнопки</param>
        /// <returns></returns>
        private ToolStripButton creatingButton(Image imageOnButton)
        {
            ToolStripButton tmpButton = new ToolStripButton(); // Временный Button для настройки по-умолчанию
            tmpButton.AutoSize = false; // Отключаеи авторазмер ддя кнопки
            tmpButton.Padding = new Padding(0); // Отключаем отступы от других элементов
            tmpButton.Margin = new Padding(0); // Отключаем отступы от других элементов
            tmpButton.Dock = DockStyle.Fill;    // Заполняем во всю ширину внутреннего контрола
            tmpButton.Height = heightButtons;   // Выстовляем высоту согалсно default значению
            tmpButton.Width = widthButtons; // Выстовляем ширину согалсно default значению
            tmpButton.DisplayStyle = ToolStripItemDisplayStyle.Image;   // Меняем стиль кнопки, на отображение только рисунка
            tmpButton.BackgroundImage = imageOnButton;  // Добавляем рисунок на кнопку
            tmpButton.BackgroundImageLayout = ImageLayout.Stretch;  // Выставляем типа заполнения рисунком кнопки (выравнивание по шиирине)

            return tmpButton;
        }

        /// <summary>
        /// Метод инициализации выпадающей кнопки ToolStripComboBox, для выбора "Сигнала" или "Шума"
        /// </summary>
        private void initializCmbSigNoise()
        {
            cmbSigNoise = new ToolStripComboBox();  // Создаём экземпляр класса ToolStripComboBox
            cmbSigNoise.AutoSize = false;   // Делаем размер не автоматическим, а задаваемым в ручную
            cmbSigNoise.Items.Add("Сигнал");    // Добавляем элемент "Сигнал"
            cmbSigNoise.Items.Add("Шум");   // Добавляем элемнет "Шум"
            cmbSigNoise.FlatStyle = FlatStyle.Flat; // Задаём внешний стиль типа: Flat
            cmbSigNoise.Padding = new Padding(0);   // Отключаем отступы от других элементов
            cmbSigNoise.Margin = new Padding(0);    // Отключаем отступы от других элементов
            cmbSigNoise.Dock = DockStyle.Fill;  // Заполнение на весь элемент
            cmbSigNoise.DropDownStyle = ComboBoxStyle.DropDownList; // Отключаем возможность вводить собственные значения в список
            cmbSigNoise.Height = heightButtons; // Выставляем высоты элемента ToolStripComboBox
            cmbSigNoise.Width = 63; // Выставляем ширину элемента ToolStripComboBox
            cmbSigNoise.SelectedIndexChanged += CmbSigNoise_SelectedIndexChanged; // Событие изменение выбора списка: "Сигнал" или "Шум"
            cmbSigNoise.SelectedIndex = (int)ActiveSelect.Signal;  // Выбираем элемент по-умолчанию — "Сигнал"


        }

        // Метод, который срабатывает при изменении выбора списка "Сигнал" или "Шум"
        private void CmbSigNoise_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Включение или отключение кнопки выбора. Если выбран "Шум", то кнопка выбора не доступна.
            btnSelect.Enabled = (byte)(sender as ToolStripComboBox).SelectedIndex == (int)ActiveSelect.Signal ? true : false;

            /// <summary>
            /// Вызываем событие в зависимости от того, что выбрано в данный момент
            /// </summary>
            if (SigNoise != null)
            {
                switch ((byte)(sender as ToolStripComboBox).SelectedIndex)
                {
                    case 0:
                        SigNoise(ActiveSelect.Signal);
                        activeSelect = ActiveSelect.Signal;
                        break;
                    case 1:
                        SigNoise(ActiveSelect.Noise);
                        activeSelect = ActiveSelect.Noise;
                        break;
                    default:
                        SigNoise(ActiveSelect.Signal);
                        activeSelect = ActiveSelect.Signal;
                        break;
                }

            }
            
        }
    }
}
