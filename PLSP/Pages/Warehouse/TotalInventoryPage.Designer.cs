namespace PLSP.Pages
{
    partial class TotalInventoryPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TotalInventoryPage));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            detailBtn = new Button();
            panel1 = new Panel();
            pagination = new WHS.Components.Pagination();
            gridView = new DataGridView();
            moSearchTxb = new TextBox();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            titlteLabel = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            arrangeStripMode = new ToolStripMenuItem();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // detailBtn
            // 
            detailBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            detailBtn.BackColor = Color.FromArgb(0, 46, 92);
            detailBtn.BackgroundImage = (Image)resources.GetObject("detailBtn.BackgroundImage");
            detailBtn.BackgroundImageLayout = ImageLayout.Zoom;
            detailBtn.FlatStyle = FlatStyle.Flat;
            detailBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            detailBtn.ForeColor = Color.White;
            detailBtn.Location = new Point(883, 2);
            detailBtn.Name = "detailBtn";
            detailBtn.Size = new Size(55, 47);
            detailBtn.TabIndex = 15;
            detailBtn.UseVisualStyleBackColor = false;
            detailBtn.Click += detailBtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pagination);
            panel1.Controls.Add(gridView);
            panel1.Controls.Add(moSearchTxb);
            panel1.Controls.Add(detailBtn);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(940, 494);
            panel1.TabIndex = 16;
            // 
            // pagination
            // 
            pagination.Dock = DockStyle.Bottom;
            pagination.Location = new Point(0, 447);
            pagination.Name = "pagination";
            pagination.Size = new Size(940, 47);
            pagination.TabIndex = 22;
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
            gridView.MultiSelect = false;
            gridView.Name = "gridView";
            gridView.ReadOnly = true;
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            gridView.RowTemplate.Height = 35;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.Size = new Size(934, 286);
            gridView.TabIndex = 21;
            gridView.CellMouseDoubleClick += gridView_CellMouseDoubleClick;
            // 
            // moSearchTxb
            // 
            moSearchTxb.BorderStyle = BorderStyle.FixedSingle;
            moSearchTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            moSearchTxb.Location = new Point(60, 90);
            moSearchTxb.Margin = new Padding(3, 4, 3, 4);
            moSearchTxb.Name = "moSearchTxb";
            moSearchTxb.Size = new Size(225, 38);
            moSearchTxb.TabIndex = 19;
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
            label2.TabIndex = 20;
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
            tableLayoutPanel1.Size = new Size(940, 83);
            tableLayoutPanel1.TabIndex = 18;
            // 
            // titlteLabel
            // 
            titlteLabel.Anchor = AnchorStyles.Top;
            titlteLabel.AutoSize = true;
            titlteLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titlteLabel.ForeColor = Color.Black;
            titlteLabel.Location = new Point(382, 0);
            titlteLabel.Name = "titlteLabel";
            titlteLabel.Size = new Size(175, 54);
            titlteLabel.TabIndex = 0;
            titlteLabel.Text = "Tồn kho";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { arrangeStripMode });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(165, 28);
            // 
            // arrangeStripMode
            // 
            arrangeStripMode.Name = "arrangeStripMode";
            arrangeStripMode.Size = new Size(164, 24);
            arrangeStripMode.Text = "Sắp xếp vị trí";
            arrangeStripMode.Click += arrangeStripMode_Click;
            // 
            // TotalInventoryPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "TotalInventoryPage";
            Padding = new Padding(20);
            Size = new Size(980, 534);
            Load += TotalInventoryPage_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button detailBtn;
        private Panel panel1;
        private TextBox moSearchTxb;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label titlteLabel;
        private WHS.Components.Pagination pagination;
        private DataGridView gridView;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem arrangeStripMode;
    }
}
