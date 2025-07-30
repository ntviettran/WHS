using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLSP.Core.Dto.User
{
    public class UserCreateDto
    {
        public string SSID { get; set; } = String.Empty;
        public int Code { get; set; }
        public int LimitQuantity { get; set; }
    }
}
