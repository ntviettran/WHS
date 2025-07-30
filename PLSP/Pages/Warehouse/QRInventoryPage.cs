using PLSP.Core.Dto.Location;
using PLSP.Core.Dto.PLSP;
using PLSP.Core.Query.Location;
using PLSP.Service.Interface;
using PLSP.Utils;
using QRCoder;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Dto;
using WHS.Core.Enums;
using WHS.Core.Factory;
using WHS.Core.Query.Base;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Factory;
using WHS.Forms;
using WHS.Pages;
using WHS.Utils;
using ZXing.Windows.Compatibility;

namespace PLSP.Pages
{
    public partial class QRInventoryPage : UserControl
    {
        private int _currentPage = 1;
        private int _pageSize = 50;
        private Dictionary<string, string> _columns = new Dictionary<string, string>();

        private List<PlspInventoryLocationDto> _inventoryLocations = new List<PlspInventoryLocationDto>();

        public QRInventoryPage()
        {
            InitializeComponent();
        }

        #region Setup

        /// <summary>
        /// Vẽ lại các cột của gridView
        /// </summary>
        private void SetColumnGridView()
        {
            gridView.DataSource = null;
            gridView.AutoGenerateColumns = false;
            gridView.Columns.Clear();

            SetColumn();

            // Kích hoạt autofill
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            gridView.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Selected",
                HeaderText = "",
                Width = 50,
                MinimumWidth = 50,
                FillWeight = 10,
                Frozen = false
            });

            foreach (var column in _columns)
            {
                gridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = column.Key,
                    HeaderText = column.Value,
                    DataPropertyName = column.Key,
                    ReadOnly = true,
                    MinimumWidth = 150,
                });
            }
        }

        /// <summary>
        /// Sự kiện load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void QRInventoryPage_Load(object sender, EventArgs e)
        {
            SetColumnGridView();
            await LoadDataGridView();
            GridViewUtils.SetBuffer(gridView);
        }
        #endregion

        private void SetColumn()
        {
            _columns = new Dictionary<string, string>()
            {
                ["ID"] = "ID",
                ["MO"] = "MO",
                ["Supplier"] = "Mã nhà cung cấp",
                ["PlspType"] = "Loại phụ liệu",
                ["PlspCode"] = "Mã code",
                ["NplColor"] = "Màu",
                ["MarketCode"] = "Mã thị trường",
                ["Size"] = "Kích thước",
                ["PlspColor"] = "Màu sản phẩm",
                ["Location"] = "Vị trí",
                ["Quantity"] = "Số lượng"
            };
        }

        #region NPL_Table

        /// <summary>
        /// Sự kiện enter để tìm kiếm mo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void moSearchTxb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _currentPage = 1;
                e.SuppressKeyPress = true;
                await LoadDataGridView();
            }
        }

        /// <summary>
        /// Search theo vị trí
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void locationSearchTxb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _currentPage = 1;
                e.SuppressKeyPress = true;
                await LoadDataGridView();
            }

        }

        /// <summary>
        /// Fill dữ liệu vào datagridview
        /// </summary>
        /// <returns></returns>
        private async Task LoadDataGridView()
        {
            // Set up parameter
            Paginate paginate = new Paginate()
            {
                PageIndex = _currentPage,
                PageSize = _pageSize
            };

            LocationSearch search = new LocationSearch()
            {
                MO = moSearchTxb.Text,
                Location = locationSearchTxb.Text,
            };

            IInventoryService<PlspInventoryDto, PlspInventoryLocationDto> _plspService = ServiceFactory.GetInventoryService<PlspInventoryDto, PlspInventoryLocationDto>();
            Response<PageDto<PlspInventoryLocationDto>> res = await _plspService.GetInventoryLocationsAsync(paginate, search);

            if (!res.IsSuccess)
            {
                ShowMessage.Error(res.Message);
                return;
            }

            if (res.Data != null && res.Data.PageData != null)
            {
                gridView.DataSource = res.Data.PageData;
                gridView.ClearSelection();
                pagination.UpdatePagination(_currentPage, res.Data.TotalPage, res.Data.TotalRecord);

                foreach (DataGridViewRow row in gridView.Rows)
                {
                    if (row.DataBoundItem is PlspInventoryLocationDto location)
                    {
                        bool isChecked = _inventoryLocations.Any(x => x.ID == location.ID);
                        row.Cells["Selected"].Value = isChecked;
                    }
                }

            }
        }

        /// <summary>
        /// Xử lí checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && gridView.Columns[e.ColumnIndex].Name == "Selected")
            {
                var row = gridView.Rows[e.RowIndex];
                var item = row.DataBoundItem;

                bool isChecked = Convert.ToBoolean(gridView.Rows[e.RowIndex].Cells["Selected"].Value);

                if (isChecked)
                {
                    if (item is PlspInventoryLocationDto location)
                    {
                        _inventoryLocations.Add(location);
                    }
                }
                else
                {
                    if (item is PlspInventoryLocationDto location)
                    {
                        _inventoryLocations.RemoveAll(l => l.ID == location.ID);
                    }
                }
            }
        }

        /// <summary>
        /// Chọn giá trị luôn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gridView.IsCurrentCellDirty && gridView.CurrentCell is DataGridViewCheckBoxCell)
            {
                gridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        #endregion

        #region pagination

        /// <summary>
        /// Bắt sự kiện khi pagination thay đổi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void pagination_PageChanged(object sender, int currentPage)
        {
            _currentPage = currentPage;
            await LoadDataGridView();

        }

        #endregion

        /// <summary>
        /// Tick chọn nhiều những dòng đc select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridView.SelectedRows)
            {
                if (row.DataBoundItem is PlspInventoryLocationDto item)
                {
                    row.Cells["Selected"].Value = true;

                    if (!_inventoryLocations.Any(l => l.ID == item.ID))
                    {
                        _inventoryLocations.Add(item);
                    }
                }
            }

            gridView.RefreshEdit();
        }

        /// <summary>
        /// Bỏ tick những dòng đc được select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void unSelectMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridView.SelectedRows)
            {
                if (row.DataBoundItem is PlspInventoryLocationDto item)
                {
                    row.Cells["Selected"].Value = false;

                    _inventoryLocations.RemoveAll(l => l.ID == item.ID);
                }
            }

            gridView.RefreshEdit();
        }

        private void qrBtn_Click(object sender, EventArgs e)
        {
            if (!_inventoryLocations.Any())
            {
                MessageBox.Show("Vui lòng chọn NPL cần tạo QR", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chọn máy in
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (pd.ShowDialog() != DialogResult.OK)
                return;

            string printerName = pd.PrinterSettings.PrinterName;

            Cursor.Current = Cursors.WaitCursor;

            string pdfPath = QRCodeUtils.GeneratePdfLabels(_inventoryLocations);

            QRCodeUtils.PrintPdf(printerName, pdfPath);

            File.Delete(pdfPath);

            Cursor.Current = Cursors.Default;
            MessageBox.Show("Đã in thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            _inventoryLocations.Clear();
            gridView.ClearSelection();

            foreach (DataGridViewRow row in gridView.Rows)
            {
                row.Cells["Selected"].Value = false;
            }
        }
    }
}
