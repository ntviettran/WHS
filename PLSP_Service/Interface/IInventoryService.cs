using PLSP.Core.Dto.Location;
using PLSP.Core.Dto.Transaction;
using PLSP.Core.Enums;
using PLSP.Core.Query.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Dto.User;
using WHS.Core.Enums;
using WHS.Core.Query.Base;
using WHS.Core.Response;

namespace PLSP.Service.Interface
{
    public interface IInventoryService
    {
        /// <summary>
        /// Kiểm tra người nhận có quyền được nhận hàng không
        /// </summary>
        /// <param name="ssid"></param>
        /// <returns></returns>
        Task<Response<(UserInfoDto, int)>> CheckExportValid(string ssid);
    }

    public interface IInventoryService<T, D>
        where T : class
        where D : class
    {
        /// <summary>
        /// Lấy ra danh sách tồn kho theo phân trang
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="mo"></param>
        /// <returns></returns>
        Task<Response<PageDto<T>>> GetInventoryAsync(Paginate paginate, string mo);

        /// <summary>
        /// Lấy ra danh sách tồn kho theo phân trang
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="mo"></param>
        /// <returns></returns>
        Task<Response<PageDto<T>>> GetBlockAsync(Paginate paginate, string mo);

        /// <summary>
        /// Lấy ra tổng nguyên phụ liệu id đã phân phối về vị trí
        /// </summary>
        /// <param name="splitID"></param>
        /// <returns></returns>
        Task<Response<int>> GetTotalQuantityLocation(int splitID);

        /// <summary>
        /// Lấy ra danh sách tồn kho theo vị trí có phân trang
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<Response<PageDto<D>>> GetInventoryLocationsAsync(Paginate paginate, LocationSearch search);

        /// <summary>
        /// Lấy ra npl theo id
        /// </summary>
        /// <returns></returns>
        Task<Response<D>> GetInventoryLocationAsync(int id);

        /// <summary>
        /// Update vị trí (edit, delete, add) của npl
        /// </summary>
        /// <param name="nplId"></param>
        /// <param name="nplType"></param>
        /// <param name="whType"></param>
        /// <param name="locations"></param>
        /// <returns></returns>
        Task<Response<List<D>>> UpdateLocationNpl(int splitId, int nplId, E_NPLType nplType, List<LocationDto> locations);

        /// <summary>
        /// Lấy số lượng mỗi vị trí của id tk đã chia vị trí
        /// </summary>
        /// <param name="splitID"></param>
        /// <returns></returns>
        Task<Response<List<QuantityPerLocation>>> GetQuantityPerLocation(int splitID);
    }
}
