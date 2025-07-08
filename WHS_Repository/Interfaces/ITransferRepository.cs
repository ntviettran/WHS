using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Dto.Transfer;
using WHS.Core.Enums;
using WHS.Core.Query.Base;
using WHS.Core.Query.Transfer;
using WHS.Core.Response;

namespace WHS.Repository.Interfaces
{
    /// <summary>
    /// Interface dùng chung 
    /// </summary>
    public interface ITransferRepository
    {
        /// <summary>
        /// Lấy ra id mới của đợt chuyển 
        /// </summary>
        /// <returns></returns>
        Task<Response<int>> GetNewId();

        /// <summary>
        /// Tạo phiếu diều phối
        /// </summary>
        /// <param name="transferData"></param>
        /// <param name="transferDetail"></param>
        /// <returns></returns>
        Task<Response<int>> CreateNewTransferAsync(TransferDto transferData, List<TransferDetailCreateDto> transferDetail);

        /// <summary>
        /// Sửa phiếu diều phối
        /// </summary>
        /// <param name="transferData"></param>
        /// <param name="transferDetail"></param>
        /// <returns></returns>
        Task<Response<int>> UpdateTransferAsync(TransferDto transferData, List<TransferDetailCreateDto> transferDetail);

        /// <summary>
        /// Get dữ liệu chia theo page
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<Response<PageDto<TransferDto>>> GetTransferByPageAsync(Paginate paginate, TransferSearch search);
    }

    /// <summary>
    /// Interface với chức năng riêng cho mỗi type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITransferRepository<T, D> : ITransferRepository
    {
        /// <summary>
        /// Lấy ra transfer cần được điều phối
        /// </summary>
        /// <returns></returns>
        Task<Response<List<T>>> GetTransferCoordinateByStatus(E_DispatchTransfer status);

        /// <summary>
        /// Lấy ra detail transfer
        /// </summary>
        /// <returns></returns>
        Task<Response<List<D>>> GetTransferDetail(int transferId);
    }
}
