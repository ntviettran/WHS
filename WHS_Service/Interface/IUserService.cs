using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.User;
using WHS.Core.Response;

namespace WHS.Service.Interface
{
    public interface IUserService
    {
        /// <summary>
        /// Xử lý login tài khoản
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<Response<string>> Login(UserDto user);

        /// <summary>
        /// Lấy ra thông tin của user đã login
        /// </summary>
        /// <returns></returns>
        Task<Response<UserInfoDto>> GetUserInfo();
    }
}
