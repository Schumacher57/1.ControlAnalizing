using System;
using System.Windows.Forms;
using System.Diagnostics;
using ControlAnalizing.DataEMF;
using ControlAnalizing.Properties;


namespace ControlAnalizing.Controls.layOutList
{


    partial class DataEMButton : UserControl
    {

        // Делегат и событие, для изменения имени
        public delegate void nameChanged(string newName);
        public event nameChanged NameChanged;

        // Основные свойства элемента для работы с графиками на форме
        private string nameMeasure = string.Empty;  // Имя измерения
        private bool showOnChart = false;   // Включён/отклюен показ на графике (chart)
        private bool activeOnChart = false; // Активен для чарта или нет
        private TextBoxNameMesure tmpTextBoxMeasure = new TextBoxNameMesure();

        // Автосвойства элемента показа графиков
        public string NameMeasure { get => nameMeasure; set => nameMeasure = value; }
        public bool ShowOnChart { get => showOnChart; set => showOnChart = value; }
        public bool ActiveOnChart
        {
            get => activeOnChart;
            set
            {
                tmpTextBoxMeasure.ActiveOnChart = value;
                activeOnChart = value;
            }
        }

        // Для внешнего события, если был нажат встроенный элемент TextBox'а
        public event EventHandler TextBoxClicked;

        // Конструктор с настройкой пользовательского элемента по-умолчанию. Должен принять имя измерения, для отображения.
        public DataEMButton(EMField.UpMeasureLevel emfield, string inputName, int index)
        {
            InitializeComponent();  // Инициализируем встроенные компоненты
            this.Dock = DockStyle.Fill; // Заполняем пользовательский элемент на весь дочерний
            this.BorderStyle = BorderStyle.None;    // Отключаем границы у пользовательского элемента
            this.Margin = new Padding(1, 1, 1, 1);  // Задаём отступы по-умолчанию, у пользоватльского элемента
            this.Padding = new Padding(1, 1, 1, 1);  // Задаём отступы по-умолчанию, у пользоватльского элемента
            this.nameMeasure = inputName;   // Задаём имя для пользоватльского элемента (в последующем для TextBox'а)


            tmpTextBoxMeasure.Text = inputName; // Назначаем принятое имя для внутреннего элемента TextBox'а

            // /* ——— Пользовательские события ——— */ 
            // Вызывем событие изменения имени
            tmpTextBoxMeasure.TextChanged += (s, e) => { NameChanged((s as TextBox).Text); };
            // Тестовое событие
            tmpTextBoxMeasure.Click += (s, e) =>
            {
                TextBoxClicked?.Invoke(this, e);
            };

            this.Controls.Add(tmpTextBoxMeasure);
            activeOnChart = tmpTextBoxMeasure.ActiveOnChart;
            this.Controls.Add(new ButtonEyeFlag());
            this.Refresh();
            updateTextBoxWidth();

        }



        // Событие загрузки эелемнта куда либо
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Debug.WriteLine($"this.Width: {this.Width.ToString()}");
            updateTextBoxWidth();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            updateTextBoxWidth();
        }


        // Ресайзим элементы во время загрузки согласно из новым размерам
        public void updateTextBoxWidth()
        {
            foreach (Control someCont in this.Controls)
            {
                if (someCont is ButtonEyeFlag)
                {

                    someCont.Width = (int)(this.Width * 0.1);
                }
                if (someCont is TextBoxNameMesure)
                {
                    someCont.Width = (int)(this.Width * 0.9) - 5;
                }
            }
        }


        #region Встроенные классы, c наследуемыми стандартынми контроллами (Button, TextBox...), необходимые для построения пользовательского контрола 

        // Класс TextBox'а с моим фнукционалом
        private class TextBoxNameMesure : TextBox
        {
            string nameMeasure = string.Empty;
            //public string NameMeasure { get => nameMeasure; set => nameMeasure = value; }
            public bool ActiveOnChart
            {
                get => activeOnChart;
                set
                {
                    activeOnChart = value;
                    this.BackColor = this.ActiveOnChart ? System.Drawing.Color.DeepSkyBlue : this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240); // Меняеи цвет, если элемент стал "выбранным"
                }
            }

            private bool activeOnChart = false;

            // Конструктор TextBox'а с найтроками по-умолчанию
            public TextBoxNameMesure()
            {


                this.Dock = DockStyle.Left; // Выравниваем TextBox по левому краю
                this.TextAlign = HorizontalAlignment.Center;   // Выравниваем текст в TextBox'е по центру
                this.Multiline = true;  // Включаем многострочную линию в TextBox'е
                this.BorderStyle = BorderStyle.None;    // Отключаем границы в TextBox'е
                this.Cursor = Cursors.Hand; // Крусор мыши в виде руки, при наведении на TextBox
                this.Margin = new Padding(0);   // Отключаем отступы от других элеметов
                this.ReadOnly = true;   // По-умолчанию режим только для чтения
                this.Font = new System.Drawing.Font("Arial", 8.5f, System.Drawing.FontStyle.Bold);  // Настраиваем шрифт TextBox'а по-умолчанию

                // /* ——— События у TextBox элемента ——— */
                this.MouseClick += TextBoxNameMesure_MouseClick;    // Событие одного клика — Выбор для просмотра списка сигналов
                this.MouseDoubleClick += TextBoxNameMesure_MouseDoubleClick; // Событие двойного клика по мышке
                this.LostFocus += TextBoxNameMesure_LostFocus;  // Событие покидания фокуса элемента, завершения режима изменения Имени

            }

            // Событие одного клика. Выбор элемента для показа списка сигналов
            private void TextBoxNameMesure_MouseClick(object sender, MouseEventArgs e)
            {
                this.ActiveOnChart = this.ActiveOnChart ? false : true;
            }

            // Покидание фокуса TextBox'а, отключение режима изменения имени
            private void TextBoxNameMesure_LostFocus(object sender, EventArgs e)
            {
                this.ReadOnly = true;
            }

            // Двойной клик по мышке — активация режима изменения имени
            private void TextBoxNameMesure_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.ReadOnly = false;
                }
            }
        }

        #endregion

    }




    // Класс кнопки с глазом для показа скрытия графика
    class ButtonEyeFlag : Button
    {
        private bool flagShow = false;
        // Показывает был ли нажата кнопка на элементе 
        public bool FlagShow { get => flagShow; set => flagShow = value; }


        /// <summary>
        /// Конструктор кнопки, с настройками по-умолчанию
        /// </summary>
        public ButtonEyeFlag()
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand; // Ставим курсор в виде руки
            this.Margin = new Padding(0);   // убераем отступы от граничных элементов
            this.FlatStyle = FlatStyle.Flat; // тип кнопки - Flat
            this.FlatAppearance.BorderSize = 0; // отключаем границы у кнопки
            this.Dock = DockStyle.Right; // выравниваем положение кнопки по левой стороне
            this.Click += ButtonFlagShow_Click; // Обработка события нажатия клавиши
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            if (this.FlagShow == true)
            {
                this.BackgroundImage = Resources.Hide_show; //  Добавляем глазик на кнопку
            }   //  По-умолчанию добавляем "глаз" на форму
            this.BackgroundImageLayout = ImageLayout.Stretch;   // Выравниваем изображение "глаза" по форме кнопки

        }


        /// <summary>
        /// Событие нажатия кнопки. В завивисимости от bool значения, будет изменено на обратное
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFlagShow_Click(object sender, EventArgs e)
        {
            flagShow = flagShow ? false : true; // Выставляем значение кнопки на противоположное
            this.BackgroundImage = FlagShow ? this.BackgroundImage = Resources.Hide_show : this.BackgroundImage = null; // Скрываем или показывем "глаз" в зависимости от значения
        }

    }

}
