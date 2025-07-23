using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Dto.Receive;
using WHS.Core.Enums;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Service.Interface;
using WHS.Service.Services;

namespace WHS.Popup
{
    // Base form KHÔNG dùng Designer
    public class BaseTransaction : Form
    {
        protected GroupReceiveDto _receiveData = new GroupReceiveDto();

        protected Dictionary<string, string> _columns = new Dictionary<string, string>();
        protected DataTable _dataTable = new DataTable();

        public event EventHandler? SaveSuccess;
        protected DataGridView _gridView = default!;
        protected DataGridView _gridViewCoordinated = default!;
        protected ComboBox _statusCb = default!;
        protected ComboBox _dispatchStatusCb = default!;

        #region Setup
        public BaseTransaction()
        {

        }

        public void Initialize(GroupReceiveDto GroupReceiveDto)
        {
            _receiveData = GroupReceiveDto;
            InitUI();
        }

        /// <summary>
        /// Hàm InitUI, xử lí ở các popup con
        /// </summary>
        protected virtual void InitUI()
        {
        }

        /// <summary>
        /// Sự kiện raise lên khi lưu thành công
        /// </summary>
        protected void RaiseSaveSuccess()
        {
            SaveSuccess?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Setup combobox
        /// </summary>
        protected void SetupCombobox()
        {
            if (_statusCb == null || _dispatchStatusCb == null) return;

            var statusList = Enum.GetValues(typeof(E_TransferReceived))
                .Cast<E_TransferReceived>()
                .Select(e => new
                {
                    Value = (int)e,
                    Text = EnumHelper.GetEnumDescription(e)
                })
                .ToList();

            // Thêm dòng "Tất cả"
            statusList.Insert(0, new { Value = -1, Text = "Tất cả" });

            _statusCb.DataSource = statusList;
            _statusCb.DisplayMember = "Text";
            _statusCb.ValueMember = "Value";

            var dispatchList = Enum.GetValues(typeof(E_DispatchTransfer))
                .Cast<E_DispatchTransfer>()
                .Select(e => new
                {
                    Value = (int)e,
                    Text = EnumHelper.GetEnumDescription(e)
                })
                .ToList();

            // Thêm dòng "Tất cả"
            dispatchList.Insert(0, new { Value = -1, Text = "Tất cả" });

            _dispatchStatusCb.DataSource = dispatchList;
            _dispatchStatusCb.DisplayMember = "Text";
            _dispatchStatusCb.ValueMember = "Value";
        }

        /// <summary>
        /// Setup gridView 
        /// </summary>
        protected void SetupGridView()
        {
            if (_gridView == null) return;

            _gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _gridView.AutoGenerateColumns = false;

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, _gridView, new object[] { true });

            foreach (var col in _columns)
            {
                var gridCol = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = col.Key,
                    HeaderText = col.Value,
                    MinimumWidth = 150,
                    FillWeight = 1,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                };
                _gridView.Columns.Add(gridCol);
            }

            _statusCb.SelectedIndexChanged += ComboBox_SelectedIndexChanged!;
            _dispatchStatusCb.SelectedIndexChanged += ComboBox_SelectedIndexChanged!;
        }

        /// <summary>
        /// Update dữ liệu khi thay đổi combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitGridView();
        }

        /// <summary>
        /// Fill bảng dataGridView
        /// </summary>
        protected virtual void InitGridView()
        {
        }
        #endregion
    }
}
