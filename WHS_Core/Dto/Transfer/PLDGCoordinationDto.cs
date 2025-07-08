using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Dto.Transfer
{
    public class PLDGCoordinationDto : Coordination
    {
        public string PldgType { get; set; } = String.Empty;
        public string PackCode { get; set; } = String.Empty;
        public string Color { get; set; } = String.Empty;
    }
}
