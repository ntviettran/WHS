using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLSP.Core.Query.Transaction
{
    public class HistorySearch
    {
        public string? MO { get; set; }
        public string? Location { get; set; }
        public string? Area { get; set; }
        public string? Code { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
