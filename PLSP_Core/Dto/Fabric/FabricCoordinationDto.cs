using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.Transfer;
using WHS.Core.Enums;

namespace WHS.Core.Dto.Fabric
{
    public class FabricCoordinationDto : Coordination
    {
        public string Style { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string FabricType { get; set; } = string.Empty;
        public string Batch { get; set; } = string.Empty;
        public float FabricLength { get; set; }
        public string LengthUnit { get; set; } = string.Empty;
        public float FabricWeight { get; set; }
        public string WeightUnit { get; set; } = string.Empty;
        public float RollWidth { get; set; }
        public float LengthReceived { get; set; }
        public float WeightReceived { get; set; }
        public int FabricNumber { get; set; }
    }
}
