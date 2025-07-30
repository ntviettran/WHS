using PLSP.Core.Dto.Location;
using PLSP.Core.Dto.PLSP;
using PLSP.Core.Dto.Transaction;
using PLSP.Core.Enums;
using PLSP.Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Dto;
using WHS.Core.Dto.User;
using WHS.Core.Enums;
using WHS.Core.Query.Base;
using WHS.Core.Response;
using WHS.Core.Session;
using WHS.Core.Utils;
using WHS.Factory;

namespace PLSP.Pages
{
    public partial class ExportInventoryPage : UserControl
    {
        private BindingList<PlspInventoryLocationDto> _exportData = new BindingList<PlspInventoryLocationDto>();
        private UserInfoDto _userInfo = new UserInfoDto();
        private int _remainingQuantity = 0;

        public ExportInventoryPage()
        {
            InitializeComponent();

            mainPanel.Visible = false;
            SetColumnGridView();
        }

        /// <summary>
        /// Kiểm tra người nhận hàng xuất kho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ssidTxb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                IInventoryService service = ServiceFactory.GetInventoryService();
                Response<(UserInfoDto, int)> res = await service.CheckExportValid(ssidTxb.Text);

                if (!res.IsSuccess)
                {
                    ShowMessage.Error(res.Message);
                    return;
                }

                _userInfo = res.Data.Item1!;
                _remainingQuantity = (_userInfo.LimitQuantity - res.Data.Item2) ?? 0;
                ssidPanel.Visible = false;
                mainPanel.Visible = true;

                codeLabel.Text = _userInfo.Code.ToString();
                locationLabel.Text = _userInfo.Area;

                nplCode.Focus();
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

            Dictionary<string, string> columns = SetColumn();

            List<string> editColumn = new List<string>()
            {
                "ExportQuantity",
            };

            // Kích hoạt autofill
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (var column in columns)
            {
                gridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = column.Key,
                    HeaderText = column.Value,
                    DataPropertyName = column.Key,
                    MinimumWidth = 150,
                    ReadOnly = editColumn.Contains(column.Key) ? false : true
                });
            }

            gridView.DataSource = _exportData;
        }

        private Dictionary<string, string> SetColumn()
        {
            return new Dictionary<string, string>
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
                ["Quantity"] = "Số lượng tồn",
                ["ExportQuantity"] = "Số lượng xuất",
            };
        }

        /// <summary>
        /// Sự kiện xóa dòng khi bấm delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var selectedRows = gridView.SelectedRows
                            .Cast<DataGridViewRow>()
                            .Where(row => !row.IsNewRow)
                            .ToList();

                foreach (var row in selectedRows)
                {
                    if (row.DataBoundItem is PlspInventoryLocationDto item)
                    {
                        _exportData.Remove(item);
                    }
                }
            }
        }

        /// <summary>
        /// Quét QR Code sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void nplCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (int.TryParse(nplCode.Text.Split("-")[0], out int id))
                {
                    IInventoryService<PlspInventoryDto, PlspInventoryLocationDto> _plspService = ServiceFactory.GetInventoryService<PlspInventoryDto, PlspInventoryLocationDto>();
                    Response<PlspInventoryLocationDto> res = await _plspService.GetInventoryLocationAsync(id);


                    if (!res.IsSuccess)
                    {
                        ShowMessage.Error(res.Message);
                        nplCode.Text = string.Empty;
                        nplCode.Focus();
                        return;
                    }

                    PlspInventoryLocationDto data = res.Data!;
                    data.ExportQuantity = Math.Min(Convert.ToInt32(data.Quantity), 50);

                    _exportData.Add(res.Data!);
                    gridView.ClearSelection();
                    nplCode.Text = string.Empty;
                    nplCode.Focus();
                }
                else
                {
                    ShowMessage.Error("Không hợp lệ!");
                }
            }
        }

        private async void exportBtn_Click(object sender, EventArgs e)
        {
            if (_exportData == null || !_exportData.Any())
            {
                ShowMessage.Warning("Không có dữ liệu để xuất kho");
                return;
            }

            var invalidRows = _exportData
                .Where(item => item.ExportQuantity > item.Quantity)
                .ToList();

            if (invalidRows.Any())
            {
                ShowMessage.Warning("Kiểm tra lại dữ liệu xuất ra không thể lớn hơn dữ liệu tồn");
                return;
            }

            int totalExport = _exportData.Sum(item => item.ExportQuantity);

            if (Session.CurrentUser.GetCurrentType() == E_WHType.BLOCK && totalExport > _remainingQuantity)
            {
                ShowMessage.Warning($"Người này không thể xuất nhiều hơn {_remainingQuantity} trong ngày hôm nay");
                return;
            }

            List<TransactionCreateDto> transactionDetails = _exportData
            .Select(x => new TransactionCreateDto
            {
                LocationId = x.ID,
                NplId = x.NplId,
                NplType = E_NPLType.PLSP,
                ExportQuantity = x.ExportQuantity
            }).ToList();

            ITransactionService service = ServiceFactory.GetTransactionService();

            Response<int> res = await service.InventoryExport(_userInfo, transactionDetails);

            if (!res.IsSuccess)
            {
                MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Xuất kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ssidTxb.Text = String.Empty;
            _exportData = new BindingList<PlspInventoryLocationDto>();
            gridView.DataSource = _exportData;

            ssidPanel.Visible = true;
            mainPanel.Visible = false;

            ssidTxb.Focus();
        }
    }
}
