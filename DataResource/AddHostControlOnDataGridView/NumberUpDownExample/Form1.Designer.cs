namespace NumberUpDownExample
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new NumberUpDownExample.DataGridViewNumUpDownColumn();
            this.ceLearningNumUpDown1 = new NumberUpDownExample.CeLearningNumUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(79, 152);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.Size = new System.Drawing.Size(420, 236);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // ceLearningNumUpDown1
            // 
            this.ceLearningNumUpDown1.BackColor = System.Drawing.SystemColors.Info;
            this.ceLearningNumUpDown1.BtnUpDownWidth = 50;
            this.ceLearningNumUpDown1.ButtonColor = System.Drawing.Color.Maroon;
            this.ceLearningNumUpDown1.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.ceLearningNumUpDown1.Location = new System.Drawing.Point(161, 12);
            this.ceLearningNumUpDown1.Name = "ceLearningNumUpDown1";
            this.ceLearningNumUpDown1.Size = new System.Drawing.Size(183, 43);
            this.ceLearningNumUpDown1.TabIndex = 0;
            this.ceLearningNumUpDown1.Text = "ceLearningNumUpDown1";
            this.ceLearningNumUpDown1.Value = 0D;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 418);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ceLearningNumUpDown1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CeLearningNumUpDown ceLearningNumUpDown1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataGridViewNumUpDownColumn Column1;
    }
}

