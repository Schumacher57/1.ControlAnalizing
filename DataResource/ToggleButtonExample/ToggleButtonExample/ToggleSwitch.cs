using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace ToggleButtonExample
{
    // Вспомогательный!
    public class ToggleSwitchEditingControl : ToggleSwitch, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public ToggleSwitchEditingControl() { }

        // Здесь как понимаю определяем значение по-умолчанию!
        public Object EditingControlFormattedValue
        {
            get
            {
                return this.IsOn;
            }
            set
            {
                if (value is string)
                {
                    try
                    {
                        this.IsOn = bool.Parse(value.ToString());
                    }
                    catch
                    {
                        this.IsOn = true;
                    }

                }
            }
        }

        // Тут как понимаю если было исключение в EditingControlFormattedValue (выше) то ставим значение по-умолчанию
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Тут как понимаю редактируем стили ячейки
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }

        // Свойство для индекса строки!
        public int EditingControlRowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }

        // Функция нажатия клавиши
        public bool EditingControlWantsInputKey(Keys key, bool datagridviewWantsInputKey)
        {
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !datagridviewWantsInputKey;
            }
        }

        // Тут ничего ненужно
        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }


        // Тут тоже ничего не трогаем
        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        // Устнанавлеваем полю какое-то значение
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set { dataGridView = value; }
        }

        // Определяем было ли измененю значение
        public bool EditingControlValueChanged
        {
            get { return valueChanged; }
            set { valueChanged = value; }
        }

        // Положение курсора
        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        // После того как занчили редактировать значение в ячейке!
        protected override void OnLeave(EventArgs e)
        {
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnLeave(e);
        }




    }


    // Попытка №2
    public class DataGridViewToggleSwitchColumn : DataGridViewColumn
    {
        public DataGridViewToggleSwitchColumn() : base(new ToggleSwitchCell())
        {

        }

        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(ToggleSwitchCell)))
                {
                    Debug.WriteLine("Тут косяк!");
                    //throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class ToggleSwitchCell : DataGridViewTextBoxCell
    {
        public ToggleSwitchCell() : base()
        {
            this.Style.Format = "true";
        }

        // Манипуляция со значениями!
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            ToggleSwitchEditingControl ctl = DataGridView.EditingControl as ToggleSwitchEditingControl;

            if (this.Value == null)
            {
                ctl.IsOn = (bool)this.DefaultNewRowValue;
            }
            else
            {
                ctl.IsOn = (bool)this.Value;
            }



        }

        // Соответсвие типу класса
        public override Type EditType
        {
            get
            {
                // Return the type of the editing control that CalendarCell uses.
                return typeof(ToggleSwitchEditingControl);
            }
        }

        // Возвращаемый тип логический
        public override Type ValueType
        {
            get { return typeof(ToggleSwitchEditingControl); }
        }

        // Значение добавленной ячейки по-умолчанию!
        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value.
                return true;
            }
        }



    }

    public class ToggleSwitch : CeLearningToggle
    {
        public ToggleSwitch() : base()
        {

            this.Size = new System.Drawing.Size(61, 30);
            this.Dock = DockStyle.Fill;
            this.OnColor = System.Drawing.Color.FromArgb(66, 252, 122);
            this.OffColor = System.Drawing.Color.Red;

        }

        // Перезаписываем метод нажатия кнопки на форму (для выставления цвета надписям)
        public override void paintTicker_Tick(object sender, EventArgs e)
        {
            base.paintTicker_Tick(sender, e); // Выполняем действия базового класса
            // меняем цвет ячейки
            if (this.IsOn == true)
            {
                this.ForeColor = System.Drawing.Color.DarkRed;
            }
            else
            {
                this.ForeColor = System.Drawing.Color.White;
            }
        }

    }
}
