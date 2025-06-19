namespace WHS.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label1 = new Label();
            label2 = new Label();
            loginBtn = new Button();
            panel1 = new Panel();
            userNameTxb = new TextBox();
            panel2 = new Panel();
            pictureBox3 = new PictureBox();
            passwordTxb = new TextBox();
            errorLabel = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(106, 113);
            label1.Name = "label1";
            label1.Size = new Size(87, 23);
            label1.TabIndex = 2;
            label1.Text = "Tài khoản";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(108, 222);
            label2.Name = "label2";
            label2.Size = new Size(86, 23);
            label2.TabIndex = 3;
            label2.Text = "Mật khẩu";
            // 
            // loginBtn
            // 
            loginBtn.BackColor = Color.DodgerBlue;
            loginBtn.FlatAppearance.BorderSize = 0;
            loginBtn.FlatStyle = FlatStyle.Flat;
            loginBtn.ForeColor = Color.White;
            loginBtn.Location = new Point(112, 354);
            loginBtn.Margin = new Padding(3, 4, 3, 4);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(261, 45);
            loginBtn.TabIndex = 4;
            loginBtn.Text = "Đăng nhập";
            loginBtn.UseVisualStyleBackColor = false;
            loginBtn.Click += loginBtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(userNameTxb);
            panel1.Location = new Point(111, 144);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(261, 45);
            panel1.TabIndex = 0;
            // 
            // userNameTxb
            // 
            userNameTxb.BorderStyle = BorderStyle.None;
            userNameTxb.Location = new Point(8, 11);
            userNameTxb.Margin = new Padding(3, 4, 3, 4);
            userNameTxb.Name = "userNameTxb";
            userNameTxb.Size = new Size(243, 20);
            userNameTxb.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(passwordTxb);
            panel2.Location = new Point(111, 252);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(261, 45);
            panel2.TabIndex = 1;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.eye;
            pictureBox3.Location = new Point(227, 9);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(24, 24);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // passwordTxb
            // 
            passwordTxb.BorderStyle = BorderStyle.None;
            passwordTxb.Location = new Point(8, 11);
            passwordTxb.Margin = new Padding(3, 4, 3, 4);
            passwordTxb.Name = "passwordTxb";
            passwordTxb.Size = new Size(211, 20);
            passwordTxb.TabIndex = 1;
            passwordTxb.UseSystemPasswordChar = true;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(109, 309);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(41, 20);
            errorLabel.TabIndex = 8;
            errorLabel.Text = "error";
            errorLabel.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(149, 31);
            label3.Name = "label3";
            label3.Size = new Size(194, 46);
            label3.TabIndex = 9;
            label3.Text = "Đăng nhập";
            // 
            // LoginForm
            // 
            AcceptButton = loginBtn;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(476, 445);
            Controls.Add(label3);
            Controls.Add(errorLabel);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(loginBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Button loginBtn;
        private Panel panel1;
        private TextBox userNameTxb;
        private Panel panel2;
        private TextBox passwordTxb;
        private Label errorLabel;
        private Label label3;
        private PictureBox pictureBox3;
    }
}