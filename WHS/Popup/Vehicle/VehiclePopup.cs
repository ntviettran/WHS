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
            gridView.AutoGenerateColumns = false;
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

            gridView.DataSource = res.Data;
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
            if (gridView.CurrentRow?.DataBoundItem is VehicleDto vehicle)
            {
                OnVehicleSelected?.Invoke(vehicle);
                this.Close();
            }
            else
            {
                ShowMessage.Error("Vui lòng chọn phương tiện");
            }
        }
        /// <summary>
        /// Edit phương tiện hiện tại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editVehicleContext_Click(object sender, EventArgs e)
        {
            if (gridView.CurrentRow?.DataBoundItem is VehicleDto vehicle)
            {
                AddVehiclePopup vehiclePopup = FormFactory.CreateForm<AddVehiclePopup>();
                vehiclePopup.SetupEdit(vehicle);

                vehiclePopup.SaveSuccess += async (sender, e) =>
                {
                    await GetDataGridView();
                };

                vehiclePopup.ShowDialog();
            }
            else
            {
                ShowMessage.Error("Vui lòng chọn phương tiện cần chỉnh sửa");
            }
        }
    }
}
