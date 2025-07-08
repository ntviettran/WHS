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
        private IVehicleService _transferService;
        public event EventHandler? SaveSuccess;

        public AddVehiclePopup(IVehicleService transferService)
        {
            _transferService = transferService;

            InitializeComponent();
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
        private async void AddVehiclePopup_Load(object sender, EventArgs e)
        {
            Response<int> res = await _transferService.GetNewVehicleIdAsync();

            if (!res.IsSuccess)
            {
                ShowMessage.Error(res.Message);
                return;
            } 

            idTxb.BackColor = Color.White;  
            idTxb.Text = res.Data.ToString();

            SetupCombobox();
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
                SealNumber = sealNumberTxb.Text,
                Capacity = float.Parse(capacityTxb.Text)
            };

            Response<int> res = await _transferService.CreateVehicleAsync(vehicle);

            // Kiểm tra xem dữ liệu trả về và đưa ra thông báo
            if (!res.IsSuccess) ShowMessage.Error(res.Message);

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

            if (string.IsNullOrWhiteSpace(sealNumberTxb.Text))
            {
                errors.Add("Số chì không được để trống.");
            }

            if (!float.TryParse(capacityTxb.Text, out float capacity))
            {
                errors.Add("Tải trọng phải là dạng số.");
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
