namespace PLSP.Popup.Inventory
{
    partial class DetailInventoryPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailInventoryPopup));
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            IdLabel = new Label();
            label8 = new Label();
            panel7 = new Panel();
            colorLabel = new Label();
            label10 = new Label();
            panel4 = new Panel();
            moLabel = new Label();
            label3 = new Label();
            panel6 = new Panel();
            inventoryQuantityLabel = new Label();
            label6 = new Label();
            panel3 = new Panel();
            plspTypeLabel = new Label();
            label2 = new Label();
            panel5 = new Panel();
            plspCodeLabel = new Label();
            label7 = new Label();
            moveQuantityLabel = new Label();
            label5 = new Label();
            locationGridView = new DataGridView();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel7.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)locationGridView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(moveQuantityLabel);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(locationGridView);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(760, 513);
            panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel7, 1, 2);
            tableLayoutPanel1.Controls.Add(panel4, 1, 0);
            tableLayoutPanel1.Controls.Add(panel6, 0, 2);
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Controls.Add(panel5, 1, 1);
            tableLayoutPanel1.Location = new Point(0, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(754, 156);
            tableLayoutPanel1.TabIndex = 46;
            // 
            // panel2
            // 
            panel2.Controls.Add(IdLabel);
            panel2.Controls.Add(label8);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(371, 46);
            panel2.TabIndex = 40;
            // 
            // IdLabel
            // 
            IdLabel.AutoSize = true;
            IdLabel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IdLabel.ForeColor = Color.Black;
            IdLabel.Location = new Point(51, 13);
            IdLabel.Name = "IdLabel";
            IdLabel.Size = new Size(175, 31);
            IdLabel.TabIndex = 32;
            IdLabel.Text = "Chưa có dữ liệu";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(3, 13);
            label8.Name = "label8";
            label8.Size = new Size(44, 31);
            label8.TabIndex = 31;
            label8.Text = "ID:";
            // 
            // panel7
            // 
            panel7.Controls.Add(colorLabel);
            panel7.Controls.Add(label10);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(380, 107);
            panel7.Name = "panel7";
            panel7.Size = new Size(371, 46);
            panel7.TabIndex = 45;
            // 
            // colorLabel
            // 
            colorLabel.AutoSize = true;
            colorLabel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            colorLabel.ForeColor = Color.Black;
            colorLabel.Location = new Point(72, 14);
            colorLabel.Name = "colorLabel";
            colorLabel.Size = new Size(175, 31);
            colorLabel.TabIndex = 30;
            colorLabel.Text = "Chưa có dữ liệu";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(5, 14);
            label10.Name = "label10";
            label10.Size = new Size(66, 31);
            label10.TabIndex = 29;
            label10.Text = "Màu:";
            // 
            // panel4
            // 
            panel4.Controls.Add(moLabel);
            panel4.Controls.Add(label3);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(380, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(371, 46);
            panel4.TabIndex = 42;
            // 
            // moLabel
            // 
            moLabel.AutoSize = true;
            moLabel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            moLabel.ForeColor = Color.Black;
            moLabel.Location = new Point(64, 13);
            moLabel.Name = "moLabel";
            moLabel.Size = new Size(175, 31);
            moLabel.TabIndex = 28;
            moLabel.Text = "Chưa có dữ liệu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(5, 13);
            label3.Name = "label3";
            label3.Size = new Size(58, 31);
            label3.TabIndex = 27;
            label3.Text = "MO:";
            // 
            // panel6
            // 
            panel6.Controls.Add(inventoryQuantityLabel);
            panel6.Controls.Add(label6);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 107);
            panel6.Name = "panel6";
            panel6.Size = new Size(371, 46);
            panel6.TabIndex = 44;
            // 
            // inventoryQuantityLabel
            // 
            inventoryQuantityLabel.AutoSize = true;
            inventoryQuantityLabel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            inventoryQuantityLabel.ForeColor = Color.Black;
            inventoryQuantityLabel.Location = new Point(160, 14);
            inventoryQuantityLabel.Name = "inventoryQuantityLabel";
            inventoryQuantityLabel.Size = new Size(175, 31);
            inventoryQuantityLabel.TabIndex = 30;
            inventoryQuantityLabel.Text = "Chưa có dữ liệu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(5, 14);
            label6.Name = "label6";
            label6.Size = new Size(155, 31);
            label6.TabIndex = 29;
            label6.Text = "Số lượng tồn:";
            // 
            // panel3
            // 
            panel3.Controls.Add(plspTypeLabel);
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 55);
            panel3.Name = "panel3";
            panel3.Size = new Size(371, 46);
            panel3.TabIndex = 41;
            // 
            // plspTypeLabel
            // 
            plspTypeLabel.AutoSize = true;
            plspTypeLabel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            plspTypeLabel.ForeColor = Color.Black;
            plspTypeLabel.Location = new Point(156, 12);
            plspTypeLabel.Name = "plspTypeLabel";
            plspTypeLabel.Size = new Size(175, 31);
            plspTypeLabel.TabIndex = 37;
            plspTypeLabel.Text = "Chưa có dữ liệu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(5, 11);
            label2.Name = "label2";
            label2.Size = new Size(152, 31);
            label2.TabIndex = 36;
            label2.Text = "Loại phụ liệu:";
            // 
            // panel5
            // 
            panel5.Controls.Add(plspCodeLabel);
            panel5.Controls.Add(label7);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(380, 55);
            panel5.Name = "panel5";
            panel5.Size = new Size(371, 46);
            panel5.TabIndex = 43;
            // 
            // plspCodeLabel
            // 
            plspCodeLabel.AutoSize = true;
            plspCodeLabel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            plspCodeLabel.ForeColor = Color.Black;
            plspCodeLabel.Location = new Point(124, 12);
            plspCodeLabel.Name = "plspCodeLabel";
            plspCodeLabel.Size = new Size(175, 31);
            plspCodeLabel.TabIndex = 39;
            plspCodeLabel.Text = "Chưa có dữ liệu";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(5, 12);
            label7.Name = "label7";
            label7.Size = new Size(113, 31);
            label7.TabIndex = 38;
            label7.Text = "Mã Code:";
            // 
            // moveQuantityLabel
            // 
            moveQuantityLabel.AutoSize = true;
            moveQuantityLabel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            moveQuantityLabel.ForeColor = Color.Black;
            moveQuantityLabel.Location = new Point(253, 171);
            moveQuantityLabel.Name = "moveQuantityLabel";
            moveQuantityLabel.Size = new Size(175, 31);
            moveQuantityLabel.TabIndex = 34;
            moveQuantityLabel.Text = "Chưa có dữ liệu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(7, 171);
            label5.Name = "label5";
            label5.Size = new Size(240, 31);
            label5.TabIndex = 33;
            label5.Text = "Số lượng tồn tại vị trí:";
            // 
            // locationGridView
            // 
            locationGridView.AllowUserToDeleteRows = false;
            locationGridView.AllowUserToResizeRows = false;
            locationGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            locationGridView.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(0, 10, 0, 10);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            locationGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            locationGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            locationGridView.DefaultCellStyle = dataGridViewCellStyle2;
            locationGridView.EnableHeadersVisualStyles = false;
            locationGridView.Location = new Point(3, 218);
            locationGridView.Name = "locationGridView";
            locationGridView.RowHeadersWidth = 51;
            locationGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            locationGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            locationGridView.RowTemplate.Height = 35;
            locationGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            locationGridView.Size = new Size(754, 292);
            locationGridView.TabIndex = 35;
            // 
            // DetailInventoryPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 553);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DetailInventoryPopup";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin chi tiết";
            Load += DetailInventoryPopup_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)locationGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView locationGridView;
        private Label moveQuantityLabel;
        private Label label5;
        private Label IdLabel;
        private Label label8;
        private Label inventoryQuantityLabel;
        private Label label6;
        private Label moLabel;
        private Label label3;
        private Label plspCodeLabel;
        private Label label7;
        private Label plspTypeLabel;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel panel4;
        private Panel panel3;
        private Panel panel5;
        private Panel panel7;
        private Label colorLabel;
        private Label label10;
        private Panel panel6;
    }
}