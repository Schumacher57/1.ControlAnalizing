using ZedGraph;


namespace WorkWithChart.MyControl
{
    class myZedGraph : ZedGraph.ZedGraphControl
    {
        public myZedGraph()
        {
            this.Dock = System.Windows.Forms.DockStyle.Fill;

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "myZedGraph";
            this.ResumeLayout(false);

        }
    }
}
