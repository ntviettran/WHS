namespace PLSP.Pages
{
    partial class ExportInventoryPage
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panel1 = new Panel();
            mainPanel = new Panel();
            exportBtn = new Button();
            gridView = new DataGridView();
            nplCode = new TextBox();
            label1 = new Label();
            ssidPanel = new Panel();
            ssidTxb = new TextBox();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            titlteLabel = new Label();
            label4 = new Label();
            codeLabel = new Label();
            locationLabel = new Label();
            label6 = new Label();
            panel1.SuspendLayout();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            ssidPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(mainPanel);
            panel1.Controls.Add(ssidPanel);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(849, 547);
            panel1.TabIndex = 0;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(locationLabel);
            mainPanel.Controls.Add(label6);
            mainPanel.Controls.Add(codeLabel);
            mainPanel.Controls.Add(label4);
            mainPanel.Controls.Add(exportBtn);
            mainPanel.Controls.Add(gridView);
            mainPanel.Controls.Add(nplCode);
            mainPanel.Controls.Add(label1);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 147);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(849, 400);
            mainPanel.TabIndex = 25;
            // 
            // exportBtn
            // 
            exportBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            exportBtn.BackColor = Color.FromArgb(0, 46, 92);
            exportBtn.FlatStyle = FlatStyle.Flat;
            exportBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exportBtn.ForeColor = Color.White;
            exportBtn.Location = new Point(716, 350);
            exportBtn.Name = "exportBtn";
            exportBtn.Size = new Size(130, 47);
            exportBtn.TabIndex = 35;
            exportBtn.Text = "Xuất kho";
            exportBtn.UseVisualStyleBackColor = false;
            exportBtn.Click += exportBtn_Click;
            // 
            // gridView
            // 
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;
            gridView.AllowUserToResizeRows = false;
            gridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridView.BackgroundColor = Color.White;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.Padding = new Padding(0, 10, 0, 10);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            gridView.DefaultCellStyle = dataGridViewCellStyle5;
            gridView.EnableHeadersVisualStyles = false;
            gridView.Location = new Point(0, 138);
            gridView.Name = "gridView";
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            gridView.RowTemplate.Height = 35;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.Size = new Size(849, 198);
            gridView.TabIndex = 26;
            gridView.KeyDown += gridView_KeyDown;
            // 
            // nplCode
            // 
            nplCode.BorderStyle = BorderStyle.FixedSingle;
            nplCode.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nplCode.Location = new Point(128, 83);
            nplCode.Margin = new Padding(3, 4, 3, 4);
            nplCode.Name = "nplCode";
            nplCode.Size = new Size(267, 38);
            nplCode.TabIndex = 24;
            nplCode.KeyDown += nplCode_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(4, 85);
            label1.Name = "label1";
            label1.Size = new Size(112, 31);
            label1.TabIndex = 25;
            label1.Text = "Quét NPL";
            // 
            // ssidPanel
            // 
            ssidPanel.Controls.Add(ssidTxb);
            ssidPanel.Controls.Add(label2);
            ssidPanel.Dock = DockStyle.Top;
            ssidPanel.Location = new Point(0, 78);
            ssidPanel.Name = "ssidPanel";
            ssidPanel.Size = new Size(849, 69);
            ssidPanel.TabIndex = 24;
            // 
            // ssidTxb
            // 
            ssidTxb.BorderStyle = BorderStyle.FixedSingle;
            ssidTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ssidTxb.Location = new Point(224, 16);
            ssidTxb.Margin = new Padding(3, 4, 3, 4);
            ssidTxb.Name = "ssidTxb";
            ssidTxb.Size = new Size(267, 38);
            ssidTxb.TabIndex = 22;
            ssidTxb.KeyDown += ssidTxb_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(3, 18);
            label2.Name = "label2";
            label2.Size = new Size(215, 31);
            label2.TabIndex = 23;
            label2.Text = "Quét thẻ nhân viên ";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(titlteLabel, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(849, 78);
            tableLayoutPanel1.TabIndex = 21;
            // 
            // titlteLabel
            // 
            titlteLabel.Anchor = AnchorStyles.Top;
            titlteLabel.AutoSize = true;
            titlteLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titlteLabel.ForeColor = Color.Black;
            titlteLabel.Location = new Point(328, 0);
            titlteLabel.Name = "titlteLabel";
            titlteLabel.Size = new Size(192, 54);
            titlteLabel.TabIndex = 0;
            titlteLabel.Text = "Xuất kho";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(4, 22);
            label4.Name = "label4";
            label4.Size = new Size(122, 31);
            label4.TabIndex = 37;
            label4.Text = "Mã số thẻ:";
            // 
            // codeLabel
            // 
            codeLabel.AutoSize = true;
            codeLabel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            codeLabel.ForeColor = Color.Black;
            codeLabel.Location = new Point(128, 23);
            codeLabel.Name = "codeLabel";
            codeLabel.Size = new Size(175, 31);
            codeLabel.TabIndex = 38;
            codeLabel.Text = "Chưa có dữ liệu";
            // 
            // locationLabel
            // 
            locationLabel.AutoSize = true;
            locationLabel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            locationLabel.ForeColor = Color.Black;
            locationLabel.Location = new Point(399, 22);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new Size(175, 31);
            locationLabel.TabIndex = 40;
            locationLabel.Text = "Chưa có dữ liệu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(327, 22);
            label6.Name = "label6";
            label6.Size = new Size(70, 31);
            label6.TabIndex = 39;
            label6.Text = "Vị trí:";
            // 
            // ExportInventoryPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "ExportInventoryPage";
            Padding = new Padding(20);
            Size = new Size(889, 587);
            panel1.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            ssidPanel.ResumeLayout(false);
            ssidPanel.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel ssidPanel;
        private TextBox ssidTxb;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label titlteLabel;
        private Panel mainPanel;
        private TextBox nplCode;
        private Label label1;
        private DataGridView gridView;
        private Button exportBtn;
        private Label locationLabel;
        private Label label6;
        private Label codeLabel;
        private Label label4;
    }
}
