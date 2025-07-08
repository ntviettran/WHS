using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Dto.Transfer
{
    public class FabricTransferDetailDto : TransferDetailDto
    {
        public string Style { get; set; } = String.Empty;
        public string Color { get; set; } = String.Empty;
        public string FabricType { get; set; } = String.Empty;
        public string Batch { get; set; } = String.Empty;
        public float RollWidth { get; set; }
        public string FabricNumber { get; set; } = String.Empty;
        public float FabricLength { get; set; }
        public float FabricWeight { get; set; }
    }
}
