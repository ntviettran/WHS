using PLSP.Core.Dto.PLSP;
using PLSP.Core.Enums;
using PLSP.Core.Query.Location;
using PLSP.Popup.Inventory;
using PLSP.Popup.User;
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
using WHS.Core.Factory;
using WHS.Core.Query.Base;
using WHS.Core.Response;
using WHS.Core.Session;
using WHS.Core.Utils;
using WHS.Factory;
using WHS.Forms;
using WHS.Service.Interface;
using WHS.Utils;

namespace PLSP.Pages.Warehouse
{
    public partial class WorkerPage : UserControl
    {
        private int _currentPage = 1;
        private int _pageSize = 50;
        private Dictionary<string, string> _columns = new Dictionary<string, string>();

        public WorkerPage()
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
        private async void WorkerPage_Load(object sender, EventArgs e)
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
                ["SSID"] = "SSID",
                ["Code"] = "Mã nhân viên",
                ["LimitQuantity"] = "Số lượng giới hạn mỗi ngày",
            };
        }

        #region NPL_Table

        /// <summary>
        /// Sự kiện enter để tìm kiếm mo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void codeSearchTxb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _currentPage = 1;
                e.SuppressKeyPress = true;

                if (int.TryParse(codeSearchTxb.Text, out int code) || string.IsNullOrEmpty(codeSearchTxb.Text))
                {
                    await LoadDataGridView();
                }
                else
                {
                    ShowMessage.Warning("Mã nhân viên không hợp lệ");
                }

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

            int? id = null;

            if (codeSearchTxb != null && int.TryParse(codeSearchTxb.Text, out int parseID))
            {
                id = parseID;
            }

            IUserService userService = ServiceFactory.GetUserService();
            Response<PageDto<UserInfoDto>> res = await userService.GetUserPage(paginate, id);

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

        private void addBtn_Click(object sender, EventArgs e)
        {
            UserPopup popup = new UserPopup(E_StatusForm.ADD, null);
            popup.SaveSucess = async () =>
            {
                await LoadDataGridView();
            };

            popup.ShowDialog();
        }

        private void gridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gridView.SelectedRows.Count > 0)
            {
                UserInfoDto selectedItem = (UserInfoDto)gridView.SelectedRows[0].DataBoundItem;

                UserPopup popup = new UserPopup(E_StatusForm.EDIT, selectedItem);
                popup.SaveSucess = async () =>
                {
                    await LoadDataGridView();
                };

                popup.ShowDialog();
            }
        }

        private async void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                UserInfoDto selectedItem = (UserInfoDto)gridView.SelectedRows[0].DataBoundItem;

                DialogResult result = MessageBox.Show("Bạn thực sự muốn xóa nhân viên này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes) {
                    IUserService userService = ServiceFactory.GetUserService();
                    Response<int> res = await userService.DeleteUser(selectedItem.ID);

                    if (!res.IsSuccess) { 
                        ShowMessage.Error(res.Message);
                        return;
                    }

                    await LoadDataGridView();
                }
            }
        }
    }
}
