using PLSP.Core.Dto.Location;
using PLSP.Core.Dto.PLSP;
using PLSP.Core.Enums;
using PLSP.Service.Interface;
using PLSP.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Enums;
using WHS.Core.Response;
using WHS.Core.Session;
using WHS.Core.Utils;
using WHS.Factory;

namespace PLSP.Popup.Inventory
{
    public partial class MoveToLocationPopup : Form
    {
        private PlspInventoryDto _plsp;
        private E_WHType _whType;
        private int _initQuantityLocation = 0;
        private int _quantityLocation = 0;
        BindingList<LocationDto> _locations = new BindingList<LocationDto>();

        public MoveToLocationPopup(PlspInventoryDto plsp, E_WHType type)
        {
            _plsp = plsp;
            _whType = type;
            InitializeComponent();
        }

        private void MoveToLocationPopup_Load(object sender, EventArgs e)
        {
            InitUI();
        }

        private async void InitUI()
        {

            IInventoryService<PlspInventoryDto, PlspInventoryLocationDto> locationService = ServiceFactory.GetInventoryService<PlspInventoryDto, PlspInventoryLocationDto>();

            Response<int> response = await locationService.GetTotalQuantityLocation(_plsp.ID);

            if (!response.IsSuccess)
            {
                ShowMessage.Error(response.Message);
                return;
            }

            IdLabel.Text = _plsp.ID.ToString();
            moLabel.Text = _plsp.MO;
            inventoryQuantityLabel.Text = _plsp.InventoryQuantity.ToString();
            moveQuantityLabel.Text = response.Data.ToString();

            _initQuantityLocation = response.Data;

            SetupLocationGridView();
        }

        private Dictionary<string, string> GetColumn()
        {
            if (_whType == E_WHType.BLOCK)
            {
                return new Dictionary<string, string>
                {
                    ["Location"] = "Vị trí",
                    ["Quantity"] = "Số lượng",
                    ["QuantityPerBag"] = "Số lượng mỗi túi",
                };
            }

            return new Dictionary<string, string>
            {
                ["Location"] = "Vị trí",
                ["Quantity"] = "Số lượng"
            };
        }

        /// <summary>
        /// Vẽ lại các cột của gridView
        /// </summary>
        private void SetupLocationGridView()
        {
            locationGridView.AutoGenerateColumns = false;
            locationGridView.DataSource = null;
            locationGridView.DataSource = _locations;

            Dictionary<string, string> columns = GetColumn();

            locationGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (var column in columns)
            {
                locationGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = column.Key,
                    HeaderText = column.Value,
                    DataPropertyName = column.Key
                });
            }
        }

        /// <summary>
        /// Tính toán tổng số lượng của các vị trí
        /// </summary>
        private void CalculateTotalQuantity()
        {
            int totalQuantity = _locations.Sum(location => location.Quantity);
            _quantityLocation = _initQuantityLocation + totalQuantity;
            moveQuantityLabel.Text = _quantityLocation.ToString();
        }

        /// <summary>
        /// Bắt sự kiện khi có thay đổi giá trị trong ô của gridView để xử lý tính toán tổng số lượng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void locationGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == locationGridView.Columns["Quantity"].Index)
            {
                CalculateTotalQuantity();
            }
        }

        /// <summary>
        /// Sự kiện xóa dòng khi bấm delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void locationGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var selectedRows = locationGridView.SelectedRows
                            .Cast<DataGridViewRow>()
                            .Where(row => !row.IsNewRow)
                            .ToList();

                foreach (var row in selectedRows)
                {
                    if (row.DataBoundItem is LocationDto item)
                    {
                        _locations.Remove(item);
                    }
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        /// <summary>
        /// Lưu vị trí đã thêm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void saveBtn_Click(object sender, EventArgs e)
        {
            if (_plsp == null)
            {
                ShowMessage.Warning("Vui lòng chọn một NPL trước khi lưu vị trí.");
                return;
            }

            if (_locations.Count == 0)
            {
                ShowMessage.Warning("Vui lòng thêm ít nhất một vị trí trước khi lưu.");
                return;
            }

            if (_plsp.InventoryQuantity > _quantityLocation)
            {
                ShowMessage.Warning("Vui lòng sắp xếp hết số lượng tồn vào vị trí.");
                return;
            }

            if (_plsp.InventoryQuantity < _quantityLocation)
            {
                ShowMessage.Warning("Tổng số lượng xếp vào vị trí không thể lớn hơn số lượng tồn.");
                return;
            }

            IInventoryService<PlspInventoryDto, PlspInventoryLocationDto> locationService = ServiceFactory.GetInventoryService<PlspInventoryDto, PlspInventoryLocationDto>();

            int nplID = _plsp.NplId ?? _plsp.ID;

            Response<List<PlspInventoryLocationDto>> response = await locationService.UpdateLocationNpl(_plsp.ID, nplID, E_NPLType.PLSP, _locations.ToList());

            if (!response.IsSuccess)
            {
                ShowMessage.Error(response.Message);
                return;
            }

            DialogResult result = ShowMessage.Success("Lưu vị trí thành công.");

            if (result == DialogResult.OK)
            {
                // Chọn máy in
                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new PrinterSettings();
                if (pd.ShowDialog() != DialogResult.OK)
                    return;

                string printerName = pd.PrinterSettings.PrinterName;

                Cursor.Current = Cursors.WaitCursor;

                string pdfPath = QRCodeUtils.GeneratePdfLabels(response.Data!);

                QRCodeUtils.PrintPdf(printerName, pdfPath);

                File.Delete(pdfPath);

                if (MessageBox.Show("Đã in thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Cursor.Current = Cursors.Default;
                    this.Close();
                }
            }
        }
    }
}
