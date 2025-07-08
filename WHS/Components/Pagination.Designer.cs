namespace WHS.Components
{
    partial class Pagination
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel3 = new Panel();
            pageNumeric = new NumericUpDown();
            totalPageLabel = new Label();
            label3 = new Label();
            label2 = new Label();
            nextBtn = new Button();
            prevBtn = new Button();
            panel1 = new Panel();
            recordLabel = new Label();
            label1 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pageNumeric).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.AutoSize = true;
            panel3.BackColor = Color.WhiteSmoke;
            panel3.Controls.Add(pageNumeric);
            panel3.Controls.Add(totalPageLabel);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(468, 0);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(186, 46);
            panel3.TabIndex = 7;
            // 
            // pageNumeric
            // 
            pageNumeric.AutoSize = true;
            pageNumeric.BackColor = Color.WhiteSmoke;
            pageNumeric.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pageNumeric.Location = new Point(71, 4);
            pageNumeric.Margin = new Padding(3, 4, 3, 4);
            pageNumeric.Name = "pageNumeric";
            pageNumeric.Size = new Size(70, 38);
            pageNumeric.TabIndex = 8;
            pageNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // totalPageLabel
            // 
            totalPageLabel.AutoSize = true;
            totalPageLabel.BackColor = Color.WhiteSmoke;
            totalPageLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            totalPageLabel.Location = new Point(157, 5);
            totalPageLabel.Name = "totalPageLabel";
            totalPageLabel.Size = new Size(26, 31);
            totalPageLabel.TabIndex = 7;
            totalPageLabel.Text = "1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.WhiteSmoke;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(140, 5);
            label3.Name = "label3";
            label3.Size = new Size(23, 31);
            label3.TabIndex = 6;
            label3.Text = "/";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.WhiteSmoke;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 5);
            label2.Name = "label2";
            label2.Size = new Size(71, 31);
            label2.TabIndex = 5;
            label2.Text = "Trang";
            // 
            // nextBtn
            // 
            nextBtn.BackColor = Color.DodgerBlue;
            nextBtn.BackgroundImage = Properties.Resources.arrow_right;
            nextBtn.BackgroundImageLayout = ImageLayout.Zoom;
            nextBtn.Dock = DockStyle.Right;
            nextBtn.FlatStyle = FlatStyle.Flat;
            nextBtn.ForeColor = Color.Transparent;
            nextBtn.Location = new Point(417, 0);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(51, 46);
            nextBtn.TabIndex = 8;
            nextBtn.UseVisualStyleBackColor = false;
            // 
            // prevBtn
            // 
            prevBtn.BackColor = Color.DodgerBlue;
            prevBtn.BackgroundImage = Properties.Resources.arrow_left;
            prevBtn.BackgroundImageLayout = ImageLayout.Zoom;
            prevBtn.Dock = DockStyle.Right;
            prevBtn.FlatStyle = FlatStyle.Flat;
            prevBtn.ForeColor = Color.Transparent;
            prevBtn.Location = new Point(366, 0);
            prevBtn.Name = "prevBtn";
            prevBtn.Size = new Size(51, 46);
            prevBtn.TabIndex = 9;
            prevBtn.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(recordLabel);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(102, 46);
            panel1.TabIndex = 10;
            // 
            // recordLabel
            // 
            recordLabel.AutoSize = true;
            recordLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            recordLabel.Location = new Point(73, 9);
            recordLabel.Name = "recordLabel";
            recordLabel.Size = new Size(26, 31);
            recordLabel.TabIndex = 1;
            recordLabel.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(2, 9);
            label1.Name = "label1";
            label1.Size = new Size(75, 31);
            label1.TabIndex = 0;
            label1.Text = "Tổng:";
            // 
            // Pagination
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(prevBtn);
            Controls.Add(nextBtn);
            Controls.Add(panel3);
            Name = "Pagination";
            Size = new Size(654, 46);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pageNumeric).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private NumericUpDown pageNumeric;
        private Label totalPageLabel;
        private Label label3;
        private Label label2;
        private Button nextBtn;
        private Button prevBtn;
        private Panel panel1;
        private Label recordLabel;
        private Label label1;
    }
}
