using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.PLDG;

namespace WHS.Core.Dto.Transfer
{
    public class PLDGTransferDetailDto: TransferDetailDto
    {
        public string PldgType { get; set; } = String.Empty;
        public string PackCode { get; set; } = String.Empty;
        public string PoCode { get; set; } = String.Empty;
        public string Color { get; set; } = String.Empty;
        public float NetWeight { get; set; }
        public float GrossWeight { get; set; }
        public string PldgSize { get; set; } = String.Empty;
    }
}
