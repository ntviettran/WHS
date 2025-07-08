namespace WHS.Popup
{
    partial class PLDGPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLDGPopup));
            moTxb = new TextBox();
            panel2 = new Panel();
            sampleFileBtn = new Button();
            cancelBtn = new Button();
            saveBtn = new Button();
            addBtn = new Button();
            label9 = new Label();
            gridView = new DataGridView();
            PldgType = new DataGridViewTextBoxColumn();
            PackCode = new DataGridViewTextBoxColumn();
            PoCode = new DataGridViewTextBoxColumn();
            QuantityPerCarton = new DataGridViewTextBoxColumn();
            NetWeight = new DataGridViewTextBoxColumn();
            GrossWeight = new DataGridViewTextBoxColumn();
            color = new DataGridViewTextBoxColumn();
            PldgWeight = new DataGridViewTextBoxColumn();
            WeightUnit = new DataGridViewTextBoxColumn();
            PldgSize = new DataGridViewTextBoxColumn();
            SizeUnit = new DataGridViewTextBoxColumn();
            QuantityToReceived = new DataGridViewTextBoxColumn();
            label8 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            label1 = new Label();
            panel4 = new Panel();
            typeTxb = new TextBox();
            label2 = new Label();
            panel10 = new Panel();
            supplierTxb = new TextBox();
            label6 = new Label();
            panel13 = new Panel();
            quantityTxb = new TextBox();
            label5 = new Label();
            panel11 = new Panel();
            estimateQuantityTxb = new TextBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)_dataTable).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel10.SuspendLayout();
            panel13.SuspendLayout();
            panel11.SuspendLayout();
            SuspendLayout();
            // 
            // moTxb
            // 
            moTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            moTxb.BorderStyle = BorderStyle.FixedSingle;
            moTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            moTxb.Location = new Point(2, 41);
            moTxb.Margin = new Padding(3, 4, 3, 4);
            moTxb.Name = "moTxb";
            moTxb.Size = new Size(256, 38);
            moTxb.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(sampleFileBtn);
            panel2.Controls.Add(cancelBtn);
            panel2.Controls.Add(saveBtn);
            panel2.Controls.Add(addBtn);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(gridView);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(20, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(1067, 692);
            panel2.TabIndex = 2;
            // 
            // sampleFileBtn
            // 
            sampleFileBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sampleFileBtn.BackColor = Color.DeepSkyBlue;
            sampleFileBtn.FlatStyle = FlatStyle.Flat;
            sampleFileBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sampleFileBtn.ForeColor = Color.White;
            sampleFileBtn.Location = new Point(832, 208);
            sampleFileBtn.Name = "sampleFileBtn";
            sampleFileBtn.Size = new Size(122, 45);
            sampleFileBtn.TabIndex = 18;
            sampleFileBtn.Text = "File mẫu";
            sampleFileBtn.UseVisualStyleBackColor = false;
            // 
            // cancelBtn
            // 
            cancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelBtn.BackColor = Color.Red;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelBtn.ForeColor = Color.White;
            cancelBtn.Location = new Point(840, 645);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 45);
            cancelBtn.TabIndex = 14;
            cancelBtn.Text = "Hủy";
            cancelBtn.UseVisualStyleBackColor = false;
            // 
            // saveBtn
            // 
            saveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveBtn.BackColor = Color.DodgerBlue;
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            saveBtn.ForeColor = Color.White;
            saveBtn.Location = new Point(940, 645);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(126, 45);
            saveBtn.TabIndex = 13;
            saveBtn.Text = "Xác nhận";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // addBtn
            // 
            addBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addBtn.BackColor = Color.Green;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(962, 208);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(105, 45);
            addBtn.TabIndex = 5;
            addBtn.Text = "Thêm";
            addBtn.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(-6, 212);
            label9.Name = "label9";
            label9.Size = new Size(322, 41);
            label9.TabIndex = 11;
            label9.Text = "Chi tiết NPL đóng gói";
            // 
            // gridView
            // 
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;
            gridView.AllowUserToResizeRows = false;
            gridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridView.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(0, 10, 0, 10);
            dataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridView.Columns.AddRange(new DataGridViewColumn[] { PldgType, PackCode, PoCode, QuantityPerCarton, NetWeight, GrossWeight, color, PldgWeight, WeightUnit, PldgSize, SizeUnit, QuantityToReceived });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridView.DefaultCellStyle = dataGridViewCellStyle2;
            gridView.EnableHeadersVisualStyles = false;
            gridView.Location = new Point(0, 260);
            gridView.Name = "gridView";
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            gridView.RowTemplate.Height = 35;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.Size = new Size(1067, 356);
            gridView.TabIndex = 10;
            // 
            // PldgType
            // 
            PldgType.DataPropertyName = "PldgType";
            PldgType.HeaderText = "Loại phụ liệu";
            PldgType.MinimumWidth = 6;
            PldgType.Name = "PldgType";
            PldgType.Width = 125;
            // 
            // PackCode
            // 
            PackCode.DataPropertyName = "PackCode";
            PackCode.HeaderText = "Mã pack";
            PackCode.MinimumWidth = 6;
            PackCode.Name = "PackCode";
            PackCode.Width = 125;
            // 
            // PoCode
            // 
            PoCode.DataPropertyName = "PoCode";
            PoCode.HeaderText = "Mã PO";
            PoCode.MinimumWidth = 6;
            PoCode.Name = "PoCode";
            PoCode.Width = 125;
            // 
            // QuantityPerCarton
            // 
            QuantityPerCarton.DataPropertyName = "QuantityPerCarton";
            QuantityPerCarton.HeaderText = "Số lượng mỗi thùng";
            QuantityPerCarton.MinimumWidth = 6;
            QuantityPerCarton.Name = "QuantityPerCarton";
            QuantityPerCarton.Width = 125;
            // 
            // NetWeight
            // 
            NetWeight.DataPropertyName = "NetWeight";
            NetWeight.HeaderText = "N.W";
            NetWeight.MinimumWidth = 6;
            NetWeight.Name = "NetWeight";
            NetWeight.Width = 125;
            // 
            // GrossWeight
            // 
            GrossWeight.DataPropertyName = "GrossWeight";
            GrossWeight.HeaderText = "G.W";
            GrossWeight.MinimumWidth = 6;
            GrossWeight.Name = "GrossWeight";
            GrossWeight.Width = 125;
            // 
            // color
            // 
            color.DataPropertyName = "color";
            color.HeaderText = "Màu";
            color.MinimumWidth = 6;
            color.Name = "color";
            color.Width = 125;
            // 
            // PldgWeight
            // 
            PldgWeight.DataPropertyName = "PldgWeight";
            PldgWeight.HeaderText = "Khối lượng";
            PldgWeight.MinimumWidth = 6;
            PldgWeight.Name = "PldgWeight";
            PldgWeight.Width = 125;
            // 
            // WeightUnit
            // 
            WeightUnit.DataPropertyName = "WeightUnit";
            WeightUnit.HeaderText = "Đơn vị khối lượng";
            WeightUnit.MinimumWidth = 6;
            WeightUnit.Name = "WeightUnit";
            WeightUnit.Width = 125;
            // 
            // PldgSize
            // 
            PldgSize.DataPropertyName = "PldgSize";
            PldgSize.HeaderText = "Kích thước";
            PldgSize.MinimumWidth = 6;
            PldgSize.Name = "PldgSize";
            PldgSize.Width = 125;
            // 
            // SizeUnit
            // 
            SizeUnit.DataPropertyName = "SizeUnit";
            SizeUnit.HeaderText = "Đơn vị kích thước";
            SizeUnit.MinimumWidth = 6;
            SizeUnit.Name = "SizeUnit";
            SizeUnit.Width = 125;
            // 
            // QuantityToReceived
            // 
            QuantityToReceived.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            QuantityToReceived.DataPropertyName = "QuantityToReceived";
            QuantityToReceived.HeaderText = "Số lượng cần nhận";
            QuantityToReceived.MinimumWidth = 6;
            QuantityToReceived.Name = "QuantityToReceived";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(498, 318);
            label8.Name = "label8";
            label8.Size = new Size(0, 20);
            label8.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Controls.Add(panel4, 1, 0);
            tableLayoutPanel1.Controls.Add(panel10, 2, 0);
            tableLayoutPanel1.Controls.Add(panel13, 3, 0);
            tableLayoutPanel1.Controls.Add(panel11, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.00121F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49.9987946F));
            tableLayoutPanel1.Size = new Size(1067, 188);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(moTxb);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(260, 88);
            panel3.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(-1, 6);
            label1.Name = "label1";
            label1.Size = new Size(52, 31);
            label1.TabIndex = 2;
            label1.Text = "MO";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Controls.Add(typeTxb);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(269, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(260, 88);
            panel4.TabIndex = 1;
            // 
            // typeTxb
            // 
            typeTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            typeTxb.BorderStyle = BorderStyle.FixedSingle;
            typeTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeTxb.Location = new Point(3, 42);
            typeTxb.Margin = new Padding(3, 4, 3, 4);
            typeTxb.Name = "typeTxb";
            typeTxb.Size = new Size(254, 38);
            typeTxb.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(-3, 6);
            label2.Name = "label2";
            label2.Size = new Size(145, 31);
            label2.TabIndex = 2;
            label2.Text = "Loại phụ liệu";
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.Controls.Add(supplierTxb);
            panel10.Controls.Add(label6);
            panel10.Location = new Point(535, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(260, 88);
            panel10.TabIndex = 2;
            // 
            // supplierTxb
            // 
            supplierTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            supplierTxb.BorderStyle = BorderStyle.FixedSingle;
            supplierTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            supplierTxb.Location = new Point(3, 42);
            supplierTxb.Margin = new Padding(3, 4, 3, 4);
            supplierTxb.Name = "supplierTxb";
            supplierTxb.Size = new Size(254, 38);
            supplierTxb.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(-2, 5);
            label6.Name = "label6";
            label6.Size = new Size(191, 31);
            label6.TabIndex = 7;
            label6.Text = "Mã nhà cung cấp";
            // 
            // panel13
            // 
            panel13.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel13.Controls.Add(quantityTxb);
            panel13.Controls.Add(label5);
            panel13.Location = new Point(801, 3);
            panel13.Name = "panel13";
            panel13.Size = new Size(263, 88);
            panel13.TabIndex = 3;
            // 
            // quantityTxb
            // 
            quantityTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            quantityTxb.BorderStyle = BorderStyle.FixedSingle;
            quantityTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            quantityTxb.Location = new Point(2, 41);
            quantityTxb.Margin = new Padding(3, 4, 3, 4);
            quantityTxb.Name = "quantityTxb";
            quantityTxb.Size = new Size(259, 38);
            quantityTxb.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(1, 4);
            label5.Name = "label5";
            label5.Size = new Size(205, 31);
            label5.TabIndex = 2;
            label5.Text = "Số lượng cần nhận";
            // 
            // panel11
            // 
            panel11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel11.Controls.Add(estimateQuantityTxb);
            panel11.Controls.Add(label7);
            panel11.Location = new Point(3, 97);
            panel11.Name = "panel11";
            panel11.Size = new Size(260, 88);
            panel11.TabIndex = 4;
            // 
            // estimateQuantityTxb
            // 
            estimateQuantityTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            estimateQuantityTxb.BorderStyle = BorderStyle.FixedSingle;
            estimateQuantityTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            estimateQuantityTxb.Location = new Point(3, 44);
            estimateQuantityTxb.Margin = new Padding(3, 4, 3, 4);
            estimateQuantityTxb.Name = "estimateQuantityTxb";
            estimateQuantityTxb.Size = new Size(254, 38);
            estimateQuantityTxb.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(-2, 9);
            label7.Name = "label7";
            label7.Size = new Size(245, 31);
            label7.TabIndex = 8;
            label7.Text = "Số lượng dự kiến nhận";
            // 
            // PLDGPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 732);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PLDGPopup";
            Padding = new Padding(20);
            Text = "Tạo NPL cần nhận";
            WindowState = FormWindowState.Maximized;
            Load += PLDGPopup_Load;
            ((System.ComponentModel.ISupportInitialize)_dataTable).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox moTxb;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private Label label2;
        private TextBox typeTxb;
        private Panel panel10;
        private Label label5;
        private Panel panel11;
        private Label label8;
        private Label label7;
        private TextBox estimateQuantityTxb;
        private Panel panel13;
        private TextBox quantityTxb;
        private TextBox supplierTxb;
        private Label label6;
        private DataGridView gridView;
        private Label label9;
        private Button addBtn;
        private Button cancelBtn;
        private Button saveBtn;
        private Button sampleFileBtn;
        private DataGridViewTextBoxColumn PldgType;
        private DataGridViewTextBoxColumn PackCode;
        private DataGridViewTextBoxColumn PoCode;
        private DataGridViewTextBoxColumn QuantityPerCarton;
        private DataGridViewTextBoxColumn NetWeight;
        private DataGridViewTextBoxColumn GrossWeight;
        private DataGridViewTextBoxColumn color;
        private DataGridViewTextBoxColumn PldgWeight;
        private DataGridViewTextBoxColumn WeightUnit;
        private DataGridViewTextBoxColumn PldgSize;
        private DataGridViewTextBoxColumn SizeUnit;
        private DataGridViewTextBoxColumn QuantityToReceived;
    }
}