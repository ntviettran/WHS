namespace PLSP.Pages.Warehouse
{
    partial class QRLocation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            rowTxb = new TextBox();
            columnTxb = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            exportBtn = new Button();
            importBtn = new Button();
            addBtn = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(addBtn);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(872, 495);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(rowTxb);
            panel2.Controls.Add(columnTxb);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(exportBtn);
            panel2.Controls.Add(importBtn);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(872, 495);
            panel2.TabIndex = 38;
            // 
            // rowTxb
            // 
            rowTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rowTxb.Location = new Point(132, 201);
            rowTxb.Name = "rowTxb";
            rowTxb.Size = new Size(257, 38);
            rowTxb.TabIndex = 44;
            rowTxb.Text = "14";
            // 
            // columnTxb
            // 
            columnTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            columnTxb.Location = new Point(132, 136);
            columnTxb.Name = "columnTxb";
            columnTxb.Size = new Size(257, 38);
            columnTxb.TabIndex = 43;
            columnTxb.Text = "7";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 204);
            label2.Name = "label2";
            label2.Size = new Size(99, 31);
            label2.TabIndex = 42;
            label2.Text = "Số hàng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 139);
            label3.Name = "label3";
            label3.Size = new Size(80, 31);
            label3.TabIndex = 41;
            label3.Text = "Số cột";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 76);
            label1.Name = "label1";
            label1.Size = new Size(266, 31);
            label1.TabIndex = 39;
            label1.Text = "Cấu hình QR trên 1 trang";
            // 
            // exportBtn
            // 
            exportBtn.BackColor = Color.FromArgb(0, 46, 92);
            exportBtn.FlatStyle = FlatStyle.Flat;
            exportBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exportBtn.ForeColor = Color.White;
            exportBtn.Location = new Point(132, 3);
            exportBtn.Name = "exportBtn";
            exportBtn.Size = new Size(123, 47);
            exportBtn.TabIndex = 38;
            exportBtn.Text = "Xuất QR";
            exportBtn.UseVisualStyleBackColor = false;
            exportBtn.Click += exportBtn_Click;
            // 
            // importBtn
            // 
            importBtn.BackColor = Color.DarkGreen;
            importBtn.FlatStyle = FlatStyle.Flat;
            importBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            importBtn.ForeColor = Color.White;
            importBtn.Location = new Point(3, 3);
            importBtn.Name = "importBtn";
            importBtn.Size = new Size(123, 47);
            importBtn.TabIndex = 37;
            importBtn.Text = "Thêm";
            importBtn.UseVisualStyleBackColor = false;
            importBtn.Click += importBtn_Click;
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.FromArgb(0, 46, 92);
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(3, 3);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(123, 47);
            addBtn.TabIndex = 37;
            addBtn.Text = "Thêm";
            addBtn.UseVisualStyleBackColor = false;
            // 
            // QRLocation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "QRLocation";
            Padding = new Padding(20);
            Size = new Size(912, 535);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button exportBtn;
        private Button importBtn;
        private Button addBtn;
        private TextBox rowTxb;
        private TextBox columnTxb;
        private Label label2;
        private Label label3;
        private Label label1;
    }
}
