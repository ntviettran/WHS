using PLSP.Core.Dto.Location;
using PLSP.Core.Dto.Transaction;
using PLSP.Core.Enums;
using PLSP.Repository.Interfaces;
using PLSP.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.User;
using WHS.Core.Enums;
using WHS.Core.Response;
using WHS.Core.Session;
using WHS.Repository.Interfaces;
using WHS.Repository.Repository.Coordinate;

namespace PLSP.Service.Services.Inventory
{
    public class BaseInventoryService : IInventoryService
    {
        private IUserRepository _userRepository;
        private ITransactionRepository _transactionRepository;

        public BaseInventoryService(IUserRepository userRepository, ITransactionRepository transactionRepository)
        {
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
        }

        /// <summary>
        /// Kiểm tra người nhận xem có được nhận hàng không
        /// </summary>
        /// <param name="ssid"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<(UserInfoDto, int)>> CheckExportValid(string ssid)
        {
            Response<UserInfoDto> resUser = await _userRepository.GetUser(ssid);
            
            if (!resUser.IsSuccess) {
                return Response<(UserInfoDto, int)>.Fail("Thẻ này không có quyền trong app này!");
            }
            
            if (resUser.Data == null) return Response<(UserInfoDto, int)>.Fail("Thẻ này không có quyền trong app này!");

            UserInfoDto user = resUser.Data;
            E_WHType currentUserType = Session.CurrentUser.GetCurrentType();
            E_WHType userInputType = user.GetCurrentType();


            if (currentUserType == E_WHType.WAREHOUSE && userInputType == E_WHType.BLOCK)
            {
                return Response<(UserInfoDto, int)>.Success((resUser.Data, 0));
            }

            if (currentUserType == E_WHType.BLOCK && userInputType == E_WHType.WORKER)
            {
                Response<int> limitRes = await _transactionRepository.CheckLimitQuantity(resUser.Data.LimitQuantity ?? 0, resUser.Data.Code);

                if (limitRes.IsSuccess) { 
                    return Response<(UserInfoDto, int)>.Success((resUser.Data, limitRes.Data));
                }
                else
                {
                    return Response<(UserInfoDto, int)>.Fail(limitRes.Message);
                }
            }

            return Response<(UserInfoDto, int)>.Fail("Không có quyền nhận hàng ở khu vực này");
        }
    }
}
