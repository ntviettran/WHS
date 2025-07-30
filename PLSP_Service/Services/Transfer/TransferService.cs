using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto.Transfer;
using WHS.Core.Enums;
using WHS.Core.Query.Receive;
using WHS.Core.Response;
using WHS.Repository.Interfaces;
using WHS.Service.Interface;
using WHS.Service.Services.Transfer;

namespace WHS.Service.Services.Coordinate
{
    public class TransferService<T, D> : BaseTransferService, ITransferService<T, D>
    {
        protected ITransferRepository<T, D> _repository;

        public TransferService(ITransferRepository<T, D> transferRepository) : base(transferRepository)
        {
            _repository = transferRepository;
        }

        /// <summary>
        /// Lấy ra danh sách những pl cần điều phối
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<Response<List<T>>> GetTransferCoordinateByStatus(E_DispatchTransfer status)
        {
            return await _repository.GetTransferCoordinateByStatus(status);
        }

        /// <summary>
        /// Lấy ra danh sách detail theo transferID
        /// </summary>
        /// <param name="transferId"></param>
        /// <returns></returns>
        public async Task<Response<List<D>>> GetTransferDetail(int transferId)
        {
            return await _repository.GetTransferDetail(transferId);
        }

        /// <summary>
        /// Lấy ra danh sách cần điều phối và danh sách đã điều phối
        /// </summary>
        /// <param name="idNplReceived"></param>
        /// <returns></returns>
        public async Task<Response<List<T>>> GetCoordinationHistory(ReceiveHistorySearch search)
        {
            return await _repository.GetCoordinationHistory(search);
        }
    }
}
