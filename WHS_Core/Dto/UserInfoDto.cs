using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Core.Dto
{
    public class UserInfoDto
    {
        public int id { get; set; }
        public int userCode { get; set; }
        public string fullName { get; set; } = string.Empty;
        public int companyId { get; set; }
        public int departmentId { get; set; }
        public string departmentCode { get; set; } = string.Empty;
    }
}
