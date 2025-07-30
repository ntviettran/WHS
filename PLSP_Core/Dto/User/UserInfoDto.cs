using PLSP.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Dto.User
{
    public class UserInfoDto
    {
        public int ID { get; set; }
        public string SSID { get; set; } = string.Empty;
        public int Code { get; set; }
        public int Decentralization { get; set; }
        public string? Area { get; set; }
        public int? LimitQuantity { get; set; }
        public int FactoryID { get; set; }

        public E_WHType GetCurrentType()
        {
            return Decentralization switch
            {
                0 => E_WHType.PPC,
                1 => E_WHType.WAREHOUSE,
                2 => E_WHType.BLOCK,
                3 => E_WHType.WORKER
            };
        }
    }
}
