using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Enums
{
    public enum E_TransferReceived
    {
        [Description("Chờ nhận")]
        PENDING = 0,

        [Description("Đang nhận")]
        DOING = 1,

        [Description("Đã nhận")]
        DONE = 2,

        [Description("Đã hủy")]
        CANCEL = 3
    }
}
