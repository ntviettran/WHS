using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Enums;
using WHS.Core.Utils;

namespace WHS.Core.Dto.Transfer
{
    public class TransferDetailCreateDto
    {
        public E_NPLType DetailType { get; set; }
        public int DetailID { get; set; }
        public int EstimateQuantity { get; set; }
        public int? EstimateLength { get; set; }
        public int? EstimateWeight { get; set; }
        public E_QuantityStatus QuantityStatus { get; set; }
        public E_QuantityStatus LengthStatus { get; set; }
        public E_QuantityStatus WeightStatus { get; set; }
        public int QuantityToReceived { get; set; }
    }

    public class TransferDetailDto : TransferDetailCreateDto
    {
        public int ID { get; set; }
        public string MO { get; set; } = String.Empty;
        public int IdNplReceived { get; set; }
        public int QuantityReceived { get; set; }
        public float LengthReceived { get; set; }
        public float WeightReceived { get; set; }
        public string QuantityStatusDescription => EnumHelper.GetEnumDescription(QuantityStatus);
        public string LengthStatusDescription => EnumHelper.GetEnumDescription(LengthStatus);
        public string WeightStatusDescription => EnumHelper.GetEnumDescription(WeightStatus);

    }
}
