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
using WHS.Core.Enums;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Popup.Receive.DetailReceive;
using WHS.Service.Interface;
using WHS.Service.Services;
using WHS.Utils;

namespace WHS.Popup
{
    public partial class FabricPopup : BasePopup
    {
        private readonly IReceiveService<FabricDto, FabricReceivedDto> _fabricService;

        public FabricPopup(IReceiveService<FabricDto, FabricReceivedDto> receiveService) : base(receiveService)
        {
            InitializeComponent();

            _fabricService = receiveService;
            _gridView = this.gridView;
            _sampleBtn = this.sampleFileBtn;
            _addBtn = this.addBtn;
            _cancelBtn = this.cancelBtn;

            RegisterSampleButtonEvent(name: "vai");
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
        private void FabricPopup_Load(object sender, EventArgs e)
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
                    ["Style"] = "Style",
                    ["Color"] = "Màu",
                    ["FabricType"] = "Loại vải",
                    ["Batch"] = "Lot",
                    ["FabricLength"] = "Chiều dài",
                    ["LengthUnit"] = "Đơn vị chiều dài",
                    ["FabricWeight"] = "Khối lượng",
                    ["WeightUnit"] = "Đơn vị khối lượng",
                    ["FabricNumber"] = "Cuộn số",
                    ["RollWidth"] = "Khổ",
                    ["WidthUnit"] = "Đơn vị khổ",
                    ["QuantityToReceived"] = "Số lượng cần nhận",
                    ["ReceivedQuantity"] = "Số lượng đã nhận",
                    ["RemainingQuantity"] = "Số lượng còn lại",
                    ["EstimateQuantity"] = "Số lượng dự kiến nhận",
                    ["QuantityUnit"] = "Đơn vị số lượng",
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
                    ["Style"] = "Style",
                    ["Color"] = "Màu",
                    ["FabricType"] = "Loại vải",
                    ["Batch"] = "Lot",
                    ["FabricLength"] = "Chiều dài",
                    ["LengthUnit"] = "Đơn vị chiều dài",
                    ["FabricWeight"] = "Khối lượng",
                    ["WeightUnit"] = "Đơn vị khối lượng",
                    ["FabricNumber"] = "Cuộn số",
                    ["RollWidth"] = "Khổ",
                    ["WidthUnit"] = "Đơn vị khổ",
                    ["QuantityToReceived"] = "Số lượng cần nhận",
                    ["QuantityUnit"] = "Đơn vị số lượng",
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

            Response<List<FabricReceivedDto>> res = await _fabricService.GetReceiveDetailAsync(_receiveData);

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

            Response<int> res = await _fabricService.CreateReceiveAsync(_dataTable);

            if (!res.IsSuccess)
            {
                MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = ShowMessage.Success(res.Message);
            if (result == DialogResult.OK) { 
                RaiseSaveSuccess();
                this.Close();            
            }
        }
        #endregion
    }
}
