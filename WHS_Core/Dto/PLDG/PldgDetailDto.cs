using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Dto.PLDG
{
    public class PldgDetailDto
    {
        public int Id { get; set; }
        public string PldgType { get; set; } = String.Empty;
        public string PackCode { get; set; } = String.Empty;
        public string PoCode { get; set; } = String.Empty;
        public int QuantityPerCarton { get; set; }
        public float NetWeight { get; set; }
        public float GrossWeight { get; set; }
        public string Color { get; set; } = String.Empty;
        public float PldgWeight { get; set; }
        public string WeightUnit { get; set; } = String.Empty;
        public string PldgSize { get; set; } = String.Empty;
        public string SizeUnit { get; set; } = String.Empty;
        public int QuantityToReceived { get; set; }
    }
}
