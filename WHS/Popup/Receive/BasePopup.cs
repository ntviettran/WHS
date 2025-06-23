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

        protected virtual void InitUI()
        {
        }

        /// <summary>
        /// Setup gridView 
        /// </summary>
        protected void SetupGridView()
        {
            if (_gridView == null) return;

            _gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _gridView.ScrollBars = ScrollBars.Both;

            foreach (DataGridViewColumn col in _gridView.Columns)
            {
                col.MinimumWidth = 150;
                col.FillWeight = 1;
            }
        }

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
    }
}
