using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ToggleButtonExample
{
    class ToggleSwitch : CeLearningToggle
    {
        public ToggleSwitch()
        {
            this.Size = new System.Drawing.Size(61, 30);
            this.Dock = DockStyle.Fill;
            this.OnColor = System.Drawing.Color.FromArgb(66, 252, 122);
            this.OffColor = System.Drawing.Color.Red;

        }

        // Перезаписываем метод нажатия кнопки на форму
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
