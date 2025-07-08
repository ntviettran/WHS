using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Core.Dto;
using WHS.Core.Dto.Receive;
using WHS.Core.Dto.Transfer;
using WHS.Core.Enums;
using WHS.Core.Query.Base;
using WHS.Core.Query.Transfer;
using WHS.Core.Response;
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
        private List<TransferDetailCreateDto> GetDetailTransfer(List<FabricCoordinationDto> fabricDetails, List<PLSPCoordinationDto> plspDetails, List<PLDGCoordinationDto> pldgDetails)
        {
            var allDetails = new List<TransferDetailCreateDto>();

            List<TransferDetailCreateDto> fabrics = fabricDetails.Select(f => new TransferDetailCreateDto()
            {
                DetailID = f.ID,
                DetailType = E_NPLType.FABRIC,
                EstimateQuantity = f.EstimateQuantity,
                QuantityStatus = GetQuantityIntStatus(f.EstimateQuantity, f.QuantityReceived),
                LengthStatus = GetQuantityFloatStatus(f.FabricLength, f.LengthReceived),
                WeightStatus = GetQuantityFloatStatus(f.FabricWeight, f.WeightReceived)
            }).ToList();

            List<TransferDetailCreateDto> plsp = plspDetails.Select(f => new TransferDetailCreateDto()
            {
                DetailID = f.ID,
                DetailType = E_NPLType.PLSP,
                EstimateQuantity = f.EstimateQuantity,
                QuantityStatus = GetQuantityIntStatus(f.EstimateQuantity, f.QuantityReceived)
            }).ToList();

            List<TransferDetailCreateDto> pldg = pldgDetails.Select(f => new TransferDetailCreateDto()
            {
                DetailID = f.ID,
                DetailType = E_NPLType.PLDG,
                EstimateQuantity = f.EstimateQuantity,
                QuantityStatus = GetQuantityIntStatus(f.EstimateQuantity, f.QuantityReceived)
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
        public async Task<Response<int>> CreateNewTransferAsync(TransferDto transferData, List<FabricCoordinationDto> fabricDetails, List<PLSPCoordinationDto> plspDetails, List<PLDGCoordinationDto> pldgDetails)
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
        public async Task<Response<int>> UpdateTransferAsync(TransferDto transferData, List<FabricCoordinationDto> fabricDetails, List<PLSPCoordinationDto> plspDetails, List<PLDGCoordinationDto> pldgDetails)
        {
            List<TransferDetailCreateDto> allDetails = GetDetailTransfer(fabricDetails, plspDetails, pldgDetails);

            return await _transferRepository.UpdateTransferAsync(transferData, allDetails);
        }

        /// <summary>
        /// Get ra status của số lượng
        /// </summary>
        /// <param name="estimate"></param>
        /// <param name="received"></param>
        /// <returns></returns>
        private E_QuantityStatus GetQuantityIntStatus(int estimate, int received)
        {
            if (received == 0) return E_QuantityStatus.PENDING;
            if (received == estimate) return E_QuantityStatus.SUFFICIENT;
            if (received > estimate) return E_QuantityStatus.EXCESS;
            return E_QuantityStatus.LACKING;
        }

        /// <summary>
        /// Lấy ra status của so sánh số lượng ban đầu  với thực nhận
        /// </summary>
        /// <param name="init"></param>
        /// <param name="received"></param>
        /// <returns></returns>
        private E_QuantityStatus GetQuantityFloatStatus(float init, float received)
        {
            if (received == 0) return E_QuantityStatus.PENDING;
            if (received == init) return E_QuantityStatus.SUFFICIENT;
            if (received > init) return E_QuantityStatus.EXCESS;
            return E_QuantityStatus.LACKING;
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
    } 
}
