using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Dto.PLSP
{
    public class PlspDto
    {
        public int Id { get; set; }
        public string MO { get; set; } = String.Empty;
        public string Supplier { get; set; } = String.Empty;
        public string PlspType { get; set; } = String.Empty;
        public string PlspCode { get; set; } = String.Empty;
        public string NplColor { get; set; } = String.Empty;
        public string MarketCode { get; set; } = String.Empty;
        public string Size { get; set; } = String.Empty;
        public string PlspColor { get; set; } = String.Empty;
        public int? QuantityToReceived { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime AvailableDate { get; set; }
        public DateTime ExpectedDate { get; set; }
    }
}
