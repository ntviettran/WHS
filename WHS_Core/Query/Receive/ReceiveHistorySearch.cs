using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Enums;

namespace WHS.Core.Query.Receive
{
    public class ReceiveHistorySearch
    {
        public int ReceiveId { get; set; }
        public int Status { get; set; }
        public int DispatchStatus { get; set; }
    }
}
