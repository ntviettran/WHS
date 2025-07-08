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
using WHS.Service.Interface;
using WHS.Service.Services;

namespace WHS.Popup
{
    public partial class FabricPopup : BasePopup
    {
        private readonly IReceiveService<FabricDto, FabricDetailDto> _fabricService;

        public FabricPopup(IReceiveService<FabricDto, FabricDetailDto> receiveService) : base(receiveService)
        {
            InitializeComponent();

            _fabricService = receiveService;

            _columns = new Dictionary<string, string>()
            {
                {"FabricNumber", "Cuộn số"},
                {"Style", "Style"},
                {"Color", "Màu"},
                {"FabricType", "Loại vải"},
                {"Batch", "Lót"},
                {"FabricLength", "Chiều dài"},
                {"LengthUnit", "Đơn vị chiều dài"},
                {"FabricWeight", "Khối lượng"},
                {"WeightUnit", "Đơn vị khối lượng"},
                {"RollWidth", "Khổ"},
                {"WidthUnit", "Đơn vị khổ"},
                {"QuantityToReceived", "Số lượng cần nhận"},
            };
            _gridView = this.gridView;
            _sampleBtn = this.sampleFileBtn;
            _addBtn = this.addBtn;
            _cancelBtn = this.cancelBtn;

            SetupGridView();
            RegisterSampleButtonEvent(name: "vai");
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
        private void FabricPopup_Load(object sender, EventArgs e)
        {
            if (_statusForm == E_StatusForm.ADD) { 
                moTxb.Focus();
            } else
            {
                styleTxb.Focus();
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

            styleTxb.Text = _receiveData.Style;
            colorTxb.Text = _receiveData.Color;
            fabricTypeTxb.Text = _receiveData.TypeDetail;
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

            Response<List<FabricDetailDto>> res = await _fabricService.GetReceiveDetailAsync(_receiveData.Id);

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
                { "Style", styleTxb },
                { "Màu", colorTxb },
                { "Loại vải", fabricTypeTxb },
                { "Nhà cung cấp", supplierTxb }
            };
            bool validateInput = ValidateInput(requiredFields, quantityTxb, estimateQuantityTxb);
            if (!validateInput) return;

            List<string> numCols = new List<string>() { "FabricWeight", "RollWidth", "QuantityToReceived"};
            bool validateDetail = ValidateNPLDetail(numCols);
            if (!validateDetail) return;

            // Bước2: Khai báo dữ liệu, gọi service create
            FabricDto fabric = new FabricDto()
            {
                MO = moTxb.Text,
                Style = styleTxb.Text,
                Color = colorTxb.Text,
                FabricType = fabricTypeTxb.Text,
                Supplier = supplierTxb.Text,
                QuantityToReceive = int.Parse(quantityTxb.Text),
                QuantityEstimate = int.Parse(estimateQuantityTxb.Text),
            };

            Response<int> res;

            if (_statusForm == E_StatusForm.ADD)
            {
                 res = await _fabricService.CreateReceiveAsync(fabric, _dataTable);
            } else
            {
                res = await _fabricService.UpdateReceiveAsync(_receiveData.Id, fabric, _dataTable);
            }

            // Bước3: Xử lí message trả về
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
