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
        private int widthButtonTool = 16;
        private int heightButtonTool = 18;


        // Метод добавления змерения шума или сигнала в список
        private void addMeasure()
        {
            measureListControls.Add(new MyControls.ListFormMesure($"Изм. №{measureListControls.Count.ToString()}"));


            // Удаляем все строки.
            for (int i = layOutControl.RowCount; i > 0; i--)
            {
                layOutControl.Controls.Clear();
                layOutControl.RowStyles.Clear();
                layOutControl.RowCount--;
            }

            layOutControl.RowCount += 2;

            // Добавляем строки
            for (int i = 0; i <= measureListControls.Count - 1; i++)
            {

                layOutControl.RowCount++;
                layOutControl.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
                layOutControl.Controls.Add(measureListControls[i], 0, layOutControl.RowCount - 2);

            }
        }

        // Метод удаления измерения из списка измерений
        private void delMeasure()
        {

            if (measureListControls.Count > 0)
            {
                Debug.WriteLine("Сработало удаление");
                measureListControls.RemoveAt(0);
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

        // Конструктор класс с отображением элементов
        public FormLayOutListMeasure()
        {
            layOutControl = new TableLayoutPanel();
            measureListControls = new List<MyControls.ListFormMesure>();
            layoutConfiguration(); // Настраиваем по-умолчание LayOut панель
            toolStripConfiguration();   // Настраиваем toolStrip панель с кнопками

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
            layOutControl.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f)); // Присваиваем высоту по умолчанию
            layOutControl.AutoScroll = true; // Включаем Scroll
            layOutControl.DisableHorizontalScrollBar(); // Отключаем горизонтальный скролл с помощью метода расширения
            //layOutControl.
                
        }

        // Создаём панель (для родительского TableLayOut'а)
        private void panelWithButtonsConfiguration()
        {
            PanelWithButtons.Height = 19; // Ставим высоту панели с кнопками
            PanelWithButtons.BorderStyle = BorderStyle.None; // Убираем границу для панели
            PanelWithButtons.Padding = new Padding(0); // Убираем отступы для панели
            PanelWithButtons.Margin = new Padding(0); // Убираем отступы для панели
            PanelWithButtons.Dock = DockStyle.Fill; // Заливаем панель во всю строку родительской TableLayOut панели
        }

        // Метод настройки по-умолчание toolStrip панели с кнопками (добавить, удалить, сохранить)
        private void toolStripConfiguration()
        {
            toolStripButtons = new ToolStrip(); // Создаём экземпляр ToolStrip'а
            toolStripButtons.Dock = DockStyle.Top; // Закрепляем кнопки сверху
            toolStripButtons.GripStyle = ToolStripGripStyle.Hidden; // Убираем справа полоску для возможности перетаскивания панели
            toolStripButtons.RenderMode = ToolStripRenderMode.System; // Устанавливаем внешний вид панели
            toolStripButtons.AutoSize = false; // Отключаем возможность автоматического выставления высоты строк
            toolStripButtons.Padding = new Padding(0); // Отключаем отступы в панели
            toolStripButtons.Margin = new Padding(0); // Отключаем отступы в панели
            /*toolStripButtons.AutoSize = true;
            toolStripButtons.CanOverflow = true;*/


            // /* Конфигурируем и добавляем кнопки на toolStrip*/
            configComboSigNoise(); // Настраиваем ComboBox выбора Сигнала / Шума
            buttonAddMeasure = crtButton(Resources.AddMeasure); // Создаём кнопку добавления измерения
            buttonDelMeasure = crtButton(Resources.DelMeasure); // Создаём кнопку удаления измерения
            buttonChartFilterMeasure = crtButton(Resources.ChartFilter4); // Создаём кнопку фильтра
            buttonLookMeasure = crtButton(Resources.LookData2); // Создаём кнопку просмотра измерения
            buttonSelectMeasure = crtButton(Resources.selectMeasure); // Создаём кнопку выбора
            buttonSaveMeasure = crtButton(Resources.SaveMeasure); // Создаём кнопку Сохранения измерений

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
            /*toolStripButtons.Items.Add(new ToolStripSeparator());
            toolStripButtons.Items.Add(buttonSaveMeasure);*/

            buttonAddMeasure.Click += (s, e) => { addMeasure(); };
            buttonDelMeasure.Click += (s, e) => { delMeasure(); };
            
            // Метод настройки CoboBox'а с выбором сигнала/шума
            void configComboSigNoise()
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
            
            // Метод создания кнопки на панели ToolStrip
            ToolStripButton crtButton(System.Drawing.Image resourceImg)
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

        }

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