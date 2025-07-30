using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.Transfer;

namespace WHS.Core.Dto.Fabric
{
    public class FabricTransferDetailDto : TransferDetailDto
    {
        public string Style { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string FabricType { get; set; } = string.Empty;
        public string Batch { get; set; } = string.Empty;
        public float RollWidth { get; set; }
        public int FabricNumber { get; set; }
        public float FabricLength { get; set; }
        public float FabricWeight { get; set; }
    }
}
