using System.Windows.Forms;

namespace formsForTests.TestClass
{
    class SomeClassWithControls
    {
        public TableLayoutPanel TestLayOutPanel;
        public bool isVisible { get => TestLayOutPanel.Visible; set => TestLayOutPanel.Visible = value; }

    }


    class TestDataWithTableLayOut
    {
        public TableLayoutPanel MainLayOutPanel;

        public TestDataWithTableLayOut ()
        {
            MainLayOutPanel = new TableLayoutPanel();
            MainLayOutPanel.BackColor = System.Drawing.Color.Red;
            MainLayOutPanel.Dock = DockStyle.Right;

        }
    
    }

}
