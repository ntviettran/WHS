namespace PLSP.Pages
{
    partial class HistoryTransactionPage
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            panel7 = new Panel();
            panel5 = new Panel();
            label3 = new Label();
            datetimeSearch = new DateTimePicker();
            codePanel = new Panel();
            label5 = new Label();
            codeSearchTxb = new TextBox();
            blockPanel = new Panel();
            label4 = new Label();
            blockSearchTxb = new TextBox();
            panel3 = new Panel();
            label1 = new Label();
            locationSearchTxb = new TextBox();
            panel2 = new Panel();
            label2 = new Label();
            moSearchTxb = new TextBox();
            pagination = new WHS.Components.Pagination();
            gridView = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            titlteLabel = new Label();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            codePanel.SuspendLayout();
            blockPanel.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(pagination);
            panel1.Controls.Add(gridView);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(1583, 470);
            panel1.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel7.Controls.Add(panel5);
            panel7.Controls.Add(codePanel);
            panel7.Controls.Add(blockPanel);
            panel7.Controls.Add(panel3);
            panel7.Controls.Add(panel2);
            panel7.Location = new Point(0, 80);
            panel7.Name = "panel7";
            panel7.Size = new Size(1580, 60);
            panel7.TabIndex = 49;
            // 
            // panel5
            // 
            panel5.Controls.Add(label3);
            panel5.Controls.Add(datetimeSearch);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(1230, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(346, 60);
            panel5.TabIndex = 48;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(3, 13);
            label3.Name = "label3";
            label3.Size = new Size(111, 31);
            label3.TabIndex = 41;
            label3.Text = "Thời gian";
            // 
            // datetimeSearch
            // 
            datetimeSearch.Checked = false;
            datetimeSearch.CustomFormat = "dd/MM/yyyy";
            datetimeSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            datetimeSearch.Format = DateTimePickerFormat.Custom;
            datetimeSearch.Location = new Point(120, 10);
            datetimeSearch.Name = "datetimeSearch";
            datetimeSearch.ShowCheckBox = true;
            datetimeSearch.Size = new Size(205, 38);
            datetimeSearch.TabIndex = 42;
            datetimeSearch.ValueChanged += datetimeSearch_ValueChanged;
            // 
            // codePanel
            // 
            codePanel.Controls.Add(label5);
            codePanel.Controls.Add(codeSearchTxb);
            codePanel.Dock = DockStyle.Left;
            codePanel.Location = new Point(835, 0);
            codePanel.Name = "codePanel";
            codePanel.Size = new Size(395, 60);
            codePanel.TabIndex = 48;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(3, 13);
            label5.Name = "label5";
            label5.Size = new Size(153, 31);
            label5.TabIndex = 44;
            label5.Text = "Mã nhân viên";
            // 
            // codeSearchTxb
            // 
            codeSearchTxb.BorderStyle = BorderStyle.FixedSingle;
            codeSearchTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            codeSearchTxb.Location = new Point(162, 12);
            codeSearchTxb.Margin = new Padding(3, 4, 3, 4);
            codeSearchTxb.Name = "codeSearchTxb";
            codeSearchTxb.Size = new Size(210, 38);
            codeSearchTxb.TabIndex = 43;
            codeSearchTxb.KeyDown += codeSearchTxb_KeyDown;
            // 
            // blockPanel
            // 
            blockPanel.Controls.Add(label4);
            blockPanel.Controls.Add(blockSearchTxb);
            blockPanel.Dock = DockStyle.Left;
            blockPanel.Location = new Point(538, 0);
            blockPanel.Name = "blockPanel";
            blockPanel.Size = new Size(297, 60);
            blockPanel.TabIndex = 47;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(3, 11);
            label4.Name = "label4";
            label4.Size = new Size(71, 31);
            label4.TabIndex = 44;
            label4.Text = "Block";
            // 
            // blockSearchTxb
            // 
            blockSearchTxb.BorderStyle = BorderStyle.FixedSingle;
            blockSearchTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            blockSearchTxb.Location = new Point(90, 11);
            blockSearchTxb.Margin = new Padding(3, 4, 3, 4);
            blockSearchTxb.Name = "blockSearchTxb";
            blockSearchTxb.Size = new Size(187, 38);
            blockSearchTxb.TabIndex = 43;
            blockSearchTxb.KeyDown += blockSearchTxb_KeyDown;
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Controls.Add(locationSearchTxb);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(265, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(273, 60);
            panel3.TabIndex = 46;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(2, 13);
            label1.Name = "label1";
            label1.Size = new Size(64, 31);
            label1.TabIndex = 39;
            label1.Text = "Vị trí";
            // 
            // locationSearchTxb
            // 
            locationSearchTxb.BorderStyle = BorderStyle.FixedSingle;
            locationSearchTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            locationSearchTxb.Location = new Point(70, 11);
            locationSearchTxb.Margin = new Padding(3, 4, 3, 4);
            locationSearchTxb.Name = "locationSearchTxb";
            locationSearchTxb.Size = new Size(187, 38);
            locationSearchTxb.TabIndex = 38;
            locationSearchTxb.KeyDown += locationSearchTxb_KeyDown;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(moSearchTxb);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(265, 60);
            panel2.TabIndex = 45;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(3, 12);
            label2.Name = "label2";
            label2.Size = new Size(52, 31);
            label2.TabIndex = 35;
            label2.Text = "MO";
            // 
            // moSearchTxb
            // 
            moSearchTxb.BorderStyle = BorderStyle.FixedSingle;
            moSearchTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            moSearchTxb.Location = new Point(61, 11);
            moSearchTxb.Margin = new Padding(3, 4, 3, 4);
            moSearchTxb.Name = "moSearchTxb";
            moSearchTxb.Size = new Size(187, 38);
            moSearchTxb.TabIndex = 34;
            moSearchTxb.KeyDown += moSearchTxb_KeyDown;
            // 
            // pagination
            // 
            pagination.Dock = DockStyle.Bottom;
            pagination.Location = new Point(0, 423);
            pagination.Name = "pagination";
            pagination.Size = new Size(1583, 47);
            pagination.TabIndex = 37;
            pagination.PageChanged += pagination_PageChanged;
            // 
            // gridView
            // 
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;
            gridView.AllowUserToResizeRows = false;
            gridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            gridView.EnableHeadersVisualStyles = false;
            gridView.Location = new Point(0, 150);
            gridView.Name = "gridView";
            gridView.ReadOnly = true;
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            gridView.RowTemplate.Height = 35;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.Size = new Size(1580, 268);
            gridView.TabIndex = 36;
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
            tableLayoutPanel1.Size = new Size(1583, 67);
            tableLayoutPanel1.TabIndex = 33;
            // 
            // titlteLabel
            // 
            titlteLabel.Anchor = AnchorStyles.Top;
            titlteLabel.AutoSize = true;
            titlteLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titlteLabel.ForeColor = Color.Black;
            titlteLabel.Location = new Point(596, 0);
            titlteLabel.Name = "titlteLabel";
            titlteLabel.Size = new Size(391, 54);
            titlteLabel.TabIndex = 0;
            titlteLabel.Text = "LỊCH SỬ XUẤT KHO";
            // 
            // HistoryTransactionPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "HistoryTransactionPage";
            Padding = new Padding(20);
            Size = new Size(1623, 510);
            Load += HistoryTransaction_Load;
            panel1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            codePanel.ResumeLayout(false);
            codePanel.PerformLayout();
            blockPanel.ResumeLayout(false);
            blockPanel.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox locationSearchTxb;
        private Label label1;
        private WHS.Components.Pagination pagination;
        private DataGridView gridView;
        private TextBox moSearchTxb;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label titlteLabel;
        private DateTimePicker datetimeSearch;
        private Label label3;
        private TextBox blockSearchTxb;
        private Label label4;
        private Panel panel7;
        private Panel codePanel;
        private Label label5;
        private TextBox codeSearchTxb;
        private Panel panel5;
        private Panel blockPanel;
        private Panel panel3;
        private Panel panel2;
    }
}
