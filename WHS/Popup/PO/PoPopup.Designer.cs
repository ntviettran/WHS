namespace WHS.Popup.PO
{
    partial class PoPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PoPopup));
            panel1 = new Panel();
            saveBtn = new Button();
            cancelBtn = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel25 = new Panel();
            addIDBtn = new Panel();
            idItemTxb = new TextBox();
            label11 = new Label();
            panel28 = new Panel();
            countryCodeTxb = new TextBox();
            label12 = new Label();
            panel31 = new Panel();
            moTxb = new TextBox();
            label13 = new Label();
            panel34 = new Panel();
            poTxb = new TextBox();
            label14 = new Label();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel25.SuspendLayout();
            panel28.SuspendLayout();
            panel31.SuspendLayout();
            panel34.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(saveBtn);
            panel1.Controls.Add(cancelBtn);
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(571, 258);
            panel1.TabIndex = 1;
            // 
            // saveBtn
            // 
            saveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveBtn.BackColor = Color.FromArgb(0, 46, 92);
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            saveBtn.ForeColor = Color.White;
            saveBtn.Location = new Point(463, 208);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(105, 47);
            saveBtn.TabIndex = 13;
            saveBtn.Text = "Lưu";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelBtn.BackColor = Color.Crimson;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelBtn.ForeColor = Color.White;
            cancelBtn.Location = new Point(363, 208);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 47);
            cancelBtn.TabIndex = 10;
            cancelBtn.Text = "Hủy";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel25, 1, 1);
            tableLayoutPanel2.Controls.Add(panel28, 0, 1);
            tableLayoutPanel2.Controls.Add(panel31, 1, 0);
            tableLayoutPanel2.Controls.Add(panel34, 0, 0);
            tableLayoutPanel2.Location = new Point(0, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(568, 180);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // panel25
            // 
            panel25.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel25.Controls.Add(addIDBtn);
            panel25.Controls.Add(idItemTxb);
            panel25.Controls.Add(label11);
            panel25.Location = new Point(287, 93);
            panel25.Name = "panel25";
            panel25.Size = new Size(278, 84);
            panel25.TabIndex = 4;
            // 
            // addIDBtn
            // 
            addIDBtn.BackgroundImage = Properties.Resources.plus;
            addIDBtn.BackgroundImageLayout = ImageLayout.Zoom;
            addIDBtn.BorderStyle = BorderStyle.FixedSingle;
            addIDBtn.Location = new Point(237, 39);
            addIDBtn.Margin = new Padding(0);
            addIDBtn.Name = "addIDBtn";
            addIDBtn.Size = new Size(38, 38);
            addIDBtn.TabIndex = 11;
            // 
            // idItemTxb
            // 
            idItemTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            idItemTxb.BorderStyle = BorderStyle.FixedSingle;
            idItemTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idItemTxb.Location = new Point(3, 39);
            idItemTxb.Margin = new Padding(3, 4, 3, 4);
            idItemTxb.Name = "idItemTxb";
            idItemTxb.Size = new Size(234, 38);
            idItemTxb.TabIndex = 0;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(-2, 4);
            label11.Name = "label11";
            label11.Size = new Size(88, 31);
            label11.TabIndex = 2;
            label11.Text = "ID Item";
            // 
            // panel28
            // 
            panel28.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel28.Controls.Add(countryCodeTxb);
            panel28.Controls.Add(label12);
            panel28.Location = new Point(3, 93);
            panel28.Name = "panel28";
            panel28.Size = new Size(278, 84);
            panel28.TabIndex = 3;
            // 
            // countryCodeTxb
            // 
            countryCodeTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            countryCodeTxb.BorderStyle = BorderStyle.FixedSingle;
            countryCodeTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            countryCodeTxb.Location = new Point(3, 40);
            countryCodeTxb.Margin = new Padding(3, 4, 3, 4);
            countryCodeTxb.Name = "countryCodeTxb";
            countryCodeTxb.Size = new Size(272, 38);
            countryCodeTxb.TabIndex = 3;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(-3, 5);
            label12.Name = "label12";
            label12.Size = new Size(105, 31);
            label12.TabIndex = 2;
            label12.Text = "Mã nước";
            // 
            // panel31
            // 
            panel31.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel31.Controls.Add(moTxb);
            panel31.Controls.Add(label13);
            panel31.Location = new Point(287, 3);
            panel31.Name = "panel31";
            panel31.Size = new Size(278, 84);
            panel31.TabIndex = 2;
            // 
            // moTxb
            // 
            moTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            moTxb.BorderStyle = BorderStyle.FixedSingle;
            moTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            moTxb.Location = new Point(3, 39);
            moTxb.Margin = new Padding(3, 4, 3, 4);
            moTxb.Name = "moTxb";
            moTxb.Size = new Size(272, 38);
            moTxb.TabIndex = 3;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(-5, 4);
            label13.Name = "label13";
            label13.Size = new Size(52, 31);
            label13.TabIndex = 2;
            label13.Text = "MO";
            // 
            // panel34
            // 
            panel34.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel34.Controls.Add(poTxb);
            panel34.Controls.Add(label14);
            panel34.Location = new Point(3, 3);
            panel34.Name = "panel34";
            panel34.Size = new Size(278, 84);
            panel34.TabIndex = 1;
            // 
            // poTxb
            // 
            poTxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            poTxb.BorderStyle = BorderStyle.FixedSingle;
            poTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            poTxb.Location = new Point(3, 38);
            poTxb.Margin = new Padding(3, 4, 3, 4);
            poTxb.Name = "poTxb";
            poTxb.Size = new Size(272, 38);
            poTxb.TabIndex = 0;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(-3, 2);
            label14.Name = "label14";
            label14.Size = new Size(44, 31);
            label14.TabIndex = 2;
            label14.Text = "PO";
            // 
            // PoPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 298);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PoPopup";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PO";
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
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
        private Button cancelBtn;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel25;
        private TextBox idItemTxb;
        private Label label11;
        private Panel panel28;
        private TextBox countryCodeTxb;
        private Label label12;
        private Panel panel31;
        private TextBox moTxb;
        private Label label13;
        private Panel panel34;
        private TextBox poTxb;
        private Label label14;
        private Panel addIDBtn;
        private Button saveBtn;
    }
}