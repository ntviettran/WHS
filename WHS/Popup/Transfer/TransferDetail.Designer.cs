namespace WHS.Popup.Transfer
{
    partial class TransferDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferDetail));
            panel1 = new Panel();
            panel11 = new Panel();
            editBtn = new Button();
            typeContainer = new TableLayoutPanel();
            fabricBtn = new Button();
            plspBtn = new Button();
            pldgBtn = new Button();
            gridView = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel12 = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            vehicleIdLabel = new Label();
            label18 = new Label();
            panel4 = new Panel();
            tableLayoutPanel6 = new TableLayoutPanel();
            licensePlateLabel = new Label();
            label4 = new Label();
            panel3 = new Panel();
            tableLayoutPanel7 = new TableLayoutPanel();
            vehicleModeLabel = new Label();
            label3 = new Label();
            panel9 = new Panel();
            tableLayoutPanel5 = new TableLayoutPanel();
            label2 = new Label();
            vehicleTypeLabel = new Label();
            label1 = new Label();
            panel26 = new Panel();
            panel28 = new Panel();
            tableLayoutPanel12 = new TableLayoutPanel();
            transferStatusLabel = new Label();
            label47 = new Label();
            panel27 = new Panel();
            tableLayoutPanel13 = new TableLayoutPanel();
            execStatusLabel = new Label();
            label45 = new Label();
            label79 = new Label();
            panel5 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel10 = new Panel();
            tableLayoutPanel9 = new TableLayoutPanel();
            execLabel = new Label();
            label9 = new Label();
            panel8 = new Panel();
            tableLayoutPanel11 = new TableLayoutPanel();
            estimateWarehouseLabel = new Label();
            label7 = new Label();
            panel7 = new Panel();
            tableLayoutPanel10 = new TableLayoutPanel();
            warehouseLabel = new Label();
            label6 = new Label();
            panel6 = new Panel();
            tableLayoutPanel8 = new TableLayoutPanel();
            estimateExecLabel = new Label();
            label5 = new Label();
            label8 = new Label();
            panel1.SuspendLayout();
            panel11.SuspendLayout();
            typeContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel12.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel4.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            panel9.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panel26.SuspendLayout();
            panel28.SuspendLayout();
            tableLayoutPanel12.SuspendLayout();
            panel27.SuspendLayout();
            tableLayoutPanel13.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel10.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            panel8.SuspendLayout();
            tableLayoutPanel11.SuspendLayout();
            panel7.SuspendLayout();
            tableLayoutPanel10.SuspendLayout();
            panel6.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel11);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(1428, 794);
            panel1.TabIndex = 0;
            // 
            // panel11
            // 
            panel11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel11.Controls.Add(editBtn);
            panel11.Controls.Add(typeContainer);
            panel11.Controls.Add(gridView);
            panel11.Location = new Point(1, 294);
            panel11.Name = "panel11";
            panel11.Size = new Size(1424, 497);
            panel11.TabIndex = 11;
            // 
            // editBtn
            // 
            editBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            editBtn.BackColor = Color.Green;
            editBtn.FlatStyle = FlatStyle.Flat;
            editBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editBtn.ForeColor = Color.White;
            editBtn.Location = new Point(1287, 3);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(134, 48);
            editBtn.TabIndex = 6;
            editBtn.Text = "Chỉnh sửa";
            editBtn.UseVisualStyleBackColor = false;
            editBtn.Click += editBtn_Click;
            // 
            // typeContainer
            // 
            typeContainer.ColumnCount = 3;
            typeContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            typeContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            typeContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
            typeContainer.Controls.Add(fabricBtn, 0, 0);
            typeContainer.Controls.Add(plspBtn, 1, 0);
            typeContainer.Controls.Add(pldgBtn, 2, 0);
            typeContainer.Location = new Point(0, 3);
            typeContainer.Name = "typeContainer";
            typeContainer.RowCount = 1;
            typeContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            typeContainer.Size = new Size(371, 58);
            typeContainer.TabIndex = 7;
            // 
            // fabricBtn
            // 
            fabricBtn.BackColor = Color.DodgerBlue;
            fabricBtn.FlatStyle = FlatStyle.Flat;
            fabricBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fabricBtn.ForeColor = Color.White;
            fabricBtn.Location = new Point(3, 3);
            fabricBtn.Name = "fabricBtn";
            fabricBtn.Size = new Size(94, 48);
            fabricBtn.TabIndex = 1;
            fabricBtn.Text = "Vải";
            fabricBtn.UseVisualStyleBackColor = false;
            fabricBtn.Click += fabricBtn_Click;
            // 
            // plspBtn
            // 
            plspBtn.BackColor = Color.DarkGray;
            plspBtn.FlatStyle = FlatStyle.Flat;
            plspBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            plspBtn.ForeColor = Color.White;
            plspBtn.Location = new Point(136, 3);
            plspBtn.Name = "plspBtn";
            plspBtn.Size = new Size(94, 48);
            plspBtn.TabIndex = 4;
            plspBtn.Text = "PLSP";
            plspBtn.UseVisualStyleBackColor = false;
            plspBtn.Click += plspBtn_Click;
            // 
            // pldgBtn
            // 
            pldgBtn.BackColor = Color.DarkGray;
            pldgBtn.FlatStyle = FlatStyle.Flat;
            pldgBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pldgBtn.ForeColor = Color.White;
            pldgBtn.Location = new Point(269, 3);
            pldgBtn.Name = "pldgBtn";
            pldgBtn.Size = new Size(94, 47);
            pldgBtn.TabIndex = 5;
            pldgBtn.Text = "PLĐG";
            pldgBtn.UseVisualStyleBackColor = false;
            pldgBtn.Click += pldgBtn_Click;
            // 
            // gridView
            // 
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;
            gridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridView.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(10, 0, 10, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridView.DefaultCellStyle = dataGridViewCellStyle2;
            gridView.EnableHeadersVisualStyles = false;
            gridView.Location = new Point(1, 78);
            gridView.Name = "gridView";
            gridView.ReadOnly = true;
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.RowTemplate.Height = 35;
            gridView.Size = new Size(1423, 416);
            gridView.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel26, 4, 0);
            tableLayoutPanel1.Controls.Add(panel5, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1428, 270);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(tableLayoutPanel3);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(493, 264);
            panel2.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(panel12, 0, 0);
            tableLayoutPanel3.Controls.Add(panel4, 2, 2);
            tableLayoutPanel3.Controls.Add(panel3, 0, 2);
            tableLayoutPanel3.Controls.Add(panel9, 2, 0);
            tableLayoutPanel3.Location = new Point(22, 64);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(445, 174);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // panel12
            // 
            panel12.AutoSize = true;
            panel12.BorderStyle = BorderStyle.FixedSingle;
            panel12.Controls.Add(tableLayoutPanel4);
            panel12.Dock = DockStyle.Fill;
            panel12.Location = new Point(3, 3);
            panel12.Name = "panel12";
            panel12.Size = new Size(206, 71);
            panel12.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.Controls.Add(vehicleIdLabel, 1, 1);
            tableLayoutPanel4.Controls.Add(label18, 1, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(204, 69);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // vehicleIdLabel
            // 
            vehicleIdLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            vehicleIdLabel.AutoSize = true;
            vehicleIdLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vehicleIdLabel.Location = new Point(38, 34);
            vehicleIdLabel.Name = "vehicleIdLabel";
            vehicleIdLabel.Size = new Size(128, 35);
            vehicleIdLabel.TabIndex = 1;
            vehicleIdLabel.Text = "Đang cập nhật";
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label18.Location = new Point(85, 0);
            label18.Name = "label18";
            label18.Size = new Size(33, 34);
            label18.TabIndex = 0;
            label18.Text = "ID";
            // 
            // panel4
            // 
            panel4.AutoSize = true;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(tableLayoutPanel6);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(235, 100);
            panel4.Name = "panel4";
            panel4.Size = new Size(207, 71);
            panel4.TabIndex = 3;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 3;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel6.Controls.Add(licensePlateLabel, 1, 1);
            tableLayoutPanel6.Controls.Add(label4, 1, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(0, 0);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(205, 69);
            tableLayoutPanel6.TabIndex = 1;
            // 
            // licensePlateLabel
            // 
            licensePlateLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            licensePlateLabel.AutoSize = true;
            licensePlateLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            licensePlateLabel.Location = new Point(38, 34);
            licensePlateLabel.Name = "licensePlateLabel";
            licensePlateLabel.Size = new Size(128, 35);
            licensePlateLabel.TabIndex = 3;
            licensePlateLabel.Text = "Đang cập nhật";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(45, 0);
            label4.Name = "label4";
            label4.Size = new Size(115, 34);
            label4.TabIndex = 2;
            label4.Text = "Bảng số xe";
            // 
            // panel3
            // 
            panel3.AutoSize = true;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(tableLayoutPanel7);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 100);
            panel3.Name = "panel3";
            panel3.Size = new Size(206, 71);
            panel3.TabIndex = 2;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 3;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel7.Controls.Add(vehicleModeLabel, 1, 1);
            tableLayoutPanel7.Controls.Add(label3, 1, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(0, 0);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(204, 69);
            tableLayoutPanel7.TabIndex = 1;
            // 
            // vehicleModeLabel
            // 
            vehicleModeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            vehicleModeLabel.AutoSize = true;
            vehicleModeLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vehicleModeLabel.Location = new Point(38, 34);
            vehicleModeLabel.Name = "vehicleModeLabel";
            vehicleModeLabel.Size = new Size(128, 35);
            vehicleModeLabel.TabIndex = 2;
            vehicleModeLabel.Text = "Đang cập nhật";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(49, 0);
            label3.Name = "label3";
            label3.Size = new Size(106, 34);
            label3.TabIndex = 1;
            label3.Text = "Hình thức";
            // 
            // panel9
            // 
            panel9.AutoSize = true;
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(tableLayoutPanel5);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(235, 3);
            panel9.Name = "panel9";
            panel9.Size = new Size(207, 71);
            panel9.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel5.Controls.Add(label2, 1, 0);
            tableLayoutPanel5.Controls.Add(vehicleTypeLabel, 1, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(205, 69);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(15, 0);
            label2.Name = "label2";
            label2.Size = new Size(174, 34);
            label2.TabIndex = 0;
            label2.Text = "Loại phương tiện";
            // 
            // vehicleTypeLabel
            // 
            vehicleTypeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            vehicleTypeLabel.AutoSize = true;
            vehicleTypeLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vehicleTypeLabel.Location = new Point(38, 34);
            vehicleTypeLabel.Name = "vehicleTypeLabel";
            vehicleTypeLabel.Size = new Size(128, 35);
            vehicleTypeLabel.TabIndex = 1;
            vehicleTypeLabel.Text = "Đang cập nhật";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, -2);
            label1.Name = "label1";
            label1.Size = new Size(383, 46);
            label1.TabIndex = 0;
            label1.Text = "Thông tin phương tiện";
            // 
            // panel26
            // 
            panel26.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel26.BorderStyle = BorderStyle.FixedSingle;
            panel26.Controls.Add(panel28);
            panel26.Controls.Add(panel27);
            panel26.Controls.Add(label79);
            panel26.Location = new Point(1143, 3);
            panel26.Name = "panel26";
            panel26.Size = new Size(282, 264);
            panel26.TabIndex = 9;
            // 
            // panel28
            // 
            panel28.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel28.AutoSize = true;
            panel28.BorderStyle = BorderStyle.FixedSingle;
            panel28.Controls.Add(tableLayoutPanel12);
            panel28.Location = new Point(21, 157);
            panel28.Name = "panel28";
            panel28.Size = new Size(240, 82);
            panel28.TabIndex = 6;
            // 
            // tableLayoutPanel12
            // 
            tableLayoutPanel12.ColumnCount = 3;
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel12.Controls.Add(transferStatusLabel, 1, 1);
            tableLayoutPanel12.Controls.Add(label47, 1, 0);
            tableLayoutPanel12.Dock = DockStyle.Fill;
            tableLayoutPanel12.Location = new Point(0, 0);
            tableLayoutPanel12.Name = "tableLayoutPanel12";
            tableLayoutPanel12.RowCount = 2;
            tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel12.Size = new Size(238, 80);
            tableLayoutPanel12.TabIndex = 1;
            // 
            // transferStatusLabel
            // 
            transferStatusLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            transferStatusLabel.AutoSize = true;
            transferStatusLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            transferStatusLabel.Location = new Point(55, 40);
            transferStatusLabel.Name = "transferStatusLabel";
            transferStatusLabel.Size = new Size(128, 40);
            transferStatusLabel.TabIndex = 4;
            transferStatusLabel.Text = "Đang cập nhật";
            // 
            // label47
            // 
            label47.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label47.AutoSize = true;
            label47.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label47.Location = new Point(28, 0);
            label47.Name = "label47";
            label47.Size = new Size(182, 40);
            label47.TabIndex = 1;
            label47.Text = "Trạng thái chuyển";
            // 
            // panel27
            // 
            panel27.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel27.AutoSize = true;
            panel27.BorderStyle = BorderStyle.FixedSingle;
            panel27.Controls.Add(tableLayoutPanel13);
            panel27.Location = new Point(21, 54);
            panel27.Name = "panel27";
            panel27.Size = new Size(240, 82);
            panel27.TabIndex = 5;
            // 
            // tableLayoutPanel13
            // 
            tableLayoutPanel13.ColumnCount = 3;
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel13.Controls.Add(execStatusLabel, 1, 1);
            tableLayoutPanel13.Controls.Add(label45, 1, 0);
            tableLayoutPanel13.Dock = DockStyle.Fill;
            tableLayoutPanel13.Location = new Point(0, 0);
            tableLayoutPanel13.Name = "tableLayoutPanel13";
            tableLayoutPanel13.RowCount = 2;
            tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel13.Size = new Size(238, 80);
            tableLayoutPanel13.TabIndex = 1;
            // 
            // execStatusLabel
            // 
            execStatusLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            execStatusLabel.AutoSize = true;
            execStatusLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            execStatusLabel.Location = new Point(55, 40);
            execStatusLabel.Name = "execStatusLabel";
            execStatusLabel.Size = new Size(128, 40);
            execStatusLabel.TabIndex = 4;
            execStatusLabel.Text = "Đang cập nhật";
            // 
            // label45
            // 
            label45.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label45.AutoSize = true;
            label45.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label45.Location = new Point(17, 0);
            label45.Name = "label45";
            label45.Size = new Size(204, 40);
            label45.TabIndex = 1;
            label45.Text = "Trạng thái thực hiện";
            // 
            // label79
            // 
            label79.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label79.AutoSize = true;
            label79.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label79.Location = new Point(60, -2);
            label79.Name = "label79";
            label79.Size = new Size(181, 46);
            label79.TabIndex = 0;
            label79.Text = "Trạng thái";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(tableLayoutPanel2);
            panel5.Controls.Add(label8);
            panel5.Location = new Point(537, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(565, 264);
            panel5.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel10, 2, 2);
            tableLayoutPanel2.Controls.Add(panel8, 0, 0);
            tableLayoutPanel2.Controls.Add(panel7, 2, 0);
            tableLayoutPanel2.Controls.Add(panel6, 0, 2);
            tableLayoutPanel2.Location = new Point(23, 61);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(521, 177);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.AutoSize = true;
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(tableLayoutPanel9);
            panel10.Location = new Point(273, 101);
            panel10.Name = "panel10";
            panel10.Size = new Size(245, 73);
            panel10.TabIndex = 4;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 3;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel9.Controls.Add(execLabel, 1, 1);
            tableLayoutPanel9.Controls.Add(label9, 1, 0);
            tableLayoutPanel9.Dock = DockStyle.Fill;
            tableLayoutPanel9.Location = new Point(0, 0);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 2;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.Size = new Size(243, 71);
            tableLayoutPanel9.TabIndex = 1;
            // 
            // execLabel
            // 
            execLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            execLabel.AutoSize = true;
            execLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            execLabel.Location = new Point(57, 35);
            execLabel.Name = "execLabel";
            execLabel.Size = new Size(128, 36);
            execLabel.TabIndex = 4;
            execLabel.Text = "Đang cập nhật";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label9.Location = new Point(42, 0);
            label9.Name = "label9";
            label9.Size = new Size(158, 35);
            label9.TabIndex = 2;
            label9.Text = "Ngày thực hiện";
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel8.AutoSize = true;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(tableLayoutPanel11);
            panel8.Location = new Point(3, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(244, 72);
            panel8.TabIndex = 1;
            // 
            // tableLayoutPanel11
            // 
            tableLayoutPanel11.ColumnCount = 3;
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel11.Controls.Add(estimateWarehouseLabel, 1, 1);
            tableLayoutPanel11.Controls.Add(label7, 1, 0);
            tableLayoutPanel11.Dock = DockStyle.Fill;
            tableLayoutPanel11.Location = new Point(0, 0);
            tableLayoutPanel11.Name = "tableLayoutPanel11";
            tableLayoutPanel11.RowCount = 2;
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel11.Size = new Size(242, 70);
            tableLayoutPanel11.TabIndex = 1;
            // 
            // estimateWarehouseLabel
            // 
            estimateWarehouseLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            estimateWarehouseLabel.AutoSize = true;
            estimateWarehouseLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            estimateWarehouseLabel.Location = new Point(57, 35);
            estimateWarehouseLabel.Name = "estimateWarehouseLabel";
            estimateWarehouseLabel.Size = new Size(128, 35);
            estimateWarehouseLabel.TabIndex = 3;
            estimateWarehouseLabel.Text = "Đang cập nhật";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(17, 0);
            label7.Name = "label7";
            label7.Size = new Size(208, 35);
            label7.TabIndex = 0;
            label7.Text = "Ngày dự kiến về kho";
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel7.AutoSize = true;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(tableLayoutPanel10);
            panel7.Location = new Point(273, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(245, 72);
            panel7.TabIndex = 2;
            // 
            // tableLayoutPanel10
            // 
            tableLayoutPanel10.ColumnCount = 3;
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel10.Controls.Add(warehouseLabel, 1, 1);
            tableLayoutPanel10.Controls.Add(label6, 1, 0);
            tableLayoutPanel10.Dock = DockStyle.Fill;
            tableLayoutPanel10.Location = new Point(0, 0);
            tableLayoutPanel10.Name = "tableLayoutPanel10";
            tableLayoutPanel10.RowCount = 2;
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel10.Size = new Size(243, 70);
            tableLayoutPanel10.TabIndex = 1;
            // 
            // warehouseLabel
            // 
            warehouseLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            warehouseLabel.AutoSize = true;
            warehouseLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            warehouseLabel.Location = new Point(57, 35);
            warehouseLabel.Name = "warehouseLabel";
            warehouseLabel.Size = new Size(128, 35);
            warehouseLabel.TabIndex = 4;
            warehouseLabel.Text = "Đang cập nhật";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(56, 0);
            label6.Name = "label6";
            label6.Size = new Size(131, 35);
            label6.TabIndex = 1;
            label6.Text = "Ngày về kho";
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel6.AutoSize = true;
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(tableLayoutPanel8);
            panel6.Location = new Point(3, 101);
            panel6.Name = "panel6";
            panel6.Size = new Size(244, 73);
            panel6.TabIndex = 3;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 3;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel8.Controls.Add(estimateExecLabel, 1, 1);
            tableLayoutPanel8.Controls.Add(label5, 1, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(0, 0);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 2;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Size = new Size(242, 71);
            tableLayoutPanel8.TabIndex = 1;
            // 
            // estimateExecLabel
            // 
            estimateExecLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            estimateExecLabel.AutoSize = true;
            estimateExecLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            estimateExecLabel.Location = new Point(57, 35);
            estimateExecLabel.Name = "estimateExecLabel";
            estimateExecLabel.Size = new Size(128, 36);
            estimateExecLabel.TabIndex = 4;
            estimateExecLabel.Text = "Đang cập nhật";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(235, 35);
            label5.TabIndex = 2;
            label5.Text = "Ngày dự kiến thực hiện";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(147, -1);
            label8.Name = "label8";
            label8.Size = new Size(263, 46);
            label8.TabIndex = 0;
            label8.Text = "Thông tin ngày";
            // 
            // TransferDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1468, 834);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TransferDetail";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin đợt chuyển";
            panel1.ResumeLayout(false);
            panel11.ResumeLayout(false);
            typeContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            panel12.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            panel4.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            panel3.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            panel9.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            panel26.ResumeLayout(false);
            panel26.PerformLayout();
            panel28.ResumeLayout(false);
            tableLayoutPanel12.ResumeLayout(false);
            tableLayoutPanel12.PerformLayout();
            panel27.ResumeLayout(false);
            tableLayoutPanel13.ResumeLayout(false);
            tableLayoutPanel13.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel10.ResumeLayout(false);
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            panel8.ResumeLayout(false);
            tableLayoutPanel11.ResumeLayout(false);
            tableLayoutPanel11.PerformLayout();
            panel7.ResumeLayout(false);
            tableLayoutPanel10.ResumeLayout(false);
            tableLayoutPanel10.PerformLayout();
            panel6.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel5;
        private Panel panel10;
        private Label label9;
        private Panel panel6;
        private Label label5;
        private Panel panel7;
        private Label label6;
        private Panel panel8;
        private Label label7;
        private Label label8;
        private Panel panel2;
        private Panel panel4;
        private Label label4;
        private Panel panel3;
        private Label label3;
        private Panel panel9;
        private Label label2;
        private Label label1;
        private Label licensePlateLabel;
        private Label vehicleModeLabel;
        private Label vehicleTypeLabel;
        private Panel panel26;
        private Panel panel28;
        private Label transferStatusLabel;
        private Label label47;
        private Panel panel27;
        private Label execStatusLabel;
        private Label label45;
        private Label label79;
        private Label execLabel;
        private Label estimateExecLabel;
        private Label warehouseLabel;
        private Label estimateWarehouseLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel11;
        private Button fabricBtn;
        private DataGridView gridView;
        private Button pldgBtn;
        private Button plspBtn;
        private Panel panel12;
        private Label vehicleIdLabel;
        private Label label18;
        private TableLayoutPanel typeContainer;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel9;
        private TableLayoutPanel tableLayoutPanel8;
        private TableLayoutPanel tableLayoutPanel12;
        private TableLayoutPanel tableLayoutPanel13;
        private TableLayoutPanel tableLayoutPanel11;
        private TableLayoutPanel tableLayoutPanel10;
        private Button editBtn;
    }
}