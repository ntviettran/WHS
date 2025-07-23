using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Dto;
using WHS.Core.Dto.PO;
using WHS.Core.Dto.Receive;
using WHS.Core.Enums;
using WHS.Core.Factory;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Popup;
using WHS.Popup.PO;
using WHS.Popup.Receive.DetailReceive;
using WHS.Popup.Receive.ReceiveDetailTransaction;
using WHS.Service.Interface;
using WHS.Utils;

namespace WHS.Pages
{
    public partial class POPage : UserControl
    {
        private int _currentPage = 1;
        private IPOService _poSerivce;

        public POPage(IPOService poService)
        {
            _poSerivce = poService;
            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void POPage_Load(object sender, EventArgs e)
        {
            await LoadDataGridView();
            GridViewUtils.SetBuffer(gridView);
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
                PageSize = 20
            };

            string po = txtSearchPO.Text.Trim();

            // Call service
            Response<PageDto<PODto>> res = await _poSerivce.GetPoAsync(paginate, po);

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

        // Thêm mới PO
        private void addBtn_Click(object sender, EventArgs e)
        {
            PoPopup? popup = FormFactory.CreateForm<PoPopup>();
            popup.SaveSuccess += async (s, args) =>
            {
                await LoadDataGridView();
            };
            popup.Show();
        }

        /// <summary>
        /// Double click vào ô dữ liệu để sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return; // Bỏ qua nếu double click header

            var selectedRow = gridView.Rows[e.RowIndex];

            if (selectedRow.DataBoundItem is PODto po)
            {
                PoPopup? popup = FormFactory.CreateForm<PoPopup>();
                popup.Po = po;
                popup.InitEdit();
                popup.SaveSuccess += async (s, args) =>
                {
                    await LoadDataGridView();
                };
                popup.Show();
            }
        }

        /// <summary>
        /// Enter search PO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void txtSearchPO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await LoadDataGridView();
            }
        }
    }
}
