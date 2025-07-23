using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Enums;
using WHS.Core.Utils;

namespace WHS.Core.Dto.PLDG
{
    public class PldgReceivedDto : PldgDto
    {
        public int ReceivedQuantity { get; set; }
        public int RemainingQuantity { get; set; }
        public int EstimateQuantity { get; set; }
        public E_TransferReceived Status { get; set; }
        public E_DispatchTransfer DispatchStatus { get; set; }
        public string StatusDescription => EnumHelper.GetEnumDescription(Status);
        public string DispatchStatusDescription => EnumHelper.GetEnumDescription(DispatchStatus);
    }
}
