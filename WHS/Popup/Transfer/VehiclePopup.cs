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
using WHS.Core.Factory;
using WHS.Core.Query.Vehicle;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Service.Interface;
using WHS.Service.Services.Coordinate;
using WHS.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static OfficeOpenXml.ExcelErrorValue;

namespace WHS.Popup.Transfer
{
    public partial class VehiclePopup : Form
    {
        public event Action<VehicleDto>? OnVehicleSelected;

        private IVehicleService _vehicleService;

        public VehiclePopup(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;

            InitializeComponent();
            InitSetup();
        }

        /// <summary>
        /// Init Setup ban đầu
        /// </summary>
        private void InitSetup()
        {
            var vehicleModes = Enum.GetValues(typeof(E_VehicleMode))
                .Cast<E_VehicleMode>()
                .Select(e => new
                {
                    Text = EnumHelper.GetEnumDescription(e),
                    Value = (int)e
                })
                .ToList();

            // Thêm "Tất cả" vào đầu danh sách
            vehicleModes.Insert(0, new
            {
                Text = "Tất cả",
                Value = -1
            });

            vehicleModeCb.DataSource = vehicleModes;
            vehicleModeCb.DisplayMember = "Text";
            vehicleModeCb.ValueMember = "Value";
            vehicleModeCb.SelectedValue = -1;
        }


        /// <summary>
        /// Sự kiện khi load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void VehiclePopup_Load(object sender, EventArgs e)
        {
            GridViewUtils.SetBuffer(gridView);
            await GetDataGridView();
        }

        /// <summary>
        /// Load dữ liệu phương tiện và fill và DataGridView
        /// </summary>
        private async Task GetDataGridView()
        {
            // Khởi tạo search
            VehicleSearch vehicleSearch = new VehicleSearch()
            {
                VehicleMode = (int)vehicleModeCb.SelectedValue!,
                LincensePlate = licensePlateTxb.Text
            };

            // Gọi service get dữ liệu
            Response<List<VehicleDto>> res = await _vehicleService.GetVehicles(vehicleSearch);

            // Handle data trả về
            if (!res.IsSuccess)
            {
                ShowMessage.Error(res.Message);
                return;
            }

            var viewList = res.Data!.Select(x => new
            {
                x.ID,
                VehicleMode = EnumHelper.GetEnumDescription(x.VehicleMode),
                VehicleType = EnumHelper.GetEnumDescription(x.VehicleType),
                x.LicensePlate,
                x.SealNumber,
                x.Capacity
            }).ToList();

            gridView.DataSource = viewList;
        }

        /// <summary>
        /// Sự kiện chọn hình thức tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void vehicleModeCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            await GetDataGridView();
        }

        /// <summary>
        /// Sự kiện khi bấm enter textbox thì search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void licensePlateTxb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await GetDataGridView();
            }
        }

        /// <summary>
        /// Sự kiện bấm nút cancel thì đóng form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Sự kiện bấm nút thêm mới phương tiện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            AddVehiclePopup vehiclePopup = FormFactory.CreateForm<AddVehiclePopup>();

            vehiclePopup.SaveSuccess += async (sender, e) =>
            {
                await GetDataGridView();
            };

            vehiclePopup.ShowDialog();
        }

        /// <summary>
        /// Bám xác nhận chọn phương tiện 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBtn_Click(object sender, EventArgs e)
        {
            var row = gridView.CurrentRow;

            VehicleDto vehicle = new VehicleDto()
            {
                ID = int.Parse(row.Cells["ID"].Value.ToString()!),
                VehicleMode = EnumHelper.GetEnumByDescription<E_VehicleMode>(row.Cells["VehicleMode"].Value.ToString()!),
                VehicleType = EnumHelper.GetEnumByDescription<E_VehicleType>(row.Cells["VehicleType"].Value.ToString()!),
                LicensePlate = row.Cells["LicensePlate"].Value.ToString()!,
                SealNumber = row.Cells["SealNumber"].Value.ToString()!,
                Capacity = float.Parse(row.Cells["Capacity"].Value.ToString()!)
            };

            OnVehicleSelected?.Invoke(vehicle);
            this.Close();
        }
    }
}
