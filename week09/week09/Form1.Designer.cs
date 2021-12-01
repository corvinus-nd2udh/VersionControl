
namespace week09
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
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownCloseDate = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCsvPath = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCloseDate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Záróév: ";
            // 
            // numericUpDownCloseDate
            // 
            this.numericUpDownCloseDate.Location = new System.Drawing.Point(66, 16);
            this.numericUpDownCloseDate.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.numericUpDownCloseDate.Minimum = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            this.numericUpDownCloseDate.Name = "numericUpDownCloseDate";
            this.numericUpDownCloseDate.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownCloseDate.TabIndex = 1;
            this.numericUpDownCloseDate.Value = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Népesség fájl:";
            // 
            // textBoxCsvPath
            // 
            this.textBoxCsvPath.Location = new System.Drawing.Point(270, 15);
            this.textBoxCsvPath.Name = "textBoxCsvPath";
            this.textBoxCsvPath.Size = new System.Drawing.Size(304, 20);
            this.textBoxCsvPath.TabIndex = 3;
            this.textBoxCsvPath.Text = "C:\\Temp\\nép.csv";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(580, 13);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(101, 23);
            this.buttonBrowse.TabIndex = 4;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(687, 13);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(101, 23);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 47);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(776, 391);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxCsvPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownCloseDate);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCloseDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownCloseDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCsvPath;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

