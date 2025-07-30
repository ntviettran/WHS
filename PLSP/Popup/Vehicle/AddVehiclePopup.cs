using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Dto.Vehicle;
using WHS.Core.Enums;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Service.Interface;
using WHS.Service.Services.Coordinate;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WHS.Popup.Transfer
{
    public partial class AddVehiclePopup : Form
    {
        private IVehicleService _vehicleService;
        private E_StatusForm _status = E_StatusForm.ADD;
        public event EventHandler? SaveSuccess;


        public AddVehiclePopup(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;

            InitializeComponent();
            SetupCombobox();
        }

        public void SetupEdit(VehicleDto vehicle)
        {
            _status = E_StatusForm.EDIT;
            idTxb.Text = vehicle.ID.ToString();
            licensePlateTxb.Text = vehicle.LicensePlate;
            sealNumberTxb.Text = vehicle.SealNumber ?? string.Empty;
            capacityTxb.Text = vehicle.Capacity?.ToString() ?? string.Empty;
            vehicleModeCb.SelectedValue = vehicle.VehicleMode;
            vehicleTypeCb.SelectedValue = vehicle.VehicleType;
        }

        private async void SetupAdd()
        {
            Response<int> res = await _vehicleService.GetNewVehicleIdAsync();

            if (!res.IsSuccess)
            {
                ShowMessage.Error(res.Message);
                return;
            }

            idTxb.BackColor = Color.White;
            idTxb.Text = res.Data.ToString();
        }

        private void SetupCombobox()
        {
            var vehicleModes = Enum.GetValues(typeof(E_VehicleMode))
                       .Cast<E_VehicleMode>()
                       .Select(e => new
                       {
                           Text = EnumHelper.GetEnumDescription(e),
                           Value = e
                       })
                        .ToList();

            vehicleModeCb.DataSource = vehicleModes;
            vehicleModeCb.DisplayMember = "Text";
            vehicleModeCb.ValueMember = "Value";
            vehicleModeCb.SelectedValue = E_VehicleMode.INTERNAL;

            var vehicleTypes = Enum.GetValues(typeof(E_VehicleType))
                               .Cast<E_VehicleType>()
                               .Select(e => new
                               {
                                   Text = EnumHelper.GetEnumDescription(e),
                                   Value = e
                               })
                                .ToList();

            vehicleTypeCb.DataSource = vehicleTypes;
            vehicleTypeCb.DisplayMember = "Text";
            vehicleTypeCb.ValueMember = "Value";
            vehicleTypeCb.SelectedValue = E_VehicleType.CONTAINER;
        }

        /// <summary>
        /// Sự kiện load form thì lấy ra id mới nhất để khởi tạo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddVehiclePopup_Load(object sender, EventArgs e)
        {
            if (_status == E_StatusForm.ADD)
            {
                SetupAdd();
            }
        }

        /// <summary>
        /// Sự kiện cancel form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Sư kiện lưu thông tin phương tiện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void nextBtn_Click(object sender, EventArgs e)
        {
            bool validated = ValidateInformation();
            if (!validated) return;

            // Gọi service thêm mới 
            VehicleDto vehicle = new VehicleDto()
            {
                ID = int.Parse(idTxb.Text),
                VehicleMode = (E_VehicleMode)vehicleModeCb.SelectedValue!,
                VehicleType = (E_VehicleType)vehicleTypeCb.SelectedValue!,
                LicensePlate = licensePlateTxb.Text,
                SealNumber = !string.IsNullOrEmpty(sealNumberTxb.Text) ? sealNumberTxb.Text : null,
                Capacity = !string.IsNullOrEmpty(capacityTxb.Text) ? float.Parse(capacityTxb.Text) : null
            };

            Response<int> res = null!;
            if (_status == E_StatusForm.EDIT)
            {
                res = await _vehicleService.UpdateVehicleAsync(vehicle);
            } else
            {
                res = await _vehicleService.CreateVehicleAsync(vehicle);
            }

            // Kiểm tra xem dữ liệu trả về và đưa ra thông báo
            if (!res.IsSuccess)
            {
                ShowMessage.Error(res.Message);
                return;
            }

            DialogResult result = ShowMessage.Success(res.Message);

            if (result == DialogResult.OK)
            {
                SaveSuccess?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }

        /// <summary>
        /// Validate thông tin phương tiện
        /// </summary>
        /// <returns></returns>
        private bool ValidateInformation()
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(licensePlateTxb.Text))
            {
                errors.Add("Biển số không được để trống.");
            }

            if (errors.Count > 0)
            {
                ShowMessage.Warning(string.Join(Environment.NewLine, errors));
                return false;
            }

            return true;
        }
    }
}
