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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FabricPopup));
            moTxbContainer = new Panel();
            moTxb = new TextBox();
            panel2 = new Panel();
            panel14 = new Panel();
            label9 = new Label();
            saveBtn = new Button();
            cancelBtn = new Button();
            sampleFileBtn = new Button();
            addBtn = new Button();
            gridView = new DataGridView();
            label8 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            label1 = new Label();
            panel11 = new Panel();
            label7 = new Label();
            panel9 = new Panel();
            estimateQuantityTxb = new TextBox();
            panel13 = new Panel();
            panel16 = new Panel();
            quantityTxb = new TextBox();
            label5 = new Label();
            panel8 = new Panel();
            panel12 = new Panel();
            fabricTypeTxb = new TextBox();
            label4 = new Label();
            panel4 = new Panel();
            label2 = new Label();
            styleContainer = new Panel();
            styleTxb = new TextBox();
            panel6 = new Panel();
            label3 = new Label();
            panel7 = new Panel();
            colorTxb = new TextBox();
            panel10 = new Panel();
            panel15 = new Panel();
            supplierTxb = new TextBox();
            label6 = new Label();
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
            ((System.ComponentModel.ISupportInitialize)_dataTable).BeginInit();
            moTxbContainer.SuspendLayout();
            panel2.SuspendLayout();
            panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            panel11.SuspendLayout();
            panel9.SuspendLayout();
            panel13.SuspendLayout();
            panel16.SuspendLayout();
            panel8.SuspendLayout();
            panel12.SuspendLayout();
            panel4.SuspendLayout();
            styleContainer.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel10.SuspendLayout();
            panel15.SuspendLayout();
            SuspendLayout();
            // 
            // moTxbContainer
            // 
            moTxbContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            moTxbContainer.AutoSize = true;
            moTxbContainer.BackColor = Color.White;
            moTxbContainer.BorderStyle = BorderStyle.FixedSingle;
            moTxbContainer.Controls.Add(moTxb);
            moTxbContainer.Location = new Point(3, 32);
            moTxbContainer.Margin = new Padding(3, 4, 3, 4);
            moTxbContainer.Name = "moTxbContainer";
            moTxbContainer.Padding = new Padding(5);
            moTxbContainer.Size = new Size(254, 45);
            moTxbContainer.TabIndex = 0;
            // 
            // moTxb
            // 
            moTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            moTxb.BorderStyle = BorderStyle.None;
            moTxb.Location = new Point(8, 11);
            moTxb.Margin = new Padding(3, 4, 3, 4);
            moTxb.Name = "moTxb";
            moTxb.Size = new Size(235, 20);
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
            panel2.Size = new Size(1067, 683);
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
            panel14.Size = new Size(1067, 492);
            panel14.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(0, 15);
            label9.Name = "label9";
            label9.Size = new Size(219, 38);
            label9.TabIndex = 11;
            label9.Text = "Chi tiết NPL vải";
            // 
            // saveBtn
            // 
            saveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveBtn.BackColor = Color.DodgerBlue;
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.ForeColor = Color.White;
            saveBtn.Location = new Point(973, 444);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(94, 45);
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
            cancelBtn.ForeColor = Color.White;
            cancelBtn.Location = new Point(873, 444);
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
            sampleFileBtn.ForeColor = Color.White;
            sampleFileBtn.Location = new Point(871, 15);
            sampleFileBtn.Name = "sampleFileBtn";
            sampleFileBtn.Size = new Size(94, 45);
            sampleFileBtn.TabIndex = 17;
            sampleFileBtn.Text = "File mẫu";
            sampleFileBtn.UseVisualStyleBackColor = false;
            // 
            // addBtn
            // 
            addBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addBtn.BackColor = Color.Green;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(970, 15);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(94, 45);
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
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(0, 10, 0, 10);
            dataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridView.Columns.AddRange(new DataGridViewColumn[] { id, fabricNumber, style, color, fabricType, batch, fabricLength, lengthUnit, fabricWeight, weightUnit, rollWidth, widthUnit });
            gridView.EnableHeadersVisualStyles = false;
            gridView.Location = new Point(0, 81);
            gridView.Name = "gridView";
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            gridView.RowTemplate.Height = 35;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.Size = new Size(1067, 357);
            gridView.TabIndex = 10;
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
            tableLayoutPanel1.Controls.Add(panel11, 2, 1);
            tableLayoutPanel1.Controls.Add(panel13, 1, 1);
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
            // panel11
            // 
            panel11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel11.AutoSize = true;
            panel11.Controls.Add(label7);
            panel11.Controls.Add(panel9);
            panel11.Location = new Point(535, 97);
            panel11.Name = "panel11";
            panel11.Size = new Size(260, 88);
            panel11.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 12);
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
            panel9.TabIndex = 6;
            // 
            // estimateQuantityTxb
            // 
            estimateQuantityTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            estimateQuantityTxb.BorderStyle = BorderStyle.None;
            estimateQuantityTxb.Location = new Point(7, 11);
            estimateQuantityTxb.Margin = new Padding(3, 4, 3, 4);
            estimateQuantityTxb.Name = "estimateQuantityTxb";
            estimateQuantityTxb.Size = new Size(235, 20);
            estimateQuantityTxb.TabIndex = 6;
            // 
            // panel13
            // 
            panel13.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel13.AutoSize = true;
            panel13.Controls.Add(panel16);
            panel13.Controls.Add(label5);
            panel13.Location = new Point(269, 97);
            panel13.Name = "panel13";
            panel13.Size = new Size(260, 88);
            panel13.TabIndex = 5;
            // 
            // panel16
            // 
            panel16.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel16.AutoSize = true;
            panel16.BackColor = Color.White;
            panel16.BorderStyle = BorderStyle.FixedSingle;
            panel16.Controls.Add(quantityTxb);
            panel16.Location = new Point(3, 34);
            panel16.Margin = new Padding(3, 4, 3, 4);
            panel16.Name = "panel16";
            panel16.Padding = new Padding(5);
            panel16.Size = new Size(254, 45);
            panel16.TabIndex = 5;
            // 
            // quantityTxb
            // 
            quantityTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            quantityTxb.BorderStyle = BorderStyle.None;
            quantityTxb.Location = new Point(9, 11);
            quantityTxb.Margin = new Padding(3, 4, 3, 4);
            quantityTxb.Name = "quantityTxb";
            quantityTxb.Size = new Size(235, 20);
            quantityTxb.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1, 10);
            label5.Name = "label5";
            label5.Size = new Size(132, 20);
            label5.TabIndex = 2;
            label5.Text = "Số lượng cần nhận";
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel8.AutoSize = true;
            panel8.Controls.Add(panel12);
            panel8.Controls.Add(label4);
            panel8.Location = new Point(801, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(263, 88);
            panel8.TabIndex = 3;
            // 
            // panel12
            // 
            panel12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel12.AutoSize = true;
            panel12.BackColor = Color.White;
            panel12.BorderStyle = BorderStyle.FixedSingle;
            panel12.Controls.Add(fabricTypeTxb);
            panel12.Location = new Point(4, 32);
            panel12.Margin = new Padding(3, 4, 3, 4);
            panel12.Name = "panel12";
            panel12.Padding = new Padding(5);
            panel12.Size = new Size(259, 45);
            panel12.TabIndex = 3;
            // 
            // fabricTypeTxb
            // 
            fabricTypeTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fabricTypeTxb.BorderStyle = BorderStyle.None;
            fabricTypeTxb.Location = new Point(11, 12);
            fabricTypeTxb.Margin = new Padding(3, 4, 3, 4);
            fabricTypeTxb.Name = "fabricTypeTxb";
            fabricTypeTxb.Size = new Size(235, 20);
            fabricTypeTxb.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1, 8);
            label4.Name = "label4";
            label4.Size = new Size(60, 20);
            label4.TabIndex = 2;
            label4.Text = "Loại vải";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.AutoSize = true;
            panel4.Controls.Add(label2);
            panel4.Controls.Add(styleContainer);
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
            label2.Size = new Size(41, 20);
            label2.TabIndex = 2;
            label2.Text = "Style";
            // 
            // styleContainer
            // 
            styleContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            styleContainer.AutoSize = true;
            styleContainer.BackColor = Color.White;
            styleContainer.BorderStyle = BorderStyle.FixedSingle;
            styleContainer.Controls.Add(styleTxb);
            styleContainer.Location = new Point(3, 31);
            styleContainer.Margin = new Padding(3, 4, 3, 4);
            styleContainer.Name = "styleContainer";
            styleContainer.Padding = new Padding(5);
            styleContainer.Size = new Size(254, 45);
            styleContainer.TabIndex = 1;
            // 
            // styleTxb
            // 
            styleTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            styleTxb.BorderStyle = BorderStyle.None;
            styleTxb.Location = new Point(8, 13);
            styleTxb.Margin = new Padding(3, 4, 3, 4);
            styleTxb.Name = "styleTxb";
            styleTxb.Size = new Size(235, 20);
            styleTxb.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel6.AutoSize = true;
            panel6.Controls.Add(label3);
            panel6.Controls.Add(panel7);
            panel6.Location = new Point(535, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(260, 88);
            panel6.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1, 6);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 2;
            label3.Text = "Màu";
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel7.AutoSize = true;
            panel7.BackColor = Color.White;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(colorTxb);
            panel7.Location = new Point(4, 32);
            panel7.Margin = new Padding(3, 4, 3, 4);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(5);
            panel7.Size = new Size(252, 45);
            panel7.TabIndex = 2;
            // 
            // colorTxb
            // 
            colorTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            colorTxb.BorderStyle = BorderStyle.None;
            colorTxb.Location = new Point(8, 12);
            colorTxb.Margin = new Padding(3, 4, 3, 4);
            colorTxb.Name = "colorTxb";
            colorTxb.Size = new Size(235, 20);
            colorTxb.TabIndex = 2;
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.AutoSize = true;
            panel10.Controls.Add(panel15);
            panel10.Controls.Add(label6);
            panel10.Location = new Point(3, 97);
            panel10.Name = "panel10";
            panel10.Size = new Size(260, 88);
            panel10.TabIndex = 4;
            // 
            // panel15
            // 
            panel15.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel15.AutoSize = true;
            panel15.BackColor = Color.White;
            panel15.BorderStyle = BorderStyle.FixedSingle;
            panel15.Controls.Add(supplierTxb);
            panel15.Location = new Point(3, 34);
            panel15.Margin = new Padding(3, 4, 3, 4);
            panel15.Name = "panel15";
            panel15.Padding = new Padding(5);
            panel15.Size = new Size(254, 45);
            panel15.TabIndex = 4;
            // 
            // supplierTxb
            // 
            supplierTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            supplierTxb.BorderStyle = BorderStyle.None;
            supplierTxb.Location = new Point(8, 12);
            supplierTxb.Margin = new Padding(3, 4, 3, 4);
            supplierTxb.Name = "supplierTxb";
            supplierTxb.Size = new Size(235, 20);
            supplierTxb.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 8);
            label6.Name = "label6";
            label6.Size = new Size(122, 20);
            label6.TabIndex = 7;
            label6.Text = "Mã nhà cung cấp";
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
            // FabricPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 723);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FabricPopup";
            Padding = new Padding(20);
            Text = "Tạo NPL cần nhận";
            WindowState = FormWindowState.Maximized;
            Load += FabricPopup_Load;
            ((System.ComponentModel.ISupportInitialize)_dataTable).EndInit();
            moTxbContainer.ResumeLayout(false);
            moTxbContainer.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            styleContainer.ResumeLayout(false);
            styleContainer.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
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
        private Panel styleContainer;
        private TextBox styleTxb;
        private Panel panel8;
        private Label label4;
        private Panel panel6;
        private Label label3;
        private Panel panel7;
        private TextBox colorTxb;
        private Panel panel10;
        private Label label5;
        private Panel panel12;
        private TextBox fabricTypeTxb;
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
    }
}