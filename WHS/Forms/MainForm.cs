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
using WHS.Pages.Receive;
using WHS.Pages.Transfer;

namespace WHS.Forms
{
    public partial class MainForm : Form
    {
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
            receiveSubMenu.Visible = false;
            coordinateSubMenu.Visible = false;
        }

        /// <summary>
        /// Set lại màu mặc định cho các button trong parent
        /// </summary>
        /// <param name="parent"></param>
        private void SetBgButtons(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button btn)
                {
                    if (!btn.Name.Contains("Toggle"))
                    {
                        btn.BackColor = Color.FromArgb(35, 32, 39);
                    }
                }
                else if (control.HasChildren)
                {
                    // Nếu control là panel con (hoặc có children), duyệt tiếp
                    SetBgButtons(control);
                }
            }
        }

        /// <summary>
        /// Set màu cho active button
        /// </summary>
        /// <param name="button"></param>
        private void ActiveButton(Button button)
        {
            SetBgButtons(sidebar);
            button.BackColor = Color.FromArgb(49, 50, 51);
        }

        /// <summary>
        /// Đóng tất cả subMenu
        /// </summary>
        private void HideSubMenu()
        {
            if (receiveSubMenu.Visible == true)
            {
                receiveSubMenu.Visible = false;
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
        private void ShowUserControl(UserControl newControl)
        {
            if (mainLayout == null) return;
            if (_currentControl != null && _currentControl.GetType() == newControl.GetType()) return;

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
        private void receiveToggleBtn_Click(object sender, EventArgs e)
        {
            ShowSubMenu(receiveSubMenu);
        }


        /// <summary>
        /// Sự kiện bấm chọn "Chi tiết NPL"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detailReceiveBtn_Click(object sender, EventArgs e)
        {
            if (Program.ServiceProvider == null) return;
            ActiveButton(detailReceiveBtn);

            UserControl detailReceive = Program.ServiceProvider.GetRequiredService<DetailReceive>();
            ShowUserControl(detailReceive);
        }

        /// <summary>
        /// Sự kiện bấm vào button toggle "Điều phối"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coordinateToggleBtn_Click(object sender, EventArgs e)
        {
            ShowSubMenu(coordinateSubMenu);
        }

        /// <summary>
        /// Sự kiện bấm vào button "Chuyển NPL"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void transferNPLBtn_Click(object sender, EventArgs e)
        {
            if (Program.ServiceProvider == null) return;
            ActiveButton(transferNPLBtn);

            UserControl transferNPLPage = Program.ServiceProvider.GetRequiredService<TransferNPLPage>();
            ShowUserControl(transferNPLPage);
        }
    }
}
