using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.PLDG;
using WHS.Core.Dto.PLSP;
using WHS.Core.Dto.Transfer;
using WHS.Core.Dto.Vehicle;
using WHS.Core.Enums;
using WHS.Core.Factory;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Factory;
using WHS.Service.Interface;
using WHS.Utils;

namespace WHS.Popup.Transfer
{
    public partial class TransferDetail : Form
    {
        private ITransferService _transferService;
        private IVehicleService _vehicleService;
        private E_NPLType _type = E_NPLType.FABRIC;
        private VehicleDto _vehicle = new VehicleDto();
        private Dictionary<string, string> _columns = new Dictionary<string, string>();
        private E_StatusPage _statusPage = E_StatusPage.VIEW;
        private List<string> _editColumns = new List<string>();

        private List<FabricTransferDetailDto> _fabricDetail = new List<FabricTransferDetailDto>();
        private List<PLSPTransferDetailDto> _plspDetail = new List<PLSPTransferDetailDto>();
        private List<PLDGTransferDetailDto> _pldgDetail = new List<PLDGTransferDetailDto>();

        public TransferDto Transfer { get; set; } = new TransferDto();

        public TransferDetail(IVehicleService vehicleService)
        {
            _transferService = TransferFactory.GetService(_type);
            _vehicleService = vehicleService;

            InitializeComponent();
        }

        #region Setup
        /// <summary>
        /// Hàm khởi tạo giá trị ban đầu cho form
        /// </summary>
        /// 

        private void TransferDetail_Load(object sender, EventArgs e)
        {
            GridViewUtils.SetBuffer(gridView);
        }

        public async void InitUI()
        {
            estimateWarehouseLabel.Text = Transfer.PlanWarehouseDateVN;
            warehouseLabel.Text = Transfer.WarehouseDateVN;
            estimateExecLabel.Text = Transfer.PlanExecDateVN;
            execLabel.Text = Transfer.ExecDateVN;
            execStatusLabel.Text = Transfer.ExecStatusDescription;
            transferStatusLabel.Text = Transfer.TransferStatusDescription;
            vehicleIdLabel.Text = Transfer.VehicleId.ToString();

            UpdateVehicleInformation();
            await GetDataTransfer();
            GetFabicDetail();
        }

        /// <summary>
        /// Init khi detail này mở bằng PPC
        /// </summary>
        public void InitPPC()
        {
            mid1.Visible = false;
            mid2.Visible = false;
            mid3.Visible = false;
            mid4.Visible = false;
            confirmBtn.Visible = false;
            uploadExcelBtn.Visible = false;
            downExcelBtn.Visible = false;
            failBtn.Visible = false;
            panelBottom.Visible = false;

            if (Transfer.ExecDate.HasValue)
            {
                editBtn.Visible = false;
            }

            _statusPage = E_StatusPage.VIEW;
        }

        /// <summary>
        /// Init khi detail này mở bằng kho
        /// </summary>
        public void InitWarehouseManager()
        {
            mid1.Visible = false;
            editBtn.Visible = false;
            downExcelBtn.Visible = false;
            uploadExcelBtn.Visible = false;
            failBtn.Visible = false;
            panelBottom.Visible = false;

            _statusPage = E_StatusPage.EDIT;
            if (Transfer.ExecDate.HasValue)
            {
                confirmBtn.Text = "Xác nhận về kho";
                panelBottom.Visible = false;
            }

            if (Transfer.WarehouseDate.HasValue)
            {
                confirmBtn.Visible = false;
                failBtn.Visible = false;
                mid2.Visible = false;
                mid3.Visible = false;
                downExcelBtn.Visible = true;
                uploadExcelBtn.Visible = true;
                panelBottom.Visible = true;
            }
        }

        /// <summary>
        /// Update phương tiện vận chuyển
        /// </summary>
        public async void UpdateVehicleInformation()
        {
            Response<VehicleDto> res = await _vehicleService.GetVehicleByID(Transfer.VehicleId);
            if (res.IsSuccess && res.Data != null)
            {
                _vehicle = res.Data;
                vehicleTypeLabel.Text = EnumHelper.GetEnumDescription(res.Data.VehicleType);
                vehicleModeLabel.Text = EnumHelper.GetEnumDescription(res.Data.VehicleMode);
                licensePlateLabel.Text = res.Data.LicensePlate;
            }
        }

        /// <summary>
        /// Vẽ lại các cột của gridView
        /// </summary>
        private void SetColumnGridView()
        {
            gridView.DataSource = null;
            gridView.AutoGenerateColumns = false;
            gridView.Columns.Clear();

            // Kích hoạt autofill
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            foreach (var column in _columns)
            {
                gridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = column.Key,
                    HeaderText = column.Value,
                    DataPropertyName = column.Key,
                    MinimumWidth = 150,
                    ReadOnly = _statusPage == E_StatusPage.VIEW || !(_statusPage == E_StatusPage.EDIT && Transfer.WarehouseDate.HasValue && _editColumns.Contains(column.Key))
                });
            }
        }
        #endregion

        #region GridView
        /// <summary>
        /// Khởi tạo giá trị cho bảng cần điều phối
        /// </summary>
        private async Task GetDataTransfer()
        {
            foreach (E_NPLType type in Enum.GetValues(typeof(E_NPLType)))
            {
                var service = TransferFactory.GetService(type);

                var transferId = Transfer.ID;

                switch (type)
                {
                    case E_NPLType.FABRIC:
                        var fabricService = service as ITransferService<FabricCoordinationDto, FabricTransferDetailDto>;
                        if (fabricService == null) continue;

                        var fabricRes = await fabricService.GetTransferDetail(transferId);
                        if (!fabricRes.IsSuccess || fabricRes.Data == null) continue;

                        _fabricDetail = fabricRes.Data;
                        break;

                    case E_NPLType.PLSP:
                        var plspService = service as ITransferService<PLSPCoordinationDto, PLSPTransferDetailDto>;
                        if (plspService == null) continue;

                        var plspRes = await plspService.GetTransferDetail(transferId);
                        if (!plspRes.IsSuccess || plspRes.Data == null) continue;

                        _plspDetail = plspRes.Data;
                        break;

                    case E_NPLType.PLDG:
                        var pldgService = service as ITransferService<PLDGCoordinationDto, PLDGTransferDetailDto>;
                        if (pldgService == null) continue;

                        var pldgRes = await pldgService.GetTransferDetail(transferId);
                        if (!pldgRes.IsSuccess || pldgRes.Data == null) continue;

                        _pldgDetail = pldgRes.Data;
                        break;
                }
            }

        }

        /// <summary>
        /// Refresh lại gridView
        /// </summary>
        private void RefreshCurrentDataGrid()
        {
            SetColumnGridView();
            switch (_type)
            {
                case E_NPLType.FABRIC:
                    gridView.DataSource = new BindingList<FabricTransferDetailDto>(_fabricDetail);
                    break;

                case E_NPLType.PLSP:
                    gridView.DataSource = new BindingList<PLSPTransferDetailDto>(_plspDetail);
                    break;

                case E_NPLType.PLDG:
                    gridView.DataSource = new BindingList<PLDGTransferDetailDto>(_pldgDetail);
                    break;

                default:
                    gridView.DataSource = null;
                    break;
            }
        }

        /// <summary>
        /// Hiện ui active loại NPL được chọn (Vải, PLSP, PLĐG)
        /// </summary>
        /// <param name="btn"></param>
        private void ActiveTypeBtn(Button button)
        {
            // Unactive tất cả các button trong vùng typeContainer
            foreach (Control ctrl in typeContainer.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.DarkGray;
                }
            }

            // Active button truyền vào
            button.BackColor = Color.FromArgb(0, 46, 92);

            _transferService = TransferFactory.GetService(_type);
            _columns = GetColumnsByType(_type);
        }

        /// <summary>
        /// Get các cột cần hiển thị theo loại NPL
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private Dictionary<string, string> GetColumnsByType(E_NPLType type)
        {
            return type switch
            {

                E_NPLType.FABRIC => new Dictionary<string, string>
            {
                {"ID", "ID"},
                {"MO", "MO"},
                {"Style", "Style"},
                {"Color", "Màu"},
                {"FabricType", "Loại vải"},
                {"Batch", "Lot"},
                {"FabricNumber", "Cuộn số"},
                {"EstimateQuantity", "Số lượng dự kiến nhận"},
                {"ReceivedQuantity", "Số lượng thực nhận"},
                {"QuantityStatusDescription", "Trạng thái số lượng"},
                {"FabricLength", "Chiều dài cần"},
                {"LengthReceived", "Chiều dài thực nhận"},
                {"LengthStatusDescription", "Trạng thái chiều dài"},
                {"FabricWeight", "Khối lượng cần"},
                {"WeightReceived", "Khối lượng thực nhận"},
                {"WeightStatusDescription", "Trạng thái khối lượng"}
            },

                E_NPLType.PLSP => new Dictionary<string, string>
            {
                {"ID", "ID"},
                {"MO", "MO"},
                {"PlspType", "Loại phụ liệu"},
                {"MarketCode", "Mã thị trường"},
                {"PlspCode", "Mã code"},
                {"NplColor", "Màu"},
                {"Size", "Kích cỡ"},
                {"PlspColor", "Màu sắc sản phẩm"},
                {"EstimateQuantity", "Số lượng dự kiến nhận"},
                {"ReceivedQuantity", "Số lượng thực nhận"},
                {"QuantityStatusDescription", "Trạng thái số lượng"}
            },

                E_NPLType.PLDG => new Dictionary<string, string>
            {
                {"ID", "ID"},
                {"MO", "MO"},
                {"PldgType", "Loại phụ liệu"},
                {"PackCode", "Mã thùng"},
                {"PoCode", "Mã PO"},
                {"NetWeight", "N.W"},
                {"GrossWeight", "G.W"},
                {"Color", "Màu"},
                {"PldgSize", "Kích thước"},
                {"EstimateQuantity", "Số lượng dự kiến nhận"},
                {"ReceivedQuantity", "Số lượng thực nhận"},
                {"QuantityStatusDescription", "Trạng thái số lượng"}
            },

                _ => throw new ArgumentException("Invalid type", nameof(type))
            };
        }

        /// <summary>
        /// Get fabric detail
        /// </summary>
        public void GetFabicDetail()
        {
            _type = E_NPLType.FABRIC;
            ActiveTypeBtn(fabricBtn);

            _editColumns = new List<string>
            {
                "QuantityReceived",
                "LengthReceived",
                "WeightReceived"
            };

            RefreshCurrentDataGrid();
        }

        /// <summary>
        /// Get Plsp detail
        /// </summary>
        private void GetPlspDetail()
        {
            _type = E_NPLType.PLSP;
            ActiveTypeBtn(plspBtn);

            _editColumns = new List<string>
            {
                "QuantityReceived"
            };

            RefreshCurrentDataGrid();
        }

        /// <summary>
        /// Get Pldg detail
        /// </summary>
        private void GetPldgDetail()
        {
            _type = E_NPLType.PLDG;
            ActiveTypeBtn(pldgBtn);


            _editColumns = new List<string>
            {
                "QuantityReceived"
            };

            RefreshCurrentDataGrid();
        }

        /// <summary>
        /// Sự kiện click button vải
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fabricBtn_Click(object sender, EventArgs e)
        {
            GetFabicDetail();
        }

        /// <summary>
        /// Sự kiện click button plsp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plspBtn_Click(object sender, EventArgs e)
        {
            GetPlspDetail();
        }

        /// <summary>
        /// Sự kiện click button pldg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pldgBtn_Click(object sender, EventArgs e)
        {
            GetPldgDetail();
        }

        /// <summary>
        /// Sự kiện edit transfer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editBtn_Click(object sender, EventArgs e)
        {
            AddTransferPopup transferPopup = FormFactory.CreateForm<AddTransferPopup>();

            transferPopup.Transfer = Transfer;
            transferPopup.Vehicle = _vehicle;
            transferPopup.InitEditMode();

            transferPopup.SaveSucces += (transfer, e) =>
            {
                Transfer = transfer;
                InitUI();
            };

            transferPopup.Show();
        }
        #endregion

        #region Warehouse

        /// <summary>
        /// Sự kiện khi bấm vào xác nhận thực hiện hoặc xác nhận về kho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void confirmBtn_Click(object sender, EventArgs e)
        {
            if (Transfer.ExecDate.HasValue)
            {
                Response<int> res = await _transferService.UpdateWarhouseDate(Transfer.ID);

                if (!res.IsSuccess)
                {
                    ShowMessage.Error(res.Message);
                    return;
                }

                confirmBtn.Visible = false;
                failBtn.Visible = false;
                mid2.Visible = false;
                mid3.Visible = false;
                downExcelBtn.Visible = true;
                uploadExcelBtn.Visible = true;
                panelBottom.Visible = true;
                transferStatusLabel.Text = EnumHelper.GetEnumDescription(E_TransferStatus.SUCCESS);
                warehouseLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
                Transfer.WarehouseDate = DateTime.Now;

                RefreshCurrentDataGrid();
            }
            else
            {
                Response<int> res = await _transferService.UpdateExecDate(Transfer.ID);

                if (!res.IsSuccess)
                {
                    ShowMessage.Error(res.Message);
                    return;
                }


                failBtn.Visible = true;
                panelBottom.Visible = false;
                Transfer.ExecDate = DateTime.Now;
                execStatusLabel.Text = EnumHelper.GetEnumDescription(E_TransferExec.DOING);
                confirmBtn.Text = "Xác nhận về kho";
                execLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        /// <summary>
        /// Sự kiện về kho thất bại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void failBtn_Click(object sender, EventArgs e)
        {
            Response<int> res = await _transferService.UpdateTransferStatus(Transfer.ID, E_TransferStatus.FAIL);

            if (!res.IsSuccess)
            {
                ShowMessage.Error(res.Message);
                return;
            }

            failBtn.Visible = false;
            transferStatusLabel.Text = EnumHelper.GetEnumDescription(E_TransferStatus.FAIL);
        }

        /// <summary>
        /// Sự kiện bấm nút down excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downExcelBtn_Click(object sender, EventArgs e)
        {
            ExportAllTransfersToExcel();
        }

        /// <summary>
        /// Xử lí xuất file excel
        /// </summary>
        private void ExportAllTransfersToExcel()
        {
            ExcelPackage.License.SetNonCommercialPersonal("whs");

            using var package = new ExcelPackage();

            foreach (E_NPLType type in Enum.GetValues(typeof(E_NPLType)))
            {
                switch (type)
                {
                    case E_NPLType.FABRIC:
                        AddSheet<FabricTransferDetailDto>(package, E_NPLType.FABRIC, "Fabric", _fabricDetail);
                        break;

                    case E_NPLType.PLSP:

                        AddSheet<PLSPTransferDetailDto>(package, E_NPLType.PLSP, "Plsp", _plspDetail);
                        break;

                    case E_NPLType.PLDG:
                        AddSheet<PLDGTransferDetailDto>(package, E_NPLType.PLDG, "Pldg", _pldgDetail);
                        break;
                }
            }

            // Chọn nơi lưu file và lưu file
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                string timestamp = DateTime.Now.ToString("ddMMyyyyHHmmss");
                saveFileDialog.FileName = $"dieuchuyen_{timestamp}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, package.GetAsByteArray());
                    DialogResult result = MessageBox.Show("Xuất file thành công! Bạn có muốn mở file không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true });
                    }
                }
            }
        }

        /// <summary>
        /// Thêm dữ liệu vào sheet của file excel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="package"></param>
        /// <param name="type"></param>
        /// <param name="sheetName"></param>
        /// <param name="data"></param>
        private void AddSheet<T>(ExcelPackage package, E_NPLType type, string sheetName, List<T> data)
        {
            var worksheet = package.Workbook.Worksheets.Add(sheetName);

            var props = GetColumnsByType(type).ToList();

            // --- Header
            for (int i = 0; i < props.Count; i++)
            {
                var cell = worksheet.Cells[1, i + 1];
                cell.Value = props[i].Value;
                cell.Style.Font.Bold = true;
                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                cell.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            // --- Data
            for (int row = 0; row < data.Count; row++)
            {
                for (int col = 0; col < props.Count; col++)
                {
                    string propName = props[col].Key;
                    var propInfo = typeof(T).GetProperty(propName);

                    object? value = propInfo?.GetValue(data[row]);
                    var cell = worksheet.Cells[row + 2, col + 1];

                    if (value is DateTime dt)
                    {
                        cell.Value = dt;
                        cell.Style.Numberformat.Format = "dd/MM/yyyy";
                    }
                    else
                    {
                        cell.Value = value ?? "";
                    }

                    cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
        }

        /// <summary>
        /// Đọc dữ liệu từ file excel và cập nhật vào các danh sách chi tiết
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uploadExcelBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files|*.xlsx;*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string filePath = ofd.FileName;
                    UpdateFromExcel(filePath);
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// Đọc dữ liệu từ file excel
        /// </summary>
        /// <param name="filePath"></param>
        public void UpdateFromExcel(string filePath)
        {
            ExcelPackage.License.SetNonCommercialPersonal("whs");
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var sheetNames = new[] { "Fabric", "Plsp", "Pldg" };

                // Đọc dữ liệu theo 3 sheet tương ứng với 3 type
                foreach (var sheetName in sheetNames)
                {
                    var worksheet = package.Workbook.Worksheets[sheetName];
                    if (worksheet == null) continue;

                    int rowCount = worksheet.Dimension.End.Row;
                    int colCount = worksheet.Dimension.End.Column;

                    // Lấy ra vị trí cột để lấy dữ liệu
                    var headerIndex = new Dictionary<string, int>();
                    for (int col = 1; col <= colCount; col++)
                    {
                        var header = worksheet.Cells[1, col].Text.Trim();
                        if (!string.IsNullOrEmpty(header))
                        {
                            headerIndex[header] = col;
                        }
                    }

                    // Update số lượng thức tế nhận vào danh sách tương ứng
                    for (int row = 2; row <= rowCount; row++)
                    {
                        try
                        {
                            switch (sheetName.ToLower())
                            {
                                case "fabric":
                                    {
                                        var columnMap = GetColumnsByType(E_NPLType.FABRIC);

                                        if (!headerIndex.TryGetValue(columnMap["ID"], out int idCol) || idCol <= 0) break;
                                        if (!headerIndex.TryGetValue(columnMap["ReceivedQuantity"], out int quantityCol)) quantityCol = -1;
                                        if (!headerIndex.TryGetValue(columnMap["LengthReceived"], out int lengthCol)) lengthCol = -1;
                                        if (!headerIndex.TryGetValue(columnMap["WeightReceived"], out int weightCol)) weightCol = -1;

                                        if (!int.TryParse(worksheet.Cells[row, idCol]?.Text, out int id)) break;

                                        int quantity = 0;
                                        float length = 0, weight = 0;

                                        if (quantityCol > 0)
                                            int.TryParse(worksheet.Cells[row, quantityCol]?.Text, out quantity);
                                        if (lengthCol > 0)
                                            float.TryParse(worksheet.Cells[row, lengthCol]?.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out length);
                                        if (weightCol > 0)
                                            float.TryParse(worksheet.Cells[row, weightCol]?.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out weight);

                                        var fabricItem = _fabricDetail.FirstOrDefault(x => x.ID == id);
                                        if (fabricItem != null)
                                        {
                                            fabricItem.ReceivedQuantity = quantity;
                                            fabricItem.LengthReceived = length;
                                            fabricItem.WeightReceived = weight;
                                        }
                                        break;
                                    }

                                case "plsp":
                                case "pldg":
                                    {
                                        var columnMap = GetColumnsByType(E_NPLType.FABRIC);

                                        if (!headerIndex.TryGetValue(columnMap["ID"], out int idCol) || idCol <= 0) break;
                                        if (!headerIndex.TryGetValue(columnMap["ReceivedQuantity"], out int quantityCol)) quantityCol = -1;

                                        if (!int.TryParse(worksheet.Cells[row, idCol]?.Text, out int id)) break;

                                        int quantity = 0;
                                        if (quantityCol > 0)
                                            int.TryParse(worksheet.Cells[row, quantityCol]?.Text, out quantity);

                                        if (sheetName.ToLower() == "plsp")
                                        {
                                            var item = _plspDetail.FirstOrDefault(x => x.ID == id);
                                            if (item != null)
                                                item.ReceivedQuantity = quantity;
                                        }
                                        else
                                        {
                                            var item = _pldgDetail.FirstOrDefault(x => x.ID == id);
                                            if (item != null)
                                                item.ReceivedQuantity = quantity;
                                        }

                                        break;
                                    }
                            }
                        }
                        catch (Exception ex)
                        {
                            ShowMessage.Error(ex.Message);
                        }
                    }
                }
            }
            RefreshCurrentDataGrid();
        }

        #endregion

        /// <summary>
        /// Sự kiện lưu dữ liệu update số lượng thực tế từ kho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void saveBtn_Click(object sender, EventArgs e)
        {
            Response<int> res = await _transferService.UpdateQuantityTransfer(_fabricDetail, _plspDetail, _pldgDetail);

            if (!res.IsSuccess)
            {
                ShowMessage.Error(res.Message);
                return;
            }

            this.Close();
        }

        private void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
