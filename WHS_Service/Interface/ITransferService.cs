using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Dto.Transfer;
using WHS.Core.Enums;
using WHS.Core.Query.Base;
using WHS.Core.Query.Transfer;
using WHS.Core.Response;

namespace WHS.Service.Interface
{
    public interface ITransferService
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
        Task<Response<int>> CreateNewTransferAsync(TransferDto transferData, List<FabricCoordinationDto> fabricDetails, List<PLSPCoordinationDto> plspDetails, List<PLDGCoordinationDto> pldgDetails);

        /// <summary>
        /// Sửa phiếu diều phối
        /// </summary>
        /// <param name="transferData"></param>
        /// <param name="transferDetail"></param>
        /// <returns></returns>
        Task<Response<int>> UpdateTransferAsync(TransferDto transferData, List<FabricCoordinationDto> fabricDetails, List<PLSPCoordinationDto> plspDetails, List<PLDGCoordinationDto> pldgDetails);

        /// <summary>
        /// Get dữ liệu chia theo page
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<Response<PageDto<TransferDto>>> GetTransferByPageAsync(Paginate paginate, TransferSearch search);
    }

    public interface ITransferService<T, D> : ITransferService
    {
        /// <summary>
        /// Lấy ra detail transfer
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
