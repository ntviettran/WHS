using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Enums;
using WHS.Core.Utils;

namespace WHS.Core.Dto.Transfer
{
    public class  Coordination
    {
        public int ID { get; set; }
        public string MO { get; set; } = String.Empty;
        public int QuantityToReceived { get; set; }
        public int ReceivedQuantity { get; set; }
        public int RemainingQuantity { get; set; }
        public E_TransferReceived Status { get; set; }
        public E_DispatchTransfer DispatchStatus { get; set; }
        public int EstimateQuantity { get; set; }
        public string StatusDescription => EnumHelper.GetEnumDescription(Status);
        public string DispatchStatusDescription => EnumHelper.GetEnumDescription(DispatchStatus);
    }
}
