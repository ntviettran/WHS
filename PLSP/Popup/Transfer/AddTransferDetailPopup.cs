using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.PLDG;
using WHS.Core.Dto.PLSP;
using WHS.Core.Dto.Transfer;
using WHS.Core.Enums;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Factory;
using WHS.Service.Interface;
using WHS.Service.Services.Receive;
using WHS.Utils;

namespace WHS.Popup.Transfer
{
    public partial class AddTransferDetailPopup : Form
    {
        public AddTransferPopup CallerForm { get; set; } = default!;
        public TransferDto TransferData { get; set; } = default!;
        public E_StatusPage Status { get; set; } = E_StatusPage.ADD;

        private ITransferService _transferService;
        private E_NPLType _type = E_NPLType.PLSP;
        private Dictionary<string, string> _columns = new Dictionary<string, string>();
        private Dictionary<string, string> _coordinateColumns = new Dictionary<string, string>();

        private List<FabricTransferDetailDto> _fabricSelected = new List<FabricTransferDetailDto>();
        private List<PlspTransferDetailDto> _plspSelected = new List<PlspTransferDetailDto>();
        private List<PLDGTransferDetailDto> _pldgSelected = new List<PLDGTransferDetailDto>();

        public AddTransferDetailPopup()
        {
            _transferService = TransferFactory.GetService(_type);

            InitializeComponent();
            HideFunction();
        }

        private void HideFunction()
        {
            typeContainer.Visible = false;
        }

        /// <summary>
        /// Quay lại form khởi tạo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            CallerForm.Show();
        }

        /// <summary>
        /// Sự kiện đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTransferDetailPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            CallerForm.Show();
        }

        /// <summary>
        /// Sự kiện load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTransferDetailPopup_Load(object sender, EventArgs e)
        {
            GridViewUtils.SetBuffer(coordinateView);
            GridViewUtils.SetBuffer(coordinateDetailView);
            GetDataPlsp();
        }

        /// <summary>
        /// Khởi tạo giá trị cho bảng cần điều phối
        /// </summary>
        private async Task GetCoordiateView()
        {
            var status = E_DispatchTransfer.PENDING;

            switch (_type)
            {
                case E_NPLType.FABRIC:
                    if (_transferService is ITransferService<FabricCoordinationDto, FabricTransferDetailDto> fabricService)
                    {
                        Response<List<FabricCoordinationDto>> res = await fabricService.GetTransferCoordinateByStatus(status);
                        FillCoordiateTable<FabricCoordinationDto>(res);

                        if (Status == E_StatusPage.EDIT)
                        {
                            Response<List<FabricTransferDetailDto>> resDetail = await fabricService.GetTransferDetail(TransferData.ID);

                            if (_fabricSelected.Count == 0 && resDetail.IsSuccess && resDetail.Data != null)
                            {
                                _fabricSelected = resDetail.Data;
                            }
                        }
                    }
                    break;
                case E_NPLType.PLSP:
                    if (_transferService is ITransferService<PlspCoordinationDto, PlspTransferDetailDto> plspService)
                    {
                        Response<List<PlspCoordinationDto>> res = await plspService.GetTransferCoordinateByStatus(status);
                        FillCoordiateTable<PlspCoordinationDto>(res);

                        if (Status == E_StatusPage.EDIT)
                        {
                            Response<List<PlspTransferDetailDto>> resDetail = await plspService.GetTransferDetail(TransferData.ID);

                            if (_plspSelected.Count == 0 && resDetail.IsSuccess && resDetail.Data != null)
                            {
                                _plspSelected = resDetail.Data;
                            }
                        }
                    }
                    break;
                case E_NPLType.PLDG:
                    if (_transferService is ITransferService<PLDGCoordinationDto, PLDGTransferDetailDto> pldgService)
                    {
                        Response<List<PLDGCoordinationDto>> res = await pldgService.GetTransferCoordinateByStatus(status);
                        FillCoordiateTable<PLDGCoordinationDto>(res);

                        if (Status == E_StatusPage.EDIT)
                        {
                            Response<List<PLDGTransferDetailDto>> resDetail = await pldgService.GetTransferDetail(TransferData.ID);

                            if (_pldgSelected.Count == 0 && resDetail.IsSuccess && resDetail.Data != null)
                            {
                                _pldgSelected = resDetail.Data;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Fill dữ liệu T vào bảng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private void FillCoordiateTable<T>(Response<List<T>> res)
        {
            if (!res.IsSuccess)
            {
                ShowMessage.Error(res.Message);
                return;
            }

            coordinateView.DataSource = res.Data;
        }

        /// <summary>
        /// Vẽ lại các cột của gridView
        /// </summary>
        private void SetColumnGridView()
        {
            coordinateView.DataSource = null;
            coordinateView.AutoGenerateColumns = false;
            coordinateView.Columns.Clear();

            coordinateDetailView.DataSource = null;
            coordinateDetailView.AutoGenerateColumns = false;
            coordinateDetailView.Columns.Clear();

            // Kích hoạt autofill
            coordinateView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            coordinateDetailView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            coordinateView.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Selected",
                HeaderText = "",
                Width = 50,
                MinimumWidth = 50,
                FillWeight = 10,
                Frozen = false
            });

            foreach (var column in _columns)
            {
                coordinateView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = column.Key,
                    HeaderText = column.Value,
                    DataPropertyName = column.Key,
                    MinimumWidth = 150,
                    ReadOnly = true
                });
            }

            foreach (var column in _coordinateColumns)
            {
                coordinateDetailView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = column.Key,
                    HeaderText = column.Value,
                    DataPropertyName = column.Key,
                    MinimumWidth = 150,
                    ReadOnly = column.Key != "EstimateQuantity"
                });
            }
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

            _transferService = TransferFactory.GetService(_type);
        }

        /// <summary>
        /// Get dữ liệu fabric
        /// </summary>
        private async void GetDataFabric()
        {
            _type = E_NPLType.FABRIC;
            ActiveTypeBtn(fabricBtn);

            _columns = new Dictionary<string, string>
            {
                {"ID", "ID"},
                {"MO", "MO"},
                {"Style", "Style"},
                {"Color", "Màu"},
                {"FabricType", "Loại vải"},
                {"Batch", "Lot"},
                {"FabricNumber", "Cuộn số"},
                {"QuantityToReceived", "Số lượng cần nhận"},
                {"ReceivedQuantity", "Số lượng đã nhận"},
                {"RemainingQuantity", "Số lượng còn lại"},
                {"StatusDescription", "Trạng thái"},
                {"DispatchStatusDescription", "Trạng thái điều phối"},
            };

            _coordinateColumns = new Dictionary<string, string>
            {
                {"ID", "ID"},
                {"MO", "MO"},
                {"Style", "Style"},
                {"Color", "Màu"},
                {"FabricType", "Loại vải"},
                {"Batch", "Lot"},
                {"QuantityToReceived", "Số lượng cần nhận"},
                {"ReceivedQuantity", "Số lượng thực nhận"},
                {"QuantityStatusDescription", "Trạng thái số lượng"},
                {"LengthReceived", "Chiều dài thực nhận"},
                {"LengthStatusDescription", "Trạng thái chiều dài"},
                {"WeightReceived", "Khối lượng thực nhận"},
                {"WeightStatusDescription", "Trạng thái khối lượng"},
                {"EstimateQuantity", "Số lượng dự kiến nhận"},
            };

            SetColumnGridView();
            await GetCoordiateView();

            foreach (DataGridViewRow row in coordinateView.Rows)
            {
                var item = row.DataBoundItem as FabricCoordinationDto;
                row.Cells["Selected"].Value = _fabricSelected.Any(x => x.ID == item?.ID);
            }

            // Cập nhật lại bảng detail
            coordinateDetailView.DataSource = null;
            coordinateDetailView.DataSource = _fabricSelected.ToList();
        }

        /// <summary>
        /// Get dữ liệu plsp
        /// </summary>
        private async void GetDataPlsp()
        {
            _type = E_NPLType.PLSP;
            ActiveTypeBtn(plspBtn);

            _columns = new Dictionary<string, string>
            {
                {"ID", "ID"},
                {"MO", "MO"},
                {"PlspType", "Loại phụ liệu"},
                {"PlspCode", "Mã code"},
                {"NplColor", "Màu"},
                {"QuantityToReceived", "Số lượng cần nhận"},
                {"ReceivedQuantity", "Số lượng đã nhận"},
                {"StatusDescription", "Trạng thái"},
                {"DispatchStatusDescription", "Trạng thái điều phối"}
            };

            _coordinateColumns = new Dictionary<string, string>
            {
                {"ID", "ID"},
                {"MO", "MO"},
                {"PlspType", "Loại phụ liệu"},
                {"PlspCode", "Mã code"},
                {"NplColor", "Màu"},
                {"MarketCode", "Mã thị trường"},
                {"Size", "Kích thước"},
                {"PlspColor", "Màu sắc sản phẩm"},
                {"QuantityToReceived", "Số lượng cần nhận"},
                {"ReceivedQuantity", "Số lượng thực nhận"},
                {"QuantityStatusDescription", "Trạng thái số lượng"},
                {"EstimateQuantity", "Số lượng dự kiến nhận"},
            };
            SetColumnGridView();
            await GetCoordiateView();

            foreach (DataGridViewRow row in coordinateView.Rows)
            {
                var item = row.DataBoundItem as PlspCoordinationDto;
                row.Cells["Selected"].Value = _plspSelected.Any(x => x.ID == item?.ID);
            }

            // Cập nhật lại bảng detail
            coordinateDetailView.DataSource = null;
            coordinateDetailView.DataSource = _plspSelected.ToList();
        }

        private async void GetDataPldg()
        {
            _type = E_NPLType.PLDG;
            ActiveTypeBtn(pldgBtn);

            _columns = new Dictionary<string, string>
            {
                {"ID", "ID"},
                {"MO", "MO"},
                {"PldgType", "Loại phụ liệu"},
                {"PldgCode", "Mã pack"},
                {"Color", "Màu"},
                {"QuantityToReceived", "Số lượng cần nhận"},
                {"ReceivedQuantity", "Số lượng đã nhận"},
                {"StatusDescription", "Trạng thái"},
                {"DispatchStatusDescription", "Trạng thái điều phối"}
            };

            _coordinateColumns = new Dictionary<string, string>
            {
                {"ID", "ID"},
                {"MO", "MO"},
                {"PldgType", "Loại phụ liệu"},
                {"PldgCode", "Mã pack"},
                {"PoCode", "Mã PO"},
                {"Color", "Màu"},
                {"PldgSize", "Kích thước"},
                {"NetWeight", "N.W"},
                {"GrossWeight", "G.W"},
                {"QuantityToReceived", "Số lượng cần nhận"},
                {"ReceivedQuantity", "Số lượng đã nhận"},
                {"QuantityStatusDescription", "Trạng thái số lượng"},
                {"EstimateQuantity", "Số lượng dự kiến nhận"},
            };
            SetColumnGridView();
            await GetCoordiateView();

            foreach (DataGridViewRow row in coordinateView.Rows)
            {
                var item = row.DataBoundItem as PLDGCoordinationDto;
                row.Cells["Selected"].Value = _pldgSelected.Any(x => x.ID == item?.ID);
            }

            // Cập nhật lại bảng detail
            coordinateDetailView.DataSource = null;
            coordinateDetailView.DataSource = _pldgSelected.ToList();
        }

        /// <summary>
        /// Sự kiện click chọn vải
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fabricBtn_Click(object sender, EventArgs e)
        {
            GetDataFabric();
        }

        /// <summary>
        /// Sự kiện click chọn plsp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plspBtn_Click(object sender, EventArgs e)
        {
            GetDataPlsp();
        }

        /// <summary>
        /// Sự kiện click chọn pldg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pldgBtn_Click(object sender, EventArgs e)
        {
            GetDataPldg();
        }

        /// <summary>
        /// Bắt sự kiện click checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coordinateView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && coordinateView.Columns[e.ColumnIndex].Name == "Selected")
            {
                var row = coordinateView.Rows[e.RowIndex];

                bool isChecked = Convert.ToBoolean(row.Cells["Selected"].EditedFormattedValue);

                switch (_type)
                {
                    case E_NPLType.FABRIC:
                        {
                            var item = row.DataBoundItem as FabricCoordinationDto;
                            if (item == null) return;

                            var id = (int)typeof(FabricCoordinationDto).GetProperty("ID")?.GetValue(item)!;

                            if (isChecked)
                            {
                                if (!_fabricSelected.Any(x => x.ID! == id))
                                {
                                    FabricTransferDetailDto detail = new FabricTransferDetailDto()
                                    {
                                        ID = item.ID,
                                        MO = item.MO,
                                        Style = item.Style,
                                        Color = item.Color,
                                        FabricType = item.FabricType,
                                        Batch = item.Batch,
                                        FabricNumber = item.FabricNumber,
                                        QuantityToReceived = item.QuantityToReceived,
                                        ReceivedQuantity = item.ReceivedQuantity,
                                        WeightReceived = item.WeightReceived,
                                        EstimateQuantity = item.RemainingQuantity,
                                        QuantityStatus = TransferUtils.GetQuantityIntStatus(item.QuantityToReceived, item.ReceivedQuantity),
                                        LengthStatus = TransferUtils.GetQuantityFloatStatus(item.FabricLength, item.LengthReceived),
                                        WeightStatus = TransferUtils.GetQuantityFloatStatus(item.FabricWeight, item.WeightReceived)
                                    };

                                    _fabricSelected.Add(detail);
                                }
                            }
                            else
                            {
                                _fabricSelected.RemoveAll(x => x.ID == id);
                            }

                            coordinateDetailView.DataSource = null;
                            coordinateDetailView.DataSource = _fabricSelected;
                        }
                        break;
                    case E_NPLType.PLDG:
                        {
                            var item = row.DataBoundItem as PLDGCoordinationDto;
                            if (item == null) return;

                            var id = (int)typeof(PLDGCoordinationDto).GetProperty("ID")?.GetValue(item)!;

                            if (isChecked)
                            {
                                if (!_pldgSelected.Any(x => x.ID! == id))
                                {
                                    PLDGTransferDetailDto detail = new PLDGTransferDetailDto()
                                    {
                                        ID = item.ID,
                                        MO = item.MO,
                                        PldgType = item.PldgType,
                                        Color = item.Color,
                                        PldgCode = item.PldgCode,
                                        NetWeight = item.NetWeight,
                                        GrossWeight = item.GrossWeight,
                                        PoCode = item.PoCode,
                                        PldgSize = item.PldgSize,
                                        QuantityToReceived = item.QuantityToReceived,
                                        ReceivedQuantity = item.ReceivedQuantity,
                                        EstimateQuantity = item.RemainingQuantity,
                                        QuantityStatus = TransferUtils.GetQuantityIntStatus(item.QuantityToReceived, item.ReceivedQuantity)
                                    };

                                    _pldgSelected.Add(detail);
                                }
                            }
                            else
                            {
                                _pldgSelected.RemoveAll(x => x.ID == id);
                            }

                            coordinateDetailView.DataSource = null;
                            coordinateDetailView.DataSource = _pldgSelected;
                        }
                        break;
                    case E_NPLType.PLSP:
                        {
                            var item = row.DataBoundItem as PlspCoordinationDto;
                            if (item == null) return;

                            var id = (int)typeof(PlspCoordinationDto).GetProperty("ID")?.GetValue(item)!;

                            if (isChecked)
                            {
                                if (!_plspSelected.Any(x => x.ID! == id))
                                {
                                    PlspTransferDetailDto detail = new PlspTransferDetailDto()
                                    {
                                        ID = item.ID,
                                        MO = item.MO,
                                        PlspCode = item.PlspCode,
                                        PlspType = item.PlspType,
                                        NplColor = item.NplColor,
                                        MarketCode = item.MarketCode,
                                        PlspColor = item.PlspColor,
                                        Size = item.Size,
                                        QuantityToReceived = item.QuantityToReceived,
                                        ReceivedQuantity = item.ReceivedQuantity,
                                        EstimateQuantity = item.RemainingQuantity,
                                        QuantityStatus = TransferUtils.GetQuantityIntStatus(item.QuantityToReceived, item.ReceivedQuantity)
                                    };

                                    _plspSelected.Add(detail);
                                }
                            }
                            else
                            {
                                _plspSelected.RemoveAll(x => x.ID == id);
                            }

                            coordinateDetailView.DataSource = null;
                            coordinateDetailView.DataSource = _plspSelected;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Sự kiện lưu đăng ký form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void saveBtn_Click(object sender, EventArgs e)
        {
            Response<int> res;

            if (Status == E_StatusPage.ADD)
            {
                res = await _transferService.CreateNewTransferAsync(TransferData, _fabricSelected, _plspSelected, _pldgSelected);
            }
            else
            {
                res = await _transferService.UpdateTransferAsync(TransferData, _fabricSelected, _plspSelected, _pldgSelected);
            }

            if (!res.IsSuccess)
            {
                ShowMessage.Error(res.Message);
                return;
            }

            string message = Status == E_StatusPage.ADD ? "Tạo" : "Sửa";
            DialogResult result = ShowMessage.Success($"{message} đợt chuyển thành công!");
            if (result == DialogResult.OK)
            {
                this.Close();

                CallerForm.SaveSuccesCallback();
                CallerForm.Close();
            }
        }

        /// <summary>
        /// Sự kiện bấm nút delete xóa 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coordinateDetailView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;
            IList? sourceList = _type switch
            {
                E_NPLType.FABRIC => _fabricSelected,
                E_NPLType.PLSP => _plspSelected,
                E_NPLType.PLDG => _pldgSelected,
                _ => null
            };

            if (sourceList == null) return;

            // Duyệt các dòng đã chọn
            foreach (DataGridViewRow row in coordinateDetailView.SelectedRows)
            {
                var item = row.DataBoundItem;
                if (item != null)
                {
                    sourceList.Remove(item);
                }
            }

            coordinateDetailView.DataSource = null;
            coordinateDetailView.DataSource = sourceList;
        }
    }
}
