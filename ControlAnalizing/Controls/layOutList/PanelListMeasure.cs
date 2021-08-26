using System.Windows.Forms;
using ControlAnalizing.DataEMF;


namespace ControlAnalizing.Controls.layOutList
{
    /// <summary>
    /// Класс для управления списками измерений ("Сигнала", "Шума"). Хранит кнопки для управления и список измерений ("Сигнала", "Шума").
    /// </summary>
    class PanelListMeasure : Panel
    {
        private ToolStripBtnsForList toolStripBtns;
        private TableLayoutPanel layOutSignal;  // Панель не инициализируются! А должна ссылаться на галвный класс с измерением!
        private TableLayoutPanel layOutNoise;   // Панель не инициализируются! А должна ссылаться на галвный класс с измерением!

        public delegate void addClick(ActiveSelect activeSelect);

        public event addClick AddClick;

        /// <summary>
        /// Конструктор панели с кнопками по управлению "Сигналом" или "Шумом"
        /// </summary>
        public PanelListMeasure()
        {
            Dock = DockStyle.Fill;
            Padding = new Padding(0);
            Margin = new Padding(0);

            // /* ———— Добавляем необходимые эелменты на панель ———— */
            toolStripBtns = new ToolStripBtnsForList();   // Инициализируем панель с кнопками по управлению списком измерений "Сигнал" или "Шум"
            Controls.Add(toolStripBtns);    // Добавляем на панель, панель ToolStrip с кнопками по управлению списком измерений "Сигнал" или "Шум"
            toolStripBtns.SigNoise += hideShowLayout;   // Подписываем метод, показа сокрытия списка "Сигнал" или "Шум" в зависисмости от того, что выборано
            toolStripBtns.AddClick += (a) => { this.AddClick(a); }; // Вернёт ActiveSelect, для вызова метода Add либо у "Сигнал" либо у "Шум"
        }

        /// <summary>
        /// Метод которые скрывает, показывает список "Сигнал" или "Шум" в зависимости, от того, что сейчас выбрано
        /// </summary>
        /// <param name="curSelect">Принимающий параметр из события, который укажет, что выбрано "Сигнал" или "Шум"</param>
        private void hideShowLayout(ActiveSelect activeSelect)
        {
            if (activeSelect == ActiveSelect.Signal)
            {
                if (layOutSignal != null)
                {
                    layOutSignal.Visible = true;
                }
                if (layOutNoise != null)
                {
                    layOutNoise.Visible = false;
                }
            }
            else if (activeSelect == ActiveSelect.Noise)
            {
                if (layOutSignal != null)
                {
                    layOutSignal.Visible = false;
                }
                if (layOutNoise != null)
                {
                    layOutNoise.Visible = true;
                }
            }
        }

        /// <summary>
        /// Свойство для добавления панели со списком шумов
        /// </summary>
        public TableLayoutPanel LayOutSignal
        {
            get => layOutSignal;
            set
            {
                layOutSignal = value;
                this.Controls.Add(layOutSignal);
            }
        }

        /// <summary>
        /// Свойство для добавления LayOut панели со списком сигналов
        /// </summary>
        public TableLayoutPanel LayOutNoise
        {
            get => layOutNoise;
            set
            {
                layOutNoise = value;
                Controls.Add(layOutNoise);
            }
        }
    }
}
