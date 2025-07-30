using PLSP.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Enums;

namespace PLSP.Core.Dto.Location
{
    public class LocationDto
    {
        public int ID { get; set; }
        public string Location { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int QuantityPerBag { get; set; }
    }
}
