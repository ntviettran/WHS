namespace WHS.Pages
{
    partial class POPage
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
            txtSearchPO = new TextBox();
            label2 = new Label();
            addBtn = new Button();
            pagination = new WHS.Components.Pagination();
            gridView = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            Po = new DataGridViewTextBoxColumn();
            Mo = new DataGridViewTextBoxColumn();
            CountryCode = new DataGridViewTextBoxColumn();
            IDItem = new DataGridViewTextBoxColumn();
            tableLayoutPanel1 = new TableLayoutPanel();
            titlteLabel = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txtSearchPO);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(addBtn);
            panel1.Controls.Add(pagination);
            panel1.Controls.Add(gridView);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(865, 533);
            panel1.TabIndex = 0;
            // 
            // txtSearchPO
            // 
            txtSearchPO.BorderStyle = BorderStyle.FixedSingle;
            txtSearchPO.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchPO.Location = new Point(56, 104);
            txtSearchPO.Margin = new Padding(3, 4, 3, 4);
            txtSearchPO.Name = "txtSearchPO";
            txtSearchPO.Size = new Size(225, 38);
            txtSearchPO.TabIndex = 16;
            txtSearchPO.KeyDown += txtSearchPO_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(5, 106);
            label2.Name = "label2";
            label2.Size = new Size(45, 31);
            label2.TabIndex = 17;
            label2.Text = "PO";
            // 
            // addBtn
            // 
            addBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addBtn.BackColor = Color.FromArgb(0, 46, 92);
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(734, 98);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(130, 47);
            addBtn.TabIndex = 15;
            addBtn.Text = "Tạo mới";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // pagination
            // 
            pagination.Dock = DockStyle.Bottom;
            pagination.Location = new Point(0, 487);
            pagination.Name = "pagination";
            pagination.Size = new Size(865, 46);
            pagination.TabIndex = 14;
            // 
            // gridView
            // 
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;
            gridView.AllowUserToResizeRows = false;
            gridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridView.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(0, 10, 0, 10);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridView.Columns.AddRange(new DataGridViewColumn[] { id, Po, Mo, CountryCode, IDItem });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridView.DefaultCellStyle = dataGridViewCellStyle2;
            gridView.EnableHeadersVisualStyles = false;
            gridView.Location = new Point(3, 162);
            gridView.Name = "gridView";
            gridView.ReadOnly = true;
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            gridView.RowTemplate.Height = 35;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.Size = new Size(862, 319);
            gridView.TabIndex = 13;
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
            // Po
            // 
            Po.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Po.DataPropertyName = "PO";
            Po.HeaderText = "Po";
            Po.MinimumWidth = 6;
            Po.Name = "Po";
            Po.ReadOnly = true;
            // 
            // Mo
            // 
            Mo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Mo.DataPropertyName = "MO";
            Mo.HeaderText = "Mo";
            Mo.MinimumWidth = 6;
            Mo.Name = "Mo";
            Mo.ReadOnly = true;
            // 
            // CountryCode
            // 
            CountryCode.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CountryCode.DataPropertyName = "CountryCode";
            CountryCode.HeaderText = "Mã nước";
            CountryCode.MinimumWidth = 6;
            CountryCode.Name = "CountryCode";
            CountryCode.ReadOnly = true;
            // 
            // IDItem
            // 
            IDItem.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            IDItem.DataPropertyName = "IDItem";
            IDItem.HeaderText = "Id Item";
            IDItem.MinimumWidth = 6;
            IDItem.Name = "IDItem";
            IDItem.ReadOnly = true;
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
            tableLayoutPanel1.Size = new Size(865, 83);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // titlteLabel
            // 
            titlteLabel.Anchor = AnchorStyles.Top;
            titlteLabel.AutoSize = true;
            titlteLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titlteLabel.ForeColor = Color.Black;
            titlteLabel.Location = new Point(393, 0);
            titlteLabel.Name = "titlteLabel";
            titlteLabel.Size = new Size(78, 54);
            titlteLabel.TabIndex = 0;
            titlteLabel.Text = "PO";
            // 
            // POPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "POPage";
            Padding = new Padding(20);
            Size = new Size(905, 573);
            Load += POPage_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label titlteLabel;
        private DataGridView gridView;
        private Components.Pagination pagination;
        private Button addBtn;
        private TextBox txtSearchPO;
        private Label label2;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn Po;
        private DataGridViewTextBoxColumn Mo;
        private DataGridViewTextBoxColumn CountryCode;
        private DataGridViewTextBoxColumn IDItem;
    }
}
