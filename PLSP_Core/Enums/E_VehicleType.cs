using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Enums
{
    public enum E_VehicleType
    {
        [Description("Container")]
        CONTAINER = 0,

        [Description("Tải")]
        TRUCK = 1
    }
}
