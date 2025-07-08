using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Enums
{
    public enum E_QuantityStatus
    {
        [Description("Đang xác nhận")]
        PENDING = 0,

        [Description("Đủ")]
        SUFFICIENT = 1,

        [Description("Thừa")]
        EXCESS = 2,

        [Description("Thiếu")]
        LACKING = 3
    }
}
