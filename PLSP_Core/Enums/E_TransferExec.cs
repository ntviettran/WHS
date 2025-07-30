using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Enums
{
    public enum E_TransferExec
    {
        [Description("Chờ thực hiện")]
        PENDING = 0,

        [Description("Đang thực hiện")]
        DOING = 1,

        [Description("Đã thực hiện")]
        DONE = 2,

        [Description("Đã hủy")]
        CANCEL = 3
    }
}
