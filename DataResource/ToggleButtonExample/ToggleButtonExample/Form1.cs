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

            //ceLearningToggle1.OnText = "  "+ "\u2714";
        }
    }
}
