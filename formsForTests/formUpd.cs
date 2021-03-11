using System.Windows.Forms;
using System.Diagnostics;

namespace formsForTests
{
    class formUpd
    {
        static public DataGridView myData;


        static public TableLayoutPanel myLayoutPanel;

        static public void myLayoutUpd()
        {
            myBestButton mySuperButton1 = new myBestButton();
            myBestButton mySuperButton2 = new myBestButton();

            TableLayoutPanelCellPosition myCell = new TableLayoutPanelCellPosition(0, 0);


            myLayoutPanel.Controls.Add(mySuperButton1, 0, 0);
            myLayoutPanel.Controls.Add(mySuperButton2, 1, 0);

            myLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;

        }


        static public void myGridUpd()
        {
            myButtonDataGrid mySomeButton = new myButtonDataGrid();
            DataGridTextBoxColumn myColumn = new DataGridTextBoxColumn();
            DataGridViewButtonCell myColumnButton = new DataGridViewButtonCell();

            myBestButton curBestButton = new myBestButton();

            //mySomeButton.CellType = "123";

            //myColumnButton.Text = "Блаблаб";
            myColumnButton.UseColumnTextForButtonValue = true;
            myData.ColumnCount = 3;
            myData.RowCount = 3;
            myData.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(207, 239, 252);
            myData.GridColor = System.Drawing.Color.FromArgb(207, 239, 252);
            myData.BorderStyle = BorderStyle.Fixed3D;
            //myData.BorderStyle = 
            myColumnButton.FlatStyle = FlatStyle.Flat;
            myData.Controls.Add(curBestButton);
            curBestButton.Location = myData.GetCellDisplayRectangle(0, 0, true).Location;
            curBestButton.Size = myData.GetCellDisplayRectangle(0, 0, true).Size;
            myData[0, 0] = myColumnButton;

            myData[0, 1].Value = "Тут какой-то элемент";

            myData[1, 1].Value = mySomeButton;

            Debug.WriteLine("Обновили");
            myData.Refresh();



        }


    }


    class myBestButton : Button
    {
        public myBestButton()
        {
            this.Dock = DockStyle.Fill;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Text = "123";
            this.BackColor = System.Drawing.Color.FromArgb(192, 241, 255);
        }
    }

    class myButtonDataGrid : DataGridViewColumn, IDataGridViewEditingControl
    {
        //class someButton : Button
        //{ 
        //    public someButton()
        //    {
        //        this.Text = "123";
        //    }
        //}



        public DataGridView EditingControlDataGridView { get; set; }
        public Cursor EditingPanelCursor { get; set; }
        public int EditingControlRowIndex { get; set; }
        public bool EditingControlValueChanged { get; set; }
        public object EditingControlFormattedValue { get; set; }
        public bool RepositionEditingControlOnValueChange { get; set; }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts someError)
        {
            return null;
        }

        public void PrepareEditingControlForEdit(bool myBool)
        {

        }

        public bool EditingControlWantsInputKey(Keys myKey, bool MyBool)
        {
            return true;
        }


        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle myCellStyle)
        {

        }

        public string Name { get; set; }
        public void someMove()
        {

        }

        //public myButton()
        //{
        //    this.Text = "Кнопка 1";d
        //    this.BackColor = System.Drawing.Color.Red;
        //}
    }

    public interface IMySomeInterface
    {
        string Name { get; set; }
        void someMove();


    }



}
