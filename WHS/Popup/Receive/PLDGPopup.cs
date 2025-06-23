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

        public PLDGPopup(IReceiveService<PldgDto, PldgDetailDto> receiveService)
        {

            InitializeComponent();

            _pldgService = receiveService;
            _columns = new Dictionary<string, string>()
            {
                {"plspType", "Loại phụ liệu"},
                {"packCode", "Mã pack"},
                {"poCode", "Mã PO"},
                {"quantityPerCarton", "Số chiếc mỗi thùng"},
                {"netWeight", "N.W"},
                {"grossWeight", "G.W"},
                {"color", "Màu"},
                {"pldgWeight", "Khối lượng"},
                {"weightUnit", "Đơn vị khối lương"},
                {"pldgSize","Kích thước"},
                {"sizeUnit", "Đơn vị kích thước"}
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
        private void FabricPopup_Load(object sender, EventArgs e)
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
            moTxb.BackColor = Color.LightGray;
            moTxbContainer.BackColor = Color.LightGray;

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

        #region validate
        /// <summary>
        /// Validate input điền vào 
        /// </summary>
        /// <returns></returns>
        private bool ValidateInput()
        {
            var requiredFields = new Dictionary<string, TextBox>
            {
                { "MO", moTxb },
                { "Loaị phụ liệu", typeTxb },
                { "Nhà cung cấp", supplierTxb }
            };

            List<string> missingFields = new List<string>();

            foreach (var field in requiredFields)
            {
                if (string.IsNullOrWhiteSpace(field.Value.Text))
                {
                    missingFields.Add($"- {field.Key}");
                }
            }

            List<string> numberErrors = new List<string>();

            bool validQty = int.TryParse(quantityTxb.Text.Trim(), out int qty);
            bool validEst = int.TryParse(estimateQuantityTxb.Text.Trim(), out int estQty);

            if (!validQty)
            {
                numberErrors.Add("- Số lượng phải là số nguyên hợp lệ");
            }

            if (!validEst)
            {
                numberErrors.Add("- Số lượng dự kiến phải là số nguyên hợp lệ");
            }

            if (validQty && validEst && estQty > qty)
            {
                numberErrors.Add("- Số lượng dự kiến không được lớn hơn Số lượng");
            }

            // Gộp thông báo lỗi
            if (missingFields.Count > 0 || numberErrors.Count > 0)
            {
                string message = "Vui lòng kiểm tra các lỗi sau:\n";

                if (missingFields.Count > 0)
                {
                    message += "\nThiếu thông tin:\n" + string.Join("\n", missingFields);
                }

                if (numberErrors.Count > 0)
                {
                    message += "\n\nLỗi định dạng:\n" + string.Join("\n", numberErrors);
                }

                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validate dữ liệu chi tiết của NPL
        /// </summary>
        /// <returns></returns>
        private bool ValiateNPLDetail()
        {
            if (_dataTable == null || _dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Cần thêm dữ liệu chi tiết của NPL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            List<string> errorMessages = new List<string>();
            int rowIndex = 1;

            foreach (DataRow row in _dataTable.Rows)
            {
                // Check fabric_weight
                string weightStr = row["fabricWeight"]?.ToString()?.Trim() ?? "";
                if (!double.TryParse(weightStr, out _))
                {
                    errorMessages.Add($"- Dòng {rowIndex}: Cột '{_columns["fabricWeight"]}' không phải là số.");
                }

                // Check roll_width
                string widthStr = row["rollWidth"]?.ToString()?.Trim() ?? "";
                if (!double.TryParse(widthStr, out _))
                {
                    errorMessages.Add($"- Dòng {rowIndex}: Cột '{_columns["rollWidth"]}' không phải là số.");
                }

                rowIndex++;
            }

            if (errorMessages.Count > 0)
            {
                string message = "Dữ liệu không hợp lệ:\n" + string.Join("\n", errorMessages);
                MessageBox.Show(message, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
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
            bool validateInput = ValidateInput();
            if (!validateInput) return;

            bool validateDetail = ValiateNPLDetail();
            if (!validateDetail) return;

            // Bước2: Khai báo dữ liệu, gọi service create




            this.Close();
        }
        #endregion
    }
}
