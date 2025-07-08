namespace WHS.Popup
{
    partial class FabricPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FabricPopup));
            moTxb = new TextBox();
            panel2 = new Panel();
            panel14 = new Panel();
            label9 = new Label();
            saveBtn = new Button();
            cancelBtn = new Button();
            sampleFileBtn = new Button();
            addBtn = new Button();
            gridView = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            fabricNumber = new DataGridViewTextBoxColumn();
            style = new DataGridViewTextBoxColumn();
            color = new DataGridViewTextBoxColumn();
            fabricType = new DataGridViewTextBoxColumn();
            batch = new DataGridViewTextBoxColumn();
            fabricLength = new DataGridViewTextBoxColumn();
            lengthUnit = new DataGridViewTextBoxColumn();
            fabricWeight = new DataGridViewTextBoxColumn();
            weightUnit = new DataGridViewTextBoxColumn();
            rollWidth = new DataGridViewTextBoxColumn();
            widthUnit = new DataGridViewTextBoxColumn();
            QuantityToReceived = new DataGridViewTextBoxColumn();
            label8 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel13 = new Panel();
            quantityTxb = new TextBox();
            label5 = new Label();
            panel3 = new Panel();
            label1 = new Label();
            panel11 = new Panel();
            estimateQuantityTxb = new TextBox();
            label7 = new Label();
            panel8 = new Panel();
            fabricTypeTxb = new TextBox();
            label4 = new Label();
            panel4 = new Panel();
            styleTxb = new TextBox();
            label2 = new Label();
            panel6 = new Panel();
            colorTxb = new TextBox();
            label3 = new Label();
            panel10 = new Panel();
            supplierTxb = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)_dataTable).BeginInit();
            panel2.SuspendLayout();
            panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel13.SuspendLayout();
            panel3.SuspendLayout();
            panel11.SuspendLayout();
            panel8.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panel10.SuspendLayout();
            SuspendLayout();
            // 
            // moTxb
            // 
            moTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            moTxb.BorderStyle = BorderStyle.FixedSingle;
            moTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            moTxb.Location = new Point(3, 46);
            moTxb.Margin = new Padding(3, 4, 3, 4);
            moTxb.Name = "moTxb";
            moTxb.Size = new Size(254, 38);
            moTxb.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(panel14);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(20, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(1067, 699);
            panel2.TabIndex = 2;
            // 
            // panel14
            // 
            panel14.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel14.Controls.Add(label9);
            panel14.Controls.Add(saveBtn);
            panel14.Controls.Add(cancelBtn);
            panel14.Controls.Add(sampleFileBtn);
            panel14.Controls.Add(addBtn);
            panel14.Controls.Add(gridView);
            panel14.Location = new Point(0, 188);
            panel14.Name = "panel14";
            panel14.Size = new Size(1067, 508);
            panel14.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(0, 17);
            label9.Name = "label9";
            label9.Size = new Size(235, 41);
            label9.TabIndex = 11;
            label9.Text = "Chi tiết NPL vải";
            // 
            // saveBtn
            // 
            saveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveBtn.BackColor = Color.DodgerBlue;
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            saveBtn.ForeColor = Color.White;
            saveBtn.Location = new Point(937, 460);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(130, 45);
            saveBtn.TabIndex = 15;
            saveBtn.Text = "Xác nhận";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelBtn.BackColor = Color.Red;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelBtn.ForeColor = Color.White;
            cancelBtn.Location = new Point(835, 460);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 45);
            cancelBtn.TabIndex = 16;
            cancelBtn.Text = "Hủy";
            cancelBtn.UseVisualStyleBackColor = false;
            // 
            // sampleFileBtn
            // 
            sampleFileBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sampleFileBtn.BackColor = Color.DeepSkyBlue;
            sampleFileBtn.FlatStyle = FlatStyle.Flat;
            sampleFileBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sampleFileBtn.ForeColor = Color.White;
            sampleFileBtn.Location = new Point(835, 16);
            sampleFileBtn.Name = "sampleFileBtn";
            sampleFileBtn.Size = new Size(117, 45);
            sampleFileBtn.TabIndex = 17;
            sampleFileBtn.Text = "File mẫu";
            sampleFileBtn.UseVisualStyleBackColor = false;
            // 
            // addBtn
            // 
            addBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addBtn.BackColor = Color.Green;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(958, 15);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(106, 45);
            addBtn.TabIndex = 7;
            addBtn.Text = "Thêm";
            addBtn.UseVisualStyleBackColor = false;
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
            gridView.Columns.AddRange(new DataGridViewColumn[] { id, fabricNumber, style, color, fabricType, batch, fabricLength, lengthUnit, fabricWeight, weightUnit, rollWidth, widthUnit, QuantityToReceived });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridView.DefaultCellStyle = dataGridViewCellStyle2;
            gridView.EnableHeadersVisualStyles = false;
            gridView.Location = new Point(0, 81);
            gridView.Name = "gridView";
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            gridView.RowTemplate.Height = 35;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.Size = new Size(1067, 351);
            gridView.TabIndex = 10;
            // 
            // id
            // 
            id.DataPropertyName = "id";
            id.HeaderText = "ID";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.Visible = false;
            id.Width = 125;
            // 
            // fabricNumber
            // 
            fabricNumber.DataPropertyName = "fabricNumber";
            fabricNumber.HeaderText = "Cuộn số";
            fabricNumber.MinimumWidth = 6;
            fabricNumber.Name = "fabricNumber";
            fabricNumber.Width = 125;
            // 
            // style
            // 
            style.DataPropertyName = "style";
            style.HeaderText = "Style";
            style.MinimumWidth = 6;
            style.Name = "style";
            style.Width = 125;
            // 
            // color
            // 
            color.DataPropertyName = "color";
            color.HeaderText = "Màu";
            color.MinimumWidth = 6;
            color.Name = "color";
            color.Width = 125;
            // 
            // fabricType
            // 
            fabricType.DataPropertyName = "fabricType";
            fabricType.HeaderText = "Loại vải";
            fabricType.MinimumWidth = 6;
            fabricType.Name = "fabricType";
            fabricType.Width = 125;
            // 
            // batch
            // 
            batch.DataPropertyName = "batch";
            batch.HeaderText = "Lót";
            batch.MinimumWidth = 6;
            batch.Name = "batch";
            batch.Width = 125;
            // 
            // fabricLength
            // 
            fabricLength.DataPropertyName = "fabricLength";
            fabricLength.HeaderText = "Chiều dài";
            fabricLength.MinimumWidth = 6;
            fabricLength.Name = "fabricLength";
            fabricLength.Width = 125;
            // 
            // lengthUnit
            // 
            lengthUnit.DataPropertyName = "lengthUnit";
            lengthUnit.HeaderText = "Đơn vị chiều dài";
            lengthUnit.MinimumWidth = 6;
            lengthUnit.Name = "lengthUnit";
            lengthUnit.Width = 125;
            // 
            // fabricWeight
            // 
            fabricWeight.DataPropertyName = "fabricWeight";
            fabricWeight.HeaderText = "Khối lượng";
            fabricWeight.MinimumWidth = 6;
            fabricWeight.Name = "fabricWeight";
            fabricWeight.Width = 125;
            // 
            // weightUnit
            // 
            weightUnit.DataPropertyName = "weightUnit";
            weightUnit.HeaderText = "Đơn vị khối lượng";
            weightUnit.MinimumWidth = 6;
            weightUnit.Name = "weightUnit";
            weightUnit.Width = 125;
            // 
            // rollWidth
            // 
            rollWidth.DataPropertyName = "rollWidth";
            rollWidth.HeaderText = "Khổ";
            rollWidth.MinimumWidth = 6;
            rollWidth.Name = "rollWidth";
            rollWidth.Width = 125;
            // 
            // widthUnit
            // 
            widthUnit.DataPropertyName = "widthUnit";
            widthUnit.HeaderText = "Đơn vị khổ";
            widthUnit.MinimumWidth = 6;
            widthUnit.Name = "widthUnit";
            widthUnit.Width = 125;
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
            tableLayoutPanel1.Controls.Add(panel13, 1, 1);
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Controls.Add(panel11, 2, 1);
            tableLayoutPanel1.Controls.Add(panel8, 3, 0);
            tableLayoutPanel1.Controls.Add(panel4, 1, 0);
            tableLayoutPanel1.Controls.Add(panel6, 2, 0);
            tableLayoutPanel1.Controls.Add(panel10, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.00121F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49.9987946F));
            tableLayoutPanel1.Size = new Size(1067, 188);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel13
            // 
            panel13.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel13.Controls.Add(quantityTxb);
            panel13.Controls.Add(label5);
            panel13.Location = new Point(269, 97);
            panel13.Name = "panel13";
            panel13.Size = new Size(260, 88);
            panel13.TabIndex = 5;
            // 
            // quantityTxb
            // 
            quantityTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            quantityTxb.BorderStyle = BorderStyle.FixedSingle;
            quantityTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            quantityTxb.Location = new Point(3, 46);
            quantityTxb.Margin = new Padding(3, 4, 3, 4);
            quantityTxb.Name = "quantityTxb";
            quantityTxb.Size = new Size(255, 38);
            quantityTxb.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(-1, 7);
            label5.Name = "label5";
            label5.Size = new Size(205, 31);
            label5.TabIndex = 2;
            label5.Text = "Số lượng cần nhận";
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
            label1.Location = new Point(3, 11);
            label1.Name = "label1";
            label1.Size = new Size(52, 31);
            label1.TabIndex = 2;
            label1.Text = "MO";
            // 
            // panel11
            // 
            panel11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel11.Controls.Add(estimateQuantityTxb);
            panel11.Controls.Add(label7);
            panel11.Location = new Point(535, 97);
            panel11.Name = "panel11";
            panel11.Size = new Size(260, 88);
            panel11.TabIndex = 6;
            // 
            // estimateQuantityTxb
            // 
            estimateQuantityTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            estimateQuantityTxb.BorderStyle = BorderStyle.FixedSingle;
            estimateQuantityTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            estimateQuantityTxb.Location = new Point(4, 46);
            estimateQuantityTxb.Margin = new Padding(3, 4, 3, 4);
            estimateQuantityTxb.Name = "estimateQuantityTxb";
            estimateQuantityTxb.Size = new Size(252, 38);
            estimateQuantityTxb.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(-1, 7);
            label7.Name = "label7";
            label7.Size = new Size(245, 31);
            label7.TabIndex = 8;
            label7.Text = "Số lượng dự kiến nhận";
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel8.Controls.Add(fabricTypeTxb);
            panel8.Controls.Add(label4);
            panel8.Location = new Point(801, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(263, 88);
            panel8.TabIndex = 3;
            // 
            // fabricTypeTxb
            // 
            fabricTypeTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fabricTypeTxb.BorderStyle = BorderStyle.FixedSingle;
            fabricTypeTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fabricTypeTxb.Location = new Point(2, 45);
            fabricTypeTxb.Margin = new Padding(3, 4, 3, 4);
            fabricTypeTxb.Name = "fabricTypeTxb";
            fabricTypeTxb.Size = new Size(260, 38);
            fabricTypeTxb.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(1, 8);
            label4.Name = "label4";
            label4.Size = new Size(91, 31);
            label4.TabIndex = 2;
            label4.Text = "Loại vải";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Controls.Add(styleTxb);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(269, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(260, 88);
            panel4.TabIndex = 1;
            // 
            // styleTxb
            // 
            styleTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            styleTxb.BorderStyle = BorderStyle.FixedSingle;
            styleTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            styleTxb.Location = new Point(3, 45);
            styleTxb.Margin = new Padding(3, 4, 3, 4);
            styleTxb.Name = "styleTxb";
            styleTxb.Size = new Size(255, 38);
            styleTxb.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(1, 8);
            label2.Name = "label2";
            label2.Size = new Size(62, 31);
            label2.TabIndex = 2;
            label2.Text = "Style";
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(colorTxb);
            panel6.Controls.Add(label3);
            panel6.Location = new Point(535, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(260, 88);
            panel6.TabIndex = 2;
            // 
            // colorTxb
            // 
            colorTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            colorTxb.BorderStyle = BorderStyle.FixedSingle;
            colorTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            colorTxb.Location = new Point(4, 45);
            colorTxb.Margin = new Padding(3, 4, 3, 4);
            colorTxb.Name = "colorTxb";
            colorTxb.Size = new Size(253, 38);
            colorTxb.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(1, 7);
            label3.Name = "label3";
            label3.Size = new Size(60, 31);
            label3.TabIndex = 2;
            label3.Text = "Màu";
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.Controls.Add(supplierTxb);
            panel10.Controls.Add(label6);
            panel10.Location = new Point(3, 97);
            panel10.Name = "panel10";
            panel10.Size = new Size(260, 88);
            panel10.TabIndex = 4;
            // 
            // supplierTxb
            // 
            supplierTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            supplierTxb.BorderStyle = BorderStyle.FixedSingle;
            supplierTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            supplierTxb.Location = new Point(3, 45);
            supplierTxb.Margin = new Padding(3, 4, 3, 4);
            supplierTxb.Name = "supplierTxb";
            supplierTxb.Size = new Size(254, 38);
            supplierTxb.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(-1, 8);
            label6.Name = "label6";
            label6.Size = new Size(191, 31);
            label6.TabIndex = 7;
            label6.Text = "Mã nhà cung cấp";
            // 
            // FabricPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 739);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FabricPopup";
            Padding = new Padding(20);
            Text = "Tạo NPL cần nhận";
            WindowState = FormWindowState.Maximized;
            Load += FabricPopup_Load;
            ((System.ComponentModel.ISupportInitialize)_dataTable).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
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
        private TextBox styleTxb;
        private Panel panel8;
        private Label label4;
        private Panel panel6;
        private Label label3;
        private TextBox colorTxb;
        private Panel panel10;
        private Label label5;
        private TextBox fabricTypeTxb;
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
        private Panel panel14;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn fabricNumber;
        private DataGridViewTextBoxColumn style;
        private DataGridViewTextBoxColumn color;
        private DataGridViewTextBoxColumn fabricType;
        private DataGridViewTextBoxColumn batch;
        private DataGridViewTextBoxColumn fabricLength;
        private DataGridViewTextBoxColumn lengthUnit;
        private DataGridViewTextBoxColumn fabricWeight;
        private DataGridViewTextBoxColumn weightUnit;
        private DataGridViewTextBoxColumn rollWidth;
        private DataGridViewTextBoxColumn widthUnit;
        private DataGridViewTextBoxColumn QuantityToReceived;
    }
}