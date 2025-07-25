namespace WHS.Pages
{
    partial class DetailReceivePage
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            titlteLabel = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            updateBtn = new Button();
            exportBtn = new Button();
            typeContainer = new Panel();
            fabricBtn = new Button();
            pldgBtn = new Button();
            plspBtn = new Button();
            dispatchStatusCbx = new ComboBox();
            statusCbx = new ComboBox();
            pagination = new WHS.Components.Pagination();
            label3 = new Label();
            label1 = new Label();
            moSearchTxb = new TextBox();
            label2 = new Label();
            button1 = new Button();
            panel2 = new Panel();
            gridView = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            typeContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            SuspendLayout();
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
            tableLayoutPanel1.Size = new Size(1144, 83);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // titlteLabel
            // 
            titlteLabel.Anchor = AnchorStyles.Top;
            titlteLabel.AutoSize = true;
            titlteLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titlteLabel.ForeColor = Color.Black;
            titlteLabel.Location = new Point(221, 0);
            titlteLabel.Name = "titlteLabel";
            titlteLabel.Size = new Size(701, 54);
            titlteLabel.TabIndex = 0;
            titlteLabel.Text = "THEO DÕI CHI TIẾT NPL CẦN NHẬN";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(typeContainer);
            panel1.Controls.Add(dispatchStatusCbx);
            panel1.Controls.Add(statusCbx);
            panel1.Controls.Add(pagination);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(moSearchTxb);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(gridView);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(1144, 510);
            panel1.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.Controls.Add(updateBtn);
            panel3.Controls.Add(exportBtn);
            panel3.Location = new Point(837, 87);
            panel3.Name = "panel3";
            panel3.Size = new Size(304, 53);
            panel3.TabIndex = 27;
            // 
            // updateBtn
            // 
            updateBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            updateBtn.BackColor = Color.FromArgb(0, 46, 92);
            updateBtn.BackgroundImage = Properties.Resources.up_arrow;
            updateBtn.BackgroundImageLayout = ImageLayout.Zoom;
            updateBtn.FlatStyle = FlatStyle.Flat;
            updateBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            updateBtn.ForeColor = Color.White;
            updateBtn.Location = new Point(254, 3);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(47, 48);
            updateBtn.TabIndex = 0;
            updateBtn.UseVisualStyleBackColor = false;
            updateBtn.Click += updateBtn_Click;
            // 
            // exportBtn
            // 
            exportBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            exportBtn.BackColor = Color.FromArgb(0, 46, 92);
            exportBtn.FlatStyle = FlatStyle.Flat;
            exportBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exportBtn.ForeColor = Color.White;
            exportBtn.Location = new Point(129, 3);
            exportBtn.Name = "exportBtn";
            exportBtn.Size = new Size(126, 48);
            exportBtn.TabIndex = 1;
            exportBtn.Text = "Cập nhật";
            exportBtn.UseVisualStyleBackColor = false;
            exportBtn.Click += exportBtn_Click;
            // 
            // typeContainer
            // 
            typeContainer.Controls.Add(fabricBtn);
            typeContainer.Controls.Add(pldgBtn);
            typeContainer.Controls.Add(plspBtn);
            typeContainer.Location = new Point(4, 87);
            typeContainer.Name = "typeContainer";
            typeContainer.Size = new Size(498, 53);
            typeContainer.TabIndex = 26;
            // 
            // fabricBtn
            // 
            fabricBtn.BackColor = Color.FromArgb(0, 46, 92);
            fabricBtn.FlatStyle = FlatStyle.Flat;
            fabricBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fabricBtn.ForeColor = Color.White;
            fabricBtn.Location = new Point(3, 3);
            fabricBtn.Name = "fabricBtn";
            fabricBtn.Size = new Size(94, 48);
            fabricBtn.TabIndex = 0;
            fabricBtn.Text = "Vải";
            fabricBtn.UseVisualStyleBackColor = false;
            fabricBtn.Click += fabricBtn_Click;
            // 
            // pldgBtn
            // 
            pldgBtn.BackColor = Color.DarkGray;
            pldgBtn.FlatStyle = FlatStyle.Flat;
            pldgBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pldgBtn.ForeColor = Color.White;
            pldgBtn.Location = new Point(203, 4);
            pldgBtn.Name = "pldgBtn";
            pldgBtn.Size = new Size(94, 47);
            pldgBtn.TabIndex = 2;
            pldgBtn.Text = "PLĐG";
            pldgBtn.UseVisualStyleBackColor = false;
            pldgBtn.Click += pldgBtn_Click;
            // 
            // plspBtn
            // 
            plspBtn.BackColor = Color.DarkGray;
            plspBtn.FlatStyle = FlatStyle.Flat;
            plspBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            plspBtn.ForeColor = Color.White;
            plspBtn.Location = new Point(103, 4);
            plspBtn.Name = "plspBtn";
            plspBtn.Size = new Size(94, 48);
            plspBtn.TabIndex = 1;
            plspBtn.Text = "PLSP";
            plspBtn.UseVisualStyleBackColor = false;
            plspBtn.Click += plspBtn_Click;
            // 
            // dispatchStatusCbx
            // 
            dispatchStatusCbx.DropDownStyle = ComboBoxStyle.DropDownList;
            dispatchStatusCbx.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dispatchStatusCbx.FormattingEnabled = true;
            dispatchStatusCbx.Location = new Point(914, 165);
            dispatchStatusCbx.Name = "dispatchStatusCbx";
            dispatchStatusCbx.Size = new Size(218, 39);
            dispatchStatusCbx.TabIndex = 25;
            dispatchStatusCbx.SelectionChangeCommitted += dispatchStatusCbx_SelectionChangeCommitted;
            // 
            // statusCbx
            // 
            statusCbx.DropDownStyle = ComboBoxStyle.DropDownList;
            statusCbx.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusCbx.FormattingEnabled = true;
            statusCbx.Location = new Point(444, 165);
            statusCbx.Name = "statusCbx";
            statusCbx.Size = new Size(218, 39);
            statusCbx.TabIndex = 24;
            statusCbx.SelectionChangeCommitted += statusCbx_SelectionChangeCommitted;
            // 
            // pagination
            // 
            pagination.Dock = DockStyle.Bottom;
            pagination.Location = new Point(0, 464);
            pagination.Name = "pagination";
            pagination.Size = new Size(1144, 46);
            pagination.TabIndex = 23;
            pagination.PageChanged += pagination_PageChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(680, 169);
            label3.Name = "label3";
            label3.Size = new Size(222, 31);
            label3.TabIndex = 21;
            label3.Text = "Trạng thái điều phối";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(309, 168);
            label1.Name = "label1";
            label1.Size = new Size(118, 31);
            label1.TabIndex = 19;
            label1.Text = "Trạng thái";
            // 
            // moSearchTxb
            // 
            moSearchTxb.BorderStyle = BorderStyle.FixedSingle;
            moSearchTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            moSearchTxb.Location = new Point(63, 165);
            moSearchTxb.Margin = new Padding(3, 4, 3, 4);
            moSearchTxb.Name = "moSearchTxb";
            moSearchTxb.Size = new Size(225, 38);
            moSearchTxb.TabIndex = 16;
            moSearchTxb.KeyDown += moSearchTxb_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(4, 165);
            label2.Name = "label2";
            label2.Size = new Size(52, 31);
            label2.TabIndex = 17;
            label2.Text = "MO";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 46, 92);
            button1.BackgroundImage = Properties.Resources.leftarrow;
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(3, 1);
            button1.Name = "button1";
            button1.Size = new Size(55, 47);
            button1.TabIndex = 15;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(1, 146);
            panel2.Name = "panel2";
            panel2.Size = new Size(1143, 1);
            panel2.TabIndex = 9;
            // 
            // gridView
            // 
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;
            gridView.AllowUserToResizeRows = false;
            gridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridView.BackgroundColor = Color.White;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.Padding = new Padding(0, 10, 0, 10);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            gridView.DefaultCellStyle = dataGridViewCellStyle8;
            gridView.EnableHeadersVisualStyles = false;
            gridView.Location = new Point(0, 230);
            gridView.Name = "gridView";
            gridView.ReadOnly = true;
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridView.RowsDefaultCellStyle = dataGridViewCellStyle9;
            gridView.RowTemplate.Height = 35;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.Size = new Size(1138, 228);
            gridView.TabIndex = 22;
            gridView.CellMouseDoubleClick += gridView_CellMouseDoubleClick;
            // 
            // DetailReceivePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "DetailReceivePage";
            Padding = new Padding(20);
            Size = new Size(1184, 550);
            Load += DetailReceivePage_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            typeContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label titlteLabel;
        private Panel panel1;
        private Button pldgBtn;
        private Button plspBtn;
        private Button fabricBtn;
        private Panel panel2;
        private Button button1;
        private Label label3;
        private Label label1;
        private TextBox moSearchTxb;
        private Label label2;
        private Components.Pagination pagination;
        private DataGridView gridView;
        private ComboBox dispatchStatusCbx;
        private ComboBox statusCbx;
        private Panel typeContainer;
        private Panel panel3;
        private Button updateBtn;
        private Button exportBtn;
    }
}
