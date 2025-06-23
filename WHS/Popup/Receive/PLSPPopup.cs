using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.PLSP;
using WHS.Core.Response;
using WHS.Service.Interface;

namespace WHS.Popup
{
    public partial class PLSPPopup : BasePopup
    {
        public PLSPPopup(IReceiveService<PlspDto, FabricDetailDto> receiveService)
        {

            InitializeComponent();

            _receiveService = receiveService;
            _columns = new Dictionary<string, string>()
            {
                {"plsp_type", "Loại phụ liệu"},
                {"plsp_code", "Mã phụ liệu"},
                {"npl_color", "Màu"},
                {"market_code", "Mã thị trường"},
                {"size", "Kích thước"},
                {"plsp_color", "Màu sản phẩm"}
            };

            _gridView = this.gridView;
            _sampleBtn = this.sampleFileBtn;
            _addBtn = this.addBtn;
            _cancelBtn = this.cancelBtn;

            SetupGridView();
            RegisterSampleButtonEvent(name: "plsp");
            RegisterAddButtonEvent();
            RegisterCancelButtonEvent();
            RegisterDeleteDetailEvent();
        }
    }
}
