using System;
using System.Windows.Forms;
using System.Diagnostics;
using TableLayoutWithListCharts.Properties;

namespace TableLayoutWithListCharts.MyControls
{


    public partial class ListFormMesure : UserControl
    {
        // Основные свойства элемента для работы с графиками на форме
        private string nameMeasure = string.Empty;
        private bool showOnChart = false;
        private bool activeOnChart = false;
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

        //private mouseClick delegateMouseClickButton;
        public event EventHandler TextBoxClicked;

        // Конструктор
        public ListFormMesure(string inputName)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.BorderStyle = BorderStyle.None;
            this.Margin = new Padding(1, 1, 1, 1);
            this.Padding = new Padding(1, 1, 1, 1);
            this.nameMeasure = inputName;


            tmpTextBoxMeasure.Text = inputName;
            tmpTextBoxMeasure.Click += (s, e) =>
            {
                TextBoxClicked?.Invoke(this, e);
                // this.ActiveOnChart = ((TextBoxNameMesure)s).ActiveOnChart;
            };

            this.Controls.Add(tmpTextBoxMeasure);
            activeOnChart = tmpTextBoxMeasure.ActiveOnChart;
            this.Controls.Add(new ButtonFlagShow());
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
                if (someCont is ButtonFlagShow)
                {

                    someCont.Width = (int)(this.Width * 0.1);
                }
                if (someCont is TextBoxNameMesure)
                {
                    someCont.Width = (int)(this.Width * 0.9) - 5;
                }
            }
        }

    }

    // Класс TextBox'а с моим фнукционалом
    class TextBoxNameMesure : TextBox
    {
        string nameMeasure = string.Empty;
        //public string NameMeasure { get => nameMeasure; set => nameMeasure = value; }
        public bool ActiveOnChart
        {
            get => activeOnChart;
            set
            {
                activeOnChart = value;
                this.BackColor = this.ActiveOnChart ? System.Drawing.Color.DeepSkyBlue : this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            }
        }

        private bool activeOnChart = false;

        public TextBoxNameMesure()
        {


            this.Dock = DockStyle.Left;
            this.TextAlign = HorizontalAlignment.Center;
            this.Multiline = true;
            this.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Hand;
            this.Margin = new Padding(0);
            this.ReadOnly = true;
            this.Font = new System.Drawing.Font("Arial", 8.5f, System.Drawing.FontStyle.Bold);
            // MouseClickButton += TextBoxNameMesure_MouseClick;
            // MouseClickButton += TextBoxNameMesure_MouseClick;

            this.MouseClick += TextBoxNameMesure_MouseClick;
            this.MouseDoubleClick += TextBoxNameMesure_MouseDoubleClick; // Событие двойного клика по мышке
            this.LostFocus += TextBoxNameMesure_LostFocus;  // Событие покдания фокуса элемента


        }

        // Событие нажати мышкой на название
        private void TextBoxNameMesure_MouseClick(object sender, MouseEventArgs e)
        {
            this.ActiveOnChart = this.ActiveOnChart ? false : true;
        }

        // Когда пакидаем фокус, то элемент снова только для чтения
        private void TextBoxNameMesure_LostFocus(object sender, EventArgs e)
        {
            this.ReadOnly = true;
        }

        // Дабл клик по мышульке
        private void TextBoxNameMesure_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.ReadOnly = false;
            }
        }
    }

    // Класс кнопки с галзом для показа скрытия графиков
    class ButtonFlagShow : Button
    {
        private bool flagShow = false;
        // Показывает был ли нажата кнопка на элементе 
        public bool FlagShow { get => flagShow; set => flagShow = value; }

        // Конструктор кнопки нажатия клавиши
        public ButtonFlagShow()
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
            }
            this.BackgroundImageLayout = ImageLayout.Stretch;

        }

        // Событие нажатия кнопки
        private void ButtonFlagShow_Click(object sender, EventArgs e)
        {
            flagShow = flagShow ? false : true;
            this.BackgroundImage = FlagShow ? this.BackgroundImage = Resources.Hide_show : this.BackgroundImage = null;
        }

    }

}
