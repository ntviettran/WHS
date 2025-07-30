using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.PLDG;
using WHS.Core.Dto.PLSP;
using WHS.Core.Enums;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Popup.Receive.DetailReceive;
using WHS.Service.Interface;
using WHS.Utils;

namespace WHS.Popup
{
    public partial class PLSPPopup : BasePopup
    {
        private readonly IReceiveService<PlspDto, PlspReceivedDto> _plspService;
        public PLSPPopup(IReceiveService<PlspDto, PlspReceivedDto> receiveService) : base(receiveService)
        {

            InitializeComponent();

            _plspService = receiveService;
            _gridView = this.gridView;
            _sampleBtn = this.sampleFileBtn;
            _addBtn = this.addBtn;
            _cancelBtn = this.cancelBtn;

            RegisterSampleButtonEvent(name: "plsp");
            RegisterAddButtonEvent();
            RegisterCancelButtonEvent();
            RegisterGridViewEvent();
        }

        #region setup

        /// <summary>
        /// Setup load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PLSPPopup_Load(object sender, EventArgs e)
        {
            GridViewUtils.SetBuffer(gridView);
        }

        /// <summary>
        /// Nếu là trạng thái edit thì fill data vào input
        /// </summary>
        protected override void InitUI()
        {
            if (_statusForm == E_StatusForm.VIEW)
            {
                panel1.Visible = false;
                panel3.Visible = false;
                _columns = new Dictionary<string, string>()
                {
                    ["ID"] = "ID",
                    ["MO"] = "MO",
                    ["Supplier"] = "Mã nhà cung cấp",
                    ["PlspType"] = "Loại phụ liệu",
                    ["PlspCode"] = "Mã code",
                    ["NplColor"] = "Màu",
                    ["MarketCode"] = "Mã thị trường",
                    ["Size"] = "Kích thước",
                    ["PlspColor"] = "Màu sản phẩm",
                    ["QuantityToReceived"] = "Số lượng cần nhận",
                    ["ReceivedQuantity"] = "Số lượng đã nhận",
                    ["RemainingQuantity"] = "Số lượng còn lại",
                    ["EstimateQuantity"] = "Số lượng dự kiến nhận",
                    ["OrderDateVN"] = "Ngày đặt hàng",
                    ["AvailableDateVN"] = "Ngày có thể nhận",
                    ["ExpectedDateVN"] = "Ngày dự kiến nhận",
                    ["StatusDescription"] = "Trạng thái",
                    ["DispatchStatusDescription"] = "Trạng thái điều phối",
                };
            } else
            {
                _columns = new Dictionary<string, string>()
                {
                    ["MO"] = "MO",
                    ["Supplier"] = "Mã nhà cung cấp",
                    ["PlspType"] = "Loại phụ liệu",
                    ["PlspCode"] = "Mã code",
                    ["NplColor"] = "Màu",
                    ["MarketCode"] = "Mã thị trường",
                    ["Size"] = "Kích thước",
                    ["PlspColor"] = "Màu sản phẩm",
                    ["QuantityToReceived"] = "Số lượng cần nhận",
                    ["OrderDate"] = "Ngày đặt hàng",
                    ["AvailableDate"] = "Ngày có thể nhận",
                    ["ExpectedDate"] = "Ngày dự kiến nhận",
                };
            }

            SetupGridView();
            InitGridView();
        }

        /// <summary>
        /// Fill bảng dataGridView
        /// </summary>
        private async void InitGridView()
        {
            if (_statusForm == E_StatusForm.ADD) return;
            if (_receiveData == null) return;

            Response<List<PlspReceivedDto>> res = await _plspService.GetReceiveDetailAsync(_receiveData);

            if (!res.IsSuccess)
            {
                ShowMessage.Error(res.Message);
                return;
            }

            if (res.Data != null)
            {
                gridView.DataSource = res.Data;
                gridView.ClearSelection();
            }
        }

        #endregion

        #region save
        /// <summary>
        /// Sự kiện click save form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void saveBtn_Click(object sender, EventArgs e)
        {

            if (_statusForm != E_StatusForm.ADD) return;

            List<string> numCols = new List<string>() { "QuantityToReceived" };
            bool validateDetail = ValidateNPLDetail(numCols);
            if (!validateDetail) return;

            Response<int> res = await _plspService.CreateReceiveAsync(_dataTable);

            if (!res.IsSuccess)
            {
                MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = ShowMessage.Success(res.Message);
            if (result == DialogResult.OK)
            {
                RaiseSaveSuccess();
                this.Close();
            }
        }

        #endregion
    }
}
