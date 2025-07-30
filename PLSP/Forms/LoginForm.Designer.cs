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
            userNameTxb = new TextBox();
            errorLabel = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(101, 113);
            label1.Name = "label1";
            label1.Size = new Size(53, 31);
            label1.TabIndex = 2;
            label1.Text = "Thẻ";
            // 
            // userNameTxb
            // 
            userNameTxb.BorderStyle = BorderStyle.FixedSingle;
            userNameTxb.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userNameTxb.Location = new Point(106, 153);
            userNameTxb.Margin = new Padding(3, 4, 3, 4);
            userNameTxb.Name = "userNameTxb";
            userNameTxb.PlaceholderText = "Quét thẻ";
            userNameTxb.Size = new Size(267, 38);
            userNameTxb.TabIndex = 0;
            userNameTxb.KeyDown += userNameTxb_KeyDown;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(106, 215);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(41, 20);
            errorLabel.TabIndex = 8;
            errorLabel.Text = "error";
            errorLabel.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(127, 31);
            label3.Name = "label3";
            label3.Size = new Size(230, 54);
            label3.TabIndex = 9;
            label3.Text = "Đăng nhập";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(476, 282);
            Controls.Add(userNameTxb);
            Controls.Add(label3);
            Controls.Add(errorLabel);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox userNameTxb;
        private Label errorLabel;
        private Label label3;
    }
}