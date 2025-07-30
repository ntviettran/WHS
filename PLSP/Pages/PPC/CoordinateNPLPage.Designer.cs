namespace WHS.Pages.Transfer
{
    partial class CoordinateNPLPage
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            pagination = new WHS.Components.Pagination();
            gridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            PlanExecDateVN = new DataGridViewTextBoxColumn();
            ExecDateVN = new DataGridViewTextBoxColumn();
            PlanWarehouseDateVN = new DataGridViewTextBoxColumn();
            WarehouseDateVN = new DataGridViewTextBoxColumn();
            ExecStatusDescription = new DataGridViewTextBoxColumn();
            TransferStatusDescription = new DataGridViewTextBoxColumn();
            CreatedAtVN = new DataGridViewTextBoxColumn();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel8 = new Panel();
            statusCb = new ComboBox();
            label5 = new Label();
            panel5 = new Panel();
            warehouseDatePicker = new DateTimePicker();
            label3 = new Label();
            panel12 = new Panel();
            execDatePicker = new DateTimePicker();
            label6 = new Label();
            panel3 = new Panel();
            esWarehouseDatePicker = new DateTimePicker();
            label1 = new Label();
            panel10 = new Panel();
            esExecDatePicker = new DateTimePicker();
            label4 = new Label();
            panel2 = new Panel();
            idTxb = new TextBox();
            label2 = new Label();
            panel14 = new Panel();
            addBtn = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            label7 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            cancelToolStrip = new ToolStripMenuItem();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel8.SuspendLayout();
            panel5.SuspendLayout();
            panel12.SuspendLayout();
            panel3.SuspendLayout();
            panel10.SuspendLayout();
            panel2.SuspendLayout();
            panel14.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pagination);
            panel1.Controls.Add(gridView);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(tableLayoutPanel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(966, 551);
            panel1.TabIndex = 12;
            // 
            // pagination
            // 
            pagination.Dock = DockStyle.Bottom;
            pagination.Location = new Point(0, 502);
            pagination.Name = "pagination";
            pagination.Size = new Size(966, 49);
            pagination.TabIndex = 15;
            // 
            // gridView
            // 
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;
            gridView.AllowUserToResizeRows = false;
            gridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridView.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.Padding = new Padding(0, 10, 0, 10);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridView.Columns.AddRange(new DataGridViewColumn[] { ID, PlanExecDateVN, ExecDateVN, PlanWarehouseDateVN, WarehouseDateVN, ExecStatusDescription, TransferStatusDescription, CreatedAtVN });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            gridView.DefaultCellStyle = dataGridViewCellStyle4;
            gridView.EnableHeadersVisualStyles = false;
            gridView.Location = new Point(0, 294);
            gridView.Name = "gridView";
            gridView.ReadOnly = true;
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.RowTemplate.Height = 35;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.Size = new Size(966, 202);
            gridView.TabIndex = 14;
            gridView.CellMouseDoubleClick += gridView_CellMouseDoubleClick;
            // 
            // ID
            // 
            ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // PlanExecDateVN
            // 
            PlanExecDateVN.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PlanExecDateVN.DataPropertyName = "PlanExecDateVN";
            PlanExecDateVN.HeaderText = "Ngày dự kiến thực hiện";
            PlanExecDateVN.MinimumWidth = 6;
            PlanExecDateVN.Name = "PlanExecDateVN";
            PlanExecDateVN.ReadOnly = true;
            // 
            // ExecDateVN
            // 
            ExecDateVN.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ExecDateVN.DataPropertyName = "ExecDateVN";
            ExecDateVN.HeaderText = "Ngày thực hiện";
            ExecDateVN.MinimumWidth = 6;
            ExecDateVN.Name = "ExecDateVN";
            ExecDateVN.ReadOnly = true;
            // 
            // PlanWarehouseDateVN
            // 
            PlanWarehouseDateVN.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PlanWarehouseDateVN.DataPropertyName = "PlanWarehouseDateVN";
            PlanWarehouseDateVN.HeaderText = "Ngày dự kiến nhập kho";
            PlanWarehouseDateVN.MinimumWidth = 6;
            PlanWarehouseDateVN.Name = "PlanWarehouseDateVN";
            PlanWarehouseDateVN.ReadOnly = true;
            // 
            // WarehouseDateVN
            // 
            WarehouseDateVN.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            WarehouseDateVN.DataPropertyName = "WarehouseDateVN";
            WarehouseDateVN.HeaderText = "Ngày nhập kho";
            WarehouseDateVN.MinimumWidth = 6;
            WarehouseDateVN.Name = "WarehouseDateVN";
            WarehouseDateVN.ReadOnly = true;
            // 
            // ExecStatusDescription
            // 
            ExecStatusDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ExecStatusDescription.DataPropertyName = "ExecStatusDescription";
            ExecStatusDescription.HeaderText = "Trạng thái thực hiện";
            ExecStatusDescription.MinimumWidth = 6;
            ExecStatusDescription.Name = "ExecStatusDescription";
            ExecStatusDescription.ReadOnly = true;
            // 
            // TransferStatusDescription
            // 
            TransferStatusDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TransferStatusDescription.DataPropertyName = "TransferStatusDescription";
            TransferStatusDescription.HeaderText = "Trạng thái chuyển";
            TransferStatusDescription.MinimumWidth = 6;
            TransferStatusDescription.Name = "TransferStatusDescription";
            TransferStatusDescription.ReadOnly = true;
            // 
            // CreatedAtVN
            // 
            CreatedAtVN.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CreatedAtVN.DataPropertyName = "CreatedAtVN";
            CreatedAtVN.HeaderText = "Ngày tạo";
            CreatedAtVN.MinimumWidth = 6;
            CreatedAtVN.Name = "CreatedAtVN";
            CreatedAtVN.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel14, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 83);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(966, 166);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(panel8, 2, 1);
            tableLayoutPanel2.Controls.Add(panel5, 1, 1);
            tableLayoutPanel2.Controls.Add(panel12, 0, 1);
            tableLayoutPanel2.Controls.Add(panel3, 2, 0);
            tableLayoutPanel2.Controls.Add(panel10, 1, 0);
            tableLayoutPanel2.Controls.Add(panel2, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(815, 160);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel8
            // 
            panel8.AutoSize = true;
            panel8.Controls.Add(statusCb);
            panel8.Controls.Add(label5);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(545, 83);
            panel8.Name = "panel8";
            panel8.Size = new Size(267, 74);
            panel8.TabIndex = 23;
            // 
            // statusCb
            // 
            statusCb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            statusCb.DropDownHeight = 400;
            statusCb.DropDownStyle = ComboBoxStyle.DropDownList;
            statusCb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusCb.FormattingEnabled = true;
            statusCb.IntegralHeight = false;
            statusCb.ItemHeight = 31;
            statusCb.Location = new Point(3, 35);
            statusCb.Name = "statusCb";
            statusCb.Size = new Size(264, 39);
            statusCb.TabIndex = 5;
            statusCb.SelectionChangeCommitted += statusCb_SelectionChangeCommitted;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(-1, 3);
            label5.Name = "label5";
            label5.Size = new Size(204, 28);
            label5.TabIndex = 19;
            label5.Text = "Trạng thái thực hiện";
            // 
            // panel5
            // 
            panel5.AutoSize = true;
            panel5.Controls.Add(warehouseDatePicker);
            panel5.Controls.Add(label3);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(274, 83);
            panel5.Name = "panel5";
            panel5.Size = new Size(265, 74);
            panel5.TabIndex = 25;
            // 
            // warehouseDatePicker
            // 
            warehouseDatePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            warehouseDatePicker.Checked = false;
            warehouseDatePicker.CustomFormat = "dd/MM/yyyy";
            warehouseDatePicker.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            warehouseDatePicker.Format = DateTimePickerFormat.Custom;
            warehouseDatePicker.Location = new Point(3, 35);
            warehouseDatePicker.Margin = new Padding(0);
            warehouseDatePicker.Name = "warehouseDatePicker";
            warehouseDatePicker.ShowCheckBox = true;
            warehouseDatePicker.Size = new Size(260, 38);
            warehouseDatePicker.TabIndex = 17;
            warehouseDatePicker.ValueChanged += warehouseDatePicker_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(-1, 3);
            label3.Name = "label3";
            label3.Size = new Size(131, 28);
            label3.TabIndex = 19;
            label3.Text = "Ngày về kho";
            // 
            // panel12
            // 
            panel12.AutoSize = true;
            panel12.Controls.Add(execDatePicker);
            panel12.Controls.Add(label6);
            panel12.Dock = DockStyle.Fill;
            panel12.Location = new Point(3, 83);
            panel12.Name = "panel12";
            panel12.Size = new Size(265, 74);
            panel12.TabIndex = 26;
            // 
            // execDatePicker
            // 
            execDatePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            execDatePicker.Checked = false;
            execDatePicker.CustomFormat = "dd/MM/yyyy";
            execDatePicker.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            execDatePicker.Format = DateTimePickerFormat.Custom;
            execDatePicker.Location = new Point(3, 35);
            execDatePicker.Margin = new Padding(0);
            execDatePicker.Name = "execDatePicker";
            execDatePicker.ShowCheckBox = true;
            execDatePicker.Size = new Size(261, 38);
            execDatePicker.TabIndex = 16;
            execDatePicker.ValueChanged += execDatePicker_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(-1, 2);
            label6.Name = "label6";
            label6.Size = new Size(158, 28);
            label6.TabIndex = 19;
            label6.Text = "Ngày thực hiện";
            // 
            // panel3
            // 
            panel3.AutoSize = true;
            panel3.Controls.Add(esWarehouseDatePicker);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(545, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(267, 74);
            panel3.TabIndex = 27;
            // 
            // esWarehouseDatePicker
            // 
            esWarehouseDatePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            esWarehouseDatePicker.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            esWarehouseDatePicker.Checked = false;
            esWarehouseDatePicker.CustomFormat = "dd/MM/yyyy";
            esWarehouseDatePicker.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            esWarehouseDatePicker.Format = DateTimePickerFormat.Custom;
            esWarehouseDatePicker.Location = new Point(3, 33);
            esWarehouseDatePicker.Margin = new Padding(0);
            esWarehouseDatePicker.Name = "esWarehouseDatePicker";
            esWarehouseDatePicker.ShowCheckBox = true;
            esWarehouseDatePicker.Size = new Size(264, 38);
            esWarehouseDatePicker.TabIndex = 16;
            esWarehouseDatePicker.ValueChanged += esWarehouseDatePicker_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(-1, 2);
            label1.Name = "label1";
            label1.Size = new Size(208, 28);
            label1.TabIndex = 19;
            label1.Text = "Ngày dự kiến về kho";
            // 
            // panel10
            // 
            panel10.AutoSize = true;
            panel10.Controls.Add(esExecDatePicker);
            panel10.Controls.Add(label4);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(274, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(265, 74);
            panel10.TabIndex = 26;
            // 
            // esExecDatePicker
            // 
            esExecDatePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            esExecDatePicker.Checked = false;
            esExecDatePicker.CustomFormat = "dd/MM/yyyy";
            esExecDatePicker.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            esExecDatePicker.Format = DateTimePickerFormat.Custom;
            esExecDatePicker.Location = new Point(3, 33);
            esExecDatePicker.Margin = new Padding(0);
            esExecDatePicker.Name = "esExecDatePicker";
            esExecDatePicker.ShowCheckBox = true;
            esExecDatePicker.Size = new Size(260, 38);
            esExecDatePicker.TabIndex = 16;
            esExecDatePicker.ValueChanged += esExecDatePicker_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(-1, 2);
            label4.Name = "label4";
            label4.Size = new Size(235, 28);
            label4.TabIndex = 19;
            label4.Text = "Ngày dự kiến thực hiện";
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(idTxb);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(265, 74);
            panel2.TabIndex = 24;
            // 
            // idTxb
            // 
            idTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            idTxb.BorderStyle = BorderStyle.FixedSingle;
            idTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idTxb.Location = new Point(0, 31);
            idTxb.Margin = new Padding(3, 4, 3, 4);
            idTxb.Name = "idTxb";
            idTxb.Size = new Size(264, 38);
            idTxb.TabIndex = 0;
            idTxb.KeyDown += idTxb_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(-1, 1);
            label2.Name = "label2";
            label2.Size = new Size(147, 28);
            label2.TabIndex = 19;
            label2.Text = "ID đợt chuyển";
            // 
            // panel14
            // 
            panel14.Controls.Add(addBtn);
            panel14.Dock = DockStyle.Fill;
            panel14.Location = new Point(824, 3);
            panel14.Name = "panel14";
            panel14.Size = new Size(139, 160);
            panel14.TabIndex = 1;
            // 
            // addBtn
            // 
            addBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            addBtn.BackColor = Color.FromArgb(0, 46, 92);
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(0, 59);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(136, 61);
            addBtn.TabIndex = 14;
            addBtn.Text = "Tạo mới";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(label7, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Top;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(966, 83);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(219, 0);
            label7.Name = "label7";
            label7.Size = new Size(528, 54);
            label7.TabIndex = 0;
            label7.Text = "DANH SÁCH ĐỢT CHUYỂN";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { cancelToolStrip });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(105, 28);
            // 
            // cancelToolStrip
            // 
            cancelToolStrip.Name = "cancelToolStrip";
            cancelToolStrip.Size = new Size(104, 24);
            cancelToolStrip.Text = "Hủy";
            cancelToolStrip.Click += cancelToolStrip_Click;
            // 
            // CoordinateNPLPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "CoordinateNPLPage";
            Padding = new Padding(20, 20, 20, 10);
            Size = new Size(1006, 581);
            Load += TransferNPLPage_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel14.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label7;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel8;
        private Label label5;
        private Panel panel5;
        private Label label3;
        private Panel panel12;
        private Label label6;
        private Panel panel3;
        private Label label1;
        private Panel panel10;
        private Label label4;
        private Panel panel2;
        private Label label2;
        private TextBox idTxb;
        private Panel panel14;
        private Button addBtn;
        private DataGridView gridView;
        private Components.Pagination pagination;
        private DateTimePicker esExecDatePicker;
        private DateTimePicker execDatePicker;
        private DateTimePicker esWarehouseDatePicker;
        private ComboBox statusCb;
        private DateTimePicker warehouseDatePicker;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn PlanExecDateVN;
        private DataGridViewTextBoxColumn ExecDateVN;
        private DataGridViewTextBoxColumn PlanWarehouseDateVN;
        private DataGridViewTextBoxColumn WarehouseDateVN;
        private DataGridViewTextBoxColumn ExecStatusDescription;
        private DataGridViewTextBoxColumn TransferStatusDescription;
        private DataGridViewTextBoxColumn CreatedAtVN;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem cancelToolStrip;
    }
}
