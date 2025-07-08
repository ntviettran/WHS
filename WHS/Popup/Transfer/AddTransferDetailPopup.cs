using System;
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
using WHS.Core.Dto.PLSP;
using WHS.Core.Dto.Transfer;
using WHS.Core.Enums;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Factory;
using WHS.Service.Interface;
using WHS.Service.Services.Receive;

namespace WHS.Popup.Transfer
{
    public partial class AddTransferDetailPopup : Form
    {
        public AddTransferPopup CallerForm { get; set; } = default!;
        public TransferDto TransferData { get; set; } = default!;
        public E_StatusPage Status { get; set; } = E_StatusPage.ADD;

        private ITransferService _transferService;
        private E_NPLType _type = E_NPLType.FABRIC;
        private Dictionary<string, string> _columns = new Dictionary<string, string>();

        private List<FabricCoordinationDto> _fabricSelected = new List<FabricCoordinationDto>();
        private List<PLSPCoordinationDto> _plspSelected = new List<PLSPCoordinationDto>();
        private List<PLDGCoordinationDto> _pldgSelected = new List<PLDGCoordinationDto>();

        public AddTransferDetailPopup()
        {
            _transferService = TransferFactory.GetService(_type);

            InitializeComponent();
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
            GetDataFabric();
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
                                _fabricSelected = resDetail.Data.Select(f => new FabricCoordinationDto()
                                {
                                    ID = f.ID,
                                    IdNplReceived = f.IdNplReceived,
                                    MO = f.MO,
                                    Style = f.Style,
                                    Color = f.Color,
                                    FabricType = f.FabricType,
                                    Batch = f.Batch,
                                    QuantityToReceived = f.QuantityToReceived,
                                    QuantityReceived = f.QuantityReceived,
                                    EstimateQuantity = f.EstimateQuantity,
                                }).ToList();
                            }
                        }
                    }
                    break;
                case E_NPLType.PLSP:
                    if (_transferService is ITransferService<PLSPCoordinationDto, PLDGTransferDetailDto> plspService)
                    {
                        Response<List<PLSPCoordinationDto>> res = await plspService.GetTransferCoordinateByStatus(status);
                        FillCoordiateTable<PLSPCoordinationDto>(res);
                    }
                    break;
                case E_NPLType.PLDG:
                    if (_transferService is ITransferService<PLDGCoordinationDto, PLDGTransferDetailDto> pldgService)
                    {
                        Response<List<PLDGCoordinationDto>> res = await pldgService.GetTransferCoordinateByStatus(status);
                        FillCoordiateTable<PLDGCoordinationDto>(res);
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

                if (column.Key == "StatusDescription" || column.Key == "DispatchStatusDescription") continue;

                coordinateDetailView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = column.Key,
                    HeaderText = column.Value,
                    DataPropertyName = column.Key,
                    MinimumWidth = 150,
                    ReadOnly = true
                });
            }

            coordinateDetailView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EstimateQuantity",
                HeaderText = "Số lượng dự kiến",
                DataPropertyName = "EstimateQuantity",
                MinimumWidth = 150
            });
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
            button.BackColor = Color.DodgerBlue;

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
                {"IdNplReceived", "ID NPL nhận"},
                {"MO", "MO"},
                {"Style", "Style"},
                {"Color", "Màu"},
                {"FabricType", "Loại vải"},
                {"Batch", "Lót"},
                {"QuantityToReceived", "Số lượng cần nhận"},
                {"QuantityReceived", "Số lượng đã nhận"},
                {"RemainingQuantity", "Số lượng còn phải nhận"},
                {"StatusDescription", "Trạng thái"},
                {"DispatchStatusDescription", "Trạng thái điều phối"},
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
                {"IdNplReceived", "ID NPL nhận"},
                {"MO", "MO"},
                {"PlspType", "Loại phụ liệu"},
                {"PlspCode", "Mã code"},
                {"NplColor", "Màu"},
                {"QuantityToReceived", "Số lượng cần nhận"},
                {"QuantityReceived", "Số lượng đã nhận"},
                {"RemainingQuantity", "Số lượng còn phải nhận"},
                {"StatusDescription", "Trạng thái"},
                {"DispatchStatusDescription", "Trạng thái điều phối"}
            };
            SetColumnGridView();
            await GetCoordiateView();

            foreach (DataGridViewRow row in coordinateView.Rows)
            {
                var item = row.DataBoundItem as PLSPCoordinationDto;
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
                {"IdNplReceived", "ID NPL nhận"},
                {"MO", "MO"},
                {"PldgType", "Loại phụ liệu"},
                {"PackCode", "Mã pack"},
                {"Color", "Màu"},
                {"QuantityToReceived", "Số lượng cần nhận"},
                {"QuantityReceived", "Số lượng đã nhận"},
                {"RemainingQuantity", "Số lượng còn phải nhận"},
                {"StatusDescription", "Trạng thái"},
                {"DispatchStatusDescription", "Trạng thái điều phối"}
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
        /// Hàm handle row selection theo generictype
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <param name="isChecked"></param>
        /// <param name="selectedList"></param>
        private void HandleRowSelection<T>(DataGridViewRow row, bool isChecked, List<T> selectedList)
        where T : class
        {
            var item = row.DataBoundItem as T;
            if (item == null) return;

            // Dùng reflection nếu không muốn dùng interface
            var id = (int)typeof(T).GetProperty("ID")?.GetValue(item)!;
            var remaining = (int)typeof(T).GetProperty("RemainingQuantity")?.GetValue(item)!;
            var estimateProp = typeof(T).GetProperty("EstimateQuantity");

            if (isChecked)
            {
                estimateProp?.SetValue(item, remaining);
                if (!selectedList.Any(x => (int)typeof(T).GetProperty("ID")?.GetValue(x)! == id))
                    selectedList.Add(item);
            }
            else
            {
                selectedList.RemoveAll(x => (int)typeof(T).GetProperty("ID")?.GetValue(x)! == id);
            }

            coordinateDetailView.DataSource = null;
            coordinateDetailView.DataSource = selectedList;
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
                        HandleRowSelection<FabricCoordinationDto>(row, isChecked, _fabricSelected);
                        break;
                    case E_NPLType.PLDG:
                        HandleRowSelection<PLDGCoordinationDto>(row, isChecked, _pldgSelected);
                        break;
                    case E_NPLType.PLSP:
                        HandleRowSelection<PLSPCoordinationDto>(row, isChecked, _plspSelected);
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

            DialogResult result = ShowMessage.Success("Tạo đợt chuyển thành công!");
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
            if (e.KeyCode == Keys.Delete && coordinateDetailView.SelectedRows.Count > 0)
            {
                var bindingList = coordinateDetailView.DataSource as BindingList<FabricCoordinationDto>;
                if (bindingList == null) return;

                foreach (DataGridViewRow row in coordinateDetailView.SelectedRows)
                {
                    if (row.DataBoundItem is FabricCoordinationDto item)
                    {
                        bindingList.Remove(item);
                    }
                }
            }
        }
    }
}
