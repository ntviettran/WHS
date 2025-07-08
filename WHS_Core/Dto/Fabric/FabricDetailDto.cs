using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Dto.Fabric
{
    public class FabricDetailDto
    {
        public int ID { get; set; }
        public string Style { get; set; } = String.Empty;
        public string Color { get; set; } = String.Empty;
        public string FabricType { get; set; } = String.Empty;
        public string Batch { get; set; } = String.Empty;
        public float FabricLength { get; set; }
        public string LengthUnit { get; set; } = String.Empty;
        public float FabricWeight { get; set; }
        public string WeightUnit { get; set; } = String.Empty;
        public float RollWidth { get; set; }
        public string WidthUnit { get; set; } = String.Empty;
        public int FabricNumber { get; set; }
        public int QuantityToReceived { get; set; }
    }
}
