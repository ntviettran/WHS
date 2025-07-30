using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.PLDG;
using WHS.Core.Dto.Receive;
using WHS.Core.Enums;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Popup.Receive.DetailReceive;
using WHS.Service.Interface;
using WHS.Service.Services;
using WHS.Utils;

namespace WHS.Popup
{
    public partial class PLDGPopup : BasePopup
    {
        private readonly IReceiveService<PldgDto, PldgReceivedDto> _pldgService;

        public PLDGPopup(IReceiveService<PldgDto, PldgReceivedDto> receiveService) : base(receiveService)
        {

            InitializeComponent();

            _pldgService = receiveService;
            _gridView = this.gridView;
            _sampleBtn = this.sampleFileBtn;
            _addBtn = this.addBtn;
            _cancelBtn = this.cancelBtn;

            RegisterSampleButtonEvent(name: "plđg");
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
        private void PLDGPopup_Load(object sender, EventArgs e)
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
                    ["PldgType"] = "Loại phụ liệu",
                    ["PldgCode"] = "Mã code",
                    ["PoCode"] = "Mã PO",
                    ["QuantityPerCarton"] = "Số chiếc mỗi thùng",
                    ["NetWeight"] = "N.W",
                    ["GrossWeight"] = "G.W",
                    ["Color"] = "Màu",
                    ["PldgWeight"] = "Khối lượng",
                    ["WeightUnit"] = "Đơn vị khối lương",
                    ["PldgSize"] = "Kích thước",
                    ["SizeUnit"] = "Đơn vị kích thước",
                    ["QuantityToReceived"] = "Số lượng cần nhận",
                    ["ReceivedQuantity"] = "Số lượng đã nhận",
                    ["RemainingQuantity"] = "Số lượng còn lại",
                    ["EstimateQuantity"] = "Số lượng dự kiến nhận",
                    ["OrderDateVN"] = "Ngày đặt hàng",
                    ["AvailableDateVN"] = "Ngày có thể nhận",
                    ["ExpectedDateVN"] = "Ngày dự kiến nhận",
                    ["StatusDescription"] = "Ngày dự kiến nhận",
                    ["DispatchStatusDescription"] = "Ngày dự kiến nhận",
                };
            } else
            {
                _columns = new Dictionary<string, string>()
                {
                    ["MO"] = "MO",
                    ["Supplier"] = "Mã nhà cung cấp",
                    ["PldgType"] = "Loại phụ liệu",
                    ["PldgCode"] = "Mã code",
                    ["PoCode"] = "Mã PO",
                    ["QuantityPerCarton"] = "Số chiếc mỗi thùng",
                    ["NetWeight"] = "N.W",
                    ["GrossWeight"] = "G.W",
                    ["Color"] = "Màu",
                    ["PldgWeight"] = "Khối lượng",
                    ["WeightUnit"] = "Đơn vị khối lương",
                    ["PldgSize"] = "Kích thước",
                    ["SizeUnit"] = "Đơn vị kích thước",
                    ["QuantityToReceived"] = "Số lượng cần nhận",
                    ["OrderDate"] = "Ngày đặt hàng",
                    ["StatusDescription"] = "Trạng thái",
                    ["DispatchStatusDescription"] = "Trạng thái điều phối",
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

            Response<List<PldgReceivedDto>> res = await _pldgService.GetReceiveDetailAsync(_receiveData);

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

            Response<int> res = await _pldgService.CreateReceiveAsync(_dataTable);
            
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
