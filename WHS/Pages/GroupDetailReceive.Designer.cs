namespace WHS.Pages.Receive
{
    partial class GroupDetailReceive
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
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            panel1 = new Panel();
            button1 = new Button();
            moSearchTxb = new TextBox();
            pagination = new WHS.Components.Pagination();
            addBtn = new Button();
            gridView = new DataGridView();
            label2 = new Label();
            panel2 = new Panel();
            typeContainer = new TableLayoutPanel();
            pldgBtn = new Button();
            plspBtn = new Button();
            fabricBtn = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            titlteLabel = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            typeContainer.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(moSearchTxb);
            panel1.Controls.Add(pagination);
            panel1.Controls.Add(addBtn);
            panel1.Controls.Add(gridView);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(typeContainer);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(948, 715);
            panel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(0, 46, 92);
            button1.BackgroundImage = Properties.Resources.rightarrow;
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(889, 3);
            button1.Name = "button1";
            button1.Size = new Size(55, 47);
            button1.TabIndex = 14;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // moSearchTxb
            // 
            moSearchTxb.BorderStyle = BorderStyle.FixedSingle;
            moSearchTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            moSearchTxb.Location = new Point(55, 164);
            moSearchTxb.Margin = new Padding(3, 4, 3, 4);
            moSearchTxb.Name = "moSearchTxb";
            moSearchTxb.Size = new Size(225, 38);
            moSearchTxb.TabIndex = 0;
            moSearchTxb.KeyDown += moSearchTxb_KeyDown;
            // 
            // pagination
            // 
            pagination.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pagination.Location = new Point(3, 666);
            pagination.Name = "pagination";
            pagination.Size = new Size(945, 46);
            pagination.TabIndex = 13;
            pagination.PageChanged += pagination_PageChanged;
            // 
            // addBtn
            // 
            addBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addBtn.BackColor = Color.FromArgb(0, 46, 92);
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(815, 166);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(130, 47);
            addBtn.TabIndex = 3;
            addBtn.Text = "Tạo mới";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // gridView
            // 
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;
            gridView.AllowUserToResizeRows = false;
            gridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridView.BackgroundColor = Color.White;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.White;
            dataGridViewCellStyle10.Padding = new Padding(0, 10, 0, 10);
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle10.SelectionForeColor = Color.White;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = SystemColors.Window;
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            gridView.DefaultCellStyle = dataGridViewCellStyle11;
            gridView.EnableHeadersVisualStyles = false;
            gridView.Location = new Point(1, 233);
            gridView.Name = "gridView";
            gridView.ReadOnly = true;
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridView.RowsDefaultCellStyle = dataGridViewCellStyle12;
            gridView.RowTemplate.Height = 35;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.Size = new Size(947, 427);
            gridView.TabIndex = 12;
            gridView.CellMouseDoubleClick += gridView_CellMouseDoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(-3, 166);
            label2.Name = "label2";
            label2.Size = new Size(52, 31);
            label2.TabIndex = 1;
            label2.Text = "MO";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(0, 146);
            panel2.Name = "panel2";
            panel2.Size = new Size(948, 1);
            panel2.TabIndex = 8;
            // 
            // typeContainer
            // 
            typeContainer.ColumnCount = 3;
            typeContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            typeContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            typeContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            typeContainer.Controls.Add(pldgBtn, 2, 0);
            typeContainer.Controls.Add(plspBtn, 1, 0);
            typeContainer.Controls.Add(fabricBtn, 0, 0);
            typeContainer.Dock = DockStyle.Top;
            typeContainer.Location = new Point(0, 83);
            typeContainer.Name = "typeContainer";
            typeContainer.RowCount = 1;
            typeContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            typeContainer.Size = new Size(948, 54);
            typeContainer.TabIndex = 7;
            // 
            // pldgBtn
            // 
            pldgBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pldgBtn.BackColor = Color.DarkGray;
            pldgBtn.FlatStyle = FlatStyle.Flat;
            pldgBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pldgBtn.ForeColor = Color.White;
            pldgBtn.Location = new Point(851, 3);
            pldgBtn.Name = "pldgBtn";
            pldgBtn.Size = new Size(94, 47);
            pldgBtn.TabIndex = 2;
            pldgBtn.Text = "PLĐG";
            pldgBtn.UseVisualStyleBackColor = false;
            pldgBtn.Click += pldgBtn_Click;
            // 
            // plspBtn
            // 
            plspBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            plspBtn.BackColor = Color.DarkGray;
            plspBtn.FlatStyle = FlatStyle.Flat;
            plspBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            plspBtn.ForeColor = Color.White;
            plspBtn.Location = new Point(425, 3);
            plspBtn.Name = "plspBtn";
            plspBtn.Size = new Size(94, 48);
            plspBtn.TabIndex = 1;
            plspBtn.Text = "PLSP";
            plspBtn.UseVisualStyleBackColor = false;
            plspBtn.Click += plspBtn_Click;
            // 
            // fabricBtn
            // 
            fabricBtn.BackColor = Color.FromArgb(0, 46, 92);
            fabricBtn.FlatStyle = FlatStyle.Flat;
            fabricBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fabricBtn.ForeColor = Color.White;
            fabricBtn.Location = new Point(3, 3);
            fabricBtn.Name = "fabricBtn";
            fabricBtn.Size = new Size(94, 45);
            fabricBtn.TabIndex = 0;
            fabricBtn.Text = "Vải";
            fabricBtn.UseVisualStyleBackColor = false;
            fabricBtn.Click += fabricBtn_Click;
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
            tableLayoutPanel1.Size = new Size(948, 83);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // titlteLabel
            // 
            titlteLabel.Anchor = AnchorStyles.Top;
            titlteLabel.AutoSize = true;
            titlteLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titlteLabel.ForeColor = Color.Black;
            titlteLabel.Location = new Point(209, 0);
            titlteLabel.Name = "titlteLabel";
            titlteLabel.Size = new Size(530, 54);
            titlteLabel.TabIndex = 0;
            titlteLabel.Text = "THEO DÕI NPL CẦN NHẬN";
            // 
            // GroupDetailReceive
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(panel1);
            Name = "GroupDetailReceive";
            Padding = new Padding(20, 20, 20, 10);
            Size = new Size(988, 745);
            Load += DetailReceive_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            typeContainer.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private TextBox moSearchTxb;
        private DataGridView gridView;
        private Button addBtn;
        private Components.Pagination pagination;
        private TableLayoutPanel typeContainer;
        private Button pldgBtn;
        private Button plspBtn;
        private Button fabricBtn;
        private TableLayoutPanel tableLayoutPanel1;
        private Label titlteLabel;
        private Button button1;
    }
}
