using System.Diagnostics;
using System.Windows.Forms;

namespace ToggleButtonExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ceLearningToggle1.Click += (s, a) => { Debug.WriteLine($"Значение элемента toggleSwitch: {(s as CeLearningToggle).IsOn.ToString()}"); };

            var mySwitch = new ToggleSwitch();

            //mySwitch.Size = new System.Drawing.Size(61, mySwitch.Height);
            //mySwitch.Dock = DockStyle.Fill;
            //mySwitch.OnColor = System.Drawing.Color.Green;
            //mySwitch.OffColor = System.Drawing.Color.Red;

            tableLayoutPanel1.Controls.Add(mySwitch, 0, 0);
            dataGridView1.DataError += (s, a) => { a.Cancel = false; };
            updateDataGridView(dataGridView1);

            //ceLearningToggle1.OnText = "  "+ "\u2714";
        }


        private void updateDataGridView(DataGridView dataGrid)
        {
            var myColumn = new DataGridViewToggleSwitchColumn();
            //myColumn.HeaderText = "Заголовок";
            //myColumn
            //myColumn.


            dataGrid.Columns.Add(myColumn);
            dataGridView1.RowCount = 4;


        }

    }
}
