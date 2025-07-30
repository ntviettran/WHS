using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Enums
{
    public enum E_TransferStatus
    {
        [Description("Thành công")]
        SUCCESS = 0,

        [Description("Thất bại")]
        FAIL = 1
    }
}
