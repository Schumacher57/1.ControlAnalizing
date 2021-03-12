using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberUpDownExample
{
    public class DataGridViewNumUpDownColumn : DataGridViewColumn
    {
        //DataGridViewNumUpDownCell this class i will generate later
        public DataGridViewNumUpDownColumn() : base(new DataGridViewNumUpDownCell())
        { }
        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                //Ensure that the cell used for the template is a NumericUpDown
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewNumUpDownCell)))
                {
                    throw new InvalidCastException("Must be a string");
                }
                base.CellTemplate = value;
            }
        }
    }
}
