using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberUpDownExample
{
    public class DataGridViewNumUpDownCell : DataGridViewTextBoxCell
    {
        public DataGridViewNumUpDownCell() : base()
        { }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue,
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            CeLearningNumUpDown ctl = DataGridView.EditingControl as CeLearningNumUpDown;

            if (this.Value == null)
            {
                ctl.Value = Convert.ToDouble(this.DefaultNewRowValue);
            }
            else
            {
                ctl.textbox.Text = this.Value.ToString();
            }
        }
        public override Type EditType
        {
            get { return typeof(NumUpDownEditingControl); }
        }

        public override Type ValueType
        {
            get { return typeof(string); }
        }

        public override object DefaultNewRowValue
        {
            get { return 0; }
        }
    }
}
