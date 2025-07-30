using PLSP.Core.Dto.PLSP;
using PLSP.Core.Query.Location;
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
using WHS.Core.Enums;
using WHS.Core.Factory;
using WHS.Core.Query.Base;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Factory;
using WHS.Forms;
using WHS.Pages;
using WHS.Utils;

namespace PLSP.Pages
{
    public partial class DetailInventoryPage : UserControl
    {
        public MainForm Mainform { get; set; } = new MainForm();

        private int _currentPage = 1;
        private int _pageSize = 50;
        private Dictionary<string, string> _columns = new Dictionary<string, string>();

        public DetailInventoryPage()
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
                    MinimumWidth = 150,
                });
            }
        }

        /// <summary>
        /// Sự kiện load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DetailInventoryPage_Load(object sender, EventArgs e)
        {
            SetColumnGridView();
            await LoadDataGridView();
            GridViewUtils.SetBuffer(gridView);
        }
        #endregion

        /// <summary>
        /// Mở sang màn hình detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prevBtn_Click(object sender, EventArgs e)
        {
            TotalInventoryPage totalInventoryPage = FormFactory.CreateUserControl<TotalInventoryPage>();
            totalInventoryPage.Mainform = Mainform;
            Mainform.ShowUserControl(totalInventoryPage);
        }

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
