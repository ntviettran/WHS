using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Dto.PLDG
{
    public class PldgDto
    {
        public string MO { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public string Supplier { get; set; } = String.Empty;
        public int QuantityToReceive { get; set; }
        public int QuantityEstimate { get; set; }
    }
}
