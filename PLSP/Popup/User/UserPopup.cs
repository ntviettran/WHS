using PLSP.Core.Dto.User;
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
using WHS.Core.Enums;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Factory;
using WHS.Service.Interface;

namespace PLSP.Popup.User
{
    public partial class UserPopup : Form
    {
        private E_StatusForm _statusForm = E_StatusForm.ADD;
        private UserInfoDto? _userEdit = new UserInfoDto();

        public Action? SaveSucess;
        public UserPopup(E_StatusForm status, UserInfoDto? user)
        {
            InitializeComponent();

            _statusForm = status;
            _userEdit = user;
        }

        private void UserPopup_Load(object sender, EventArgs e)
        {
            if (_statusForm == E_StatusForm.EDIT && _userEdit != null)
            {
                ssidTxb.Text = _userEdit.SSID;
                ssidTxb.ReadOnly = true;
                addBtn.Text = "Sửa";
                codeTxb.Text = _userEdit.Code.ToString();
                limitQuantityTxb.Value = _userEdit.LimitQuantity ?? 0;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ssidTxb.Text)) {
                ShowMessage.Warning("Vui lòng điền đủ thông tin SSID");
                return;
            }

            if (string.IsNullOrEmpty(codeTxb.Text))
            {
                ShowMessage.Warning("Vui lòng điền đủ thông tin mã nhân viên");
                return;
            }

            if (!int.TryParse(codeTxb.Text, out int code))
            {
                ShowMessage.Warning("Mã nhân viên không hợp lệ");
                return;
            }

            UserCreateDto user = new UserCreateDto()
            {
                SSID = ssidTxb.Text,
                Code = code,
                LimitQuantity = (int)limitQuantityTxb.Value
            };

            Response<int> res = null!;
            IUserService service = ServiceFactory.GetUserService();

            if (_statusForm == E_StatusForm.ADD)
            {
                res = await service.CreateUser(user);
            }
            else
            {
                res = await service.UpdateUser(_userEdit!.ID, user);
            }

            if (!res.IsSuccess) { 
                ShowMessage.Error(res.Message);
                return;
            }

            string status = _statusForm == E_StatusForm.ADD ? "Thêm mới" : "Cập nhật";
            DialogResult result = ShowMessage.Success($"{status} thành công");

            if (result == DialogResult.OK) {
                SaveSucess?.Invoke();
                this.Close();
            }
        }
    }
}
