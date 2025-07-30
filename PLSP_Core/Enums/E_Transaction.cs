using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLSP.Core.Enums
{
    public enum E_Transaction
    {
        [Description("Xuất")]
        EXPORT = 0,

        [Description("Nhập")]
        IMPORT = 1
    }
}
