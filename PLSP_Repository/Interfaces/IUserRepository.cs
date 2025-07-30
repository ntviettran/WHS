using PLSP.Core.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Dto.User;
using WHS.Core.Query.Base;
using WHS.Core.Response;

namespace WHS.Repository.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Xử lý login tài khoản
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<Response<UserInfoDto>> GetUser(string ssid);

        /// <summary>
        /// Lấy ra user
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<Response<PageDto<UserInfoDto>>> GetUserPage(Paginate paginate, int? code);

        /// <summary>
        /// Tạo user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<Response<int>> CreateUser(UserCreateDto user);

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<Response<int>> UpdateUser(int id, UserCreateDto user);

        /// <summary>
        /// Xóa user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response<int>> DeleteUser(int id);
    }
}
