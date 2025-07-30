namespace PLSP.Popup.Inventory
{
    partial class MoveToLocationPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveToLocationPopup));
            panel1 = new Panel();
            saveBtn = new Button();
            locationGridView = new DataGridView();
            moveQuantityLabel = new Label();
            label5 = new Label();
            IdLabel = new Label();
            label8 = new Label();
            inventoryQuantityLabel = new Label();
            label6 = new Label();
            moLabel = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)locationGridView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(saveBtn);
            panel1.Controls.Add(locationGridView);
            panel1.Controls.Add(moveQuantityLabel);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(IdLabel);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(inventoryQuantityLabel);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(moLabel);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(661, 496);
            panel1.TabIndex = 0;
            // 
            // saveBtn
            // 
            saveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveBtn.BackColor = Color.FromArgb(0, 46, 92);
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            saveBtn.ForeColor = Color.White;
            saveBtn.Location = new Point(564, 436);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(94, 57);
            saveBtn.TabIndex = 36;
            saveBtn.Text = "Lưu";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // locationGridView
            // 
            locationGridView.AllowUserToDeleteRows = false;
            locationGridView.AllowUserToResizeRows = false;
            locationGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            locationGridView.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(0, 10, 0, 10);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            locationGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            locationGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            locationGridView.DefaultCellStyle = dataGridViewCellStyle2;
            locationGridView.EnableHeadersVisualStyles = false;
            locationGridView.Location = new Point(3, 183);
            locationGridView.Name = "locationGridView";
            locationGridView.RowHeadersWidth = 51;
            locationGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            locationGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            locationGridView.RowTemplate.Height = 35;
            locationGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            locationGridView.Size = new Size(655, 241);
            locationGridView.TabIndex = 35;
            locationGridView.CellValueChanged += locationGridView_CellValueChanged;
            // 
            // moveQuantityLabel
            // 
            moveQuantityLabel.AutoSize = true;
            moveQuantityLabel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            moveQuantityLabel.ForeColor = Color.Black;
            moveQuantityLabel.Location = new Point(295, 119);
            moveQuantityLabel.Name = "moveQuantityLabel";
            moveQuantityLabel.Size = new Size(175, 31);
            moveQuantityLabel.TabIndex = 34;
            moveQuantityLabel.Text = "Chưa có dữ liệu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(2, 119);
            label5.Name = "label5";
            label5.Size = new Size(287, 31);
            label5.TabIndex = 33;
            label5.Text = "Số lượng đã xếp vào vị trí:";
            // 
            // IdLabel
            // 
            IdLabel.AutoSize = true;
            IdLabel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IdLabel.ForeColor = Color.Black;
            IdLabel.Location = new Point(52, 3);
            IdLabel.Name = "IdLabel";
            IdLabel.Size = new Size(175, 31);
            IdLabel.TabIndex = 32;
            IdLabel.Text = "Chưa có dữ liệu";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(2, 3);
            label8.Name = "label8";
            label8.Size = new Size(44, 31);
            label8.TabIndex = 31;
            label8.Text = "ID:";
            // 
            // inventoryQuantityLabel
            // 
            inventoryQuantityLabel.AutoSize = true;
            inventoryQuantityLabel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            inventoryQuantityLabel.ForeColor = Color.Black;
            inventoryQuantityLabel.Location = new Point(163, 79);
            inventoryQuantityLabel.Name = "inventoryQuantityLabel";
            inventoryQuantityLabel.Size = new Size(175, 31);
            inventoryQuantityLabel.TabIndex = 30;
            inventoryQuantityLabel.Text = "Chưa có dữ liệu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(2, 79);
            label6.Name = "label6";
            label6.Size = new Size(155, 31);
            label6.TabIndex = 29;
            label6.Text = "Số lượng tồn:";
            // 
            // moLabel
            // 
            moLabel.AutoSize = true;
            moLabel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            moLabel.ForeColor = Color.Black;
            moLabel.Location = new Point(61, 41);
            moLabel.Name = "moLabel";
            moLabel.Size = new Size(175, 31);
            moLabel.TabIndex = 28;
            moLabel.Text = "Chưa có dữ liệu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(2, 41);
            label3.Name = "label3";
            label3.Size = new Size(58, 31);
            label3.TabIndex = 27;
            label3.Text = "MO:";
            // 
            // MoveToLocationPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 536);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MoveToLocationPopup";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sắp xếp vị trí";
            Load += MoveToLocationPopup_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)locationGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label moveQuantityLabel;
        private Label label5;
        private Label IdLabel;
        private Label label8;
        private Label inventoryQuantityLabel;
        private Label label6;
        private Label moLabel;
        private Label label3;
        private Button saveBtn;
        private DataGridView locationGridView;
    }
}