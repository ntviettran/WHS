namespace WHS.Popup.Transfer
{
    partial class VehiclePopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VehiclePopup));
            panel1 = new Panel();
            addBtn = new Button();
            cancelBtn = new Button();
            saveBtn = new Button();
            gridView = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            VehicleMode = new DataGridViewTextBoxColumn();
            VehicleType = new DataGridViewTextBoxColumn();
            LicensePlate = new DataGridViewTextBoxColumn();
            SealNumber = new DataGridViewTextBoxColumn();
            Capacity = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            licensePlateTxb = new TextBox();
            vehicleModeCb = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(addBtn);
            panel1.Controls.Add(cancelBtn);
            panel1.Controls.Add(saveBtn);
            panel1.Controls.Add(gridView);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(871, 496);
            panel1.TabIndex = 0;
            // 
            // addBtn
            // 
            addBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addBtn.BackColor = Color.FromArgb(0, 46, 92);
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(737, 66);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(134, 47);
            addBtn.TabIndex = 9;
            addBtn.Text = "Thêm mới";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelBtn.BackColor = Color.Crimson;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelBtn.ForeColor = Color.White;
            cancelBtn.Location = new Point(637, 446);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 47);
            cancelBtn.TabIndex = 8;
            cancelBtn.Text = "Hủy";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // saveBtn
            // 
            saveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveBtn.BackColor = Color.FromArgb(0, 46, 92);
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            saveBtn.ForeColor = Color.White;
            saveBtn.Location = new Point(737, 446);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(134, 47);
            saveBtn.TabIndex = 7;
            saveBtn.Text = "Xác nhận";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // gridView
            // 
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;
            gridView.AllowUserToResizeRows = false;
            gridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridView.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(0, 10, 0, 10);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridView.Columns.AddRange(new DataGridViewColumn[] { id, VehicleMode, VehicleType, LicensePlate, SealNumber, Capacity });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridView.DefaultCellStyle = dataGridViewCellStyle2;
            gridView.EnableHeadersVisualStyles = false;
            gridView.Location = new Point(0, 126);
            gridView.MultiSelect = false;
            gridView.Name = "gridView";
            gridView.ReadOnly = true;
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.RowTemplate.Height = 35;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.Size = new Size(871, 306);
            gridView.TabIndex = 4;
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            id.DataPropertyName = "ID";
            id.HeaderText = "ID";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.ReadOnly = true;
            // 
            // VehicleMode
            // 
            VehicleMode.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            VehicleMode.DataPropertyName = "VehicleMode";
            VehicleMode.HeaderText = "Hình thức";
            VehicleMode.MinimumWidth = 6;
            VehicleMode.Name = "VehicleMode";
            VehicleMode.ReadOnly = true;
            // 
            // VehicleType
            // 
            VehicleType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            VehicleType.DataPropertyName = "VehicleType";
            VehicleType.HeaderText = "Loại xe";
            VehicleType.MinimumWidth = 6;
            VehicleType.Name = "VehicleType";
            VehicleType.ReadOnly = true;
            // 
            // LicensePlate
            // 
            LicensePlate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            LicensePlate.DataPropertyName = "LicensePlate";
            LicensePlate.HeaderText = "Biển số xe";
            LicensePlate.MinimumWidth = 6;
            LicensePlate.Name = "LicensePlate";
            LicensePlate.ReadOnly = true;
            // 
            // SealNumber
            // 
            SealNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SealNumber.DataPropertyName = "SealNumber";
            SealNumber.HeaderText = "Số chì";
            SealNumber.MinimumWidth = 6;
            SealNumber.Name = "SealNumber";
            SealNumber.ReadOnly = true;
            // 
            // Capacity
            // 
            Capacity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Capacity.DataPropertyName = "Capacity";
            Capacity.HeaderText = "Tải trọng";
            Capacity.MinimumWidth = 6;
            Capacity.Name = "Capacity";
            Capacity.ReadOnly = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(licensePlateTxb);
            panel2.Controls.Add(vehicleModeCb);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(871, 49);
            panel2.TabIndex = 3;
            // 
            // licensePlateTxb
            // 
            licensePlateTxb.BorderStyle = BorderStyle.FixedSingle;
            licensePlateTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            licensePlateTxb.Location = new Point(462, 6);
            licensePlateTxb.Margin = new Padding(3, 4, 3, 4);
            licensePlateTxb.Name = "licensePlateTxb";
            licensePlateTxb.Size = new Size(205, 38);
            licensePlateTxb.TabIndex = 0;
            licensePlateTxb.KeyDown += licensePlateTxb_KeyDown;
            // 
            // vehicleModeCb
            // 
            vehicleModeCb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vehicleModeCb.FormattingEnabled = true;
            vehicleModeCb.Location = new Point(122, 5);
            vehicleModeCb.Name = "vehicleModeCb";
            vehicleModeCb.Size = new Size(193, 39);
            vehicleModeCb.TabIndex = 4;
            vehicleModeCb.SelectionChangeCommitted += vehicleModeCb_SelectionChangeCommitted;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(326, 7);
            label2.Name = "label2";
            label2.Size = new Size(130, 31);
            label2.TabIndex = 3;
            label2.Text = "Bảng số xe";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(-2, 7);
            label1.Name = "label1";
            label1.Size = new Size(122, 31);
            label1.TabIndex = 2;
            label1.Text = "Hình thức";
            // 
            // VehiclePopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 536);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "VehiclePopup";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin xe";
            Load += VehiclePopup_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private ComboBox vehicleModeCb;
        private Label label1;
        private TextBox licensePlateTxb;
        private Label label2;
        private DataGridView gridView;
        private Button addBtn;
        private Button cancelBtn;
        private Button saveBtn;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn VehicleMode;
        private DataGridViewTextBoxColumn VehicleType;
        private DataGridViewTextBoxColumn LicensePlate;
        private DataGridViewTextBoxColumn SealNumber;
        private DataGridViewTextBoxColumn Capacity;
    }
}