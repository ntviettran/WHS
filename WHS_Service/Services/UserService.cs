using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.User;
using WHS.Core.Response;
using WHS.Repository.Interfaces;
using WHS.Service.Interface;

namespace WHS.Service.Services
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
        public async Task<Response<string>> Login(UserDto user)
        {
            return await _userRepository.Login(user);
        }

        /// <summary>
        /// Get ra thông tin của user đã login
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<UserInfoDto>> GetUserInfo()
        {
            return await _userRepository.GetUserInfo();
        }
    }
}
