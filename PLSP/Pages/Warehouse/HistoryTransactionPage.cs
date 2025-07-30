using PLSP.Core.Dto.PLSP;
using PLSP.Core.Dto.Transaction;
using PLSP.Core.Enums;
using PLSP.Core.Query.Location;
using PLSP.Core.Query.Transaction;
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
using WHS.Core.Factory;
using WHS.Core.Query.Base;
using WHS.Core.Response;
using WHS.Core.Session;
using WHS.Core.Utils;
using WHS.Factory;
using WHS.Forms;
using WHS.Utils;

namespace PLSP.Pages
{
    public partial class HistoryTransactionPage : UserControl
    {
        private int _currentPage = 1;
        private int _pageSize = 50;
        private Dictionary<string, string> _columns = new Dictionary<string, string>();

        public HistoryTransactionPage()
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

            foreach (var column in _columns)
            {
                gridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = column.Key,
                    HeaderText = column.Value,
                    DataPropertyName = column.Key,
                    MinimumWidth = 200,
                });
            }
        }

        /// <summary>
        /// Sự kiện load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void HistoryTransaction_Load(object sender, EventArgs e)
        {
            E_WHType type = Session.CurrentUser.GetCurrentType();

            if (type == E_WHType.WAREHOUSE)
            {
                codePanel.Visible = false;
                blockPanel.Visible = true;
            }
            else if (type == E_WHType.BLOCK)
            {
                blockPanel.Visible = false;
                codePanel.Visible = true;
            }

            SetColumnGridView();
            await LoadDataGridView();
            GridViewUtils.SetBuffer(gridView);
        }

        #endregion

        private void SetColumn()
        {
            E_WHType type = Session.CurrentUser.GetCurrentType();

            _columns = type switch
            {
                E_WHType.WAREHOUSE => new Dictionary<string, string>()
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
                    ["Area"] = "Block",
                    ["Quantity"] = "Số lượng",
                    ["CreatedAtVN"] = "Thời gian"
                },
                E_WHType.BLOCK => new Dictionary<string, string>()
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
                    ["Code"] = "Mã nhân viên",
                    ["Quantity"] = "Số lượng",
                    ["CreatedAtVN"] = "Thời gian"
                }
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

        private async void blockSearchTxb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _currentPage = 1;
                e.SuppressKeyPress = true;
                await LoadDataGridView();
            }
        }

        private async void codeSearchTxb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _currentPage = 1;
                e.SuppressKeyPress = true;
                await LoadDataGridView();
            }
        }

        private async void datetimeSearch_ValueChanged(object sender, EventArgs e)
        {
            _currentPage = 1;
            await LoadDataGridView();
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

            HistorySearch search = new HistorySearch()
            {
                MO = moSearchTxb.Text,
                Location = locationSearchTxb.Text,
                Area = blockSearchTxb.Text,
                Code = codeSearchTxb.Text,
                CreatedAt = datetimeSearch.Checked ? datetimeSearch.Value.Date : null
            };

            ITransactionService<TransactionPlspDetailDto> _plspService = ServiceFactory.GetTransactionService<TransactionPlspDetailDto>();
            Response<PageDto<TransactionPlspDetailDto>> res = await _plspService.GetHistoryTransactionInventory(paginate, search);

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
    }
}
