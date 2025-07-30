using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.Transfer;

namespace WHS.Core.Dto.PLSP
{
    public class PlspCoordinationDto: Coordination
    {
        public string PlspType { get; set; } = string.Empty;
        public string PlspCode { get; set; } = string.Empty;
        public string NplColor { get; set; } = string.Empty;
        public string MarketCode { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string PlspColor { get; set; } = string.Empty;
    }
}
