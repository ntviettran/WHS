namespace WHS.Popup.Transfer
{
    partial class AddTransferDetailPopup
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTransferDetailPopup));
            panel1 = new Panel();
            backBtn = new Button();
            saveBtn = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            label2 = new Label();
            coordinateDetailView = new DataGridView();
            panel4 = new Panel();
            label1 = new Label();
            coordinateView = new DataGridView();
            typeContainer = new TableLayoutPanel();
            pldgBtn = new Button();
            plspBtn = new Button();
            fabricBtn = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            label7 = new Label();
            panel2 = new Panel();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)coordinateDetailView).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)coordinateView).BeginInit();
            typeContainer.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(backBtn);
            panel1.Controls.Add(saveBtn);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(typeContainer);
            panel1.Controls.Add(tableLayoutPanel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(1191, 855);
            panel1.TabIndex = 0;
            // 
            // backBtn
            // 
            backBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            backBtn.BackColor = Color.Crimson;
            backBtn.FlatStyle = FlatStyle.Flat;
            backBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            backBtn.ForeColor = Color.White;
            backBtn.Location = new Point(972, 805);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(116, 47);
            backBtn.TabIndex = 26;
            backBtn.Text = "Quay lại";
            backBtn.UseVisualStyleBackColor = false;
            backBtn.Click += backBtn_Click;
            // 
            // saveBtn
            // 
            saveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveBtn.BackColor = Color.FromArgb(0, 46, 92);
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            saveBtn.ForeColor = Color.White;
            saveBtn.Location = new Point(1094, 805);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(94, 47);
            saveBtn.TabIndex = 25;
            saveBtn.Text = "Lưu";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Controls.Add(panel4, 0, 0);
            tableLayoutPanel1.Location = new Point(1, 128);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1187, 657);
            tableLayoutPanel1.TabIndex = 24;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(coordinateDetailView);
            panel3.Location = new Point(3, 331);
            panel3.Name = "panel3";
            panel3.Size = new Size(1181, 323);
            panel3.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(-1, 5);
            label2.Name = "label2";
            label2.Size = new Size(245, 38);
            label2.TabIndex = 23;
            label2.Text = "Chi tiết điều phối";
            // 
            // coordinateDetailView
            // 
            coordinateDetailView.AllowUserToAddRows = false;
            coordinateDetailView.AllowUserToDeleteRows = false;
            coordinateDetailView.AllowUserToResizeRows = false;
            coordinateDetailView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            coordinateDetailView.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(10);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            coordinateDetailView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            coordinateDetailView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            coordinateDetailView.DefaultCellStyle = dataGridViewCellStyle2;
            coordinateDetailView.EnableHeadersVisualStyles = false;
            coordinateDetailView.Location = new Point(2, 45);
            coordinateDetailView.Name = "coordinateDetailView";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            coordinateDetailView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            coordinateDetailView.RowHeadersWidth = 51;
            coordinateDetailView.RowTemplate.Height = 35;
            coordinateDetailView.Size = new Size(1179, 275);
            coordinateDetailView.TabIndex = 22;
            coordinateDetailView.KeyDown += coordinateDetailView_KeyDown;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Controls.Add(coordinateView);
            panel4.Controls.Add(label1);
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(1181, 322);
            panel4.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 10);
            label1.Name = "label1";
            label1.Size = new Size(199, 38);
            label1.TabIndex = 22;
            label1.Text = "Cần điều phối";
            // 
            // coordinateView
            // 
            coordinateView.AllowUserToAddRows = false;
            coordinateView.AllowUserToDeleteRows = false;
            coordinateView.AllowUserToResizeRows = false;
            coordinateView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            coordinateView.BackgroundColor = Color.White;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.Padding = new Padding(10);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 46, 92);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            coordinateView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            coordinateView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            coordinateView.DefaultCellStyle = dataGridViewCellStyle5;
            coordinateView.EnableHeadersVisualStyles = false;
            coordinateView.Location = new Point(1, 50);
            coordinateView.Name = "coordinateView";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            coordinateView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            coordinateView.RowHeadersVisible = false;
            coordinateView.RowHeadersWidth = 51;
            coordinateView.RowTemplate.Height = 35;
            coordinateView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            coordinateView.Size = new Size(1179, 272);
            coordinateView.TabIndex = 21;
            coordinateView.CellContentClick += coordinateView_CellContentClick;
            // 
            // typeContainer
            // 
            typeContainer.ColumnCount = 3;
            typeContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            typeContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            typeContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            typeContainer.Controls.Add(pldgBtn, 2, 0);
            typeContainer.Controls.Add(plspBtn, 1, 0);
            typeContainer.Controls.Add(fabricBtn, 0, 0);
            typeContainer.Dock = DockStyle.Top;
            typeContainer.Location = new Point(0, 52);
            typeContainer.Name = "typeContainer";
            typeContainer.RowCount = 1;
            typeContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            typeContainer.Size = new Size(1191, 54);
            typeContainer.TabIndex = 22;
            // 
            // pldgBtn
            // 
            pldgBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pldgBtn.BackColor = Color.DarkGray;
            pldgBtn.FlatStyle = FlatStyle.Flat;
            pldgBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pldgBtn.ForeColor = Color.White;
            pldgBtn.Location = new Point(1094, 3);
            pldgBtn.Name = "pldgBtn";
            pldgBtn.Size = new Size(94, 47);
            pldgBtn.TabIndex = 2;
            pldgBtn.Text = "PLĐG";
            pldgBtn.UseVisualStyleBackColor = false;
            pldgBtn.Click += pldgBtn_Click;
            // 
            // plspBtn
            // 
            plspBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            plspBtn.BackColor = Color.DarkGray;
            plspBtn.FlatStyle = FlatStyle.Flat;
            plspBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            plspBtn.ForeColor = Color.White;
            plspBtn.Location = new Point(548, 3);
            plspBtn.Name = "plspBtn";
            plspBtn.Size = new Size(94, 48);
            plspBtn.TabIndex = 1;
            plspBtn.Text = "PLSP";
            plspBtn.UseVisualStyleBackColor = false;
            plspBtn.Click += plspBtn_Click;
            // 
            // fabricBtn
            // 
            fabricBtn.BackColor = Color.FromArgb(0, 46, 92);
            fabricBtn.FlatStyle = FlatStyle.Flat;
            fabricBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fabricBtn.ForeColor = Color.White;
            fabricBtn.Location = new Point(3, 3);
            fabricBtn.Name = "fabricBtn";
            fabricBtn.Size = new Size(94, 45);
            fabricBtn.TabIndex = 0;
            fabricBtn.Text = "Vải";
            fabricBtn.UseVisualStyleBackColor = false;
            fabricBtn.Click += fabricBtn_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(label7, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Top;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(1191, 52);
            tableLayoutPanel3.TabIndex = 15;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(434, 0);
            label7.Name = "label7";
            label7.Size = new Size(322, 46);
            label7.TabIndex = 0;
            label7.Text = "Chi tiết đợt chuyển";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(-9, 111);
            panel2.Name = "panel2";
            panel2.Size = new Size(1196, 1);
            panel2.TabIndex = 17;
            // 
            // AddTransferDetailPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1231, 895);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddTransferDetailPopup";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm chi tiết đợt chuyển";
            FormClosed += AddTransferDetailPopup_FormClosed;
            Load += AddTransferDetailPopup_Load;
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)coordinateDetailView).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)coordinateView).EndInit();
            typeContainer.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel typeContainer;
        private Button pldgBtn;
        private Button plspBtn;
        private Button fabricBtn;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label7;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private Label label2;
        private DataGridView coordinateDetailView;
        private Panel panel4;
        private Label label1;
        private DataGridView coordinateView;
        private Button backBtn;
        private Button saveBtn;
    }
}