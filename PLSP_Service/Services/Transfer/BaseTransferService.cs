using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Dto.Fabric;
using WHS.Core.Dto.PLDG;
using WHS.Core.Dto.PLSP;
using WHS.Core.Dto.Receive;
using WHS.Core.Dto.Transfer;
using WHS.Core.Enums;
using WHS.Core.Query.Base;
using WHS.Core.Query.Transfer;
using WHS.Core.Response;
using WHS.Core.Utils;
using WHS.Repository.Interfaces;
using WHS.Service.Interface;

namespace WHS.Service.Services.Transfer
{
    public class BaseTransferService : ITransferService
    {
        private ITransferRepository _transferRepository;

        public BaseTransferService(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        /// <summary>
        /// Láy ra id mới
        /// </summary>
        /// <returns></returns>
        public async Task<Response<int>> GetNewId()
        {
            return await _transferRepository.GetNewId();
        }

        /// <summary>
        /// Lấy ra danh sách danh sách detail cần tạo
        /// </summary>
        /// <param name="fabricDetails"></param>
        /// <param name="plspDetails"></param>
        /// <param name="pldgDetails"></param>
        /// <returns></returns>
        private List<TransferDetailCreateDto> GetDetailTransfer(List<FabricTransferDetailDto> fabricDetails, List<PlspTransferDetailDto> plspDetails, List<PLDGTransferDetailDto> pldgDetails)
        {
            var allDetails = new List<TransferDetailCreateDto>();

            List<TransferDetailCreateDto> fabrics = fabricDetails.Select(f => new TransferDetailCreateDto()
            {
                DetailID = f.ID,
                DetailType = E_NPLType.FABRIC,
                EstimateQuantity = f.EstimateQuantity,
                QuantityStatus = f.QuantityStatus,
                LengthStatus = f.LengthStatus,
                WeightStatus = f.WeightStatus
            }).ToList();

            List<TransferDetailCreateDto> plsp = plspDetails.Select(f => new TransferDetailCreateDto()
            {
                DetailID = f.ID,
                DetailType = E_NPLType.PLSP,
                EstimateQuantity = f.EstimateQuantity,
                QuantityStatus = f.QuantityStatus
            }).ToList();

            List<TransferDetailCreateDto> pldg = pldgDetails.Select(f => new TransferDetailCreateDto()
            {
                DetailID = f.ID,
                DetailType = E_NPLType.PLDG,
                EstimateQuantity = f.EstimateQuantity,
                QuantityStatus = f.QuantityStatus
            }).ToList();

            allDetails.AddRange(fabrics);
            allDetails.AddRange(plsp);
            allDetails.AddRange(pldg);

            return allDetails;
        }

        /// <summary>
        /// Tạo phiếu điều chuyển mới
        /// </summary>
        /// <param name="transferData"></param>
        /// <param name="fabricDetails"></param>
        /// <param name="plspDetails"></param>
        /// <param name="pldgDetails"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> CreateNewTransferAsync(TransferDto transferData, List<FabricTransferDetailDto> fabricDetails, List<PlspTransferDetailDto> plspDetails, List<PLDGTransferDetailDto> pldgDetails)
        {
            List< TransferDetailCreateDto> allDetails = GetDetailTransfer(fabricDetails, plspDetails, pldgDetails);

            return await _transferRepository.CreateNewTransferAsync(transferData, allDetails);
        }

        /// <summary>
        /// Sửa phiếu diều phối
        /// </summary>
        /// <param name="transferData"></param>
        /// <param name="transferDetail"></param>
        /// <returns></returns>
        public async Task<Response<int>> UpdateTransferAsync(TransferDto transferData, List<FabricTransferDetailDto> fabricDetails, List<PlspTransferDetailDto> plspDetails, List<PLDGTransferDetailDto> pldgDetails)
        {
            List<TransferDetailCreateDto> allDetails = GetDetailTransfer(fabricDetails, plspDetails, pldgDetails);

            return await _transferRepository.UpdateTransferAsync(transferData, allDetails);
        }

        /// <summary>
        /// Get dữ liệu chia theo page
        /// </summary>
        /// <param name="paginate"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<Response<PageDto<TransferDto>>> GetTransferByPageAsync(Paginate paginate, TransferSearch search)
        {
            return await _transferRepository.GetTransferByPageAsync(paginate, search);
        }


        /// <summary>
        /// Update ngày thực hiện là ngày khi gọi hàm
        /// </summary>
        /// <param name="transferId"></param>
        /// <returns></returns>
        public async Task<Response<int>> UpdateExecDate(int transferId)
        {
            return await _transferRepository.UpdateExecDate(transferId);
        }

        /// <summary>
        /// Update ngày về kho là ngày khi gọi hàm
        /// </summary>
        /// <param name="transferId"></param>
        /// <returns></returns>
        public async Task<Response<int>> UpdateWarhouseDate(int transferId)
        {
            return await _transferRepository.UpdateWarhouseDate(transferId);
        }

        /// <summary>
        /// Update số lượng thực tế nhận được
        /// </summary>
        /// <param name="fabricDetail"></param>
        /// <param name="plspDetail"></param>
        /// <param name="pldgDetail"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> UpdateQuantityTransfer(List<FabricTransferDetailDto> fabricDetails, List<PlspTransferDetailDto> plspDetails, List<PLDGTransferDetailDto> pldgDetails)
        {
            var allDetails = new List<TransferQuantityDetailDto>();

            List<TransferQuantityDetailDto> fabrics = fabricDetails.Select(f => new TransferQuantityDetailDto()
            {
                ID = f.TransferDetailId,
                ReceivedQuantity = f.ReceivedQuantity,
                LengthReceived = f.LengthReceived,
                WeightReceived = f.WeightReceived,
                QuantityStatus = TransferUtils.GetQuantityIntStatus(f.QuantityToReceived, f.ReceivedQuantity),
                LengthStatus = TransferUtils.GetQuantityFloatStatus(f.FabricLength, f.LengthReceived),
                WeightStatus = TransferUtils.GetQuantityFloatStatus(f.FabricWeight, f.WeightReceived),
            }).ToList();

            List<TransferQuantityDetailDto> plsp = plspDetails.Select(f => new TransferQuantityDetailDto()
            {
                ID = f.TransferDetailId,
                ReceivedQuantity = f.ReceivedQuantity,
                QuantityStatus = TransferUtils.GetQuantityIntStatus(f.QuantityToReceived, f.ReceivedQuantity)
            }).ToList();

            List<TransferQuantityDetailDto> pldg = pldgDetails.Select(f => new TransferQuantityDetailDto()
            {
                ID = f.TransferDetailId,
                ReceivedQuantity = f.ReceivedQuantity,
                QuantityStatus = TransferUtils.GetQuantityIntStatus(f.QuantityToReceived, f.ReceivedQuantity)
            }).ToList();

            allDetails.AddRange(fabrics);
            allDetails.AddRange(plsp);
            allDetails.AddRange(pldg);

            return await _transferRepository.UpdateQuantityTransfer(allDetails);
        }

        /// <summary>
        /// Update trạng thái status fail
        /// </summary>
        /// <param name="transferId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<int>> UpdateTransferStatus(int transferId, E_TransferStatus status)
        {
            return await _transferRepository.UpdateTransferStatus(transferId, status);
        }

        /// <summary>
        /// Cancel các transfer theo id
        /// </summary>
        /// <param name="transferIds"></param>
        /// <returns></returns>
        public async Task<Response<int>> CancelTransfers(List<int> transferIds)
        {
            return await _transferRepository.CancelTransfers(transferIds);
        }
    } 
}
