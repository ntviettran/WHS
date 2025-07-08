using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Dto.Transfer;
using WHS.Core.Dto.Vehicle;
using WHS.Core.Enums;
using WHS.Core.Factory;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Factory;
using WHS.Service.Interface;

namespace WHS.Popup.Transfer
{
    public partial class TransferDetail : Form
    {
        private ITransferService _transferService;
        private IVehicleService _vehicleService;
        private E_NPLType _type = E_NPLType.FABRIC;
        private VehicleDto _vehicle = new VehicleDto();
        private Dictionary<string, string> _columns = new Dictionary<string, string>();

        public TransferDto Transfer { get; set; } = new TransferDto();

        public TransferDetail(IVehicleService vehicleService)
        {
            _transferService = TransferFactory.GetService(_type);
            _vehicleService = vehicleService;

            InitializeComponent();
        }

        public void InitUI()
        {
            estimateWarehouseLabel.Text = Transfer.PlanWarehouseDateVN;
            warehouseLabel.Text = Transfer.WarehouseDateVN;
            estimateExecLabel.Text = Transfer.PlanExecDateVN;
            execLabel.Text = Transfer.ExecDateVN;
            execStatusLabel.Text = Transfer.ExecStatusDescription;
            transferStatusLabel.Text = Transfer.TransferStatusDescription;
            vehicleIdLabel.Text = Transfer.VehicleId.ToString();

            UpdateVehicleInformation();
            GetFabicDetail();
        }

        public async void UpdateVehicleInformation()
        {
            Response<VehicleDto> res = await _vehicleService.GetVehicleByID(Transfer.VehicleId);
            if (res.IsSuccess && res.Data != null)
            {
                _vehicle = res.Data;
                vehicleTypeLabel.Text = EnumHelper.GetEnumDescription(res.Data.VehicleType);
                vehicleModeLabel.Text = EnumHelper.GetEnumDescription(res.Data.VehicleMode);
                licensePlateLabel.Text = res.Data.LicensePlate;
            }
        }

        /// <summary>
        /// Vẽ lại các cột của gridView
        /// </summary>
        private void SetColumnGridView()
        {
            gridView.DataSource = null;
            gridView.AutoGenerateColumns = false;
            gridView.Columns.Clear();

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
                    ReadOnly = true
                });
            }
        }

        /// <summary>
        /// Khởi tạo giá trị cho bảng cần điều phối
        /// </summary>
        private async Task GetDataTransfer()
        {
            int transferId = Transfer.ID;

            switch (_type)
            {
                case E_NPLType.FABRIC:
                    if (_transferService is ITransferService<FabricCoordinationDto, FabricTransferDetailDto> fabricService)
                    {
                        Response<List<FabricTransferDetailDto>> res = await fabricService.GetTransferDetail(transferId);
                        FillDetailTable<FabricTransferDetailDto>(res);
                    }
                    break;
                case E_NPLType.PLSP:
                    if (_transferService is ITransferService<PLSPCoordinationDto, PLSPTransferDetailDto> plspService)
                    {
                        Response<List<PLSPTransferDetailDto>> res = await plspService.GetTransferDetail(transferId);
                        FillDetailTable<PLSPTransferDetailDto>(res);
                    }
                    break;
                case E_NPLType.PLDG:
                    if (_transferService is ITransferService<PLDGCoordinationDto, PLDGTransferDetailDto> pldgService)
                    {
                        Response<List<PLDGTransferDetailDto>> res = await pldgService.GetTransferDetail(transferId);
                        FillDetailTable<PLDGTransferDetailDto>(res);
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
        private void FillDetailTable<T>(Response<List<T>> res)
        {
            if (!res.IsSuccess)
            {
                ShowMessage.Error(res.Message);
                return;
            }

            gridView.DataSource = res.Data;
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
        /// Get fabric detail
        /// </summary>
        public async void GetFabicDetail()
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
                {"EstimateQuantity", "Số lượng dự kiến nhận"},
                {"QuantityReceived", "Số lượng thực nhận"},
                {"QuantityStatusDescription", "Trạng thái số lượng"},
                {"LengthReceived", "Chiều dài thực nhận"},
                {"LengthStatusDescription", "Trạng thái chiều dài"},
                {"WeightReceived", "Khối lượng thực nhận"},
                {"WeightStatusDescription", "Trạng thái khối lượng"}
            };

            SetColumnGridView();
            await GetDataTransfer();
        }

        /// <summary>
        /// Get Plsp detail
        /// </summary>
        private async void GetPlspDetail()
        {
            _type = E_NPLType.PLSP;
            ActiveTypeBtn(plspBtn);

            _columns = new Dictionary<string, string>
            {
                {"ID", "ID"},
                {"IdNplReceived", "ID NPL nhận"},
                {"MO", "MO"},
                {"PlspType", "Loại phụ liệu"},
                {"MarketCode", "Mã thị trường"},
                {"PlspCode", "Mã code"},
                {"NplColor", "Màu"},
                {"Size", "Kích cỡ" },
                {"PlspColor", "Màu sắc sản phẩm"},
                {"EstimateQuantity", "Số lượng dự kiến nhận"},
                {"QuantityReceived", "Số lượng thực nhận"},
                {"QuantityStatusDescription", "Trạng thái số lượng"}
            };
            SetColumnGridView();
            await GetDataTransfer();
        }

        /// <summary>
        /// Get Pldg detail
        /// </summary>
        private async void GetPldgDetail()
        {
            _type = E_NPLType.PLDG;
            ActiveTypeBtn(pldgBtn);

            _columns = new Dictionary<string, string>
            {
                {"ID", "ID"},
                {"IdNplReceived", "ID NPL nhận"},
                {"MO", "MO"},
                {"PldgType", "Loại phụ liệu"},
                {"PackCode", "Mã thùng"},
                {"PoCode", "Mã PO"},
                {"NetWeight", "N.W"},
                {"GrossWeight", "G.W"},
                {"Color", "Màu"},
                {"PldgSize", "Kích thước"},
                {"EstimateQuantity", "Số lượng dự kiến nhận"},
                {"QuantityReceived", "Số lượng thực nhận"},
                {"QuantityStatusDescription", "Trạng thái số lượng"}
            };
            SetColumnGridView();
            await GetDataTransfer();
        }

        /// <summary>
        /// Sự kiện click button vải
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fabricBtn_Click(object sender, EventArgs e)
        {
            GetFabicDetail();
        }

        /// <summary>
        /// Sự kiện click button plsp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plspBtn_Click(object sender, EventArgs e)
        {
            GetPlspDetail();
        }

        /// <summary>
        /// Sự kiện click button pldg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pldgBtn_Click(object sender, EventArgs e)
        {
            GetPldgDetail();
        }

        /// <summary>
        /// Sự kiện edit transfer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editBtn_Click(object sender, EventArgs e)
        {
            AddTransferPopup transferPopup = FormFactory.CreateForm<AddTransferPopup>();

            transferPopup.Transfer = Transfer;
            transferPopup.Vehicle = _vehicle;
            transferPopup.InitEditMode();

            transferPopup.SaveSucces += (sender, e) =>
            {
                InitUI();
            };

            transferPopup.Show();
        }
    }
}
