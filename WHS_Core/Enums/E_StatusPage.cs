using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Enums
{
    public enum E_StatusPage
    {
        [Description("Xem")]
        VIEW = 0,

        [Description("Thêm")]
        ADD = 1,

        [Description("Sửa")]
        EDIT = 2
    }
}
