using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;

namespace WHS.Core.Session
{
    public static class Session
    {
        public static string AccessToken { get; set; } = String.Empty;
        public static UserInfoDto CurrentUser { get; set; } = new UserInfoDto();
    }
}
