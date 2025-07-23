namespace WHS.Popup.Receive.ReceiveDetailTransaction
{
    partial class PLSPTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLSPTransaction));
            panel2 = new Panel();
            panel7 = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            label4 = new Label();
            dispatchStatusCb = new ComboBox();
            panel1 = new Panel();
            label3 = new Label();
            statusCb = new ComboBox();
            gridView = new DataGridView();
            label8 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            moTxb = new TextBox();
            label1 = new Label();
            panel4 = new Panel();
            typeTxb = new TextBox();
            label2 = new Label();
            panel10 = new Panel();
            supplierTxb = new TextBox();
            label6 = new Label();
            panel13 = new Panel();
            quantityTxb = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)_dataTable).BeginInit();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel10.SuspendLayout();
            panel13.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(panel7);
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(gridView);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(20, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(1342, 763);
            panel2.TabIndex = 3;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel7.BackColor = Color.Black;
            panel7.Location = new Point(3, 110);
            panel7.Name = "panel7";
            panel7.Size = new Size(1339, 1);
            panel7.TabIndex = 23;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(panel5);
            panel6.Controls.Add(panel1);
            panel6.Location = new Point(0, 132);
            panel6.Name = "panel6";
            panel6.Size = new Size(1339, 71);
            panel6.TabIndex = 22;
            // 
            // panel5
            // 
            panel5.Controls.Add(label4);
            panel5.Controls.Add(dispatchStatusCb);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(375, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(434, 71);
            panel5.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 17);
            label4.Name = "label4";
            label4.Size = new Size(219, 31);
            label4.TabIndex = 0;
            label4.Text = "Trạng thái điều phối";
            // 
            // dispatchStatusCb
            // 
            dispatchStatusCb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dispatchStatusCb.FormattingEnabled = true;
            dispatchStatusCb.Location = new Point(225, 14);
            dispatchStatusCb.Name = "dispatchStatusCb";
            dispatchStatusCb.Size = new Size(206, 39);
            dispatchStatusCb.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(statusCb);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(375, 71);
            panel1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 17);
            label3.Name = "label3";
            label3.Size = new Size(116, 31);
            label3.TabIndex = 0;
            label3.Text = "Trạng thái";
            // 
            // statusCb
            // 
            statusCb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusCb.FormattingEnabled = true;
            statusCb.Location = new Point(122, 14);
            statusCb.Name = "statusCb";
            statusCb.Size = new Size(223, 39);
            statusCb.TabIndex = 0;
            // 
            // gridView
            // 
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;
            gridView.AllowUserToResizeColumns = false;
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
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridView.DefaultCellStyle = dataGridViewCellStyle2;
            gridView.EnableHeadersVisualStyles = false;
            gridView.Location = new Point(0, 224);
            gridView.Name = "gridView";
            gridView.RowHeadersVisible = false;
            gridView.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            gridView.RowTemplate.Height = 35;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.Size = new Size(1339, 536);
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
            tableLayoutPanel1.Controls.Add(panel4, 1, 0);
            tableLayoutPanel1.Controls.Add(panel10, 2, 0);
            tableLayoutPanel1.Controls.Add(panel13, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.00121F));
            tableLayoutPanel1.Size = new Size(1342, 94);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(moTxb);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(329, 88);
            panel3.TabIndex = 0;
            // 
            // moTxb
            // 
            moTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            moTxb.BorderStyle = BorderStyle.FixedSingle;
            moTxb.Enabled = false;
            moTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            moTxb.Location = new Point(2, 40);
            moTxb.Margin = new Padding(3, 4, 3, 4);
            moTxb.Name = "moTxb";
            moTxb.Size = new Size(327, 38);
            moTxb.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 6);
            label1.Name = "label1";
            label1.Size = new Size(52, 31);
            label1.TabIndex = 2;
            label1.Text = "MO";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.AutoSize = true;
            panel4.Controls.Add(typeTxb);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(338, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(329, 88);
            panel4.TabIndex = 1;
            // 
            // typeTxb
            // 
            typeTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            typeTxb.BorderStyle = BorderStyle.FixedSingle;
            typeTxb.Enabled = false;
            typeTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeTxb.Location = new Point(2, 40);
            typeTxb.Margin = new Padding(3, 4, 3, 4);
            typeTxb.Name = "typeTxb";
            typeTxb.Size = new Size(327, 38);
            typeTxb.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(-2, 6);
            label2.Name = "label2";
            label2.Size = new Size(145, 31);
            label2.TabIndex = 2;
            label2.Text = "Loại phụ liệu";
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.AutoSize = true;
            panel10.Controls.Add(supplierTxb);
            panel10.Controls.Add(label6);
            panel10.Location = new Point(673, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(329, 88);
            panel10.TabIndex = 2;
            // 
            // supplierTxb
            // 
            supplierTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            supplierTxb.BorderStyle = BorderStyle.FixedSingle;
            supplierTxb.Enabled = false;
            supplierTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            supplierTxb.Location = new Point(2, 41);
            supplierTxb.Margin = new Padding(3, 4, 3, 4);
            supplierTxb.Name = "supplierTxb";
            supplierTxb.Size = new Size(327, 38);
            supplierTxb.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(3, 6);
            label6.Name = "label6";
            label6.Size = new Size(191, 31);
            label6.TabIndex = 7;
            label6.Text = "Mã nhà cung cấp";
            // 
            // panel13
            // 
            panel13.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel13.AutoSize = true;
            panel13.Controls.Add(quantityTxb);
            panel13.Controls.Add(label5);
            panel13.Location = new Point(1008, 3);
            panel13.Name = "panel13";
            panel13.Size = new Size(331, 88);
            panel13.TabIndex = 3;
            // 
            // quantityTxb
            // 
            quantityTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            quantityTxb.BorderStyle = BorderStyle.FixedSingle;
            quantityTxb.Enabled = false;
            quantityTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            quantityTxb.Location = new Point(2, 41);
            quantityTxb.Margin = new Padding(3, 4, 3, 4);
            quantityTxb.Name = "quantityTxb";
            quantityTxb.Size = new Size(329, 38);
            quantityTxb.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(-1, 4);
            label5.Name = "label5";
            label5.Size = new Size(205, 31);
            label5.TabIndex = 2;
            label5.Text = "Số lượng cần nhận";
            // 
            // PLSPTransaction
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 803);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PLSPTransaction";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NPL Vải";
            Load += PLSPTransaction_Load;
            ((System.ComponentModel.ISupportInitialize)_dataTable).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label8;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private TextBox moTxb;
        private Label label1;
        private Panel panel4;
        private TextBox typeTxb;
        private Label label2;
        private Panel panel10;
        private TextBox supplierTxb;
        private Label label6;
        private Panel panel13;
        private TextBox quantityTxb;
        private Label label5;
        private DataGridView gridView;
        private Panel panel6;
        private Panel panel5;
        private Label label4;
        private ComboBox dispatchStatusCb;
        private Panel panel1;
        private Label label3;
        private ComboBox statusCb;
        private Panel panel7;
    }
}