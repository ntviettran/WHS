namespace PLSP.Popup.User
{
    partial class UserPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserPopup));
            panel1 = new Panel();
            limitQuantityTxb = new NumericUpDown();
            cancelBtn = new Button();
            addBtn = new Button();
            label3 = new Label();
            codeTxb = new TextBox();
            label1 = new Label();
            ssidTxb = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)limitQuantityTxb).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(limitQuantityTxb);
            panel1.Controls.Add(cancelBtn);
            panel1.Controls.Add(addBtn);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(codeTxb);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(ssidTxb);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(402, 387);
            panel1.TabIndex = 0;
            // 
            // limitQuantityTxb
            // 
            limitQuantityTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            limitQuantityTxb.Location = new Point(3, 254);
            limitQuantityTxb.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            limitQuantityTxb.Name = "limitQuantityTxb";
            limitQuantityTxb.Size = new Size(393, 38);
            limitQuantityTxb.TabIndex = 43;
            // 
            // cancelBtn
            // 
            cancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelBtn.BackColor = Color.Crimson;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelBtn.ForeColor = Color.White;
            cancelBtn.Location = new Point(173, 335);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 47);
            cancelBtn.TabIndex = 42;
            cancelBtn.Text = "Hủy";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // addBtn
            // 
            addBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            addBtn.BackColor = Color.FromArgb(0, 46, 92);
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(273, 335);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(123, 47);
            addBtn.TabIndex = 41;
            addBtn.Text = "Thêm";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(4, 205);
            label3.Name = "label3";
            label3.Size = new Size(301, 31);
            label3.TabIndex = 40;
            label3.Text = "Số lượng giới hạn mỗi ngày";
            // 
            // codeTxb
            // 
            codeTxb.BorderStyle = BorderStyle.FixedSingle;
            codeTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            codeTxb.Location = new Point(3, 144);
            codeTxb.Margin = new Padding(3, 4, 3, 4);
            codeTxb.Name = "codeTxb";
            codeTxb.Size = new Size(393, 38);
            codeTxb.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 100);
            label1.Name = "label1";
            label1.Size = new Size(153, 31);
            label1.TabIndex = 38;
            label1.Text = "Mã nhân viên";
            // 
            // ssidTxb
            // 
            ssidTxb.BorderStyle = BorderStyle.FixedSingle;
            ssidTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ssidTxb.Location = new Point(3, 44);
            ssidTxb.Margin = new Padding(3, 4, 3, 4);
            ssidTxb.Name = "ssidTxb";
            ssidTxb.Size = new Size(393, 38);
            ssidTxb.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(3, 5);
            label2.Name = "label2";
            label2.Size = new Size(64, 31);
            label2.TabIndex = 36;
            label2.Text = "SSID";
            // 
            // UserPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 427);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UserPopup";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            Load += UserPopup_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)limitQuantityTxb).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private TextBox codeTxb;
        private Label label1;
        private TextBox ssidTxb;
        private Label label2;
        private Button addBtn;
        private Button cancelBtn;
        private NumericUpDown limitQuantityTxb;
    }
}