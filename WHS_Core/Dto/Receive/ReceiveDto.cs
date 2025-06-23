using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Dto.Receive
{
    public class ReceiveDto
    {
        public int Id { get; set; }
        public string MO { get; set; } = String.Empty;
        public string Style { get; set; }  = String.Empty;
        public string Color { get; set; } = String.Empty;
        public string TypeDetail { get; set; } = String.Empty;
        public string Supplier { get; set; } = String.Empty;
        public int QuantityToReceive { get; set; }
        public int QuantityReceived { get; set; }
        public int QuantityEstimate { get; set; }
    }
}
