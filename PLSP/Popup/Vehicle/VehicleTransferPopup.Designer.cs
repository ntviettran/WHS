namespace WHS.Popup.Vehicle
{
    partial class VehicleTransferPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VehicleTransferPopup));
            gridView = new DataGridView();
            panel1 = new Panel();
            TransferId = new DataGridViewTextBoxColumn();
            ExecStatusDescription = new DataGridViewTextBoxColumn();
            TransferStatusDescription = new DataGridViewTextBoxColumn();
            VehicleModeDescription = new DataGridViewTextBoxColumn();
            VehicleTypeDescription = new DataGridViewTextBoxColumn();
            LicensePlate = new DataGridViewTextBoxColumn();
            SealNumber = new DataGridViewTextBoxColumn();
            Capacity = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // gridView
            // 
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;
            gridView.AllowUserToResizeRows = false;
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
            gridView.Columns.AddRange(new DataGridViewColumn[] { TransferId, ExecStatusDescription, TransferStatusDescription, VehicleModeDescription, VehicleTypeDescription, LicensePlate, SealNumber, Capacity });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridView.DefaultCellStyle = dataGridViewCellStyle2;
            gridView.Dock = DockStyle.Fill;
            gridView.EnableHeadersVisualStyles = false;
            gridView.Location = new Point(0, 0);
            gridView.MultiSelect = false;
            gridView.Name = "gridView";
            gridView.ReadOnly = true;
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            gridView.RowTemplate.Height = 35;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.Size = new Size(985, 410);
            gridView.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Controls.Add(gridView);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(985, 410);
            panel1.TabIndex = 6;
            // 
            // TransferId
            // 
            TransferId.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TransferId.DataPropertyName = "TransferId";
            TransferId.HeaderText = "ID đợt chuyển";
            TransferId.MinimumWidth = 6;
            TransferId.Name = "TransferId";
            TransferId.ReadOnly = true;
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
            TransferStatusDescription.HeaderText = "Trạng thái điều chuyển";
            TransferStatusDescription.MinimumWidth = 6;
            TransferStatusDescription.Name = "TransferStatusDescription";
            TransferStatusDescription.ReadOnly = true;
            // 
            // VehicleModeDescription
            // 
            VehicleModeDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            VehicleModeDescription.DataPropertyName = "VehicleModeDescription";
            VehicleModeDescription.HeaderText = "Hình thức";
            VehicleModeDescription.MinimumWidth = 6;
            VehicleModeDescription.Name = "VehicleModeDescription";
            VehicleModeDescription.ReadOnly = true;
            // 
            // VehicleTypeDescription
            // 
            VehicleTypeDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            VehicleTypeDescription.DataPropertyName = "VehicleTypeDescription";
            VehicleTypeDescription.HeaderText = "Loại xe";
            VehicleTypeDescription.MinimumWidth = 6;
            VehicleTypeDescription.Name = "VehicleTypeDescription";
            VehicleTypeDescription.ReadOnly = true;
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
            // VehicleTransferPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 450);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "VehicleTransferPopup";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            Load += VehicleTransferPopup_Load;
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridView;
        private Panel panel1;
        private DataGridViewTextBoxColumn TransferId;
        private DataGridViewTextBoxColumn ExecStatusDescription;
        private DataGridViewTextBoxColumn TransferStatusDescription;
        private DataGridViewTextBoxColumn VehicleModeDescription;
        private DataGridViewTextBoxColumn VehicleTypeDescription;
        private DataGridViewTextBoxColumn LicensePlate;
        private DataGridViewTextBoxColumn SealNumber;
        private DataGridViewTextBoxColumn Capacity;
    }
}