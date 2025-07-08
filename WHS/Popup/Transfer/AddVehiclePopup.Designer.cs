namespace WHS.Popup.Transfer
{
    partial class AddVehiclePopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVehiclePopup));
            panel1 = new Panel();
            cancelBtn = new Button();
            nextBtn = new Button();
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
            vehicleModeCb = new ComboBox();
            label12 = new Label();
            panel31 = new Panel();
            vehicleTypeCb = new ComboBox();
            label13 = new Label();
            panel34 = new Panel();
            idTxb = new TextBox();
            label14 = new Label();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel19.SuspendLayout();
            panel22.SuspendLayout();
            panel25.SuspendLayout();
            panel28.SuspendLayout();
            panel31.SuspendLayout();
            panel34.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cancelBtn);
            panel1.Controls.Add(nextBtn);
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(653, 336);
            panel1.TabIndex = 0;
            // 
            // cancelBtn
            // 
            cancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelBtn.BackColor = Color.Crimson;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelBtn.ForeColor = Color.White;
            cancelBtn.Location = new Point(428, 287);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 47);
            cancelBtn.TabIndex = 10;
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
            nextBtn.Location = new Point(528, 287);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(123, 47);
            nextBtn.TabIndex = 9;
            nextBtn.Text = "Xác nhận";
            nextBtn.UseVisualStyleBackColor = false;
            nextBtn.Click += nextBtn_Click;
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
            tableLayoutPanel2.Location = new Point(0, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(652, 266);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // panel19
            // 
            panel19.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel19.Controls.Add(capacityTxb);
            panel19.Controls.Add(label9);
            panel19.Location = new Point(329, 179);
            panel19.Name = "panel19";
            panel19.Size = new Size(320, 84);
            panel19.TabIndex = 6;
            // 
            // capacityTxb
            // 
            capacityTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            capacityTxb.BorderStyle = BorderStyle.FixedSingle;
            capacityTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            capacityTxb.Location = new Point(3, 40);
            capacityTxb.Margin = new Padding(3, 4, 3, 4);
            capacityTxb.Name = "capacityTxb";
            capacityTxb.Size = new Size(315, 38);
            capacityTxb.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(-2, 5);
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
            panel22.Size = new Size(320, 84);
            panel22.TabIndex = 5;
            // 
            // sealNumberTxb
            // 
            sealNumberTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sealNumberTxb.BorderStyle = BorderStyle.FixedSingle;
            sealNumberTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sealNumberTxb.Location = new Point(2, 40);
            sealNumberTxb.Margin = new Padding(3, 4, 3, 4);
            sealNumberTxb.Name = "sealNumberTxb";
            sealNumberTxb.Size = new Size(317, 38);
            sealNumberTxb.TabIndex = 1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(-4, 6);
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
            panel25.Location = new Point(329, 91);
            panel25.Name = "panel25";
            panel25.Size = new Size(320, 82);
            panel25.TabIndex = 4;
            // 
            // licensePlateTxb
            // 
            licensePlateTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            licensePlateTxb.BorderStyle = BorderStyle.FixedSingle;
            licensePlateTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            licensePlateTxb.Location = new Point(3, 39);
            licensePlateTxb.Margin = new Padding(3, 4, 3, 4);
            licensePlateTxb.Name = "licensePlateTxb";
            licensePlateTxb.Size = new Size(315, 38);
            licensePlateTxb.TabIndex = 0;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(-2, 4);
            label11.Name = "label11";
            label11.Size = new Size(124, 31);
            label11.TabIndex = 2;
            label11.Text = "Bảng số xe";
            // 
            // panel28
            // 
            panel28.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel28.Controls.Add(vehicleModeCb);
            panel28.Controls.Add(label12);
            panel28.Location = new Point(3, 91);
            panel28.Name = "panel28";
            panel28.Size = new Size(320, 82);
            panel28.TabIndex = 3;
            // 
            // vehicleModeCb
            // 
            vehicleModeCb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            vehicleModeCb.DropDownHeight = 400;
            vehicleModeCb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vehicleModeCb.FormattingEnabled = true;
            vehicleModeCb.IntegralHeight = false;
            vehicleModeCb.ItemHeight = 31;
            vehicleModeCb.Location = new Point(2, 39);
            vehicleModeCb.Name = "vehicleModeCb";
            vehicleModeCb.Size = new Size(315, 39);
            vehicleModeCb.TabIndex = 4;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(-3, 5);
            label12.Name = "label12";
            label12.Size = new Size(189, 31);
            label12.TabIndex = 2;
            label12.Text = "Loại phương tiện";
            // 
            // panel31
            // 
            panel31.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel31.Controls.Add(vehicleTypeCb);
            panel31.Controls.Add(label13);
            panel31.Location = new Point(329, 3);
            panel31.Name = "panel31";
            panel31.Size = new Size(320, 82);
            panel31.TabIndex = 2;
            // 
            // vehicleTypeCb
            // 
            vehicleTypeCb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            vehicleTypeCb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vehicleTypeCb.FormattingEnabled = true;
            vehicleTypeCb.Location = new Point(2, 37);
            vehicleTypeCb.Name = "vehicleTypeCb";
            vehicleTypeCb.Size = new Size(316, 39);
            vehicleTypeCb.TabIndex = 3;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(-5, 4);
            label13.Name = "label13";
            label13.Size = new Size(114, 31);
            label13.TabIndex = 2;
            label13.Text = "Hình thức";
            // 
            // panel34
            // 
            panel34.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel34.Controls.Add(idTxb);
            panel34.Controls.Add(label14);
            panel34.Location = new Point(3, 3);
            panel34.Name = "panel34";
            panel34.Size = new Size(320, 82);
            panel34.TabIndex = 1;
            // 
            // idTxb
            // 
            idTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            idTxb.BorderStyle = BorderStyle.FixedSingle;
            idTxb.Enabled = false;
            idTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idTxb.Location = new Point(3, 38);
            idTxb.Margin = new Padding(3, 4, 3, 4);
            idTxb.Name = "idTxb";
            idTxb.Size = new Size(314, 38);
            idTxb.TabIndex = 0;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(-3, 2);
            label14.Name = "label14";
            label14.Size = new Size(36, 31);
            label14.TabIndex = 2;
            label14.Text = "ID";
            // 
            // AddVehiclePopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 376);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddVehiclePopup";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm mới phương tiện";
            Load += AddVehiclePopup_Load;
            panel1.ResumeLayout(false);
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
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
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
        private Panel panel31;
        private Label label13;
        private Panel panel34;
        private Label label14;
        private TextBox idTxb;
        private Button cancelBtn;
        private Button nextBtn;
        private ComboBox vehicleModeCb;
        private ComboBox vehicleTypeCb;
    }
}