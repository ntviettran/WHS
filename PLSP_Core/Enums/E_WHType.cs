using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLSP.Core.Enums
{
    public enum E_WHType
    {
        [Description("PPC")]
        PPC = 0,

        [Description("Kho tổng")]
        WAREHOUSE = 1,

        [Description("Block")]
        BLOCK = 2,

        [Description("Công nhân")]
        WORKER = 3
    }
}
