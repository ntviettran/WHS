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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLDGPopup));
            moTxbContainer = new Panel();
            moTxb = new TextBox();
            panel2 = new Panel();
            sampleFileBtn = new Button();
            cancelBtn = new Button();
            button1 = new Button();
            addBtn = new Button();
            label9 = new Label();
            gridView = new DataGridView();
            pldg_type = new DataGridViewTextBoxColumn();
            pack_code = new DataGridViewTextBoxColumn();
            po_code = new DataGridViewTextBoxColumn();
            quantity_per_carton = new DataGridViewTextBoxColumn();
            net_weight = new DataGridViewTextBoxColumn();
            gross_weight = new DataGridViewTextBoxColumn();
            color = new DataGridViewTextBoxColumn();
            pldg_weight = new DataGridViewTextBoxColumn();
            weight_unit = new DataGridViewTextBoxColumn();
            pldg_size = new DataGridViewTextBoxColumn();
            size_unit = new DataGridViewTextBoxColumn();
            label8 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            label1 = new Label();
            panel4 = new Panel();
            label2 = new Label();
            panel5 = new Panel();
            typeTxb = new TextBox();
            panel10 = new Panel();
            panel15 = new Panel();
            supplierTxb = new TextBox();
            label6 = new Label();
            panel13 = new Panel();
            panel16 = new Panel();
            quantityTxb = new TextBox();
            label5 = new Label();
            panel11 = new Panel();
            label7 = new Label();
            panel9 = new Panel();
            estimateQuantityTxb = new TextBox();
            ((System.ComponentModel.ISupportInitialize)_dataTable).BeginInit();
            moTxbContainer.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel10.SuspendLayout();
            panel15.SuspendLayout();
            panel13.SuspendLayout();
            panel16.SuspendLayout();
            panel11.SuspendLayout();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // moTxbContainer
            // 
            moTxbContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            moTxbContainer.AutoSize = true;
            moTxbContainer.BackColor = Color.White;
            moTxbContainer.BorderStyle = BorderStyle.FixedSingle;
            moTxbContainer.Controls.Add(moTxb);
            moTxbContainer.Location = new Point(3, 33);
            moTxbContainer.Margin = new Padding(3, 4, 3, 4);
            moTxbContainer.Name = "moTxbContainer";
            moTxbContainer.Padding = new Padding(5);
            moTxbContainer.Size = new Size(254, 45);
            moTxbContainer.TabIndex = 1;
            // 
            // moTxb
            // 
            moTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            moTxb.BorderStyle = BorderStyle.None;
            moTxb.Location = new Point(9, 12);
            moTxb.Margin = new Padding(3, 4, 3, 4);
            moTxb.Name = "moTxb";
            moTxb.Size = new Size(235, 20);
            moTxb.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(sampleFileBtn);
            panel2.Controls.Add(cancelBtn);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(addBtn);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(gridView);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(20, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(1067, 683);
            panel2.TabIndex = 2;
            // 
            // sampleFileBtn
            // 
            sampleFileBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sampleFileBtn.BackColor = Color.DeepSkyBlue;
            sampleFileBtn.FlatStyle = FlatStyle.Flat;
            sampleFileBtn.ForeColor = Color.White;
            sampleFileBtn.Location = new Point(870, 208);
            sampleFileBtn.Name = "sampleFileBtn";
            sampleFileBtn.Size = new Size(94, 45);
            sampleFileBtn.TabIndex = 18;
            sampleFileBtn.Text = "File mẫu";
            sampleFileBtn.UseVisualStyleBackColor = false;
            // 
            // cancelBtn
            // 
            cancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelBtn.BackColor = Color.Red;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.ForeColor = Color.White;
            cancelBtn.Location = new Point(870, 638);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 45);
            cancelBtn.TabIndex = 14;
            cancelBtn.Text = "Hủy";
            cancelBtn.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.DodgerBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(973, 638);
            button1.Name = "button1";
            button1.Size = new Size(94, 45);
            button1.TabIndex = 13;
            button1.Text = "Xác nhận";
            button1.UseVisualStyleBackColor = false;
            // 
            // addBtn
            // 
            addBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addBtn.BackColor = Color.Green;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(973, 208);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(94, 45);
            addBtn.TabIndex = 5;
            addBtn.Text = "Thêm";
            addBtn.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(-6, 212);
            label9.Name = "label9";
            label9.Size = new Size(300, 38);
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.Padding = new Padding(0, 10, 0, 10);
            dataGridViewCellStyle3.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridView.Columns.AddRange(new DataGridViewColumn[] { pldg_type, pack_code, po_code, quantity_per_carton, net_weight, gross_weight, color, pldg_weight, weight_unit, pldg_size, size_unit });
            gridView.EnableHeadersVisualStyles = false;
            gridView.Location = new Point(0, 260);
            gridView.Name = "gridView";
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            gridView.RowTemplate.Height = 35;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.Size = new Size(1067, 356);
            gridView.TabIndex = 10;
            // 
            // pldg_type
            // 
            pldg_type.HeaderText = "Loại phụ liệu";
            pldg_type.MinimumWidth = 6;
            pldg_type.Name = "pldg_type";
            pldg_type.Width = 125;
            // 
            // pack_code
            // 
            pack_code.HeaderText = "Mã pack";
            pack_code.MinimumWidth = 6;
            pack_code.Name = "pack_code";
            pack_code.Width = 125;
            // 
            // po_code
            // 
            po_code.HeaderText = "Mã PO";
            po_code.MinimumWidth = 6;
            po_code.Name = "po_code";
            po_code.Width = 125;
            // 
            // quantity_per_carton
            // 
            quantity_per_carton.HeaderText = "Số lượng mỗi thùng";
            quantity_per_carton.MinimumWidth = 6;
            quantity_per_carton.Name = "quantity_per_carton";
            quantity_per_carton.Width = 125;
            // 
            // net_weight
            // 
            net_weight.HeaderText = "N.W";
            net_weight.MinimumWidth = 6;
            net_weight.Name = "net_weight";
            net_weight.Width = 125;
            // 
            // gross_weight
            // 
            gross_weight.HeaderText = "G.W";
            gross_weight.MinimumWidth = 6;
            gross_weight.Name = "gross_weight";
            gross_weight.Width = 125;
            // 
            // color
            // 
            color.HeaderText = "Màu";
            color.MinimumWidth = 6;
            color.Name = "color";
            color.Width = 125;
            // 
            // pldg_weight
            // 
            pldg_weight.HeaderText = "Khối lượng";
            pldg_weight.MinimumWidth = 6;
            pldg_weight.Name = "pldg_weight";
            pldg_weight.Width = 125;
            // 
            // weight_unit
            // 
            weight_unit.HeaderText = "Đơn vị khối lượng";
            weight_unit.MinimumWidth = 6;
            weight_unit.Name = "weight_unit";
            weight_unit.Width = 125;
            // 
            // pldg_size
            // 
            pldg_size.HeaderText = "Kích thước";
            pldg_size.MinimumWidth = 6;
            pldg_size.Name = "pldg_size";
            pldg_size.Width = 125;
            // 
            // size_unit
            // 
            size_unit.HeaderText = "Đơn vị kích thước";
            size_unit.MinimumWidth = 6;
            size_unit.Name = "size_unit";
            size_unit.Width = 125;
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
            panel3.Controls.Add(label1);
            panel3.Controls.Add(moTxbContainer);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(260, 88);
            panel3.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 6);
            label1.Name = "label1";
            label1.Size = new Size(33, 20);
            label1.TabIndex = 2;
            label1.Text = "MO";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.AutoSize = true;
            panel4.Controls.Add(label2);
            panel4.Controls.Add(panel5);
            panel4.Location = new Point(269, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(260, 88);
            panel4.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1, 6);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 2;
            label2.Text = "Loại phụ liệu";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.AutoSize = true;
            panel5.BackColor = Color.White;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(typeTxb);
            panel5.Location = new Point(3, 33);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(5);
            panel5.Size = new Size(254, 45);
            panel5.TabIndex = 1;
            // 
            // typeTxb
            // 
            typeTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            typeTxb.BorderStyle = BorderStyle.None;
            typeTxb.Location = new Point(9, 12);
            typeTxb.Margin = new Padding(3, 4, 3, 4);
            typeTxb.Name = "typeTxb";
            typeTxb.Size = new Size(235, 20);
            typeTxb.TabIndex = 1;
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.AutoSize = true;
            panel10.Controls.Add(panel15);
            panel10.Controls.Add(label6);
            panel10.Location = new Point(535, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(260, 88);
            panel10.TabIndex = 2;
            // 
            // panel15
            // 
            panel15.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel15.AutoSize = true;
            panel15.BackColor = Color.White;
            panel15.BorderStyle = BorderStyle.FixedSingle;
            panel15.Controls.Add(supplierTxb);
            panel15.Location = new Point(3, 33);
            panel15.Margin = new Padding(3, 4, 3, 4);
            panel15.Name = "panel15";
            panel15.Padding = new Padding(5);
            panel15.Size = new Size(254, 45);
            panel15.TabIndex = 2;
            // 
            // supplierTxb
            // 
            supplierTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            supplierTxb.BorderStyle = BorderStyle.None;
            supplierTxb.Location = new Point(9, 12);
            supplierTxb.Margin = new Padding(3, 4, 3, 4);
            supplierTxb.Name = "supplierTxb";
            supplierTxb.Size = new Size(235, 20);
            supplierTxb.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 6);
            label6.Name = "label6";
            label6.Size = new Size(122, 20);
            label6.TabIndex = 7;
            label6.Text = "Mã nhà cung cấp";
            // 
            // panel13
            // 
            panel13.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel13.AutoSize = true;
            panel13.Controls.Add(panel16);
            panel13.Controls.Add(label5);
            panel13.Location = new Point(801, 3);
            panel13.Name = "panel13";
            panel13.Size = new Size(263, 88);
            panel13.TabIndex = 3;
            // 
            // panel16
            // 
            panel16.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel16.AutoSize = true;
            panel16.BackColor = Color.White;
            panel16.BorderStyle = BorderStyle.FixedSingle;
            panel16.Controls.Add(quantityTxb);
            panel16.Location = new Point(3, 33);
            panel16.Margin = new Padding(3, 4, 3, 4);
            panel16.Name = "panel16";
            panel16.Padding = new Padding(5);
            panel16.Size = new Size(257, 45);
            panel16.TabIndex = 3;
            // 
            // quantityTxb
            // 
            quantityTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            quantityTxb.BorderStyle = BorderStyle.None;
            quantityTxb.Location = new Point(10, 12);
            quantityTxb.Margin = new Padding(3, 4, 3, 4);
            quantityTxb.Name = "quantityTxb";
            quantityTxb.Size = new Size(235, 20);
            quantityTxb.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1, 6);
            label5.Name = "label5";
            label5.Size = new Size(132, 20);
            label5.TabIndex = 2;
            label5.Text = "Số lượng cần nhận";
            // 
            // panel11
            // 
            panel11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel11.AutoSize = true;
            panel11.Controls.Add(label7);
            panel11.Controls.Add(panel9);
            panel11.Location = new Point(3, 97);
            panel11.Name = "panel11";
            panel11.Size = new Size(260, 88);
            panel11.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 9);
            label7.Name = "label7";
            label7.Size = new Size(158, 20);
            label7.TabIndex = 8;
            label7.Text = "Số lượng dự kiến nhận";
            // 
            // panel9
            // 
            panel9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel9.AutoSize = true;
            panel9.BackColor = Color.White;
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(estimateQuantityTxb);
            panel9.Location = new Point(4, 34);
            panel9.Margin = new Padding(3, 4, 3, 4);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(5);
            panel9.Size = new Size(251, 45);
            panel9.TabIndex = 4;
            // 
            // estimateQuantityTxb
            // 
            estimateQuantityTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            estimateQuantityTxb.BorderStyle = BorderStyle.None;
            estimateQuantityTxb.Location = new Point(7, 12);
            estimateQuantityTxb.Margin = new Padding(3, 4, 3, 4);
            estimateQuantityTxb.Name = "estimateQuantityTxb";
            estimateQuantityTxb.Size = new Size(235, 20);
            estimateQuantityTxb.TabIndex = 4;
            // 
            // PLDGPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 723);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PLDGPopup";
            Padding = new Padding(20);
            Text = "Tạo NPL cần nhận";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)_dataTable).EndInit();
            moTxbContainer.ResumeLayout(false);
            moTxbContainer.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel moTxbContainer;
        private TextBox moTxb;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private Label label2;
        private Panel panel5;
        private TextBox typeTxb;
        private Panel panel10;
        private Label label5;
        private Panel panel11;
        private Label label8;
        private Label label7;
        private Panel panel9;
        private TextBox estimateQuantityTxb;
        private Panel panel13;
        private Panel panel16;
        private TextBox quantityTxb;
        private Panel panel15;
        private TextBox supplierTxb;
        private Label label6;
        private DataGridView gridView;
        private Label label9;
        private Button addBtn;
        private Button cancelBtn;
        private Button button1;
        private DataGridViewTextBoxColumn pldg_type;
        private DataGridViewTextBoxColumn pack_code;
        private DataGridViewTextBoxColumn po_code;
        private DataGridViewTextBoxColumn quantity_per_carton;
        private DataGridViewTextBoxColumn net_weight;
        private DataGridViewTextBoxColumn gross_weight;
        private DataGridViewTextBoxColumn color;
        private DataGridViewTextBoxColumn pldg_weight;
        private DataGridViewTextBoxColumn weight_unit;
        private DataGridViewTextBoxColumn pldg_size;
        private DataGridViewTextBoxColumn size_unit;
        private Button sampleFileBtn;
    }
}