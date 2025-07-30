using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.Transfer;

namespace WHS.Core.Dto.PLDG
{
    public class PLDGTransferDetailDto: TransferDetailDto
    {
        public string PldgType { get; set; } = String.Empty;
        public string PldgCode { get; set; } = String.Empty;
        public string PoCode { get; set; } = String.Empty;
        public string Color { get; set; } = String.Empty;
        public float NetWeight { get; set; }
        public float GrossWeight { get; set; }
        public string PldgSize { get; set; } = String.Empty;
    }
}