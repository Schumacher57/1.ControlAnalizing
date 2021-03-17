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

            tableLayoutPanel1.Controls.Add(mySwitch, 0, 0);
            dataGridView1.DataError += (s, a) => { a.Cancel = false; };
            updateDataGridView(dataGridView1);

            button1.Click += (s, a) => { myEvenButClick(); };

            //ceLearningToggle1.OnText = "  "+ "\u2714";
        }

        // Попытка добавить мой пользовательский контрол в DataGridView
        private void updateDataGridView(DataGridView dataGrid)
        {
            var myColumn = new DataGridViewToggleSwitchColumn();
            var myButCol = new DataGridViewButtonColumn();

            myButCol.HeaderText = "Что-то";

            //myColumn.HeaderText
            myColumn.HeaderText = "Откл/вкл";
            //myColumn.HeaderText = "Заголовок";
            //myColumn
            //myColumn.
            myButCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            myColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;

            dataGrid.Columns.Add(myColumn);
            //dataGrid.Columns.Add(myButCol);
            dataGridView1.RowCount = 4;


        }

        private void myEvenButClick()
        {
            Debug.WriteLine(dataGridView1.CurrentCell.Value.ToString());
        }

    }
}
