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
using WHS.Repository.Interfaces;
using WHS.Service.Interface;

namespace PLSP.Service.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Xử lý login tài khoản
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<Response<UserInfoDto>> GetUser(string ssid)
        {
            return await _userRepository.GetUser(ssid);
        }

        public async Task<Response<PageDto<UserInfoDto>>> GetUserPage(Paginate paginate, int? code)
        {
            return await _userRepository.GetUserPage(paginate, code);
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> UpdateUser(int id, UserCreateDto user)
        {
            return await _userRepository.UpdateUser(id, user);
        }

        /// <summary>
        /// Thêm mới user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<Response<int>> CreateUser(UserCreateDto user)
        {
            return await _userRepository.CreateUser(user);
        }

        /// <summary>
        /// Xóa user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response<int>> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }
    }
}
