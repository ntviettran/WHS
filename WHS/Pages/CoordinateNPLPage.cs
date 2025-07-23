using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using WHS.Components;
using WHS.Core.Dto;
using WHS.Core.Dto.Transfer;
using WHS.Core.Enums;
using WHS.Core.Factory;
using WHS.Core.Query.Base;
using WHS.Core.Query.Transfer;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Popup.Transfer;
using WHS.Service.Interface;
using WHS.Service.Services.Coordinate;
using WHS.Utils;

namespace WHS.Pages.Transfer
{
    public partial class CoordinateNPLPage : UserControl
    {
        private ITransferService _transferService;
        private int _currentPage = 1;
        private E_StatusPage _status = E_StatusPage.VIEW;

        public CoordinateNPLPage(ITransferService transferService)
        {
            _transferService = transferService;
            InitializeComponent();
        }

        /// <summary>
        /// Setup khi page quản lí bởi kho
        /// </summary>
        public void InitWarehouseManager()
        {
            //Bước 1: Xóa cột tạo mới ở tìm kiếm
            int lastColumnIndex = tableLayoutPanel1.ColumnCount - 1;

            // Xóa tất cả các control trong cột cuối
            for (int row = 0; row < tableLayoutPanel1.RowCount; row++)
            {
                var control = tableLayoutPanel1.GetControlFromPosition(lastColumnIndex, row);
                if (control != null)
                {
                    tableLayoutPanel1.Controls.Remove(control);
                    control.Dispose();
                }
            }

            // Giảm số lượng cột
            tableLayoutPanel1.ColumnCount--;

            // Xóa ColumnStyle tương ứng
            if (tableLayoutPanel1.ColumnStyles.Count > lastColumnIndex)
            {
                tableLayoutPanel1.ColumnStyles.RemoveAt(lastColumnIndex);
            }

            //Bước 2: Set lại type của page
            _status = E_StatusPage.EDIT;
        }

        /// <summary>
        /// Sự kiện load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TransferNPLPage_Load(object sender, EventArgs e)
        {
            // Setup dữ liệu cho combobox tìm theo trạng thái
            var status = new[]
            {
                new {
                    Text = "Tất cả",
                    Value = -1
                }
            }
            .Concat(
                Enum.GetValues(typeof(E_TransferExec))
                    .Cast<E_TransferExec>()
                    .Select(e => new
                    {
                        Text = EnumHelper.GetEnumDescription(e),
                        Value = (int)e // ép kiểu enum về int
                    })
            )
            .ToList();

            statusCb.DataSource = status;
            statusCb.DisplayMember = "Text";
            statusCb.ValueMember = "Value";

            if (_status == E_StatusPage.VIEW)
            {
                gridView.ContextMenuStrip = contextMenuStrip1;
            } else
            {
                gridView.ContextMenuStrip = null;
            }

            idTxb.Focus();
            await GetTransferData();
            GridViewUtils.SetBuffer(gridView);
        }

        /// <summary>
        /// Get dữ liệu fill vào datagridview
        /// </summary>
        /// <returns></returns>
        private async Task GetTransferData()
        {
            Paginate paginate = new Paginate()
            {
                PageIndex = _currentPage,
                PageSize = 20
            };

            TransferSearch search = new TransferSearch()
            {
                ID = !string.IsNullOrEmpty(idTxb.Text) ? int.Parse(idTxb.Text) : null,
                EstimateExec = esExecDatePicker.Checked ? esExecDatePicker.Value : null,
                EstimateWarehouse = esWarehouseDatePicker.Checked ? esWarehouseDatePicker.Value : null,
                ExecDate = execDatePicker.Checked ? execDatePicker.Value : null,
                WarehouseDate = warehouseDatePicker.Checked ? warehouseDatePicker.Value : null,
                ExecStatus = (int)statusCb.SelectedValue!,
            };

            Response<PageDto<TransferDto>> res = await _transferService.GetTransferByPageAsync(paginate, search);

            if (!res.IsSuccess)
            {
                ShowMessage.Error(res.Message);
                return;
            }

            if (res.Data != null && res.Data.PageData != null)
            {
                gridView.AutoGenerateColumns = false;
                gridView.DataSource = res.Data.PageData;
                gridView.ClearSelection();
                pagination.UpdatePagination(_currentPage, res.Data.TotalPage, res.Data.TotalRecord);
            }
        }

        /// <summary>
        /// Sự kiện thêm mới điều chuyển NPL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            
            if (Program.ServiceProvider == null) return;

            AddTransferPopup transferPopup = FormFactory.CreateForm<AddTransferPopup>();

            this.Enabled = false;
            transferPopup.CallerForm = this;
            transferPopup.SaveSucces += async (sender, e) =>
            {
                await GetTransferData();
            };

            transferPopup.Show();
        }

        /// <summary>
        /// Double click dòng hiện lên detail chi tiết
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = gridView.Rows[e.RowIndex];
                var data = selectedRow.DataBoundItem as TransferDto;

                if (data != null)
                {
                    TransferDetail transferDetail = FormFactory.CreateForm<TransferDetail>();
                    transferDetail.Transfer = data;
                    if (_status == E_StatusPage.EDIT)
                    {
                        transferDetail.InitWarehouseManager();
                    }
                    else
                    {
                        transferDetail.InitPPC();
                    }

                    transferDetail.InitUI();
                    transferDetail.FormClosed += async (sender, e) =>
                    {
                        await GetTransferData();
                    };

                    transferDetail.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Hủy các phiếu điều chhuyển được selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void cancelToolStrip_Click(object sender, EventArgs e)
        {
            var selectedIds = gridView.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(row => row.DataBoundItem as TransferDto)
                .Where(dto => dto != null)
                .Select(dto => dto!.ID)
                .ToList();

            if (selectedIds.Count == 0)
            {
                ShowMessage.Warning("Vui lòng chọn ít nhất một dòng để hủy.");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn hủy các phiếu điều chuyển đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var result = await _transferService.CancelTransfers(selectedIds);

                if (!result.IsSuccess)
                {
                    ShowMessage.Error("Hủy thất bại: " + result.Message);
                    return;
                }

                ShowMessage.Success("Đã hủy thành công!");
                await GetTransferData();
            }
        }

        #region Search

        /// <summary>
        /// Tìm kiếm theo id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void idTxb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (int.TryParse(idTxb.Text, out var idTxbId) || string.IsNullOrEmpty(idTxb.Text))
                {
                    await GetTransferData();
                    return;
                }

                ShowMessage.Warning("ID phải là số nguyên!");
            }
        }

        /// <summary>
        /// Tìm kiếm theo thời gian dự kiến thực hiện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void esExecDatePicker_ValueChanged(object sender, EventArgs e)
        {
            await GetTransferData();
        }

        /// <summary>
        /// Tìm kiếm theo thời gian dự kiến về kho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void esWarehouseDatePicker_ValueChanged(object sender, EventArgs e)
        {
            await GetTransferData();
        }

        /// <summary>
        /// Tìm kiếm theo thời gian thực hiện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void execDatePicker_ValueChanged(object sender, EventArgs e)
        {
            await GetTransferData();
        }

        /// <summary>
        /// Tìm kiến theo thời gian về kho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void warehouseDatePicker_ValueChanged(object sender, EventArgs e)
        {
            await GetTransferData();
        }

        /// <summary>
        /// Sự ện thay đổi trạng thái tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void statusCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            await GetTransferData();
        }

        #endregion
    }
}
