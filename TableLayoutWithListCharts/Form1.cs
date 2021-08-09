using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using TableLayoutWithListCharts.LayOutWithListMeasure;
using System;

namespace TableLayoutWithListCharts
{
    public partial class Form1 : Form
    {
        Button myButton = new Button();

        List<MyControls.ListFormMesure> myControl = new List<TableLayoutWithListCharts.MyControls.ListFormMesure>();
        private int mouseScroll;

        private event EventHandler textBoxesClicked;

        public Form1()
        {

            InitializeComponent();


            //Button myButton = new Button();
            myButton.Text = "Что-то сделать";
            myButton.Dock = DockStyle.Fill;
            myButton.FlatStyle = FlatStyle.Flat;
            tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);

            tableLayoutPanel3.Controls.Add(new LayOutWithListMeasure.FormLayOutListMeasure().PanelWithButtons, 0, 1);

            //tableLayoutPanel3.Controls.Add(new LayOutWithListMeasure.FormLayOutListMeasure().LayOutControl, 0, 1);


            //crtColumnButton(dataGridView1);
            //addRowToTableLayout();
            //textBoxesClicked += Form1_textBoxesClicked;




        }

        private void Form1_textBoxesClicked(object sender, EventArgs e)
        {
            for (int i = 0; i < myControl.Count; i++)
            {
                myControl[i].ActiveOnChart = false;
            }
        }


        // Добавление TextBox'ов на панель
        private void addRowToTableLayout()
        {

            tableLayoutPanel2.RowStyles[0].SizeType = SizeType.Absolute;
            tableLayoutPanel2.RowStyles[0].Height = 20f;

            for (int i = 0; i < 30; i++)
            {
                tableLayoutPanel2.AutoScroll = true;

                tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                tableLayoutPanel2.Padding = new Padding(0, 0, 0, 0);
                tableLayoutPanel2.Margin = new Padding(0, 0, 0, 0);

                //tableLayoutPanel2.Controls.Add(new myTextBox($"Сиг №{i}"), 0, i);
                //tmpListFormMesure.TextBoxClicked += (s, e) => { Debug.WriteLine($"Нажал на TextBox №{i}"); };

                MyControls.ListFormMesure tmpListFormMesure = new MyControls.ListFormMesure($"Сиг. № {i}");
                myControl.Add(new MyControls.ListFormMesure($"Сиг. № {i}"));
                myControl[myControl.Count - 1].TextBoxClicked += (s, e) => { textBoxesClicked?.Invoke(this, e); };
                
                tableLayoutPanel2.Controls.Add(myControl[myControl.Count - 1], 0, i);
                tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
                tableLayoutPanel2.RowCount += 1;

            }

        }

        private void crtColumnButton(DataGridView gridViewSignal)
        {
            Button myTypeButton = new Button();
            myTypeButton.Dock = DockStyle.Top;
            myTypeButton.FlatStyle = FlatStyle.Flat;
            myTypeButton.Text = "Сигнал №1";
            myTypeButton.Click += (s, e) => { MessageBox.Show("Привет андрей"); };


            //myButCell.

            Button myBut1 = new Button();
            //this.Controls.Add(myTypeButton);
            //DataGridView

            // Мой пользовательские столбцы
            //DataGridViewButtonColumn myClmnButton = new DataGridViewButtonColumn();
            DataGridViewTextBoxColumn myClmnText = new DataGridViewTextBoxColumn();

            //myClmnText.FlatStyle = FlatStyle.Flat;
            gridViewSignal.Columns.Add(myClmnText);
            gridViewSignal.Rows.Add(new myTextBox("123").Text);
            gridViewSignal.Rows.Add(new myTextBox("321"));





        }

    }




    class myButton : Button
    {

        public myButton(string someText = "123")
        {
            this.Dock = DockStyle.Fill;
            this.FlatStyle = FlatStyle.Flat;
            this.Text = someText;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.FlatAppearance.BorderSize = 1;
            this.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.Margin = new Padding(0, 0, 0, 0);
            this.Padding = new Padding(0, 0, 0, 0);
        }
    }

    class myTextBox : TextBox
    {
        private bool flagChoice = false;
        private ContextMenuStrip textBoxContextMenu = new ContextMenuStrip();

        public bool FlagChoice { get => flagChoice; set => flagChoice = value; }
        public ContextMenuStrip TextBoxContextMenu { get => textBoxContextMenu; set => textBoxContextMenu = value; }

        public myTextBox(string someName)
        {


            textBoxContextMenu.Items.Add("Что-нибудь");


            this.Text = someName;

            this.TextAlign = HorizontalAlignment.Center;

            this.Dock = DockStyle.Fill;
            this.ReadOnly = true;
            this.BorderStyle = BorderStyle.None;
            this.Multiline = true;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.DoubleClick += MyTextBox_DoubleClick;
            this.Margin = new Padding(1, 2, 1, 2);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            // СОбытия для TextBox'ов
            this.MouseMove += (s, e) =>
            {
                if ((s as myTextBox).BackColor != System.Drawing.Color.DeepSkyBlue)
                    (s as myTextBox).BackColor = System.Drawing.Color.DeepSkyBlue;
            };
            this.MouseLeave += (s, e) => { if (!FlagChoice) (s as myTextBox).BackColor = System.Drawing.Color.FromArgb(240, 240, 240); };
            this.Click += (s, e) =>
            {
                refreshTableLayout(this.Parent as TableLayoutPanel);
                this.BackColor = System.Drawing.Color.DeepSkyBlue;
                this.FlagChoice = true;
                Debug.WriteLine((this.Parent as TableLayoutPanel).GetCellPosition(this).ToString());

                Debug.WriteLine($"Нажата listBox {this.Text}");
                //new ColorDialog().ShowDialog();
            };
            this.Leave += (s, a) => { this.ReadOnly = true; };
            this.ContextMenuStrip = textBoxContextMenu;
            this.MouseClick += MyTextBox_MouseClick;
            //RaiseMouseEvent(MouseWheel)
        }

        private void MyTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                textBoxContextMenu.Show(new Point(e.Location.X, e.Location.Y));
        }

        private void refreshTableLayout(TableLayoutPanel panelForRefresh)
        {
            TableLayoutControlCollection controls = panelForRefresh.Controls;
            for (int i = 0; i < controls.Count; i++)
            {
                controls[i].BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                (controls[i] as myTextBox).flagChoice = false;
            }
        }

        private void MyTextBox_DoubleClick(object sender, System.EventArgs e)
        {
            this.ReadOnly = false;
        }
    }
}
