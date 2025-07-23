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
            logoutToggleBtn = new Button();
            panel1 = new Panel();
            transferWarhouseSubMenu = new Panel();
            coordinateManage = new Button();
            transferToggleBtn = new Button();
            deliverySubMenu = new Panel();
            coordinateBtn = new Button();
            detailReceiveBtn = new Button();
            deliveryToggleBtn = new Button();
            poToggleBtn = new Button();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            mainLayout = new Panel();
            sidebar.SuspendLayout();
            panel1.SuspendLayout();
            transferWarhouseSubMenu.SuspendLayout();
            deliverySubMenu.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // sidebar
            // 
            sidebar.AutoScroll = true;
            sidebar.BackColor = Color.Black;
            sidebar.Controls.Add(logoutToggleBtn);
            sidebar.Controls.Add(panel1);
            sidebar.Controls.Add(panel2);
            sidebar.Dock = DockStyle.Left;
            sidebar.ForeColor = Color.White;
            sidebar.Location = new Point(0, 0);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(290, 619);
            sidebar.TabIndex = 0;
            // 
            // logoutToggleBtn
            // 
            logoutToggleBtn.BackColor = Color.Black;
            logoutToggleBtn.Dock = DockStyle.Bottom;
            logoutToggleBtn.FlatAppearance.BorderSize = 0;
            logoutToggleBtn.FlatStyle = FlatStyle.Flat;
            logoutToggleBtn.Font = new Font("Segoe UI", 13.8F);
            logoutToggleBtn.Location = new Point(0, 574);
            logoutToggleBtn.Name = "logoutToggleBtn";
            logoutToggleBtn.Size = new Size(290, 45);
            logoutToggleBtn.TabIndex = 7;
            logoutToggleBtn.Text = "Đăng xuất";
            logoutToggleBtn.TextAlign = ContentAlignment.MiddleLeft;
            logoutToggleBtn.UseVisualStyleBackColor = false;
            logoutToggleBtn.Click += logoutBtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(transferWarhouseSubMenu);
            panel1.Controls.Add(transferToggleBtn);
            panel1.Controls.Add(deliverySubMenu);
            panel1.Controls.Add(deliveryToggleBtn);
            panel1.Controls.Add(poToggleBtn);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 89);
            panel1.Name = "panel1";
            panel1.Size = new Size(290, 406);
            panel1.TabIndex = 1;
            // 
            // transferWarhouseSubMenu
            // 
            transferWarhouseSubMenu.BackColor = Color.FromArgb(35, 32, 39);
            transferWarhouseSubMenu.Controls.Add(coordinateManage);
            transferWarhouseSubMenu.Dock = DockStyle.Top;
            transferWarhouseSubMenu.Location = new Point(0, 233);
            transferWarhouseSubMenu.Name = "transferWarhouseSubMenu";
            transferWarhouseSubMenu.Size = new Size(290, 52);
            transferWarhouseSubMenu.TabIndex = 12;
            // 
            // coordinateManage
            // 
            coordinateManage.Dock = DockStyle.Top;
            coordinateManage.FlatAppearance.BorderSize = 0;
            coordinateManage.FlatStyle = FlatStyle.Flat;
            coordinateManage.Font = new Font("Segoe UI", 13.8F);
            coordinateManage.ForeColor = Color.Transparent;
            coordinateManage.Location = new Point(0, 0);
            coordinateManage.Name = "coordinateManage";
            coordinateManage.Padding = new Padding(20, 0, 0, 0);
            coordinateManage.Size = new Size(290, 45);
            coordinateManage.TabIndex = 0;
            coordinateManage.Text = "Quản lí đợt chuyển";
            coordinateManage.TextAlign = ContentAlignment.MiddleLeft;
            coordinateManage.UseVisualStyleBackColor = true;
            coordinateManage.Click += coordinateManage_Click;
            // 
            // transferToggleBtn
            // 
            transferToggleBtn.BackColor = Color.Black;
            transferToggleBtn.Dock = DockStyle.Top;
            transferToggleBtn.FlatAppearance.BorderSize = 0;
            transferToggleBtn.FlatStyle = FlatStyle.Flat;
            transferToggleBtn.Font = new Font("Segoe UI", 13.8F);
            transferToggleBtn.Location = new Point(0, 188);
            transferToggleBtn.Name = "transferToggleBtn";
            transferToggleBtn.Size = new Size(290, 45);
            transferToggleBtn.TabIndex = 11;
            transferToggleBtn.Text = "Đợt chuyển";
            transferToggleBtn.TextAlign = ContentAlignment.MiddleLeft;
            transferToggleBtn.UseVisualStyleBackColor = false;
            transferToggleBtn.Click += transferToggleBtn_Click;
            // 
            // deliverySubMenu
            // 
            deliverySubMenu.BackColor = Color.FromArgb(35, 32, 39);
            deliverySubMenu.Controls.Add(detailReceiveBtn);
            deliverySubMenu.Controls.Add(coordinateBtn);
            deliverySubMenu.Dock = DockStyle.Top;
            deliverySubMenu.Location = new Point(0, 90);
            deliverySubMenu.Name = "deliverySubMenu";
            deliverySubMenu.Size = new Size(290, 98);
            deliverySubMenu.TabIndex = 9;
            // 
            // coordinateBtn
            // 
            coordinateBtn.Dock = DockStyle.Top;
            coordinateBtn.FlatAppearance.BorderSize = 0;
            coordinateBtn.FlatStyle = FlatStyle.Flat;
            coordinateBtn.Font = new Font("Segoe UI", 13.8F);
            coordinateBtn.ForeColor = Color.Transparent;
            coordinateBtn.Location = new Point(0, 45);
            coordinateBtn.Name = "coordinateBtn";
            coordinateBtn.Padding = new Padding(20, 0, 0, 0);
            coordinateBtn.Size = new Size(290, 45);
            coordinateBtn.TabIndex = 0;
            coordinateBtn.Text = "Điều phối";
            coordinateBtn.TextAlign = ContentAlignment.MiddleLeft;
            coordinateBtn.UseVisualStyleBackColor = true;
            coordinateBtn.Click += coordinateBtn_Click;
            // 
            // detailReceiveBtn
            // 
            detailReceiveBtn.BackColor = Color.FromArgb(38, 32, 39);
            detailReceiveBtn.Dock = DockStyle.Top;
            detailReceiveBtn.FlatAppearance.BorderSize = 0;
            detailReceiveBtn.FlatStyle = FlatStyle.Flat;
            detailReceiveBtn.Font = new Font("Segoe UI", 13.8F);
            detailReceiveBtn.Location = new Point(0, 0);
            detailReceiveBtn.Name = "detailReceiveBtn";
            detailReceiveBtn.Padding = new Padding(20, 0, 0, 0);
            detailReceiveBtn.Size = new Size(290, 45);
            detailReceiveBtn.TabIndex = 4;
            detailReceiveBtn.Text = "Theo dõi NPL cần nhận";
            detailReceiveBtn.TextAlign = ContentAlignment.MiddleLeft;
            detailReceiveBtn.UseVisualStyleBackColor = false;
            detailReceiveBtn.Click += detailReceiveBtn_Click;
            // 
            // deliveryToggleBtn
            // 
            deliveryToggleBtn.BackColor = Color.Black;
            deliveryToggleBtn.Dock = DockStyle.Top;
            deliveryToggleBtn.FlatAppearance.BorderSize = 0;
            deliveryToggleBtn.FlatStyle = FlatStyle.Flat;
            deliveryToggleBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            deliveryToggleBtn.Location = new Point(0, 45);
            deliveryToggleBtn.Name = "deliveryToggleBtn";
            deliveryToggleBtn.Size = new Size(290, 45);
            deliveryToggleBtn.TabIndex = 8;
            deliveryToggleBtn.Text = "Vận chuyển";
            deliveryToggleBtn.TextAlign = ContentAlignment.MiddleLeft;
            deliveryToggleBtn.UseVisualStyleBackColor = false;
            deliveryToggleBtn.Click += deliveryToggleBtn_Click;
            // 
            // poToggleBtn
            // 
            poToggleBtn.BackColor = Color.Black;
            poToggleBtn.Dock = DockStyle.Top;
            poToggleBtn.FlatAppearance.BorderSize = 0;
            poToggleBtn.FlatStyle = FlatStyle.Flat;
            poToggleBtn.Font = new Font("Segoe UI", 13.8F);
            poToggleBtn.Location = new Point(0, 0);
            poToggleBtn.Name = "poToggleBtn";
            poToggleBtn.Size = new Size(290, 45);
            poToggleBtn.TabIndex = 13;
            poToggleBtn.Text = "PO";
            poToggleBtn.TextAlign = ContentAlignment.MiddleLeft;
            poToggleBtn.UseVisualStyleBackColor = false;
            poToggleBtn.Click += poToggleBtn_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(290, 89);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(77, 15);
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
            mainLayout.Location = new Point(290, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.Size = new Size(510, 619);
            mainLayout.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 619);
            Controls.Add(mainLayout);
            Controls.Add(sidebar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Kho NPL";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            sidebar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            transferWarhouseSubMenu.ResumeLayout(false);
            deliverySubMenu.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel sidebar;
        private Panel panel2;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel mainLayout;
        private Button logoutToggleBtn;
        private Panel panel1;
        private Panel transferWarhouseSubMenu;
        private Button coordinateManage;
        private Button transferToggleBtn;
        private Button coordinateBtn;
        private Panel deliverySubMenu;
        private Button detailReceiveBtn;
        private Button deliveryToggleBtn;
        private Button poToggleBtn;
    }
}