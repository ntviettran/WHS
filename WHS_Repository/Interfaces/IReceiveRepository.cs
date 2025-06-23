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

    public interface IReceiveRepository
    {
        /// <summary>
        /// Lấy ra danh sách nhận NPL
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="receiveSearch"></param>
        /// <returns></returns>
        Task<Response<PageDto<ReceiveDto>>> GetReceiveAsync(Paginate paginate, ReceiveSearch receiveSearch);
    }

    public interface IReceiveRepository<T, D> : IReceiveRepository
    {
        /// <summary>
        /// Tạo mới phiếu NPL
        /// </summary>
        /// <param name="fabric"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        Task<Response<int>> CreateReceiveAsync(T data, DataTable detail);

        /// <summary>
        /// Chỉnh sửa phiếu NPL
        /// </summary>
        /// <param name="fabric"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        Task<Response<int>> UpdateReceiveAsync(int id, T data, DataTable detail);

        /// <summary>
        /// Lấy ra detail chi tiết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response<List<D>>> GetReceiveDetailAsync(int id);
    }
}
