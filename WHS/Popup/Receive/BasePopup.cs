using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Dto.Receive;
using WHS.Core.Enums;
using WHS.Core.Response;
using WHS.Service.Interface;
using WHS.Service.Services;

namespace WHS.Popup
{
    // Base form KHÔNG dùng Designer
    public class BasePopup : Form
    {
        protected E_StatusForm _statusForm = E_StatusForm.ADD;
        protected ReceiveDto _receiveData = new ReceiveDto();

        protected IReceiveService _receiveService = default!;
        protected Dictionary<string, string> _columns = new Dictionary<string, string>();
        protected DataTable _dataTable = new DataTable();

        protected DataGridView _gridView = default!;
        protected Button _sampleBtn = default!;
        protected Button _addBtn = default!;
        protected Button _cancelBtn = default!;

        public event EventHandler? SaveSuccess;

        #region Setup
        public BasePopup()
        {

        }
        public BasePopup(IReceiveService receiveService)
        {
            _receiveService = receiveService;
        }

        public void Initialize(E_StatusForm statusForm, ReceiveDto receiveDto)
        {
            _statusForm = statusForm;
            _receiveData = receiveDto;
            InitUI();
        }

        /// <summary>
        /// Hàm InitUI, xử lí ở các popup con
        /// </summary>
        protected virtual void InitUI()
        {
        }

        /// <summary>
        /// Sự kiện raise lên khi lưu thành công
        /// </summary>
        protected void RaiseSaveSuccess()
        {
            SaveSuccess?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Setup gridView 
        /// </summary>
        protected void SetupGridView()
        {
            if (_gridView == null) return;

            _gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _gridView.ScrollBars = ScrollBars.Both;
            _gridView.AutoGenerateColumns = false;

            foreach (DataGridViewColumn col in _gridView.Columns)
            {
                col.MinimumWidth = 150;
                col.FillWeight = 1;
            }
        }
        #endregion

        #region Excel
        /// <summary>
        /// Sự kiện xuất file excel mẫu
        /// </summary>
        /// <returns></returns>
        protected async Task ExportSampleExcelAsync(string name = "sample")
        {
            // Lấy ra byte[] file excel từ columns khởi tạo lúc đầu 
            List<string> headers = _columns.Values.ToList();
            Response<byte[]> res = await _receiveService.ExportExcelAsync(headers);

            // Chọn nơi lưu file và lưu file
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                string timestamp = DateTime.Now.ToString("ddMMyyyyHHmmss");
                saveFileDialog.FileName = $"{name}_{timestamp}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, res.Data!);
                    DialogResult result = MessageBox.Show("Xuất file thành công! Bạn có muốn mở file không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true });
                    }
                }
            }
        }

        /// <summary>
        /// Sự kiện nhập file excel vào gridView
        /// </summary>
        /// <returns></returns>
        protected async Task LoadExcelToGridViewAsync()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files|*.xlsx;*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    Response<DataTable> response = await _receiveService.ReadExcelAsync(filePath, _columns);

                    if (response.Data != null) {
                        _dataTable = response.Data;
                        _gridView.DataSource = _dataTable;                    
                    }
                }
            }
        }
        #endregion

        #region RegistEvent
        /// <summary>
        /// Sự kiện đăng kí click tải file mẫu
        /// </summary>
        protected void RegisterSampleButtonEvent(string name = "sample")
        {
            if (_sampleBtn != null)
            {
                _sampleBtn.Click += async (sender, e) =>
                {
                    await ExportSampleExcelAsync(name);
                };
            }
        }
        
        /// <summary>
        /// Sự kiện xóa các dòng được chọn
        /// </summary>
        protected void DeleteSelectedRows()
        {
            if (_gridView == null || _gridView.SelectedRows.Count == 0)
                return;

            foreach (DataGridViewRow row in _gridView.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    _gridView.Rows.Remove(row);
                }
            }
        }

        /// <summary>
        /// Sự kiện đăng kí click nhập excel vào table
        /// </summary>
        protected void RegisterAddButtonEvent()
        {
            if (_addBtn != null)
            {
                _addBtn.Click += async (sender, e) =>
                {
                    await LoadExcelToGridViewAsync();
                };
            }
        }

        /// <summary>
        /// Sự kiện đăng kí click cancel form
        /// </summary>
        protected void RegisterCancelButtonEvent()
        {
            if (_cancelBtn != null)
            {
                _cancelBtn.Click += (sender, e) =>
                {
                    this.Close();
                };
            }
        }

        /// <summary>
        /// Sự kiện đăng kí delete row form
        /// </summary>
        protected void RegisterDeleteDetailEvent()
        {
            if (_gridView != null)
            {
                _gridView.KeyDown += (sender, e) =>
                {
                    if (e.KeyCode == Keys.Delete)
                    {
                        DeleteSelectedRows();
                        e.Handled = true;
                    }
                };
            }
        }
        #endregion

        #region Validate
        /// <summary>
        /// Validate những input truyền vào 
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="quantityTxb"></param>
        /// <param name="estimateQuantityTxb"></param>
        /// <returns></returns>
        protected bool ValidateInput(Dictionary<string, TextBox> dict, TextBox quantityTxb, TextBox estimateQuantityTxb)
        {
            List<string> missingFields = new List<string>();

            foreach (var field in dict)
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
        protected bool ValidateNPLDetail(List<string> numCols)
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
                foreach (string col in numCols)
                {
                    string str = row[col]?.ToString()?.Trim() ?? "";
                    if (!double.TryParse(str, out _))
                    {
                        errorMessages.Add($"- Dòng {rowIndex}: Cột '{_columns[col]}' không phải là số.");
                    }
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
    }
}
