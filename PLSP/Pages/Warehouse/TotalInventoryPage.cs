using PLSP.Core.Dto.PLSP;
using PLSP.Core.Enums;
using PLSP.Popup.Inventory;
using PLSP.Repository.Interfaces;
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
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.PLDG;
using WHS.Core.Dto.PLSP;
using WHS.Core.Dto.Receive;
using WHS.Core.Enums;
using WHS.Core.Factory;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Response;
using WHS.Core.Session;
using WHS.Core.Utils;
using WHS.Factory;
using WHS.Forms;
using WHS.Pages;
using WHS.Popup;
using WHS.Popup.Receive.DetailReceive;
using WHS.Service.Interface;
using WHS.Utils;

namespace PLSP.Pages
{
    public partial class TotalInventoryPage : UserControl
    {
        public MainForm Mainform { get; set; } = new MainForm();

        private int _currentPage = 1;
        private int _pageSize = 50;
        private Dictionary<string, string> _columns = new Dictionary<string, string>();

        public TotalInventoryPage()
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
                    DataPropertyName = column.Key
                });
            }
        }

        /// <summary>
        /// Sự kiện load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TotalInventoryPage_Load(object sender, EventArgs e)
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
        private void detailBtn_Click(object sender, EventArgs e)
        {
            DetailInventoryPage detailInventoryPage = FormFactory.CreateUserControl<DetailInventoryPage>();
            detailInventoryPage.Mainform = Mainform;
            Mainform.ShowUserControl(detailInventoryPage);
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
                ["InventoryQuantity"] = "Số lượng tồn kho"
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


            IInventoryService<PlspInventoryDto, PlspInventoryLocationDto> _plspService = ServiceFactory.GetInventoryService<PlspInventoryDto, PlspInventoryLocationDto>();

            Response<PageDto<PlspInventoryDto>> res = null!;

            if (Session.CurrentUser.Decentralization == 1)
            {
                res = await _plspService.GetInventoryAsync(paginate, moSearchTxb.Text);
            }
            else
            {
                res = await _plspService.GetBlockAsync(paginate, moSearchTxb.Text);
            }

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

        /// <summary>
        /// Double click mở ra phân phối vị trí
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gridView.SelectedRows.Count > 0)
            {
                PlspInventoryDto selectedItem = (PlspInventoryDto)gridView.SelectedRows[0].DataBoundItem;

                DetailInventoryPopup poup = new DetailInventoryPopup(selectedItem);
                poup.ShowDialog();
            }
        }


        private void arrangeStripMode_Click(object sender, EventArgs e)
        {
            if (gridView.SelectedRows.Count > 0)
            {
                PlspInventoryDto selectedItem = (PlspInventoryDto)gridView.SelectedRows[0].DataBoundItem;

                E_WHType type = Session.CurrentUser.Decentralization == 1 ? E_WHType.WAREHOUSE : E_WHType.BLOCK;

                MoveToLocationPopup poup = new MoveToLocationPopup(selectedItem, type);
                var screen = Screen.PrimaryScreen!.WorkingArea;
                poup.Height = screen.Height * 3 / 4;

                poup.ShowDialog();
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
