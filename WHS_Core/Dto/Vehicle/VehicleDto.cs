using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Enums;
using WHS.Core.Utils;

namespace WHS.Core.Dto.Vehicle
{
    public class VehicleDto
    {
        public int ID { get; set; }
        public E_VehicleType VehicleType { get; set; }
        public E_VehicleMode VehicleMode { get; set; }
        public string LicensePlate { get; set; } = String.Empty;
        public string? SealNumber { get; set; } = String.Empty;
        public float? Capacity { get; set; }
        public string VehicleTypeDescription => EnumHelper.GetEnumDescription(VehicleType);
        public string VehicleModeDescription => EnumHelper.GetEnumDescription(VehicleMode);
    }
}
