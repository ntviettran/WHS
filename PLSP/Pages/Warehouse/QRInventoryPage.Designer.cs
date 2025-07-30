namespace PLSP.Pages
{
    partial class QRInventoryPage
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            qrBtn = new Button();
            locationSearchTxb = new TextBox();
            label1 = new Label();
            pagination = new WHS.Components.Pagination();
            gridView = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            selectMenuItem = new ToolStripMenuItem();
            unSelectMenuItem = new ToolStripMenuItem();
            moSearchTxb = new TextBox();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            titlteLabel = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            contextMenuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(qrBtn);
            panel1.Controls.Add(locationSearchTxb);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pagination);
            panel1.Controls.Add(gridView);
            panel1.Controls.Add(moSearchTxb);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(1097, 634);
            panel1.TabIndex = 0;
            // 
            // qrBtn
            // 
            qrBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            qrBtn.BackColor = Color.FromArgb(0, 46, 92);
            qrBtn.FlatStyle = FlatStyle.Flat;
            qrBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            qrBtn.ForeColor = Color.White;
            qrBtn.Location = new Point(964, 91);
            qrBtn.Name = "qrBtn";
            qrBtn.Size = new Size(130, 47);
            qrBtn.TabIndex = 33;
            qrBtn.Text = "Xuất QR";
            qrBtn.UseVisualStyleBackColor = false;
            qrBtn.Click += qrBtn_Click;
            // 
            // locationSearchTxb
            // 
            locationSearchTxb.BorderStyle = BorderStyle.FixedSingle;
            locationSearchTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            locationSearchTxb.Location = new Point(382, 91);
            locationSearchTxb.Margin = new Padding(3, 4, 3, 4);
            locationSearchTxb.Name = "locationSearchTxb";
            locationSearchTxb.Size = new Size(225, 38);
            locationSearchTxb.TabIndex = 31;
            locationSearchTxb.KeyDown += locationSearchTxb_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(312, 93);
            label1.Name = "label1";
            label1.Size = new Size(64, 31);
            label1.TabIndex = 32;
            label1.Text = "Vị trí";
            // 
            // pagination
            // 
            pagination.Dock = DockStyle.Bottom;
            pagination.Location = new Point(0, 587);
            pagination.Name = "pagination";
            pagination.Size = new Size(1097, 47);
            pagination.TabIndex = 30;
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
            gridView.ContextMenuStrip = contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridView.DefaultCellStyle = dataGridViewCellStyle2;
            gridView.EnableHeadersVisualStyles = false;
            gridView.Location = new Point(3, 149);
            gridView.Name = "gridView";
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            gridView.RowTemplate.Height = 35;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.Size = new Size(1091, 432);
            gridView.TabIndex = 29;
            gridView.CellValueChanged += gridView_CellValueChanged;
            gridView.CurrentCellDirtyStateChanged += gridView_CurrentCellDirtyStateChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { selectMenuItem, unSelectMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(133, 52);
            // 
            // selectMenuItem
            // 
            selectMenuItem.Name = "selectMenuItem";
            selectMenuItem.Size = new Size(132, 24);
            selectMenuItem.Text = "Chọn";
            selectMenuItem.Click += selectMenuItem_Click;
            // 
            // unSelectMenuItem
            // 
            unSelectMenuItem.Name = "unSelectMenuItem";
            unSelectMenuItem.Size = new Size(132, 24);
            unSelectMenuItem.Text = "Bỏ chọn";
            unSelectMenuItem.Click += unSelectMenuItem_Click;
            // 
            // moSearchTxb
            // 
            moSearchTxb.BorderStyle = BorderStyle.FixedSingle;
            moSearchTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            moSearchTxb.Location = new Point(60, 90);
            moSearchTxb.Margin = new Padding(3, 4, 3, 4);
            moSearchTxb.Name = "moSearchTxb";
            moSearchTxb.Size = new Size(225, 38);
            moSearchTxb.TabIndex = 27;
            moSearchTxb.KeyDown += moSearchTxb_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(2, 93);
            label2.Name = "label2";
            label2.Size = new Size(52, 31);
            label2.TabIndex = 28;
            label2.Text = "MO";
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
            tableLayoutPanel1.Size = new Size(1097, 83);
            tableLayoutPanel1.TabIndex = 26;
            // 
            // titlteLabel
            // 
            titlteLabel.Anchor = AnchorStyles.Top;
            titlteLabel.AutoSize = true;
            titlteLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titlteLabel.ForeColor = Color.Black;
            titlteLabel.Location = new Point(370, 0);
            titlteLabel.Name = "titlteLabel";
            titlteLabel.Size = new Size(356, 54);
            titlteLabel.TabIndex = 0;
            titlteLabel.Text = "TẠO QR CHO NPL";
            // 
            // QRInventoryPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "QRInventoryPage";
            Padding = new Padding(20);
            Size = new Size(1137, 674);
            Load += QRInventoryPage_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            contextMenuStrip1.ResumeLayout(false);
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
        private Button qrBtn;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem selectMenuItem;
        private ToolStripMenuItem unSelectMenuItem;
    }
}
