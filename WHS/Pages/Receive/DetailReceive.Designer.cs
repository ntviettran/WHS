namespace WHS.Pages.Receive
{
    partial class DetailReceive
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
            moSearchTxb = new TextBox();
            pagination = new WHS.Components.Pagination();
            addBtn = new Button();
            gridView = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            mo = new DataGridViewTextBoxColumn();
            style = new DataGridViewTextBoxColumn();
            color = new DataGridViewTextBoxColumn();
            typeDetail = new DataGridViewTextBoxColumn();
            supplier = new DataGridViewTextBoxColumn();
            quantityToReceive = new DataGridViewTextBoxColumn();
            quantityReceived = new DataGridViewTextBoxColumn();
            QuantityEstimate = new DataGridViewTextBoxColumn();
            label2 = new Label();
            panel2 = new Panel();
            typeContainer = new TableLayoutPanel();
            pldgBtn = new Button();
            plspBtn = new Button();
            fabricBtn = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            typeContainer.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
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
            addBtn.BackColor = Color.Green;
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(0, 10, 0, 10);
            dataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridView.Columns.AddRange(new DataGridViewColumn[] { id, mo, style, color, typeDetail, supplier, quantityToReceive, quantityReceived, QuantityEstimate });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridView.DefaultCellStyle = dataGridViewCellStyle2;
            gridView.EnableHeadersVisualStyles = false;
            gridView.Location = new Point(1, 233);
            gridView.Name = "gridView";
            gridView.ReadOnly = true;
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            gridView.RowTemplate.Height = 35;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.Size = new Size(947, 427);
            gridView.TabIndex = 12;
            gridView.CellMouseDoubleClick += gridView_CellMouseDoubleClick;
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            id.DataPropertyName = "id";
            id.HeaderText = "ID";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.ReadOnly = true;
            // 
            // mo
            // 
            mo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            mo.DataPropertyName = "mo";
            mo.HeaderText = "MO";
            mo.MinimumWidth = 6;
            mo.Name = "mo";
            mo.ReadOnly = true;
            // 
            // style
            // 
            style.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            style.DataPropertyName = "style";
            style.HeaderText = "Style";
            style.MinimumWidth = 6;
            style.Name = "style";
            style.ReadOnly = true;
            // 
            // color
            // 
            color.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            color.DataPropertyName = "color";
            color.HeaderText = "Màu";
            color.MinimumWidth = 6;
            color.Name = "color";
            color.ReadOnly = true;
            // 
            // typeDetail
            // 
            typeDetail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            typeDetail.DataPropertyName = "TypeDetail";
            typeDetail.HeaderText = "Loại Vải";
            typeDetail.MinimumWidth = 6;
            typeDetail.Name = "typeDetail";
            typeDetail.ReadOnly = true;
            // 
            // supplier
            // 
            supplier.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            supplier.DataPropertyName = "supplier";
            supplier.HeaderText = "Nhà cung cấp";
            supplier.MinimumWidth = 6;
            supplier.Name = "supplier";
            supplier.ReadOnly = true;
            // 
            // quantityToReceive
            // 
            quantityToReceive.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            quantityToReceive.DataPropertyName = "quantityToReceive";
            quantityToReceive.HeaderText = "Số lượng cần nhận";
            quantityToReceive.MinimumWidth = 6;
            quantityToReceive.Name = "quantityToReceive";
            quantityToReceive.ReadOnly = true;
            // 
            // quantityReceived
            // 
            quantityReceived.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            quantityReceived.DataPropertyName = "quantityReceived";
            quantityReceived.HeaderText = "Số lượng đã nhận";
            quantityReceived.MinimumWidth = 6;
            quantityReceived.Name = "quantityReceived";
            quantityReceived.ReadOnly = true;
            // 
            // QuantityEstimate
            // 
            QuantityEstimate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            QuantityEstimate.DataPropertyName = "QuantityEstimate";
            QuantityEstimate.HeaderText = "Số lượng dự kiến nhận";
            QuantityEstimate.MinimumWidth = 6;
            QuantityEstimate.Name = "QuantityEstimate";
            QuantityEstimate.ReadOnly = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(-3, 166);
            label2.Name = "label2";
            label2.Size = new Size(53, 31);
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
            fabricBtn.BackColor = Color.DodgerBlue;
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
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(948, 83);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(309, 0);
            label1.Name = "label1";
            label1.Size = new Size(330, 54);
            label1.TabIndex = 0;
            label1.Text = "NPL CẦN NHẬN";
            // 
            // DetailReceive
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(panel1);
            Name = "DetailReceive";
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
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel typeContainer;
        private Button pldgBtn;
        private Button plspBtn;
        private Button fabricBtn;
        private Panel panel2;
        private Label label2;
        private TextBox moSearchTxb;
        private DataGridView gridView;
        private Button addBtn;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn mo;
        private DataGridViewTextBoxColumn style;
        private DataGridViewTextBoxColumn color;
        private DataGridViewTextBoxColumn typeDetail;
        private DataGridViewTextBoxColumn supplier;
        private DataGridViewTextBoxColumn quantityToReceive;
        private DataGridViewTextBoxColumn quantityReceived;
        private DataGridViewTextBoxColumn QuantityEstimate;
        private Components.Pagination pagination;
    }
}
