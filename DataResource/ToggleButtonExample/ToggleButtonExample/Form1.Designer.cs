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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // ceLearningToggle1
            // 
            this.ceLearningToggle1.BorderColor = System.Drawing.Color.LightGray;
            this.ceLearningToggle1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ceLearningToggle1.ForeColor = System.Drawing.Color.White;
            this.ceLearningToggle1.IsOn = true;
            this.ceLearningToggle1.Location = new System.Drawing.Point(191, 104);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(178, 278);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(100, 69);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 456);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ceLearningToggle1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CeLearningToggle ceLearningToggle1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

