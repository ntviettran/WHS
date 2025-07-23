using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Dto.Fabric;
using WHS.Core.Enums;
using WHS.Core.Query.Receive;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Service.Interface;
using WHS.Utils;

namespace WHS.Popup.Receive.ReceiveDetailTransaction
{
    public partial class FabricTransaction : BaseTransaction
    {
        private ITransferService<FabricCoordinationDto, FabricTransferDetailDto> _transferService;

        public FabricTransaction(ITransferService<FabricCoordinationDto, FabricTransferDetailDto> transferService)
        {
            InitializeComponent();
            _transferService = transferService;
            _columns = new Dictionary<string, string>()
            {
                {"Style", "Style"},
                {"Color", "Màu"},
                {"FabricType", "Loại vải"},
                {"Batch", "Lot"},
                {"FabricNumber", "Cuộn số"},
                {"FabricLength", "Chiều dài"},
                {"LengthUnit", "Đơn vị chiều dài"},
                {"FabricWeight", "Khối lượng"},
                {"WeightUnit", "Đơn vị khối lượng"},
                {"RollWidth", "Khổ"},
                {"QuantityToReceived", "Số lượng cần nhận"},
                {"QuantityReceived", "Số lượng đã nhận"},
                {"RemainingQuantity", "Số lượng còn phải nhận"},
                {"StatusDescription", "Số lượng cần nhận"},
                {"DispatchStatusDescription", "Số lượng cần nhận"},
            };

            _gridView = gridView;
            _statusCb = statusCb;
            _dispatchStatusCb = dispatchStatusCb;

            SetupCombobox();
            SetupGridView();
        }


        private void FabricTransaction_Load(object sender, EventArgs e)
        {
            GridViewUtils.SetBuffer(gridView);
        }

        /// <summary>
        /// Nếu là trạng thái edit thì fill data vào input
        /// </summary>
        protected override void InitUI()
        {
            InitInput();
            InitGridView();
        }

        /// <summary>
        /// Fill giá trị cho input khi ở chế độ edit
        /// </summary>
        private void InitInput()
        {
            moTxb.Text = _receiveData.MO;
            styleTxb.Text = _receiveData.Style;
            colorTxb.Text = _receiveData.Color;
            fabricTypeTxb.Text = _receiveData.TypeDetail;
            supplierTxb.Text = _receiveData.Supplier;
            quantityTxb.Text = _receiveData.QuantityToReceived.ToString();
        }

        /// <summary>
        /// Fill bảng dataGridView
        /// </summary>
        protected override async void InitGridView()
        {
            if (_receiveData == null) return;

            ReceiveHistorySearch search = new ReceiveHistorySearch()
            {
                ReceiveId = _receiveData.Id,
                Status = _statusCb.SelectedValue != null ? Convert.ToInt32(_statusCb.SelectedValue) : -1,
                DispatchStatus = _dispatchStatusCb.SelectedValue != null ? Convert.ToInt32(_dispatchStatusCb.SelectedValue) : -1
            };

            Response<List<FabricCoordinationDto>> res = await _transferService.GetCoordinationHistory(search);

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
    }
}
