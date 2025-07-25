using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.Receive;
using WHS.Core.Query.Base;
using WHS.Core.Query.Receive;
using WHS.Core.Response;

namespace WHS.Repository.Interfaces
{
    public interface IReceiveRepository<T, D>
    {
        /// <summary>
        /// Lấy ra danh sách group by mo
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="receiveSearch"></param>
        /// <returns></returns>
        Task<Response<PageDto<GroupReceiveDto>>> GetGroupedReceiveAsync(Paginate paginate, ReceiveSearch receiveSearch);

        /// <summary>
        /// Lấy ra danh sách chi tiết
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="receiveSearch"></param>
        /// <returns></returns>
        Task<Response<PageDto<D>>> GetDetailReceiveAsync(Paginate paginate, ReceiveSearch receiveSearch);

        /// <summary>
        /// Check xem có trùng lặp giá trị trong bảng detail không
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        Task<Response<bool>> CheckDuplicateValue(DataTable detail);
       
        /// <summary>
        /// Tạo mới phiếu NPL
        /// </summary>
        /// <param name="fabric"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        Task<Response<int>> CreateReceiveAsync(DataTable detail);

        /// <summary>
        /// Lấy ra detail chi tiết theo thằng group
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response<List<D>>> GetReceiveDetailAsync(GroupReceiveDto receiveData);

        /// <summary>
        /// Lấy ra danh sách dữ liệu chưa điều phối
        /// </summary>
        /// <returns></returns>
        Task<Response<List<T>>> GetListReceiveAsync();

        /// <summary>
        /// Check xem có dữ liệu nào đã điều phối chưa
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<Response<bool>> CheckHasDispatch(List<int> ids);

        /// <summary>
        /// Update phụ liệu chưa điều phối
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<Response<int>> UpdateReceivedDetail(List<T> data);
    }
}
