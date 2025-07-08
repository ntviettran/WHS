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
using WHS.Service.Interface;
using WHS.Service.Services;

namespace WHS.Popup
{
    public partial class PLDGPopup : BasePopup
    {
        private readonly IReceiveService<PldgDto, PldgDetailDto> _pldgService;

        public PLDGPopup(IReceiveService<PldgDto, PldgDetailDto> receiveService) : base(receiveService)
        {

            InitializeComponent();

            _pldgService = receiveService;
            _columns = new Dictionary<string, string>()
            {
                {"PldgType", "Loại phụ liệu"},
                {"PackCode", "Mã pack"},
                {"PoCode", "Mã PO"},
                {"QuantityPerCarton", "Số chiếc mỗi thùng"},
                {"NetWeight", "N.W"},
                {"GrossWeight", "G.W"},
                {"Color", "Màu"},
                {"PldgWeight", "Khối lượng"},
                {"WeightUnit", "Đơn vị khối lương"},
                {"PldgSize","Kích thước"},
                {"SizeUnit", "Đơn vị kích thước"},
                {"QuantityToReceived", "Số lượng cần nhận"}
            };

            _gridView = this.gridView;
            _sampleBtn = this.sampleFileBtn;
            _addBtn = this.addBtn;
            _cancelBtn = this.cancelBtn;

            SetupGridView();
            RegisterSampleButtonEvent(name: "plđg");
            RegisterAddButtonEvent();
            RegisterCancelButtonEvent();
            RegisterDeleteDetailEvent();
        }

        #region setup

        /// <summary>
        /// Setup load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PLDGPopup_Load(object sender, EventArgs e)
        {
            if (_statusForm == E_StatusForm.ADD)
            {
                moTxb.Focus();
            }
            else
            {
                typeTxb.Focus();
            }
        }

        /// <summary>
        /// Nếu là trạng thái edit thì fill data vào input
        /// </summary>
        protected override void InitUI()
        {
            if (_statusForm == E_StatusForm.ADD) return;

            InitInput();
            InitGridView();
        }

        /// <summary>
        /// Fill giá trị cho input khi ở chế độ edit
        /// </summary>
        private void InitInput()
        {
            if (_statusForm == E_StatusForm.ADD) return;

            moTxb.Text = _receiveData.MO;
            moTxb.ReadOnly = true;

            typeTxb.Text = _receiveData.TypeDetail;
            supplierTxb.Text = _receiveData.Supplier;
            quantityTxb.Text = _receiveData.QuantityToReceive.ToString();
            estimateQuantityTxb.Text = _receiveData.QuantityEstimate.ToString();
        }

        /// <summary>
        /// Fill bảng dataGridView
        /// </summary>
        private async void InitGridView()
        {
            if (_statusForm == E_StatusForm.ADD) return;
            if (_receiveData == null) return;

            Response<List<PldgDetailDto>> res = await _pldgService.GetReceiveDetailAsync(_receiveData.Id);

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
            // Bước1: Validate
            var requiredFields = new Dictionary<string, TextBox>
            {
                { "MO", moTxb },
                { "Loaị phụ liệu", typeTxb },
                { "Nhà cung cấp", supplierTxb }
            };
            bool validateInput = ValidateInput(requiredFields, quantityTxb, estimateQuantityTxb);
            if (!validateInput) return;

            List<string> numCols = new List<string>() { "QuantityPerCarton", "NetWeight", "GrossWeight", "PldgWeight", "QuantityToReceived" };
            bool validateDetail = ValidateNPLDetail(numCols);
            if (!validateDetail) return;

            // Bước2: Khai báo dữ liệu, gọi service create
            PldgDto pldg = new PldgDto()
            {
                MO = moTxb.Text,
                Type = typeTxb.Text,
                Supplier = supplierTxb.Text,
                QuantityToReceive = int.Parse(quantityTxb.Text),
                QuantityEstimate = int.Parse(estimateQuantityTxb.Text),
            };

            Response<int> res;

            if (_statusForm == E_StatusForm.ADD)
            {
                res = await _pldgService.CreateReceiveAsync(pldg, _dataTable);
            }
            else
            {
                res = await _pldgService.UpdateReceiveAsync(_receiveData.Id, pldg, _dataTable);
            }

            // Bước3: Xử lí message trả về
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
