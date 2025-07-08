using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Dto.PLSP
{
    public class PlspDetailDto
    {
        public string PlspType { get; set; } = String.Empty;
        public string PlspCode { get; set; } = String.Empty;
        public string NplColor { get; set; } = String.Empty;
        public string MarketCode { get; set; } = String.Empty;
        public string Size { get; set; } = String.Empty;
        public string PlspColor { get; set; } = String.Empty;
        public int QuantityToReceived { get; set; }
    }
}
