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
using WHS.Core.Utils;
using WHS.Factory;
using WHS.Forms;
using WHS.Pages.Receive;
using WHS.Service.Interface;
using WHS.Utils;

namespace WHS.Pages
{
    public partial class DetailReceivePage : UserControl
    {
        public MainForm MainForm { get; set; } = new MainForm();

        private E_NPLType _type = E_NPLType.FABRIC;
        private int _currentPage = 1;
        private Dictionary<string, string> _columns = new Dictionary<string, string>();

        public DetailReceivePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Setup combobox
        /// </summary>
        protected void SetupCombobox()
        {
            if (statusCbx == null || dispatchStatusCbx == null) return;

            var statusList = Enum.GetValues(typeof(E_TransferReceived))
                .Cast<E_TransferReceived>()
                .Select(e => new
                {
                    Value = (int)e,
                    Text = EnumHelper.GetEnumDescription(e)
                })
                .ToList();

            // Thêm dòng "Tất cả"
            statusList.Insert(0, new { Value = -1, Text = "Tất cả" });

            statusCbx.DataSource = statusList;
            statusCbx.DisplayMember = "Text";
            statusCbx.ValueMember = "Value";

            var dispatchList = Enum.GetValues(typeof(E_DispatchTransfer))
                .Cast<E_DispatchTransfer>()
                .Select(e => new
                {
                    Value = (int)e,
                    Text = EnumHelper.GetEnumDescription(e)
                })
                .ToList();

            // Thêm dòng "Tất cả"
            dispatchList.Insert(0, new { Value = -1, Text = "Tất cả" });

            dispatchStatusCbx.DataSource = dispatchList;
            dispatchStatusCbx.DisplayMember = "Text";
            dispatchStatusCbx.ValueMember = "Value";
        }

        /// <summary>
        /// Trở về màn group theo mo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            GroupDetailReceive detailReceive = FormFactory.CreateUserControl<GroupDetailReceive>();
            detailReceive.Mainform = MainForm;
            MainForm.ShowUserControl(detailReceive);
        }

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
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            int index = 0;
            foreach (var column in _columns)
            {
                gridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = column.Key,
                    HeaderText = column.Value,
                    DataPropertyName = column.Key,
                    MinimumWidth = 150,
                    Frozen = index < 6
                });
                index++;
            }

            gridView.Refresh();

            foreach (DataGridViewColumn column in gridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
        }

        /// <summary>
        /// Sự kiện load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DetailReceivePage_Load(object sender, EventArgs e)
        {
            SetupCombobox();
            SetColumnGridView();
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

            ReceiveSearch receiveSearch = new ReceiveSearch()
            {
                MO = moSearchTxb.Text,
                Status = statusCbx.SelectedValue != null ? Convert.ToInt32(statusCbx.SelectedValue) : -1,
                DispatchStatus = dispatchStatusCbx.SelectedValue != null ? Convert.ToInt32(dispatchStatusCbx.SelectedValue) : -1
            };

            // Call servirce

            switch (_type)
            {
                case E_NPLType.FABRIC:
                    {
                        IReceiveService<FabricDto, FabricReceivedDto> fabricService = ReceiveFactory.GetService<FabricDto, FabricReceivedDto>(_type);

                        Response<PageDto<FabricReceivedDto>> res = await fabricService.GetDetailReceiveAsync(paginate, receiveSearch);
                        if (res.IsSuccess)
                        {
                            gridView.DataSource = res.Data!.PageData;
                            pagination.UpdatePagination(_currentPage, res.Data.TotalPage, res.Data.TotalRecord);
                        }
                        else
                        {
                            ShowMessage.Error(res.Message);
                        }
                        break;
                    }
                case E_NPLType.PLSP:
                    {
                        IReceiveService<PlspDto, PlspReceivedDto> plspService = ReceiveFactory.GetService<PlspDto, PlspReceivedDto>(_type);

                        Response<PageDto<PlspReceivedDto>> res = await plspService.GetDetailReceiveAsync(paginate, receiveSearch);
                        if (res.IsSuccess)
                        {
                            gridView.DataSource = res.Data!.PageData;
                            pagination.UpdatePagination(_currentPage, res.Data.TotalPage, res.Data.TotalRecord);
                        }
                        else
                        {
                            ShowMessage.Error(res.Message);
                        }
                        break;
                    }
                case E_NPLType.PLDG:
                    {
                        IReceiveService<PldgDto, PldgReceivedDto> pldgService = ReceiveFactory.GetService<PldgDto, PldgReceivedDto>(_type);

                        Response<PageDto<PldgReceivedDto>> res = await pldgService.GetDetailReceiveAsync(paginate, receiveSearch);
                        if (res.IsSuccess)
                        {
                            gridView.DataSource = res.Data!.PageData;
                            pagination.UpdatePagination(_currentPage, res.Data.TotalPage, res.Data.TotalRecord);
                        }
                        else
                        {
                            ShowMessage.Error(res.Message);
                        }
                        break;
                    }
                default:
                    throw new NotSupportedException("Unsupported NPL type");
            }
        }

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
            button.BackColor = Color.FromArgb(0, 46, 92);
        }

        private void SetColumn()
        {
            _columns = _type switch
            {
                E_NPLType.FABRIC => new Dictionary<string, string>()
                {
                    ["ID"] = "ID",
                    ["MO"] = "MO",
                    ["Supplier"] = "Mã nhà cung cấp",
                    ["Style"] = "Style",
                    ["Color"] = "Màu",
                    ["FabricType"] = "Loại vải",
                    ["Batch"] = "Lot",
                    ["FabricLength"] = "Chiều dài",
                    ["LengthUnit"] = "Đơn vị chiều dài",
                    ["FabricWeight"] = "Khối lượng",
                    ["WeightUnit"] = "Đơn vị khối lượng",
                    ["FabricNumber"] = "Cuộn số",
                    ["RollWidth"] = "Khổ",
                    ["WidthUnit"] = "Đơn vị khổ",
                    ["QuantityToReceived"] = "Số lượng cần nhận",
                    ["ReceivedQuantity"] = "Số lượng đã nhận",
                    ["RemainingQuantity"] = "Số lượng còn lại",
                    ["EstimateQuantity"] = "Số lượng dự kiến nhận",
                    ["QuantityUnit"] = "Đơn vị số lượng",
                    ["OrderDate"] = "Ngày đặt hàng",
                    ["AvailableDate"] = "Ngày có thể nhận",
                    ["ExpectedDate"] = "Ngày dự kiến nhận",
                    ["StatusDescription"] = "Trạng thái",
                    ["DispatchStatusDescription"] = "Trạng thái điều phối",
                },
                E_NPLType.PLSP => new Dictionary<string, string>()
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
                    ["QuantityToReceived"] = "Số lượng cần nhận",
                    ["ReceivedQuantity"] = "Số lượng đã nhận",
                    ["RemainingQuantity"] = "Số lượng còn lại",
                    ["EstimateQuantity"] = "Số lượng dự kiến nhận",
                    ["OrderDate"] = "Ngày đặt hàng",
                    ["AvailableDate"] = "Ngày có thể nhận",
                    ["ExpectedDate"] = "Ngày dự kiến nhận",
                    ["StatusDescription"] = "Trạng thái",
                    ["DispatchStatusDescription"] = "Trạng thái điều phối",
                },
                E_NPLType.PLDG => new Dictionary<string, string>()
                {
                    ["ID"] = "ID",
                    ["MO"] = "MO",
                    ["Supplier"] = "Mã nhà cung cấp",
                    ["PldgType"] = "Loại phụ liệu",
                    ["PldgCode"] = "Mã code",
                    ["PoCode"] = "Mã PO",
                    ["QuantityPerCarton"] = "Số chiếc mỗi thùng",
                    ["NetWeight"] = "N.W",
                    ["GrossWeight"] = "G.W",
                    ["Color"] = "Màu",
                    ["PldgWeight"] = "Khối lượng",
                    ["WeightUnit"] = "Đơn vị khối lương",
                    ["PldgSize"] = "Kích thước",
                    ["SizeUnit"] = "Đơn vị kích thước",
                    ["QuantityToReceived"] = "Số lượng cần nhận",
                    ["ReceivedQuantity"] = "Số lượng đã nhận",
                    ["RemainingQuantity"] = "Số lượng còn lại",
                    ["EstimateQuantity"] = "Số lượng dự kiến nhận",
                    ["OrderDate"] = "Ngày đặt hàng",
                    ["AvailableDate"] = "Ngày có thể nhận",
                    ["ExpectedDate"] = "Ngày dự kiến nhận",
                    ["StatusDescription"] = "Ngày dự kiến nhận",
                    ["DispatchStatusDescription"] = "Ngày dự kiến nhận",
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

        /// <summary>
        /// Search theo Mo
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
        /// Search theo trạng thái 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void statusCbx_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _currentPage = 1;
            await LoadDataGridView();
        }

        /// <summary>
        /// Search theo trạng thái điều phối
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void dispatchStatusCbx_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _currentPage = 1;
            await LoadDataGridView();
        }
    }
}
