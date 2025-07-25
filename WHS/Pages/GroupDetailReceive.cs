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
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.PLDG;
using WHS.Core.Dto.PLSP;
using WHS.Core.Dto.Receive;
using WHS.Core.Enums;
using WHS.Core.Factory;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Factory;
using WHS.Forms;
using WHS.Popup;
using WHS.Popup.Receive.DetailReceive;
using WHS.Service.Interface;
using WHS.Utils;

namespace WHS.Pages.Receive
{
    public partial class GroupDetailReceive : UserControl
    {
        public MainForm Mainform { get; set; } = new MainForm();

        private E_NPLType _type = E_NPLType.FABRIC;
        private int _currentPage = 1;
        private Dictionary<string, string> _columns = new Dictionary<string, string>();

        public GroupDetailReceive()
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
        private async void DetailReceive_Load(object sender, EventArgs e)
        {
            SetColumnGridView();
            await LoadDataGridView();
            GridViewUtils.SetBuffer(gridView);
        }
        #endregion

        #region Type_NPL

        /// <summary>
        /// Mở sang màn hình 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DetailReceivePage detailReceivePage = FormFactory.CreateUserControl<DetailReceivePage>();
            detailReceivePage.MainForm = Mainform;
            Mainform.ShowUserControl(detailReceivePage);
        }

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
            button.BackColor = Color.FromArgb(0, 46, 92);
        }

        private void SetColumn()
        {
            _columns = _type switch
            {
                E_NPLType.FABRIC => new Dictionary<string, string>()
                {
                    {"Mo", "MO"},
                    {"Style", "Style"},
                    {"Color", "Màu"},
                    {"TypeDetail", "Loại vải"},
                    {"Supplier", "Nhà cung cấp"},
                    {"QuantityToReceived", "Số lượng cần nhận"},
                    {"ReceivedQuantity", "Số lượng đã nhận"},
                    {"ExpectedQuantity", "Số lượng dự kiến nhận"}
                },
                E_NPLType.PLSP => new Dictionary<string, string>()
                {
                    {"Mo", "MO"},
                    {"TypeDetail", "Loại PL"},
                    {"Supplier", "Nhà cung cấp"},
                    {"QuantityToReceived", "Số lượng cần nhận"},
                    {"ReceivedQuantity", "Số lượng đã nhận"},
                    {"ExpectedQuantity", "Số lượng dự kiến nhận"}
                },
                E_NPLType.PLDG => new Dictionary<string, string>()
                {
                    {"Mo", "MO"},
                    {"TypeDetail", "Loại PL"},
                    {"Supplier", "Nhà cung cấp"},
                    {"QuantityToReceived", "Số lượng cần nhận"},
                    {"ReceivedQuantity", "Số lượng đã nhận"},
                    {"ExpectedQuantity", "Số lượng dự kiến nhận"}
                },
                _ => throw new NotSupportedException("Unsupported NPL type")
            };
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

            SetColumnGridView();
            await LoadDataGridView();
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
            SetColumnGridView();
            await LoadDataGridView();
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
            SetColumnGridView();
            await LoadDataGridView();
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
                PageSize = 20
            };

            ReceiveSearch receiveSearch = new ReceiveSearch()
            {
                MO = moSearchTxb.Text
            };

            // Call service
            Response<PageDto<GroupReceiveDto>> res = null!;

            switch (_type)
            {
                case E_NPLType.FABRIC:
                    IReceiveService<FabricDto, FabricReceivedDto> _fabricService = ReceiveFactory.GetService<FabricDto, FabricReceivedDto>(_type);
                    res = await _fabricService.GetGroupedReceiveAsync(paginate, receiveSearch);
                    break;
                case E_NPLType.PLSP:
                    IReceiveService<PlspDto, PlspReceivedDto> _plspService = ReceiveFactory.GetService<PlspDto, PlspReceivedDto>(_type);
                    res = await _plspService.GetGroupedReceiveAsync(paginate, receiveSearch);
                    break;
                case E_NPLType.PLDG:
                    IReceiveService<PldgDto, PldgReceivedDto> _pldgService = ReceiveFactory.GetService<PldgDto, PldgReceivedDto>(_type);
                    res = await _pldgService.GetGroupedReceiveAsync(paginate, receiveSearch);
                    break;
                default:
                    throw new NotSupportedException("Unsupported NPL type");
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
        /// Sự kiện thêm mới đơn NPL (nút "Thêm")
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
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
                var screen = Screen.PrimaryScreen!.WorkingArea;
                popup.Initialize(E_StatusForm.ADD, null);
                popup.Size = new Size(screen.Width * 3 / 4, screen.Height * 3 / 4);
                popup.SaveSuccess += Popup_SaveSuccess;

                popup.Show();
            }
        }

        /// <summary>
        /// Load dữ liệu mới khi mà lưu dữ liệu ở popup thành công
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Popup_SaveSuccess(object? sender, EventArgs e)
        {
            await LoadDataGridView();
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

            if (selectedRow.DataBoundItem is GroupReceiveDto receiveData)
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
                    popup.Initialize(E_StatusForm.VIEW, receiveData);
                    popup.SaveSuccess += Popup_SaveSuccess;

                    var screen = Screen.PrimaryScreen!.WorkingArea;
                    popup.Size = new Size(screen.Width * 3 / 4, screen.Height * 3 / 4);
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
            await LoadDataGridView();

        }

        #endregion
    }
}
