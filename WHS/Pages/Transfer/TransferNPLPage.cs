using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace WHS.Pages.Transfer
{
    public partial class TransferNPLPage : UserControl
    {
        private ITransferService _transferService;
        private int _currentPage = 1;

        public TransferNPLPage(ITransferService transferService)
        {
            _transferService = transferService;
            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TransferNPLPage_Load(object sender, EventArgs e)
        {
            // Setup dữ liệu cho combobox tìm theo trạng thái
            var status = Enum.GetValues(typeof(E_TransferExec))
                       .Cast<E_TransferExec>()
                       .Select(e => new
                       {
                           Text = EnumHelper.GetEnumDescription(e),
                           Value = e
                       })
                        .ToList();

            statusCb.DataSource = status;
            statusCb.DisplayMember = "Text";
            statusCb.ValueMember = "Value";
            statusCb.SelectedValue = E_TransferExec.PENDING;

            idTxb.Focus();

            await GetTransferData();
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
                ExecStatus = (E_TransferExec)statusCb.SelectedValue!,
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

                if (data != null) {
                    TransferDetail transferDetail = FormFactory.CreateForm<TransferDetail>();
                    transferDetail.Transfer = data;
                    transferDetail.InitUI();

                    transferDetail.FormClosed += async (sender, e) =>
                    {
                        await GetTransferData();
                    };

                    transferDetail.ShowDialog();
                }
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

                if (int.TryParse(idTxb.Text, out var idTxbId))
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

        #endregion
    }
}
