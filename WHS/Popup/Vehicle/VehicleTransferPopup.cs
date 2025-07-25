using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Components;
using WHS.Core.Dto;
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.PLDG;
using WHS.Core.Dto.PLSP;
using WHS.Core.Dto.Receive;
using WHS.Core.Dto.Vehicle;
using WHS.Core.Enums;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Factory;
using WHS.Service.Interface;

namespace WHS.Popup.Vehicle
{
    public partial class VehicleTransferPopup : Form
    {
        private IVehicleService _vehiceService;

        public E_NPLType Type { get; set; }
        public int ID { get; set; }

        public VehicleTransferPopup(IVehicleService vehicleService)
        {
            _vehiceService = vehicleService;
            InitializeComponent();
        }

        /// <summary>
        /// Load dữ liệu
        /// </summary>
        /// <returns></returns>
        private async Task LoadDataGridView()
        {
            // Call service
            Response<List<TransferDetailVehicle>> res = await _vehiceService.GetVehicleTransferDetail(Type, ID);

            if (!res.IsSuccess)
            {
                ShowMessage.Error(res.Message);
                return;
            }

            if (res.Data != null && res.Data != null)
            {
                gridView.AutoGenerateColumns = false;
                gridView.DataSource = res.Data;
                gridView.ClearSelection();
            }
        }

        /// <summary>
        /// Sự kiện load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void VehicleTransferPopup_Load(object sender, EventArgs e)
        {
            await LoadDataGridView();
        }
    }
}
