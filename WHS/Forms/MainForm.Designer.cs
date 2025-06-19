namespace WHS.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            sidebar = new Panel();
            receiveSubMenu = new Panel();
            transactionReceiveBtn = new Button();
            detailReceiveBtn = new Button();
            receiveToggleBtn = new Button();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            mainLayout = new Panel();
            sidebar.SuspendLayout();
            receiveSubMenu.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // sidebar
            // 
            sidebar.AutoScroll = true;
            sidebar.BackColor = Color.Black;
            sidebar.Controls.Add(receiveSubMenu);
            sidebar.Controls.Add(receiveToggleBtn);
            sidebar.Controls.Add(panel2);
            sidebar.Dock = DockStyle.Left;
            sidebar.ForeColor = Color.White;
            sidebar.Location = new Point(0, 0);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(250, 450);
            sidebar.TabIndex = 0;
            // 
            // receiveSubMenu
            // 
            receiveSubMenu.BackColor = Color.FromArgb(35, 32, 39);
            receiveSubMenu.Controls.Add(transactionReceiveBtn);
            receiveSubMenu.Controls.Add(detailReceiveBtn);
            receiveSubMenu.Dock = DockStyle.Top;
            receiveSubMenu.Location = new Point(0, 134);
            receiveSubMenu.Name = "receiveSubMenu";
            receiveSubMenu.Size = new Size(250, 98);
            receiveSubMenu.TabIndex = 2;
            // 
            // transactionReceiveBtn
            // 
            transactionReceiveBtn.BackColor = Color.FromArgb(35, 32, 39);
            transactionReceiveBtn.Dock = DockStyle.Top;
            transactionReceiveBtn.FlatAppearance.BorderSize = 0;
            transactionReceiveBtn.FlatStyle = FlatStyle.Flat;
            transactionReceiveBtn.Location = new Point(0, 45);
            transactionReceiveBtn.Name = "transactionReceiveBtn";
            transactionReceiveBtn.Padding = new Padding(20, 0, 0, 0);
            transactionReceiveBtn.Size = new Size(250, 45);
            transactionReceiveBtn.TabIndex = 5;
            transactionReceiveBtn.Text = "Giao dịch NPL";
            transactionReceiveBtn.TextAlign = ContentAlignment.MiddleLeft;
            transactionReceiveBtn.UseVisualStyleBackColor = false;
            // 
            // detailReceiveBtn
            // 
            detailReceiveBtn.BackColor = Color.FromArgb(38, 32, 39);
            detailReceiveBtn.Dock = DockStyle.Top;
            detailReceiveBtn.FlatAppearance.BorderSize = 0;
            detailReceiveBtn.FlatStyle = FlatStyle.Flat;
            detailReceiveBtn.Location = new Point(0, 0);
            detailReceiveBtn.Name = "detailReceiveBtn";
            detailReceiveBtn.Padding = new Padding(20, 0, 0, 0);
            detailReceiveBtn.Size = new Size(250, 45);
            detailReceiveBtn.TabIndex = 4;
            detailReceiveBtn.Text = "Chi tiết NPL";
            detailReceiveBtn.TextAlign = ContentAlignment.MiddleLeft;
            detailReceiveBtn.UseVisualStyleBackColor = false;
            detailReceiveBtn.Click += detailReceiveBtn_Click;
            // 
            // receiveToggleBtn
            // 
            receiveToggleBtn.BackColor = Color.RoyalBlue;
            receiveToggleBtn.Dock = DockStyle.Top;
            receiveToggleBtn.FlatAppearance.BorderSize = 0;
            receiveToggleBtn.FlatStyle = FlatStyle.Flat;
            receiveToggleBtn.Location = new Point(0, 89);
            receiveToggleBtn.Name = "receiveToggleBtn";
            receiveToggleBtn.Size = new Size(250, 45);
            receiveToggleBtn.TabIndex = 1;
            receiveToggleBtn.Text = "NPL cần nhận";
            receiveToggleBtn.TextAlign = ContentAlignment.MiddleLeft;
            receiveToggleBtn.UseVisualStyleBackColor = false;
            receiveToggleBtn.Click += receiveToggleBtn_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 89);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(74, 15);
            label1.Name = "label1";
            label1.Size = new Size(168, 46);
            label1.TabIndex = 1;
            label1.Text = "KHO NPL";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_white;
            pictureBox1.Location = new Point(3, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(65, 65);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // mainLayout
            // 
            mainLayout.BackColor = Color.WhiteSmoke;
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(250, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.Size = new Size(550, 450);
            mainLayout.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainLayout);
            Controls.Add(sidebar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Kho NPL";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            sidebar.ResumeLayout(false);
            receiveSubMenu.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel sidebar;
        private Button receiveToggleBtn;
        private Panel panel2;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel receiveSubMenu;
        private Button detailReceiveBtn;
        private Button transactionReceiveBtn;
        private Panel mainLayout;
    }
}