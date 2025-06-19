using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Dto;
using WHS.Core.Response;
using WHS.Service.Interface;

namespace WHS.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;
        private bool _showPassword = true;

        public LoginForm(IUserService userService)
        {
            _userService = userService;

            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện login click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void loginBtn_Click(object sender, EventArgs e)
        {
            // Láy dữ liệu form login
            string username = userNameTxb.Text;
            string password = passwordTxb.Text;

            UserDto user = new UserDto
            {
                userName = username,
                password = password,
            };

            // Call api login
            Response<string> response = await _userService.Login(user);

            // Nếu success và có response data trả về thì get info
            if (response.success && !string.IsNullOrEmpty(response.data))
            {
                errorLabel.Text = String.Empty;
                errorLabel.Visible = false;
                Response<UserInfoDto> userResponse = await _userService.GetUserInfo();

                // Mở main form khi login thành công
                MainForm mainform = new MainForm();
                mainform.Show();

                // Xử lý nếu mainform bám đóng thì đóng luôn cả login form để đóng hẳn app
                mainform.FormClosed += (s, args) =>
                {
                    this.Close();
                };
                this.Hide();
            }
            else
            {
                errorLabel.Text = response.message;
                errorLabel.Visible = true;
            }
        }

        /// <summary>
        /// Sự click icon hide, off hide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (_showPassword)
            {
                pictureBox3.Image = Properties.Resources.eye_hide;
                passwordTxb.UseSystemPasswordChar = false;
                _showPassword = false;
            }
            else
            {
                pictureBox3.Image = Properties.Resources.eye;
                passwordTxb.UseSystemPasswordChar = true;
                _showPassword = true;
            }
        }
    }
}
