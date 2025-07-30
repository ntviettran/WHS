using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Enums
{
    public enum E_StatusForm
    {
        [Description("Trạng thái xem")]
        VIEW = 0,

        [Description("Trạng thái thêm mới")]
        ADD = 1,

        [Description("Trạng thái chỉnh sửa")]
        EDIT = 2
    }
}
