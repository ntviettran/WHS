namespace WHS.Popup.Transfer
{
    partial class AddTransferPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTransferPopup));
            panel1 = new Panel();
            cancelBtn = new Button();
            nextBtn = new Button();
            panel2 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel19 = new Panel();
            capacityTxb = new TextBox();
            label9 = new Label();
            panel22 = new Panel();
            sealNumberTxb = new TextBox();
            label10 = new Label();
            panel25 = new Panel();
            licensePlateTxb = new TextBox();
            label11 = new Label();
            panel28 = new Panel();
            vehicleTypeTxb = new TextBox();
            label12 = new Label();
            panel31 = new Panel();
            vehicleModeTxb = new TextBox();
            label13 = new Label();
            panel34 = new Panel();
            addIDBtn = new Panel();
            label14 = new Label();
            vehicleIdTxb = new TextBox();
            label8 = new Label();
            panel3 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel12 = new Panel();
            warehouseDatePicker = new DateTimePicker();
            label7 = new Label();
            panel10 = new Panel();
            estimateWarehouseDatePicker = new DateTimePicker();
            label6 = new Label();
            panel8 = new Panel();
            execDatePicker = new DateTimePicker();
            label5 = new Label();
            panel6 = new Panel();
            estimateExecDatePicker = new DateTimePicker();
            label4 = new Label();
            panel4 = new Panel();
            createdDatePicker = new DateTimePicker();
            label3 = new Label();
            panel21 = new Panel();
            idTxb = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel19.SuspendLayout();
            panel22.SuspendLayout();
            panel25.SuspendLayout();
            panel28.SuspendLayout();
            panel31.SuspendLayout();
            panel34.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel12.SuspendLayout();
            panel10.SuspendLayout();
            panel8.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            panel21.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cancelBtn);
            panel1.Controls.Add(nextBtn);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(612, 696);
            panel1.TabIndex = 0;
            // 
            // cancelBtn
            // 
            cancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelBtn.BackColor = Color.Crimson;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelBtn.ForeColor = Color.White;
            cancelBtn.Location = new Point(374, 648);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 47);
            cancelBtn.TabIndex = 12;
            cancelBtn.Text = "Hủy";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // nextBtn
            // 
            nextBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            nextBtn.BackColor = Color.DodgerBlue;
            nextBtn.FlatStyle = FlatStyle.Flat;
            nextBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nextBtn.ForeColor = Color.White;
            nextBtn.Location = new Point(472, 648);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(139, 47);
            nextBtn.TabIndex = 11;
            nextBtn.Text = "Tiếp theo";
            nextBtn.UseVisualStyleBackColor = false;
            nextBtn.Click += nextBtn_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Controls.Add(label8);
            panel2.Location = new Point(0, 308);
            panel2.Name = "panel2";
            panel2.Size = new Size(612, 319);
            panel2.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel19, 1, 2);
            tableLayoutPanel2.Controls.Add(panel22, 0, 2);
            tableLayoutPanel2.Controls.Add(panel25, 1, 1);
            tableLayoutPanel2.Controls.Add(panel28, 0, 1);
            tableLayoutPanel2.Controls.Add(panel31, 1, 0);
            tableLayoutPanel2.Controls.Add(panel34, 0, 0);
            tableLayoutPanel2.Location = new Point(0, 53);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(609, 266);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // panel19
            // 
            panel19.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel19.Controls.Add(capacityTxb);
            panel19.Controls.Add(label9);
            panel19.Location = new Point(307, 179);
            panel19.Name = "panel19";
            panel19.Size = new Size(299, 84);
            panel19.TabIndex = 6;
            // 
            // capacityTxb
            // 
            capacityTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            capacityTxb.BorderStyle = BorderStyle.FixedSingle;
            capacityTxb.Enabled = false;
            capacityTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            capacityTxb.Location = new Point(2, 40);
            capacityTxb.Margin = new Padding(3, 4, 3, 4);
            capacityTxb.Name = "capacityTxb";
            capacityTxb.Size = new Size(294, 38);
            capacityTxb.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(-5, 3);
            label9.Name = "label9";
            label9.Size = new Size(106, 31);
            label9.TabIndex = 2;
            label9.Text = "Tải trọng";
            // 
            // panel22
            // 
            panel22.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel22.Controls.Add(sealNumberTxb);
            panel22.Controls.Add(label10);
            panel22.Location = new Point(3, 179);
            panel22.Name = "panel22";
            panel22.Size = new Size(298, 84);
            panel22.TabIndex = 5;
            // 
            // sealNumberTxb
            // 
            sealNumberTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sealNumberTxb.BorderStyle = BorderStyle.FixedSingle;
            sealNumberTxb.Enabled = false;
            sealNumberTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sealNumberTxb.Location = new Point(3, 40);
            sealNumberTxb.Margin = new Padding(3, 4, 3, 4);
            sealNumberTxb.Name = "sealNumberTxb";
            sealNumberTxb.Size = new Size(293, 38);
            sealNumberTxb.TabIndex = 1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(3, 6);
            label10.Name = "label10";
            label10.Size = new Size(75, 31);
            label10.TabIndex = 2;
            label10.Text = "Số chì";
            // 
            // panel25
            // 
            panel25.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel25.Controls.Add(licensePlateTxb);
            panel25.Controls.Add(label11);
            panel25.Location = new Point(307, 91);
            panel25.Name = "panel25";
            panel25.Size = new Size(299, 82);
            panel25.TabIndex = 4;
            // 
            // licensePlateTxb
            // 
            licensePlateTxb.BorderStyle = BorderStyle.FixedSingle;
            licensePlateTxb.Enabled = false;
            licensePlateTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            licensePlateTxb.Location = new Point(3, 40);
            licensePlateTxb.Margin = new Padding(3, 4, 3, 4);
            licensePlateTxb.Name = "licensePlateTxb";
            licensePlateTxb.Size = new Size(293, 38);
            licensePlateTxb.TabIndex = 1;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(-4, 3);
            label11.Name = "label11";
            label11.Size = new Size(124, 31);
            label11.TabIndex = 2;
            label11.Text = "Bảng số xe";
            // 
            // panel28
            // 
            panel28.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel28.Controls.Add(vehicleTypeTxb);
            panel28.Controls.Add(label12);
            panel28.Location = new Point(3, 91);
            panel28.Name = "panel28";
            panel28.Size = new Size(298, 82);
            panel28.TabIndex = 3;
            // 
            // vehicleTypeTxb
            // 
            vehicleTypeTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            vehicleTypeTxb.BorderStyle = BorderStyle.FixedSingle;
            vehicleTypeTxb.Enabled = false;
            vehicleTypeTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vehicleTypeTxb.Location = new Point(2, 39);
            vehicleTypeTxb.Margin = new Padding(3, 4, 3, 4);
            vehicleTypeTxb.Name = "vehicleTypeTxb";
            vehicleTypeTxb.Size = new Size(294, 38);
            vehicleTypeTxb.TabIndex = 1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(-5, 4);
            label12.Name = "label12";
            label12.Size = new Size(189, 31);
            label12.TabIndex = 2;
            label12.Text = "Loại phương tiện";
            // 
            // panel31
            // 
            panel31.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel31.Controls.Add(vehicleModeTxb);
            panel31.Controls.Add(label13);
            panel31.Location = new Point(307, 3);
            panel31.Name = "panel31";
            panel31.Size = new Size(299, 82);
            panel31.TabIndex = 2;
            // 
            // vehicleModeTxb
            // 
            vehicleModeTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            vehicleModeTxb.BorderStyle = BorderStyle.FixedSingle;
            vehicleModeTxb.Enabled = false;
            vehicleModeTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vehicleModeTxb.Location = new Point(3, 37);
            vehicleModeTxb.Margin = new Padding(3, 4, 3, 4);
            vehicleModeTxb.Name = "vehicleModeTxb";
            vehicleModeTxb.Size = new Size(293, 38);
            vehicleModeTxb.TabIndex = 1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(-2, 3);
            label13.Name = "label13";
            label13.Size = new Size(114, 31);
            label13.TabIndex = 2;
            label13.Text = "Hình thức";
            // 
            // panel34
            // 
            panel34.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel34.Controls.Add(addIDBtn);
            panel34.Controls.Add(label14);
            panel34.Controls.Add(vehicleIdTxb);
            panel34.Location = new Point(3, 3);
            panel34.Name = "panel34";
            panel34.Size = new Size(298, 82);
            panel34.TabIndex = 1;
            // 
            // addIDBtn
            // 
            addIDBtn.BackgroundImage = Properties.Resources.plus;
            addIDBtn.BackgroundImageLayout = ImageLayout.Zoom;
            addIDBtn.BorderStyle = BorderStyle.FixedSingle;
            addIDBtn.Location = new Point(259, 38);
            addIDBtn.Margin = new Padding(0);
            addIDBtn.Name = "addIDBtn";
            addIDBtn.Size = new Size(38, 38);
            addIDBtn.TabIndex = 1;
            addIDBtn.Click += addIDBtn_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(-4, 4);
            label14.Name = "label14";
            label14.Size = new Size(36, 31);
            label14.TabIndex = 2;
            label14.Text = "ID";
            // 
            // vehicleIdTxb
            // 
            vehicleIdTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            vehicleIdTxb.BorderStyle = BorderStyle.FixedSingle;
            vehicleIdTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vehicleIdTxb.Location = new Point(2, 38);
            vehicleIdTxb.Margin = new Padding(3, 4, 3, 4);
            vehicleIdTxb.Name = "vehicleIdTxb";
            vehicleIdTxb.Size = new Size(257, 38);
            vehicleIdTxb.TabIndex = 0;
            vehicleIdTxb.KeyDown += vehicleIdTxb_KeyDown;
            vehicleIdTxb.Leave += vehicleIdTxb_Leave;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(-3, 12);
            label8.Name = "label8";
            label8.Size = new Size(404, 41);
            label8.TabIndex = 1;
            label8.Text = "THÔNG TIN PHƯƠNG TIỆN";
            // 
            // panel3
            // 
            panel3.Controls.Add(tableLayoutPanel1);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(612, 308);
            panel3.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel12, 1, 2);
            tableLayoutPanel1.Controls.Add(panel10, 0, 2);
            tableLayoutPanel1.Controls.Add(panel8, 1, 1);
            tableLayoutPanel1.Controls.Add(panel6, 0, 1);
            tableLayoutPanel1.Controls.Add(panel4, 1, 0);
            tableLayoutPanel1.Controls.Add(panel21, 0, 0);
            tableLayoutPanel1.Location = new Point(0, 48);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(612, 260);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel12
            // 
            panel12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel12.Controls.Add(warehouseDatePicker);
            panel12.Controls.Add(label7);
            panel12.Location = new Point(309, 175);
            panel12.Name = "panel12";
            panel12.Size = new Size(300, 82);
            panel12.TabIndex = 6;
            // 
            // warehouseDatePicker
            // 
            warehouseDatePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            warehouseDatePicker.CustomFormat = "dd/MM/yyyy";
            warehouseDatePicker.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            warehouseDatePicker.Format = DateTimePickerFormat.Custom;
            warehouseDatePicker.Location = new Point(3, 40);
            warehouseDatePicker.Margin = new Padding(0);
            warehouseDatePicker.Name = "warehouseDatePicker";
            warehouseDatePicker.Size = new Size(295, 38);
            warehouseDatePicker.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(-1, 4);
            label7.Name = "label7";
            label7.Size = new Size(140, 31);
            label7.TabIndex = 2;
            label7.Text = "Ngày về kho";
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.Controls.Add(estimateWarehouseDatePicker);
            panel10.Controls.Add(label6);
            panel10.Location = new Point(3, 175);
            panel10.Name = "panel10";
            panel10.Size = new Size(300, 82);
            panel10.TabIndex = 5;
            // 
            // estimateWarehouseDatePicker
            // 
            estimateWarehouseDatePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            estimateWarehouseDatePicker.CustomFormat = "dd/MM/yyyy";
            estimateWarehouseDatePicker.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            estimateWarehouseDatePicker.Format = DateTimePickerFormat.Custom;
            estimateWarehouseDatePicker.Location = new Point(2, 40);
            estimateWarehouseDatePicker.Margin = new Padding(0);
            estimateWarehouseDatePicker.Name = "estimateWarehouseDatePicker";
            estimateWarehouseDatePicker.Size = new Size(296, 38);
            estimateWarehouseDatePicker.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(-3, 6);
            label6.Name = "label6";
            label6.Size = new Size(222, 31);
            label6.TabIndex = 2;
            label6.Text = "Ngày dự kiến về kho";
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel8.Controls.Add(execDatePicker);
            panel8.Controls.Add(label5);
            panel8.Location = new Point(309, 89);
            panel8.Name = "panel8";
            panel8.Size = new Size(300, 80);
            panel8.TabIndex = 4;
            // 
            // execDatePicker
            // 
            execDatePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            execDatePicker.CustomFormat = "dd/MM/yyyy";
            execDatePicker.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            execDatePicker.Format = DateTimePickerFormat.Custom;
            execDatePicker.Location = new Point(1, 36);
            execDatePicker.Margin = new Padding(0);
            execDatePicker.Name = "execDatePicker";
            execDatePicker.Size = new Size(297, 38);
            execDatePicker.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 1);
            label5.Name = "label5";
            label5.Size = new Size(170, 31);
            label5.TabIndex = 2;
            label5.Text = "Ngày thực hiện";
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(estimateExecDatePicker);
            panel6.Controls.Add(label4);
            panel6.Location = new Point(3, 89);
            panel6.Name = "panel6";
            panel6.Size = new Size(300, 80);
            panel6.TabIndex = 3;
            // 
            // estimateExecDatePicker
            // 
            estimateExecDatePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            estimateExecDatePicker.CustomFormat = "dd/MM/yyyy";
            estimateExecDatePicker.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            estimateExecDatePicker.Format = DateTimePickerFormat.Custom;
            estimateExecDatePicker.Location = new Point(2, 36);
            estimateExecDatePicker.Margin = new Padding(0);
            estimateExecDatePicker.Name = "estimateExecDatePicker";
            estimateExecDatePicker.Size = new Size(295, 38);
            estimateExecDatePicker.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(-4, 2);
            label4.Name = "label4";
            label4.Size = new Size(252, 31);
            label4.TabIndex = 2;
            label4.Text = "Ngày dự kiến thực hiện";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Controls.Add(createdDatePicker);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(309, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(300, 80);
            panel4.TabIndex = 2;
            // 
            // createdDatePicker
            // 
            createdDatePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            createdDatePicker.CustomFormat = "dd/MM/yyyy";
            createdDatePicker.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createdDatePicker.Format = DateTimePickerFormat.Custom;
            createdDatePicker.Location = new Point(1, 38);
            createdDatePicker.Margin = new Padding(0);
            createdDatePicker.Name = "createdDatePicker";
            createdDatePicker.Size = new Size(297, 38);
            createdDatePicker.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(-3, 4);
            label3.Name = "label3";
            label3.Size = new Size(228, 31);
            label3.TabIndex = 2;
            label3.Text = "Ngày tạo đợt chuyển";
            // 
            // panel21
            // 
            panel21.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel21.Controls.Add(idTxb);
            panel21.Controls.Add(label2);
            panel21.Location = new Point(3, 3);
            panel21.Name = "panel21";
            panel21.Size = new Size(300, 80);
            panel21.TabIndex = 1;
            // 
            // idTxb
            // 
            idTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            idTxb.BorderStyle = BorderStyle.FixedSingle;
            idTxb.Enabled = false;
            idTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idTxb.Location = new Point(3, 37);
            idTxb.Margin = new Padding(3, 4, 3, 4);
            idTxb.Name = "idTxb";
            idTxb.Size = new Size(293, 38);
            idTxb.TabIndex = 0;
            idTxb.Text = "Tự động";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 1);
            label2.Name = "label2";
            label2.Size = new Size(36, 31);
            label2.TabIndex = 2;
            label2.Text = "ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 3);
            label1.Name = "label1";
            label1.Size = new Size(388, 41);
            label1.TabIndex = 0;
            label1.Text = "THÔNG TIN ĐỢT CHUYỂN";
            // 
            // AddTransferPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 736);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddTransferPopup";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo mới thông tin đợt chuyển";
            FormClosed += AddTransferPopup_FormClosed;
            Load += AddTransferPopup_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panel19.ResumeLayout(false);
            panel19.PerformLayout();
            panel22.ResumeLayout(false);
            panel22.PerformLayout();
            panel25.ResumeLayout(false);
            panel25.PerformLayout();
            panel28.ResumeLayout(false);
            panel28.PerformLayout();
            panel31.ResumeLayout(false);
            panel31.PerformLayout();
            panel34.ResumeLayout(false);
            panel34.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel21.ResumeLayout(false);
            panel21.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel19;
        private Label label9;
        private TextBox capacityTxb;
        private Panel panel22;
        private Label label10;
        private TextBox sealNumberTxb;
        private Panel panel25;
        private Label label11;
        private TextBox licensePlateTxb;
        private Panel panel28;
        private Label label12;
        private TextBox vehicleTypeTxb;
        private Panel panel31;
        private Label label13;
        private TextBox vehicleModeTxb;
        private Panel panel34;
        private Label label14;
        private Panel addIDBtn;
        private TextBox vehicleIdTxb;
        private Label label8;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel12;
        private Label label7;
        private DateTimePicker warehouseDatePicker;
        private Panel panel10;
        private Label label6;
        private DateTimePicker estimateWarehouseDatePicker;
        private Panel panel8;
        private Label label5;
        private DateTimePicker execDatePicker;
        private Panel panel6;
        private Label label4;
        private DateTimePicker estimateExecDatePicker;
        private Panel panel4;
        private Label label3;
        private DateTimePicker createdDatePicker;
        private Panel panel21;
        private Label label2;
        private TextBox idTxb;
        private Label label1;
        private Button cancelBtn;
        private Button nextBtn;
    }
}