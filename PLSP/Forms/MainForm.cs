using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using PLSP.Core.Enums;
using PLSP.Pages;
using PLSP.Pages.Warehouse;
using WHS.Core.Factory;
using WHS.Core.Session;
using WHS.Pages;
using WHS.Pages.Receive;
using WHS.Pages.Transfer;

namespace WHS.Forms
{
    public partial class MainForm : Form
    {
        public bool IsLogout { get; set; } = false;

        private UserControl? _currentControl;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            deliverySubMenu.Visible = false;
            poToggleBtn.Visible = false;
            transferWarhouseSubMenu.Visible = false;
            warehouseSubmenu.Visible = false;
            poToggleBtn.Visible = false;
            workderToggleBtn.Visible = false;

            E_WHType type = Session.CurrentUser.GetCurrentType();

            if (type == E_WHType.PPC)
            {
                transferToggleBtn.Visible = false;
                inventoryToggleBtn.Visible = false;
            }

            if (type == E_WHType.WAREHOUSE)
            {
                deliveryToggleBtn.Visible = false;
            }

            if (type == E_WHType.BLOCK)
            {
                deliveryToggleBtn.Visible = false;
                transferToggleBtn.Visible = false;
                workderToggleBtn.Visible = true;
            }
        }

        /// <summary>
        /// Set lại màu mặc định cho các button trong parent
        /// </summary>
        /// <param name="parent"></param>
        private void SetBgButtons(Control parent, string nameToggle)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button btn)
                {
                    if (!btn.Name.Contains("Toggle"))
                    {
                        btn.BackColor = Color.FromArgb(35, 32, 39);
                    }
                    else
                    {
                        btn.BackColor = Color.Black;
                    }

                    if (btn.Name == nameToggle)
                    {
                        btn.BackColor = Color.FromArgb(0, 46, 92);
                    }
                }
                else if (control.HasChildren)
                {
                    // Nếu control là panel con (hoặc có children), duyệt tiếp
                    SetBgButtons(control, nameToggle);
                }
            }
        }

        /// <summary>
        /// Set màu cho active button
        /// </summary>
        /// <param name="button"></param>
        private void ActiveButton(string nameToggle, Button? button)
        {
            SetBgButtons(sidebar, nameToggle);

            if (button == null) return;
            button.BackColor = Color.FromArgb(49, 50, 51);
        }

        /// <summary>
        /// Đóng tất cả subMenu
        /// </summary>
        private void HideSubMenu()
        {
            if (deliverySubMenu.Visible == true)
            {
                deliverySubMenu.Visible = false;
            }
            if (transferWarhouseSubMenu.Visible == true)
            {
                transferWarhouseSubMenu.Visible = false;
            }
        }

        /// <summary>
        /// Hiện submenu được truyền vào
        /// </summary>
        /// <param name="subMenu"></param>
        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        /// <summary>
        /// Xử lý show các user control của màn
        /// </summary>
        /// <param name="newControl"></param>
        public void ShowUserControl(UserControl newControl)
        {
            if (mainLayout == null) return;

            // Nếu có màn nào đang chạy thì clear 
            if (_currentControl != null)
            {
                mainLayout.Controls.Clear();
            }

            // Add user control và hiển thị
            _currentControl = newControl;

            mainLayout.Controls.Add(_currentControl);
            _currentControl.Dock = DockStyle.Fill;

            _currentControl.BringToFront();
        }

        /// <summary>
        /// Sự kiện nhấn vào button toggle "NPL cần nhận"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deliveryToggleBtn_Click(object sender, EventArgs e)
        {
            deliveryToggleBtn.BackColor = Color.FromArgb(0, 46, 92);
            SetBgButtons(sidebar, "deliveryToggleBtn");
            ShowSubMenu(deliverySubMenu);
        }

        /// <summary>
        /// Sự kiện bấm chọn "Chi tiết NPL"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detailReceiveBtn_Click(object sender, EventArgs e)
        {
            ActiveButton("deliveryToggleBtn", detailReceiveBtn);

            GroupDetailReceive detailReceive = FormFactory.CreateUserControl<GroupDetailReceive>();
            detailReceive.Mainform = this;
            ShowUserControl(detailReceive);
        }

        /// <summary>
        /// Sự kiện bấm vào button "Chuyển NPL"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coordinateBtn_Click(object sender, EventArgs e)
        {
            ActiveButton("deliveryToggleBtn", coordinateBtn);

            CoordinateNPLPage transferNPLPage = FormFactory.CreateUserControl<CoordinateNPLPage>();
            ShowUserControl(transferNPLPage);
        }

        /// <summary>
        /// Sự kiện click button toggle "Đợt chuyển"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void transferToggleBtn_Click(object sender, EventArgs e)
        {
            transferToggleBtn.BackColor = Color.FromArgb(0, 46, 92);
            SetBgButtons(sidebar, "transferToggleBtn");
            ShowSubMenu(transferWarhouseSubMenu);
        }

        /// <summary>
        /// Sự kiện click button "Quản lý đợt chuyển"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coordinateManage_Click(object sender, EventArgs e)
        {
            ActiveButton("transferToggleBtn", coordinateManage);

            CoordinateNPLPage transferNPLPage = FormFactory.CreateUserControl<CoordinateNPLPage>();
            transferNPLPage.InitWarehouseManager();
            ShowUserControl(transferNPLPage);
        }

        /// <summary>
        /// Mở quản lý po
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void poToggleBtn_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            SetBgButtons(sidebar, "poToggleBtn");

            POPage poPage = FormFactory.CreateUserControl<POPage>();
            ShowUserControl(poPage);
        }

        private void inventoryToggleBtn_Click(object sender, EventArgs e)
        {
            inventoryToggleBtn.BackColor = Color.FromArgb(0, 46, 92);
            SetBgButtons(sidebar, "inventoryToggleBtn");
            ShowSubMenu(warehouseSubmenu);
        }

        private void warehouseInventoryBtn_Click(object sender, EventArgs e)
        {
            ActiveButton("inventoryToggleBtn", warehouseInventoryBtn);

            TotalInventoryPage totalInventoryPage = FormFactory.CreateUserControl<TotalInventoryPage>();
            totalInventoryPage.Mainform = this;
            ShowUserControl(totalInventoryPage);
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            IsLogout = true;
            this.Close();
        }

        private void qrCodeBtn_Click(object sender, EventArgs e)
        {
            ActiveButton("inventoryToggleBtn", qrCodeBtn);

            QRInventoryPage qRInventoryPage = FormFactory.CreateUserControl<QRInventoryPage>();
            ShowUserControl(qRInventoryPage);
        }

        private void qrLocation_Click(object sender, EventArgs e)
        {
            ActiveButton("inventoryToggleBtn", qrLocationBtn);

            QRLocation qrLocation = FormFactory.CreateUserControl<QRLocation>();
            ShowUserControl(qrLocation);
        }

        private void exportWhBtn_Click(object sender, EventArgs e)
        {
            ActiveButton("inventoryToggleBtn", exportWhBtn);

            ExportInventoryPage exportInventoryPage = FormFactory.CreateUserControl<ExportInventoryPage>();
            ShowUserControl(exportInventoryPage);
        }

        private void historyTransactionBtn_Click(object sender, EventArgs e)
        {
            ActiveButton("inventoryToggleBtn", historyTransactionBtn);

            HistoryTransactionPage historyTransactionPage = FormFactory.CreateUserControl<HistoryTransactionPage>();
            ShowUserControl(historyTransactionPage);
        }

        private void workderToggleBtn_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            SetBgButtons(sidebar, "workderToggleBtn");

            WorkerPage workerPage = FormFactory.CreateUserControl<WorkerPage>();
            ShowUserControl(workerPage);
        }
    }
}
