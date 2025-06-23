using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Enums
{
    public enum E_NPLType
    {
        [Description("Vải")]
        FABRIC = 0,

        [Description("Phụ liệu sản phẩm")]
        PLSP = 1,

        [Description("Phụ liệu đóng gói")]
        PLDG = 2
    }
}
