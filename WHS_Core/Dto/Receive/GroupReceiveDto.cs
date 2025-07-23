using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Dto.Receive
{
    public class GroupReceiveDto
    {
        public int Id { get; set; }
        public string MO { get; set; } = String.Empty;
        public string Style { get; set; }  = String.Empty;
        public string Color { get; set; } = String.Empty;
        public string TypeDetail { get; set; } = String.Empty;
        public string Supplier { get; set; } = String.Empty;
        public int QuantityToReceived { get; set; }
        public int ReceivedQuantity { get; set; }
        public int ExpectedQuantity { get; set; }
    }
}
