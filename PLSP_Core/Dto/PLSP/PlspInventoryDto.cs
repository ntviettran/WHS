using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLSP.Core.Dto.PLSP
{
    public class PlspInventoryDto
    {
        public int ID { get; set; }
        public int? NplId { get; set; }
        public string MO { get; set; } = String.Empty;
        public string Supplier { get; set; } = String.Empty;
        public string PlspType { get; set; } = String.Empty;
        public string PlspCode { get; set; } = String.Empty;
        public string NplColor { get; set; } = String.Empty;
        public string MarketCode { get; set; } = String.Empty;
        public string Size { get; set; } = String.Empty;
        public string PlspColor { get; set; } = String.Empty;
        public int InventoryQuantity { get; set; }
    }
}
