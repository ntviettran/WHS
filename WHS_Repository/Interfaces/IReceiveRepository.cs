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
        /// Chỉnh sửa phiếu NPL
        /// </summary>
        /// <param name="fabric"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        Task<Response<int>> UpdateReceiveAsync(int id, DataTable detail);

        /// <summary>
        /// Lấy ra detail chi tiết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response<List<D>>> GetReceiveDetailAsync(GroupReceiveDto receiveData);
    }
}
