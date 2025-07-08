using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Enums;

namespace WHS.Core.Query.Vehicle
{
    public class VehicleSearch
    {
        public int VehicleMode { get; set; }
        public string LincensePlate { get; set; } = String.Empty;
    }
}
