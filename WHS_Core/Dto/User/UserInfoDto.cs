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
        public int UserCode { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; } = string.Empty;
    }
}
