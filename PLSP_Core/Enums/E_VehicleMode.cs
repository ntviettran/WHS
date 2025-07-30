using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Enums
{
    public enum E_VehicleMode
    {
        [Description("Nội bộ")]
        INTERNAL  = 0,

        [Description("Thuê")]
        RENT = 1
    }
}
