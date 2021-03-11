namespace ToggleButtonExample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ceLearningToggle1 = new ToggleButtonExample.CeLearningToggle();
            this.SuspendLayout();
            // 
            // ceLearningToggle1
            // 
            this.ceLearningToggle1.BorderColor = System.Drawing.Color.LightGray;
            this.ceLearningToggle1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ceLearningToggle1.ForeColor = System.Drawing.Color.White;
            this.ceLearningToggle1.IsOn = true;
            this.ceLearningToggle1.Location = new System.Drawing.Point(142, 203);
            this.ceLearningToggle1.Name = "ceLearningToggle1";
            this.ceLearningToggle1.OffColor = System.Drawing.Color.DarkRed;
            this.ceLearningToggle1.OffText = "Off";
            this.ceLearningToggle1.OnColor = System.Drawing.Color.SpringGreen;
            this.ceLearningToggle1.OnText = "On";
            this.ceLearningToggle1.Size = new System.Drawing.Size(178, 91);
            this.ceLearningToggle1.TabIndex = 0;
            this.ceLearningToggle1.Text = "ceLearningToggle1";
            this.ceLearningToggle1.TextEnabled = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 456);
            this.Controls.Add(this.ceLearningToggle1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CeLearningToggle ceLearningToggle1;
    }
}

