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
        public string MO { get; set; } = String.Empty;
        public string Style { get; set; } = String.Empty;
        public string Color { get; set; } = String.Empty;
        public string FabricType { get; set; } = String.Empty;
        public string Supplier { get; set; } = String.Empty;
        public int QuantityToReceive { get; set; }
        public int QuantityEstimate { get; set; }
    }
}
