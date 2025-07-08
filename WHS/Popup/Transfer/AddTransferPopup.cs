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
using WHS.Service.Interface;
using WHS.Service.Services.Coordinate;

namespace WHS.Popup.Transfer
{
    public partial class AddTransferPopup : Form
    {
        private ITransferService _transferService;
        private IVehicleService _vehicleService;
        private AddTransferDetailPopup _popup = default!;
        private E_StatusPage _status = E_StatusPage.ADD;

        public TransferDto Transfer { get; set; } = new TransferDto();
        public VehicleDto Vehicle { get; set; } = new VehicleDto();
        public UserControl? CallerForm { get; set; } = default!;
        public EventHandler? SaveSucces;

        public AddTransferPopup(ITransferService transferService, IVehicleService vehicleService)
        {
            _transferService = transferService;
            _vehicleService = vehicleService;

            InitializeComponent();

        }

        #region Setup

        /// <summary>
        /// Sự kiện load form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddTransferPopup_Load(object sender, EventArgs e)
        {
            InítSetup();

            // Gán id mới nhất cho phiếu là là form thêm mới
            if (_status == E_StatusPage.ADD)
            {
                Response<int> res = await _transferService.GetNewId();

                if (!res.IsSuccess)
                {
                    ShowMessage.Error(res.Message);
                    return;
                }

                idTxb.Text = res.Data.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InítSetup()
        {
            idTxb.BackColor = Color.White;
            vehicleTypeTxb.BackColor = Color.White;
            vehicleModeTxb.BackColor = Color.White;
            licensePlateTxb.BackColor = Color.White;
            sealNumberTxb.BackColor = Color.White;
            capacityTxb.BackColor = Color.White;
        }

        /// <summary>
        /// Hàm phulic set value cho trạng thái edit
        /// </summary>
        public void InitEditMode()
        {
            _status = E_StatusPage.EDIT;

            idTxb.Text = Transfer.ID.ToString();
            createdDatePicker.Value = Transfer.CreatedAt;
            estimateExecDatePicker.Value = Transfer.PlanExecDate;
            execDatePicker.Value = Transfer.ExecDate;
            estimateWarehouseDatePicker.Value = Transfer.PlanWarehouseDate;
            warehouseDatePicker.Value = Transfer.WarehouseDate;

            vehicleIdTxb.Text = Vehicle.ID.ToString();
            vehicleModeTxb.Text = EnumHelper.GetEnumDescription(Vehicle.VehicleMode);
            vehicleTypeTxb.Text = EnumHelper.GetEnumDescription(Vehicle.VehicleType);
            licensePlateTxb.Text = Vehicle.LicensePlate;
            sealNumberTxb.Text = Vehicle.SealNumber;
            capacityTxb.Text = Vehicle.Capacity.ToString();
        }

        /// <summary>
        /// Invoke sự kiện save thành công cho form lắng nghe
        /// </summary>
        public void SaveSuccesCallback()
        {
            SaveSucces?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Action
        /// <summary>
        /// Sự kiện cancel form thêm mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (CallerForm != null) CallerForm.Enabled = true;
            this.Close();
        }

        /// <summary>
        /// Sự kiện close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTransferPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CallerForm != null) CallerForm.Enabled = true;
        }

        /// <summary>
        /// Sự kiện bấm vào nút next sang bước tiếp theo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (_popup == null || _popup.IsDisposed)
            {
                _popup = FormFactory.CreateForm<AddTransferDetailPopup>();
                _popup.CallerForm = this;
            }

            if (string.IsNullOrEmpty(vehicleIdTxb.Text))
            {
                ShowMessage.Warning("Vui lòng điền hoặc chọn id của phương tiện");
                return;
            }

            TransferDto transferData = new TransferDto()
            {
                ID = int.Parse(idTxb.Text),
                VehicleId = int.Parse(vehicleIdTxb.Text),
                CreatedAt = createdDatePicker.Value,
                PlanExecDate = estimateExecDatePicker.Value,
                ExecDate = execDatePicker.Value,
                PlanWarehouseDate = estimateWarehouseDatePicker.Value,
                WarehouseDate = warehouseDatePicker.Value,
                TransferStatus = null
            };

            this.Hide();

            _popup.Status = _status;
            _popup.TransferData = transferData;
            _popup.Show();
        }
        #endregion

        #region Input
        /// <summary>
        /// Update thời gian ngày thực hiện giống với ngày thực hiện dự kiến
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimateExecDatePicker_ValueChanged(object sender, EventArgs e)
        {
            execDatePicker.Value = estimateExecDatePicker.Value;
        }

        /// <summary>
        // Update thời gian về kho theo thời gian dự kiến về kho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimateWarehouseDatePicker_ValueChanged(object sender, EventArgs e)
        {
            warehouseDatePicker.Value = estimateWarehouseDatePicker.Value;
        }

        /// <summary>
        /// Sự kiện gõ id thì fill vào những trường input phương tiện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vehicleIdTxb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                handleIDVehicle();
            }
        }

        /// <summary>
        /// Sự kiện out focus id phương tiện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vehicleIdTxb_Leave(object sender, EventArgs e)
        {
            handleIDVehicle();
        }

        /// <summary>
        /// Xử lí sự kiện lấy id của phương tiện 
        /// </summary>
        private async void handleIDVehicle()
        {

            if (int.TryParse(vehicleIdTxb.Text, out int id))
            {
                Response<VehicleDto> res = await _vehicleService.GetVehicleByID(id);

                if (!res.IsSuccess)
                {
                    ShowMessage.Error(res.Message);
                    return;
                }

                if (res.Data != null) HandleVehicleSelected(res.Data);
            }
            else
            {
                ShowMessage.Error("ID phải là số nguyên");
            }
        }

        /// <summary>
        /// Sự kiện bấm thêm mở rộng để tìm id phương tiện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addIDBtn_Click(object sender, EventArgs e)
        {
            VehiclePopup vehiclePopup = FormFactory.CreateForm<VehiclePopup>();

            vehiclePopup.Show();
            vehiclePopup.OnVehicleSelected += HandleVehicleSelected;
        }

        /// <summary>
        /// Sự kiện chọn phương tiện từ form phương tiện
        /// </summary>
        /// <param name="vehicle"></param>
        private void HandleVehicleSelected(VehicleDto vehicle)
        {
            vehicleIdTxb.Text = vehicle.ID.ToString();
            vehicleModeTxb.Text = EnumHelper.GetEnumDescription(vehicle.VehicleMode);
            vehicleTypeTxb.Text = EnumHelper.GetEnumDescription(vehicle.VehicleType);
            licensePlateTxb.Text = vehicle.LicensePlate.ToString();
            sealNumberTxb.Text = vehicle.SealNumber.ToString();
            capacityTxb.Text = vehicle.Capacity.ToString();
        }

        #endregion
    }
}
