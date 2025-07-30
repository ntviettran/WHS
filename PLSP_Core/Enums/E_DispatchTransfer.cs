using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Enums
{
    public enum E_DispatchTransfer
    {
        [Description("Cần điều phối")]
        PENDING = 0,

        [Description("Đã điều phối")]
        DONE = 1
    }
}
