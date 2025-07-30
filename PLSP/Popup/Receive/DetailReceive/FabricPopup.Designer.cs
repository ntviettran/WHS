namespace WHS.Popup
{
    partial class FabricPopup
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FabricPopup));
            panel2 = new Panel();
            panel14 = new Panel();
            gridView = new DataGridView();
            panel3 = new Panel();
            cancelBtn = new Button();
            saveBtn = new Button();
            panel1 = new Panel();
            sampleFileBtn = new Button();
            addBtn = new Button();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)_dataTable).BeginInit();
            panel2.SuspendLayout();
            panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(panel14);
            panel2.Controls.Add(label8);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(20, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(1067, 699);
            panel2.TabIndex = 2;
            // 
            // panel14
            // 
            panel14.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel14.Controls.Add(gridView);
            panel14.Controls.Add(panel3);
            panel14.Controls.Add(panel1);
            panel14.Location = new Point(0, 0);
            panel14.Name = "panel14";
            panel14.Size = new Size(1067, 696);
            panel14.TabIndex = 2;
            // 
            // gridView
            // 
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;
            gridView.AllowUserToResizeRows = false;
            gridView.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(0, 10, 0, 10);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridView.DefaultCellStyle = dataGridViewCellStyle2;
            gridView.Dock = DockStyle.Fill;
            gridView.EnableHeadersVisualStyles = false;
            gridView.Location = new Point(0, 63);
            gridView.Name = "gridView";
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            gridView.RowTemplate.Height = 35;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.Size = new Size(1067, 563);
            gridView.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.Controls.Add(cancelBtn);
            panel3.Controls.Add(saveBtn);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 626);
            panel3.Name = "panel3";
            panel3.Size = new Size(1067, 70);
            panel3.TabIndex = 19;
            // 
            // cancelBtn
            // 
            cancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelBtn.BackColor = Color.Red;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelBtn.ForeColor = Color.White;
            cancelBtn.Location = new Point(834, 25);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 45);
            cancelBtn.TabIndex = 16;
            cancelBtn.Text = "Hủy";
            cancelBtn.UseVisualStyleBackColor = false;
            // 
            // saveBtn
            // 
            saveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveBtn.BackColor = Color.FromArgb(0, 46, 92);
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            saveBtn.ForeColor = Color.White;
            saveBtn.Location = new Point(934, 25);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(130, 45);
            saveBtn.TabIndex = 15;
            saveBtn.Text = "Xác nhận";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(sampleFileBtn);
            panel1.Controls.Add(addBtn);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1067, 63);
            panel1.TabIndex = 18;
            // 
            // sampleFileBtn
            // 
            sampleFileBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sampleFileBtn.BackColor = Color.CornflowerBlue;
            sampleFileBtn.FlatStyle = FlatStyle.Flat;
            sampleFileBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sampleFileBtn.ForeColor = Color.White;
            sampleFileBtn.Location = new Point(835, 3);
            sampleFileBtn.Name = "sampleFileBtn";
            sampleFileBtn.Size = new Size(117, 45);
            sampleFileBtn.TabIndex = 17;
            sampleFileBtn.Text = "File mẫu";
            sampleFileBtn.UseVisualStyleBackColor = false;
            // 
            // addBtn
            // 
            addBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addBtn.BackColor = Color.FromArgb(0, 46, 92);
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(958, 3);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(106, 45);
            addBtn.TabIndex = 7;
            addBtn.Text = "Thêm";
            addBtn.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(498, 318);
            label8.Name = "label8";
            label8.Size = new Size(0, 20);
            label8.TabIndex = 9;
            // 
            // FabricPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 739);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FabricPopup";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo NPL cần nhận";
            Load += FabricPopup_Load;
            ((System.ComponentModel.ISupportInitialize)_dataTable).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Label label8;
        private DataGridView gridView;
        private Button addBtn;
        private Button cancelBtn;
        private Button saveBtn;
        private Button sampleFileBtn;
        private Panel panel14;
        private Panel panel1;
        private Panel panel3;
    }
}