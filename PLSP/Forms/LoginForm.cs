using PLSP.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Dto.User;
using WHS.Core.Response;
using WHS.Core.Session;
using WHS.Service.Interface;

namespace WHS.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;

        public LoginForm(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private async void userNameTxb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;

                // Láy dữ liệu form login
                string username = userNameTxb.Text;
                Session.CurrentUser = new UserInfoDto();

                // Call api login
                Response<UserInfoDto> response = await _userService.GetUser(username);

                // Nếu success và có response data trả về thì get info
                if (response.IsSuccess )
                {
                    var type = response.Data!.GetCurrentType();
                    Console.WriteLine($"Actual type: {type} ({(int)type})");

                    if (type == E_WHType.WORKER)
                    {
                        errorLabel.Text = "Bạn không có quyền truy cập app này!";
                        errorLabel.Visible = true;
                        return;
                    } 

                    errorLabel.Text = String.Empty;
                    errorLabel.Visible = false;

                    Session.CurrentUser = response.Data!;
                    // Mở main form khi login thành công
                    MainForm mainform = new MainForm();
                    mainform.Show();

                    // Xử lý nếu mainform bám đóng thì đóng luôn cả login form để đóng hẳn app
                    mainform.FormClosed += (s, args) =>
                    {
                        if (mainform.IsLogout)
                        {
                            userNameTxb.Text = "";
                            this.Show();
                            userNameTxb.Focus();
                        }
                        else this.Close();
                    };
                    this.Hide();
                }
                else
                {
                    errorLabel.Text = response.Message;
                    errorLabel.Visible = true;
                }
            }
        }
    }
}
