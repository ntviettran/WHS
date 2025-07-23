using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Enums;

namespace WHS.Core.Dto.Fabric
{
    public class FabricDto
    {
        public int ID { get; set; }
        public string MO { get; set; } = String.Empty;
        public string Supplier { get; set; } = String.Empty;
        public string Style { get; set; } = String.Empty;
        public string Color { get; set; } = String.Empty;
        public string FabricType { get; set; } = String.Empty;
        public string Batch { get; set; } = String.Empty;
        public float? FabricLength { get; set; }
        public string LengthUnit { get; set; } = String.Empty;
        public float? FabricWeight { get; set; }
        public string WeightUnit { get; set; } = String.Empty;
        public float? RollWidth { get; set; }
        public string WidthUnit { get; set; } = String.Empty;
        public int? FabricNumber { get; set; }
        public int? QuantityToReceived { get; set; }
        public string QuantityUnit { get; set; } = String.Empty;
        public DateTime OrderDate { get; set; }
        public DateTime AvailableDate { get; set; }
        public DateTime ExpectedDate { get; set; }
    }
}
