using PLSP.Core.Dto.Location;
using PLSP.Core.Dto.PLSP;
using PLSP.Core.Enums;
using PLSP.Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Factory;

namespace PLSP.Popup.Inventory
{
    public partial class DetailInventoryPopup : Form
    {
        private PlspInventoryDto _plsp;

        public DetailInventoryPopup(PlspInventoryDto plsp)
        {
            _plsp = plsp;
            InitializeComponent();
        }

        private void DetailInventoryPopup_Load(object sender, EventArgs e)
        {
            InitUI();
        }

        private async void InitUI()
        {
            IdLabel.Text = _plsp.ID.ToString();
            moLabel.Text = _plsp.MO;
            inventoryQuantityLabel.Text = _plsp.InventoryQuantity.ToString();
            plspCodeLabel.Text = _plsp.PlspCode;
            plspTypeLabel.Text = _plsp.PlspType;
            colorLabel.Text = _plsp.NplColor;

            IInventoryService<PlspInventoryDto, PlspInventoryLocationDto> locationService = ServiceFactory.GetInventoryService<PlspInventoryDto, PlspInventoryLocationDto>();

            Response<List<QuantityPerLocation>> response = await locationService.GetQuantityPerLocation(_plsp.ID);

            if (!response.IsSuccess)
            {
                ShowMessage.Error(response.Message);
                return;
            }

            int quantity = response.Data!.Sum(x => x.Quantity);
            moveQuantityLabel.Text = quantity.ToString();

            SetupLocationGridView();
            locationGridView.DataSource = response.Data;
            locationGridView.ClearSelection();
        }

        /// <summary>
        /// Vẽ lại các cột của gridView
        /// </summary>
        private void SetupLocationGridView()
        {
            locationGridView.AutoGenerateColumns = false;
            locationGridView.DataSource = null;

            Dictionary<string, string> columns = new Dictionary<string, string>
            {
                ["Location"] = "Vị trí",
                ["Quantity"] = "Số lượng"
            }; ;

            locationGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (var column in columns)
            {
                locationGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = column.Key,
                    HeaderText = column.Value,
                    DataPropertyName = column.Key
                });
            }
        }
    }
}
