using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Dto.PO;
using WHS.Core.Enums;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Service.Interface;

namespace WHS.Popup.PO
{
    public partial class PoPopup : Form
    {
        public PODto Po { get; set; } = new PODto();
        public event EventHandler? SaveSuccess;

        private E_StatusPage _status  = E_StatusPage.ADD;
        private IPOService _poService;

        public PoPopup(IPOService poService)
        {
            _poService = poService;
            InitializeComponent();
        }

        public void InitEdit()
        {
            _status = E_StatusPage.EDIT;
            poTxb.Text = Po.PO;
            moTxb.Text = Po.MO;
            countryCodeTxb.Text = Po.CountryCode;
            idItemTxb.Text = Po.IdItem.ToString();
        }

        /// <summary>
        /// Sự kiện click nút cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Validate dữ liệu
        /// </summary>
        /// <exception cref="Exception"></exception>
        public bool ValidateInput()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(poTxb.Text))
            {
                errors.Add("PO không được để trống");
            }
            if (string.IsNullOrWhiteSpace(moTxb.Text))
            {
                errors.Add("MO không được để trống");
            }
            if (string.IsNullOrWhiteSpace(countryCodeTxb.Text))
            {
                errors.Add("Mã nước không được để trống");
            }
            if (string.IsNullOrWhiteSpace(idItemTxb.Text) || !int.TryParse(idItemTxb.Text, out _))
            {
                errors.Add("Id Item không hợp lệ");
            }

            if (errors.Count > 0)
            {
                ShowMessage.Warning(string.Join(Environment.NewLine, errors));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Sự kiện click nút Lưu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void saveBtn_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateInput();
            if (!isValid) return;

            Response<int> response;

            if (_status == E_StatusPage.EDIT)
            {
                response = await _poService.UpdatePO(Po.Id, new POCreateDto()
                {
                    PO = poTxb.Text.Trim(),
                    MO = moTxb.Text.Trim(),
                    CountryCode = countryCodeTxb.Text.Trim(),
                    IdItem = int.Parse(idItemTxb.Text.Trim())
                });
            }
            else
            {
                response = await _poService.CreatedNewPO(new POCreateDto()
                {
                    PO = poTxb.Text.Trim(),
                    MO = moTxb.Text.Trim(),
                    CountryCode = countryCodeTxb.Text.Trim(),
                    IdItem = int.Parse(idItemTxb.Text.Trim())
                });
            }

            if (!response.IsSuccess)
            {
                ShowMessage.Error(response.Message);
                return;
            }

            if (_status == E_StatusPage.ADD)
            {
                ShowMessage.Success("Thêm mới PO thành công");
                
            } else
            {
                ShowMessage.Success("Cập nhật PO thành công");
            }

            SaveSuccess?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
