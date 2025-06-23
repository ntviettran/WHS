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
using WHS.Core.Dto;
using WHS.Core.Dto.Receive;
using WHS.Core.Enums;
using WHS.Core.Factory;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Response;
using WHS.Factory;
using WHS.Forms;
using WHS.Popup;
using WHS.Service.Interface;

namespace WHS.Pages.Receive
{ 
    public partial class DetailReceive : UserControl
    {
        private IReceiveService _receiveService;
        private E_NPLType _type;
        private int _currentPage = 1;

        public DetailReceive()
        {
            _receiveService = ReceiveFactory.GetService(_type);
            InitializeComponent();
        }

        #region Setup
        /// <summary>
        /// Sự kiện load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DetailReceive_Load(object sender, EventArgs e)
        {
            await FillDataGridView();
        }
        #endregion

        #region Type_NPL

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
            button.BackColor = Color.DodgerBlue;

            _receiveService = ReceiveFactory.GetService(_type);
        }

        /// <summary>
        /// Sự kiện click vảo button "Vải"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void fabricBtn_Click(object sender, EventArgs e)
        {
            _type = E_NPLType.FABRIC;
            ActiveTypeBtn(fabricBtn);

            _currentPage = 1;
            await FillDataGridView();
        }

        /// <summary>
        /// Sự kiện click vào button "PLSP"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void plspBtn_Click(object sender, EventArgs e)
        {
            _type = E_NPLType.PLSP;
            ActiveTypeBtn(plspBtn);

            _currentPage = 1;
            await FillDataGridView();
        }

        /// <summary>
        /// Sự kiện click vào button "PLĐG"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void pldgBtn_Click(object sender, EventArgs e)
        {
            _type = E_NPLType.PLDG;
            ActiveTypeBtn(pldgBtn);

            _currentPage = 1;
            await FillDataGridView();
        }
        #endregion

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
                e.SuppressKeyPress = true;
                await FillDataGridView();
            }
        }

        /// <summary>
        /// Fill dữ liệu vào datagridview
        /// </summary>
        /// <returns></returns>
        private async Task FillDataGridView()
        {
            // Set up parameter
            Paginate paginate = new Paginate()
            {
                PageIndex = _currentPage,
                PageSize = 20
            };

            ReceiveSearch receiveSearch = new ReceiveSearch()
            {
                MO = moSearchTxb.Text,
                Type = _type,
            };

            // Call service
            Response<PageDto<ReceiveDto>> res = await _receiveService.GetReceiveAsync(paginate, receiveSearch);

            if (!res.IsSuccess) return;

            if (res.Data != null && res.Data.PageData != null)
            {
                gridView.DataSource = res.Data.PageData;
                gridView.ClearSelection();
                pagination.UpdatePagination(_currentPage, res.Data.TotalPage, res.Data.TotalRecord);
            }
        }


        /// <summary>
        /// Sự kiện thêm mới đơn NPL (nút "Thêm")
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            Form? popup = _type switch
            {
                E_NPLType.FABRIC => FormFactory.CreateForm<FabricPopup>(),
                E_NPLType.PLSP => FormFactory.CreateForm<PLSPPopup>(),
                E_NPLType.PLDG => FormFactory.CreateForm<PLDGPopup>(),
                _ => null
            };

            popup?.Show();
        }

        /// <summary>
        /// Sự kiện double click vào row mở poup detail để edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return; // Bỏ qua nếu double click header

            var selectedRow = gridView.Rows[e.RowIndex];

            if (selectedRow.DataBoundItem is ReceiveDto receiveData)
            {
                BasePopup? popup = _type switch
                {
                    E_NPLType.FABRIC => FormFactory.CreateForm<FabricPopup>(),
                    E_NPLType.PLSP => FormFactory.CreateForm<PLSPPopup>(),
                    E_NPLType.PLDG => FormFactory.CreateForm<PLDGPopup>(),
                    _ => null
                };

                if (popup != null)
                {
                    popup.Initialize(E_StatusForm.EDIT, receiveData);
                    popup.Show();
                }
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
            await FillDataGridView();

        }
        #endregion
    }
}
