using System.Windows.Forms;
using System.Drawing;
using TableLayoutWithListCharts.Properties;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System;

namespace TableLayoutWithListCharts.LayOutWithListMeasure
{
    class FormLayOutListMeasure
    {
        private TableLayoutPanel layOutControl;
        public TableLayoutPanel LayOutControl { get => layOutControl; }
        public Panel PanelWithButtons { get => panelWithButtons; }

        private Panel panelWithButtons = new Panel();

        // Коллекция кнопок по управлению измерениями
        private List<MyControls.ListFormMesure> measureListControls;

        // Отрисовка ToolStrip меню
        private ToolStrip toolStripButtons;
        private ToolStripButton buttonAddMeasure;
        private ToolStripButton buttonDelMeasure;
        private ToolStripButton buttonChartFilterMeasure;
        private ToolStripButton buttonLookMeasure;
        private ToolStripButton buttonSelectMeasure;
        private ToolStripButton buttonSaveMeasure;
        private ToolStripComboBox comboSigNoise;
        private ToolStripSeparator toolSeparator;
        private int widthButtonTool = 16;
        private int heightButtonTool = 18;




        // Конструктор класс с отображением элементов
        public FormLayOutListMeasure()
        {
            layOutControl = new TableLayoutPanel();
            measureListControls = new List<MyControls.ListFormMesure>();
            layoutConfiguration(); // Настраиваем по-умолчание LayOut панель
            toolStripConfiguration();   // Настраиваем toolStrip панель с кнопками
            //layOutControl.Controls.Add(toolStripButtons); // Добавляем панель ToolStrip панель на LayOut панель
            panelWithButtonsConfiguration();
            PanelWithButtons.Controls.Add(toolStripButtons); // Добавляем панель ToolStrip панель на LayOut панель
            panelWithButtons.Controls.Add(layOutControl);

        }

        // Метод настройки по-умолчанию LayOut панели
        private void layoutConfiguration()
        {
            layOutControl = new TableLayoutPanel(); // Создаём экземпляр LayOut панели

            // layOutControl.BackColor = Color.Red; // временно.
            layOutControl.Dock = DockStyle.Fill; // Делаем заполнение панели во "всю"
            layOutControl.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single; // Убираем гранцы
            layOutControl.Padding = new Padding(0, 5, 0, 0); // Убираем отступы внутри ячейки
            layOutControl.Margin = new Padding(0, 5, 0, 0); // Убираем отступы внутри ячейки
            layOutControl.RowCount++; // Добавляем строку для кнопок (добавить, удалить, сохранить список)
            layOutControl.RowStyles.Add(new RowStyle(SizeType.Absolute, 19f)); // Присваиваем высоту по умолчанию
            layOutControl.AutoScroll = true;
            layOutControl.DisableHorizontalScrollBar();

            /* добавляем ешё одну строку, пока для "красивого" отображения в режиме теста */
            layOutControl.RowCount++; // Добавляем строку для кнопок (добавить, удалить, сохранить список)
            layOutControl.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f)); // Присваиваем высоту по умолчанию


        }



        private void panelWithButtonsConfiguration()
        {
            PanelWithButtons.Height = 19;
            PanelWithButtons.BorderStyle = BorderStyle.None;
            PanelWithButtons.Padding = new Padding(0);
            PanelWithButtons.Margin = new Padding(0);
            PanelWithButtons.Dock = DockStyle.Fill;

        }

        // Метод добавления змерения шума или сигнала в список
        private void addMeasure()
        {
            measureListControls.Add(new MyControls.ListFormMesure($"Изм. №{measureListControls.Count.ToString()}"));

            for (int i = layOutControl.RowCount; i > 2; i--)
            {
                layOutControl.RowCount--;
            }
            for (int i = 0; i <= measureListControls.Count - 1; i++)
            {
                layOutControl.RowCount++;
                layOutControl.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
                layOutControl.Controls.Add(measureListControls[i], 0, layOutControl.RowCount - 2);
                //Debug.WriteLine($"LayOut hVisible: { layOutControl.VerticalScroll.Visible.ToString()}");

            }
        }

        //Удаление измерения
        private void delMeasure()
        {
            
            if (measureListControls.Count > 0)
            {
                Debug.WriteLine("Сработало удаление");
                measureListControls.RemoveAt(0);
                //layOutControl.RowCount--;
                //layOutControl.RowStyles[layOutControl.RowCount] = new RowStyle(SizeType.Absolute, 20f);
            }
            for (int i = layOutControl.RowCount; i > 2; i--)
            {
                layOutControl.Controls.Clear();
                layOutControl.RowStyles.Clear();
                layOutControl.RowCount--;
            }
            for (int i = 0; i <= measureListControls.Count - 1; i++)
            {
                layOutControl.RowCount++;
                layOutControl.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
                layOutControl.Controls.Add(measureListControls[i], 0, layOutControl.RowCount - 2);
                //layOutControl.RowCount++;

            }
        }

        // Метод настройки по-умолчание toolStrip панели с кнопками (добавить, удалить, сохранить)
        private void toolStripConfiguration()
        {
            toolStripButtons = new ToolStrip();
            toolStripButtons.Dock = DockStyle.Top;
            toolStripButtons.GripStyle = ToolStripGripStyle.Hidden;
            toolStripButtons.RenderMode = ToolStripRenderMode.System;
            toolStripButtons.AutoSize = false;
            toolStripButtons.Padding = new Padding(0);
            toolStripButtons.Margin = new Padding(0);

            /* Конфигурируем и добавляем кнопки на toolStrip*/
            configurationButtonAddMeasure();
            configComboSigNoise();
            configurationToolSeparator();

            buttonDelMeasure = crtButton(Resources.DelMeasure);
            buttonChartFilterMeasure = crtButton(Resources.ChartFilter4);
            buttonLookMeasure = crtButton(Resources.LookData2);
            buttonSelectMeasure = crtButton(Resources.selectMeasure); // Добавляем кнопку с помощью метода
            buttonSaveMeasure = crtButton(Resources.SaveMeasure);

            toolStripButtons.Items.Add(buttonSelectMeasure);
            toolStripButtons.Items.Add(new ToolStripSeparator());
            toolStripButtons.Items.Add(buttonAddMeasure);
            toolStripButtons.Items.Add(new ToolStripSeparator());
            toolStripButtons.Items.Add(buttonDelMeasure);
            toolStripButtons.Items.Add(new ToolStripSeparator());
            toolStripButtons.Items.Add(comboSigNoise);
            toolStripButtons.Items.Add(new ToolStripSeparator());
            toolStripButtons.Items.Add(buttonChartFilterMeasure);
            toolStripButtons.Items.Add(new ToolStripSeparator());
            toolStripButtons.Items.Add(buttonLookMeasure);

            buttonAddMeasure.Click += (s, e) => { addMeasure(); };
            buttonDelMeasure.Click += (s, e) => { delMeasure(); };



        }

        // Метод найтроки собственного разделителя в ToolsStrip
        private void configurationToolSeparator()
        {
            toolSeparator = new ToolStripSeparator();
            //toolSeparator.AutoSize = true;
            toolSeparator.Margin = new Padding(0, 0, 0, 0);
            toolSeparator.Padding = new Padding(0, 0, 0, 0);
            toolSeparator.BackColor = Color.Black;
            toolSeparator.Dock = DockStyle.Fill;
            toolSeparator.ForeColor = Color.Black;

            toolSeparator.Height = 25;

        }

        // Метод настройки кнопки для добавления измерения
        private void configurationButtonAddMeasure()
        {
            buttonAddMeasure = new ToolStripButton();
            buttonAddMeasure.AutoSize = false;
            buttonAddMeasure.Padding = new Padding(0);
            buttonAddMeasure.Margin = new Padding(0);
            buttonAddMeasure.Dock = DockStyle.Fill;
            buttonAddMeasure.Height = heightButtonTool;
            //buttonAddMeasure.Height = 10;

            buttonAddMeasure.Width = widthButtonTool;
            buttonAddMeasure.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonAddMeasure.BackgroundImage = Resources.AddMeasure;
            buttonAddMeasure.BackgroundImageLayout = ImageLayout.Stretch;
        }

        //Метод создания кнопки
        private ToolStripButton crtButton(System.Drawing.Image resourceImg)
        {
            ToolStripButton tmpButton = new ToolStripButton();
            tmpButton.AutoSize = false;
            tmpButton.Padding = new Padding(0);
            tmpButton.Margin = new Padding(0);
            tmpButton.Dock = DockStyle.Fill;
            tmpButton.Height = heightButtonTool;
            tmpButton.Width = widthButtonTool;
            tmpButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tmpButton.BackgroundImage = resourceImg;
            tmpButton.BackgroundImageLayout = ImageLayout.Stretch;
            return tmpButton;
        }

        // Метод настройки CoboBox'а с выбором сигнала/шума
        private void configComboSigNoise()
        {
            comboSigNoise = new ToolStripComboBox();
            comboSigNoise.AutoSize = false;
            //comboSigNoise.Dock = DockStyle.Fill;
            comboSigNoise.Items.Add("Сигнал");
            comboSigNoise.Items.Add("Шум");
            comboSigNoise.SelectedIndex = 0;
            comboSigNoise.Padding = new Padding(0);
            comboSigNoise.FlatStyle = FlatStyle.Flat;
            comboSigNoise.Margin = new Padding(0);
            comboSigNoise.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSigNoise.Width = 63;
            comboSigNoise.Height = heightButtonTool;
            /*comboSigNoise.MouseHover += (s, e) => { ((ToolStripComboBox)s).BackColor = Color.LightSkyBlue; };
            comboSigNoise.MouseLeave += (s, e) => { ((ToolStripComboBox)s).BackColor = Color.White; };*/
        }


    }





}

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