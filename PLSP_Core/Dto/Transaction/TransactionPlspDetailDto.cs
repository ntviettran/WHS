using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLSP.Core.Dto.Transaction
{
    public class TransactionPlspDetailDto
    {
        public int ID { get; set; }
        public string MO { get; set; } = String.Empty;
        public string Supplier { get; set; } = String.Empty;
        public string PlspType { get; set; } = String.Empty;
        public string PlspCode { get; set; } = String.Empty;
        public string NplColor { get; set; } = String.Empty;
        public string MarketCode { get; set; } = String.Empty;
        public string Size { get; set; } = String.Empty;
        public string PlspColor { get; set; } = String.Empty;
        public string Area { get; set; } = String.Empty;
        public string Code { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty;
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedAtVN => CreatedAt.ToString("dd/MM/yyyy HH:mm");
    }
}
