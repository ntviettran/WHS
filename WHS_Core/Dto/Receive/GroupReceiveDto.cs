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
        public string? MO { get; set; }
        public string? Style { get; set; }
        public string? Color { get; set; }
        public string? TypeDetail { get; set; }
        public string? Supplier { get; set; }
        public int QuantityToReceived { get; set; }
        public int ReceivedQuantity { get; set; }
        public int ExpectedQuantity { get; set; }
    }
}
