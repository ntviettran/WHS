using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.Fabric;
using WHS.Core.Enums;

namespace WHS.Core.Dto.Transfer
{
    public class FabricCoordinationDto : Coordination
    {
        public string Style { get; set; } = String.Empty;
        public string Color { get; set; } = String.Empty;
        public string FabricType { get; set; } = String.Empty;
        public string Batch { get; set; } = String.Empty;
        public float FabricLength { get; set; }
        public float FabricWeight { get; set; }
        public float LengthReceived { get; set; }
        public float WeightReceived { get; set; }
    }
}
