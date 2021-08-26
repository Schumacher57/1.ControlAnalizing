using System.Windows.Forms;
using System;
using System.Reflection;

namespace ControlAnalizing.Controls.layOutList
{

    class DataEMFTableLayOutList
    {

        private int activeIndexControl;
        public int ActiveIndexControl { get => activeIndexControl; set => activeIndexControl = value; }
        private TableLayoutPanel pDTEMFTabelLayOutList;
        public TableLayoutPanel DTEMFTabelLayOutList { get => pDTEMFTabelLayOutList; set => pDTEMFTabelLayOutList = value; }


        /// <summary>
        /// Метод добавление измеренния в отображаемый список.
        /// </summary>
        /// <param name="dataEMButton">параметр который хранит пользовательский контрол для управления конкретным измерением</param>
        public void Add(DataEMButton dataEMButton)
        {

        }

        /// <summary>
        /// Поле с TableLayOutPanel которое хранит список измерений с собственым контролом по управлению
        /// </summary>


        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public DataEMFTableLayOutList()
        {
            initialpTableLayout();
        }

        /// Метод инициализации панели для отображения пользовательского контрола, конкретного измерения
        void initialpTableLayout()
        {
            pDTEMFTabelLayOutList = new TableLayoutPanel(); // Инициализируем класс TableLayOutPanel
            pDTEMFTabelLayOutList.Dock = DockStyle.Fill;    //  Делаем заполнение во всю дочернюю форму
            pDTEMFTabelLayOutList.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;   // Отключаем границы
            pDTEMFTabelLayOutList.Padding = new Padding(0); // Отключаем отступы от других элементов
            pDTEMFTabelLayOutList.Margin = new Padding(0); // Отключаем отступы от других элементов
            pDTEMFTabelLayOutList.RowCount++;   // Добавляем строку по-умолчанию в панель
            pDTEMFTabelLayOutList.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));  // Применяем стиль по-умолчанию
            pDTEMFTabelLayOutList.AutoScroll = true;    //  Включаем автопрокрутку элементов в панели
            pDTEMFTabelLayOutList.DisableHorizontalScrollBar(); //  Отключаем горизонтальную прокрутку
        }



    }


    // Метод расширения который помогает отключить вертикальную прокрутку в TableLayout панели
    public static class DisableScroll
    {
        static MethodInfo funcSetVisibleScrollbars;
        static EventHandler ehResized;

        public static void DisableHorizontalScrollBar(this ScrollableControl ctrl)
        {
            //cache the method info
            if (funcSetVisibleScrollbars == null)
            {
                funcSetVisibleScrollbars = typeof(ScrollableControl).GetMethod("SetVisibleScrollbars",
                     BindingFlags.Instance | BindingFlags.NonPublic);
            }

            //init the resize event handler
            if (ehResized == null)
            {
                ehResized = (s, e) =>
                {
                    funcSetVisibleScrollbars.Invoke(s, new object[] { false, (s as ScrollableControl).VerticalScroll.Visible });
                };
            }

            ctrl.Resize -= ehResized;
            ctrl.Resize += ehResized;
        }
    }
}
